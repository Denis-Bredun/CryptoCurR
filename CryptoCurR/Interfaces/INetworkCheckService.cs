using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Interfaces
{
    public interface INetworkCheckService
    {
        Task<bool> IsInternetAvailableAsync();
    }
}
