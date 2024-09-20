﻿using MotorsportDrivers.WPF.Commands;
using MotorsportDrivers.Domain.Models;
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
        private readonly MotorsportDriversStore _motorsportDriversStore;
        private readonly SelectedMotorsportDriverStore _selectedMotorsportDriverStore;
        private readonly ModalNavigationStore _modalNavigationStore;
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

        public ICommand LoadMotorsportDriversCommand { get; }

        public MotorsportDriversListingViewModel(
            MotorsportDriversStore motorsportDriversStore,
            SelectedMotorsportDriverStore selectedMotorsportDriverStore,
            ModalNavigationStore modalNavigationStore) {

            _motorsportDriversStore = motorsportDriversStore;
            _selectedMotorsportDriverStore = selectedMotorsportDriverStore;
            _modalNavigationStore = modalNavigationStore;
            _motorsportDriversListingItemViewModels = new ObservableCollection<MotorsportDriversListingItemViewModel>();

            LoadMotorsportDriversCommand = new LoadMotorsportDriversCommand(motorsportDriversStore);


            _motorsportDriversStore.MotorsportDriversLoadedEvent += MotorsportDriversStore_MotorsportDriversLoadedEvent;
            _motorsportDriversStore.MotorsportDriverCreatedEvent += MotorsportDriversStore_MotorsportDriverCreatedEvent;
            _motorsportDriversStore.MotorsportDriverUpdatedEvent += MotorsportDriversStore_MotorsportDriverUpdatedEvent;
            _motorsportDriversStore.MotorsportDriverDeletedEvent += MotorsportDriversStore_MotorsportDriverDeletedEvent;

        }


        private void MotorsportDriversStore_MotorsportDriversLoadedEvent()
        {
            _motorsportDriversListingItemViewModels.Clear();

            foreach(MotorsportDriver motorsportDriver in _motorsportDriversStore.MotorsportDrivers)
            {
                CreateMotorsportDriver(motorsportDriver);
            }
        }

        public static MotorsportDriversListingViewModel LoadViewModel(
            MotorsportDriversStore motorsportDriversStore,
            SelectedMotorsportDriverStore selectedMotorsportDriverStore,
            ModalNavigationStore modalNavigationStore)
        {
            MotorsportDriversListingViewModel viewModel = new MotorsportDriversListingViewModel(motorsportDriversStore, selectedMotorsportDriverStore, modalNavigationStore);

            viewModel.LoadMotorsportDriversCommand.Execute(null);

            return viewModel;
        }

        protected override void Dispose()
        {

            _motorsportDriversStore.MotorsportDriversLoadedEvent -= MotorsportDriversStore_MotorsportDriversLoadedEvent;
            _motorsportDriversStore.MotorsportDriverCreatedEvent -= MotorsportDriversStore_MotorsportDriverCreatedEvent;
            _motorsportDriversStore.MotorsportDriverUpdatedEvent -= MotorsportDriversStore_MotorsportDriverUpdatedEvent;
            _motorsportDriversStore.MotorsportDriverDeletedEvent -= MotorsportDriversStore_MotorsportDriverDeletedEvent;

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

    }
}
