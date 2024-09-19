
namespace MIcroinvestIO
{
    public class MicroinvestIOService : BackgroundService
    {
        public MicroinvestIOService(ILoggerFactory loggerFactory)
        {
            Logger = loggerFactory.CreateLogger<MicroinvestIOService>();

        }
        public ILogger Logger { get; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Logger.LogInformation("MicroinvestIOService is starting.");

            stoppingToken.Register(() => Logger.LogInformation("ServiceA is stopping."));

            while (!stoppingToken.IsCancellationRequested)
            {
                Logger.LogInformation("MicroinvestIOService is doing background work.");

                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }

            Logger.LogInformation("ServiceA has stopped.");
        }
    }
}
