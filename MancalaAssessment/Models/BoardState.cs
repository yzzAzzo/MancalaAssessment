using System;
using System.Collections.Generic;

namespace MancalaAssessment.Models;

public class BoardState
{
    public List<int> Board = new List<int>();
    public GameStatus GameStatus;
    public int PlayerNumber;

    public BoardState()
    {
        InitializeBoard();
        GameStatus = GameStatus.Ongoing;
        PlayerNumber = 1;
    }

    private void InitializeBoard()
    {
        for (int i = 0; i < GameConstants.BOARD_SIZE; i++)
        {
            if (i != GameConstants.BOARD_SIZE - 1 || i != GameConstants.BOARD_SIZE / 2 - 1)
            {
                Board.Add(4);
            }
            else
            {
                Board.Add(1);
            }
        }
    }
}