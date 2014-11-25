using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
/*
public class ServicioSeleccionarGondolas : MonoBehaviour
{
    public static int failedGondola;
    public static DateTime gondolaStart;
    public GameObject listadoGrid;
    public GameObject gondolasGrid;

	void Start ()
	{
        initializeStatistics();

		if (!seleccionFinalizada ()) {
            //ListadoSingleton.Instance.makeGondolaScene();
			showScene();
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
		if (Configuration.Current.PurchaseModule) {
			Application.LoadLevel ("PantallaPago");
		} else {
			ListadoSingleton.Instance.clean ();
			Application.LoadLevel ("PantallaFinal");
		}
	}

	private bool seleccionFinalizada ()
	{
		return Configuration.Current.GondolasCount == ListadoSingleton.PosicionActual;
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

    private void showScene()
    {
        ListadoSingleton.Instance.showListado(listadoGrid);
        ListadoSingleton.Instance.showGondolas(gondolasGrid);
    }

}*/