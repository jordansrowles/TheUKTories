using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TheUKTories.Services.Data.EFCore.Models;
using TheUKTories.Services.Data.EFCore.Models.Covid;
using TheUKTories.Services.Data.EFCore.Models.People;

namespace TheUKTories.Services.Data.EFCore
{
    public class SqlServerDataContext : DbContext
    {
        public DbSet<Contact>? Contacts { get; set; }
        public DbSet<FacistTactic>? FacistTactics { get; set; }
        // UK.Austerity
        public DbSet<UKAusterityMeasure>? UKAusterityMeasures { get; set; }
        public DbSet<UKAusterityMeasureSource>? UKAusterityMeasuresSources { get; set; }
        // UK.Covid
        public DbSet<CovidGovResponse>? CovidGovResponses { get; set; }
        public DbSet<CovidGovResponseSource>? CovidGovResponseSources { get; set; }
        public DbSet<GovPPEContract>? CovidGovContracts { get; set; }
        public DbSet<GovPPEContractCompany>? CovidGovContractCompanies { get; set; }
        // People
        public DbSet<Person>? People { get; set; }
        public DbSet<PersonQuote>? PeopleQuotes { get; set; }
        public DbSet<PersonGeneral>? PeopleGeneral { get; set; }
        public DbSet<PersonQuoteSource>? PersonQuoteSources { get; set; }
        public DbSet<PersonGeneralSource>? PersonGeneralSources { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseSqlServer(Globals.TryGetConnectionString(Globals.ConnectionString));

            options.LogTo(Console.WriteLine).EnableDetailedErrors().EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var person_titles_converter = new ValueConverter<string[], string>(
                v => string.Join(";", v),
                v => v.Split(";", StringSplitOptions.RemoveEmptyEntries).ToArray());

            builder.Entity<Person>()
                .Property(i => i.Titles).HasConversion(person_titles_converter);
        }
    }
}
