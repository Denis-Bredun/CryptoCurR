using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CryptoCurR.Converters
{
    public class TrustScoreToBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string trustScore)
            {
                return trustScore.ToLower() switch
                {
                    "green" => new SolidColorBrush(Colors.Green),
                    "yellow" => new SolidColorBrush(Colors.Orange),
                    "red" => new SolidColorBrush(Colors.Red),
                    _ => new SolidColorBrush(Colors.Gray)
                };
            }
            
            return new SolidColorBrush(Colors.Gray);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 