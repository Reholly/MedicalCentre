using System.Security.Principal;

namespace MedicalCentre.Authentification;

public class AccountPrincipal : IPrincipal
{
    IIdentity IPrincipal.Identity
    {
        get { return this.Identity; }
    }
    public bool IsInRole(string role)
    {
        return identity.Role.ToString() == role;
    }

    private AccountIdentity identity;

    public AccountIdentity Identity
    {
        get { return identity; }
        set { identity = value; }
    }
}