using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.FormsViewModels;

public class EmployeeProfileViewModel
{
    public ICommand CloseCommand { get; set; }
    public ICommand SaveCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    private readonly EmployeeProfileForm profileForm;
    private readonly Employee employee;
    private readonly IServiceProvider provider;

    public EmployeeProfileViewModel(EmployeeProfileForm profileForm, Employee employee, IServiceProvider provider)
    {
        this.profileForm = profileForm;
        this.employee = employee;
        this.provider = provider;

        var accDb = this.provider.GetRequiredService<IRepository<Account>>();

        CloseCommand = new RelayCommand(Close);
        DeleteCommand = new RelayCommandAsync(Delete);
        SaveCommand = new RelayCommandAsync(Save);

        this.profileForm.IsOnline.IsChecked = accDb.GetItemById(employee.AccountId).IsOnline;

        this.profileForm.Password.Text = accDb.GetItemById(employee.AccountId).Password;
        this.profileForm.Login.Text = accDb.GetItemById(employee.AccountId).Username;
        this.profileForm.Name.Text = employee.Name;
        this.profileForm.Surname.Text = employee.Surname;
        this.profileForm.Patronymic.Text = employee.Patronymic;
        this.profileForm.Salary.Text = employee.Salary.ToString(CultureInfo.InvariantCulture);
        this.profileForm.Description.Text = employee.Description;
    }

    private async Task Delete()
    {
        var empDb = new ContextRepository<Employee>();
        var accDb = new ContextRepository<Account>();

        Account account = await accDb.GetItemByIdAsync(employee.AccountId);

        await Task.Run(() => accDb.DeleteItemAsync(account));
        await Task.Run(() => empDb.DeleteItemAsync(employee));

        Close();
    }

    private async Task Save()
    {
        var accDb = provider.GetRequiredService<IRepository<Account>>();
        var account = await accDb.GetItemByIdAsync(employee.AccountId);
        account.Password = profileForm.Password.Text;
        account.Username = profileForm.Login.Text;

        account.IsOnline = profileForm.IsOnline.IsChecked!.Value;

        employee.Name = profileForm.Name.Text;
        employee.Surname = profileForm.Surname.Text;
        employee.Patronymic = profileForm.Patronymic.Text;
        try
        {
            employee.Salary = double.Parse(profileForm.Salary.Text);
        }
        catch (Exception)
        {
            MessageBox.Show("Зарплата должна быть числом. Попробуйте позже.");
        }
        employee.Description = profileForm.Description.Text;


        var empDb = provider.GetRequiredService<IRepository<Employee>>();

        await Task.Run(() => accDb.UpdateItemAsync(account));
        await Task.Run(() => empDb.UpdateItemAsync(employee));

        Close();
    }

    private void Close()
    {
        profileForm.Close();
    }
}
