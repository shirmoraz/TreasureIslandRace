using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TreasureIslandRace.Models;
using TreasureIslandRace.Game;
using TreasureIslandRace.Persistence;
using System.Drawing.Drawing2D;
using System.Media;

namespace TreasureIslandRace.Forms
{
    public partial class MainForm : Form
    {
        private const int GridSize = 6;

        private readonly Board board = new Board();
        private readonly Dice dice = new Dice();
        private List<Player> players = new List<Player>();
        private int currentPlayerIndex = 0;

        private (Panel Panel, Panel Swatch, Label Name, Label Coins)[] playerCards;

        private int currentDiceFace = 1;
        private float diceRotationAngle = 0f;
        private int diceAnimationTicksLeft;
        private readonly Random animationRandom = new Random();

        private const int MoveAnimationTotalTicks = 15;
        private Player animatingPlayer = null;
        private PointF animatingPixelPosition;
        private PointF moveAnimationStart;
        private PointF moveAnimationEnd;
        private int moveAnimationTicksLeft;

        private readonly List<ConfettiParticle> confettiParticles = new List<ConfettiParticle>();
        private int confettiTicksLeft;
        private readonly Random confettiRandom = new Random();

        private readonly SoundPlayer gameStartSound = new SoundPlayer(@"Sounds\game-start.wav");
        private readonly SoundPlayer diceSound = new SoundPlayer(@"Sounds\dice.wav");
        private readonly SoundPlayer winSound = new SoundPlayer(@"Sounds\orchestral-win.wav");
        private readonly SoundPlayer achievementSound = new SoundPlayer(@"Sounds\achievement.wav");

        public MainForm(List<Player> selectedPlayers)
        {
            InitializeComponent();
            EnableDoubleBuffering(boardPanel);
            EnableDoubleBuffering(picDice);

            playerCards = new[]
            {
                (playerPanel1, colorSwatch1, lblName1, lblCoins1),
                (playerPanel2, colorSwatch2, lblName2, lblCoins2),
                (playerPanel3, colorSwatch3, lblName3, lblCoins3),
                (playerPanel4, colorSwatch4, lblName4, lblCoins4),
            };

            players = selectedPlayers;
            board.SpecialSquareTriggered += Board_SpecialSquareTriggered;

            SetupBoardSquares();
            UpdatePlayerCards();
            lblCurrentTurn.Text = $"תור של: {players[currentPlayerIndex].Name}";
            gameStartSound.Play();
        }

        private void SetupBoardSquares()
        {
            board.Squares.ReplaceAt(4, new ShipSquare(4, 3));
            board.Squares.ReplaceAt(9, new WhirlpoolSquare(9, 2));
            board.Squares.ReplaceAt(15, new TrapSquare(15));
            board.Squares.ReplaceAt(20, new CompassSquare(20));
            board.Squares.ReplaceAt(25, new TreasureSquare(25, 2));
            board.Squares.ReplaceAt(30, new PortalSquare(30, 5));
        }

        private Point GetCellTopLeft(int squareIndex, int cellSize)
        {
            int row = squareIndex / GridSize;
            int colInRow = squareIndex % GridSize;
            int col = (row % 2 == 0) ? colInRow : (GridSize - 1 - colInRow);

            int x = col * cellSize;
            int y = (GridSize - 1 - row) * cellSize;
            return new Point(x, y);
        }

        private void boardPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int cellSize = boardPanel.Width / GridSize;

            DrawSeaBackground(g);
            DrawSquares(g, cellSize);
            DrawPlayerTokens(g, cellSize);
            DrawConfettiParticles(g);
        }

        private void DrawSquares(Graphics g, int cellSize)
        {
            for (int i = 0; i < board.Squares.Count; i++)
            {
                Point topLeft = GetCellTopLeft(i, cellSize);
                Rectangle cellRect = new Rectangle(topLeft.X, topLeft.Y, cellSize, cellSize);

                DrawGlossyCell(g, cellRect, GetColorsForSquare(board.Squares[i]));
                g.DrawRectangle(Pens.White, cellRect);
                g.DrawString(i.ToString(), Font, Brushes.Black, cellRect.X + 4, cellRect.Y + 4);
            }
        }

        private void DrawPlayerTokens(Graphics g, int cellSize)
        {
            foreach (var player in players)
            {
                PointF center;
                if (player == animatingPlayer)
                {
                    center = animatingPixelPosition;
                }
                else
                {
                    Point topLeft = GetCellTopLeft(player.Position, cellSize);
                    center = new PointF(topLeft.X + cellSize / 2f, topLeft.Y + cellSize / 2f);
                }

                float tokenRadius = cellSize / 4f;
                RectangleF tokenRect = new RectangleF(center.X - tokenRadius, center.Y - tokenRadius, tokenRadius * 2, tokenRadius * 2);

                using (Brush tokenBrush = new SolidBrush(player.TokenColor))
                {
                    g.FillEllipse(tokenBrush, tokenRect);
                    g.DrawEllipse(Pens.Black, tokenRect);
                }
            }
        }

