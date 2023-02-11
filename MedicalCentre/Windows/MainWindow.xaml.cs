﻿using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
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

namespace MedicalCentre.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DatabaseInteraction db = new DatabaseInteraction();

            var emp = new Employee(10, "Хрен", "Вай", "Ойой", "Уролог", 10500, new Role("Doctor"));
            
            Database<Employee> database = new Database<Employee>();
            Employee mp = database.GetTable().Find(p => p.Id == emp.Id);

            MessageBox.Show(mp.Id.ToString());
            

        }
    }
}   
