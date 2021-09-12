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
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace DiceShow.App {

    public class Startup {

        public IConfigurationRoot Configuration { get; set; }
        public IHostingEnvironment Environment { get; set; }


        public Startup(IHostingEnvironment env, ILoggerFactory factory) {
            Environment = env;
            Configuration = new ConfigurationBuilder()
                            .AddEnvironmentVariables("diceshow_")
                            .Build();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logFactory) {
            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                // in dev mode serve all files including .scss
                app.UseStaticFiles(new StaticFileOptions { ServeUnknownFileTypes = true });
            } else {
                app.UseExceptionHandler("/Error");
                app.UseStaticFiles();
            }

            app.UseWebSockets();
            app.UseSignalR();
            app.UseMvc();
        }

        public IServiceProvider ConfigureServices(IServiceCollection services) {
            services.AddSignalR(options => {
                if(Environment.IsDevelopment()) {
                    options.Hubs.EnableDetailedErrors = true;
                }
            });

            services.AddMvc();

            var cb = new ContainerBuilder();

            cb.RegisterType<Executer>().As<IEvaluator>();
            cb.RegisterType<RandomRoller>().As<IRoller>();
            cb.RegisterType<Parser>().As<IParser>();

            if(Environment.IsDevelopment()) {
                cb.Register<InMemoryRepository>(c => new InMemoryRepository("InMemoryRepository")).As<IRepository>();
            } else {
                // cb.Register<DocumentDbRepository>(c=> new DocumentDbRepository("connectionString","databaseName")).As<IRepository>();
                var connectionString = Configuration.GetValue<string>("storage_connection");
                cb.Register<InMemoryRepository>(c => new InMemoryRepository("InMemoryRepository")).As<IRepository>();
            }

            cb.Populate(services);
            var container = cb.Build();
            return container.Resolve<IServiceProvider>();
        }
    }

}