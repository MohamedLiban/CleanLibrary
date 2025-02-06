using CleanLibrary.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CleanLibrary.Test.Setup
{
    public static class TestDatabaseSetup
    {
        public static ServiceProvider InitializeTestDatabase()
        {
            var services = new ServiceCollection();

            services.AddDbContext<RealDatabase>(options =>
                options.UseInMemoryDatabase("TestDatabase"));

            return services.BuildServiceProvider();
        }
    }
}
