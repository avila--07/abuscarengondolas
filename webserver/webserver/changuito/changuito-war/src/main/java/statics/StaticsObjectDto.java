package statics;

import java.util.List;

public class StaticsObjectDto {
	private Integer minutosJugados;
	private Integer partidasJugados;
	private List<PartidaDto> listaPartidas;
	
	public Integer getMinutosJugados() {
		return minutosJugados;
	}
	public void setMinutosJugados(Integer minutosJugados) {
		this.minutosJugados = minutosJugados;
	}
	public Integer getPartidasJugados() {
		return partidasJugados;
	}
	public void setPartidasJugados(Integer partidasJugados) {
		this.partidasJugados = partidasJugados;
	}
	public List<PartidaDto> getListaPartidas() {
		return listaPartidas;
	}
	public void setListaPartidas(List<PartidaDto> listaPartidas) {
		this.listaPartidas = listaPartidas;
	}
	
	
}
