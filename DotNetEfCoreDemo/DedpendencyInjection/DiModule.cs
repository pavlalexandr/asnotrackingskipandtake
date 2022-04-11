using DotNetEfCoreDemo.Domain;
using DotNetEfCoreDemo.Services;
using DotNetEfCoreDemo.Services.HangfireJobs;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.EntityFrameworkCore;

namespace DotNetEfCoreDemo.DedpendencyInjection
{
    public static class DiModule
    {
        public static IServiceCollection AddDIModule(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddLogging(config =>
                {
                    config.AddConsole();
                })                
                .AddDbContextFactory<EfCoreDemoDbContext>(options => options.UseSqlServer(configuration.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection")))
                .AddDbContext<EfCoreDemoDbContext>(options => options.UseSqlServer(configuration.GetSection("ConnectionStrings").GetValue<string>("DefaultConnection")))
                .AddSingleton<StatefullService>()
                .AddScoped<AddNewOrderJob>()
                .AddScoped<OrdersService>()
                .AddSingleton<DisplayOrdersCountJob>()
                // Add Hangfire services.
                .AddHangfire(configuration => configuration
                .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                .UseSimpleAssemblyNameTypeSerializer()
                .UseRecommendedSerializerSettings()
                .UseMemoryStorage())
                .AddHangfireServer();
        }
    }
}
