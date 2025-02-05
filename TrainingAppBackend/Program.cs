
using System.Reflection;
using TrainingAppBackend.Context;
using TrainingAppBackend.Repositories;
using TrainingAppBackend.Services;

namespace TrainingAppBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  policy =>
                                  {
                                      policy.WithOrigins("http://localhost:4200").
                                      AllowAnyMethod()
                                      .AllowAnyHeader();
                                  });
            });

            // Add services to the container.
            builder.Configuration.AddEnvironmentVariables();
            builder.Configuration.AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true);

            //Repos
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            //Services
            builder.Services.AddScoped<WeatherForecastService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ApplicationDbContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
