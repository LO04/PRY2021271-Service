using Montrac.API.Persistence;

namespace Montrac.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            using (var context = scope.ServiceProvider.GetRequiredService<MontracDbContext>())
            {
                context.Database.EnsureCreated();
            }
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}