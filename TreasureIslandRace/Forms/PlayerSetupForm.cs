using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TreasureIslandRace.Models;

namespace TreasureIslandRace.Forms
{
    public partial class PlayerSetupForm : Form
    {
        private static readonly (string Name, Color Value)[] AvailableColors = new[]
        {
            ("אדום", Color.Red),
            ("כחול", Color.Blue),
            ("ירוק", Color.SeaGreen),
            ("סגול", Color.Purple),
        };

        public List<Player> Players { get; private set; }

        private CheckBox[] checkBoxes;
        private TextBox[] nameBoxes;
        private ComboBox[] colorBoxes;

        public PlayerSetupForm()
        {
            InitializeComponent();

            checkBoxes = new[] { chkPlayer1, chkPlayer2, chkPlayer3, chkPlayer4 };
            nameBoxes = new[] { txtName1, txtName2, txtName3, txtName4 };
            colorBoxes = new[] { cmbColor1, cmbColor2, cmbColor3, cmbColor4 };

            for (int i = 0; i < colorBoxes.Length; i++)
            {
                foreach (var color in AvailableColors)
                    colorBoxes[i].Items.Add(color.Name);
                colorBoxes[i].SelectedIndex = i % AvailableColors.Length;

                int idx = i;
                checkBoxes[i].CheckedChanged += (s, e) =>
                {
                    nameBoxes[idx].Enabled = checkBoxes[idx].Checked;
                    colorBoxes[idx].Enabled = checkBoxes[idx].Checked;
                };
            }
        }

        private void btnStartGame_Click(object sender, EventArgs e)
        {
            var selected = new List<Player>();

            for (int i = 0; i < checkBoxes.Length; i++)
            {
                if (!checkBoxes[i].Checked) continue;

                string name = nameBoxes[i].Text.Trim();
                if (string.IsNullOrEmpty(name))
                {
                    lblError.Text = $"חסר שם לשחקן {i + 1}";
                    return;
                }

                Color color = AvailableColors[colorBoxes[i].SelectedIndex].Value;
                selected.Add(new Player(name, color));
            }

            if (selected.Count < 2)
            {
                lblError.Text = "צריך לפחות 2 שחקנים";
                return;
            }

            Players = selected;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}