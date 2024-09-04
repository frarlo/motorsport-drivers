using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class MotorsportDriversDetailsViewModel : ViewModelBase
    {
        public string Name { get; }
    
        public string IsWorldChampionDisplay { get; }

        public string Country { get; }


        public MotorsportDriversDetailsViewModel()
        {
            Name = "Ayrton Senna da Silva";
            IsWorldChampionDisplay = "Yes";
            Country = "Brazil";
        }

    }
}
