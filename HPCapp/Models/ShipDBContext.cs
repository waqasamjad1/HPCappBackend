using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HPCapp.Models
{
    public class ShipDBContext: DbContext
    {
        public ShipDBContext(DbContextOptions<ShipDBContext> options): base(options)
        {

        }

        public DbSet<ShipDetail> ShipDetails { get; set; }
    }
}
