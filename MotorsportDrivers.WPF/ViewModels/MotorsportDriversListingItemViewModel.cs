using MotorsportDrivers.WPF.Commands;
using MotorsportDrivers.Domain.Models;
using MotorsportDrivers.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class MotorsportDriversListingItemViewModel : ViewModelBase
    {
        public MotorsportDriver MotorsportDriver { get; private set; }

        public string Name => MotorsportDriver.Name;

        private bool _isDeleting;

        public bool IsDeleting
        {
            get
            {
                return _isDeleting;
            }
            set
            {
                _isDeleting = value;
                OnPropertyChanged(nameof(IsDeleting));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);

        public ICommand EditCommand { get; }

        public ICommand DeleteCommand { get; }

        public MotorsportDriversListingItemViewModel(MotorsportDriver motorsportDriver, MotorsportDriversStore motorsportDriversStore, ModalNavigationStore modalNavigationStore)
        {
            MotorsportDriver = motorsportDriver;

            EditCommand = new OpenEditMotorsportDriverCommand(this, motorsportDriversStore, modalNavigationStore);
            DeleteCommand = new DeleteMotorsportDriverCommand(this, motorsportDriversStore);
        }

        public void Update(MotorsportDriver motorsportDriver)
        {
            MotorsportDriver = motorsportDriver;

            OnPropertyChanged(nameof(Name));
        }
    }
}
