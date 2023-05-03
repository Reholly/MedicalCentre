using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.FormsViewModels;

public class EmployeeProfileViewModel
{
    public ICommand? CloseCommand { get; set; }
    public ICommand? SaveCommand { get; set; }
    public ICommand? DeleteCommand { get; set; }

    private EmployeeProfileForm profileForm;
    private Employee employee;

    public EmployeeProfileViewModel(EmployeeProfileForm profileForm, Employee employee)
    {
        this.profileForm = profileForm;
        this.employee = employee;

        var accDb = new ContextRepository<Account>();

        CloseCommand = new RelayCommand(Close);
        DeleteCommand = new RelayCommandAsync(Delete);
        SaveCommand = new RelayCommandAsync(Save);

        if (accDb.GetItemById(employee.AccountId).IsOnline) this.profileForm.IsOnline.IsChecked = true;
        else this.profileForm.IsOnline.IsChecked = false;

        this.profileForm.Password.Text = accDb.GetItemById(employee.AccountId).Password;
        this.profileForm.Login.Text = accDb.GetItemById(employee.AccountId).Username;
        this.profileForm.Name.Text = employee.Name;
        this.profileForm.Surname.Text = employee.Surname;
        this.profileForm.Patronymic.Text = employee.Patronymic;
        this.profileForm.Salary.Text = employee.Salary.ToString();
        this.profileForm.Description.Text = employee.Description.ToString();
    }

    private async Task Delete()
    {
        var empDb = new ContextRepository<Employee>();
        var accDb = new ContextRepository<Account>();

        Account account = await accDb.GetItemByIdAsync(employee.AccountId);

        accDb.DeleteItemAsync(account);
        empDb.DeleteItemAsync(employee);

        Close();
    }

    private async Task Save()
    {
        var accDb = new ContextRepository<Account>();
        Account account = await accDb.GetItemByIdAsync(employee.AccountId);
        account.Password = profileForm.Password.Text;
        account.Username = profileForm.Login.Text;

        account.IsOnline = profileForm.IsOnline.IsChecked.Value;

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


        var empDb = new ContextRepository<Employee>();

        accDb.UpdateItemAsync(account);
        empDb.UpdateItemAsync(employee);

        Close();
    }

    private void Close()
    {
        profileForm.Close();
    }
}
