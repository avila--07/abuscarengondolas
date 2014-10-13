package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.GenericService;
import ar.com.utn.changuito.model.JuegoStatistic;
import ar.com.utn.changuito.model.SeleccionarGondolaStatistic;
import ar.com.utn.changuito.model.SeleccionarProductoStatistic;
import ar.com.utn.changuito.persistence.JuegoStatisticDAO;
import ar.com.utn.changuito.persistence.SeleccionarGondolaStatisticDAO;
import ar.com.utn.changuito.persistence.SeleccionarProductoStatisticDAO;

public class SeleccionarGondolaStatisticsService extends GenericService<SeleccionarGondolaStatistic> {

	@Override
	protected SharedObject typedCall(SeleccionarGondolaStatistic serviceParameter) {

	    final SharedObject response = new SharedObject();
	    response.set("idPantalla", serviceParameter.getIdPantalla());
	    response.set("idEvento", serviceParameter.getIdEvento());
	    response.set("idPartida", serviceParameter.getIdPartida());
	    response.set("idUsuario", serviceParameter.getIdUsuario());
        response.set("id", serviceParameter.getId());
        response.set("gameDate", serviceParameter.getGameDate());
        response.set("failedGondolas", serviceParameter.getFailedGondolas());
        response.set("cantidadGondolas", serviceParameter.getCantidadGondolas());
        response.set("playTime", serviceParameter.getPlayTime());
      
        new SeleccionarGondolaStatisticDAO().persist(serviceParameter);
        
        return response;
	}

	@Override
	public String getId() {
		return "sgss";
	}
}
