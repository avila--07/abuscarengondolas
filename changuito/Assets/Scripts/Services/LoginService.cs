using UnityEngine;
using System.Collections;
using System;

public class LoginService  {

    public static void Call(Login dataUser, Action<Login, Exception> originalCallback)
    {
        ServiceManager.Instance.NewService("ls").
                WithSecondsTimeout(30).
                WithMaxRetries(3).
                Call(dataUser, originalCallback);
    }

}
