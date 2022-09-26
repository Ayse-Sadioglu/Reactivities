using MediatR;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Application.Activities;
using Application.Core;
using Persistence;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions 
    {

        public static IServiceCollection AddApplicationServices (this IServiceCollection services,
        IConfiguration config){

             services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPIv5", Version = "v1" });
            });
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));

            });


            services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", policy =>
                {

                    policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
                });
            });

            services.AddMediatR(typeof(List.Handler).Assembly);//tell where handlers are
            services.AddAutoMapper(typeof(MappingProfiles).Assembly);

            return services;


        }
        
    }
}