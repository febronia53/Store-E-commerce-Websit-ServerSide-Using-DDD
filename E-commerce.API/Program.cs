using E_commerce.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using E_commerce.Infrastructure.Data.Repositories;
using System.Reflection;
using E_commerce.Application.Queries;
using E_commerce.Application.Queries.Implementation;
using E_commerce.Application.Queries.Interfaces;
using E_commerceWebsite.AggregateModels.IRepositories;
using E_commerce.API.Middleware;
namespace E_commerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();



            builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDbContext<StoreDbContext>(options =>
               options.UseSqlServer(builder.Configuration.GetConnectionString("StoreConnection")));

            builder.Services.AddTransient<IMediator, Mediator>();

            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IProductQuery, ProductQuery>();
            builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            builder.Services.AddScoped<IProductTypeQuery, ProductTypeQuery>();
            builder.Services.AddScoped<IProductBrandRepository, ProductBrandRepository>();
            builder.Services.AddScoped<IProductBrandQuery, ProductBrandQuery>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddCors();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();



                using var scope = app.Services.CreateScope();
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<StoreDbContext>();
                var logger = services.GetRequiredService<ILogger<Program>>();
                try
                {
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error Occured while Migrating Process");
                }


            }

            app.UseMiddleware<ExceptionMiddleware>();
            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // prefered to add cors middleware before authorization 
            app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200/"));

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
