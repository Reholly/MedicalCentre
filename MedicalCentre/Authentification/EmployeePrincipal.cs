using System.Security.Principal;

namespace MedicalCentre.Authentification
{
    internal class AccountPrincipal : IPrincipal
    {
        private AccountIdentity identity;

        public AccountIdentity Identity
        {
            get { return identity; }
            set { identity = value; }
        }

        IIdentity IPrincipal.Identity
        {
            get { return this.Identity; }
        }

        public bool IsInRole(string role)
        {
            return identity.Role == role;
        }
    }
}
