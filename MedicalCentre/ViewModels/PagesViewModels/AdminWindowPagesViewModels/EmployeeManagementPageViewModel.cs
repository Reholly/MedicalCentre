﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Pages.AdminWindowPages;
using MedicalCentre.Services;
using MedicalCentre.UserControls;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.PagesViewModels.AdminWindowPagesViewModels;

public class EmployeeManagementPageViewModel
{
    private ObservableCollection<Employee> Employees { get; set; } = new();
    public ICommand SearchCommand { get; set; }
    public ICommand OpenRegistrationCommand { get; set; }
    public ICommand OpenNewsCommand { get; set; }

    private readonly EmployeesManagementPage page;
    private readonly IServiceProvider serviceProvider;
    public EmployeeManagementPageViewModel(EmployeesManagementPage page, IServiceProvider serviceProvider)
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
        EmployeeRegistrationForm employeeRegistrationForm = new(serviceProvider);
        employeeRegistrationForm.Show();
    }

    private async Task SearchItems()
    {
        var empDb = serviceProvider.GetRequiredService<IRepository<Employee>>();

        var employees = await Task.Run(() => empDb.GetTableAsync());

        Employees = new ObservableCollection<Employee>(employees);
        Employees = new ObservableCollection<Employee>(SearchFilterService<Employee>.GetFilteredList(Employees.ToList(), page.Search.Text));

        page.EmployeesCards.Children.Clear();

        foreach (var employee in Employees)
            page.EmployeesCards.Children.Insert(0, new EmployeeCard(employee, serviceProvider));       
    }

    private void OpenNews() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.RickRoll);

    private void OnTextChanged(object sender, TextChangedEventArgs args) => Task.Run(SearchItems);   
}
