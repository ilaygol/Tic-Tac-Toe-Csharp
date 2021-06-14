using System;
using System.Drawing;
using System.Windows.Forms;
using GameLogic;

namespace UserInterface
{
    public partial class GameForm : Form
    {
        private static GameManager s_GameManager;
        private readonly CellButton[,] r_CellButtons;

        public GameForm(GameManager i_GameManager, string i_Player1Name, string i_Player2Name)
        {
            s_GameManager = i_GameManager;
            r_CellButtons = new CellButton[s_GameManager.RowSize, s_GameManager.ColSize];
            initializeButtons();
            InitializeComponent();

            this.Height = r_CellButtons[s_GameManager.RowSize - 1, 0].Bottom + 80;
            //Player1Label.Top = r_CellButtons[s_GameManager.RowSize - 1, 0].Bottom + 30;
            Player1Label.Text = i_Player1Name;
            //Player1ScoreLabel.Top = Player1Label.Top;
            Player1ScoreLabel.Left = Player1Label.Right + 5;

            //Player2Label.Top = Player1Label.Top;
            Player2Label.Left = Player1ScoreLabel.Right + 20;
            Player2Label.Text = i_Player2Name;
            //Player2ScoreLabel.Top = Player1Label.Top;
            Player2ScoreLabel.Left = Player2Label.Right + 5;
        }

        private void initializeButtons()
        {
            int xPosition = 10;
            int yPosition = 10;
            CellButton currentButton = null;
            for(int i = 0; i < s_GameManager.RowSize; i++)
            {
                for(int j = 0; j < s_GameManager.ColSize; j++)
                {
                    currentButton = new CellButton(s_GameManager.GetBoardCell(new Position(i, j)));
                    currentButton.Location = new Point(xPosition, yPosition);
                    xPosition += currentButton.Width + 10;
                    r_CellButtons[i, j] = currentButton;
                    this.Controls.Add(currentButton);
                }
                xPosition = 10;
                yPosition += 60;
            }
        }
    }
}
