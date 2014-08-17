using UnityEngine;
using System.Collections;

public class BackToHome : MonoBehaviour {


	void OnMouseDown(){
		Application.LoadLevel("PantallaInicial");
		Destroy (this.gameObject);
	}
}
