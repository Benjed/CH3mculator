using System;
using System.Globalization;
using System.Windows.Data;

namespace CH3mculator.Shared.Logic.Converter
{
    public class SignificantFigureStringFormatConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double number)
            {
                const string NOT_AVAILABLE = "N/A";
                int significantFigures = UsersettingsProvider.GetUsersettings().Value.SignificantFigure;
                return double.IsInfinity(number) || (parameter is string param && param == "density" && number == 0.0)
                    ? NOT_AVAILABLE
                    : number.ToString($"N{significantFigures}", new CultureInfo("en-US"));
            }
            else
                return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string textNumber)
            {
                bool isValid = double.TryParse(textNumber, NumberStyles.Float, new CultureInfo("en-US"), out double result);
                if (isValid)
                    return result;
                else
                    return null;
            }
            else
                return value;
        }
    }
}
