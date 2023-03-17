using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.UserControls;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.AdminWindowPagesViewModels
{
    public class EmployeeManagementViewModel
    {
        public ObservableCollection<Employee> Employees { get; set; } = new();
        public ICommand? SearchCommand { get; set; }
        public ICommand? OpenRegistrationCommand { get; set; }
        public ICommand? OpenNewsCommand { get; set; }

        private EmployeesManagementPage page;
        public EmployeeManagementViewModel(EmployeesManagementPage page)
        {
            this.page = page;
            SearchCommand = new RelayCommandAsync(SearchItems);

            OpenRegistrationCommand = new RelayCommand(OpenRegistration);        
            OpenNewsCommand = new RelayCommand(OpenNews);
            page.Search.TextChanged += OnTextChanged;

            
            SearchItems();
        }

        public void OpenNews()
        {
            OpenBrowserService.OpenPageInBrowser("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }

        public void OpenRegistration()
        {
            EmployeeRegistration employeeRegistration = new();
            employeeRegistration.Show();
        }

        public async Task SearchItems()
        {
            ContextRepository<Employee> empDb = new();
            Employees = new ObservableCollection<Employee>( await empDb.GetTableAsync());
            Employees = new ObservableCollection<Employee>(SearchFilterService<Employee>.GetFilteredList(Employees.ToList(), page.Search.Text));
            page.EmployeesCards.Children.Clear();
            foreach(var employee in Employees)
            {
                page.EmployeesCards.Children.Insert(0, new EmployeeCard(employee));
            }     
        }

        private void OnTextChanged(object sender, TextChangedEventArgs args)
        {
            SearchItems();      
        }
    }
}