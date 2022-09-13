using Application.DataAccess;
using Application.Services;
using Application.Services.Interfaces;
using Infrastructure.Persistance;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = CreateServiceProvider();

            //var clienteRepository = serviceProvider.GetRequiredService<IClienteRepository>();
            //var ordenRepository = serviceProvider.GetRequiredService<IOrdenRepository>();
            //var ordenService = serviceProvider.GetRequiredService<IOrdenService>();
            var clienteService = serviceProvider.GetRequiredService<IClienteService>();

            Console.WriteLine(serviceProvider.GetRequiredService<IClienteService>().GetClienteById(1).Result.Nombre + " " + clienteService.instancia());
            Console.WriteLine(serviceProvider.GetRequiredService<IClienteService>().GetClienteById(1).Result.Nombre + " " + clienteService.instancia());
            Console.WriteLine(serviceProvider.GetRequiredService<IClienteService>().GetClienteById(1).Result.Nombre + " " + clienteService.instancia());
            Console.WriteLine(serviceProvider.GetRequiredService<IClienteService>().GetClienteById(1).Result.Nombre + " " + clienteService.instancia());
        }

        static IServiceProvider CreateServiceProvider()
        {
            var collection = new ServiceCollection();
            
            var configBuilder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                          .AddJsonFile("appsettings.json", optional: false);

            IConfiguration configuration = configBuilder.Build();
            
            var connectionString = configuration.GetSection("ConnectionString").Value;


            collection.AddTransient<IClienteRepository, ClienteRepository>();
            collection.AddTransient<IOrdenRepository, OrdenRepository>();
            collection.AddTransient<IClienteService, ClienteService>();
            collection.AddTransient<IOrdenService, OrdenService>();
            collection.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

            return collection.BuildServiceProvider();
        }
    }
}