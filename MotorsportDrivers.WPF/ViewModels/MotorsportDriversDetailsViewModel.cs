using MotorsportDrivers.Domain.Models;
using MotorsportDrivers.WPF.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.ViewModels
{
    public class MotorsportDriversDetailsViewModel : ViewModelBase
    {
        private readonly SelectedMotorsportDriverStore _selectedMotorsportDriverStore;
        private MotorsportDriver SelectedMotorsportDriver => _selectedMotorsportDriverStore.SelectedMotorsportDriver;

        public bool HasSelectedMotorsportDriver => SelectedMotorsportDriver != null;
        public string Name => SelectedMotorsportDriver?.Name ?? "Unknown";
        public string IsWorldChampionDisplay => (SelectedMotorsportDriver?.IsWorldChampion ?? false) ? "Yes" : "No";
        public string Country => SelectedMotorsportDriver?.Country ?? "Unknown";

        public MotorsportDriversDetailsViewModel(SelectedMotorsportDriverStore selectedMotorsportDriverStore)
        {
            _selectedMotorsportDriverStore = selectedMotorsportDriverStore;

            _selectedMotorsportDriverStore.SelectedMotorsportDriverChanged += SelectedMotorsportDriverStore_SelectedMotorsportDriverChanged;
        }

        protected override void Dispose()
        {
            _selectedMotorsportDriverStore.SelectedMotorsportDriverChanged -= SelectedMotorsportDriverStore_SelectedMotorsportDriverChanged;

            base.Dispose();
        }

        private void SelectedMotorsportDriverStore_SelectedMotorsportDriverChanged()
        {
            OnPropertyChanged(nameof(HasSelectedMotorsportDriver));
            OnPropertyChanged(nameof(Name));
            OnPropertyChanged(nameof(IsWorldChampionDisplay));
            OnPropertyChanged(nameof(Country));
        }

    }
}
