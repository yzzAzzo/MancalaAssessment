using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MancalaAssessment.Models;

namespace MancalaAssessment.Interfaces
{
    public interface IGameManager
    {
       BoardState BoardState { get; }
       BoardState Move(int pitNumber);
       GameStatus GetGameStatus();

    }
}
