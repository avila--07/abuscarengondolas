using UnityEngine;
using System.Collections;
using System;

public class IniciarEstadisticaJuego : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ChanguitoConfiguration.gameStartDate = DateTime.Now;
	}
}
