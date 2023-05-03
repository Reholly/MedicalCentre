using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MedicalCentre.Authentification;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Forms;
using MedicalCentre.Models;
using MedicalCentre.Services;
using MedicalCentre.ViewModels.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace MedicalCentre.ViewModels.FormsViewModels;

public class EmployeeRegistrationFormViewModel
{
    public ICommand RegisterCommand { get; set; }
    public ICommand CloseCommand { get; set; }

    private readonly Dictionary<string, Roles> roleVariantsToRoles;
    private readonly EmployeeRegistrationForm profile;
    private readonly AuthentificationService authentificationService;
    private readonly IServiceProvider serviceProvider;
            
    private const string DOCTOR_ROLE = "Доктор";
    private const string ADMIN_ROLE = "Администратор";
    private const string OPERATOR_ROLE = "Оператор";
    private const string JUNIOR_ROLE = "Младший мед.персонал";

    public EmployeeRegistrationFormViewModel(EmployeeRegistrationForm profile, IServiceProvider serviceProvider)
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

        this.profile.RolesComboBox.ItemsSource = new[] { DOCTOR_ROLE, ADMIN_ROLE, OPERATOR_ROLE, JUNIOR_ROLE };

        RegisterCommand = new RelayCommandAsync(Register);
        CloseCommand = new RelayCommand(() => profile.Close());
    }

    private async Task Register()
    {
        var empDb = serviceProvider.GetRequiredService<IRepository<Employee>>();
        var logDb = serviceProvider.GetRequiredService<IRepository<Log>>();

        var random = new Random();
        var empId = uint.Parse(random.Next(1, int.MaxValue).ToString());
        var accId = uint.Parse(random.Next(1, int.MaxValue).ToString());

        var employee = new Employee(empId, profile.Name.Text, accId, profile.Surname.Text,
                                        profile.Patronymic.Text, profile.Specialization.Text,
                                        profile.Description.Text, double.Parse(profile.Salary.Text));
        var accountRole = GetRoleByString(profile.RolesComboBox.SelectedItem.ToString()!);

        var account = new Account(accId, empId, profile.Login.Text, profile.Password.Text, accountRole);

        try
        {
            await authentificationService.RegisterAsync(account);
            await empDb.AddItemAsync(employee);
            await LoggerService.CreateLog($"Регистрация нового сотрудника {account.Id} - {account.Username}", true, logDb);
        }
        catch (Exception)
        {
            MessageBox.Show("Неизвестная ошибка в создании аккаунта, попробуйте еще раз");
            await LoggerService.CreateLog($"Ошибка в регистрации нового сотрудника {account.Id} - {account.Username}", false, logDb);
            profile.Close();
        }

        profile.Close();
    }

    private Roles GetRoleByString(string role)
    {
        return roleVariantsToRoles[role];
    }
}