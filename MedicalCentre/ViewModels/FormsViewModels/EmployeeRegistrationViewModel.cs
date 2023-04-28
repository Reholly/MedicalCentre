using MedicalCentre.Authentification;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.FormsViewModels;

public class EmployeeRegistrationViewModel
{
    public ICommand? RegisterCommand { get; set; }
    public ICommand? CloseCommand { get; set; }

    private Dictionary<string, Roles> roleVariantsToRoles;
    private EmployeeRegistration profile;
    private AuthentificationService authentificationService;
    private IServiceProvider serviceProvider;
            
    private const string DOCTOR_ROLE = "Доктор";
    private const string ADMIN_ROLE = "Администратор";
    private const string OPERATOR_ROLE = "Оператор";
    private const string JUNIOR_ROLE = "Младший мед.персонал";

    public EmployeeRegistrationViewModel(EmployeeRegistration profile, IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;

        this.profile = profile;
        roleVariantsToRoles = new Dictionary<string, Roles>
        {
            { DOCTOR_ROLE, Roles.Doctor },
            { ADMIN_ROLE, Roles.Admin },
            { OPERATOR_ROLE, Roles.Operator },
            { JUNIOR_ROLE, Roles.JuniorPersonal }
        };

        this.authentificationService = serviceProvider.GetRequiredService<AuthentificationService>();

        this.profile.RolesComboBox.ItemsSource = new string[] { DOCTOR_ROLE, ADMIN_ROLE, OPERATOR_ROLE, JUNIOR_ROLE };

        RegisterCommand = new RelayCommandAsync(Register);
        CloseCommand = new RelayCommand(() => profile.Close());
    }

    private async Task Register()
    {
        var empDb = serviceProvider.GetRequiredService<IRepository<Employee>>();

        Random random = new Random();
        uint empId = uint.Parse(random.Next(1, int.MaxValue).ToString());
        uint accId = uint.Parse(random.Next(1, int.MaxValue).ToString());

        Employee employee = new Employee(empId, profile.Name.Text, accId, profile.Surname.Text,
                                        profile.Patronymic.Text, profile.Specialization.Text,
                                        profile.Description.Text, double.Parse(profile.Salary.Text));
        Roles accountRole = GetRoleByString(profile.RolesComboBox.SelectedItem.ToString());

        Account account = new Account(accId, empId, profile.Login.Text, profile.Password.Text, accountRole);

        try
        {
            await authentificationService.RegisterAsync(account);
            await empDb.AddItemAsync(employee);
            await LoggerService.CreateLog($"Регистрация нового сотрудника {account.Id} - {account.Username}", true);
        }
        catch (Exception)
        {
            MessageBox.Show("Неизвестная ошибка в создании аккаунта, попробуйте еще раз");
            await LoggerService.CreateLog($"Ошибка в регистрации нового сотрудника {account.Id} - {account.Username}", false);
            profile.Close();
        }

        profile.Close();
    }

    private Roles GetRoleByString(string role)
    {
        return roleVariantsToRoles[role];
    }
}