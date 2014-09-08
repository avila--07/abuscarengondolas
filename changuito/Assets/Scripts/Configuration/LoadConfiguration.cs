using UnityEngine;
using System.Collections;
using System;

public class LoadConfiguration : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.loadCantidadProductos();
        this.loadModuloPago();
        this.loadModuloControlVuelto();
	}


    private void loadModuloPago()
    {
        GameObject check = GameObject.Find("ModuloPagoCheckbox");
        check.GetComponent<UIToggle>().value = ChanguitoConfiguration.moduloPago;
    }

    private void loadModuloControlVuelto()
    {
        GameObject check = GameObject.Find("ModuloControlVueltoCheckbox");
        check.GetComponent<UIToggle>().value = ChanguitoConfiguration.moduloControlVuelto;
    }

    private void loadCantidadProductos()
    {
        GameObject popup = GameObject.Find("CantidadProductosPopupList");
        popup.GetComponent<UIPopupList>().value = ChanguitoConfiguration.cantidadGondolas.ToString();
    }

}
