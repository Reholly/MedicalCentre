using System;
using System.Collections.Generic;

namespace MedicalCentre.Models
{
    public class Patient
    { 
        public uint Id { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Patronymic { get; set; } = null!;
        public DateOnly BirthDate { get; set; }
        public List<MedicalExamination> Examinations { get; set; } = null!;
        public List<Note> Notes { get; set; } = null!;
    }
}
