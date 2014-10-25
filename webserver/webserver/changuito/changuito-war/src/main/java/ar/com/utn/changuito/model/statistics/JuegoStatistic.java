package ar.com.utn.changuito.model.statistics;

//TODO: si la aplicación WEB no la utiliza (lo más seguro) eliminar la clase
public final class JuegoStatistic extends Statistic {

    public JuegoStatistic() {

    }

    public int getCantidadGondolas() {
        return getInt("cantidadGondolas");
    }

    public void setCantidadGondolas(final int cantidadGondolas) {
        set("cantidadGondolas", cantidadGondolas);
    }

    public int getCantidadModulos() {
        return getInt("cantidadModulos");
    }

    public void setCantidadModulos(final int cantidadModulos) {
        set("cantidadModulos", cantidadModulos);
    }
}
