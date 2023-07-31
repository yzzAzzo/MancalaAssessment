using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using MancalaAssessment.Command;
using MancalaAssessment.Models;
using MancalaAssessment.Views;

namespace MancalaAssessment.ViewModels
{
    public class BoardViewModel : NotifyBase
    {
        private GameManager _gameManager;

        private int _playerNumber = 0;
        public int PlayerNumber
        {
            get => _playerNumber;
            set
            {
                _playerNumber = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<PitData> _pitDatas;

        public ObservableCollection<PitData> PitDatas
        {
            get => _pitDatas;
            set
            {
                _pitDatas = value;
                OnPropertyChanged();
            }
        }

        private int _storePlayer1 = 0;
        public int StorePlayer1
        {
            get => _storePlayer1;
            set
            {
                _storePlayer1 = value;
                OnPropertyChanged();
            }
        }

        private int _storePlayer2 = 0;
        public int StorePlayer2
        {
            get => _storePlayer2;
            set
            {
                _storePlayer2 = value;
                OnPropertyChanged();
            }
        }
        public DelegateCommand MoveCommand { get; }


        public BoardViewModel()
        {
            MoveCommand = new DelegateCommand(MoveExecute);

            _pitDatas = new ObservableCollection<PitData>(
                Enumerable.Repeat(new PitData(4,1),GameConstants.BOARD_SIZE / 2 - 1 ).ToArray()
                    .Concat(Enumerable.Repeat(new PitData(4,2), GameConstants.BOARD_SIZE / 2 - 1).ToArray()));

            _gameManager = new GameManager(new BoardState(Enumerable.Repeat(4, GameConstants.BOARD_SIZE).ToArray(), 1));
        }

        private void StartNewGame()
        {
            //Instanciates the gameManager with the right settings(who starts, board size)
            _gameManager = new GameManager(new BoardState(Enumerable.Repeat(4, GameConstants.BOARD_SIZE).ToArray(), 1));
        }

        private void MoveExecute(object? parameter)
        {

            if (parameter != null)
            {
                //TODO parameter is the focused element, check later if this can go wrong.
                var boardState = _gameManager.Move((int)parameter);

                StorePlayer1 = boardState.Board[GameConstants.BOARD_SIZE / 2 - 1];
                StorePlayer2 = boardState.Board[GameConstants.BOARD_SIZE - 1];
                var pitList = boardState.Board.Take(_pitDatas.Count / 2).Skip(1).Take(_pitDatas.Count / 2).ToList();

                for (int i = 0; i < pitList.Count; i++)
                {
                    if (i < _pitDatas.Count)
                    {
                        _pitDatas[i].Stones = pitList[i]; 
                    }
                }

            }

        }


        
    }
}
