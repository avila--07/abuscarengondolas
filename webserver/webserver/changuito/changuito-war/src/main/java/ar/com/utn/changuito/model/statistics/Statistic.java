package ar.com.utn.changuito.model.statistics;

import ar.com.utn.changuito.architecture.net.SharedObject;

public class Statistic extends SharedObject {

    public Statistic() {
    }

    public Long getId() {
        return getLong("id");
    }

    public void setId(final Long id) {
        set("id", id);
    }

    public String getGameDate() {
        return getString("gameDate");
    }

    public void setGameDate(final String gameDate) {
        set("gameDate", gameDate);
    }

    public long getIdPartida() {
        return getLong("idPartida");
    }

    public void setIdPartida(final long idPartida) {
        set("idPartida", idPartida);
    }

    public long getIdUsuario() {
        return getLong("idUsuario");
    }

    public void setIdUsuario(final long idUsuario) {
        set("idUsuario", idUsuario);
    }

    public int getIdPantalla() {
        return getInt("idPantalla");
    }

    public void setIdPantalla(final int idPantalla) {
        set("idPantalla", idPantalla);
    }

    public String getIdEvento() {
        return getString("idEvento");
    }

    public void setIdEvento(final String idEvento) {
        set("idEvento", idEvento);
    }

    public String getPlayTime() {
        return getString("playTime");
    }

    public void setPlayTime(String value) {
        set("playTime", value);
    }

}
