package ar.com.utn.changuito.model;

import ar.com.utn.changuito.architecture.net.SharedObject;

public class ControlVueltoStatistic extends Statistic{

	public void setPago(final int pago){
		set("pago",pago);
	}
	public int getPago(){
		return getInt("pago");
	}

	public void setMonto(final int monto){
		set("montoFinal",monto);
	}
	
	public int getMonto(){
		return getInt("monto");
	}

	public void setFailedVuelto(final int failedVuelto){
		set("failedVuelto",failedVuelto);
	}
	
	public int getFailedVuelto(){
		return getInt("failedVuelto");
	}

	
	
	public ControlVueltoStatistic(){
		
	}
	
   public ControlVueltoStatistic(final SharedObject sharedObject) {
	        super(sharedObject);
   }
}
