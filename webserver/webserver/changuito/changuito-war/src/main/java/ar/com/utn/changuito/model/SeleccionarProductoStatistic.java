package ar.com.utn.changuito.model;

import ar.com.utn.changuito.architecture.net.SharedObject;

public class SeleccionarProductoStatistic  extends SharedObject{

	public long getId() {
	    return getLong("id");
	}
	
	public void setId(final long id) {
        set("id", id);
    }

	public void setGameDate(final String gameDate){
		set("gameDate", gameDate);
	}
	
	public String getGameDate(){
		return getString("gameDate");
	}
	
	public void setFailedProducts(final int failedProducts){
		set("failedProducts",failedProducts);
	}

	public int getFailedProducts(){
		return getInt("failedProducts");
	}
}
