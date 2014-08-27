using System;
using UnityEngine;
using System.Collections;

public class GoToSeleccionProducto : MonoBehaviour
{

    private bool popUp;

    void start()
    {
        this.popUp = false;
    }

    void OnMouseDown()
    {
        this.popUp = true;
        Application.LoadLevelAdditive("PantallaSeleccionProducto");
    }


    // Dibuja si y solo si esta activo el popUp (Cuando se efectua OnMouseDown)
    /*void OnGUI()
    {
        if (this.popUp)
        {
            GUI.Window(0, new Rect(Screen.width / 2 - 700, Screen.height / 2 - 100, 400, 120), DoMyWindow, "Notice:");
        }
    }*/

    void DoMyWindow(int windowID)
    {
        Application.LoadLevelAdditiveAsync("PantallaSeleccionProducto");
        Destroy(this);
    }

}
