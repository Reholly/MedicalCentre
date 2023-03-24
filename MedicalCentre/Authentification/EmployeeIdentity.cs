using System.Security.Principal;


namespace MedicalCentre.Authentification
{
    internal class AccountIdentity : IIdentity
    {
        public string Name { get; private set; }
        public string Role { get; private set; }

        public AccountIdentity(string username, string role)
        {
            Name = username;
            Role = role;
        }

        public string AuthenticationType { get { return "Medical Centre authentication"; } }

        public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }
    }
}
