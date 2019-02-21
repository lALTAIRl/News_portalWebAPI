using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using News_portal.BLL.Interfaces;
using News_portal.BLL.Services;
using News_portal.DAL.Data;
using News_portal.DAL.Entities;
using News_portal.DAL.Interfaces;
using News_portal.DAL.Repositories;
using AutoMapper;

namespace News_portal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<IUserService, UserService>();

            services.AddCors();

            services.AddAutoMapper();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

        }

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
   
            app.UseStaticFiles(); 
            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
