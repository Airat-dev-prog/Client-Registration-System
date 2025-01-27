using CRS.Offer.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace CRS.Offer.Infrastructure.Data
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Office> Offices { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<MasterService> MasterServices { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Master>()
                .HasOne<Office>(m => m.Office)
                .WithMany(o => o.Masters);

            modelBuilder.Entity<Service>()
                .HasOne<Office>(s => s.Office)
                .WithMany(o => o.Services);

            modelBuilder.Entity<Schedule>()
                .HasOne<Office>(s => s.Office)
                .WithMany(o => o.Schedules);

            modelBuilder.Entity<Schedule>()
                .HasOne<Master>(m => m.Master)
                .WithMany(m => m.Schedules);

            modelBuilder.Entity<MasterService>()
                .HasKey(ms => new { ms.MasterId, ms.ServiceId });
            modelBuilder.Entity<MasterService>()
                .HasOne<Master>(ms => ms.Master)
                .WithMany(m => m.MasterService);
            modelBuilder.Entity<MasterService>()
                .HasOne<Service>(ms => ms.Service)
                .WithMany(s => s.MasterService);

        }
    }
}
