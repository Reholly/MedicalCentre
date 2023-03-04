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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MedicalCentre.Pages.SystemAdminPages
{
    /// <summary>
    /// Логика взаимодействия для DatabaseSettings.xaml
    /// </summary>
    public partial class DatabaseSettings : Page
    {
        public DatabaseSettings()
        {
            InitializeComponent();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            ConnectionString.Text = Properties.Settings.Default.ConnStr;
  
        }
    }
}
