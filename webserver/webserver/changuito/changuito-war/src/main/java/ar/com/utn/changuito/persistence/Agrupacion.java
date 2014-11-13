package ar.com.utn.changuito.persistence;

import java.util.ArrayList;
import java.util.List;

import ar.com.utn.changuito.model.statistics.Statistic;

public class Agrupacion {

	private long numeroPartida;
	private List<Statistic> eventosPartida;

	Agrupacion(long idPartida){
		setNumeroPartida(idPartida);
		eventosPartida = new ArrayList<Statistic>();
	}
	
	public void agregarEvento(Statistic evento){
		eventosPartida.add(evento);
	}
	
	public List<Statistic> getEventos(){
		return eventosPartida;
	}
	
	public long getNumeroPartida() {
		return numeroPartida;
	}

	public void setNumeroPartida(long numeroPartida) {
		this.numeroPartida = numeroPartida;
	};
	
}
