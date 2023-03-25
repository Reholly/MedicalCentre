using MedicalCentre.TelegramBot.Notifacations;

namespace MedicalCentre.TelegramBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
}