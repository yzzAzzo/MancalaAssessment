using System.Linq;
using System.Runtime.CompilerServices;

namespace MancalaAssessment.Models
{
    internal class GameManager
    {

        private BoardState _boardState;
        public BoardState BoardState
        {
            get => _boardState;
            set => _boardState = value;
        }


        //Boards will include stores
        public GameManager() 
        {
            _boardState = new BoardState();
        }

        public BoardState Move(int pitNumber)
        {
            //figyelj a pit number re h 0 e vagy 1 tol kezdodik DIK!!!
            var board = _boardState.Board;
            int stoneCount = board[pitNumber];


            //Determine the index of the callerPlayers store and the opponents.
            int store = (_boardState.Board.Count / 2 * _boardState.PlayerNumber) - 1;
            int opponentStore = _boardState.PlayerNumber == 1 ? store * 2 : store / 2;

            //Reset the chosen pit because we took all the stones out.
            board[pitNumber] = 0;
            pitNumber++;

            //TODO Rethink all of this


            while (stoneCount > 0)
            {
               
                if (pitNumber != opponentStore)
                {
                    board[pitNumber]++;
                    stoneCount--; 
                }

                if (stoneCount == 0 && pitNumber == store)
                {
                    return _boardState;
                    //return
                    //Signal your turn Again.
                }

                if (stoneCount == 0 && pitNumber < store && pitNumber >= store - (board.Count / 2 - 1) && board[pitNumber] == 1)
                {
                    //In this case we have finished putting stones on our side in an empty pit.
                    // note: if we subtract 2(the 2 stores) from board.Length we get the number that the opposing pits index and the
                    // current one has to add up to. e.g.: board.Length == 14, -2 => 12, so opposing is 12 - pitNumber.

                    int opposingPitNumber = (board.Count - 2) - pitNumber;
                    board[store] += board[opposingPitNumber] + 1;

                    _boardState.PlayerNumber = _boardState.PlayerNumber == 2 ? 1: 2;

                    return _boardState;
                    //return
                    //Signal your turn is over.
                }

                pitNumber++;

                if (pitNumber == board.Count)
                {
                    //Reset the pit index, because we did a full circle
                    pitNumber = 0;
                }
            }

            _boardState.PlayerNumber = _boardState.PlayerNumber == 2 ? 1 : 2;

            return _boardState;
            //Signal end of turn

        }

        private GameStatus GetGameStatus()
        {
            bool isGameOver = false;
            var board = _boardState.Board;

            //Thiese elements of the boards are always the store elements no matter the size.
            var store1 = (board.Count / 2) - 1;
            var store2 = board.Count - 1;

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

    public enum GameStatus
    {
        Ongoing,
        P1Win,
        P2Win,
        Draw
    }

}
