package ar.com.utn.changuito.services;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.GenericService;
import ar.com.utn.changuito.architecture.utils.RandomUtils;
import ar.com.utn.changuito.architecture.utils.StringUtils;
import ar.com.utn.changuito.model.game.User;
import ar.com.utn.changuito.persistence.UserDAO;

public final class GameLoginService extends GenericService<User> {

    @Override
    protected SharedObject typedCall(final User userParamater) {

        final String id = userParamater.getId();
        final String token = userParamater.getToken();

        // Check user already exists with same id and token
        if (!StringUtils.isEmptyOrNull(id) && !StringUtils.isEmptyOrNull(token)) {
            final User existentUser = new UserDAO().getEntityById(userParamater.getId());
            if (existentUser == null) {
                throw new RuntimeException("User with id [" + userParamater.getId() + "] and token [" + userParamater.getToken() +
                        "] does NOT exists");
            }
            if (!existentUser.getToken().equals(userParamater.getToken())) {
                throw new RuntimeException("User with id [" + userParamater.getId() + "] and token [" + userParamater.getToken() +
                        "] has changed her/his token");
            }

            existentUser.blankPassword(); // we dont want to return the password
            return existentUser;
        }

        final String email = userParamater.getEmail();
        final String password = userParamater.getPassword();

        if (email == null || password == null) {
            throw new RuntimeException("User email/password is null");
        }

        // Check user already exists
        final User user = new UserDAO().getEntityByEmail(email);
        if (user == null) {

            // Create and save a new user
            final RandomUtils instance = RandomUtils.getInstance();
            userParamater.setId(instance.getRandomAlphaNumberString(15));
            userParamater.setToken(instance.getRandomAlphaNumberString(20));
            new UserDAO().persist(userParamater);
        } else {

            // Check the password
            if (!user.getPassword().equals(password)) {

                userParamater.setAlreadyExists();
                return userParamater;
            }

            // Take existentUser values for refreshing client version of user
            userParamater.mergeWith(user);
        }

        userParamater.blankPassword(); // we dont want to return the password
        return userParamater;
    }

    @Override
    public String getId() {
        return "login";
    }
}
