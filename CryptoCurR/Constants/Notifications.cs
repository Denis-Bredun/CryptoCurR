using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Constants
{
    public static class Notifications
    {
        public const string NetworkErrorNotification =
            "No internet connection.";

        public const string HttpErrorNotification =
            "Network error while {0}.";

        public const string JsonErrorNotification =
            "Data parsing error while {0}.";

        public const string OhlcParsingErrorNotification =
            "Something went wrong while parsing OHLC data.";
    }
}
