using MedicalCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.UserControls.ViewModels
{
    public class AppointmentCardViewModel
    {
        private readonly AppointmentCard card;
        private readonly Appointment appointment;
        public AppointmentCardViewModel(AppointmentCard card, Appointment appointment)
        {
            this.card = card;
            this.appointment = appointment;
        }
    }
}