package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.GenericService;
import ar.com.utn.changuito.model.game.GameRound;
import ar.com.utn.changuito.persistence.GameRoundDAO;

public final class GetGameRoundService extends GenericService<SharedObject> {

    @Override
    public String getId() {
        return "ggss";
    }

    @Override
    protected SharedObject typedCall(final SharedObject serviceParameter) {

        final long id = serviceParameter.getLong("id");
        if (id <= 0) {
            throw new RuntimeException("The game round id [" + id + "] is invalid!");
        }

        final GameRound gameRound = new GameRoundDAO().getEntityById(id);
        if (gameRound.getId() == null || gameRound.getId() != id) {
            throw new RuntimeException("The game round with id [" + id + "] does not exists!");
        }

        return gameRound;
    }
}
