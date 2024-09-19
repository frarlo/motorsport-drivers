using MotorsportDrivers.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.Stores
{
    public class SelectedMotorsportDriverStore
    {
        private readonly MotorsportDriversStore _motorsportDriversStore;

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

        public SelectedMotorsportDriverStore(MotorsportDriversStore motorsportDriversStore)
        {
            _motorsportDriversStore = motorsportDriversStore;

            _motorsportDriversStore.MotorsportDriverUpdatedEvent += _motorsportDriversStore_MotorsportDriverUpdatedEvent;
        }

        private void _motorsportDriversStore_MotorsportDriverUpdatedEvent(MotorsportDriver motorsportDriver)
        {
            if (motorsportDriver.Id == SelectedMotorsportDriver?.Id)
            {
                SelectedMotorsportDriver = motorsportDriver;
            }
        }
    }
}
