using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MedicalCentre.Models
{
    public class TimeTable : INotifyPropertyChanged
    {
        public uint Id { get; set; }
        public uint EmployeeId { get; set; }
        public List<DateTime> Timesheet { get; set; } = null!;

        public TimeTable() { }
        public TimeTable(uint employeeId,List<DateTime> timesheet)
        {
            EmployeeId = employeeId;
            Timesheet = timesheet;  
        }
        public TimeTable(uint id, uint employeeId, List<DateTime> timesheet)
        {
            Id = id;
            EmployeeId = employeeId;
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
