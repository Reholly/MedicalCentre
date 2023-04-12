using MedicalCentre.ViewModels.OperatorWindowPagesViewModels;
using System.Windows.Controls;

namespace MedicalCentre.Pages.OperatorPages;

public partial class MainPage : Page
{
    public MainPage()
    {
        InitializeComponent();
        DataContext = new MainPageViewModel(this);
    }
}
