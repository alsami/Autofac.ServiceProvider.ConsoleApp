using System;
using System.Diagnostics;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Autofac.ServiceProvider.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<ServiceCollectionClass>();
      
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ContainerBuilderClass>();
            
            // this transfers the registrations from `ServiceCollection` to the instance of `ContainerBuilder`
            containerBuilder.Populate(services);

            // build the container
            var container = containerBuilder.Build();

            // resolve the classes, would throw an exception if it was not possible
            var serviceCollectionService = container.Resolve<ServiceCollectionClass>();
            var containerBuilderService = container.Resolve<ContainerBuilderClass>();

            Console.WriteLine("Press any key to exit");
            Console.ReadKey(true);
        }
    }
}
