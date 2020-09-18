using BroData.API.Brokers;
using BroData.API.Datasets;
using BroData.API.Service.v0;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace BroData.API
{
    public class Startup
    {
        
        public IConfiguration Configuration { get; private set; }


        public Startup(IConfiguration configuration)
        {
            
            Configuration = configuration;
        }

        public void InitialStorage(IServiceCollection services)
        {
            string constr = Configuration["ConnectionString"];
            services.AddDbContext<StorageBroker>(context => context.UseNpgsql(constr));
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v0", new OpenApiInfo
                {
                    Title = "BroData Open API",
                    Version = "v0",
                    Description = "Open Datasets for your projects ",
                    Contact = new OpenApiContact
                    {
                        Url = new Uri("https://brodata.io"),
                    },

                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
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

            

            //services.AddSingleton<IISO3166Repo, ISO3166Repo>();

            services.AddScoped<INameService, NameService>();
            services.AddTransient<ISurnameService, SurnameService>();
            services.AddTransient<IGenEmailService, GenEmailService>();
            services.AddTransient<IGetCallCounterService, GetCallCounterService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IStateService, StateService>();

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
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v0/swagger.json", "BroData Open API V0");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
