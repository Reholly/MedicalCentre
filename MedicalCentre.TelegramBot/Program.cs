using MedicalCentre.TelegramBot.Models;
using MedicalCentre.TelegramBot.Notifacations;

namespace MedicalCentre.TelegramBot;

public class Program
{
    public static IConfiguration Configuration { get; } =
        new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true)
        .AddEnvironmentVariables()
        .Build();

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Configuration.AddConfiguration(Configuration);
        AppSetings.Token = builder.Configuration["BotToken"];
        if(AppSetings.Token == null)
        {
            Logger.Log("Token is null");
            return;
        }
        // Add services to the container.

        builder.Services.AddControllers().AddNewtonsoftJson();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        TimerNotification timer = new TimerNotification(AppSetings.TimeOfNotification);
        timer.StartTimer();

        app.Run();
    }
}