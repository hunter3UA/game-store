using AutoMapper;
using GameStore.API.Middleware;
using GameStore.API.Static;
using GameStore.BLL.Mapper;
using GameStore.BLL.Services.Abstract;
using GameStore.BLL.Services.Implementation;
using GameStore.DAL.Context;
using GameStore.DAL.UoW.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

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
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AutoMapperConfig());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSingleton<StoreDbContext>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();       
            services.AddSingleton<IGameService,GameService>();
            services.AddSingleton<IGenreService,GenreService>();
            services.AddSingleton<ICommentService,CommentService>();
            services.AddSingleton<IHostEnvironment>(_env);
          
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerFactory loggerFactory,ILogger<Startup> logger)
        {
            loggerFactory.AddFile(Path.Combine(env.ContentRootPath,Constants.LOG_FILE_PATH));         
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(Constants.SWAGGER_URL, Constants.SWAGGER_NAME);
                });
            }
            app.UseRouting(); 
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
           
        }
    }
}
