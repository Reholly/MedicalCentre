﻿using System.Security.Principal;

namespace MedicalCentre.Authentification;

public class AccountIdentity : IIdentity
{
    public string Name { get; private set; }
    public Roles Role { get; private set; }
    public string AuthenticationType { get { return "Medical Centre authentication"; } }
    public bool IsAuthenticated { get { return !string.IsNullOrEmpty(Name); } }

    public AccountIdentity(string username, Roles role)
    {
        Name = username;
        Role = role;
    }   
}