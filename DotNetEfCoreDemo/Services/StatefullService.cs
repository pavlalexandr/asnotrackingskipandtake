using DotNetEfCoreDemo.Domain;
using Microsoft.EntityFrameworkCore;

namespace DotNetEfCoreDemo.Services
{
    public class StatefullService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IDbContextFactory<EfCoreDemoDbContext> _dbContextFactory;

        public StatefullService(IServiceProvider serviceProvider, IDbContextFactory<EfCoreDemoDbContext> dbContextFactory)
        {
            _serviceProvider = serviceProvider;
            _dbContextFactory = dbContextFactory;
        }

        public async Task<int> GetAsNoTrackingOrdersCount()
        {
            using var scope = _serviceProvider.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<EfCoreDemoDbContext>();
            return await dbContext.Order.AsNoTracking().CountAsync();
        }

        public async Task<int> GetOrdersCount()
        {
            using var scope = _serviceProvider.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<EfCoreDemoDbContext>();
            return await dbContext.Order.CountAsync();
        }

        public async Task<int> GetFactoryAsNoTrackingOrdersCount()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.Order.AsNoTracking().CountAsync();
        }

        public async Task<int> GetFactoryOrdersCount()
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            return await dbContext.Order.CountAsync();
        }
    }
}
