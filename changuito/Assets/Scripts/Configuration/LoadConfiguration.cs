using UnityEngine;
using System.Collections;
using System;

public class LoadConfiguration : MonoBehaviour {
// REVIEW: Este muchacho en algun momento tomara la data de un WS.
    private static string GONDOLA_DEFAULT = "4";

    // Use this for initialization
	void Start () {
        this.loadCantidadProductos();
        this.loadModuloPago();
        this.loadModuloControlVuelto();
	}

    private void loadModuloPago()
    {
        GameObject check = GameObject.Find("ModuloPagoCheckbox");
        check.GetComponent<UIToggle>().value = ChanguitoConfiguration.ModuloPago;
    }

    private void loadModuloControlVuelto()
    {
        GameObject check = GameObject.Find("ModuloControlVueltoCheckbox");
        check.GetComponent<UIToggle>().value = ChanguitoConfiguration.ModuloControlVuelto;
    }

    private void loadCantidadProductos()
    {
        GameObject popup = GameObject.Find("CantidadProductosPopupList");
        if (ChanguitoConfiguration.CantidadGondolas == 0)
        {
            popup.GetComponent<UIPopupList>().value = GONDOLA_DEFAULT;
        }
        else
        {
            popup.GetComponent<UIPopupList>().value = ChanguitoConfiguration.CantidadGondolas.ToString();
        }
    }

}
