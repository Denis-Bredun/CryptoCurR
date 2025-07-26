using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Constants
{
    public static class LogMessages
    {
        public const string NetworkUnavailable =
            "No internet connection detected while {0}.";

        public const string HttpError =
            "HTTP error occurred while {0}.";

        public const string JsonError =
            "JSON parse error occurred while {0}.";

        public const string OhlcParsingError =
            "Critical error occurred while parsing OHLC data for '{0}'.";
    }
}
