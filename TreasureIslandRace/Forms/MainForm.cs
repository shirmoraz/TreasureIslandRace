using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TreasureIslandRace.Models;
using TreasureIslandRace.Game;
using TreasureIslandRace.Persistence;
using System.Drawing.Drawing2D;

namespace TreasureIslandRace.Forms
{
    public partial class MainForm : Form
    {
        private const int GridSize = 6;

        private readonly Board board = new Board();
        private readonly Dice dice = new Dice();
        private List<Player> players = new List<Player>();
        private int currentPlayerIndex = 0;

        private Panel[] playerPanels;
        private Panel[] colorSwatches;
        private Label[] nameLabels;
        private Label[] coinLabels;

        public MainForm(List<Player> selectedPlayers)
        {
            InitializeComponent();

            playerPanels = new[] { playerPanel1, playerPanel2, playerPanel3, playerPanel4 };
            colorSwatches = new[] { colorSwatch1, colorSwatch2, colorSwatch3, colorSwatch4 };
            nameLabels = new[] { lblName1, lblName2, lblName3, lblName4 };
            coinLabels = new[] { lblCoins1, lblCoins2, lblCoins3, lblCoins4 };

            players = selectedPlayers;
            board.SpecialSquareTriggered += Board_SpecialSquareTriggered;

            SetupBoardSquares();
            UpdatePlayerCards();
            lblCurrentTurn.Text = $"תור של: {players[currentPlayerIndex].Name}";
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

            DrawSeaBackground(g);

            int cellSize = boardPanel.Width / GridSize;

            for (int i = 0; i < board.Squares.Count; i++)
            {
                Point topLeft = GetCellTopLeft(i, cellSize);
                Rectangle cellRect = new Rectangle(topLeft.X, topLeft.Y, cellSize, cellSize);

                DrawGlossyCell(g, cellRect, GetColorsForSquare(board.Squares[i]));
                g.DrawRectangle(Pens.White, cellRect);
                g.DrawString(i.ToString(), Font, Brushes.White, cellRect.X + 4, cellRect.Y + 4);
            }

            foreach (var player in players)
            {
                Point topLeft = GetCellTopLeft(player.Position, cellSize);
                Rectangle tokenRect = new Rectangle(
                    topLeft.X + cellSize / 4, topLeft.Y + cellSize / 4, cellSize / 2, cellSize / 2);

                using (Brush tokenBrush = new SolidBrush(player.TokenColor))
                {
                    g.FillEllipse(tokenBrush, tokenRect);
                    g.DrawEllipse(Pens.Black, tokenRect);
                }
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

            int roll = dice.Roll();
            AppendLog($"{currentPlayer.Name} הטיל/ה {roll}");

            board.MovePlayer(currentPlayer, roll);
            boardPanel.Invalidate();

            if (currentPlayer.Position >= Board.TotalSquares - 1)
            {
                AppendLog($"🏆 {currentPlayer.Name} ניצח/ה!");
                lblCurrentTurn.Text = $"{currentPlayer.Name} ניצח/ה!";
                btnRollDice.Enabled = false;
                UpdatePlayerCards();
                return;
            }

            if (currentPlayer.HasExtraTurn)
            {
                currentPlayer.HasExtraTurn = false;
                AppendLog($"{currentPlayer.Name} מקבל/ת תור נוסף (מצפן)");
                UpdatePlayerCards();
                return;
            }

            AdvanceTurn();
        }

        private void AdvanceTurn()
        {
            currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
            UpdatePlayerCards();
            lblCurrentTurn.Text = $"תור של: {players[currentPlayerIndex].Name}";
        }

        private void UpdatePlayerCards()
        {
            for (int i = 0; i < playerPanels.Length; i++)
            {
                if (i < players.Count)
                {
                    playerPanels[i].Visible = true;
                    nameLabels[i].Text = players[i].Name;
                    coinLabels[i].Text = $"מטבעות: {players[i].Coins}";
                    colorSwatches[i].BackColor = players[i].TokenColor;
                    playerPanels[i].BackColor = (i == currentPlayerIndex) ? Color.LightYellow : SystemColors.Control;
                }
                else
                {
                    playerPanels[i].Visible = false;
                }
            }
        }

        private void AppendLog(string message)
        {
            txtLog.AppendText(message + Environment.NewLine);
        }

        private void Board_SpecialSquareTriggered(object sender, SquareTriggeredEventArgs e)
        {
            AppendLog($"↳ {e.Player.Name} נחת/ה על {e.Square.Description}");
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
    }
}