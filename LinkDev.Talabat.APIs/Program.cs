using System.Text;
using LinkDev.Talabat.APIs.Extintions;
using LinkDev.Talabat.APIs.Middlewares;
using LinkDev.Talabat.Application;
using LinkDev.Talabat.Application.Abstraction.Services.Auth;
using LinkDev.Talabat.Application.Services.Auth;
using LinkDev.Talabat.Domain.Entites.Identity;
using LinkDev.Talabat.Infrastracture;
using LinkDev.Talabat.Infrastracture.Persistence;
using LinkDev.Talabat.Infrastracture.Persistence.Identity;
using LinkDev.Talabt.APIs.Controllers;
using LinkDev.Talabt.APIs.Controllers.Erorrs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace LinkDev.Talabat.APIs
{
    public class Program
    {
        
        public static async Task Main(string[] args)
        {

           

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                .AddApplicationPart(typeof(AssemplyInfromation).Assembly).ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressModelStateInvalidFilter = false;
                    options.InvalidModelStateResponseFactory = (context) =>
                    {
                        var errors = context.ModelState
                        .Where(e => e.Value!.Errors.Count > 0)
                        .Select(P => new ApiValidationErorrResponse.ValditonErorr()
                        {
                            Field=P.Key,
                            Erorrs=P.Value!.Errors.Select(E =>E.ErrorMessage)

                        }).ToList();

                        return new BadRequestObjectResult(new ApiValidationErorrResponse()
                        {
                            Errors = errors

                        });
                    };

                });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
           

            builder.Services.AddPersistenceServices(builder.Configuration);
            // Add Application Services
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastractureServices(builder.Configuration);


            //identity
            //builder.Services.AddIdentity<ApplicationUser,IdentityRole>();
            builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                

                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                options.Lockout.AllowedForNewUsers = true;
            })
                .AddEntityFrameworkStores<StoreIdentityDbContext>();
            builder.Services.AddScoped(typeof(IAuthService), typeof(AuthService));
            builder.Services.AddScoped(typeof(Func<IAuthService>), (serviceProvider) =>
            {
                return () => serviceProvider.GetService<IAuthService>();
            });

            builder.Services.AddAuthentication((options) => { 
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme= JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer( (options) =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
                        ValidAudience = builder.Configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!))
                    };
                });

            var app = builder.Build();
            //datebase initializier

            await app.IntializeDbAsync();

            // Configure the HTTP request pipeline.
            app.UseMiddleware<ExceptionHandlerMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
