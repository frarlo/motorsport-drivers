using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.EntityFramework
{
    public class MotorsportDriversDbContextFactory
    {
        
        private readonly DbContextOptions _options;

        public MotorsportDriversDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public MotorsportDriversDbContext Create()
        {
            return new MotorsportDriversDbContext(_options);
        }
    }
}
