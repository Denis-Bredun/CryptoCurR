using CryptoCurR.Models;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CryptoCurR.Converters
{
    public class MarketChartConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not MarketChartData chartData || chartData.Prices == null)
                return null;

            var values = CreateChartValues(chartData.Prices);
            var series = CreateLineSeries(values);

            return new SeriesCollection { series };
        }

        private static ChartValues<ObservablePoint> CreateChartValues(float[][] prices)
        {
            var values = new ChartValues<ObservablePoint>();

            foreach (var pricePoint in prices)
            {
                if (pricePoint.Length != 2)
                    continue;

                var timestampMs = (long)pricePoint[0];
                var price = (double)pricePoint[1];
                var dateTime = DateTimeOffset.FromUnixTimeMilliseconds(timestampMs).DateTime;

                values.Add(new ObservablePoint(dateTime.Ticks, price));
            }

            return values;
        }

        private static LineSeries CreateLineSeries(ChartValues<ObservablePoint> values)
        {
            return new LineSeries
            {
                Title = "Price",
                Values = values,
                PointGeometry = null,
                StrokeThickness = 2,
                Fill = Brushes.Transparent
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
