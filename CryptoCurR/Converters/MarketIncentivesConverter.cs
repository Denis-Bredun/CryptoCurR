using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace CryptoCurR.Converters
{
    public class MarketIncentivesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool hasTradingIncentive)
            {
                return hasTradingIncentive == true ? "🎁" : "✖";
            }
            
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 