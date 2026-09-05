namespace TreasureIslandRace.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            קובץToolStripMenuItem = new ToolStripMenuItem();
            newGameMenuItem = new ToolStripMenuItem();
            saveMenuItem = new ToolStripMenuItem();
            loadMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitMenuItem = new ToolStripMenuItem();
            לוחToolStripMenuItem = new ToolStripMenuItem();
            editModeMenuItem = new ToolStripMenuItem();
            autoModeMenuItem = new ToolStripMenuItem();
            boardPanel = new Panel();
            playersPanel = new Panel();
            playerPanel4 = new Panel();
            btnRemovePlayer4 = new Button();
            lblCoins4 = new Label();
            lblName4 = new Label();
            colorSwatch4 = new Panel();
            playerPanel3 = new Panel();
            btnRemovePlayer3 = new Button();
            lblCoins3 = new Label();
            lblName3 = new Label();
            colorSwatch3 = new Panel();
            playerPanel2 = new Panel();
            btnRemovePlayer2 = new Button();
            lblCoins2 = new Label();
            lblName2 = new Label();
            colorSwatch2 = new Panel();
            playerPanel1 = new Panel();
            btnRemovePlayer1 = new Button();
            lblCoins1 = new Label();
            lblName1 = new Label();
            colorSwatch1 = new Panel();
            picDice = new PictureBox();
            btnRollDice = new Button();
            lblCurrentTurn = new Label();
            txtLog = new TextBox();
            notifyIcon1 = new NotifyIcon(components);
            diceAnimationTimer = new System.Windows.Forms.Timer(components);
            moveAnimationTimer = new System.Windows.Forms.Timer(components);
            confettiTimer = new System.Windows.Forms.Timer(components);
            lblEditModeIndicator = new Label();
            btnEditHelp = new Button();
            autoPlayTimer = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            playersPanel.SuspendLayout();
            playerPanel4.SuspendLayout();
            playerPanel3.SuspendLayout();
            playerPanel2.SuspendLayout();
            playerPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picDice).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { קובץToolStripMenuItem, לוחToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(9, 3, 0, 3);
            menuStrip1.Size = new Size(1427, 35);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // קובץToolStripMenuItem
            // 
            קובץToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newGameMenuItem, saveMenuItem, loadMenuItem, toolStripSeparator1, exitMenuItem });
            קובץToolStripMenuItem.Name = "קובץToolStripMenuItem";
            קובץToolStripMenuItem.Size = new Size(65, 29);
            קובץToolStripMenuItem.Text = "קובץ";
            // 
            // newGameMenuItem
            // 
            newGameMenuItem.Name = "newGameMenuItem";
            newGameMenuItem.Size = new Size(204, 34);
            newGameMenuItem.Text = "משחק חדש";
            newGameMenuItem.Click += newGameMenuItem_Click;
            // 
            // saveMenuItem
            // 
            saveMenuItem.Name = "saveMenuItem";
            saveMenuItem.Size = new Size(204, 34);
            saveMenuItem.Text = "שמור";
            saveMenuItem.Click += saveMenuItem_Click;
            // 
            // loadMenuItem
            // 
            loadMenuItem.Name = "loadMenuItem";
            loadMenuItem.Size = new Size(204, 34);
            loadMenuItem.Text = "טען";
            loadMenuItem.Click += loadMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(201, 6);
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(204, 34);
            exitMenuItem.Text = "יציאה";
            exitMenuItem.Click += exitMenuItem_Click;
            // 
            // לוחToolStripMenuItem
            // 
            לוחToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editModeMenuItem, autoModeMenuItem });
            לוחToolStripMenuItem.Name = "לוחToolStripMenuItem";
            לוחToolStripMenuItem.Size = new Size(55, 29);
            לוחToolStripMenuItem.Text = "לוח";
            // 
            // editModeMenuItem
            // 
            editModeMenuItem.CheckOnClick = true;
            editModeMenuItem.Name = "editModeMenuItem";
            editModeMenuItem.Size = new Size(214, 34);
            editModeMenuItem.Text = "מצב עריכה";
            editModeMenuItem.CheckedChanged += editModeMenuItem_CheckedChanged;
            // 
            // autoModeMenuItem
            // 
            autoModeMenuItem.CheckOnClick = true;
            autoModeMenuItem.Name = "autoModeMenuItem";
            autoModeMenuItem.Size = new Size(214, 34);
            autoModeMenuItem.Text = "מצב אוטומטי";
            autoModeMenuItem.CheckedChanged += autoModeMenuItem_CheckedChanged;
            // 
            // boardPanel
            // 
            boardPanel.BackColor = Color.FromArgb(26, 100, 156);
            boardPanel.BorderStyle = BorderStyle.FixedSingle;
            boardPanel.Location = new Point(17, 60);
            boardPanel.Margin = new Padding(4, 5, 4, 5);
            boardPanel.Name = "boardPanel";
            boardPanel.Size = new Size(885, 1032);
            boardPanel.TabIndex = 1;
            boardPanel.Paint += boardPanel_Paint;
            boardPanel.MouseClick += boardPanel_MouseClick_1;
            // 
            // playersPanel
            // 
            playersPanel.BorderStyle = BorderStyle.FixedSingle;
            playersPanel.Controls.Add(playerPanel4);
            playersPanel.Controls.Add(playerPanel3);
            playersPanel.Controls.Add(playerPanel2);
            playersPanel.Controls.Add(playerPanel1);
            playersPanel.Location = new Point(920, 60);
            playersPanel.Margin = new Padding(4, 5, 4, 5);
            playersPanel.Name = "playersPanel";
            playersPanel.Size = new Size(491, 432);
            playersPanel.TabIndex = 2;
            // 
            // playerPanel4
            // 
            playerPanel4.Controls.Add(btnRemovePlayer4);
            playerPanel4.Controls.Add(lblCoins4);
            playerPanel4.Controls.Add(lblName4);
            playerPanel4.Controls.Add(colorSwatch4);
            playerPanel4.Location = new Point(7, 308);
            playerPanel4.Margin = new Padding(4, 5, 4, 5);
            playerPanel4.Name = "playerPanel4";
            playerPanel4.Size = new Size(457, 92);
            playerPanel4.TabIndex = 3;
            // 
            // btnRemovePlayer4
            // 
            btnRemovePlayer4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemovePlayer4.Location = new Point(421, 5);
            btnRemovePlayer4.Margin = new Padding(4, 5, 4, 5);
            btnRemovePlayer4.Name = "btnRemovePlayer4";
            btnRemovePlayer4.Size = new Size(31, 37);
            btnRemovePlayer4.TabIndex = 6;
            btnRemovePlayer4.Text = "✕";
            btnRemovePlayer4.UseVisualStyleBackColor = true;
            btnRemovePlayer4.Click += btnRemovePlayer4_Click;
            // 
            // lblCoins4
            // 
            lblCoins4.AutoSize = true;
            lblCoins4.Location = new Point(51, 47);
            lblCoins4.Margin = new Padding(4, 0, 4, 0);
            lblCoins4.Name = "lblCoins4";
            lblCoins4.Size = new Size(59, 25);
            lblCoins4.TabIndex = 2;
            lblCoins4.Text = "label1";
            // 
            // lblName4
            // 
            lblName4.AutoSize = true;
            lblName4.Location = new Point(51, 10);
            lblName4.Margin = new Padding(4, 0, 4, 0);
            lblName4.Name = "lblName4";
            lblName4.Size = new Size(59, 25);
            lblName4.TabIndex = 1;
            lblName4.Text = "label3";
            // 
            // colorSwatch4
            // 
            colorSwatch4.Location = new Point(11, 13);
            colorSwatch4.Margin = new Padding(4, 5, 4, 5);
            colorSwatch4.Name = "colorSwatch4";
            colorSwatch4.Size = new Size(29, 33);
            colorSwatch4.TabIndex = 0;
            // 
            // playerPanel3
            // 
            playerPanel3.Controls.Add(btnRemovePlayer3);
            playerPanel3.Controls.Add(lblCoins3);
            playerPanel3.Controls.Add(lblName3);
            playerPanel3.Controls.Add(colorSwatch3);
            playerPanel3.Location = new Point(7, 208);
            playerPanel3.Margin = new Padding(4, 5, 4, 5);
            playerPanel3.Name = "playerPanel3";
            playerPanel3.Size = new Size(457, 92);
            playerPanel3.TabIndex = 2;
            // 
            // btnRemovePlayer3
            // 
            btnRemovePlayer3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemovePlayer3.Location = new Point(421, 5);
            btnRemovePlayer3.Margin = new Padding(4, 5, 4, 5);
            btnRemovePlayer3.Name = "btnRemovePlayer3";
            btnRemovePlayer3.Size = new Size(31, 37);
            btnRemovePlayer3.TabIndex = 5;
            btnRemovePlayer3.Text = "✕";
            btnRemovePlayer3.UseVisualStyleBackColor = true;
            btnRemovePlayer3.Click += btnRemovePlayer3_Click;
            // 
            // lblCoins3
            // 
            lblCoins3.AutoSize = true;
            lblCoins3.Location = new Point(51, 47);
            lblCoins3.Margin = new Padding(4, 0, 4, 0);
            lblCoins3.Name = "lblCoins3";
            lblCoins3.Size = new Size(59, 25);
            lblCoins3.TabIndex = 2;
            lblCoins3.Text = "label1";
            // 
            // lblName3
            // 
            lblName3.AutoSize = true;
            lblName3.Location = new Point(51, 10);
            lblName3.Margin = new Padding(4, 0, 4, 0);
            lblName3.Name = "lblName3";
            lblName3.Size = new Size(59, 25);
            lblName3.TabIndex = 1;
            lblName3.Text = "label2";
            // 
            // colorSwatch3
            // 
            colorSwatch3.Location = new Point(11, 13);
            colorSwatch3.Margin = new Padding(4, 5, 4, 5);
            colorSwatch3.Name = "colorSwatch3";
            colorSwatch3.Size = new Size(29, 33);
            colorSwatch3.TabIndex = 0;
            // 
            // playerPanel2
            // 
            playerPanel2.Controls.Add(btnRemovePlayer2);
            playerPanel2.Controls.Add(lblCoins2);
            playerPanel2.Controls.Add(lblName2);
            playerPanel2.Controls.Add(colorSwatch2);
            playerPanel2.Location = new Point(7, 108);
            playerPanel2.Margin = new Padding(4, 5, 4, 5);
            playerPanel2.Name = "playerPanel2";
            playerPanel2.Size = new Size(457, 92);
            playerPanel2.TabIndex = 1;
            // 
            // btnRemovePlayer2
            // 
            btnRemovePlayer2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemovePlayer2.Location = new Point(421, 5);
            btnRemovePlayer2.Margin = new Padding(4, 5, 4, 5);
            btnRemovePlayer2.Name = "btnRemovePlayer2";
            btnRemovePlayer2.Size = new Size(31, 37);
            btnRemovePlayer2.TabIndex = 4;
            btnRemovePlayer2.Text = "✕";
            btnRemovePlayer2.UseVisualStyleBackColor = true;
            btnRemovePlayer2.Click += btnRemovePlayer2_Click;
            // 
            // lblCoins2
            // 
            lblCoins2.AutoSize = true;
            lblCoins2.Location = new Point(51, 47);
            lblCoins2.Margin = new Padding(4, 0, 4, 0);
            lblCoins2.Name = "lblCoins2";
            lblCoins2.Size = new Size(59, 25);
            lblCoins2.TabIndex = 2;
            lblCoins2.Text = "label1";
            // 
            // lblName2
            // 
            lblName2.AutoSize = true;
            lblName2.Location = new Point(51, 10);
            lblName2.Margin = new Padding(4, 0, 4, 0);
            lblName2.Name = "lblName2";
            lblName2.Size = new Size(59, 25);
            lblName2.TabIndex = 1;
            lblName2.Text = "label1";
            // 
            // colorSwatch2
            // 
            colorSwatch2.Location = new Point(11, 13);
            colorSwatch2.Margin = new Padding(4, 5, 4, 5);
            colorSwatch2.Name = "colorSwatch2";
            colorSwatch2.Size = new Size(29, 33);
            colorSwatch2.TabIndex = 0;
            // 
            // playerPanel1
            // 
            playerPanel1.Controls.Add(btnRemovePlayer1);
            playerPanel1.Controls.Add(lblCoins1);
            playerPanel1.Controls.Add(lblName1);
            playerPanel1.Controls.Add(colorSwatch1);
            playerPanel1.Location = new Point(7, 8);
            playerPanel1.Margin = new Padding(4, 5, 4, 5);
            playerPanel1.Name = "playerPanel1";
            playerPanel1.Size = new Size(457, 92);
            playerPanel1.TabIndex = 0;
            // 
            // btnRemovePlayer1
            // 
            btnRemovePlayer1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRemovePlayer1.Location = new Point(421, 5);
            btnRemovePlayer1.Margin = new Padding(4, 5, 4, 5);
            btnRemovePlayer1.Name = "btnRemovePlayer1";
            btnRemovePlayer1.Size = new Size(31, 37);
            btnRemovePlayer1.TabIndex = 3;
            btnRemovePlayer1.Text = "✕";
            btnRemovePlayer1.UseVisualStyleBackColor = true;
            btnRemovePlayer1.Click += btnRemovePlayer1_Click;
            // 
            // lblCoins1
            // 
            lblCoins1.AutoSize = true;
            lblCoins1.Location = new Point(51, 47);
            lblCoins1.Margin = new Padding(4, 0, 4, 0);
            lblCoins1.Name = "lblCoins1";
            lblCoins1.Size = new Size(59, 25);
            lblCoins1.TabIndex = 2;
            lblCoins1.Text = "label1";
            // 
            // lblName1
            // 
            lblName1.AutoSize = true;
            lblName1.Location = new Point(51, 10);
            lblName1.Margin = new Padding(4, 0, 4, 0);
            lblName1.Name = "lblName1";
            lblName1.Size = new Size(59, 25);
            lblName1.TabIndex = 1;
            lblName1.Text = "label1";
            // 
            // colorSwatch1
            // 
            colorSwatch1.Location = new Point(11, 13);
            colorSwatch1.Margin = new Padding(4, 5, 4, 5);
            colorSwatch1.Name = "colorSwatch1";
            colorSwatch1.Size = new Size(29, 33);
            colorSwatch1.TabIndex = 0;
            // 
            // picDice
            // 
            picDice.BorderStyle = BorderStyle.FixedSingle;
            picDice.Location = new Point(949, 510);
            picDice.Margin = new Padding(4, 5, 4, 5);
            picDice.Name = "picDice";
            picDice.Size = new Size(113, 132);
            picDice.TabIndex = 3;
            picDice.TabStop = false;
            picDice.Paint += picDice_Paint;
            // 
            // btnRollDice
            // 
            btnRollDice.Location = new Point(920, 677);
            btnRollDice.Margin = new Padding(4, 5, 4, 5);
            btnRollDice.Name = "btnRollDice";
            btnRollDice.Size = new Size(200, 67);
            btnRollDice.TabIndex = 4;
            btnRollDice.Text = "הטל קובייה 🎲";
            btnRollDice.UseVisualStyleBackColor = true;
            btnRollDice.Click += btnRollDice_Click;
            // 
            // lblCurrentTurn
            // 
            lblCurrentTurn.AutoSize = true;
            lblCurrentTurn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCurrentTurn.Location = new Point(1143, 693);
            lblCurrentTurn.Margin = new Padding(4, 0, 4, 0);
            lblCurrentTurn.Name = "lblCurrentTurn";
            lblCurrentTurn.Size = new Size(63, 25);
            lblCurrentTurn.TabIndex = 5;
            lblCurrentTurn.Text = "label1";
            // 
            // txtLog
            // 
            txtLog.Location = new Point(920, 760);
            txtLog.Margin = new Padding(4, 5, 4, 5);
            txtLog.Multiline = true;
            txtLog.Name = "txtLog";
            txtLog.ReadOnly = true;
            txtLog.ScrollBars = ScrollBars.Vertical;
            txtLog.Size = new Size(490, 331);
            txtLog.TabIndex = 6;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            // 
            // diceAnimationTimer
            // 
            diceAnimationTimer.Interval = 60;
            diceAnimationTimer.Tick += diceAnimationTimer_Tick;
            // 
            // moveAnimationTimer
            // 
            moveAnimationTimer.Interval = 25;
            moveAnimationTimer.Tick += moveAnimationTimer_Tick;
            // 
            // confettiTimer
            // 
            confettiTimer.Interval = 30;
            confettiTimer.Tick += confettiTimer_Tick;
            // 
            // lblEditModeIndicator
            // 
            lblEditModeIndicator.BackColor = Color.FromArgb(255, 255, 192);
            lblEditModeIndicator.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEditModeIndicator.ForeColor = Color.FromArgb(31, 41, 55);
            lblEditModeIndicator.Location = new Point(174, 5);
            lblEditModeIndicator.Margin = new Padding(4, 0, 4, 0);
            lblEditModeIndicator.Name = "lblEditModeIndicator";
            lblEditModeIndicator.Size = new Size(729, 50);
            lblEditModeIndicator.TabIndex = 7;
            lblEditModeIndicator.Text = "מצב עריכה פעיל";
            lblEditModeIndicator.TextAlign = ContentAlignment.MiddleCenter;
            lblEditModeIndicator.Visible = false;
            // 
            // btnEditHelp
            // 
            btnEditHelp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEditHelp.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnEditHelp.Location = new Point(141, 20);
            btnEditHelp.Margin = new Padding(4, 5, 4, 5);
            btnEditHelp.Name = "btnEditHelp";
            btnEditHelp.Size = new Size(31, 37);
            btnEditHelp.TabIndex = 8;
            btnEditHelp.Text = "?";
            btnEditHelp.UseVisualStyleBackColor = true;
            btnEditHelp.Visible = false;
            btnEditHelp.Click += btnHelp_Click;
            // 
            // autoPlayTimer
            // 
            autoPlayTimer.Interval = 1200;
            autoPlayTimer.Tick += autoPlayTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1427, 1102);
            Controls.Add(btnEditHelp);
            Controls.Add(lblEditModeIndicator);
            Controls.Add(txtLog);
            Controls.Add(lblCurrentTurn);
            Controls.Add(btnRollDice);
            Controls.Add(picDice);
            Controls.Add(playersPanel);
            Controls.Add(boardPanel);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4, 5, 4, 5);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Treasure Island Race";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            playersPanel.ResumeLayout(false);
            playerPanel4.ResumeLayout(false);
            playerPanel4.PerformLayout();
            playerPanel3.ResumeLayout(false);
            playerPanel3.PerformLayout();
            playerPanel2.ResumeLayout(false);
            playerPanel2.PerformLayout();
            playerPanel1.ResumeLayout(false);
            playerPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picDice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem קובץToolStripMenuItem;
        private ToolStripMenuItem newGameMenuItem;
        private ToolStripMenuItem saveMenuItem;
        private ToolStripMenuItem loadMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem לוחToolStripMenuItem;
        private ToolStripMenuItem editModeMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private Panel boardPanel;
        private Panel playersPanel;
        private Panel playerPanel4;
        private Panel playerPanel3;
        private Panel playerPanel2;
        private Panel playerPanel1;
        private Panel colorSwatch4;
        private Panel colorSwatch3;
        private Panel colorSwatch2;
        private Label lblName1;
        private Panel colorSwatch1;
        private Label lblCoins4;
        private Label lblName4;
        private Label lblCoins3;
        private Label lblName3;
        private Label lblCoins2;
        private Label lblName2;
        private Label lblCoins1;
        private PictureBox picDice;
        private Button btnRollDice;
        private Label lblCurrentTurn;
        private TextBox txtLog;
        private NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer diceAnimationTimer;
        private System.Windows.Forms.Timer moveAnimationTimer;
        private System.Windows.Forms.Timer confettiTimer;
        private Label lblEditModeIndicator;
        private Button btnEditHelp;
        private Button btnRemovePlayer3;
        private Button btnRemovePlayer2;
        private Button btnRemovePlayer1;
        private Button btnRemovePlayer4;
        private ToolStripMenuItem autoModeMenuItem;
        private System.Windows.Forms.Timer autoPlayTimer;
    }
}
