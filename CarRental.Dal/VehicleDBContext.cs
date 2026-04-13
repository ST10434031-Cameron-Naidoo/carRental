using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace CarRental.Dal
{
    public class VehicleDBContext: DbContext
    {
            public DbSet<Vehicle> Vehicles { get; set; }
            
            public DbSet<Customer> Customers { get; set; }
            public VehicleDBContext(DbContextOptions<VehicleDBContext> options)
            : base(options)
            {
            }
        }
    }
