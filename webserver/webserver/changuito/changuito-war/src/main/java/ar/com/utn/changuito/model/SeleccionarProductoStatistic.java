package ar.com.utn.changuito.model;

import ar.com.utn.changuito.architecture.net.SharedObject;

public class SeleccionarProductoStatistic extends Statistic{

	public void setFailedProducts(final int failedProducts){
		set("failedProducts",failedProducts);
	}

	public int getFailedProducts(){
		return getInt("failedProducts");
	}
	
	public SeleccionarProductoStatistic(){
		
	}
	
   public SeleccionarProductoStatistic(final SharedObject sharedObject) {
	        super(sharedObject);
   }
}
