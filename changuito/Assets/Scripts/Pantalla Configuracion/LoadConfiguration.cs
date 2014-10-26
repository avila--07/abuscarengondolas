using UnityEngine;
using System.Collections;
using System;

public class LoadConfiguration : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		Load ();
	}

	public void  Load ()
	{
		this.loadCantidadProductos ();
		this.loadModuloPago ();
		this.loadModuloControlVuelto ();
	}
	
	public void RefreshWithUserConfigurationDelayed ()
	{
		StartCoroutine (RefreshWithUserConfigurationImpl());		
	}

	private IEnumerator RefreshWithUserConfigurationImpl ()
	{
		yield return new WaitForEndOfFrame();

		Load ();
	}

	private void loadModuloPago ()
	{
		GameObject check = GameObject.Find ("ModuloPagoCheckbox");
		check.GetComponent<UIToggle> ().value = Configuration.Current.PurchaseModule;
	}

	private void loadModuloControlVuelto ()
	{
		GameObject check = GameObject.Find ("ModuloControlVueltoCheckbox");
		check.GetComponent<UIToggle> ().value = Configuration.Current.ChangeControlModule;
	}

	private void loadCantidadProductos ()
	{
		GameObject popup = GameObject.Find ("CantidadProductosPopupList");
		popup.GetComponent<UIPopupList> ().value = Configuration.Current.GondolasCount.ToString ();
	}

}
