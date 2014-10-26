using UnityEngine;
using System.Collections;
using System;

public static class UploadGameRoundService
{
	public static void TryToCall (GameRound gameRound)
	{
		// Solo lo llamamos, si hay un usuario logueado
		if (User.Current != null) {
			ServiceManager.Instance.NewService ("ugrs").
				WithSecondsTimeout (30).
					WithMaxRetries (3).
					Call (gameRound, (Action<SharedObject, Exception>) UploadGameRoundResult);
		}
	}
	
	private static void UploadGameRoundResult (SharedObject result, Exception exception)
	{
		if (exception != null) {
			Debug.LogError ("El servicio de subida de game round fallo, la razon es: " + exception.Message);
		}
	}
}