using UnityEngine;
using System.Collections;
using System;

public class OnClickProductoOnGondola : MonoBehaviour {

    public string okMessage = "¡Muy Bien!";
    public string keepMessage = "¡Sigue intentando!";

    void OnClick()
    {
       Debug.Log("Click on Product!");
        //Obtengo el mensaje de la pantalla a mostrar
       GameObject targetMessage = GameObject.Find("GameMessage");
       Boolean isTarget = gameObject.GetComponent<ProductProperties>().isTarget();
        
       if (isTarget)
       {
           targetMessage.GetComponent<UILabel>().text = this.okMessage;
           System.Threading.Thread.Sleep(250);
           NGUISomosUtils.setTildeProductoSeleccionado(ListadoSingleton.Instance.getTarget(),true);
           ListadoSingleton.Instance.cleanListadoTipoProductos();
           ListadoSingleton.PosicionActual++;
           Application.LoadLevel("PantallaSeleccionGondolas");
           Destroy(this.gameObject);
        }
        else
        {   //Si el producto no es el que esta siendo exibido como target ...
            if (!gameObject.tag.Equals("SeleccionarProducto"))
            {
                targetMessage.GetComponent<UILabel>().text = this.keepMessage;
            }
        }
    }

}
