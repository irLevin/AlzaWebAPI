using System;
using System.IO;
using System.Reflection;
using Alza.BusinessLogic.Inventory;
using Alza.BusinessLogic.Products;
using Alza.Common.Data;
using Alza.Common.Logger;
using Alza.Data.MockData;
using Alza.Data.MSSQLData;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace AlzaTask
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvcCore().AddApiExplorer();
            services.AddApiVersioning(
               options =>
               {
                   options.ReportApiVersions = true;
                   options.AssumeDefaultVersionWhenUnspecified = true;
                   options.DefaultApiVersion = new ApiVersion(1, 0);
               });
            services.AddVersionedApiExplorer(
                options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<ProductDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("dbconn")));
            // My custom dependency injections
            services.AddSingleton<IAlzaLogger, ConsoleLogger>();
            services.AddScoped<IProductsRepo, ProductsRepo>();
            services.AddScoped<IInventoryRepo, InventoryRepo>();
            bool isTestMode;
            if(Boolean.TryParse(Configuration.GetValue<string>("isTestMode"), out isTestMode))
            {
                if (isTestMode)
                {
                    services.AddSingleton<IDataProvider, MockDataProvider>();
                }
                else
                {
                    services.AddScoped<IDataProvider, SQLDataProvider>();
                }
            }
            
            


            // Swagger documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Alza web api",
                    Description = "Alza web api description",
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Irina",
                        Email = "iralevin.mail@gmail.com",
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            //db context

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
                app.UseHsts();
            }

            // Swagger documentation IU
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "docs/{documentName}/docs.json";
            });
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/docs/v1/docs.json", "Alza web api");
                c.DocumentTitle = "API Documentation";
                c.RoutePrefix = "swagger";
                c.DocExpansion(DocExpansion.None);
            });

            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
