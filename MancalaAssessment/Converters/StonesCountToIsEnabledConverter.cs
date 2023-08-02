using System;
using System.Globalization;
using System.Windows.Data;

namespace MancalaAssessment.Converters;

public class StonesCountToIsEnabledConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var stones = (int)value;

        return stones > 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}