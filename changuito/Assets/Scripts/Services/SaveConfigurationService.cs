using UnityEngine;
using System.Collections;
using System;

public static class SaveConfigurationService
{
	public static void TryToCall ()
	{
		// Solo lo llamamos, si hay un usuario logueado
		if (User.Current != null) {
			ServiceManager.Instance.NewService ("scs").
					WithSecondsTimeout (30).
					WithMaxRetries (3).
					Call (User.Current, (Action<SharedObject, Exception>)SaveConfigurationResult);
		}
	}
		
	private static void SaveConfigurationResult (SharedObject result, Exception exception)
	{
		if (exception != null) {
			Debug.LogError ("El servicio de guardar configuracion fallo, la razon es: " + exception.Message);
		}
	}
}
