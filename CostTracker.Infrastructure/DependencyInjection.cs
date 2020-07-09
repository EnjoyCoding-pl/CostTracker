using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CostTracker.Core.Interfaces;
using CostTracker.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using CostTracker.Infrastructure.FileManager;

namespace CostTracker.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddCostTrackerInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<ApplicationDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("MainDatabase"), builder => builder.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)); });
            services.AddScoped<IApplicationDBContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddOptions<BlobStorageOptions>().Configure(options => configuration.GetSection(BlobStorageOptions.Section).Bind(options));
            services.AddScoped<IFileManager, BlobStorageFileManager>();
        }
    }
}