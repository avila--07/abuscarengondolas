package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.model.game.User;
import ar.com.utn.changuito.model.statistics.Statistic;
import ar.com.utn.changuito.persistence.StatisticDAO;
import ar.com.utn.changuito.persistence.UserDAO;

public final class UploadStatisticsService extends SecuredService<Statistic> {

    @Override
    public String getId() {
        return "ustcs";
    }

    @Override
    protected SharedObject securedTypedCall(final Statistic statistic) {

        final User authenticatedServiceUser = getAuthenticatedServiceUser();

        long lastIdPartida = authenticatedServiceUser.getLastIdPartida();

        // si es la primera estadistica
        if ("fin_gondolas".equals(statistic.getIdEvento())) {
            lastIdPartida++;
            authenticatedServiceUser.setLastidPartidad(lastIdPartida);
            new UserDAO().persist(authenticatedServiceUser);
        }

        statistic.setIdPartida(lastIdPartida);
        new StatisticDAO().persist(statistic);
        return null;
    }
}
