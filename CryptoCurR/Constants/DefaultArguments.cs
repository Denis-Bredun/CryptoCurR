using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CryptoCurR.Converters;

namespace CryptoCurR.Constants
{
    public static class DefaultArguments
    {
        public const string VsCurrency = "usd";
        public const int CoinsMarketsPerPage = 10;
        public const int CoinsMarketsDefaultPage = 1;
        public const int DefaultPeriodInDays = 7;
        public const bool DefaultIsLineChart = true;
        public const string DateFormat = "MM/dd/yyyy HH:mm";
        public const int DefaultPricePrecision = 18;
        public const decimal DefaultConverterAmount = 1.0m;
        
        public static List<int> AvailableTimeframes { get; } = new() { 1, 7, 30 };
        
        public static Func<double, string> DateLabelFormatter { get; } =
            value => new DateTime((long)value).ToString(DateFormat);
            
        public static Func<double, string> OhlcLabelFormatter => value =>
        {
            int index = (int)value;
            if (index >= 0 && index < OhlcSeriesConverter.XAxisDates.Count)
            {
                return OhlcSeriesConverter.XAxisDates[index].ToString(DateFormat);
            }
            return string.Empty;
        };
    }
}
