package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.model.replay.GameRound;
import ar.com.utn.changuito.persistence.GameRoundDAO;

public final class UploadGameRoundService extends SecuredService<GameRound> {

    @Override
    public String getId() {
        return "ugrs";
    }

    @Override
    protected SharedObject securedTypedCall(final GameRound serviceParameter) {

        serviceParameter.setDate();

        new GameRoundDAO().persist(serviceParameter);
        return null;
    }
}
