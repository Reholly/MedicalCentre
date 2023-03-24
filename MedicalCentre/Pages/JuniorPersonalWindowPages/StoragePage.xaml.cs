using MedicalCentre.ViewModels.JuniorPersonalWindowPagesViewModel;
using System.Windows.Controls;

namespace MedicalCentre.Pages.GeneralPages
{
    public partial class StoragePage : Page
    {
        public StoragePage()
        {
            InitializeComponent();
            DataContext = new JuniorPersonalMainPageViewModel();
        }
    }
}