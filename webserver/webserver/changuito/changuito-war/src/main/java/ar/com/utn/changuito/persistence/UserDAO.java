package ar.com.utn.changuito.persistence;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.DomainModelValidationException;
import ar.com.utn.changuito.architecture.utils.StringUtils;
import ar.com.utn.changuito.model.game.User;
import com.google.appengine.api.datastore.Query;

import java.util.Iterator;

public final class UserDAO extends AbstractGAEDAO<User> {

    public UserDAO() {
        super(User.class);
    }

    @Override
    protected String getId(final User domainEntity) {
        return domainEntity.getId();
    }

    @Override
    protected String getGAEEntityKind() {
        return "User";
    }

    @Override
    protected void validateDomainEntity(final User domainEntity) throws DomainModelValidationException {

        if (StringUtils.isEmptyOrNull(domainEntity.getId()))
            throw new DomainModelValidationException("User id cannot be null or empty");
        if (StringUtils.isEmptyOrNull(domainEntity.getToken()))
            throw new DomainModelValidationException("User token cannot be null or empty");
        if (StringUtils.isEmptyOrNull(domainEntity.getEmail()))
            throw new DomainModelValidationException("User email cannot be null or empty");
    }

    public User getEntityById(final String id) {

        final Query.Filter filter = new Query.FilterPredicate("uid", Query.FilterOperator.EQUAL, id);
        final Iterator<User> entities = getEntities(filter, 1).iterator();

        return entities.hasNext() ? entities.next() : null;
    }

    public User getEntityByEmail(final String email) {

        final Query.Filter filter = new Query.FilterPredicate("email", Query.FilterOperator.EQUAL, email);
        final Iterator<User> entities = getEntities(filter, 1).iterator();

        return entities.hasNext() ? entities.next() : null;
    }
}
