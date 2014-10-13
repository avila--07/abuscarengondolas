package ar.com.utn.changuito.model;

import ar.com.utn.changuito.architecture.net.SharedObject;

public class PagoStatistic extends Statistic{

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
	
	public int getBillete() {
		return getInt("billete");
	}

	public void setBillete(int billete){
		set("billete", billete);
	}
	
	public PagoStatistic(){
		
	}
	
   public PagoStatistic(final SharedObject sharedObject) {
	        super(sharedObject);
   }

}
