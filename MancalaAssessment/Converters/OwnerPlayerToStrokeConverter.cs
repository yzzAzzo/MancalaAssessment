﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MancalaAssessment.Converters;

public class OwnerPlayerToStrokeConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var ownerNumber = (int)value;

        return ownerNumber == 1 ? new SolidColorBrush(Colors.CornflowerBlue) : new SolidColorBrush(Colors.Magenta);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}