using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.AspNetCore;
using Kerberos.Business.Extensions;
using Kerberos.Util.Filters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Kerberos.WebAPI
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
            services.AddServiceCollectionExtension();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IsValidIdActionFilter<>));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt=>
            {
                opt.RequireHttpsMetadata = false;
                opt.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidIssuer="http://localhost",
                    ValidAudience= "http://localhost",
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nisanur")),
                    ValidateIssuerSigningKey=true,
                    ValidateLifetime=true
                };
            });
            services.AddControllers().AddFluentValidation();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            // localhost/Error
            app.UseExceptionHandler("/Error");
            app.UseAuthentication();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
