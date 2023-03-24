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
using MedicalCentre.ViewModels;

namespace MedicalCentre.Windows
{
    public partial class JuniorPersonalWindow : Window
    {
        public JuniorPersonalWindow(Account account)
        {
            InitializeComponent();
            DataContext = new JuniorPersonalViewModel(this, account);
        }
    }
}