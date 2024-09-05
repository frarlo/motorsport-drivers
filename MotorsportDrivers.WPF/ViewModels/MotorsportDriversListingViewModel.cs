using MotorsportDrivers.WPF.Models;
using MotorsportDrivers.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public MotorsportDriversListingViewModel(SelectedMotorsportDriverStore selectedMotorsportDriverStore) {

            _motorsportDriversListingItemViewModels = new ObservableCollection<MotorsportDriversListingItemViewModel>();

            _motorsportDriversListingItemViewModels.Add(new MotorsportDriversListingItemViewModel(new MotorsportDriver("Ayrton Senna",true,"Brazil")));
            _motorsportDriversListingItemViewModels.Add(new MotorsportDriversListingItemViewModel(new MotorsportDriver("Mika Hakkinen", true, "Finland")));
            _motorsportDriversListingItemViewModels.Add(new MotorsportDriversListingItemViewModel(new MotorsportDriver("Fernando Alonso", true, "Spain")));
            _motorsportDriversListingItemViewModels.Add(new MotorsportDriversListingItemViewModel(new MotorsportDriver("Nico Hulkenberg", false, "Germany")));

            this._selectedMotorsportDriverStore = selectedMotorsportDriverStore;
        }

    }
}
