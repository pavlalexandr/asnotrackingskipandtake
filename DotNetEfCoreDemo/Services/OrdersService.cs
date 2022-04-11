using DotNetEfCoreDemo.Domain;
using DotNetEfCoreDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetEfCoreDemo.Services
{
    public class OrdersService
    {
        private readonly EfCoreDemoDbContext _efCoreDemoDbContext;

        public OrdersService(EfCoreDemoDbContext efCoreDemoDbContext)
        {
            _efCoreDemoDbContext = efCoreDemoDbContext;
        }

        public async Task<List<Order>> SearchOrders(string name, int skip, int take)
        {
            return await _efCoreDemoDbContext.Order.AsNoTracking().Where(c => c.Name.Contains(name)).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<List<Order>> SearchOrdersOrdered(string name, int skip, int take)
        {
            return await _efCoreDemoDbContext.Order.AsNoTracking().OrderBy(o => o.CreatedDate).Where(c => c.Name.Contains(name)).Skip(skip).Take(take).ToListAsync();
        }
    }
}
