using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using desafio.app;
using desafio.app.service;
using desafio.app.repository;

namespace desafio.api
{   
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<IRegisterUserService, RegisterUserService>();
            services.AddTransient<ISignInService, SignInService>();
            
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseIISPlatformHandler();
            app.UseStaticFiles();

            app.UseMvc();
            
            //app.UseJwtBearerAuthentication(options => {});
                /*
                // Basic settings - signing key to validate with, audience and issuer.
                options.TokenValidationParameters.IssuerSigningKey = key;
                options.TokenValidationParameters.ValidAudience = tokenOptions.Audience;
                options.TokenValidationParameters.ValidIssuer = tokenOptions.Issuer;

                // When receiving a token, check that we've signed it.
                options.TokenValidationParameters.ValidateSignature = true;

                // When receiving a token, check that it is still valid.
                options.TokenValidationParameters.ValidateLifetime = true;

                // This defines the maximum allowable clock skew - i.e. provides a tolerance on the 
                // token expiry time when validating the lifetime. As we're creating the tokens locally
                // and validating them on the same machines which should have synchronised 
                // time, this can be set to zero. Where external tokens are used, some leeway here 
                // could be useful.
                options.TokenValidationParameters.ClockSkew = TimeSpan.Zero;
            });*/
        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}
