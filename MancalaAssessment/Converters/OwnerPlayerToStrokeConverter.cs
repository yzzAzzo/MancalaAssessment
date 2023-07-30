using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MancalaAssessment.Converters;

public class OwnerPlayerToStrokeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var ownerNumber = (int)value;

        return ownerNumber == 1 ? System.Drawing.Color.CornflowerBlue : System.Drawing.Color.Magenta;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}