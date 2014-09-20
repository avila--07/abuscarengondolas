using UnityEngine;
using System.Collections;
using System;

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

    /// <summary>
    /// De un label de pantalla obtengo su valor
    /// Util par obtener status de un tablero de anotaciones por ejemplo.
    /// </summary>
    /// <param name="objectLabel"></param>
    /// <returns>int</returns>
    public static int getIntFromGameObject(string objectText)
    {
        GameObject objectLabel = GameObject.Find(objectText);
        return  int.Parse(objectLabel.GetComponent<UILabel>().text);
    }

    /// <summary>
    /// Setea el tilde OK a los productos que fueron correctamente seleccionados.
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="active"></param>
    public static void setTildeProductoSeleccionado(GameObject gameObject, Boolean active)
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(active);
    }

}

