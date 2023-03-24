using MedicalCentre.ViewModels.AdminWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.AdminWindowPages
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent(); ;

            DataContext = new MainPageViewModel(this);
        }
    }
}

