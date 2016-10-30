using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DiceShow.Ops.Parsing;
using DiceShow.Ops.Rolling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

// todo - need to setup an app.config for this app now because we have a connnection stringh
// docdb connection string = AccountEndpoint=https://diceshow.documents.azure.com:443/;AccountKey=N9pyEMe6ADa5Z761gdaFvmLNHPangB9ueup6CBMQufcHa5Cadq1MXdNMANfMyOWVwxt6T7aLM6RrXKAvl7sDUQ==;

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