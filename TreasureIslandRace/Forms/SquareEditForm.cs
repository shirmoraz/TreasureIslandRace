using System;
using System.Windows.Forms;
using TreasureIslandRace.Models;

namespace TreasureIslandRace.Forms
{
    public partial class SquareEditForm : Form
    {
        public Square ResultSquare { get; private set; }

        private readonly int squareIndex;

        public SquareEditForm(Square currentSquare)
        {
            InitializeComponent();

            cmbSquareType.Items.AddRange(new object[]
            {
                "רגילה", "ספינה", "מערבולת", "פורטל", "מלכודת", "מצפן", "אוצר"
            });

            squareIndex = currentSquare.Index;
            lblSquareIndex.Text = $"משבצת מספר: {squareIndex}";

            switch (currentSquare)
            {
                case ShipSquare ship:
                    cmbSquareType.SelectedIndex = 1;
                    numParam.Value = ship.Steps;
                    break;
                case WhirlpoolSquare whirlpool:
                    cmbSquareType.SelectedIndex = 2;
                    numParam.Value = whirlpool.Steps;
                    break;
                case PortalSquare portal:
                    cmbSquareType.SelectedIndex = 3;
                    numParam.Value = portal.TargetIndex;
                    break;
                case TrapSquare _:
                    cmbSquareType.SelectedIndex = 4;
                    break;
                case CompassSquare _:
                    cmbSquareType.SelectedIndex = 5;
                    break;
                case TreasureSquare treasure:
                    cmbSquareType.SelectedIndex = 6;
                    numParam.Value = treasure.CoinAmount;
                    break;
                default:
                    cmbSquareType.SelectedIndex = 0;
                    break;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int param = (int)numParam.Value;

            switch (cmbSquareType.SelectedIndex)
            {
                case 1: ResultSquare = new ShipSquare(squareIndex, param); break;
                case 2: ResultSquare = new WhirlpoolSquare(squareIndex, param); break;
                case 3: ResultSquare = new PortalSquare(squareIndex, param); break;
                case 4: ResultSquare = new TrapSquare(squareIndex); break;
                case 5: ResultSquare = new CompassSquare(squareIndex); break;
                case 6: ResultSquare = new TreasureSquare(squareIndex, param); break;
                default: ResultSquare = new NormalSquare(squareIndex); break;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}