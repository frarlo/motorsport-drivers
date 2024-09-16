using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class EditMotorsportDriverViewModel : ViewModelBase
    {
        public MotorsportDriverDetailsFormViewModel MotorsportDriverDetailsFormViewModel { get; }

        public EditMotorsportDriverViewModel()
        {
            MotorsportDriverDetailsFormViewModel = new MotorsportDriverDetailsFormViewModel();
        }
    }
}
