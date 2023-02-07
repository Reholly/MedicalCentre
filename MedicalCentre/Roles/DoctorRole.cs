using MedicalCentre.Windows;

namespace MedicalCentre.Roles
{
    public class DoctorRole : IRole
    {
        public void ShowCurrentRoleWindow()
        {
            DoctorWindow window = new DoctorWindow();
            window.Show();
        }
    }
}
