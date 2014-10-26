package ar.com.utn.changuito.model.replay;

import ar.com.utn.changuito.architecture.net.SharedObject;

// No requiere tener mapeadas todas sus propiedades con el cliente, porque sirve sólo para persistir
public final class GameRound extends SharedObject {

    public Long getId() {
        return getLong("id");
    }

    public String getUserId() {
        return getString("uid");
    }
}
