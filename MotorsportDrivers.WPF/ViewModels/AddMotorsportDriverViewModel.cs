using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class AddMotorsportDriverViewModel : ViewModelBase
    {

        public MotorsportDriverDetailsFormViewModel MotorsportDriverDetailsFormViewModel { get; }

        public AddMotorsportDriverViewModel()
        {
            MotorsportDriverDetailsFormViewModel = new MotorsportDriverDetailsFormViewModel();
        }

    }
}
