using MedicalCentre.Windows;

namespace MedicalCentre.Roles
{
    public class OperatorRole : Role
    {
        public override void ShowCurrentRoleWindow()
        {
            OperatorWindow window = new OperatorWindow();
            window.Show();
        }
    }
}
