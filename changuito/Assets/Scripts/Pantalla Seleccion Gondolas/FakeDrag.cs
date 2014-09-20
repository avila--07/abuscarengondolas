using UnityEngine;
using System.Collections;

public class FakeDrag : MonoBehaviour {

	// Use this for initialization
    void OnClick()
    {
        if (gameObject.GetComponent<GondolaProperties>().ProductType == ListadoSingleton.Instance.getTargetType())
        {
             Application.LoadLevel("PantallaSeleccionProductos");
        }
        else
            NGUISomosUtils.showTextInScreen("SGStatusLabel","Aquí no está.\n ¡Busquemos en otra góndola!");
    }
}
