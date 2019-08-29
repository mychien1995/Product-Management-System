using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using ProductMS.DataAccess.SqlServer.Databases;
using ProductMS.DataAccess.SqlServer.Entities;
using ProductMS.DataAccess.SqlServer.Extensions;
using ProductMS.Framework.Initializations;
using System;
using System.Text;

namespace ProductMS.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            }));
        }

        public static void ConfigureMvc(this IServiceCollection services)
        {
            services
               .AddMvc()
               .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
               .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());
        }

        public static void InitializeServices(this IServiceCollection services)
        {
            InitializationModule.InitializeServices(services);
        }

        public static void ConfigureIdentity(this IServiceCollection services, string tokenKey, string tokenAudience, string tokenIssuer)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => { }).AddCustomEFStore<ProductDbContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.User.RequireUniqueEmail = true;
            });

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(config =>
            {
                config.RequireHttpsMetadata = false;
                config.SaveToken = true;
                config.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = signingKey,
                    ValidateAudience = true,
                    ValidAudience = tokenAudience,
                    ValidateIssuer = true,
                    ValidIssuer = tokenIssuer,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true
                };
            });
        }
    }
}
