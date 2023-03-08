using System;
using System.Timers;
using MedicalCentre.TelegramBot.Models;
using Timer = System.Timers.Timer;

namespace MedicalCentre.TelegramBot.Notifacations
{
    internal class TimerNotification
    {
        private Timer timer { get; set; }
        private DateTime dateTime { get; set; }

        private TimeSpan timeOfNotifacation { get; set; }

        public TimerNotification(TimeSpan timeOfNotifacation)
        {
            this.timeOfNotifacation = timeOfNotifacation;
        }

        public void StartTimer()
        {
            dateTime = DateTime.Now;
            TimeSpan timeToNotificate = GetTimeToNotification(timeOfNotifacation, dateTime);
            Logger.Log("Timer was start!");
            Logger.Log($"Time to next Notifacate: {timeToNotificate.Hours}h {timeToNotificate.Minutes}m {timeToNotificate.Seconds}s");
            timer = new Timer(timeToNotificate.TotalMilliseconds);
            timer.Elapsed += UpdateTimer;
            timer.AutoReset = false;
            timer.Start();
        }

        private TimeSpan GetTimeToNotification(TimeSpan timeOfNotifacation, DateTime dateTime)
        {
            long timeDayInMs = (long)dateTime.TimeOfDay.TotalMilliseconds;
            if (timeDayInMs > timeOfNotifacation.TotalMilliseconds)
            {
                return TimeSpan.FromMilliseconds(TimeSpan.FromDays(1).TotalMilliseconds - (long)Math.Abs(timeDayInMs - timeOfNotifacation.TotalMilliseconds));
            }
            else
            {
                return TimeSpan.FromMilliseconds(Math.Abs(timeDayInMs - timeOfNotifacation.TotalMilliseconds));
            }
        }

        private async void UpdateTimer(object sender, ElapsedEventArgs e)
        {
            Logger.Log("Timer was click!");
            Notifayer notifayer = new Notifayer();
            await notifayer.SendAllNotifacates();
            dateTime.AddDays(1);
            timer = new Timer(TimeSpan.FromDays(1).TotalMilliseconds);
            timer.Elapsed += UpdateTimer;
            timer.Start();
        }
    }
}
