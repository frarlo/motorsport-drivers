using MotorsportDrivers.WPF.Commands;
using MotorsportDrivers.WPF.Models;
using MotorsportDrivers.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class MotorsportDriversListingViewModel : ViewModelBase
    {

        private readonly SelectedMotorsportDriverStore _selectedMotorsportDriverStore;

        private readonly ObservableCollection<MotorsportDriversListingItemViewModel> _motorsportDriversListingItemViewModels;

        public IEnumerable<MotorsportDriversListingItemViewModel> MotorsportDriversListingItemViewModels => _motorsportDriversListingItemViewModels;

        private MotorsportDriversListingItemViewModel _selectedMotorsportDriverListingItemViewModel;

        public MotorsportDriversListingItemViewModel SelectedMotorsportDriverListingItemViewModel
        {
            get
            {
                return _selectedMotorsportDriverListingItemViewModel;
            }
            set
            {
                _selectedMotorsportDriverListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedMotorsportDriverListingItemViewModel));

                _selectedMotorsportDriverStore.SelectedMotorsportDriver = _selectedMotorsportDriverListingItemViewModel?.MotorsportDriver;
            }
        }

        public MotorsportDriversListingViewModel(SelectedMotorsportDriverStore selectedMotorsportDriverStore, ModalNavigationStore modalNavigationStore) {

            _motorsportDriversListingItemViewModels = new ObservableCollection<MotorsportDriversListingItemViewModel>();

            AddMotorsportDriver(new MotorsportDriver("Ayrton Senna",true,"Brazil"), modalNavigationStore);
            AddMotorsportDriver(new MotorsportDriver("Mika Hakkinen", true, "Finland"), modalNavigationStore);
            AddMotorsportDriver(new MotorsportDriver("Fernando Alonso", true, "Spain"), modalNavigationStore);
            AddMotorsportDriver(new MotorsportDriver("Nico Hulkenberg", false, "Germany"), modalNavigationStore);

            this._selectedMotorsportDriverStore = selectedMotorsportDriverStore;
        }

        // Temporary method:
        private void AddMotorsportDriver(MotorsportDriver motorsportDriver, ModalNavigationStore modalNavigationStore)
        {
            ICommand editCommand = new OpenEditMotrosportDriverCommand(motorsportDriver, modalNavigationStore);
            _motorsportDriversListingItemViewModels.Add(new MotorsportDriversListingItemViewModel(motorsportDriver, editCommand));
        }
    }
}
