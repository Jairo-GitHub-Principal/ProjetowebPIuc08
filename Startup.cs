using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;// add para session
using Microsoft.AspNetCore.Mvc;// sdd para session
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Uc08Atv4jairoCesar
{

    //*************************************************************
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
            services.AddControllersWithViews();

            services.Configure<CookiePolicyOptions>(options=>//é preciso trabalhar c/ sessão para fazer controle de acesso
            {
                options.CheckConsentNeeded=context=>false;//é preciso trabalhar c/ sessão para fazer controle de acesso
                options.MinimumSameSitePolicy=SameSiteMode.None;//é preciso trabalhar c/ sessão para fazer controle de acesso
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);//é preciso trabalhar c/ sessão para fazer controle de acesso
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                //Http
                app.UseHsts(); //é preciso trabalhar c/ sessão para fazer controle de acesso
            }
            //Http 
            app.UseHttpsRedirection();//é preciso trabalhar c/ sessão para fazer controle de acesso
            app.UseCookiePolicy();//é preciso trabalhar c/ sessão para fazer controle de acesso
            app.UseSession();//é preciso trabalhar c/ sessão para fazer controle de acesso
            //dotnet dev-certs https --trust
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }


    //*******************************************************
}
