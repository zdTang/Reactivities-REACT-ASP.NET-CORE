using API.Services;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            // this "AddIentityCore" will inject a bunch of services into ServicesCollection
            // such as "userManager"
            // https://stackoverflow.com/questions/55361533/addidentity-vs-addidentitycore
            services.AddIdentityCore<AppUser>(opt =>
           {
               opt.Password.RequireNonAlphanumeric = false;
           })
           .AddEntityFrameworkStores<DataContext>()      // Be aware, it is not DbContext, it is DataContext !!!!
           .AddSignInManager<SignInManager<AppUser>>();  // Add SignInManager into Services

            services.AddAuthentication();
            services.AddScoped<TokenService>();
            return services;
        }



    }
}