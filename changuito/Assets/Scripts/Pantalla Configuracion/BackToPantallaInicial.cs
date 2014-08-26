using UnityEngine;
using System.Collections;

public class BackToPantallaInicial : MonoBehaviour
{


	void OnMouseDown(){
		Application.LoadLevel("PantallaInicial");
		Destroy (this.gameObject);
	}
}
