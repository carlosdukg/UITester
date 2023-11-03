using Microsoft.Extensions.DependencyInjection;
using UINavigator.Contracts;
using UINavigator.Services;
using UltiProTests.Contracts;
using UltiProTests.Services;

namespace UltiProTests
{
    public  class TestServiceProvider
    {
        public static T GetService<T>() where T : notnull 
        {
            var serviceProvider = Provider();

            return serviceProvider.GetRequiredService<T>();
        }
        private static IServiceProvider Provider()
        {
            var services = new ServiceCollection();
            var chormeDriver = new ChromeWebDriverService();
            var driver = chormeDriver.GetDriver();

            services
                .AddMemoryCache()
                .AddSingleton(driver)
                .AddScoped<IMemCacheService, MemCacheService>()
                .AddScoped<ICustomerSelectorService, CustomerSelectorService>()
                .AddScoped<ILoginService, LoginService>()
                .AddScoped<INavigationService, NavigationService>()
                .AddScoped<ITestUtilitiesService, TestUtilitiesService>()
                .AddScoped<ITestMethodsService, TestMethodsService>()
                .AddScoped<IValidationsService, ValidationsService>()
                .AddScoped<ITestHelperService, TestHelperService>();

            var serviceProvider = services.BuildServiceProvider();

            return serviceProvider;
        }
   
    }
}
