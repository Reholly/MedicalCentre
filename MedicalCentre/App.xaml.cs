using MedicalCentre.Authentification;
using MedicalCentre.ViewModels;
using MedicalCentre.Windows;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MedicalCentre
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AccountPrincipal employeePrincipal = new AccountPrincipal();
            AppDomain.CurrentDomain.SetThreadPrincipal(employeePrincipal);

            base.OnStartup(e);
        }
    }
}
