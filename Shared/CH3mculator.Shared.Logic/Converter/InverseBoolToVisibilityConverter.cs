using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CH3mculator.Shared.Logic.Converter
{
    public class InverseBoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value?.GetType() == typeof(bool) && (bool)value == true)
                return Visibility.Collapsed;
            else
                return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value?.GetType() == typeof(Visibility) && (Visibility)value == Visibility.Visible)
                return false;
            else
                return true;
        }
    }
}
