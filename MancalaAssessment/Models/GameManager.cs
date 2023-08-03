using System.Linq;
using System.Runtime.CompilerServices;
using MancalaAssessment.Interfaces;

namespace MancalaAssessment.Models
{
    public class GameManager : IGameManager
    {

        private BoardState _boardState;
        public BoardState BoardState => _boardState;

        public GameManager(BoardState board) 
        {
            _boardState = board;
        }


        /// <summary>
        /// This plays one iteration on the Mancala table.
        /// </summary>
        /// <param name="pitNumber">Selected Pit number.</param>
        /// <returns>BoardState</returns>
        public BoardState Move(int pitNumber)
        {
            var board = _boardState.Board;
            int stoneCount = board[pitNumber];

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
                }

                if (stoneCount == 0 && pitNumber < store && pitNumber >= store - (board.Count / 2 - 1) && board[pitNumber] == 1)
                {
                    // In this case we have finished putting stones on our side in an empty pit.
                    
                    int opposingPitNumber = (board.Count - 2) - pitNumber;

                    // we take out our last
                    board[pitNumber]--;
                    
                    //and put it in our store
                    board[store] += board[opposingPitNumber] + 1;

                    //we take out the opponents as well
                    board[opposingPitNumber] = 0;

                    _boardState.PlayerNumber = _boardState.PlayerNumber == 2 ? 1: 2;

                    return _boardState;
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

        }

        /// <summary>
        /// Gets if the game is ongoing or over, and if so who won.
        /// </summary>
        /// <returns>GameStatus object.</returns>
        public GameStatus GetGameStatus()
        {
            bool isGameOver = false;
            var board = _boardState.Board;

            //Thiese elements of the boards are always the store elements no matter the size.
            var store1 = (board.Count / 2) - 1;
            var store2 = board.Count - 1;
            var halfOfPits = GameConstants.BOARD_SIZE / 2 - 1;

            if (!board.Take(halfOfPits).Any(x => x > 0))
            {
                board[store2] += board.Skip(halfOfPits + 1).Take(halfOfPits).Sum();
                isGameOver = true;
            }
            if(!board.Skip(halfOfPits + 1).Take(halfOfPits).Any(x => x > 0))
            {
                board[store1] += board.Take(halfOfPits).Sum();
                isGameOver = true;
            }
            if (!isGameOver)
            {
                return GameStatus.Ongoing;
            }

            if (board[store1] > board[store2])
            {
                return GameStatus.P1Win;
            }
            if (board[store1] < board[store2])
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
