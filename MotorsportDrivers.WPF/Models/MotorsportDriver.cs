using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.Models
{
    public class MotorsportDriver
    {
        public Guid Id { get; }
        public string Name { get; }
        public bool IsWorldChampion { get; }
        public string Country { get; }

        public MotorsportDriver(Guid id, string name, bool isWorldChampion, string country)
        {
            Id = id;
            Name = name;
            IsWorldChampion = isWorldChampion;
            Country = country;
        }

    }
}
