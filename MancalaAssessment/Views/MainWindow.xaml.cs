using MancalaAssessment.ViewModels;
using System;
using System.Windows;

namespace MancalaAssessment.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BoardViewModel boardViewModel;
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
           
        }
    }
}
