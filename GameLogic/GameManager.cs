using System;
using System.Collections.Generic;

namespace GameLogic
{
    public class GameManager
    {
        private readonly Board r_Board;
        private Player m_Player1;
        private Player m_Player2;
        private Player m_CurrentPlayer;
        private int m_MovesCount;
        private readonly Random r_RandomComputerChoice;

        public event Action PlayerSwitched;

        public GameManager(
            int i_RowSize,
            int i_ColSize,
            bool i_IsVersusComputer,
            string i_Player1Name,
            string i_Player2Name)
        {
            const bool v_IsComputer = true;
            r_Board = new Board(i_RowSize, i_ColSize);
            m_Player1 = new Player('X', !v_IsComputer);
            m_Player1.Name = i_Player1Name;
            m_Player2 = new Player('O', i_IsVersusComputer);
            m_Player2.Name = i_Player2Name;
            m_CurrentPlayer = m_Player1;
            m_MovesCount = 0;
            r_RandomComputerChoice = new Random();
        }

        private Board GameBoard
        {
            get
            {
                return r_Board;
            }
        }

        public int RowSize
        {
            get
            {
                return GameBoard.RowSize;
            }
        }

        public int ColSize
        {
            get
            {
                return GameBoard.ColumnSize;
            }
        }

        public Player CurrentPlayer
        {
            get
            {
                return m_CurrentPlayer;
            }
            set
            {
                m_CurrentPlayer = value;
            }
        }

        public Player Player1
        {
            get
            {
                return m_Player1;
            }
        }

        public Player Player2
        {
            get
            {
                return m_Player2;
            }
        }

        public bool IsVersusComputer
        {
            get
            {
                return Player2.IsComputer;
            }
        }

        public bool IsGoodPositionChoice(Position i_Position)
        {
            bool isGood = true;
            if (GameBoard.GetPositionSymbol(ref i_Position) != ' ')
            {
                isGood = false;
            }

            return isGood;
        }

        public bool SetPositionOnBoard(Position i_Position)
        {
            bool isGoodPosition = IsGoodPositionChoice(i_Position);
            if (isGoodPosition == true)
            {
                GameBoard.SetSymbol(ref i_Position, m_CurrentPlayer.Symbol);
                m_MovesCount++;
            }
            return isGoodPosition;
        }

        public Position? GetComputerPositionChoice()
        {
            List<Position> positionList = GetAvailablePositions();
            Position? resPosition = null;
            if(positionList.Count != 0)
            {
                int randomIndex = r_RandomComputerChoice.Next(positionList.Count);
                resPosition = positionList[randomIndex];
            }
            return resPosition;
        }

        public List<Position> GetAvailablePositions()
        {
            List<Position> positionList = new List<Position>();
            Position currentPosition = new Position();
            for(int i = 0; i < GameBoard.RowSize; i++)
            {
                for(int j = 0; j < GameBoard.ColumnSize; j++)
                {
                    currentPosition.SetLocation(i, j);
                    if(IsGoodPositionChoice(currentPosition))
                    {
                        positionList.Add(currentPosition);
                    }
                }
            }
            return positionList;
        }

        public bool IsGameEnded(Position i_LastPosition, out bool o_IsTie)
        {
            bool isRow = isFullRow(i_LastPosition);
            bool isColumn = isFullColumn(i_LastPosition);
            bool isSlant = isFullSlant();
            bool isReachMaxMoves = m_MovesCount == GameBoard.RowSize * GameBoard.ColumnSize;
            o_IsTie = isReachMaxMoves;
            return isRow || isColumn || isSlant;
        }

        public void CurrentPlayerWins()
        {
            CurrentPlayer.Score++;
        }

        public void SwitchCurrentPlayer()
        {
            if(CurrentPlayer.Equals(Player1))
            {
                CurrentPlayer = Player2;
            }
            else
            {
                CurrentPlayer = Player1;
            }
            OnPlayerSwitched();
        }

        private bool isFullRow(Position i_LastPosition)
        {
            bool isFull = true;
            char symbol = m_CurrentPlayer.Symbol;
            Position tempPosition = new Position(i_LastPosition.Row, 0);
            for(int i = 0; i < GameBoard.ColumnSize; i++)
            {
                tempPosition.Column = i;
                if(GameBoard.GetPositionSymbol(ref tempPosition) != symbol)
                {
                    isFull = false;
                    break;
                }
            }
            return isFull;
        }

        private bool isFullColumn(Position i_LastPosition)
        {
            bool isFull = true;
            char symbol = m_CurrentPlayer.Symbol;
            Position tempPosition = new Position(0, i_LastPosition.Column);
            for (int i = 0; i < GameBoard.RowSize; i++)
            {
                tempPosition.Row = i;
                if (GameBoard.GetPositionSymbol(ref tempPosition) != symbol)
                {
                    isFull = false;
                    break;
                }
            }
            return isFull;
        }

        private bool isFullSlant()
        {
            bool isFullMain = true;
            bool isFullSecond = true;
            char symbol = m_CurrentPlayer.Symbol;
            Position tempPosition = new Position();
            //check main slant
            for(int i = 0; i < GameBoard.RowSize; i++)
            {
                tempPosition.SetLocation(i, i);
                if (GameBoard.GetPositionSymbol(ref tempPosition) != symbol)
                {
                    isFullMain = false;
                    break;
                }
            }

            //check second slant
            for(int i = GameBoard.RowSize - 1; i >= 0; i--)
            {
                tempPosition.SetLocation(i, GameBoard.RowSize - 1 - i);
                if (GameBoard.GetPositionSymbol(ref tempPosition) != symbol)
                {
                    isFullSecond = false;
                    break;
                }
            }
            return isFullMain || isFullSecond;
        }

        public void ResetGameToNewRound()
        {
            CurrentPlayer = Player1;
            GameBoard.ResetBoard();
            m_MovesCount = 0;
        }

        public BoardCell GetBoardCell(Position i_Position)
        {
            return GameBoard.GetBoardCell(ref i_Position);
        }

        protected virtual void OnPlayerSwitched()
        {
            PlayerSwitched?.Invoke();
        }
    }
}
