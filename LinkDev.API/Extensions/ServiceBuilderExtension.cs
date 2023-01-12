using LinkDev.API.MiddleWares;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace LinkDev.API.Extensions
{
    public static class ServiceBuilderExtension
    {
        public static WebApplication ConfigureFiles(this WebApplication app)
        {
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Files")),
                RequestPath = new PathString("/Files")
            });
            return app;
        }

        public static WebApplication ConfigureSwagger(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Versioned API v1.0");
                c.DefaultModelsExpandDepth(-1); // remove schema from swagger
                c.DocExpansion(DocExpansion.None);
                c.InjectStylesheet("/Files/Swagger/swagger.css");
            });

            return app;
        }

        public static WebApplication ConfigurePipeLine(this WebApplication app)
        {
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.MapControllers();
            return app;
        }
    }
}
