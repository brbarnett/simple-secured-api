using System.Net;
using System.Text;
using Legacy.Platform.Api.Requests.Configuration;
using Legacy.Platform.Api.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Legacy.Platform.Api
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

            // singleton for this case because it's stateful
            services.AddSingleton<IValuesService, ValuesService>();

            // MediatR
            services.AddMediatR(typeof(Startup));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CustomRequestPostProcessorBehavior<,>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

                app.UseHttpsRedirection();
            }

            app.UseExceptionHandler(builder =>
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    var ex = context.Features.Get<IExceptionHandlerFeature>();
                    if (ex != null)
                    {
                        StringBuilder message = new StringBuilder();
                        if (env.IsDevelopment())
                        {
                            message.AppendLine(ex.Error.Message);
                            message.AppendLine(ex.Error.StackTrace);
                        }
                        else
                        {
                            message.AppendLine("An error has occurred");
                        }

                        await context.Response.WriteAsync(message.ToString()).ConfigureAwait(false);
                    }
                }));

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}