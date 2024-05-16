using Microsoft.EntityFrameworkCore;
using RequestTrackerAPI.Contexts;
using RequestTrackerAPI.Interfaces;
using RequestTrackerAPI.Models;
using RequestTrackerAPI.Repositiories;
using RequestTrackerAPI.Services;

namespace RequestTrackerAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region contexts
            builder.Services.AddDbContext<RequestTrackerContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
            });
            #endregion

            #region repository
            builder.Services.AddScoped<IRepository<int, Employee>, EmployeeRepository>();
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            #endregion

            #region services
            builder.Services.AddScoped<IUserService, UserServices>();
            #endregion

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