        private void DrawConfettiParticles(Graphics g)
        {
            foreach (var particle in confettiParticles)
            {
                DrawRotated(g, particle.X, particle.Y, particle.Rotation, () =>
                {
                    using (Brush confettiBrush = new SolidBrush(particle.Color))
                    {
                        g.FillRectangle(confettiBrush, particle.X - 4, particle.Y - 4, 8, 8);
                    }
                });
            }
        }

        private void DrawSeaBackground(Graphics g)
        {
            Rectangle area = boardPanel.ClientRectangle;

            using (var seaBrush = new LinearGradientBrush(
                area, Color.FromArgb(120, 190, 220), Color.FromArgb(10, 60, 110), LinearGradientMode.Vertical))
            {
                g.FillRectangle(seaBrush, area);
            }

            using (var wavePen = new Pen(Color.FromArgb(60, 255, 255, 255), 2))
            {
                for (int waveY = 40; waveY < area.Height; waveY += 90)
                {
                    var points = new List<Point>();
                    for (int x = 0; x <= area.Width; x += 10)
                        points.Add(new Point(x, waveY + (int)(8 * Math.Sin(x / 20.0))));
                    if (points.Count > 1)
                        g.DrawLines(wavePen, points.ToArray());
                }
            }

            using (var bubbleBrush = new SolidBrush(Color.FromArgb(50, 255, 255, 255)))
            {
                var bubbleSeed = new Random(42);
                for (int i = 0; i < 25; i++)
                {
                    int bx = bubbleSeed.Next(area.Width);
                    int by = bubbleSeed.Next(area.Height);
                    int br = bubbleSeed.Next(3, 10);
                    g.FillEllipse(bubbleBrush, bx, by, br, br);
                }
            }
        }

        private (Color Top, Color Bottom) GetColorsForSquare(Square square)
        {
            switch (square)
            {
                case ShipSquare _: return (Color.LightSkyBlue, Color.DodgerBlue);
                case WhirlpoolSquare _: return (Color.MediumSlateBlue, Color.DarkSlateBlue);
                case PortalSquare _: return (Color.Plum, Color.MediumPurple);
                case TrapSquare _: return (Color.LightCoral, Color.IndianRed);
                case CompassSquare _: return (Color.Khaki, Color.Gold);
                case TreasureSquare _: return (Color.PaleGreen, Color.SeaGreen);
                default: return (Color.White, Color.LightSkyBlue);
            }
        }

        private void DrawGlossyCell(Graphics g, Rectangle rect, (Color Top, Color Bottom) colors)
        {
            using (var fillBrush = new LinearGradientBrush(rect, colors.Top, colors.Bottom, LinearGradientMode.Vertical))
            {
                g.FillRectangle(fillBrush, rect);
            }

            Rectangle glossRect = new Rectangle(rect.X + 2, rect.Y + 2, rect.Width - 4, rect.Height / 3);
            using (var glossBrush = new SolidBrush(Color.FromArgb(70, 255, 255, 255)))
            {
                g.FillEllipse(glossBrush, glossRect);
            }
        }

        private void btnRollDice_Click(object sender, EventArgs e)
        {
            Player currentPlayer = players[currentPlayerIndex];

            if (currentPlayer.MissNextTurn)
            {
                currentPlayer.MissNextTurn = false;
                AppendLog($"{currentPlayer.Name} מפספס/ת תור (מלכודת)");
                AdvanceTurn();
                return;
            }

            btnRollDice.Enabled = false;
            diceAnimationTicksLeft = 10;
            diceAnimationTimer.Start();
            diceSound.Play();
        }

