using MedicalCentre.Windows;

namespace MedicalCentre.Roles
{
    public class SystemAdminRole : Role
    {
        public override void ShowCurrentRoleWindow()
        {
            SystemAdminWindow window = new SystemAdminWindow();
            window.Show();
        }
    }
}
