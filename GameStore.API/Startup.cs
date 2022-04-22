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
using Serilog;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.API
{
    public class Startup
    {
        private readonly IHostEnvironment _env;

        public Startup(IHostEnvironment env)
        {
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.CacheProfiles.Add(
                Constants.CACHING_PROFILE_NAME,
                new CacheProfile()
                {
                    Duration = Constants.RESPONSE_CACHE_DURATION
                });
            });
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "v1",
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

            services.AddSingleton<Serilog.ILogger>(Log.Logger);
            services.AddSingleton(mapper);
            services.AddTransient<StoreDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPlatformTypeService, PlatformTypeService>();
            services.AddSingleton<IHostEnvironment>(_env);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseSerilogRequestLogging(options =>
            {
                options.MessageTemplate =
                " [{RemoteIpAddress}] {RequestScheme} {RequestHost} {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";
                options.EnrichDiagnosticContext = (diagnosticContext,
                 httpContext) =>
                 {
                     diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                     diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
                     diagnosticContext.Set("RemoteIpAddress", httpContext.Connection.RemoteIpAddress);
                 };
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(Constants.SWAGGER_URL, Constants.SWAGGER_NAME);
                });
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
