using BroData.API.Data;
using BroData.API.Datasets;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using System;

namespace BroData.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            NamesRepo.Init("./csvs/dataset_names.csv");
            ISO3166Repo.Init("./csvs/dataset_iso3166.csv");
            SurnamesRepo.Init("./csvs/dataset_surnames.csv");
            StatesRepo.Init("./csvs/dataset_us_states.csv");
            CitiesRepo.Init("./csvs/dataset_us_cities.csv");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(serverOptions =>
                    {
                        serverOptions.Limits.MaxConcurrentConnections = 100;
                        serverOptions.Limits.MaxConcurrentUpgradedConnections = 100;
                        serverOptions.Limits.MaxRequestBodySize = 10 * 1024;
                        serverOptions.Limits.MinRequestBodyDataRate =
                            new MinDataRate(bytesPerSecond: 100,
                                gracePeriod: TimeSpan.FromSeconds(10));
                        serverOptions.Limits.MinResponseDataRate =
                            new MinDataRate(bytesPerSecond: 100,
                                gracePeriod: TimeSpan.FromSeconds(10));
                        serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
                        serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(1);
                    })
                    .UseUrls("http://0.0.0.0:5000")
                    .UseStartup<Startup>();
                });
    }
}
