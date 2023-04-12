using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalCentre.ViewModels.AdminWindowPagesViewModels;

public class EmployeeManagementViewModel
{
    public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
    public ICommand? SearchCommand { get; set; }
    public ICommand? OpenRegistrationCommand { get; set; }
    public ICommand? OpenNewsCommand { get; set; }

    private EmployeesManagementPage page;
    private IServiceCollection services;
    public EmployeeManagementViewModel(EmployeesManagementPage page, IServiceCollection services)
    {
        this.page = page;
        this.services = services;

        SearchCommand = new RelayCommandAsync(SearchItems);
        OpenRegistrationCommand = new RelayCommand(OpenRegistration);
        OpenNewsCommand = new RelayCommand(OpenNews);

        page.Search.TextChanged += OnTextChanged;

        SearchItems();
    }

    private void OpenRegistration()
    {
        EmployeeRegistration employeeRegistration = new(services);
        employeeRegistration.Show();
    }

    private async Task SearchItems()
    {
        var empDb = services.BuildServiceProvider().GetRequiredService<IRepository<Employee>>();

        Employees = new ObservableCollection<Employee>(await Task.Run( () => empDb.GetTableAsync()));
        Employees = new ObservableCollection<Employee>(SearchFilterService<Employee>.GetFilteredList(Employees.ToList(), page.Search.Text));

        page.EmployeesCards.Children.Clear();

        foreach (var employee in Employees)
            page.EmployeesCards.Children.Insert(0, new EmployeeCard(employee));       
    }

    private void OpenNews() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.RickRoll);

    private async void OnTextChanged(object sender, TextChangedEventArgs args) => await Task.Run(SearchItems);   
}
