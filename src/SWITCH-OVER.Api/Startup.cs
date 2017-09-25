using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace SWITCH_OVER.Api
{
    public class Startup
    {
	    public IConfigurationRoot _configuration { get; }

		public Startup(IHostingEnvironment env)
        {
			var builder = new ConfigurationBuilder()
		        .SetBasePath(env.ContentRootPath)
		        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
		        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
		        .AddEnvironmentVariables();

	        _configuration = builder.Build();
		}

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

	        // Configure the service to documentation the Swagger site
	        services.AddSwaggerGen(c =>
	        {
		        c.SwaggerDoc("v1",
			        new Info
			        {
				        Title = "Switch Over boilerplate",
				        Version = "v1",
				        Description = "Sample of API REST building with ASP.NET Core",
				        Contact = new Contact
				        {
					        Name = "Riguel Figueiro",
					        Url = "https://github.com/riguelbf"
				        }
			        });

		        var applicationBasePath = PlatformServices.Default.Application.ApplicationBasePath;
		        var applicationName = PlatformServices.Default.Application.ApplicationName;
		        var pathXmlDoc = Path.Combine(applicationBasePath, $"{applicationName}.xml");

		        c.IncludeXmlComments(pathXmlDoc);
	        });
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

	        loggerFactory.AddConsole(_configuration.GetSection("Logging"));
	        loggerFactory.AddDebug();

			if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

	        // Activate middlewares for use the Swagger
	        app.UseSwagger();
	        app.UseSwaggerUI(c =>
	        {
		        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sample API");
	        });
		}
    }
}
