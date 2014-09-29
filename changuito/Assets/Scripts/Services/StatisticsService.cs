using UnityEngine;
using System.Collections;
using System;

public static class StatisticsService
{
	public static void Call (Statistic statistic, Action<SharedObject, Exception> originalCallback)
	{
		ServiceLocator.Instance.NewService<SharedObject> ("stcs").
			WithInputData (statistic).
			WithMaxRetries (3).
			WithSecondsTimeout (30).
			Call(originalCallback);
	}

}