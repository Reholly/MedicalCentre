﻿using MedicalCentre.Pages.AdminWindowPages;
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
        public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();

            MainFrame.Content = new Analytics();
        }

        private void CloseIcon_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        public void OpenEmployeesPage(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("AAAA");
            MainFrame.Content = new EmployeesManagement();
        }
    }
}
