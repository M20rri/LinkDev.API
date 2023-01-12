using LinkDev.API.Context;
using LinkDev.API.Interface;
using LinkDev.API.Interface.Implementation;
using MediatR;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Reflection;

namespace LinkDev.API.Extensions
{
    public static class ConfigExtension
    {
        public static void AddDIContainer(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddCors();

            builder.Services.AddScoped<IVacancy, VacancyRepository>();
            builder.Services.AddScoped<IApplicant, ApplicantRepository>();
            builder.Services.AddScoped<IApplyVacancy, ApplyVacancyRepository>();
            builder.Services.AddDbContext<LinkDevContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Constr")));
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddSwaggerGen(options =>
            {
                // Adding swagger document
                options.SwaggerDoc("v1.0", new OpenApiInfo() { Title = "LinkDev API v1.0", Version = "v1.0" });


                // To use unique names with the requests and responses
                options.CustomSchemaIds(x => x.FullName);

                // Defining the security schema
                var securitySchema = new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                // Adding the bearer token authentaction option to the ui
                options.AddSecurityDefinition("Bearer", securitySchema);

                // use the token provided with the endpoints call
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                });

            });
        }
    }
}
