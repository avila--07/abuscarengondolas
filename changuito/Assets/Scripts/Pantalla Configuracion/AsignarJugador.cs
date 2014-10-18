using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// Scripcito que nos permite jugar con la ventana de asignar jugador
/// 
/// </summary>
public class AsignarJugador : MonoBehaviour {

    //REVIEW! yo no subiria esto a produccion ni loco! pero nos sirve para ir probando los servicios.

    public static Boolean isWindowsActive;

    public void OnClick()
    {
        if (!isWindowsActive) 
        {
            this.openWindows();
            this.cleanWindows();
        }
        else
        {
            if (this.gameObject.name.Equals("WindowsPanelAccept"))
            {
                Debug.Log("Usuario que intenta loguearse");
                String pass = GameObject.Find("WindowsPanelPass").GetComponent<UIInput>().value;
                String user = GameObject.Find("WindowsPanelUser").GetComponent<UIInput>().value;
                if (user.Equals("") || pass.Equals(""))
                {
                    NGUISomosUtils.showTextInScreen("WindowsMessage","Debe completar los datos. Vuelva a intentarlo");
                } else {
                    //TODO Validar usuario del lado server par verificar si ya existe. 
                    //REVIEW Tambien se podria definir algunas reglas o caracteres invalidos, etc ...
                    Debug.Log("user:" + user);
                    Debug.Log("pass:" + pass);
                    this.closeWindows();
                }
            }
            else if (this.gameObject.name.Equals("WindowsPanelCerrar"))
            {
                this.closeWindows();
            }
        }
    }

    //Open y Close podrian unificarse ...
    private void closeWindows()
    {
        ConfigurationWindowsManager.instance.window1.SetActive(false);
        CommonsSomosUtils.setActiveRecursively(ConfigurationWindowsManager.instance.window2, true);
        isWindowsActive = false;
    }

    //REVIEW ver de si se puede hacer de una forma mas linda ...
    private void cleanWindows(){
        GameObject.Find("WindowsPanelPass").GetComponent<UIInput>().value = "";
        GameObject.Find("WindowsPanelUser").GetComponent<UIInput>().value ="" ;
        NGUISomosUtils.showTextInScreen("WindowsMessage", "");
    }

    private void openWindows()
    {
        ConfigurationWindowsManager.instance.window1.SetActive(true);
        CommonsSomosUtils.setActiveRecursively(ConfigurationWindowsManager.instance.window2, false);
        isWindowsActive = true;
    }

}
