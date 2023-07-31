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
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
