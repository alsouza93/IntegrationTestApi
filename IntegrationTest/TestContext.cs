using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace IntegrationTest
{
    public static class TestContext
    {      
        public static void SwapTransient<TService, TImplementation>(this IServiceCollection services)
        where TImplementation : class, TService
        {
            if (services.Any(x => x.ServiceType == typeof(TService) && x.Lifetime == ServiceLifetime.Transient))
            {
                var serviceDescriptors = services.Where(x => x.ServiceType == typeof(TService) &&
                x.Lifetime == ServiceLifetime.Transient).ToList();
                foreach (var serviceDescriptor in serviceDescriptors)
                {
                    services.Remove(serviceDescriptor);
                }
            }

            services.AddTransient(typeof(TService), typeof(TImplementation));
        }
    }
}