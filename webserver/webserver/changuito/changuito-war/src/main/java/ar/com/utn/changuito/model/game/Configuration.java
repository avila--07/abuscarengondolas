package ar.com.utn.changuito.model.game;

import ar.com.utn.changuito.architecture.net.SharedObject;

public final class Configuration extends SharedObject {

    public boolean getPurchaseModule() {
        return getBoolean("purm");
    }

    public boolean getChangeControlModule() {
        return getBoolean("chcom");
    }

    public int getGondolasCount() {
        return getInt("goncou");
    }
}