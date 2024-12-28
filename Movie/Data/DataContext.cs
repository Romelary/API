using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace Movie.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
            
        }
        public DbSet<CMovie> TMovie {get;set; }
    }
}