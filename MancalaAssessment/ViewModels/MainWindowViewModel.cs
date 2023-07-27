using System.ComponentModel;

namespace MancalaAssessment.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
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
