using UnityEngine;
using System.Collections;
using System;

public static class UploadStatisticsService
{
	public static void Call (Statistic statistic, Action<SharedObject, Exception> originalCallback)
	{
		ServiceManager.Instance.NewService ("ustcs").
				WithSecondsTimeout (30).
				WithMaxRetries (3).
				Call (statistic, originalCallback);
	}
}