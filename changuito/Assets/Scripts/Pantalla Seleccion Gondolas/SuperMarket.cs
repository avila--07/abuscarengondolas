using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SuperMarket : MonoBehaviour
{
    
	private void Start ()
	{
        ListadoSingleton.Instance.showListado();
        CreateChanguitoAndGondolas();
	}

	private void CreateChanguitoAndGondolas ()
	{		
		// create gondola table
        GameObject gondolasOnScene = GameObject.Find("SGGondolasTable");
        ArrayList gondolasLabel = ListadoSingleton.Instance.getTipoProductosSeleccionados();
        int gondolaPosition;

        for (gondolaPosition = 0; gondolaPosition < ChanguitoConfiguration.CantidadGondolas; gondolaPosition++)
        {
            GameObject gondola = (GameObject)Resources.Load("Gondola");
            gondola.GetComponent<UILabel>().text = (string)gondolasLabel[gondolaPosition];
            NGUITools.AddChild(gondolasOnScene,gondola);
        }
        gondolasOnScene.GetComponent<UITable>().Reposition();
	}

 }