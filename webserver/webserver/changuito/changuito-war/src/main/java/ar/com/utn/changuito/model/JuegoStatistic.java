package ar.com.utn.changuito.model;

import ar.com.utn.changuito.architecture.net.SharedObject;

public class JuegoStatistic extends Statistic{

	public void setCantidadGondolas(final int cantidadGondolas){
		set("cantidadGondolas",cantidadGondolas);
	}

	public int getCantidadGondolas(){
		return getInt("cantidadGondolas");
	}

	public void setCantidadModulos(final int cantidadModulos){
		set("cantidadModulos",cantidadModulos);
	}
	
	public int getCantidadModulos(){
		return getInt("cantidadModulos");
	}
	
	public JuegoStatistic(){
		
	}
	
   public JuegoStatistic(final SharedObject sharedObject) {
	        super(sharedObject);
   }
}
