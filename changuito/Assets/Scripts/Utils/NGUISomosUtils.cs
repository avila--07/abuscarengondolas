using UnityEngine;
using System.Collections;

public static class NGUISomosUtils
{
    /// <summary>
    /// Cambia un UILabel en pantalla
    /// Util por si queremos modificar valores de los label dinamicamente
    /// </summary>
	public static void showTextInScreen(string objectLabel, string text){
        GameObject objectInScreen = GameObject.Find(objectLabel);
        objectInScreen.GetComponent<UILabel>().text = text.ToString();
    }

}
