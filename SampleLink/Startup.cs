using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RiskFirst.Hateoas;
using SampleLink.Model;
namespace SampleLink
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddLinks(config =>
            {
                // Uncomment the next line to use relative hrefs instead of absolute
                config.UseRelativeHrefs();
                config.ConfigureRelTransformation(transform => transform.Add(ctx => $"{ctx.LinkSpec.RouteName}"));

                config.AddPolicy<Location>(policy =>
                {
                    policy.RequireRoutedLink("users", "Get Users for a Location", x => new { id = x.Id });
                    policy.RequireRoutedLink("areas", "Get Areas for a Location", x => new { locationId = x.Id });
                });

                //config.AddPolicy<Device>(policy =>
                //{
                //    policy.RequireRoutedLink("users", "Get Users for a Device", x => new { id = x.Id });
                //});
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
