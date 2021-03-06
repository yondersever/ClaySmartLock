using ClaySmartLock.DataAccess.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClaySmartLock.Service.Interface;
using ClaySmartLock.Service.Imp;
using ClaySmartLock.DataAccess.Repository.Imp;
using ClaySmartLock.DataAccess.Repository.Interface;
using ClaySmartLock.Model.Configuration;

namespace ClaySmartLock
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<ClaySmartLockDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ClayDBConnection")));

            services.Configure<ClayAppConfiguration>(Configuration.GetSection("ClayAppConfiguration"));

            services.AddHttpContextAccessor();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDoorHistoryService, DoorHistoryService>();
            services.AddScoped<IDoorService, DoorService>();
            services.AddScoped<IDoorIOTClient, DoorIOTClient>();
            services.AddScoped<IDoorRightService, DoorRightService>();

            services.AddScoped<IDoorHistoryRepository, DoorHistoryRepository>();
            services.AddScoped<IDoorRepository, DoorRepository>();
            services.AddScoped<IDoorRightRepository, DoorRightRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserTagRepository, UserTagRepository>();
            services.AddScoped<IHashService, HashService>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClaySmartLock", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClaySmartLock v1"));
            }

            app.UseExceptionHandler("/errors");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<JwtMiddleware>();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
