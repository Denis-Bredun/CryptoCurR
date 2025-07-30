using CryptoCurR.Models;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace CryptoCurR.Converters
{
    public class OhlcSeriesConverter : IValueConverter
    {
        public static List<DateTime> XAxisDates { get; private set; } = new();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is not ObservableCollection<OhlcCandle> candles || candles.Count == 0)
                return null;

            var values = CreateOhlcValues(candles);
            var series = CreateOhlcSeries(values);

            return new SeriesCollection { series };
        }

        private static ChartValues<OhlcPoint> CreateOhlcValues(ObservableCollection<OhlcCandle> candles)
        {
            var values = new ChartValues<OhlcPoint>();
            XAxisDates = new List<DateTime>();

            foreach (var candle in candles)
            {
                if (!IsValidCandle(candle))
                    continue;

                values.Add(new OhlcPoint(
                    (double)candle.Open, 
                    (double)candle.High, 
                    (double)candle.Low, 
                    (double)candle.Close));

                XAxisDates.Add(candle.Timestamp.Value);
            }

            return values;
        }

        private static bool IsValidCandle(OhlcCandle candle)
        {
            return candle.Open != null && 
                   candle.High != null && 
                   candle.Low != null && 
                   candle.Close != null && 
                   candle.Timestamp != null;
        }

        private static OhlcSeries CreateOhlcSeries(ChartValues<OhlcPoint> values)
        {
            return new OhlcSeries
            {
                Values = values,
                Title = "Candlestick",
                StrokeThickness = 2
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
