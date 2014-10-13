package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.GenericService;
import ar.com.utn.changuito.model.Statistic;
import ar.com.utn.changuito.persistence.StatisticDAO;

public class UploadStatisticsService extends GenericService<Statistic> {

    @Override
    public String getId() {
        return "ustcs";
    }

    @Override
    protected SharedObject typedCall(final Statistic statistic) {

        final SharedObject response = new SharedObject();
        response.set("result", statistic.getId());

        //pruebas
//        StatisticDAO statisticDAO = new StatisticDAO();
//        statisticDAO.persist(statistic);
//
//        Statistic entityById = statisticDAO.getEntityById(statistic.getId());
//

        return response;
    }
}
