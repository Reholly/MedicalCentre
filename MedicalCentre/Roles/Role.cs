namespace MedicalCentre.Roles
{
    public abstract class Role
    {
        public uint Id { get; set; }
        public abstract void ShowCurrentRoleWindow();
    }
}
