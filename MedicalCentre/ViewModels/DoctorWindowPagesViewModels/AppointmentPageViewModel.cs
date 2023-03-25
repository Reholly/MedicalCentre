using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using MedicalCentre.Windows;
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
        private readonly Appointment _appointment;
        private readonly AppointmentPage _page;
        private readonly DoctorWindow _window;
        private readonly Account _account;
        private readonly ContextRepository<Patient> _repositoryPatients;
        private readonly ContextRepository<Appointment> _repositoryAppointments;
        public ICommand NotePrintingCommand { get; set; }
        public ICommand AppointmentEndingCommand { get; set; }
        public AppointmentPageViewModel(Appointment appointment, AppointmentPage page, DoctorWindow window, Account account)
        {
            this._appointment = appointment;
            this._page = page;
            this._window = window;
            NotePrintingCommand = new RelayCommand(PrintNote);
            AppointmentEndingCommand = new RelayCommandAsync(EndAppointment);
            Initialize();
            this._account = account;
            _repositoryPatients = new ContextRepository<Patient>();
            _repositoryAppointments = new ContextRepository<Appointment>();
        }

        private async Task Initialize()
        {
            Patient patient = await _repositoryPatients.GetItemByIdAsync((uint)_appointment.PatientId);
            var patientString = patient.ToStringForAppointment();
            _page.PatientsSNP.Text = patientString;
        }

        private async Task EndAppointment()
        {
            Note note = new((uint)_appointment.PatientId, _page.AppointmentTitleBox.Text, _page.AppointmentTextBox.Text, DateTime.Now);
            Patient patient = await _repositoryPatients.GetItemByIdAsync((uint)_appointment.PatientId);
            patient.Notes.Add(note);
            await _repositoryPatients.UpdateItemAsync(patient);

            _appointment.IsFinished = true;
            _window.MainFrame.Content = new DoctorMainPage(_window, _account);

            await _repositoryAppointments.UpdateItemAsync(_appointment);
            await LoggerService.CreateLog($"Приём {_appointment.Id} был закончен", true);
        }

        private void PrintNote()
        {
            //OpenBrowserService.OpenPageInBrowser("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
            PrintDialog printDialog = new();
            if (printDialog.ShowDialog() == true)
            {
                Run title = new(_page.AppointmentTitleBox.Text);
                Run text = new(_page.AppointmentTextBox.Text);

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