using MedicalCentre.DatabaseLayer;
using MedicalCentre.Models;
using MedicalCentre.ViewModels;
using System;
using System.Windows;

namespace MedicalCentre.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(this);

            var db = new ContextRepository<Transaction>();
            db.AddItem(new Transaction(1, 1000, DateTime.Parse("03-12-2022"), "зарплата", TransactionType.SalaryTransaction));
        }
    }
}   