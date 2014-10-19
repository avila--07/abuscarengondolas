using UnityEngine;
using System.Collections;

public class Login : SharedObject {

    public string User
    {
        get { return GetString("user"); }
        set { Set("user", value); }
    }

    public string Pass
    {
        get { return GetString("pass"); }
        set { Set("pass", value); }
    }

    public Login()
    {

    }
    
    public Login(string user, string pass)
    {
        User = user;
        Pass = pass;
    }

}
