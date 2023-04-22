using System.Security.Principal;

namespace MedicalCentre.Authentification;

public class AccountPrincipal : IPrincipal
{
    IIdentity IPrincipal.Identity => this.Identity; 

    public bool IsInRole(string role) =>  Identity.Role.ToString() == role;  

    public AccountIdentity Identity { get; set; }
}