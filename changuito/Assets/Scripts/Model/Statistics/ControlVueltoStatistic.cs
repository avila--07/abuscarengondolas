using UnityEngine;
using System.Collections;
using System;

public class ControlVueltoStatistic : Statistic {

    public int FailedVuelto
    {
        get { return GetInt("failedVuelto"); }
        set { Set("failedVuelto", value); }
    }

    public int Pago
    {
        get { return GetInt("pago"); }
        set { Set("pago", value); }
    }

    public int Monto
    {
        get { return GetInt("monto"); }
        set { Set("monto", value); }
    }

     public ControlVueltoStatistic(DateTime gameStart, int failedVuelto)
        : base(gameStart)
    {
        IdEvento = "fin_CV";
        IdPantalla = CV;
        FailedVuelto = failedVuelto;
        Pago = PagoStatus.pago;
        Monto = PagoStatus.monto;
     }

     public ControlVueltoStatistic()
     {

     }

}
