using System;
using System.Windows.Forms;
using GameLogic;

namespace UserInterface
{
    public partial class GameSettingsForm : Form
    {
        private static GameManager s_GameManager;
        
        public GameSettingsForm()
        {
            InitializeComponent();
        }

        public GameManager GetGameManager
        {
            get
            {
                return s_GameManager;
            }
        }

        public string Player1Name
        {
            get
            {
                string player1Name = "Player 1";
                if(Player1TextBox.Text != "")
                {
                    player1Name = Player1TextBox.Text;
                }
                return player1Name;
            }
        }

        public string Player2Name
        {
            get
            {
                string player2Name = "Computer";
                if(Player2CheckBox.Checked)
                {
                    if(Player2TextBox.Text != "")
                    {
                        player2Name = Player2TextBox.Text;
                    }
                    else
                    {
                        player2Name = "Player 2";
                    }
                }
                return player2Name;
            }
        }

        private void numericUpDownRows_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownCols.Value = numericUpDownRows.Value;
        }

        private void numericUpDownCols_ValueChanged(object sender, EventArgs e)
        {
            numericUpDownRows.Value = numericUpDownCols.Value;
        }

        private void Player2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Player2TextBox.Enabled = Player2CheckBox.Checked;
            if(Player2CheckBox.Checked)
            {
                Player2TextBox.Text = "";
            }
            else
            {
                Player2TextBox.Text = @"[Computer]";
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            s_GameManager = new GameManager(
                (int)numericUpDownRows.Value,
                (int)numericUpDownCols.Value,
                !Player2CheckBox.Checked,
                Player1Name,
                Player2Name);
            this.Close();
        }
    }
}
