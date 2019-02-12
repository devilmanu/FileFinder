using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileFinder.AppServices.Files.Commands.CreateFile;
using FileFinder.Domain.Repositories;
using FileFinder.Infrastructure.Bus.Commands;
using FileFinder.Infrastructure.Bus.Queries;
using FileFinder.Infrastructure.Presistence.Elastic.Extensions;
using FileFinder.Infrastructure.Presistence.Elastic.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FileFinder.API
{
    public class Startup
    {
        private readonly ILoggerFactory _loggerFactory;

        public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            Configuration = configuration;
            _loggerFactory = loggerFactory;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            services.AddScoped<IMediator, Mediator>();
            services.AddScoped<ServiceFactory>(p => p.GetService);

            services.AddScoped<ICommandBus, CommandBus>();
            services.AddScoped<IQueryBus, QueryBus>();
            

            services.Scan(scan => scan
                .FromAssembliesOf(typeof(CreateFileCommandHandler))
                .AddClasses()
                .AsImplementedInterfaces());

            services.AddScoped<IFileRepository, FileRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddElasticSearch(new Nest.ConnectionSettings(new Uri("http://localhost:9200"))
                    .SniffOnConnectionFault(false)
                    .SniffOnStartup(false)
                    .SniffLifeSpan(TimeSpan.FromMinutes(1))
                    .DefaultIndex("file-app-*")
                    .DefaultTypeName("doc")
                    .EnableDebugMode(details =>
                    {
                        var logger = _loggerFactory.CreateLogger<Startup>();
                        logger.LogDebug($"ES Request: => {Encoding.UTF8.GetString(details.RequestBodyInBytes ?? new byte[0])}");
                        logger.LogDebug($"ES Response: => {Encoding.UTF8.GetString(details.ResponseBodyInBytes ?? new byte[0])}");
                    }
                )
             );
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
