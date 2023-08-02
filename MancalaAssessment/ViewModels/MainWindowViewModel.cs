using System.ComponentModel;
using MancalaAssessment.Models;

namespace MancalaAssessment.ViewModels
{
    public class MainWindowViewModel : NotifyPropertyBase
    {
        private string bannerText = "Click \"New Game\" to get started!";
        public string BannerText
        {
            get => bannerText;
            set
            {
                if(bannerText != value)
                {
                    bannerText = value;
                   OnPropertyChanged();
                }
            }
        }
    }
}
