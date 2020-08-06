using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SocialDistancingTracker.Controllers;
using SocialDistancingTracker.Models;
using SocialDistancingTracker.Services;

namespace SocialDistancingTracker
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SocialDistancingTrackerDatabaseSettings>(Configuration.GetSection(nameof(SocialDistancingTrackerDatabaseSettings)));
            services.AddSingleton<ISocialDistancingTrackerDatabaseSettings>(sp => sp.GetRequiredService<IOptions<SocialDistancingTrackerDatabaseSettings>>().Value);
            services.AddSingleton<SocialDistancingTrackerService>();
            services.AddControllers();
             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
