using System.Collections;
using System;


public class SeleccionarProductoStatistic : Statistic
{
       
    // Hits.
    public int FailedProducts
    {
        get { return GetInt("failedProducts"); }
        set { Set("failedProducts", value); }
    }

    public SeleccionarProductoStatistic(int failedProducts, DateTime gameStart)
        : base(gameStart)
	{
        IdEvento = "fin_producto";
        IdPantalla = SELECCION_PRODUCTOS;
        FailedProducts = failedProducts;
    }

    public SeleccionarProductoStatistic()
    {

    }
}
