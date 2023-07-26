using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MancalaAssessment.Interfaces
{
    internal interface IMancalaPlayer
    {
        ObservableCollection<int> StoneCollection { get; set; }

        int Store { get; set; }
    }
}
