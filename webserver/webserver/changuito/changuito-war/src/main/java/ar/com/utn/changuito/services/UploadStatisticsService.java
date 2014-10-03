package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.persistence.SharedObject;
import ar.com.utn.changuito.architecture.services.AbstractService;
import ar.com.utn.changuito.architecture.services.GenericService;
import ar.com.utn.changuito.model.Statistic;

public class UploadStatisticsService extends GenericService<Statistic> {

    @Override
    public String getId() {
        return "ustcs";
    }

    @Override
    protected SharedObject typedCall(final Statistic statistic) {

        final SharedObject response = new SharedObject();
        response.set("result", statistic.getId());
        return response;
    }
}
