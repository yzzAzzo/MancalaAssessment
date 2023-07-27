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

            //Determine the index of the callerPlayers store and the opponents.
            int store = (_boardState.Board.Length / 2 * playerNumber) - 1;
            int opponentStore = playerNumber == 1 ? store * 2 : store / 2;

            //Reset the chosen pit because we took all the stones out.
            board[pitNumber] = 0;

            while (stoneCount > 0)
            {
                pitNumber++;
                if (pitNumber == board.Length)
                {
                    //Reset the pit index, because we did a full circle
                    pitNumber = 0;
                }
                if (pitNumber != opponentStore)
                {
                    board[pitNumber]++;
                    stoneCount--; 
                }

                if (stoneCount == 0 && pitNumber == store)
                {
                    //return
                    //Signal your turn Again.
                }

                if (stoneCount == 0 && pitNumber < store && pitNumber >= store - (board.Length / 2 - 1) && board[pitNumber] == 1)
                {
                    //In this case we have finished putting stones on our side in an empty pit.
                    // note: if we subtract 2(the 2 stores) from board.Length we get the number that the opposing pits index and the
                    // current one has to add up to. e.g.: board.Length == 14, -2 => 12, so opposing is 12 - pitNumber.

                    int opposingPitNumber = (board.Length - 2) - pitNumber;
                    board[store] += board[opposingPitNumber] + 1;

                    //return
                    //Signal your turn is over.
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
