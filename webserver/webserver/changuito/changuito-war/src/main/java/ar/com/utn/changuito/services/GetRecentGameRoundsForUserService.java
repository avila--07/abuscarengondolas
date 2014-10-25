package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.GenericService;
import ar.com.utn.changuito.model.game.GameRound;
import ar.com.utn.changuito.persistence.GameRoundDAO;

public final class GetRecentGameRoundsForUserService extends GenericService<SharedObject> {

    @Override
    public String getId() {
        return "grgrfus";
    }

    @Override
    protected SharedObject typedCall(final SharedObject serviceParameter) {

        final String userId = serviceParameter.getString("uid");

        if (userId == null || userId.trim().length() == 0) {
            throw new RuntimeException("The user id [" + userId + "] is null or empty.");
        }

        final GameRoundDAO gameRoundDAO = new GameRoundDAO();

        final SharedObject sharedObject = new SharedObject();
        int index = 1;
        for (final GameRound gameRound : gameRoundDAO.getRecentGameRoundsForUser(userId)) {
            String key = "gr_" + index;
            sharedObject.set(key, gameRound);
            index++;
        }
        return sharedObject;
    }
}
