
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TicketManager.API.Persistence;
using TicketManager.API.Services;

namespace TicketManager.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            //register services
            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IDeveloperService, DeveloperService>();
            builder.Services.AddScoped<ILoginService, LoginService>();
            //add database connection
            var connection = builder.Configuration.GetConnectionString("DatabaseConnection");
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //register database context
            builder.Services.AddDbContext<TicketManagerDbContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            var app = builder.Build();
            {
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.UseExceptionHandler("/error");
                app.UseHttpsRedirection();
                app.UseAuthorization();
                app.MapControllers();
                app.Run();
            }
        }
    }
}
