using System.Linq;
using System.Runtime.CompilerServices;

namespace MancalaAssessment.Models
{
    internal class GameManager
    {
        private BoardState _boardState;
        private readonly int _boardSize;

        //Boards will include stores
        public GameManager(BoardState boardState) 
        {
            _boardState = boardState;
            _boardSize = boardState.Board.Count();
        }

        private GameStatus Move(int playerNumber, int pitNumber)
        {
            //figyelj a pit number re h 0 e vagy 1 tol kezdodik DIK!!!
            var board = _boardState.Board;
            int stoneCount = board[pitNumber];
            int store = (_boardState.Board.Length / 2 * playerNumber) - 1;
            board[pitNumber] = 0;

            while (stoneCount > 0)
            {
                pitNumber++;
                if (pitNumber == store)
                {
                    board[pitNumber]++;
                    stoneCount--; 

                    //ITT TARTOTTAM
                }
            }

            return GameStatus.Ongoing;
        }

        private GameStatus GetGameStatus()
        {
            bool isGameOver = false;
            var board = _boardState.Board;

            //Thiese elements of the boards are alwys the store elements no matter the size.
            var store1 = (board.Length / 2) - 1;
            var store2 = board.Length - 1;

            if (!board.Take(6).Any(x => x > 0))
            {
                board[store2] += board.Skip(7).Take(6).Sum();
                isGameOver = true;
                return GameStatus.P1Win;
            }
            else if(!board.Skip(7).Take(6).Any(x => x > 0))
            {
                board[store1] += board.Take(6).Sum();
                isGameOver = true;
                return GameStatus.P2Win;
            }
            if (!isGameOver)
            {
                return GameStatus.Ongoing;
            }

            if (board[store1] > board[store2])
            {
                return GameStatus.P1Win;
            }
            else if (board[store1] < board[store2])
            {
                return GameStatus.P2Win;
            }

            return GameStatus.Draw;
        }
    }

    public struct BoardState
    {
        public int[] Board;
        public GameStatus GameStatus;
        public int PlayerTurn;
    }

    public enum GameStatus
    {
        Ongoing,
        P1Win,
        P2Win,
        Draw
    }
}
