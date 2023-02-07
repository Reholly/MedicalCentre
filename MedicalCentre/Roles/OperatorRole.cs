using MedicalCentre.Windows;

namespace MedicalCentre.Roles
{
    public class OperatorRole : IRole
    {
        public void ShowCurrentRoleWindow()
        {
            OperatorWindow window = new OperatorWindow();
            window.Show();
        }
    }
}
