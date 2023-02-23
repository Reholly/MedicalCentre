using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
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

namespace MedicalCentre.Forms
{
    /// <summary>
    /// Логика взаимодействия для RegisterEmployee.xaml
    /// </summary>
    public partial class RegisterEmployeeForm : Window
    {
        public RegisterEmployeeForm()
        {
            InitializeComponent();
            
        }

        private async void Register(object sender, RoutedEventArgs e)
        {
            try
            {
                AuthentificatorService auth = new AuthentificatorService(new AuthentificationService());
                Database<Employee> empDb = new Database<Employee>();
                Database<Account> accDb = new Database<Account>();

                Employee newEmployee = new Employee(uint.Parse(EmployeeId.Text),
                                            Name.Text,
                                            Surname.Text,
                                            Patronymic.Text,
                                            Specialization.Text,
                                            double.Parse(Salary.Text),
                                            uint.Parse(RoleId.Text));
                Account newAccount = new Account(uint.Parse(AccountId.Text),
                                                    empDb.GetItemById(uint.Parse(EmployeeInAccountId.Text)).Result, 
                                                    Password.Password);

                
                
                async Task AddAccAsync()
                {
                    accDb.AddItem(newAccount);
                }
                async Task AddEmpAsync()
                {
                    empDb.AddItem(newEmployee);
                }
                var task2 = AddEmpAsync();
                var task1 = AddAccAsync();        
                await Task.WhenAll(task1, task2);
                

                Result result = auth.Register(uint.Parse(AccountId.Text), Password.Password, empDb.GetItemById(uint.Parse(EmployeeInAccountId.Text)).Result).Result;
                if (result != Result.Success)
                {
                    MessageBox.Show("Ошибка!");
                    Close();
                }

                MessageBox.Show(result.ToString());

                Close();
                                           
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
