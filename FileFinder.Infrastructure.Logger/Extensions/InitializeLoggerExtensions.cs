using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileFinder.Infrastructure.Logger.Extensions
{
    public static class InitializeSentryLoggerExtensions
    {
        public static IWebHostBuilder InitializeSentryLogger(this IWebHostBuilder webHostBuilder)
        {
            webHostBuilder.UseSentry("https://20d624376eed479d8d288d4dcc213780@sentry.io/1390508");
            return webHostBuilder;
        }
    }
}
