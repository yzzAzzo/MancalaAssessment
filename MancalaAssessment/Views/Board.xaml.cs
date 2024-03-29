﻿using MancalaAssessment.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using MancalaAssessment.Models;

namespace MancalaAssessment.Views
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        public Board()
        {
            InitializeComponent();
            var boardState = new BoardState();
            var gameManager = new GameManager(boardState);
            var viewModel = new BoardViewModel(gameManager);
            DataContext = viewModel;
        }
    }
}
