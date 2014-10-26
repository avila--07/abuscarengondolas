package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.GenericService;
import ar.com.utn.changuito.architecture.utils.StringUtils;
import ar.com.utn.changuito.model.game.User;
import ar.com.utn.changuito.persistence.UserDAO;

public abstract class SecuredService<TIn extends SharedObject> extends GenericService<TIn> {

    private User user;

    protected User getAuthenticatedServiceUser() {
        return user;
    }

    protected abstract SharedObject securedTypedCall(final TIn serviceParameter);

    @Override
    protected SharedObject typedCall(final TIn serviceParameter) {

        final String userId = serviceParameter.getString("uid");
        final String userToken = serviceParameter.getString("tkn");

        if (StringUtils.isEmptyOrNull(userId) || StringUtils.isEmptyOrNull(userToken)) {
            throw new RuntimeException("The service with id [" + getId() + "] is a secured one, userid and token cannot be empties");
        }

        user = new UserDAO().getEntityById(userId);
        if (user == null || !user.getToken().equals(userToken)) {
            throw new RuntimeException("The userid and token cannot be validated");
        }
        return securedTypedCall(serviceParameter);
    }
}
