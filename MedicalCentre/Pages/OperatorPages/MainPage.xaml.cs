using MedicalCentre.ViewModels.OperatorWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.OperatorPages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel(this);
        }
    }
}
