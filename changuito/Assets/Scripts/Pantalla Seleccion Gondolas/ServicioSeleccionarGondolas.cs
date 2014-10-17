using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ServicioSeleccionarGondolas : MonoBehaviour
{
	public static List<UI2DSprite> Gondolas = new List<UI2DSprite> (10);
    public static int failedGondola;
    public static DateTime gondolaStart;
	void Start ()
	{
		Gondolas.Clear();
        initializeStatistics();

		if (!seleccionFinalizada ()) {
			ListadoSingleton.Instance.initializeListado ();
			createGondolas ();
			setTargetOfChanguito ();
			setProductTarget ();
		} else {
			finalizarJuego ();
		}
	}

    private void initializeStatistics()
    {
        failedGondola = 0;
        gondolaStart = DateTime.Now;
    }

	private void finalizarJuego ()
	{
		if (ChanguitoConfiguration.ModuloPago) {
			Application.LoadLevel ("PantallaPago");
		} else {
			ListadoSingleton.Instance.clean ();
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
			String name = ListadoSingleton.Instance.getLabelOfGondolaType (gondolaPosition);
			GameObject gondola = (GameObject)Resources.Load (name);
			gondola.name = name; 
			gondola.GetComponent<GondolaProperties> ().ProductType = (int)ListadoSingleton.Instance.getGondolasSeleccionadas () [gondolaPosition];
			Gondolas.Add (NGUITools.AddChild (gondolasOnScene, gondola).GetComponent<UI2DSprite> ());
		}
		gondolasOnScene.GetComponent<UITable> ().Reposition ();
	}

}