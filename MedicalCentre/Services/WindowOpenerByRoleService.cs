using MedicalCentre.Authentification;
using MedicalCentre.Models;
using MedicalCentre.Views;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalCentre.Services;

public static class WindowOpenerByRoleService
{
    public static async Task OpenWindowByRole(Account currentAccount, IServiceProvider serviceProvider)
    {
        AuthentificationService authentificationService = serviceProvider.GetRequiredService<AuthentificationService>();

        switch (currentAccount.Role)
        {
            case Roles.Doctor:
                DoctorWindow doctor = new DoctorWindow(currentAccount, serviceProvider);
                doctor.Show();
                break;
            case Roles.Admin:
                AdminWindow admin = new AdminWindow(currentAccount, serviceProvider);
                admin.Show();
                break;
            case Roles.Operator:
                OperatorWindow operatorWindow = new OperatorWindow(currentAccount, serviceProvider);
                operatorWindow.Show();
                break;
            case Roles.JuniorPersonal:
                JuniorPersonalWindow juniorPersonal = new JuniorPersonalWindow(currentAccount, serviceProvider);
                juniorPersonal.Show();
                break;
            default:
                await LoggerService.CreateLog("Неверно указана роль.", false);
                MessageBox.Show("Проблемы с получением роли. Перезайдите и выполните вход заново или свяжитесь с сис.админом");
                break;
        }
    }
}