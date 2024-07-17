using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Contexts;
using ProductAPI.Models;
using ProductAPI.Repositories;
using ProductAPI.Services;
using System;

namespace ProductAPI
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

            #region context
            var client = new SecretClient(new Uri("https://keyvault-gokul.vault.azure.net"), new DefaultAzureCredential());
            var secret = await client.GetSecretAsync("SqlInstanceConnectionString");
            builder.Services.AddDbContext<ProductAPIContext>(
                options => options.UseSqlServer(secret.Value.Value)
                );
            #endregion

            #region repository
            builder.Services.AddScoped<IReposiroty<int, Product>, ProductRepository>();
            #endregion

            #region service
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddSingleton<AzureStorageService>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (app.Environment.IsDevelopment())
            //{
                app.UseSwagger();
                app.UseSwaggerUI();
            //}

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
