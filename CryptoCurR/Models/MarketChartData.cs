using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Models
{
    public class MarketChartData
    {
        public float[][]? Prices { get; set; }
        public float[][]? MarketCaps { get; set; }
        public float[][]? TotalVolumes { get; set; }
    }
}
