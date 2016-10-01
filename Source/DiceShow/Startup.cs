using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DiceShow
{

    public class Startup
    {

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddSignalR(options =>
            {
                options.Hubs.EnableDetailedErrors = true;
            });

            services.AddMvc();

            var cb = new ContainerBuilder();

            cb.RegisterType<Executer>().As<IExecuter>();
            cb.RegisterType<RandomRoller>().As<IRoller>();
            cb.RegisterType<Parser>().As<IParser>();


            cb.Populate(services);
            var container = cb.Build();
            return container.Resolve<IServiceProvider>();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logFactory)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // todo - user friendly error page
            }

            app.UseWebSockets();
            app.UseSignalR();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
            });


            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World of the last resort. The Time is: " + DateTime.Now.ToString("hh:mm:ss tt"));
            });
        }
    }

}