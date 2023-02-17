using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class TimeTable : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public Employee Employee { get; set; }
        public List<DateTime> Timesheet { get; set; } = null!;

        public TimeTable() { }
        public TimeTable(Employee employee,List<DateTime> timesheet)
        {
            Employee = employee;
            Timesheet = timesheet;  
        }
        public TimeTable(uint id, Employee employee, List<DateTime> timesheet)
        {
            Id = id;
            Employee = employee;
            Timesheet = timesheet;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
