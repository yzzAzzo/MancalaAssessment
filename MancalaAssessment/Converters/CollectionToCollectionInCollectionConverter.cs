using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using MancalaAssessment.Models;

namespace MancalaAssessment.Converters
{
    internal class CollectionToCollectionInCollectionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var pitDatas = (ObservableCollection<PitData>)value;

            var collectionInCollection = new ObservableCollection<ObservableCollection<PitData>>();

            var player1 = pitDatas.Take(pitDatas.Count / 2).ToList();
            var player2 = pitDatas.Skip(pitDatas.Count/2).Take(pitDatas.Count / 2).ToList();

            collectionInCollection.Add(new ObservableCollection<PitData>(player1));
            collectionInCollection.Add(new ObservableCollection<PitData>(player2));
           
            return collectionInCollection;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
