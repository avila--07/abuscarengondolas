using UnityEngine;
using System.Collections;
using System;

public class ChanguitoConfiguration : MonoBehaviour
{
	public static bool ModuloPago = false;
    public static bool ModuloControlVuelto = false;
    public static int CantidadGondolas=2;
	//public static string ServerURL = "http://acomprarconchanguito.appspot.com/ChanguitoServices";
	public static string ServerURL = "http://localhost:80/ChanguitoServices";
    public static DateTime gameStartDate;

    public static int getCantidadModulos()
    {
        //REVIEW: No haga esto en su casa :P
        return 2 + (ModuloPago.Equals(true) ? 1 : 0) 
        + (ModuloControlVuelto.Equals(true) ? 1 : 0); 
    }
}
