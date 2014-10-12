using System.Collections;
using System;


public class SeleccionarProductoStatistic : SharedObject
{
    //ID session.
    public int Id {
		get { return GetInt("id"); }
		set { Set ("id", value); }
	}

    //Hora y Fecha de juego.
	public string GameDate {
		get { return GetString ("gameDate"); }
		set { Set ("gameDate", value); }
	}
    
    // Hit.
    public int FailedProducts
    {
        get { return GetInt("failedProducts"); }
        set { Set("failedProducts", value); }
    }

    public SeleccionarProductoStatistic(int id, string gameDate, int failedProducts)
	{
        Id = id;
        GameDate = gameDate;
        FailedProducts = failedProducts;
    }

    public String ToString()
    {
        return "id: " + this.Id + "- Time: " + this.GameDate + " - Eleccion " + this.FailedProducts;
    }
}
