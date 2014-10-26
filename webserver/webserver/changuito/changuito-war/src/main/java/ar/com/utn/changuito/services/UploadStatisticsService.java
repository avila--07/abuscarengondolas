package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.model.statistics.Statistic;
import ar.com.utn.changuito.persistence.StatisticDAO;

public final class UploadStatisticsService extends SecuredService<Statistic> {

    @Override
    public String getId() {
        return "ustcs";
    }

    @Override
    protected SharedObject securedTypedCall(final Statistic statistic) {

        new StatisticDAO().persist(statistic);
        return null;
    }
}
