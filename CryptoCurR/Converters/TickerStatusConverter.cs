using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace CryptoCurR.Converters
{
    public class TickerStatusConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length < 2 || values[0] == DependencyProperty.UnsetValue || values[1] == DependencyProperty.UnsetValue)
                return "✓";

            bool? isAnomaly = values[0] as bool?;
            bool? isStale = values[1] as bool?;

            if (isAnomaly == true)
                return "⚠";
            else if (isStale == true)
                return "⏰";
            else
                return "✓";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 