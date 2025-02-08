using CRS.Centrum.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Data;

namespace CRS.Centrum.Infrastructure.Data
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

            modelBuilder.Entity<Client>()
                .HasOne<Office>(c => c.Office)
                .WithMany(o => o.Clients);

            modelBuilder.Entity<Appointment>()
                .HasOne<Office>(a => a.Office)
                .WithMany(o => o.Appointments);

            modelBuilder.Entity<Appointment>()
                .HasOne<Master>(a => a.Master)
                .WithMany(m => m.Appointments);

            modelBuilder.Entity<Schedule>()
                .HasOne<Master>(s => s.Master)
                .WithMany(m => m.Schedules);

            modelBuilder.Entity<Appointment>()
                .HasOne<Client>(a => a.Client)
                .WithMany(c => c.Appointments);

            modelBuilder.Entity<Appointment>()
                .HasOne<Service>(a => a.Service)
                .WithMany(s => s.Appointments);

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
