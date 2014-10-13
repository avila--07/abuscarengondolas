package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.GenericService;
import ar.com.utn.changuito.model.PagoStatistic;
import ar.com.utn.changuito.persistence.PagoStatisticDAO;

public class PagoStatisticsService extends GenericService<PagoStatistic> {

	@Override
	protected SharedObject typedCall(PagoStatistic serviceParameter) {

	    final SharedObject response = new SharedObject();
	    response.set("idPantalla", serviceParameter.getIdPantalla());
	    response.set("idEvento", serviceParameter.getIdEvento());
	    response.set("idPartida", serviceParameter.getIdPartida());
	    response.set("idUsuario", serviceParameter.getIdUsuario());
        response.set("id", serviceParameter.getId());
        response.set("gameDate", serviceParameter.getGameDate());
        response.set("pago", serviceParameter.getPago());
        response.set("billete",serviceParameter.getBillete());
        response.set("monto", serviceParameter.getMonto());
        response.set("playTime", serviceParameter.getPlayTime());
      
        new PagoStatisticDAO().persist(serviceParameter);
        
        return response;
	}

	@Override
	public String getId() {
		return "pss";
	}
}
