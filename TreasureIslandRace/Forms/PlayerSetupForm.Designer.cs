namespace TreasureIslandRace.Forms
{
    partial class PlayerSetupForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            chkPlayer1 = new CheckBox();
            txtName1 = new TextBox();
            cmbColor1 = new ComboBox();
            chkPlayer2 = new CheckBox();
            txtName2 = new TextBox();
            cmbColor2 = new ComboBox();
            chkPlayer3 = new CheckBox();
            txtName3 = new TextBox();
            cmbColor3 = new ComboBox();
            chkPlayer4 = new CheckBox();
            txtName4 = new TextBox();
            cmbColor4 = new ComboBox();
            lblError = new Label();
            btnStartGame = new Button();
            SuspendLayout();
            // 
            // chkPlayer1
            // 
            chkPlayer1.Checked = true;
            chkPlayer1.CheckState = CheckState.Checked;
            chkPlayer1.Location = new Point(20, 20);
            chkPlayer1.Name = "chkPlayer1";
            chkPlayer1.Size = new Size(110, 24);
            chkPlayer1.TabIndex = 0;
            chkPlayer1.Text = "שחקן 1";
            chkPlayer1.UseVisualStyleBackColor = true;
            // 
            // txtName1
            // 
            txtName1.Location = new Point(140, 18);
            txtName1.Name = "txtName1";
            txtName1.Size = new Size(120, 23);
            txtName1.TabIndex = 1;
            txtName1.Text = "שחקן 1";
            // 
            // cmbColor1
            // 
            cmbColor1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor1.FormattingEnabled = true;
            cmbColor1.Location = new Point(270, 18);
            cmbColor1.Name = "cmbColor1";
            cmbColor1.Size = new Size(100, 23);
            cmbColor1.TabIndex = 2;
            // 
            // chkPlayer2
            // 
            chkPlayer2.Checked = true;
            chkPlayer2.CheckState = CheckState.Checked;
            chkPlayer2.Location = new Point(20, 80);
            chkPlayer2.Name = "chkPlayer2";
            chkPlayer2.Size = new Size(110, 24);
            chkPlayer2.TabIndex = 3;
            chkPlayer2.Text = "שחקן 2";
            chkPlayer2.UseVisualStyleBackColor = true;
            // 
            // txtName2
            // 
            txtName2.Location = new Point(140, 78);
            txtName2.Name = "txtName2";
            txtName2.Size = new Size(120, 23);
            txtName2.TabIndex = 4;
            txtName2.Text = "שחקן 2";
            // 
            // cmbColor2
            // 
            cmbColor2.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor2.FormattingEnabled = true;
            cmbColor2.Location = new Point(270, 78);
            cmbColor2.Name = "cmbColor2";
            cmbColor2.Size = new Size(100, 23);
            cmbColor2.TabIndex = 5;
            // 
            // chkPlayer3
            // 
            chkPlayer3.Location = new Point(20, 140);
            chkPlayer3.Name = "chkPlayer3";
            chkPlayer3.Size = new Size(110, 24);
            chkPlayer3.TabIndex = 6;
            chkPlayer3.Text = "שחקן 3";
            chkPlayer3.UseVisualStyleBackColor = true;
            // 
            // txtName3
            // 
            txtName3.Enabled = false;
            txtName3.Location = new Point(140, 138);
            txtName3.Name = "txtName3";
            txtName3.Size = new Size(120, 23);
            txtName3.TabIndex = 7;
            txtName3.Text = "שחקן 3";
            // 
            // cmbColor3
            // 
            cmbColor3.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor3.Enabled = false;
            cmbColor3.FormattingEnabled = true;
            cmbColor3.Location = new Point(270, 138);
            cmbColor3.Name = "cmbColor3";
            cmbColor3.Size = new Size(100, 23);
            cmbColor3.TabIndex = 8;
            // 
            // chkPlayer4
            // 
            chkPlayer4.Location = new Point(20, 200);
            chkPlayer4.Name = "chkPlayer4";
            chkPlayer4.Size = new Size(110, 24);
            chkPlayer4.TabIndex = 9;
            chkPlayer4.Text = "שחקן 4";
            chkPlayer4.UseVisualStyleBackColor = true;
            // 
            // txtName4
            // 
            txtName4.Enabled = false;
            txtName4.Location = new Point(140, 198);
            txtName4.Name = "txtName4";
            txtName4.Size = new Size(120, 23);
            txtName4.TabIndex = 10;
            txtName4.Text = "שחקן 4";
            // 
            // cmbColor4
            // 
            cmbColor4.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor4.Enabled = false;
            cmbColor4.FormattingEnabled = true;
            cmbColor4.Location = new Point(270, 198);
            cmbColor4.Name = "cmbColor4";
            cmbColor4.Size = new Size(100, 23);
            cmbColor4.TabIndex = 11;
            // 
            // lblError
            // 
            lblError.ForeColor = Color.Red;
            lblError.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            lblError.Location = new Point(20, 265);
            lblError.Name = "lblError";
            lblError.Size = new Size(380, 20);
            lblError.TabIndex = 12;
            lblError.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnStartGame
            // 
            btnStartGame.Location = new Point(150, 300);
            btnStartGame.Name = "btnStartGame";
            btnStartGame.Size = new Size(120, 32);
            btnStartGame.TabIndex = 13;
            btnStartGame.Text = "התחל משחק";
            btnStartGame.UseVisualStyleBackColor = true;
            btnStartGame.Click += btnStartGame_Click;
            // 
            // PlayerSetupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 350);
            Controls.Add(btnStartGame);
            Controls.Add(lblError);
            Controls.Add(cmbColor4);
            Controls.Add(txtName4);
            Controls.Add(chkPlayer4);
            Controls.Add(cmbColor3);
            Controls.Add(txtName3);
            Controls.Add(chkPlayer3);
            Controls.Add(cmbColor2);
            Controls.Add(txtName2);
            Controls.Add(chkPlayer2);
            Controls.Add(cmbColor1);
            Controls.Add(txtName1);
            Controls.Add(chkPlayer1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PlayerSetupForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "הגדרת שחקנים";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkPlayer1;
        private TextBox txtName1;
        private ComboBox cmbColor1;
        private CheckBox chkPlayer2;
        private TextBox txtName2;
        private ComboBox cmbColor2;
        private CheckBox chkPlayer3;
        private TextBox txtName3;
        private ComboBox cmbColor3;
        private CheckBox chkPlayer4;
        private TextBox txtName4;
        private ComboBox cmbColor4;
        private Label lblError;
        private Button btnStartGame;
    }
}