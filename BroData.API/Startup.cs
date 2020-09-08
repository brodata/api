using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using BroData.API.Brokers;

namespace BroData.API
{
    public class Startup
    {

        public IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void InitialStorage(IServiceCollection services)
        {
            services.AddDbContext<StorageBroker>(context => context.UseNpgsql(Configuration["ConnectionString"]));
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddResponseCaching(options =>
            {
                options.MaximumBodySize = 1024;
                options.UseCaseSensitivePaths = true;
            });
            InitialStorage(services);

            services.AddControllers();
            services.AddMvc();
            services.AddSingleton<IGenPasswdService, GenPasswdService>();
            services.AddSingleton<IGenTelephonService, GenTelephonService>();
            services.AddScoped<ICityService, CityService>();
            services.AddTransient<IISO3166Service, ISO3166Service>();
            services.AddScoped<INameService, NameService>();
            services.AddTransient<ISurnameService, SurnameService>();
            services.AddTransient<IGenEmailService, GenEmailService>();

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                    });
            });

            services.Configure<KestrelServerOptions>(
                Configuration.GetSection("Kestrel"));


            
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
