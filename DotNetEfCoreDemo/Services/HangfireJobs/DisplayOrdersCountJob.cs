namespace DotNetEfCoreDemo.Services.HangfireJobs
{
    public class DisplayOrdersCountJob
    {
        private readonly StatefullService _statefullService;
        private readonly ILogger<AddNewOrderJob> _logger;
        public DisplayOrdersCountJob(StatefullService statefullService, ILogger<AddNewOrderJob> logger)
        {
            _statefullService = statefullService;
            _logger = logger;
        }

        public async Task Start()
        {
            var asNoTrackingCount = await _statefullService.GetAsNoTrackingOrdersCount();
            var withoutAsNoTrackingCount = await _statefullService.GetOrdersCount();
            var factoryAsNoTrackingCount = await _statefullService.GetFactoryAsNoTrackingOrdersCount();
            var facotoryWithoutAsNoTrackingCount = await _statefullService.GetFactoryOrdersCount();
            _logger.LogWarning("Orders count: Scoped AsNoTracking-{0}, Scoped WithoutAsNotTracking-{1}, Factory AsNoTracking-{2}, Factory WithoutAsNotTracking-{3}", asNoTrackingCount, withoutAsNoTrackingCount, factoryAsNoTrackingCount, facotoryWithoutAsNoTrackingCount);
        }
    }
}
