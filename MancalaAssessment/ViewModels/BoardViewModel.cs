using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows.Input;
using MancalaAssessment.Command;
using MancalaAssessment.Models;

namespace MancalaAssessment.ViewModels
{
    public class BoardViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private GameManager _gameManager;

        private int _playerNumber = 0;
        public int PlayerNumber
        {
            get => _playerNumber;
            set
            {
                _playerNumber = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayerNumber)));
            }
        }

        private ObservableCollection<PitData> _stonesPlayer1;
        public ObservableCollection<PitData> StonesPlayer1
        {
            get => _stonesPlayer1;
            set
            {
                _stonesPlayer1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StonesPlayer1)));
            }
        }

        private ObservableCollection<PitData> _stonesPlayer2;
        public ObservableCollection<PitData> StonesPlayer2
        {
            get => _stonesPlayer2;
            set
            {
                _stonesPlayer2 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StonesPlayer2)));
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StorePlayer1)));
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
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StorePlayer2)));
                }
            }
        }

        public DelegateCommand MoveCommand { get; }
        public BoardViewModel()
        {
            MoveCommand = new DelegateCommand(MoveExecute);

            var pitCount = GameConstants.BOARD_SIZE - 2;
            _stonesPlayer1 = new ObservableCollection<PitData>();
            _stonesPlayer2 = new ObservableCollection<PitData>();

            for (int i = 0; i < pitCount; i++)
            {
                if (i < pitCount / 2)
                {
                    _stonesPlayer1.Add(new PitData(4, 1));
                }
                else
                {
                    _stonesPlayer2.Add(new PitData(4, 2));
                }
            }

            //TODO set 0 for the stores.
            _gameManager = new GameManager();
            _playerNumber = _gameManager.BoardState.PlayerNumber;
        }


        private void StartNewGame()
        {
            //Instanciates the gameManager with the right settings(who starts, board size)
            _gameManager = new GameManager();
        }
        private void MoveExecute(object? parameter)
        {
            if (parameter != null)
            {
                //We get the pitNumber based on the upcoming player.
                int pitNumber;
                // check for GameConstants.BOARD_SIZE are not odd
                

                if (_gameManager.BoardState.PlayerNumber == 2)
                {
                    pitNumber = GameConstants.BOARD_SIZE / 2 + (int)parameter;
                }
                else
                {
                    pitNumber = (int)parameter;
                }

                var boardState = _gameManager.Move(pitNumber);

                UpdateUi(boardState);
            }
        }

        private void UpdateUi(BoardState boardState)
        {

            var halfOfPits = GameConstants.BOARD_SIZE / 2 - 1;

            PlayerNumber = boardState.PlayerNumber;

            StorePlayer1 = boardState.Board[halfOfPits];
            StorePlayer2 = boardState.Board[GameConstants.BOARD_SIZE - 1];
            var pitList = boardState.Board.Take(halfOfPits).Concat(boardState.Board.Skip(halfOfPits + 1).Take(halfOfPits)).ToList();


            for (int i = 0; i < halfOfPits; i++)
            {
                _stonesPlayer1[i].Stones = pitList[i];
                _stonesPlayer2[i].Stones = pitList.Skip(halfOfPits).ToArray()[i];

            }
        }
    }
}
