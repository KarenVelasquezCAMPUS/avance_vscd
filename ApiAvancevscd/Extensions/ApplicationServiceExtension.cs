using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.DependencyInjection;
using Dominio.Interfaces;
using Aplicacion.UnitOfWork;

namespace ApiAvancevscd.Extensions;

    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        public static void AddAplicacionServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }