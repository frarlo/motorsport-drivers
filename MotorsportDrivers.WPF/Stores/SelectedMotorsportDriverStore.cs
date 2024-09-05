using MotorsportDrivers.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.Stores
{
    public class SelectedMotorsportDriverStore
    {
        private MotorsportDriver _selectedMotorsportDriver;

        public MotorsportDriver SelectedMotorsportDriver
        {
            get
            {
                return _selectedMotorsportDriver;
            }

            set
            {
                _selectedMotorsportDriver = value;
                SelectedMotorsportDriverChanged?.Invoke();
            }
        }

        public event Action SelectedMotorsportDriverChanged;

    }
}
