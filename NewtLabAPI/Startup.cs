using Microsoft.AspNetCore.Builder;
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
using NewtlabAPI.Services;
using NewtlabAPI.Services.IServices;
using NewtlabAPI.Services.Service;
using NewtlabAPI.Controllers;
using NewtlabAPI.Data;
using NewtlabAPI.Converters;
using NewtlabAPI.Services.Services;

namespace NewtlabAPI
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
            //services.AddAuthentication(AzureADDefaults.BearerAuthenticationScheme)
            //    .AddAzureADBearer(options => Configuration.Bind("AzureAd", options));
            services.AddDbContext<NewtLabContext>();

            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new IntToStringConverter());
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
            });
            services.AddTransient<IBancoPreguntaService, BancoPreguntasServices>();
            services.AddScoped<IUserService, UserService>();
            services.AddTransient<IExperimentoService, ExperimentoService>();
            services.AddTransient<IPruebaExperimentoService, PruebaExperimentoService>();
            services.AddTransient<IGuiaExperimento, GuiaExperimentoService>();
            services.AddTransient<IPreguntaService, PreguntaService>();
            services.AddTransient<IRespuestaService, RespuestaService>();
            services.AddTransient<ITipoPreguntaService, TipoPreguntaService>();
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

            //app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
