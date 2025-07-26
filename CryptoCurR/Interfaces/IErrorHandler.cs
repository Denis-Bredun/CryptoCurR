using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Interfaces
{
    public interface IErrorHandler
    {
        void HandleWarning(string logMessageTemplate, string context, string userNotification);
        void HandleError(Exception ex, string logMessageTemplate, string context, string userNotification);
    }
}
