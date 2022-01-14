using API.Extensions;
using API.Middleware;
using Application.Activities;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace API
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // add the Authorize policy into the Controllor services
            services.AddControllers(opt => {
                // By adding here other then on specified Action or Controller
                // We create the rule that each request need to be authorized until it use [AllowAnonymous]
                var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();  // Create a new policy
                opt.Filters.Add(new AuthorizeFilter(policy));                                      // add New Filter !!!
            }).AddFluentValidation(Config =>
           {
               Config.RegisterValidatorsFromAssemblyContaining<Create>(); // tell him which Assembly is it.
           });

            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));
            });
            services.ConfigureCors();
            // Inject MediatR
            // Here, the AddMediatR() need to be pass a Module, so that we can use type to find it.
            // We can use either Handler to retrive the Assembly
            // Either of the following approach works properly.
            services.AddMediatR(typeof(ListActivity.Handler).Assembly);
            //services.AddMediatR(typeof(Details.Handler).Assembly);   // works too

            services.ConfigAutoMapper();  // in the Extension

            services.AddIdentityServices(_configuration);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Be aware this ExceptionMiddleware has been put at the first layer!
            app.UseMiddleware<ExceptionMiddleware>();

            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
