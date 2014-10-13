package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.GenericService;
import ar.com.utn.changuito.model.JuegoStatistic;
import ar.com.utn.changuito.model.SeleccionarProductoStatistic;
import ar.com.utn.changuito.persistence.JuegoStatisticDAO;
import ar.com.utn.changuito.persistence.SeleccionarProductoStatisticDAO;

public class JuegoStatisticsService extends GenericService<JuegoStatistic> {

	@Override
	protected SharedObject typedCall(JuegoStatistic serviceParameter) {

	    final SharedObject response = new SharedObject();
	    response.set("idPantalla", serviceParameter.getIdPantalla());
	    response.set("idEvento", serviceParameter.getIdEvento());
	    response.set("idPartida", serviceParameter.getIdPartida());
	    response.set("idUsuario", serviceParameter.getIdUsuario());
        response.set("id", serviceParameter.getId());
        response.set("gameDate", serviceParameter.getGameDate());
        response.set("cantidadGondolas", serviceParameter.getCantidadGondolas());
        response.set("cantidadModulos", serviceParameter.getCantidadModulos());
        response.set("playTime", serviceParameter.getPlayTime());
      
        new JuegoStatisticDAO().persist(serviceParameter);
        
        return response;
	}

	@Override
	public String getId() {
		return "jss";
	}
}
