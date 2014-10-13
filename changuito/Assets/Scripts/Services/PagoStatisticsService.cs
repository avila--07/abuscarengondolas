using UnityEngine;
using System.Collections;
using System;

public class PagoStatisticsService {

    public static void Call(PagoStatistic statistic, Action<PagoStatistic, Exception> originalCallback)
    {
        ServiceManager.Instance.NewService("pss").
                WithSecondsTimeout(30).
                WithMaxRetries(3).
                Call(statistic, originalCallback);
    }
}
