using CryptoCurR.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Navigation
{
    public interface IViewModelFactory
    {
        Task<MainPageViewModel> CreateMainPageViewModel();
        Task<CoinDetailsViewModel> CreateCoinDetailsViewModel(string coinId);
    }
}
