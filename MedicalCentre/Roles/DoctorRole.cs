using MedicalCentre.Windows;

namespace MedicalCentre.Roles
{
    public class DoctorRole : Role
    {
        public override void ShowCurrentRoleWindow()
        {
            DoctorWindow window = new DoctorWindow();
            window.Show();
        }
    }
}
