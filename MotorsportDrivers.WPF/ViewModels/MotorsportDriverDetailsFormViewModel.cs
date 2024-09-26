using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class MotorsportDriverDetailsFormViewModel : ViewModelBase
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private bool _isWorldChampion;
        public bool IsWorldChampion
        {
            get
            {
                return _isWorldChampion;
            }
            set
            {
                _isWorldChampion = value;
                OnPropertyChanged(nameof(IsWorldChampion));
            }
        }

        private string _country;
        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }

        private bool _isSubmitting;
        public bool IsSubmitting
        {
            get
            {
                return _isSubmitting;
            }

            set
            {
                _isSubmitting = value;
                OnPropertyChanged(nameof(IsSubmitting));
            }
        }

        public bool CanSubmit => !string.IsNullOrEmpty(Name);

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

        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }

        public MotorsportDriverDetailsFormViewModel(ICommand submitCommand, ICommand cancelCommand)
        {
            SubmitCommand = submitCommand;
            CancelCommand = cancelCommand;
        }

    }
}
