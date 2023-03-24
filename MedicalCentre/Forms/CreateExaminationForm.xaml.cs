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
using MedicalCentre.Forms.ViewModels;

namespace MedicalCentre.Forms
{
    public partial class CreateExaminationForm : Window
    {
        public CreateExaminationForm()
        {
            InitializeComponent();
            DataContext = new CreateExaminationFormViewModel(this);
        }
    }
}