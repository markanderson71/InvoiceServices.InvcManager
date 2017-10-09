using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using InvoiceServices.InvcManager.Data;
using InvoiceServices.InvcManager.Core;
using InvoiceServices.InvcManager.Core.Services;
using InvoiceServices.InvcManager.Service;
using AutoMapper;

namespace InvoiceServices.InvcManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //Get Configuration
            services.Configure<DatabaseSettings>(c =>
             {
                 c.ConnectionString = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                 c.DatabaseName = Configuration.GetSection("MongoConnection:Database").Value;
             });
            services.AddScoped(cfg => cfg.GetService<IOptions<DatabaseSettings>>().Value);

            //Configure and Add Automapper
            var config = new AutoMapper.MapperConfiguration(cfg => { cfg.AddProfile(new AutoMapperConfigurationProfile()); });
            var mapper = config.CreateMapper();
            services.AddSingleton<IMapper>(mapper);

            services.AddScoped<IRepository, DataSource>();
            services.AddScoped<IIdGeneratorService, IdGenerationService>();
            services.AddScoped<IInvoiceDateService, InvoiceDateService>();
            services.AddScoped<InvoiceFactory, InvoiceFactory>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
