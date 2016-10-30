using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DiceShow.Ops.Parsing;
using DiceShow.Ops.Rolling;
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

            cb.RegisterType<Executer>().As<IEvaluator>();
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
                // in dev mode serve all files including .scss
                app.UseStaticFiles(new StaticFileOptions { ServeUnknownFileTypes = true });
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStaticFiles();
            }

            app.UseWebSockets();
            app.UseSignalR();
            app.UseMvc();

            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
            // });
        }
    }

}