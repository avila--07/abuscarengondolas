using UnityEngine;
using System.Collections;
using System;

public class OnClickProductoOnGondola : MonoBehaviour {

    public string okMessage = "¡Muy Bien!";
    public string keepMessage = "¡Seguí intentando!";

    void OnClick()
    {
       Debug.Log("Click on Product!");
        //Obtengo el mensaje de la pantalla a mostrar
       GameObject targetMessage = GameObject.Find("GameMessage");
       Boolean isTarget = gameObject.GetComponent<ProductProperties>().isTarget(); 
        
       if (isTarget)
       {
            targetMessage.GetComponent<UILabel>().text = this.keepMessage;
            System.Threading.Thread.Sleep(250);
            ListadoSingleton.PosicionActual++;
            Application.LoadLevel("PantallaSeleccionGondolas");
            Destroy(this.gameObject);
        }
        else
        {
            targetMessage.GetComponent<UILabel>().text = this.keepMessage;
        }
    }

}
