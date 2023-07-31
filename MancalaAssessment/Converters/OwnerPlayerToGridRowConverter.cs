using System;
using System.Globalization;
using System.Windows.Data;

namespace MancalaAssessment.Converters;

public class OwnerPlayerToGridRowConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var playerNumber = (int)value;

        return playerNumber % 2;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}