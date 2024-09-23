using MotorsportDrivers.WPF.Commands;
using MotorsportDrivers.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class MotorsportDriversViewModel : ViewModelBase
    {

        public MotorsportDriversListingViewModel MotorsportDriversListingViewModel {  get; }

        public MotorsportDriversDetailsViewModel MotorsportDriversDetailsViewModel { get; }

        private bool _isLoading = false;

        public bool IsLoading
        {
            get
            {
                return _isLoading;
            }
            set
            {
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        public ICommand AddMotorsportDriversCommand { get; }

        public ICommand LoadMotorsportDriversCommand { get; }

        public MotorsportDriversViewModel(MotorsportDriversStore motorsportDriversStore, SelectedMotorsportDriverStore selectedMotorsportDriverStore, ModalNavigationStore modalNavigationStore)
        {
            MotorsportDriversListingViewModel = new MotorsportDriversListingViewModel(motorsportDriversStore, selectedMotorsportDriverStore, modalNavigationStore);

            MotorsportDriversDetailsViewModel = new MotorsportDriversDetailsViewModel(selectedMotorsportDriverStore);

            LoadMotorsportDriversCommand = new LoadMotorsportDriversCommand(this, motorsportDriversStore);
            AddMotorsportDriversCommand = new OpenAddMotorsportDriverCommand(motorsportDriversStore, modalNavigationStore);
        }

        public static MotorsportDriversViewModel LoadViewModel(
            MotorsportDriversStore motorsportDriversStore,
            SelectedMotorsportDriverStore selectedMotorsportDriverStore,
            ModalNavigationStore modalNavigationStore)
        {
            MotorsportDriversViewModel viewModel = new MotorsportDriversViewModel(motorsportDriversStore, selectedMotorsportDriverStore, modalNavigationStore);

            viewModel.LoadMotorsportDriversCommand.Execute(null);

            return viewModel;
        }

    
    }
}
