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

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDoorHistoryService, DoorHistoryService>();
            services.AddTransient<IDoorService, DoorService>();
            services.AddTransient<IDoorIOTClient, DoorIOTClient>();
            services.AddTransient<IDoorRightService, DoorRightService>();

            services.AddTransient<IDoorHistoryRepository, DoorHistoryRepository>();
            services.AddTransient<IDoorRepository, DoorRepository>();
            services.AddTransient<IDoorRightRepository, DoorRightRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserTagRepository, UserTagRepository>();

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

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
