using UnityEngine;
using System.Collections;
using System;

public class OnClickProductoOnGondola : MonoBehaviour {

    public string okMessage = "¡Muy Bien!";
    public string keepMessage = "¡Sigue intentando!";

    void OnClick()
    {
        //Obtengo el mensaje de la pantalla a mostrar
       GameObject targetMessage = GameObject.Find("GameMessage");
       Boolean isTarget = gameObject.GetComponent<ProductProperties>().isTarget();


       if (isTarget)
       {
           //Producto seleccionado correctamente.
           targetMessage.GetComponent<UILabel>().text = this.okMessage;
           System.Threading.Thread.Sleep(200);
           NGUISomosUtils.setTildeProductoSeleccionado(ListadoSingleton.Instance.getTarget(),true);
           ListadoSingleton.Instance.cleanListadoTipoProductos();
           ListadoSingleton.PosicionActual++;
           //Enviamos la estadistica. 
           SeleccionarProductoStatistic result = new SeleccionarProductoStatistic(2,DateTime.Today.ToString(),ServicioSeleccionarProductos.failedProducts);
           SeleccionarProductoStatisticsService.Call(result,ServiceResult);
           Application.LoadLevel("PantallaSeleccionGondolas");
           Destroy(this.gameObject);
        }
        else
        {   //Si el producto no es el que esta siendo exibido como target ...
            if (!gameObject.tag.Equals("SeleccionarProducto"))
            {
                ServicioSeleccionarProductos.failedProducts++; 
                targetMessage.GetComponent<UILabel>().text = this.keepMessage;
            }
        }
    }


    private void ServiceResult(SeleccionarProductoStatistic result, Exception exception)
    {
       // Debug.Log("Resultado servicio: " + ((result == null) ? "Fallo con [" + exception + "]" : result.ToString()));
    }
}
