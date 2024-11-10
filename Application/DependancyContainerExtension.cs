using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependancyContainerExtension
    {


        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection service)
        {

            return service;
        }
    }
}
