using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CryptoCurR.Converters
{
    public class PriceChangeToBrushConverter : IValueConverter
    {
        private static readonly Brush PositiveBrush = new SolidColorBrush(Color.FromRgb(76, 175, 80));
        private static readonly Brush NegativeBrush = new SolidColorBrush(Color.FromRgb(244, 67, 54));
        private static readonly Brush NeutralBrush = new SolidColorBrush(Color.FromRgb(189, 189, 189));

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return NeutralBrush;

            return value switch
            {
                double doubleValue => GetBrush(doubleValue),
                float floatValue => GetBrush(floatValue),
                decimal decimalValue => GetBrush((double)decimalValue),
                _ => TryParseAndGetBrush(value)
            };
        }

        private Brush TryParseAndGetBrush(object value)
        {
            return double.TryParse(value.ToString(), out double parsedValue) 
                ? GetBrush(parsedValue) 
                : NeutralBrush;
        }

        private static Brush GetBrush(double value)
        {
            return value switch
            {
                > 0 => PositiveBrush,
                < 0 => NegativeBrush,
                _ => NeutralBrush
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
