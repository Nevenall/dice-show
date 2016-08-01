using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DiceStream {

    public class Startup {

       public IServiceProvider ConfigureServices(IServiceCollection services) {
            

            services.AddSignalR(options => {
                options.Hubs.EnableDetailedErrors = true;
            });

            services.AddMvc();
            
            var containerBuilder = new ContainerBuilder();

            /// configure custom services.     

            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return container.Resolve<IServiceProvider>();
        } 


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logFactory) {

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                // use a user friendly exception page.
            }

            app.UseWebSockets();
            app.UseSignalR();

            app.UseMvc(routes => {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
            });      

         
            app.Run(async (context) => {
                await context.Response.WriteAsync("Hello World of the last resort. The Time is: " + DateTime.Now.ToString("hh:mm:ss tt"));
            });
        }
    }

}