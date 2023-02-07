using MedicalCentre.Windows;

namespace MedicalCentre.Roles
{
    public class SystemAdminRole : IRole
    {
        public void ShowCurrentRoleWindow()
        {
            SystemAdminWindow window = new SystemAdminWindow();
            window.Show();
        }
    }
}
