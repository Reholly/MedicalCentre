using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCentre.Models
{
    public class Patient
    {
        public string PhoneNumber { get; }
        public uint Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string? Patronymic { get; }
        public DateOnly BirthDate { get; }
        public List<MedicalExamination>? Examinations { get; private set; }
        public List<Note>? Notes { get; private set; }
    }
}
