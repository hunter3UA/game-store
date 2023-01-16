using GameStore.API.Helpers;
using GameStore.API.Permissions.Publisher;
using GameStore.API.Static;
using GameStore.BLL.BackgroundServices;
using GameStore.BLL.Extensions;
using GameStore.BLL.Models;
using GameStore.BLL.Services.Abstract;
using GameStore.BLL.Services.Abstract.Games;
using GameStore.BLL.Services.Implementation;
using GameStore.BLL.Services.Implementation.Games;
using GameStore.BLL.Services.Implementation.Orders;
using GameStore.Common.Extensions;
using GameStore.Common.Services.Abstract;
using GameStore.DAL.Context;
using GameStore.DAL.Repositories.Abstract;
using GameStore.DAL.Repositories.Implementation;
using GameStore.DAL.UoW.Abstract;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System;

namespace GameStore.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDbServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<StoreDbContext>();         
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddBllServices(this IServiceCollection services)
        {
            services.AddScoped<IGameService, GameService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPlatformTypeService, PlatformTypeService>();
            services.AddScoped<IPublisherService, PublisherService>();
            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<ICustomerHelper, CustomerHelper>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddHostedService<OrderExpirationService>();
            services.AddScoped<IPaymentContext, PaymentContext>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGameFilterService, GameFilterService>();
            services.AddScoped<IShipperService, ShipperService>();
            services.AddScoped<IPasswordService, PasswordService>();
        }

        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration config)
        {
            var authOptions = config.GetJsonSection<AuthOptions>(nameof(AuthOptions));

            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                IssuerSigningKey = authOptions.GetSymmetricSecurityKey(),
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.Zero,
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

        public static void AddOptionalServices(this IServiceCollection services)
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
                    builder => 
                    builder.AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithExposedHeaders("Content-Disposition")
                    .SetIsOriginAllowed(origin => true)
                    .AllowCredentials()
                    );
            });

            services.AddSingleton(Log.Logger);
            services.AddAutoMapper(configuration =>
            {
                configuration.AddCustomProfiles();
            });

            services.AddScoped<IPublisherPermission, PublisherPermission>();
        }
    }
}
