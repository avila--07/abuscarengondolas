package statics;

public abstract class ModuloDto {
	
	private String nombre;	
	private Integer aciertos;	
	private Integer errores;	
	private Integer minutosJugados;	
	private Integer trayectoRecorrido;	

	public Integer getAciertos() {
		return aciertos;
	}
	public void setAciertos(Integer aciertos) {
		this.aciertos = aciertos;
	}
	public Integer getErrores() {
		return errores;
	}
	public void setErrores(Integer errores) {
		this.errores = errores;
	}
	public Integer getMinutosJugados() {
		return minutosJugados;
	}
	public void setMinutosJugados(Integer minutosJugados) {
		this.minutosJugados = minutosJugados;
	}
	public Integer getTrayectoRecorrido() {
		return trayectoRecorrido;
	}
	public void setTrayectoRecorrido(Integer trayectoRecorrido) {
		this.trayectoRecorrido = trayectoRecorrido;
	}

	abstract String getNombre();

}
