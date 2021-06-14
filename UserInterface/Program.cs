using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameSettingsForm gameSettingsForm = new GameSettingsForm();
            gameSettingsForm.ShowDialog();
            GameForm gameForm = new GameForm(
                gameSettingsForm.GetGameManager,
                gameSettingsForm.Player1Name,
                gameSettingsForm.Player2Name);
            gameForm.ShowDialog();

        }
    }
}
