using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PU.Core.Entities;
using PU.Core.Interfaces;
using PU.Core.Services;
using PU.Infraestructura.Data;
using PU.Infraestructura.Repositories;
using System;
using System.Configuration;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace PatronesUnitRepo
{
    class Program
    {
        private static IConfigurationRoot Configuration { get; set; }
        static void Main(string[] args)
        {

            IConfigurationBuilder config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", true, true);

            Configuration = config.Build();


            var serviceProvider = new ServiceCollection()
                .AddTransient<IUserService, UserService>()
                .AddScoped(typeof(IRepository<>), typeof(BaseRepository<>))
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddDbContext<PUContext>(options => {
                    options.UseSqlServer(Configuration.GetConnectionString("SocialMediaContext"));  
                })
                .BuildServiceProvider();

            try
            {

                var userRepo = serviceProvider.GetService<IUserService>();
                var listUser = userRepo.GetAll();
            }
            catch (Exception ex)
            {

                var e = ex.Message;
            }

            Console.WriteLine("Hello World!");
        }
    }
}
