using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using FileFinder.Infrastructure.Presistence.Elastic.Extensions;
using FileFinder.Infrastructure.Logger.Extensions;

namespace FileFinder.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().ElasticIndexEnsureCreated().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .InitializeSentryLogger()
                .UseStartup<Startup>();
    }
}
