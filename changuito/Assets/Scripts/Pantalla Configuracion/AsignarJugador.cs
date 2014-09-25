using UnityEngine;
using System.Collections;
using System;

public class AsignarJugador : MonoBehaviour {

    public static Boolean isWindowsActive;

    public void OnClick()
    {
        if (!isWindowsActive) { 
            ConfigurationWindowsManager.instance.window1.SetActive(true);
            ConfigurationWindowsManager.instance.window2.SetActive(false);
            isWindowsActive = true;
        }
        else
        {
            ConfigurationWindowsManager.instance.window1.SetActive(false);
            ConfigurationWindowsManager.instance.window2.SetActive(true);
            isWindowsActive = false;
        }
    }
}
