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

        public string Name { get; set; }

        public ICommand EditCommand { get; }

        public ICommand DeleteCommand { get; }

        public MotorsportDriversListingItemViewModel(string name)
        {
            Name = name;
        }

    }
}
