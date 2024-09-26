using MotorsportDrivers.WPF.Commands;
using MotorsportDrivers.Domain.Models;
using MotorsportDrivers.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.Specialized;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class MotorsportDriversListingViewModel : ViewModelBase
    {
        private readonly MotorsportDriversStore _motorsportDriversStore;
        private readonly SelectedMotorsportDriverStore _selectedMotorsportDriverStore;
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly ObservableCollection<MotorsportDriversListingItemViewModel> _motorsportDriversListingItemViewModels;

        public IEnumerable<MotorsportDriversListingItemViewModel> MotorsportDriversListingItemViewModels => _motorsportDriversListingItemViewModels;

        public MotorsportDriversListingItemViewModel SelectedMotorsportDriverListingItemViewModel
        {
            get
            {
                return _motorsportDriversListingItemViewModels.
                    FirstOrDefault(d => d.MotorsportDriver?.Id == _selectedMotorsportDriverStore.SelectedMotorsportDriver?.Id);
            }
            set
            {
                _selectedMotorsportDriverStore.SelectedMotorsportDriver = value?.MotorsportDriver;
            }
        }

        public MotorsportDriversListingViewModel(
            MotorsportDriversStore motorsportDriversStore,
            SelectedMotorsportDriverStore selectedMotorsportDriverStore,
            ModalNavigationStore modalNavigationStore) {

            _motorsportDriversStore = motorsportDriversStore;
            _selectedMotorsportDriverStore = selectedMotorsportDriverStore;
            _modalNavigationStore = modalNavigationStore;
            _motorsportDriversListingItemViewModels = new ObservableCollection<MotorsportDriversListingItemViewModel>();

            _selectedMotorsportDriverStore.SelectedMotorsportDriverChanged += _selectedMotorsportDriverStore_SelectedMotorsportDriverChanged;
            _motorsportDriversStore.MotorsportDriversLoadedEvent += MotorsportDriversStore_MotorsportDriversLoadedEvent;
            _motorsportDriversStore.MotorsportDriverCreatedEvent += MotorsportDriversStore_MotorsportDriverCreatedEvent;
            _motorsportDriversStore.MotorsportDriverUpdatedEvent += MotorsportDriversStore_MotorsportDriverUpdatedEvent;
            _motorsportDriversStore.MotorsportDriverDeletedEvent += MotorsportDriversStore_MotorsportDriverDeletedEvent;
            _motorsportDriversListingItemViewModels.CollectionChanged += _motorsportDriversListingItemViewModels_CollectionChanged;
        }

        private void MotorsportDriversStore_MotorsportDriversLoadedEvent()
        {
            _motorsportDriversListingItemViewModels.Clear();

            foreach(MotorsportDriver motorsportDriver in _motorsportDriversStore.MotorsportDrivers)
            {
                CreateMotorsportDriver(motorsportDriver);
            }
        }

        protected override void Dispose()
        {
            _motorsportDriversStore.MotorsportDriversLoadedEvent -= MotorsportDriversStore_MotorsportDriversLoadedEvent;
            _motorsportDriversStore.MotorsportDriverCreatedEvent -= MotorsportDriversStore_MotorsportDriverCreatedEvent;
            _motorsportDriversStore.MotorsportDriverUpdatedEvent -= MotorsportDriversStore_MotorsportDriverUpdatedEvent;
            _motorsportDriversStore.MotorsportDriverDeletedEvent -= MotorsportDriversStore_MotorsportDriverDeletedEvent;
            _selectedMotorsportDriverStore.SelectedMotorsportDriverChanged -= _selectedMotorsportDriverStore_SelectedMotorsportDriverChanged;
            _motorsportDriversListingItemViewModels.CollectionChanged -= _motorsportDriversListingItemViewModels_CollectionChanged;

            base.Dispose();
        }

        private void MotorsportDriversStore_MotorsportDriverCreatedEvent(MotorsportDriver motorsportDriver)
        {
            CreateMotorsportDriver(motorsportDriver);
        }

        private void CreateMotorsportDriver(MotorsportDriver motorsportDriver)
        {
            MotorsportDriversListingItemViewModel itemViewModel = new MotorsportDriversListingItemViewModel(motorsportDriver, _motorsportDriversStore, _modalNavigationStore);

            _motorsportDriversListingItemViewModels.Add(itemViewModel);
        }

        private void MotorsportDriversStore_MotorsportDriverUpdatedEvent(MotorsportDriver motorsportDriver)
        {
            MotorsportDriversListingItemViewModel motorsportDriverViewModel =
                _motorsportDriversListingItemViewModels.FirstOrDefault(d => d.MotorsportDriver.Id == motorsportDriver.Id);

            if (motorsportDriverViewModel != null)
            {
                motorsportDriverViewModel.Update(motorsportDriver);
            }
        }

        private void MotorsportDriversStore_MotorsportDriverDeletedEvent(Guid id)
        {
            MotorsportDriversListingItemViewModel itemViewModel =
                _motorsportDriversListingItemViewModels.FirstOrDefault(d => d.MotorsportDriver?.Id == id);

            if(itemViewModel != null)
            {
                _motorsportDriversListingItemViewModels.Remove(itemViewModel);
            }
        }

        private void _motorsportDriversListingItemViewModels_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedMotorsportDriverListingItemViewModel));
        }

        private void _selectedMotorsportDriverStore_SelectedMotorsportDriverChanged()
        {
            OnPropertyChanged(nameof(SelectedMotorsportDriverListingItemViewModel));
        }

    }
}
