using UnityEngine;
using System.Collections;
using System;

public class SeleccionarGondolaStatistic : Statistic{
    
    public int FailedGondolas
    {
        get { return GetInt("failedGondolas"); }
        set { Set("failedGondolas", value); }
    }

    public int CantidadGondolas
    {
        get { return GetInt("cantidadGondolas"); }
        set { Set("cantidadGondolas", value); }
    }


    public SeleccionarGondolaStatistic()
    {

    }

    public SeleccionarGondolaStatistic(int failedGondola, DateTime gameDate)
        : base(gameDate)
    {
        IdEvento = "fin_gondolas";
        CantidadGondolas = Configuration.Current.GondolasCount;
        IdPantalla = SELECCION_GONDOLAS;
        FailedGondolas = failedGondola;
    }
}

