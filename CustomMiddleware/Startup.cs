﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomMiddleware.Extensions;

namespace CustomMiddleware
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
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseBasicAuth();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


/*
 

 1 -  Hangi middleare' i yazacaksınız ?
 2 -  Middleware sınıfını yazmanız gereekiyor.
 3 -  Startupç.cs içerisinde bunu kullanmanız gerkeiyor


    Middlewarelar IApplicationBuilder sınıfına inject edilmelidir.
    startup cs içerisinde kullanmak için IApplciationBuilder extension kullanılabilir ve applicaitonBuilder nesnesinin UsseMiddleWare 
    methodu kullanılır.

 
 
 
 */