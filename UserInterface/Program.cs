using System;
using System.Windows.Forms;

namespace UserInterface
{
    public class Program
    {
        [STAThread]
        static void Main()
        {
            StartProgram();
        }

        public static void StartProgram()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GameSettingsForm gameSettingsForm = new GameSettingsForm();
            if (gameSettingsForm.ShowDialog() == DialogResult.OK)
            {
                GameForm gameForm = new GameForm(gameSettingsForm.GetGameManager);
                gameForm.ShowDialog();
            }
        }
    }
}
