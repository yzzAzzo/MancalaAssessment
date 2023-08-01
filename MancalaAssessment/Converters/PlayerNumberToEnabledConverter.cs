using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MancalaAssessment.Converters;

public class PlayerNumberToEnabledConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var ownerPlayer = Int32.Parse((string)parameter);
        var playerNumber = (int)value;

        return ownerPlayer == playerNumber;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}