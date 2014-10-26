using UnityEngine;
using System.Collections;
using System;

public static class UploadStatisticsService
{
	public static void TryToCall (Statistic statistic)
	{
		// Solo lo llamamos, si hay un usuario logueado
		if (User.Current != null) {
			ServiceManager.Instance.NewService ("ustcs").
				WithSecondsTimeout (30).
				WithMaxRetries (3).
				Call (statistic, (Action<SharedObject, Exception>) UploadStatisticsResult);
		}
	}

	private static void UploadStatisticsResult (SharedObject result, Exception exception)
	{
		if (exception != null) {
			Debug.LogError ("El servicio de subida de estadisticas fallo, la razon es: " + exception.Message);
		}
	}
}