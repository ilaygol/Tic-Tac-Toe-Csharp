using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserInterface
{
    public partial class GameSettingsForm : Form
    {
        public GameSettingsForm()
        {
            InitializeComponent();
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
            if(Player2CheckBox.Checked == false)
            {
                Player2TextBox.Text = @"[Computer]";
            }
        }
    }
}
