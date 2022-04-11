using DotNetEfCoreDemo.Domain;

namespace DotNetEfCoreDemo.Services.HangfireJobs
{
    public class AddNewOrderJob
    {
        private readonly EfCoreDemoDbContext _efCoreDemoDbContext;

        public AddNewOrderJob(EfCoreDemoDbContext efCoreDemoDbContext)
        {
            _efCoreDemoDbContext = efCoreDemoDbContext;
        }

        public async Task Start()
        {
            var value = Random.Shared.Next();
            var price = Random.Shared.NextDouble();

            _efCoreDemoDbContext.Order.Add(new Domain.Entities.Order()
            {
                CreatedDate = DateTime.Now,
                Name = $"NewName {value}",
                Price = (decimal)price
            });

            await _efCoreDemoDbContext.SaveChangesAsync();
        }
    }
}
