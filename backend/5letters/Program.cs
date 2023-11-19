using System.Threading.Tasks;
using _5letters.Data;
using _5letters.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _5letters
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString));

            builder.Services.AddControllers(options => options.UseRoutePrefix("api"));
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "api/swagger/{documentname}/swagger.json";
            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Five Letters API v1");
                options.RoutePrefix = "api/swagger";
            });
            app.UseCors(builder => builder
                .WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            // using (var scope = app.Services.CreateScope())
            // {
            //     var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            //     await context.Database.MigrateAsync();
            // }

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}