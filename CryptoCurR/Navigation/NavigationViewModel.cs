using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurR.Navigation
{
    public partial class NavigationViewModel : ObservableObject, IDisposable
    {
        private readonly NavigationStore _navigationStore;

        public ObservableObject? CurrentViewModel => _navigationStore.CurrentViewModel;

        public NavigationViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.PropertyChanged += OnNavigationStoreChanged;
        }

        private void OnNavigationStoreChanged(object? sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(NavigationStore.CurrentViewModel))
            {
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public void Dispose()
        {
            _navigationStore.PropertyChanged -= OnNavigationStoreChanged;
        }
    }
}
