﻿using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels.Commands;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.PagesViewModels.DoctorWindowPagesViewModels;

public class AppointmentPageViewModel
{
    public ICommand NotePrintingCommand { get; set; }
    public ICommand AppointmentEndingCommand { get; set; }

    private readonly Appointment appointment;
    private readonly AppointmentPage page;
    private readonly DoctorWindow window;
    private readonly Account account;
    private readonly IServiceProvider serviceProvider;
    private readonly IRepository<Patient> patientsRepository;
    private readonly IRepository<Log> logRepository;
    public AppointmentPageViewModel(Appointment appointment, AppointmentPage page, DoctorWindow window, Account account, IServiceProvider serviceProvider)
    {
        this.appointment = appointment;
        this.page = page;
        this.window = window;
        this.serviceProvider = serviceProvider;
        patientsRepository = serviceProvider.GetRequiredService<IRepository<Patient>>();
        logRepository = serviceProvider.GetRequiredService<IRepository<Log>>();

        NotePrintingCommand = new RelayCommand(PrintNote);
        AppointmentEndingCommand = new RelayCommandAsync(EndAppointment);
        Initialize();
        this.account = account;
    }

    private void Initialize()
    {
        var patient = patientsRepository.GetItemById((uint)appointment.PatientId).ToStringForAppointment();
        page.PatientsSNP.Text = patient;
    }

    private async Task EndAppointment()
    {
        Note note = new((uint)appointment.PatientId, page.AppointmentTitleBox.Text, page.AppointmentTextBox.Text, DateTime.Now);

        
        var patient = await Task.Run(() => patientsRepository.GetItemByIdAsync((uint)appointment.PatientId));
        patient.Notes.Add(note);
        await Task.Run( () => patientsRepository.UpdateItemAsync(patient));

        appointment.IsFinished = true;

        var appDb = serviceProvider.GetRequiredService<IRepository<Appointment>>();
        await Task.Run( () => appDb.UpdateItemAsync(appointment));
        await Task.Run(() => LoggerService.CreateLog($"Приём {appointment.Id} был закончен", true, logRepository));
        window.MainFrame.Content = new DoctorMainPage(window, account, serviceProvider);
    }

    private void PrintNote()
    {
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