using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.EntityFramework.DTOs
{
    public class MotorsportDriverDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsWorldChampion { get; set; }
        public string Country { get; set; }


    }
}
