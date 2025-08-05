using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Navigation
{
    public interface INavigationService
    {
        Task NavigateToMainAsync();
        Task NavigateToCoinDetailsAsync(string coinId);
        Task NavigateToCurrencyConverterAsync();
    }
}
