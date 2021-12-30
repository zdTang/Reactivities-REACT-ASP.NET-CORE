using Application.Core;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ServicesExtension
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                //.AllowAnyOrigin()
                .WithOrigins("http://localhost:3000")
                );
            });
        }

        public static void ConfigAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);
        }
    }
}
