using UnityEngine;
using System.Collections;

public class PlayScript : MonoBehaviour {

	void OnMouseDown(){

		Application.LoadLevel("PantallaDeJuego");
		Destroy (this.gameObject);
	}
}
