using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PU.Core.Entities;
using PU.Core.Interfaces;
using PU.Core.Services;
using PU.Infraestructura.Data;
using PU.Infraestructura.Repositories;
using System;

namespace PatronesUnitRepo
{
    class Program
    {
        static void Main(string[] args)
        {

            var serviceProvider = new ServiceCollection()
                .AddTransient<IUserService, UserService>()
                .AddScoped(typeof(IRepository<>), typeof(BaseRepository<>))
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddDbContext<PUContext>(options => {
                    options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SocialMedia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");  
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
