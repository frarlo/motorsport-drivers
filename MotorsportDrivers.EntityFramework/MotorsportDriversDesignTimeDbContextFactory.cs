using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.EntityFramework
{
    public class MotorsportDriversDesignTimeDbContextFactory : IDesignTimeDbContextFactory<MotorsportDriversDbContext>
    {
        public MotorsportDriversDbContext CreateDbContext(string[] args = null)
        {
            return new MotorsportDriversDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=MotorsportDrivers.db").Options);
        }
    }
}
