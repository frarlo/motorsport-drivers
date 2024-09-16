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

        public bool CanSubmit => !string.IsNullOrEmpty(Name);

        public ICommand SubmitCommand { get; }

        public ICommand CancelCommand { get; }
    }
}
