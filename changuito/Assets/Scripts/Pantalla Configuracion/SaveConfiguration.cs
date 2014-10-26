using UnityEngine;
using System.Collections;
using System;

public class SaveConfiguration : MonoBehaviour
{
	void OnClick ()
	{
		this.saveCantidadProductos ();
		this.saveModuloPago ();
		this.saveModuloControlVuelto ();

		Configuration.Current.SaveAsCurrent ();
		SaveConfigurationService.TryToCall ();
	}

	private void saveModuloPago ()
	{
		GameObject check = GameObject.Find ("ModuloPagoCheckbox");
		Configuration.Current.PurchaseModule = check.GetComponent<UIToggle> ().value;
	}

	private void saveModuloControlVuelto ()
	{
		GameObject check = GameObject.Find ("ModuloControlVueltoCheckbox");
		Configuration.Current.ChangeControlModule = check.GetComponent<UIToggle> ().value;
	}

	private void saveCantidadProductos ()
	{
		GameObject popup = GameObject.Find ("CantidadProductosPopupList");
		Configuration.Current.GondolasCount = Int32.Parse (popup.GetComponent<UIPopupList> ().value);
	}
}
