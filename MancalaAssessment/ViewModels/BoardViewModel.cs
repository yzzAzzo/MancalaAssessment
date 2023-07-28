using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using MancalaAssessment.Command;
using MancalaAssessment.Models;

namespace MancalaAssessment.ViewModels
{
    public class BoardViewModel : ViewModelBase
    {
        private GameManager _gameManager;

        private ObservableCollection<int> _stonesPlayer1 = new ObservableCollection<int>(Enumerable.Repeat(4, GameConstants.BOARD_SIZE / 2).ToArray());
        public ObservableCollection<int> StonesPlayer1
        {
            get => _stonesPlayer1;
            set
            {
                if (value != _stonesPlayer1)
                {
                    _stonesPlayer1 = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<int> _stonesPlayer2 = new ObservableCollection<int>(Enumerable.Repeat(4, GameConstants.BOARD_SIZE / 2).ToArray());
        public ObservableCollection<int> StonesPlayer2
        {
            get => _stonesPlayer2;
            set
            {
                if (value != _stonesPlayer2)
                {
                    _stonesPlayer2 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _storePlayer1 = 0;
        public int StorePlayer1
        {
            get => _storePlayer1;
            set
            {
                if (value != _storePlayer1)
                {
                    _storePlayer1 = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _storePlayer2 = 0;
        public int StorePlayer2
        {
            get => _storePlayer2;
            set
            {
                if (value != _storePlayer2)
                {
                    _storePlayer2 = value;
                    OnPropertyChanged();
                }
            }
        }
        public DelegateCommand MoveCommand { get; }


        public BoardViewModel()
        {
            MoveCommand = new DelegateCommand(MoveExecute);
            _gameManager = new GameManager(new BoardState(Enumerable.Repeat(4, GameConstants.BOARD_SIZE).ToArray(), 1));
        }



        private void StartNewGame()
        {
            //Instanciates the gameManager with the right settings(who starts, board size)
            _gameManager = new GameManager(new BoardState(Enumerable.Repeat(4, GameConstants.BOARD_SIZE).ToArray(), 1));

        }

        private void MoveExecute(object? parameter)
        {
            var asd = 1;

        }


        
    }
}
