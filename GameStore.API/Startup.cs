using GameStore.BLL.Services;
using GameStore.BLL.Services.Abstract;
using GameStore.DAL;
using GameStore.DAL.Repositories;
using GameStore.DAL.Repositories.Abstract;
using GameStore.DAL.UoW;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace GameStore.API
{
    public class Startup
    {
        
        private IHostEnvironment _env;
      
        public Startup(IHostEnvironment env)
        {
            _env = env;
           
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();        
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Swagger GS API",
                        Description = "Swagger",
                        Version = "v1"
                    });
            });       
            services.AddScoped<StoreDbContext>(); 
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IGameRepository,GameRepository>();
            services.AddScoped<IPlatformRepository,PlatformRepository>();
            services.AddScoped<ICommentRepository,CommentRepository>();           
            services.AddScoped<IGameService,GameService>();
            services.AddScoped<IGenreService,GenreService>();
            services.AddScoped<ICommentService,CommentService>();
            services.AddSingleton<IHostEnvironment>(_env);
          
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory,ILogger<Startup> logger)
        {

            loggerFactory.AddFile($"{env.ContentRootPath}\\Logs\\Logs.txt");
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger GS API");
                });
            }
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           


        }
    }
}
