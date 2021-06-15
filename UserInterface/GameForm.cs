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

        public GameForm(GameManager i_GameManager)
        {
            s_GameManager = i_GameManager;
            r_CellButtons = new CellButton[s_GameManager.RowSize, s_GameManager.ColSize];
            s_GameManager.PlayerSwitched += s_GameManager_PlayerSwitched;
            initializeButtons();
            InitializeComponent();

            s_GameManager.Player1.ScoreChanged += player1_ScoreChanged;
            s_GameManager.Player2.ScoreChanged += player2_ScoreChanged;

            Player1Label.Text = s_GameManager.Player1.Name + ':';
            Player2Label.Text = s_GameManager.Player2.Name + ':';

            alignComponents();
        }

        private void alignComponents()
        {
            CellButton lastButton = r_CellButtons[s_GameManager.RowSize - 1, s_GameManager.ColSize - 1];
            int clientSizeWidth = s_GameManager.ColSize * (lastButton.Width + 10) + 10;
            int clientSizeHeight = s_GameManager.RowSize * (lastButton.Height + 10) + 20 + Player1Label.Height + 20;
            this.ClientSize = new Size(clientSizeWidth, clientSizeHeight);

            Player1Label.Top = lastButton.Bottom + 20;
            Player1ScoreLabel.Top = Player1Label.Top;
            Player2Label.Top = Player1Label.Top;
            Player2ScoreLabel.Top = Player1Label.Top;

            Player1ScoreLabel.Left = (this.ClientSize.Width / 2) - Player1ScoreLabel.Width - 10;
            Player1Label.Left = Player1ScoreLabel.Left - 5 - Player1Label.Width;
            Player2Label.Left = this.ClientSize.Width / 2 + 10;
            Player2ScoreLabel.Left = Player2Label.Right + 5;
        }

        private void player2_ScoreChanged(int i_Score)
        {
            Player2ScoreLabel.Text = i_Score.ToString();
        }

        private void player1_ScoreChanged(int i_Score)
        {
            Player1ScoreLabel.Text = i_Score.ToString();
        }

        private void s_GameManager_PlayerSwitched()
        {
            if(Player1Label.Font.Bold == true)
            {
                Player1Label.Font = new Font(Player1Label.Font, FontStyle.Regular);
                Player1ScoreLabel.Font = new Font(Player1ScoreLabel.Font, FontStyle.Regular);

                Player2Label.Font = new Font(Player2Label.Font, FontStyle.Bold);
                Player2ScoreLabel.Font = new Font(Player2ScoreLabel.Font, FontStyle.Bold);
            }
            else
            {
                Player1Label.Font = new Font(Player1Label.Font, FontStyle.Bold);
                Player1ScoreLabel.Font = new Font(Player1ScoreLabel.Font, FontStyle.Bold);

                Player2Label.Font = new Font(Player2Label.Font, FontStyle.Regular);
                Player2ScoreLabel.Font = new Font(Player2ScoreLabel.Font, FontStyle.Regular);
            }
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
                    currentButton.Click += cellButton_Click;
                    currentButton.TabStop = false;
                    r_CellButtons[i, j] = currentButton;
                    this.Controls.Add(currentButton);
                }

                xPosition = 10;
                yPosition += 60;
            }
        }
        
        private void cellButton_Click(object sender, EventArgs e)
        {
            bool isGameEnded = false;
            CellButton currentButton = (sender as CellButton);
            makeAMove(currentButton);
            isGameEnded = checkGameEnded(currentButton.ButtonBoardCellPosition);
            if(s_GameManager.IsVersusComputer && !isGameEnded)
            {
                Position? computerChoice = s_GameManager.GetComputerPositionChoice();
                if(computerChoice.HasValue)
                {
                    makeAMove(r_CellButtons[computerChoice.Value.Row, computerChoice.Value.Column]);
                    checkGameEnded(computerChoice.Value);
                }
            }
        }

        private void makeAMove(CellButton i_CellButton)
        {
            s_GameManager.SetPositionOnBoard(i_CellButton.ButtonBoardCellPosition);
            i_CellButton.Enabled = false;
        }

        private bool checkGameEnded(Position i_Position)
        {
            bool isTie = false;
            bool isGameEnded = false;

            isGameEnded = s_GameManager.IsGameEnded(i_Position, out isTie);
            if (isTie)
            {
                showTieMessageBox();
            }
            else if (isGameEnded)
            {
                s_GameManager.CurrentPlayerWins();
                showWinnerMessageBox(s_GameManager.CurrentPlayer.Name);
            }
            else
            {
                s_GameManager.SwitchCurrentPlayer();
            }
            return isGameEnded || isTie;
        }

        private void showTieMessageBox()
        {
            string headerText = "A Tie!";
            string innerText = string.Format("Tie!{0}Would you like to play another round?", Environment.NewLine);
            DialogResult result = MessageBox.Show(innerText, headerText, MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                playAnotherRound();
            }
            else
            {
                this.Close();
            }
        }

        private void showWinnerMessageBox(string i_WinnerName)
        {
            string headerText = "A Win!";
            string innerText = string.Format(
                "The winner is {0}!{1}Would you like to play another round?",
                i_WinnerName,
                Environment.NewLine);
            DialogResult result = MessageBox.Show(innerText, headerText, MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                playAnotherRound();
            }
            else
            {
                this.Close();
            }
        }

        private void playAnotherRound()
        {
            s_GameManager.ResetGameToNewRound();
            foreach(var cellButton in r_CellButtons)
            {
                cellButton.Enabled = true;
            }
            Player1Label.Font = new Font(Player1Label.Font, FontStyle.Bold);
            Player1ScoreLabel.Font = new Font(Player1ScoreLabel.Font, FontStyle.Bold);

            Player2Label.Font = new Font(Player2Label.Font, FontStyle.Regular);
            Player2ScoreLabel.Font = new Font(Player2ScoreLabel.Font, FontStyle.Regular);
        }
    }
}
