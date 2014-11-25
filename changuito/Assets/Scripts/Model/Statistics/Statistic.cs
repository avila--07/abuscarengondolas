using System;

public class Statistic : SharedObject
{
    //TODO volar esto cuando hagamos el tema del login.
    public long UN_USUARIO = 0;
    public long UNA_PARTIDA = 0;

    //Pantallas
    public int JUEGO = 0;
    public int SELECCION_GONDOLAS = 1;
    public int SELECCION_PRODUCTOS = 2;
    public int PAGO = 3;
    public int CV = 4;
   
    public long IdPartida {
		get { return GetLong ("idpartida"); }
		set { Set ("idPartida", value); }
	}

    public long IdUsuario{
        get { return GetLong("idUsuario"); }
        set { Set ("idUsuario", value);}
    }

	public string GameDate {
		get { return GetString ("gameDate"); }
		set { Set ("gameDate", value); }
	}

    public int IdPantalla{
        get{ return GetInt("idPantalla"); }
        set{ Set("idPantalla",value); }
    }

    public String IdEvento{
         get{ return GetString("idEvento"); }
         set{ Set("idEvento",value); }
    }

    public long PlayTime{
        get { return GetLong("playTime"); }
        set { Set("playTime", value); } 
    }

    public Statistic(DateTime gameStart)
	{
        IdPartida = UNA_PARTIDA;
        IdUsuario = UN_USUARIO;
        PlayTime = (long) DateTime.Now.Subtract(gameStart).TotalMilliseconds;
        GameDate = DateTime.Now.ToString();
  	}

    public Statistic()
    {

    }

}

