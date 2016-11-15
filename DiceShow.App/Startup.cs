using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using DiceShow.Ops.Parsing;
using DiceShow.Ops.Rolling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using DiceShow.Model;
using DiceShow.Storage;

namespace DiceShow.App
{
    public class Startup
    {

        public IServiceProvider ConfigureServices(IServiceCollection services, IHostingEnvironment env)
        {
            services.AddSignalR(options =>
            {
                if (env.IsDevelopment())
                {
                    options.Hubs.EnableDetailedErrors = true;
                }
            });

            services.AddMvc();

            var cb = new ContainerBuilder();

            cb.RegisterType<Executer>().As<IEvaluator>();
            cb.RegisterType<RandomRoller>().As<IRoller>();
            cb.RegisterType<Parser>().As<IParser>();

            if (env.IsDevelopment())
            {
                cb.RegisterType<InMemoryRepository>().As<IRepository>();
            }
            else
            {
                cb.RegisterType<DocumentDbRepository>().As<IRepository>();
            }


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
        }
    }

}