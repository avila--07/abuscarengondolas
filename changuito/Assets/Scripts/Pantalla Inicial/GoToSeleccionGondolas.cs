using UnityEngine;
using System.Collections;

public class GoToSeleccionGondolas : MonoBehaviour{
    
    void OnMouseDown(){
        Application.LoadLevel("PantallaSeleccionGondolas");
		Destroy (this.gameObject);
	}
}
