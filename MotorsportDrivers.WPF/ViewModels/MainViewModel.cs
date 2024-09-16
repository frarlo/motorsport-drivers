using MotorsportDrivers.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private readonly ModalNavigationStore _modalNavigationStore;

        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;
        public bool IsModalOpen => _modalNavigationStore.IsOpen;
        public MotorsportDriversViewModel MotorsportDriversViewModel { get; }

        public MainViewModel(ModalNavigationStore modalNavigationStore, MotorsportDriversViewModel motorsportDriversViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            MotorsportDriversViewModel = motorsportDriversViewModel;

            _modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;

            // TODO - Delete this hardcoded line: _modalNavigationStore.CurrentViewModel = new AddMotorsportDriverViewModel(); //
        }

        protected override void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= ModalNavigationStore_CurrentViewModelChanged;
            base.Dispose();
        }

        private void ModalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
