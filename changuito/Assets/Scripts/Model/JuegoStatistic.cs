using UnityEngine;
using System.Collections;
using System;

public class JuegoStatistic : Statistic {

    public int CantidadModulos{
        get { return GetInt("cantidadModulos"); }
        set { Set("cantidadModulos", value); }
    }
    
    public int CantidadGondolas{
        get { return GetInt("cantidadGondolas"); }
        set { Set("cantidadGondolas", value); }
    }

    public JuegoStatistic()
    {

    }

    public JuegoStatistic(DateTime gameStart): base(gameStart)
    {
        IdEvento = "fin_juego";
        IdPantalla = JUEGO;
        CantidadGondolas = ChanguitoConfiguration.CantidadGondolas;
        CantidadModulos = ChanguitoConfiguration.getCantidadModulos();
    }

}
