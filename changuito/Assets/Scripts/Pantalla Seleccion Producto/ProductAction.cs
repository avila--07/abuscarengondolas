using UnityEngine;
using System.Collections;
using System;
/*
public class ProductAction : MonoBehaviour
{

	private string okMessage = "¡Muy Bien!";
	private string keepMessage = "¡Sigue intentando!";

	void OnClick ()
	{
		//Obtengo el mensaje de la pantalla a mostrar
		GameObject targetMessage = GameObject.Find ("GameMessage");
		Boolean isTarget = gameObject.GetComponent<ProductProperties> ().isTarget ();

		if (isTarget) {
			//Producto seleccionado correctamente.
			targetMessage.GetComponent<UILabel> ().text = this.okMessage;
			//Enviamos la estadistica. 
			SeleccionarProductoStatistic result = new SeleccionarProductoStatistic (ServicioSeleccionarProductos.failedProducts, ServicioSeleccionarProductos.gameStart);
			UploadStatisticsService.TryToCall (result);
			//NGUISomosUtils.setTildeProductoSeleccionado (ListadoSingleton.Instance.getTarget (), true);
            //ListadoSingleton.Instance.ListadoTipoProductos.Clear();
			//ListadoSingleton.PosicionActual++;
			Application.LoadLevel ("PantallaSeleccionGondolas");
			Destroy (this.gameObject);
		} else {   //Si el producto no es el que esta siendo exibido como target ...
			if (!gameObject.tag.Equals ("SeleccionarProducto")) {
				ServicioSeleccionarProductos.failedProducts++; 
				targetMessage.GetComponent<UILabel> ().text = this.keepMessage;
			}
		}
	}
}*/