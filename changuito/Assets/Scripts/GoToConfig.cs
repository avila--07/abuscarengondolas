using UnityEngine;
using System.Collections;

public class GoToConfig : MonoBehaviour {

	int intentos;
	// Use this for initialization
	void Start () {
	
		int intentos = 0;
	}

	void OnMouseDown(){

		//Debe darse la condicion cuando toca 3 veces el boton...
		if (++intentos > 3) {
			intentos=0;
			Application.LoadLevel("PantallaConfiguracion");
			Destroy (this.gameObject);
		}

	}
}
