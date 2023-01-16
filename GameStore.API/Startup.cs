using GameStore.API.Middleware;
using GameStore.API.Static;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using GameStore.API.Extensions;

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
            services.AddOptionalServices();
            services.AddBllServices();
            services.AddDbServices(_config);
            services.AddJwtAuthentication(_config);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
             
            app.UseCustomLogging();

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
            app.UseAuthentication();
            app.UseAuthorization(); 
                    
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }        
    }
}
