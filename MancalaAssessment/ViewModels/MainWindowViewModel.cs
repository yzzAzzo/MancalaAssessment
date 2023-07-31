using MancalaAssessment.Models;
using System.ComponentModel;

namespace MancalaAssessment.ViewModels
{
    public class MainWindowViewModel : NotifyBase
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
