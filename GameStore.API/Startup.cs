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
using GameStore.DAL.Repositories.Abstract;
using GameStore.DAL.Repositories.Implementation;
using GameStore.API.Helpers;
using GameStore.BLL.BackgroundServices;
using GameStore.BLL.Services.Abstract.Games;
using GameStore.BLL.Services.Implementation.Games;

namespace GameStore.API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            ServiceRegister(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
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
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint(Constants.SwaggerUrl, Constants.SwaggerName);
                });
            }

            app.UseRouting();
            app.UseCors("AllowOrigin");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ServiceRegister(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.CacheProfiles.Add(
                Constants.CachingProfileName,
                new CacheProfile()
                {
                    Duration = Constants.ResponseCacheDuration
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
            services.AddCors(options =>
            {

                options.AddPolicy(
                    "AllowOrigin",
                    builder => builder.AllowAnyMethod().AllowAnyHeader().WithExposedHeaders("Content-Disposition").SetIsOriginAllowed(origin => true).AllowCredentials()
                    );
            });

            services.AddSingleton(Log.Logger);
            services.AddAutoMapper(typeof(AutoMapperConfig));

            services.AddScoped<StoreDbContext>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPlatformTypeService, PlatformTypeService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ICustomerGenerator, CustomerGenerator>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddHostedService<OrderExpirationService>();
            services.AddScoped<IPaymentContext, PaymentContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGameFilterService, GameFilterService>();
        }
    }
}
