using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleProject.Services;
using Microsoft.OpenApi.Models;
using Autofac;
using Serilog;
using System.IO;

namespace SampleProject
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
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Reactive Form API", Version = "v1" });
            });

            //logger
            services.AddLogging(loggingBuilder =>
          loggingBuilder.AddSerilog(dispose: true));

            services.AddControllers();
            services.AddScoped<IUserServices, UserServices>();
            services.AddCors();
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryHandlerModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Reactive Form API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            /// Serilog
            Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .WriteTo.RollingFile(Path.Combine(env.ContentRootPath, "log-{Date}.txt"))
        .CreateLogger();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
