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
using MedicalCentre.Models;
using MedicalCentre.DatabaseLayer;
using MedicalCentre.Services;

namespace MedicalCentre.Forms
{
    /// <summary>
    /// Логика взаимодействия для DeleteEmployee.xaml
    /// </summary>
    public partial class DeleteEmployee : Window
    {
        public DeleteEmployee()
        {
            InitializeComponent();
        }
        
        public async void Delete(object sender, RoutedEventArgs e)
        {
            try
            {


                ContextRepository<Account> accDb = new ContextRepository<Account>();
                ContextRepository<Employee> empDb = new ContextRepository<Employee>();
                Account currentAccount = accDb.GetItemById(uint.Parse(AccountId.Text.ToString()));
                Employee currentEmployee = empDb.GetItemById(currentAccount.EmployeeAccountId);

                await accDb.DeleteItemAsync(currentAccount);
                await empDb.DeleteItemAsync(currentEmployee);

                LoggerService.CreateLog($"Employee {currentAccount.Id} has been deleted", true);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Неверные данные или проблемы на сервере. В случае последнего сообщите вашему сис.админу и попробуйте позже.");
                LoggerService.CreateLog($"{ex.Message.ToString()}", false);
            }
            Close();
        }
    }
}
