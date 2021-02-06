using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiddlewareApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            #region FirstSample
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("MidleWare Start");
            //    await next.Invoke();
            //    await context.Response.WriteAsync("MiddleWare End");
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("Sub middleWare Run");
            //});



            #endregion FirstSample

            #region SecondSample

            //app.Use(async (context, next) =>
            //{

            //    await context.Response.WriteAsync(" MiddleWare1 Start ");
            //    await next.Invoke();
            //    await context.Response.WriteAsync(" MiddleWare1 End ");
            //});


            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync(" MiddleWare2 Start ");
            //    await next.Invoke();
            //    await context.Response.WriteAsync(" MiddleWare2 End ");
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync(" next Middeware Running ");
            //});

            #endregion SecondSample

            #region MiddlewareRun

            //app.Run(async (context) => {
            //    await context.Response.WriteAsync("MiddleWare1");
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("MiddleWare2");
            //});



            #endregion middlewareeRun

            #region Middleware Map


            app.Map("/HandleSample1", app => 
            {
                app.Use(async (context, next) =>
                {
                    await context.Response.WriteAsync("MidleWare Start");
                    await next.Invoke();
                    await context.Response.WriteAsync("MiddleWare End");
                });

                //app.Run(async context =>
                //{
                //    await context.Response.WriteAsync("HandleSample1 Working");
                //});
            });

            app.Map("/HandleSample2", HandleMapSample2);

            app.Run(async context => {
                await context.Response.WriteAsync("Finished request Chain");
            });

            #endregion Middleware Map




            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }

        private static void HandleMapSample2(IApplicationBuilder app)
        {
            app.Run(async context => {
                await context.Response.WriteAsync("HandleSample2 Working");
            });
        }
    }
}
