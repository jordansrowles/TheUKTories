using EasyCaching.Core;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheUKTories.Services
{
    public static class CacheServiceProvider
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddEasyCaching(options =>
                options.UseSQLite(config =>
                {
                    config.DBConfig = new EasyCaching.SQLite.SQLiteDBOptions
                    {
                        FileName = "cache.db"
                    };
                }));
            return services;
        }       
    }
    public class CacheService
    {
        private readonly IEasyCachingProvider cache;

        public CacheService(IEasyCachingProvider cache)
        {
            this.cache = cache;
        }

    }
}
