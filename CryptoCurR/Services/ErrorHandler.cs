using CryptoCurR.Interfaces;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToastNotifications;
using ToastNotifications.Messages;

namespace CryptoCurR.Services
{
    public class ErrorHandler(Notifier notifier) : IErrorHandler
    {
        public void HandleWarning(string logMessageTemplate, string context, string userNotification)
        {
            Log.Warning(logMessageTemplate, context);
            notifier.ShowWarning(userNotification);
        }

        public void HandleError(Exception ex, string logMessageTemplate, string context, string userNotification)
        {
            Log.Error(ex, logMessageTemplate, context);
            notifier.ShowError(userNotification);
        }
    }
}
