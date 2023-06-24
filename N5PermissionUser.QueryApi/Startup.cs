using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using N5PermissionUser.Domain.UnitOfWork;
using N5PermissionUser.Infrastructure;
using N5PermissionUser.Infrastructure.UnitOfWork;
using N5PermissionUser.QueryApi.Services;
using System;

namespace N5PermissionUser.QueryApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_N5PermissionUserQueryCors";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string conexion = Configuration.GetConnectionString("n5permission").ToString() ?? "";
            services.AddDbContext<N5PermissionUserContext>(opt => opt.UseSqlServer(conexion, x => x.MigrationsAssembly("N5PermissionUser.Infrastructure")));


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "N5PermissionUser.QueryApi", Version = "v1" });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin()
                                             .AllowAnyHeader()
                                             .AllowAnyMethod();
                                  });
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITypeService, TypeService>();
            services.AddTransient<IPermissionService, PermissionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "N5PermissionUser.QueryApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
