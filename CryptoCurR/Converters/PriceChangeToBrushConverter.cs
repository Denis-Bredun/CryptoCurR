using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            if (value is double doubleValue)
                return GetBrush(doubleValue);

            if (value is float floatValue)
                return GetBrush(floatValue);

            if (value is decimal decimalValue)
                return GetBrush((double)decimalValue);

            if (double.TryParse(value.ToString(), out double parsedValue))
                return GetBrush(parsedValue);

            return NeutralBrush;
        }

        private Brush GetBrush(double value)
        {
            if (value > 0)
                return PositiveBrush;
            else if (value < 0)
                return NegativeBrush;
            else
                return NeutralBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
