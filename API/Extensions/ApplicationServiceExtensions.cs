using Application.Activities;
using Application.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Persistence;
using System;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, 
            IConfiguration config)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors(opt => 
            {
                opt.AddPolicy("CorsPolicy", policy => 
                {
                    policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
                });
            });
            // Here reference the AddMediatR(MediatRServiceConfiguration)...see document!
            var newObject = new MediatRServiceConfiguration();
            var configuration = newObject.RegisterServicesFromAssemblyContaining(typeof(List.Handler));
            services.AddMediatR(configuration);
            //services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;
        }
    }
}