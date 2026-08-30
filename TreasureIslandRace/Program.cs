using System;
using System.Windows.Forms;
using TreasureIslandRace.Forms;

namespace TreasureIslandRace
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (var setupForm = new PlayerSetupForm())
            {
                if (setupForm.ShowDialog() != DialogResult.OK)
                    return;

                Application.Run(new MainForm(setupForm.Players));
            }
        }
    }
}