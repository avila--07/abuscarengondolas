using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// Implementa y ejecuta la logica de la pantalla de seleccion de productos.<br> Es en escencia un emptyGameObject. El script esta attachado a un HiddenCube (buuu!)
public class SeleccionarProductosGameLogic : MonoBehaviour
{

    List<GameObject> productos;

	// Use this for initialization
	void Start () {

        productos = new List<GameObject>();

        // TODO: Mas luego levantarlos de DB.
        // TODO DEMO 2 (?) generar productos aleatoreamente (posible prefabs)
        // TODO DEMO 2: que el producto seleccionado de la gondola este como opcion en la seleccion de productos. Pasar parametros entre escenas. 
        GameObject lechuga = (GameObject)Resources.Load("Lechuga");
        GameObject rumba = (GameObject)Resources.Load("Rumba");

        productos.Add(lechuga);
        productos.Add(rumba);
	}
	
	// Update is called once per frame
	void Update () {

        if ( Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click, hit?");
            RaycastHit hit ;
            Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
            // Productos - Layout 13. 
            if (Physics.Raycast(ray, out hit, 13))
            {
                Debug.Log("Yes, hit!");
                Debug.Log(hit.collider.gameObject.name);
                // TODO: Eliminar espantoso hardcodeado del nombre del producto a seleccionar !
                if (hit.collider.gameObject.name.Equals("Lechuga"))
                {
                    Debug.Log("Exelente pibe!");
                    // TODO DEMO 2: Actualizar la lista
                    // TODO DEMO 1: Mostrar texto feliz y dejar un sleep (o algo asi) para volver a la pantalla de seleccion de gondolas.
                    // TODO DEMO 1: Suavizar los cambios de escena (sobretodo si tiene una escena ejecutandose en otro layout.
                    // TODO DEMO 1: Ver la forma de bloquear la pantalla de seleccion de gondolas 
                    // (2 alternativas, hacer el plano de seleccion mas grande o poner un plano transparente con mesh coloider) 
                    Application.LoadLevel("PantallaSeleccionGondolas");
                    Destroy(this);
                }
                else
                {
                    // TODO DEMO 1: Mostrar texto para que lo vuelva a intentar.
                    Debug.Log("Volve a intentar! tenes que elegir la lechuga. Acordate que sos una Tortuga por ahora");
                }
            }
        }
    }
}
