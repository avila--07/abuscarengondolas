package ar.com.utn.changuito.model.game;

import ar.com.utn.changuito.architecture.net.SharedObject;

public final class Configuration extends SharedObject {

    public boolean getPurchaseModule() {
        return getBoolean("purm");
    }

    public boolean getControlChangeModule() {
        return getBoolean("cchm");
    }

    public int getGondolaQuantity() {
        return getInt("gonqty");
    }
}