using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FishStore.Models;

namespace FishStore.Models
{
    public class FishDbContext : DbContext
    {
        public FishDbContext (DbContextOptions<FishDbContext> options)
            : base(options)
        {
        }

        public DbSet<Fish> Fishs{ get; set; }
        public DbSet<FishStore.Models.Fish> Fish { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
