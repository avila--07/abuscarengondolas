using UnityEngine;
using System.Collections;
using System;

public class JuegoStaticsService  {

    public static void Call(JuegoStatistic statistic, Action<JuegoStatistic, Exception> originalCallback)
    {
        ServiceManager.Instance.NewService("jss").
                WithSecondsTimeout(30).
                WithMaxRetries(3).
                Call(statistic, originalCallback);
    }
}
