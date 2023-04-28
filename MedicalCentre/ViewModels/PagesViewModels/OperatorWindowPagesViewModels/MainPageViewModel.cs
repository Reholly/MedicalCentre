using System.Windows.Input;
using MedicalCentre.Forms;
using MedicalCentre.Pages.OperatorPages;
using MedicalCentre.Services;
using MedicalCentre.ViewModels.Commands;

namespace MedicalCentre.ViewModels.PagesViewModels.OperatorWindowPagesViewModels;

public class MainPageViewModel
{
    public ICommand OpenNewsCommand { get; set; }
    public ICommand OpenNewFeaturesCommand { get; set; }
    public ICommand WriteCommand { get; set; }
    public ICommand CreateCommand { get; set; }

    private MainPage currentPage;

    public MainPageViewModel(MainPage page)
    {
        this.currentPage = page;
        OpenNewsCommand = new RelayCommand(OpenNews);
        OpenNewFeaturesCommand = new RelayCommand(OpenNewFeatures);
        CreateCommand = new RelayCommand(Create);
        WriteCommand = new RelayCommand(Write);
    }

    private void OpenNews() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.OpenInvalidSite);
    
    private void OpenNewFeatures() => OpenBrowserService.OpenPageInBrowser(Properties.Settings.Default.NewFeatures);
    

    private void Create()
    {
        AppointmentCreatingForm window = new AppointmentCreatingForm();
        window.Show();
    }

    private void Write()
    {
        WriteAppointment window = new WriteAppointment();
        window.Show();
    }
}