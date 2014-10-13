package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.GenericService;
import ar.com.utn.changuito.model.ControlVueltoStatistic;
import ar.com.utn.changuito.model.JuegoStatistic;
import ar.com.utn.changuito.model.SeleccionarProductoStatistic;
import ar.com.utn.changuito.persistence.ControlVueltoStatisticDAO;
import ar.com.utn.changuito.persistence.JuegoStatisticDAO;
import ar.com.utn.changuito.persistence.SeleccionarProductoStatisticDAO;

public class ControlVueltoStatisticsService extends GenericService<ControlVueltoStatistic> {

	@Override
	protected SharedObject typedCall(ControlVueltoStatistic serviceParameter) {

	    final SharedObject response = new SharedObject();
	    response.set("idPantalla", serviceParameter.getIdPantalla());
	    response.set("idEvento", serviceParameter.getIdEvento());
	    response.set("idPartida", serviceParameter.getIdPartida());
	    response.set("idUsuario", serviceParameter.getIdUsuario());
        response.set("id", serviceParameter.getId());
        response.set("gameDate", serviceParameter.getGameDate());
        response.set("pago", serviceParameter.getPago());
        response.set("monto", serviceParameter.getMonto());
        response.set("failedVuelto", serviceParameter.getFailedVuelto());
        response.set("playTime", serviceParameter.getPlayTime());
      
        new ControlVueltoStatisticDAO().persist(serviceParameter);
        
        return response;
	}

	@Override
	public String getId() {
		return "cvss";
	}
}
