package ar.com.utn.changuito.model;

import ar.com.utn.changuito.architecture.persistence.SharedObject;

public class Statistic extends SharedObject {

    public String getId() {
        return get("id");
    }

    public Statistic() {
    }

    public Statistic(final SharedObject sharedObject) {
        super(sharedObject);
    }
}
