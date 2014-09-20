using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SuperMarket : MonoBehaviour
{
	public static List<UI2DSprite> Gondolas = new List<UI2DSprite> (10);

	void Start ()
	{
		Gondolas.Clear();

		if (!seleccionFinalizada ()) {
			ListadoSingleton.Instance.initializeListado ();
			createGondolas ();
			setTargetOfChanguito ();
			setProductTarget ();
		} else {
			ListadoSingleton.Instance.clean ();
			finalizarJuego ();
		}
	}

	private void finalizarJuego ()
	{
		if (ChanguitoConfiguration.ModuloPago) {
			Application.LoadLevel ("PantallaPago");
		} else {
			Application.LoadLevel ("PantallaFinal");
		}
	}

	private bool seleccionFinalizada ()
	{
		return ChanguitoConfiguration.CantidadGondolas == ListadoSingleton.PosicionActual;
	}

	private void setProductTarget ()
	{
		ListadoSingleton.ProductTarget = ListadoSingleton.Instance.getTarget ();
	}

	private void setTargetOfChanguito ()
	{
		GameObject changuito = GameObject.Find ("Changuito");
		changuito.GetComponent<ChanguitoDragable> ().GondolaTarget = ListadoSingleton.Instance.getTargetType ();
	}

	private void createGondolas ()
	{		
		GameObject gondolasOnScene = GameObject.Find ("SGGondolasTable");
        
		int gondolaPosition;
		for (gondolaPosition = 0; gondolaPosition < ChanguitoConfiguration.CantidadGondolas; gondolaPosition++) {
			GameObject gondola = (GameObject)Resources.Load ("Gondola");
			String name = ListadoSingleton.Instance.getLabelOfGondolaType (gondolaPosition);
			gondola.GetComponent<UILabel> ().text = name;
			gondola.name = name; 
			gondola.GetComponent<GondolaProperties> ().ProductType = (int)ListadoSingleton.Instance.getGondolasSeleccionadas () [gondolaPosition];
			Gondolas.Add (NGUITools.AddChild (gondolasOnScene, gondola).GetComponent<UI2DSprite> ());
		}
		gondolasOnScene.GetComponent<UITable> ().Reposition ();
	}

}