using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MancalaAssessment.Views
{
    /// <summary>
    /// Interaction logic for GameEndWindow.xaml
    /// </summary>
    public partial class GameEndWindow : Window
    {
        public string GameOverText
        {
            get { return (string)GetValue(GameOverTextProperty); }
            set { SetValue(GameOverTextProperty, value); }
        }

        public static readonly DependencyProperty GameOverTextProperty = DependencyProperty.Register(
            nameof(GameOverText),
            typeof(string),
            typeof(GameEndWindow),
            new PropertyMetadata("")
        );

        public ICommand NewGameCommand
        {
            get { return (ICommand)GetValue(NewGameCommandProperty); }
            set { SetValue(NewGameCommandProperty, value); }
        }

        public static readonly DependencyProperty NewGameCommandProperty =
            DependencyProperty.Register(
                nameof(NewGameCommand),
                typeof(ICommand),
                typeof(GameEndWindow),
                new UIPropertyMetadata(null));
       
        public GameEndWindow(string gameEndText, ICommand newGameCommand)
        {
            GameOverText = gameEndText;
            NewGameCommand = newGameCommand;
            InitializeComponent();
        }
    }
}
