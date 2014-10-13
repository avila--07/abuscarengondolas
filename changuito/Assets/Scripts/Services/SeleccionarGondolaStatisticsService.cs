using UnityEngine;
using System.Collections;
using System;

public class SeleccionarGondolaStatisticsService {

    public static void Call(SeleccionarGondolaStatistic statistic, Action<SeleccionarGondolaStatistic, Exception> originalCallback)
    {
        ServiceManager.Instance.NewService("sgss").
                WithSecondsTimeout(30).
                WithMaxRetries(3).
                Call(statistic, originalCallback);
    }
}
