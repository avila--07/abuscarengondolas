package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.DomainModelValidationException;
import ar.com.utn.changuito.model.replay.GameRound;
import com.google.appengine.api.datastore.Query;

public final class GameRoundDAO extends AbstractGAEDAO<GameRound> {

    public GameRoundDAO() {
        super(GameRound.class);
    }

    @Override
    protected String getGAEEntityKind() {
        return "GameRound";
    }

    @Override
    protected void validateDomainEntity(final GameRound entityModel) throws DomainModelValidationException {

    }

    public Iterable<GameRound> getRecentGameRoundsForUser(final String userId) {
        final Query.FilterPredicate filter = new Query.FilterPredicate("uid", Query.FilterOperator.EQUAL, userId);

        //Returns 20 more recent game rounds for user
        return getEntities(filter, 20);
    }
}
