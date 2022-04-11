using DotNetEfCoreDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetEfCoreDemo.Domain
{
    public class EfCoreDemoDbContext : DbContext
    {
        public EfCoreDemoDbContext(DbContextOptions<EfCoreDemoDbContext> options) : base(options)
        {

        }

        public DbSet<Order> Order { get; set; }
    }
}
