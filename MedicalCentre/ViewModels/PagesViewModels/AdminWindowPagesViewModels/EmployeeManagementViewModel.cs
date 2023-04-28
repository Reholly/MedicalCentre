using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.UserControls;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.ViewModels.AdminWindowPagesViewModels;

public class EmployeeManagementViewModel
{
    public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
    public ICommand? SearchCommand { get; set; }
    public ICommand? OpenRegistrationCommand { get; set; }
    public ICommand? OpenNewsCommand { get; set; }

    private EmployeesManagementPage page;
    private IServiceProvider serviceProvider;
    public EmployeeManagementViewModel(EmployeesManagementPage page, IServiceProvider serviceProvider)
    {
        this.page = page;
        this.serviceProvider = serviceProvider;

        SearchCommand = new RelayCommandAsync(SearchItems);
        OpenRegistrationCommand = new RelayCommand(OpenRegistration);
        OpenNewsCommand = new RelayCommand(OpenNews);

        page.Search.TextChanged += OnTextChanged;

        SearchItems();
    }

    private void OpenRegistration()
    {
        EmployeeRegistration employeeRegistration = new(serviceProvider);
        employeeRegistration.Show();
    }

    private async Task SearchItems()
    {
        var empDb = serviceProvider.GetRequiredService<IRepository<Employee>>();

        Employees = new ObservableCollection<Employee>(await Task.Run( () => empDb.GetTableAsync()));
        Employees = new ObservableCollection<Employee>(SearchFilterService<Employee>.GetFilteredList(Employees.ToList(), page.Search.Text));

        page.EmployeesCards.Children.Clear();

        foreach (var employee in Employees)
            page.EmployeesCards.Children.Insert(0, new EmployeeCard(employee));       
    }

    private void OpenNews() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.RickRoll);

    private async void OnTextChanged(object sender, TextChangedEventArgs args) => await Task.Run(SearchItems);   
}
