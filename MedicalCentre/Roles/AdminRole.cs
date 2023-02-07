using MedicalCentre.Windows;

namespace MedicalCentre.Roles
{
    public class AdminRole : IRole
    {
        public void ShowCurrentRoleWindow()
        {
            AdminWindow window = new AdminWindow();
            window.Show();
        }
    }
}
