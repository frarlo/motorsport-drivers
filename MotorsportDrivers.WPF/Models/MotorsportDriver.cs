using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.Models
{
    public class MotorsportDriver
    {

        public string Name { get; }
        public bool IsWorldChampion { get; }
        public string Country { get; }

        public MotorsportDriver(string name, bool isWorldChampion, string country)
        {
            Name = name;
            IsWorldChampion = isWorldChampion;
            Country = country;
        }

    }
}
