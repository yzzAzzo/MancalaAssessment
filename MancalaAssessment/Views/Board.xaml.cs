using MancalaAssessment.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;

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
            DataContext = new BoardViewModel();
        }
    }
}
