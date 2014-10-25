package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.GenericService;
import ar.com.utn.changuito.model.game.GameRound;
import ar.com.utn.changuito.persistence.GameRoundDAO;

public final class UploadGameRoundService extends GenericService<GameRound> {

    @Override
    public String getId() {
        return "ugrs";
    }

    @Override
    protected SharedObject typedCall(final GameRound serviceParameter) {

        new GameRoundDAO().persist(serviceParameter);
        return null;
    }
}
