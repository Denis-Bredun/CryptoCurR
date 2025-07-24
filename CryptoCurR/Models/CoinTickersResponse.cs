using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Models
{
    public class CoinTickersResponse
    {
        public string? Name { get; set; }
        public Ticker[]? Tickers { get; set; }
    }
}
