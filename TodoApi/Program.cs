
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using TodoApi.DomainLogic;
using TodoApi.Extentions;
using TodoApi.Infrastructure;
using TodoApi.Repository;

namespace TodoApi;

class Programs
{
    public static void Main(string[] args)
    {

        AppDomain appDomain = AppDomain.CurrentDomain;
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddCommandLine(args)
            .Build();

        var host = Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseUrls("http://*:5000");
            webBuilder.UseConfiguration(config);
            webBuilder.UseStartup<Startup>();
        });

        return host;
    }



}