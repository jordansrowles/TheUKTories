using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheUKTories.Services.Data.EFCore.Models;

namespace TheUKTories.Services.Data.EFCore
{
    public class SqlServerDataCache
    {
        private readonly SqlServerDataContext context;
        private readonly ILogger<SqlServerDataCache> logger;
        private readonly IMemoryCache cache;

        public SqlServerDataCache(SqlServerDataContext context, ILogger<SqlServerDataCache> logger, IMemoryCache cache)
        {
            this.context = context;
            this.logger = logger;
            this.cache = cache;
        }

        public async Task<IList<UKAusterityMeasure>> UKAusterityMeasuresCachedAllAsync()
        {
            if (this.cache.TryGetValue("austerity_all", out IList<UKAusterityMeasure> measureList))
            {
                logger.LogInformation("Cache hit: auserity_all");
                return measureList;
            }
            measureList = await context.UKAusterityMeasures.Include(i => i.SourceItems).ToListAsync(); // todo is the include too much? will we have memory issues?
            cache.Set("austerity_all", measureList);
            logger.LogInformation("Cache data not found, repopulated: austerity_all");
            return measureList;
        }

        public async Task<IList<T>> GetListAsync<T>(string key)
        {
            if (this.cache.TryGetValue(key, out IList<T> measureList))
            {
                logger.LogInformation($"Cache hit: {key}");
                return measureList;
            }
            measureList = null;// await context.UKAusterityMeasures.Include(i => i.SourceItems).ToListAsync(); // todo is the include too much? will we have memory issues?
            cache.Set(key, measureList);
            logger.LogInformation($"Cache data not found, repopulated: {key}");
            return measureList;
        }
    }
}