        private void AdvanceTurn()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            UpdatePlayerCards();
            lblCurrentTurn.Text = $"תור של: {players[currentPlayerIndex].Name}";
        }

        private void FinishDiceRoll()
        {
            Player currentPlayer = players[currentPlayerIndex];

            int roll = dice.Roll();
            currentDiceFace = roll;
            diceRotationAngle = 0f;
            picDice.Invalidate();

            AppendLog($"{currentPlayer.Name} הטיל/ה {roll}");

            int cellSize = boardPanel.Width / GridSize;
            int oldPosition = currentPlayer.Position;

            board.MovePlayer(currentPlayer, roll);
            int newPosition = currentPlayer.Position;

            StartMoveAnimation(currentPlayer, oldPosition, newPosition, cellSize);
        }

        private void StartMoveAnimation(Player player, int fromIndex, int toIndex, int cellSize)
        {
            Point fromTopLeft = GetCellTopLeft(fromIndex, cellSize);
            Point toTopLeft = GetCellTopLeft(toIndex, cellSize);

            moveAnimationStart = new PointF(fromTopLeft.X + cellSize / 2f, fromTopLeft.Y + cellSize / 2f);
            moveAnimationEnd = new PointF(toTopLeft.X + cellSize / 2f, toTopLeft.Y + cellSize / 2f);

            animatingPlayer = player;
            animatingPixelPosition = moveAnimationStart;
            moveAnimationTicksLeft = MoveAnimationTotalTicks;

            boardPanel.Invalidate();
            moveAnimationTimer.Start();
        }

        private void AfterMoveAnimation()
        {
            Player currentPlayer = players[currentPlayerIndex];

            if (currentPlayer.Position >= Board.TotalSquares - 1)
            {
                AppendLog($"🏆 {currentPlayer.Name} ניצח/ה!");
                lblCurrentTurn.Text = $"{currentPlayer.Name} ניצח/ה!";
                UpdatePlayerCards();
                StartConfetti();
                winSound.Play();
                return;
            }

            if (currentPlayer.HasExtraTurn)
            {
                currentPlayer.HasExtraTurn = false;
                AppendLog($"{currentPlayer.Name} מקבל/ת תור נוסף (מצפן)");
                UpdatePlayerCards();
                btnRollDice.Enabled = true;
                return;
            }

            AdvanceTurn();
            btnRollDice.Enabled = true;
        }

        private void UpdatePlayerCards()
        {
            for (int i = 0; i < playerCards.Length; i++)
            {
                var card = playerCards[i];

                if (i < players.Count)
                {
                    card.Panel.Visible = true;
                    card.Name.Text = players[i].Name;
                    card.Coins.Text = $"מטבעות: {players[i].Coins}";
                    card.Swatch.BackColor = players[i].TokenColor;
                    card.Panel.BackColor = (i == currentPlayerIndex) ? Color.LightYellow : SystemColors.Control;
                }
                else
                {
                    card.Panel.Visible = false;
                }
            }
        }

        private void AppendLog(string message)
        {
            txtLog.AppendText(message + Environment.NewLine);
        }

        private void DrawRotated(Graphics g, float centerX, float centerY, float angleDegrees, Action draw)
        {
            g.TranslateTransform(centerX, centerY);
            g.RotateTransform(angleDegrees);
            g.TranslateTransform(-centerX, -centerY);
            draw();
            g.ResetTransform();
        }

        private static void EnableDoubleBuffering(Control control)
        {
            typeof(Control).InvokeMember(
                "DoubleBuffered",
                System.Reflection.BindingFlags.SetProperty | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic,
                null,
                control,
                new object[] { true });
        }

        private void Board_SpecialSquareTriggered(object sender, SquareTriggeredEventArgs e)
        {
            AppendLog($"↳ {e.Player.Name} נחת/ה על {e.Square.Description}");

            if (e.Square is TreasureSquare)
                achievementSound.Play();
        }

        private int GetSquareIndexAt(Point clickLocation, int cellSize)
        {
            int col = clickLocation.X / cellSize;
            int rowFromTop = clickLocation.Y / cellSize;
            int row = GridSize - 1 - rowFromTop;

            int colInRow = (row % 2 == 0) ? col : (GridSize - 1 - col);
            return row * GridSize + colInRow;
        }

        private void boardPanel_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (!editModeMenuItem.Checked) return;

            int cellSize = boardPanel.Width / GridSize;
            int index = GetSquareIndexAt(e.Location, cellSize);

            if (index < 0 || index >= board.Squares.Count) return;

            using (var editForm = new SquareEditForm(board.Squares[index]))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    board.Squares.ReplaceAt(index, editForm.ResultSquare);
                    boardPanel.Invalidate();
                }
            }
        }

        private void saveMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "קובצי שמירה (*.xml)|*.xml", FileName = "treasure_save.xml" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    GameSerializer.Save(dialog.FileName, board, players, currentPlayerIndex);
                    AppendLog("המשחק נשמר");
                }
            }
        }

        private void loadMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Filter = "קובצי שמירה (*.xml)|*.xml" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var (loadedPlayers, loadedIndex) = GameSerializer.Load(dialog.FileName, board);
                    players = loadedPlayers;
                    currentPlayerIndex = loadedIndex;

                    UpdatePlayerCards();
                    lblCurrentTurn.Text = $"תור של: {players[currentPlayerIndex].Name}";
                    boardPanel.Invalidate();
                    btnRollDice.Enabled = true;
                    AppendLog("המשחק נטען");
                }
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newGameMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void diceAnimationTimer_Tick(object sender, EventArgs e)
        {
            currentDiceFace = animationRandom.Next(1, 7);
            diceRotationAngle = animationRandom.Next(-15, 16);
            picDice.Invalidate();

            diceAnimationTicksLeft--;
            if (diceAnimationTicksLeft <= 0)
            {
                diceAnimationTimer.Stop();
                FinishDiceRoll();
            }
        }

        private void picDice_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle area = picDice.ClientRectangle;
            area.Inflate(-4, -4);

            DrawRotated(g, picDice.Width / 2f, picDice.Height / 2f, diceRotationAngle, () =>
            {
                using (var diceBrush = new SolidBrush(Color.White))
                using (var diceBorderPen = new Pen(Color.Black, 2))
                {
                    g.FillRectangle(diceBrush, area);
                    g.DrawRectangle(diceBorderPen, area);
                }

                DrawDicePips(g, area, currentDiceFace);
            });
        }

        private void DrawDicePips(Graphics g, Rectangle area, int face)
        {
            int pipSize = area.Width / 5;
            int cellW = area.Width / 3;
            int cellH = area.Height / 3;

            Point[] grid = new Point[9];
            for (int r = 0; r < 3; r++)
                for (int c = 0; c < 3; c++)
                    grid[r * 3 + c] = new Point(area.X + c * cellW + cellW / 2, area.Y + r * cellH + cellH / 2);

            int[][] layouts =
            {
                new[] { 4 },
                new[] { 0, 8 },
                new[] { 0, 4, 8 },
                new[] { 0, 2, 6, 8 },
                new[] { 0, 2, 4, 6, 8 },
                new[] { 0, 2, 3, 5, 6, 8 }
            };

            int[] pips = layouts[Math.Max(1, Math.Min(6, face)) - 1];

            using (var pipBrush = new SolidBrush(Color.Black))
            {
                foreach (int idx in pips)
                {
                    Point center = grid[idx];
                    g.FillEllipse(pipBrush, center.X - pipSize / 2, center.Y - pipSize / 2, pipSize, pipSize);
                }
            }
        }

        private void moveAnimationTimer_Tick(object sender, EventArgs e)
        {
            moveAnimationTicksLeft--;
            float t = 1f - (moveAnimationTicksLeft / (float)MoveAnimationTotalTicks);

            float x = moveAnimationStart.X + (moveAnimationEnd.X - moveAnimationStart.X) * t;
            float y = moveAnimationStart.Y + (moveAnimationEnd.Y - moveAnimationStart.Y) * t;

            float arcHeight = 40f;
            y -= arcHeight * (float)Math.Sin(t * Math.PI);

            animatingPixelPosition = new PointF(x, y);
            boardPanel.Invalidate();

            if (moveAnimationTicksLeft <= 0)
            {
                moveAnimationTimer.Stop();
                animatingPlayer = null;
                boardPanel.Invalidate();
                AfterMoveAnimation();
            }
        }

        private void StartConfetti()
        {
            confettiParticles.Clear();

            Color[] palette = { Color.Gold, Color.OrangeRed, Color.MediumPurple, Color.LimeGreen, Color.DeepSkyBlue, Color.HotPink };

            for (int i = 0; i < 80; i++)
            {
                confettiParticles.Add(new ConfettiParticle
                {
                    X = confettiRandom.Next(0, boardPanel.Width),
                    Y = confettiRandom.Next(-200, 0),
                    VelocityX = (float)(confettiRandom.NextDouble() * 2 - 1),
                    VelocityY = 2f + (float)confettiRandom.NextDouble() * 3f,
                    Rotation = confettiRandom.Next(0, 360),
                    RotationSpeed = (float)(confettiRandom.NextDouble() * 10 - 5),
                    Color = palette[confettiRandom.Next(palette.Length)]
                });
            }

            confettiTicksLeft = 120;
            confettiTimer.Start();
        }

        private void confettiTimer_Tick(object sender, EventArgs e)
        {
            foreach (var particle in confettiParticles)
            {
                particle.X += particle.VelocityX;
                particle.Y += particle.VelocityY;
                particle.Rotation += particle.RotationSpeed;
            }

            boardPanel.Invalidate();

            confettiTicksLeft--;
            if (confettiTicksLeft <= 0)
            {
                confettiTimer.Stop();
                confettiParticles.Clear();
                boardPanel.Invalidate();
            }
        }

        private class ConfettiParticle
        {
            public float X;
            public float Y;
            public float VelocityX;
            public float VelocityY;
            public float Rotation;
            public float RotationSpeed;
            public Color Color;
        }

        private void editModeMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            Text = editModeMenuItem.Checked ? "Treasure Island Race — מצב עריכה" : "Treasure Island Race";
            lblEditModeIndicator.Visible = editModeMenuItem.Checked;
        }
    }
}