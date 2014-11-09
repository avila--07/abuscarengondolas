using UnityEngine;
using System.Collections;
using System;

public class PagoStatistic : Statistic {
   
    public int Monto
    {
        get { return GetInt("monto"); }
        set { Set("monto", value); }
    }

    public int Pago
    {
        get { return GetInt("pago"); }
        set { Set("pago", value); }
    }

    public int Billete
    {
        get { return GetInt("billete"); }
        set { Set("billete", value); }
    }

    public PagoStatistic(DateTime gameStart)
        : base(gameStart)
    {
        Billete = 0;
        IdEvento = "fin_pago";
        IdPantalla = PAGO;
        Monto = GameManager.Instance.GetModule<GondolaSelectionModule>().GetTotalCost();
        Pago = GameManager.Instance.GetModule<PurchaseChangeModule>().Payment;
    }

    public PagoStatistic()
    {

    }

}
