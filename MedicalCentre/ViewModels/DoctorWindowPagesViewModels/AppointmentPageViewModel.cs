using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using MedicalCentre.Views;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class AppointmentPageViewModel
    {
        private readonly Appointment appointment;
        private readonly AppointmentPage page;
        private readonly DoctorWindow window;
        private readonly Account account;
        public ICommand NotePrintingCommand { get; set; }
        public ICommand AppointmentEndingCommand { get; set; }
        public AppointmentPageViewModel(Appointment appointment, AppointmentPage page, DoctorWindow window, Account account)
        {
            this.appointment = appointment;
            this.page = page;
            this.window = window;
            NotePrintingCommand = new RelayCommand(PrintNote);
            AppointmentEndingCommand = new RelayCommandAsync(EndAppointment);
            Initialize();
            this.account = account;
        }

        private void Initialize()
        {
            string patient = new ContextRepository<Patient>().GetItemById((uint)appointment.PatientId).ToStringForAppointment();
            page.PatientsSNP.Text = patient;
        }

        private async Task EndAppointment()
        {
            Note note = new((uint)appointment.PatientId, page.AppointmentTitleBox.Text, page.AppointmentTextBox.Text, DateTime.Now);
            Patient patient = await new ContextRepository<Patient>().GetItemByIdAsync((uint)appointment.PatientId);
            patient.Notes.Add(note);
            await new ContextRepository<Patient>().UpdateItemAsync(patient);

            appointment.IsFinished = true;
            window.MainFrame.Content = new DoctorMainPage(window, account);

            new ContextRepository<Appointment>().UpdateItemAsync(appointment);
            await LoggerService.CreateLog($"Приём {appointment.Id} был закончен", true);
        }

        private void PrintNote()
        {
            //OpenBrowserService.OpenPageInBrowser("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            PrintDialog printDialog = new();
            if (printDialog.ShowDialog() == true)
            {
                Run title = new(page.AppointmentTitleBox.Text);
                Run text = new(page.AppointmentTextBox.Text);

                TextBlock textBlock = new();
                textBlock.Inlines.Add(title);
                textBlock.Inlines.Add("\n");
                textBlock.Inlines.Add(text);

                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Margin = new Thickness(5);
                textBlock.TextWrapping = TextWrapping.Wrap;
                textBlock.LayoutTransform = new ScaleTransform(1.5, 1.5);

                Size pageSize = new(printDialog.PrintableAreaWidth, printDialog.PrintableAreaHeight);
                textBlock.Measure(pageSize);
                textBlock.Arrange(new Rect(0, 0, pageSize.Width, pageSize.Height));

                printDialog.PrintVisual(textBlock, "");
            }
        }
    }
}