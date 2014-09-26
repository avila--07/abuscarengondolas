package statics;

import java.util.Date;
import java.util.List;

public class PartidaDto {
	private Date fechaPartida;
	private List<ModuloDto> listaModulos;
	
	public List<ModuloDto> getListaModulos() {
		return listaModulos;
	}
	public void setListaModulos(List<ModuloDto> listaModulos) {
		this.listaModulos = listaModulos;
	}
	public Date getFechaPartida() {
		return fechaPartida;
	}
	public void setFechaPartida(Date fechaPartida) {
		this.fechaPartida = fechaPartida;
	} 
	
}
