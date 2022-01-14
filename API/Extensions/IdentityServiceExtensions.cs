using System.Text;
using API.Services;
using Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
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

            // "super secret key"
            // when we create the Token, we used this key
            // when the client carry the token, we still use the key to  Check it was modified
            // we don't want anyone to modify the token 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super secret key"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    // set up Token validation rule
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ValidateIssuer = false,
                    ValidateAudience = false

                };
            });
            services.AddScoped<TokenService>();
            return services;
        }



    }
}