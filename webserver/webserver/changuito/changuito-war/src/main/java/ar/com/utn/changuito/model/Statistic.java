package ar.com.utn.changuito.model;

import ar.com.utn.changuito.architecture.persistence.SharedObject;

public class Statistic extends SharedObject {

    public String getId() {
        return getString("id");
    }

    public void setId(final String id) {
        set("id", id);
    }

    public Statistic() {
    }

    public Statistic(final SharedObject sharedObject) {
        super(sharedObject);
    }
}
