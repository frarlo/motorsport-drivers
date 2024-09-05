using MotorsportDrivers.WPF.Models;
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
        public MotorsportDriver MotorsportDriver { get; }

        public string Name => MotorsportDriver.Name;

        public ICommand EditCommand { get; }

        public ICommand DeleteCommand { get; }

        public MotorsportDriversListingItemViewModel(MotorsportDriver motorsportDriver)
        {
            MotorsportDriver = motorsportDriver;
        }
    }
}
