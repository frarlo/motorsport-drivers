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
        public event Action<MotorsportDriver> MotorsportDriverDeletedEvent;

        public SelectedMotorsportDriverStore(MotorsportDriversStore motorsportDriversStore)
        {
            _motorsportDriversStore = motorsportDriversStore;

            _motorsportDriversStore.MotorsportDriverUpdatedEvent += _motorsportDriversStore_MotorsportDriverUpdatedEvent;
            _motorsportDriversStore.MotorsportDriverCreatedEvent += _motorsportDriversStore_MotorsportDriverCreatedEvent;
            _motorsportDriversStore.MotorsportDriverDeletedEvent += _motorsportDriversStore_MotorsportDriverDeletedEvent;
        }

        private void _motorsportDriversStore_MotorsportDriverDeletedEvent(Guid motorsportDriverId)
        {

            if (SelectedMotorsportDriver != null && motorsportDriverId == SelectedMotorsportDriver.Id)
            {
                SelectedMotorsportDriver = null;
            }
        }

        private void _motorsportDriversStore_MotorsportDriverCreatedEvent(MotorsportDriver motorsportDriver)
        {
            SelectedMotorsportDriver = motorsportDriver;
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
