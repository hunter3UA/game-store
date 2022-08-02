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
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using GameStore.DAL.Context.Abstract;
using GameStore.BLL.Providers;
using Microsoft.IdentityModel.Tokens;
using GameStore.BLL.Models;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace GameStore.API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureOtherServices(services);
            ConfigureBllServices(services);
            ConfigureDbServices(services);
            ConfigureAuthenticationService(services);
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
            app.UseAuthentication();
            app.UseAuthorization(); 
            
            app.UseCors("AllowOrigin");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDbServices(IServiceCollection services)
        {
            services.AddScoped<StoreDbContext>();
            services.AddSingleton<IMongoClient, MongoClient>(m => new MongoClient(_config.GetConnectionString("NorthwindDb")));
            services.AddScoped<INorthwindFactory, NorthwindFactory>();
            services.AddScoped(typeof(INorthwindGenericRepository<>), typeof(NorthwindGenericRepository<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<INorthwindLogRepository, NorthwindLogRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private void ConfigureOtherServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.CacheProfiles.Add(
                Constants.CachingProfileName,
                new CacheProfile()
                {
                    Duration = Constants.ResponseCacheDuration
                });

            }).AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

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

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                        {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                        }
                    },
                    new string[] { }
                    }
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

            services.AddScoped<IMongoLoggerProvider, MongoLoggerProvider>();
        }

        private void ConfigureBllServices(IServiceCollection services)
        {
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
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<IPasswordService, PasswordService>();
            
        }

        private void ConfigureAuthenticationService(IServiceCollection services)
        {
            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.Zero
            };
            services.AddSingleton(tokenValidationParameters);
            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions =>
            {
                jwtOptions.TokenValidationParameters = tokenValidationParameters;
            });

            services.AddScoped<IAuthenticationService, JwtService>();
        }
    }
}
