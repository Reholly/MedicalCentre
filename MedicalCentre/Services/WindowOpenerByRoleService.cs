﻿using MedicalCentre.Authentification;
using MedicalCentre.DatabaseLayer;
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
        IRepository<Log> logRepository = serviceProvider.GetRequiredService<IRepository<Log>>();

        switch (currentAccount.Role)
        {
            case Roles.Doctor:
                var doctor = new DoctorWindow(currentAccount, serviceProvider);
                doctor.Show();
                break;
            case Roles.Admin:
                var admin = new AdminWindow(currentAccount, serviceProvider);
                admin.Show();
                break;
            case Roles.Operator:
                var operatorWindow = new OperatorWindow(currentAccount, serviceProvider);
                operatorWindow.Show();
                break;
            case Roles.JuniorPersonal:
                var juniorPersonal = new JuniorPersonalWindow(currentAccount, serviceProvider);
                juniorPersonal.Show();
                break;
            default:
                await Task.Run(() => LoggerService.CreateLog("Неверно указана роль.", false, logRepository));
                MessageBox.Show("Проблемы с получением роли. Перезайдите и выполните вход заново или свяжитесь с сис.админом");
                break;
        }
    }
}