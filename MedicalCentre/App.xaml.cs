using MedicalCentre.Authentification;
using System;
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
