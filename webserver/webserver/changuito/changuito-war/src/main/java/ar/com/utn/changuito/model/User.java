package ar.com.utn.changuito.model;

import ar.com.utn.changuito.architecture.net.SharedObject;

public class User extends SharedObject {

    public String getId() {
        return getString("uid");
    }

    public void setId(final String id) {
        set("uid", id);
    }

    public String getToken() {
        return getString("tkn");
    }

    public void setToken(final String value) {
        set("tkn", value);
    }

    public String getEmail() {
        return getString("email");
    }

    public String getPassword() {
        return getString("pwd");
    }

    public void blankPassword() {
        set("pwd", null);
    }

    public void setAlreadyExists(final boolean value) {
        set("adyext", value);
    }

}
