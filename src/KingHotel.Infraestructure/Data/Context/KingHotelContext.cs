using KingHotel.Domain.Entity;
using KingHotel.Infraestructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KingHotel.Infraestructure.Data.Context
{
    public class KingHotelContext : DbContext
    {
        public KingHotelContext(DbContextOptions<KingHotelContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
