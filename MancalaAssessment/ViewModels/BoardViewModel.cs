using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MancalaAssessment.ViewModels
{
    public class BoardViewModel : ViewModelBase
    {
        private ObservableCollection<int> _stonesPlayer1 = new ObservableCollection<int>() { 4, 4, 4, 4, 4, 4 };
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

        private ObservableCollection<int> _stonesPlayer2 = new ObservableCollection<int>() { 4, 4, 4, 4, 4, 4 };
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
                    //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(StorePlayer2)));
                }
            }
        }

        
    }
}
