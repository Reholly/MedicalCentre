using System.Windows.Controls;
using MedicalCentre.ViewModels.AdminWindowPagesViewModels;

namespace MedicalCentre.Pages.AdminWindowPages
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();;

            DataContext = new MainPageViewModel(this);
        }    
    }
}

