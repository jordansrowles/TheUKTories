using Microsoft.EntityFrameworkCore;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.Services.Data.EFCore
{
    public class CosmosEFCoreContext : DbContext
    {
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<FacistTactic>? FacistTactics { get; set; }
        public DbSet<UKAusterityMeasure>? UKAusterityMeasures { get; set; }

        public CosmosEFCoreContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseCosmos(Globals.TryGetConnectionString(), 
                "theuktoriesdb");
        }
 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Contact>().ToContainer("Contacts")
                .HasPartitionKey(i => i.Id)
                .HasKey(i => i.Id);

            builder.Entity<FacistTactic>().ToContainer("FacistTactics")
                .HasPartitionKey(i => i.Id)
                .HasKey(i => i.Id);

            builder.Entity<UKAusterityMeasure>().ToContainer("UKAusterity")
                .HasPartitionKey(i => i.Type)
                .HasKey(i => i.Id);
            builder.Entity<UKAusterityMeasure>().Property(i => i.Type).HasConversion<string>();
        }
    }
}
