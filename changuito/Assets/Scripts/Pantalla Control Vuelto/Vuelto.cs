﻿using UnityEngine;
using System.Collections;
using System;

public class Vuelto : MonoBehaviour {

    public Boolean soyElCorrecto;

    void OnClick()
    {
        if (soyElCorrecto)
        {
            NGUISomosUtils.showTextInScreen("CVMessageStatus","¡Muy Bien! es el vuelto Correcto!");
            ListadoSingleton.Instance.clean();
            Application.LoadLevel("PantallaFinal");
        }
        else
        {
            NGUISomosUtils.showTextInScreen("CVMessageStatus","Segui intentando!");
        }
    }


}
