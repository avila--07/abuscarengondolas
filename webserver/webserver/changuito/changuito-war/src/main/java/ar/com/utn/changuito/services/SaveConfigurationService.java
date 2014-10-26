package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.model.game.User;
import ar.com.utn.changuito.persistence.UserDAO;

public class SaveConfigurationService extends SecuredService<User> {

    @Override
    protected SharedObject securedTypedCall(final User serviceParameter) {

        final User authenticatedServiceUser = getAuthenticatedServiceUser();
        if (!authenticatedServiceUser.getId().equals(serviceParameter.getId()) ||
                !authenticatedServiceUser.getToken().equals(serviceParameter.getToken())) {
            throw new RuntimeException("The user authenticated want to save configuration of another user!");
        }

        authenticatedServiceUser.mergeWith(serviceParameter);
        new UserDAO().persist(authenticatedServiceUser);
        return null;
    }

    @Override
    public String getId() {
        return "scs";
    }
}
