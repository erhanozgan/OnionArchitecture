using Microsoft.Extensions.DependencyInjection;
using OA.Application;
using OA.Persistence;

namespace OA.Test
{
    [SetUpFixture]
    public class Startup
    {
        internal static IServiceProvider ServiceProvider { get; set; }

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            ServiceProvider = ContainerBuilder();
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {

        }

        public IServiceProvider ContainerBuilder()
        {
            var services = new ServiceCollection();
            services.AddApplicationRegistration();
            services.AddPersistenceRegistration(null);
            return services.BuildServiceProvider();
        }
    }
}
