using MedicalCentre.Windows;

namespace MedicalCentre.Roles
{
    public class AdminRole : Role
    {
        public override void ShowCurrentRoleWindow()
        {
            AdminWindow window = new AdminWindow();
            window.Show();
        }
    }
}
