using Microsoft.EntityFrameworkCore;
using MotorsportDrivers.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.EntityFramework
{
    public class MotorsportDriversDbContext : DbContext
    {

        public MotorsportDriversDbContext(DbContextOptions options) : base(options) { }

        public DbSet<MotorsportDriverDto>  MotorsportDrivers { get; set; } 


    }
}
