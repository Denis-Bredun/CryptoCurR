using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CryptoCurR.Converters
{
    public class TimeframeToBrushMultiConverter : IMultiValueConverter
    {
        public Brush SelectedBrush { get; set; } = Brushes.Red;
        public Brush DefaultBrush { get; set; } = Brushes.Brown;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!HasValidValues(values))
                return DefaultBrush;

            return TryParseTimeframes(values, out int selected, out int current)
                ? (selected == current ? SelectedBrush : DefaultBrush)
                : DefaultBrush;
        }

        private static bool HasValidValues(object[] values)
        {
            return values.Length >= 2 && values[0] != null && values[1] != null;
        }

        private static bool TryParseTimeframes(object[] values, out int selected, out int current)
        {
            selected = 0;
            current = 0;

            return int.TryParse(values[0].ToString(), out selected) &&
                   int.TryParse(values[1].ToString(), out current);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
