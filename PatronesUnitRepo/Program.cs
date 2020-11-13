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
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PatronesUnitRepo
{
    class Program
    {
        private static IConfigurationRoot Configuration { get; set; }
        static async Task Main(string[] args)
        {

            IConfigurationBuilder config = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", true, true);

            Configuration = config.Build();


            var serviceProvider = new ServiceCollection()
                .AddTransient<IPostService, PostService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<ICommentRepository, CommentService>()
                .AddScoped(typeof(IRepository<>), typeof(BaseRepository<>))
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddDbContext<PUContext>(options => {
                    options.UseSqlServer(Configuration.GetConnectionString("SocialMediaContext"));  
                })
                .BuildServiceProvider();

            try
            {

                //var userRepo = serviceProvider.GetService<IUserService>();
                //var listUser = userRepo.GetAll().ToList();

                //var userDelete = serviceProvider.GetService<IUserService>();
                //var Resp = await userDelete.GetById(1);
           

                //var commentRepo = serviceProvider.GetService<ICommentRepository>();
                //var listComment = commentRepo.GetAll().ToList();


                var postService = serviceProvider.GetService<IPostService>();
                var resp = await postService.GetPostByUser(1);

            }
            catch (Exception ex)
            {

                var e = ex.Message;
            }

            Console.WriteLine("Hello World!");
        }
    }
}
