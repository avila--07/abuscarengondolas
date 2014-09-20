using UnityEngine;
using System.Collections;
using System;

public class ChanguitoDragable : MonoBehaviour
{
	public int GondolaTarget;

	void OnDragStart ()
	{
		//Debug.LogError ("OnDragStart");
		NGUISomosUtils.showTextInScreen ("SGStatusLabel", "");
	}

	void OnDragEnd ()
	{
		UI2DSprite changuito = gameObject.GetComponent<UI2DSprite> ();
		bool findGondola = false;

		foreach (UI2DSprite gondola in SuperMarket.Gondolas) {
				
			if (gondola.GetComponent<GondolaProperties> ().ProductType == ListadoSingleton.Instance.getTargetType () &&
				ColliderUtils.IsFullyInside (gondola, changuito)) {

				findGondola = true;
				break;
			}
		}

		if (findGondola) {		
			NGUISomosUtils.showTextInScreen ("SGStatusLabel", "¡Excelente!");

			Invoke ("GoToNextScene", 1F);
		} else {
			NGUISomosUtils.showTextInScreen ("SGStatusLabel", "Aquí no está.\n ¡Busquemos en otra góndola!");
		}
	}

	private void GoToNextScene ()
	{		
		Application.LoadLevel ("PantallaSeleccionProductos");
	}
}