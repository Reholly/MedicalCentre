using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace MedicalCentre.ViewModels.AdminWindowPagesViewModels
{
    internal class EmployeeManagementViewModel
    {
        public EmployeeManagementViewModel(DataGrid grid)
        {
            DisplayEmployeeList(grid);
        }
        public void DisplayEmployeeList(DataGrid dataGrid)
        {
            Database<Employee> empDb = new Database<Employee>();
            dataGrid.AutoGenerateColumns = false;

            dataGrid.ItemsSource = empDb.GetTable().Result;

            
            dataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "Id",
                Binding = new Binding($"Data[{0}]")
            });
            dataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "Name",
                Binding = new Binding($"Data[{1}]")
            });
            dataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "Surname",
                Binding = new Binding($"Data[{2}]")
            });
            dataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = "Patronymic",
                Binding = new Binding($"Data[{3}]")
            });

        }
    }
}
