package ar.com.utn.changuito.model;

import ar.com.utn.changuito.architecture.net.SharedObject;

public class Statistic extends SharedObject {

    public Long getId() {
        return getLong("id");
    }

    public void setId(final Long id) {
        set("id", id);
    }

    public Statistic() {
    }

    public Statistic(final SharedObject sharedObject) {
        super(sharedObject);
    }
}
