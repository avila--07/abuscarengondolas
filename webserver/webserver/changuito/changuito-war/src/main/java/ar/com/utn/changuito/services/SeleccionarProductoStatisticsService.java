package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.GenericService;
import ar.com.utn.changuito.model.SeleccionarProductoStatistic;
import ar.com.utn.changuito.persistence.SeleccionarProductoStatisticDAO;

public class SeleccionarProductoStatisticsService extends GenericService<SeleccionarProductoStatistic> {

	@Override
	protected SharedObject typedCall(SeleccionarProductoStatistic serviceParameter) {

	    final SharedObject response = new SharedObject();
	    response.set("idPantalla", serviceParameter.getIdPantalla());
	    response.set("idEvento", serviceParameter.getIdEvento());
	    response.set("idPartida", serviceParameter.getIdPartida());
	    response.set("idUsuario", serviceParameter.getIdUsuario());
        response.set("id", serviceParameter.getId());
        response.set("gameDate", serviceParameter.getGameDate());
        response.set("failedProducts", serviceParameter.getFailedProducts());
        response.set("playTime", serviceParameter.getPlayTime());
      
        new SeleccionarProductoStatisticDAO().persist(serviceParameter);
        
        return response;
	}

	@Override
	public String getId() {
		return "spss";
	}

}
