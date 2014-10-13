using UnityEngine;
using System.Collections;
using System;

public class ControlVueltoStatisticsService {

    public static void Call(ControlVueltoStatistic statistic, Action<ControlVueltoStatistic, Exception> originalCallback)
    {
        ServiceManager.Instance.NewService("cvss").
                WithSecondsTimeout(30).
                WithMaxRetries(3).
                Call(statistic, originalCallback);
    }
}
