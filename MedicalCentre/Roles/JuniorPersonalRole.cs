using MedicalCentre.Windows;

namespace MedicalCentre.Roles
{
    public class JuniorPersonalRole : Role
    {
        public override void ShowCurrentRoleWindow()
        {
            JuniorPersonalWindow window = new JuniorPersonalWindow();
            window.Show();
        }
    }
}
