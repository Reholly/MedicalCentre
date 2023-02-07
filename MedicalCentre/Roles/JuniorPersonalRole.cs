using MedicalCentre.Windows;

namespace MedicalCentre.Roles
{
    public class JuniorPersonalRole : IRole
    {
        public void ShowCurrentRoleWindow()
        {
            JuniorPersonalWindow window = new JuniorPersonalWindow();
            window.Show();
        }
    }
}
