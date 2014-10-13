using System.Collections;
using System;

public class SeleccionarProductoStatisticsService {

    public static void Call(SeleccionarProductoStatistic statistic, Action<SeleccionarProductoStatistic, Exception> originalCallback)
    {
        ServiceManager.Instance.NewService("spss").
                WithSecondsTimeout(30).
                WithMaxRetries(3).
                Call(statistic, originalCallback);
    }

}
