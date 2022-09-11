using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
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
        public DbSet<Quote>? Quotes { get; set; }
        public DbSet<PersonGeneral>? PeopleGeneral { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options
                .UseSqlServer(Globals.TryGetConnectionString(Globals.ExpressConnectionString));

            options.LogTo(Console.WriteLine).EnableDetailedErrors().EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }

    public class CachedDataContext : SqlServerDataContext
    {
        IMemoryCache _cache;

        public CachedDataContext(IMemoryCache cache)
        {
            _cache = cache;
        }

        public async Task<PaginatedList<UKAusterityMeasure>> GetPagedAusterity(int? pageIndex, int pageSize)
        {
            if (!_cache.TryGetValue("item", out var x))
            {

            }

            IQueryable<UKAusterityMeasure> items = from i in base.UKAusterityMeasures select i;
            var list = await PaginatedList<UKAusterityMeasure>.CreateAsync(items.AsNoTracking().Include(i => i.SourceItems),
                pageIndex ?? 1, pageSize);
            return list;
        }
    }
}
