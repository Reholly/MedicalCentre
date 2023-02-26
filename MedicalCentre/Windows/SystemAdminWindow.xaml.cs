using MedicalCentre.Models;
using MedicalCentre.Pages.SystemAdminPages;
using MedicalCentre.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MedicalCentre.Windows
{
    /// <summary>
    /// Логика взаимодействия для SystemAdminWindow.xaml
    /// </summary>
    public partial class SystemAdminWindow : Window
    {
        public SystemAdminWindow(uint employeeId)
        {
            InitializeComponent();

            EmployeeNameBinderService.BindName(employeeId, RoleName, EmployeeName);
        }
        private void CloseIcon_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Open_LogsPanel(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new LogsPanel();
        }

        private void Open_DatabaseSettings(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new DatabaseSettings();
        }
    }
}
