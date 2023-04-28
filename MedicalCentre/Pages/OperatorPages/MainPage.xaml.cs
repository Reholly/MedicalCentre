using System.Windows.Controls;
using MedicalCentre.ViewModels.PagesViewModels.OperatorWindowPagesViewModels;

namespace MedicalCentre.Pages.OperatorPages;

public partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
        DataContext = new MainPageViewModel(this);
    }
}
