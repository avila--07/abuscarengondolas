package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.model.replay.GameRound;
import ar.com.utn.changuito.persistence.GameRoundDAO;

public final class GetRecentGameRoundsForUserService extends SecuredService<SharedObject> {

    @Override
    public String getId() {
        return "grgrfus";
    }

    @Override
    protected SharedObject securedTypedCall(SharedObject serviceParameter) {

        final GameRoundDAO gameRoundDAO = new GameRoundDAO();

        final String userId = getAuthenticatedServiceUser().getId();

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
