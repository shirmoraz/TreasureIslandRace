namespace TreasureIslandRace.Forms
{
    partial class SquareEditForm
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
            lblSquareIndex = new Label();
            label1 = new Label();
            cmbSquareType = new ComboBox();
            label2 = new Label();
            numParam = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();
            ((System.ComponentModel.ISupportInitialize)numParam).BeginInit();
            SuspendLayout();
            // 
            // lblSquareIndex
            // 
            lblSquareIndex.Location = new Point(20, 20);
            lblSquareIndex.Name = "lblSquareIndex";
            lblSquareIndex.Size = new Size(260, 20);
            lblSquareIndex.TabIndex = 0;
            lblSquareIndex.Text = "משבצת מספר: -";
            // 
            // label1
            // 
            label1.Location = new Point(20, 55);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 1;
            label1.Text = "סוג:";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // cmbSquareType
            // 
            cmbSquareType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSquareType.FormattingEnabled = true;
            cmbSquareType.Location = new Point(90, 52);
            cmbSquareType.Name = "cmbSquareType";
            cmbSquareType.Size = new Size(180, 23);
            cmbSquareType.TabIndex = 2;
            // 
            // label2
            // 
            label2.Location = new Point(20, 90);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.No;
            label2.Size = new Size(60, 20);
            label2.TabIndex = 3;
            label2.Text = "פרמטר:";
            // 
            // numParam
            // 
            numParam.Location = new Point(90, 87);
            numParam.Maximum = new decimal(new int[] { 35, 0, 0, 0 });
            numParam.Name = "numParam";
            numParam.Size = new Size(80, 23);
            numParam.TabIndex = 4;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(40, 140);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(90, 30);
            btnSave.TabIndex = 5;
            btnSave.Text = "שמור";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(170, 140);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 30);
            btnCancel.TabIndex = 6;
            btnCancel.Text = "ביטול";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // SquareEditForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(284, 181);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(numParam);
            Controls.Add(label2);
            Controls.Add(cmbSquareType);
            Controls.Add(label1);
            Controls.Add(lblSquareIndex);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SquareEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "עריכת משבצת";
            ((System.ComponentModel.ISupportInitialize)numParam).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblSquareIndex;
        private Label label1;
        private ComboBox cmbSquareType;
        private Label label2;
        private NumericUpDown numParam;
        private Button btnSave;
        private Button btnCancel;
    }
}