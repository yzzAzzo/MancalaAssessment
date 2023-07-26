using MancalaAssessment.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MancalaAssessment.Models
{
    internal class MancalaPlayer : IMancalaPlayer
    {

        // we will need INotifyWrapper on this

        private ObservableCollection<int> _stoneCollection;

        public ObservableCollection<int> StoneCollection
        {
            get { return _stoneCollection; }
            set { _stoneCollection = value; }
        }

        private int _store;

        public int Store
        {
            get { return _store; }
            set { _store = value; }
        }

        public MancalaPlayer(ObservableCollection<int> stoneCollection) 
        {
            _store = 0;
            _stoneCollection = stoneCollection;

        }
    }
}
