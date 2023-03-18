using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.Pages.DoctorWindowPages;
using MedicalCentre.UserControls;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MedicalCentre.ViewModels.DoctorWindowPagesViewModels
{
    public class DoctorMainPageViewModel
    {
        private readonly MainPage page;
        public ObservableCollection<Appointment> Appointments { get; set; } = new();
        public DoctorMainPageViewModel(MainPage page)
        {
            this.page = page;
            ShowCards();
        }

        private void ShowCards()
        {
            ContextRepository<Appointment> repository = new();
            List<Appointment> appointments = repository.GetTable();
            foreach (Appointment appointment in appointments)
            {
                page.AppointmentCards.Children.Insert(0, new AppointmentCard(appointment, page, "testP", "testD"));
            }
        }
    }
}