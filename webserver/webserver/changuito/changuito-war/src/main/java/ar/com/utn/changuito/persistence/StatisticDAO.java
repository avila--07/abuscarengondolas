package ar.com.utn.changuito.persistence;

import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;

import org.json.simple.JSONArray;

import ar.com.utn.changuito.architecture.persistence.AbstractGAEDAO;
import ar.com.utn.changuito.architecture.persistence.DomainModelValidationException;
import ar.com.utn.changuito.model.statistics.Statistic;

import com.google.appengine.api.datastore.Query.Filter;
import com.google.appengine.api.datastore.Query.FilterOperator;
import com.google.appengine.api.datastore.Query.FilterPredicate;

public final class StatisticDAO extends AbstractGAEDAO<Statistic> {

    public StatisticDAO() {
        super(Statistic.class);
    }

    @Override
    protected String getGAEEntityKind() {
        return "Statistic";
    }

    @Override
    protected void validateDomainEntity(final Statistic entityModel) throws DomainModelValidationException {

    }
    
    @Override
    public Statistic getEntityById(Long id) {
    	
//    	return crearUnFalsoObjetoDeStadisticas();
    	System.out.println("Get Games for 81IQL5EEV5QZ30G");
    	return crearUnFalsoObjetoDeStadisticas("81IQL5EEV5QZ30G");
    }
    
    private Statistic crearUnFalsoObjetoDeStadisticas(String usuario) {
    	long IDJUEGO = 1L;
    	long USUARIO = 1L;
    	
    	System.out.println("Get filter for 81IQL5EEV5QZ30G");
    	Filter sameUserFilter =
    			  new FilterPredicate("uid",
    			                      FilterOperator.EQUAL,
    			                      usuario);
    	
    	Iterable<Statistic> entities = getEntitiesAndIterate(sameUserFilter,10,0);
    	
    	System.out.println("Entyties for 81IQL5EEV5QZ30G "+ entities);
    	int offset = 0;
    	Iterator<Statistic> it = entities.iterator();
    	boolean seguir = it.hasNext();
    	List<Agrupacion> eventosPorPartida = new ArrayList<Agrupacion>();
    	
    	while (seguir){
			while (it.hasNext()) {
				agregarUnEvento(eventosPorPartida,it.next());
			}
			
			offset += 10;
			entities = getEntitiesAndIterate(sameUserFilter,10,offset);
			it = entities.iterator();
			seguir = it.hasNext();
    	}
    	
    	//Lugar para traer todos los juegos
    	Statistic juego = getAGameById(IDJUEGO, USUARIO);
    	Statistic juego2 = getAGameById(IDJUEGO + 1, USUARIO);
    	Statistic juego3 = getAGameById(IDJUEGO + 2, USUARIO);
    	
    	Statistic estadisticas = new Statistic();
    	
    	JSONArray partidas = new JSONArray();
    	partidas.add(juego);
    	partidas.add(juego2);
    	partidas.add(juego3);
    	
    	estadisticas.set("partidas",partidas);
    	
    	estadisticas.setPlayTime("56:23");
    	
    	return estadisticas;
    	
    }

    private void agregarUnEvento(List<Agrupacion> eventosPorPartida,Statistic evento) {
    	for (Agrupacion agrupacion : eventosPorPartida) {
			if(agrupacion.getNumeroPartida() == evento.getIdPartida() ){
				agrupacion.agregarEvento(evento);
				
			}
		}
	}

	private Statistic crearUnFalsoObjetoDeStadisticas() {
    	long IDJUEGO = 1L;
    	long USUARIO = 1L;
    	//Lugar para traer todos los juegos
    	Statistic juego = getAGameById(IDJUEGO, USUARIO);
    	Statistic juego2 = getAGameById(IDJUEGO + 1, USUARIO);
    	Statistic juego3 = getAGameById(IDJUEGO + 2, USUARIO);
    	
    	Statistic estadisticas = new Statistic();
    	
    	JSONArray partidas = new JSONArray();
    	partidas.add(juego);
    	partidas.add(juego2);
    	partidas.add(juego3);
    	
    	estadisticas.set("partidas",partidas);
    	
    	estadisticas.setPlayTime("56:23");
    	
    	return estadisticas;
    	
    }
    
	private Statistic getAGameById(long iDJUEGO, long uSUARIO) {
		//Buscar las estadísticas del juego
		return populateFakeStatics(iDJUEGO,uSUARIO);
	}

	private Statistic populateFakeStatics(long iDJUEGO, long uSUARIO) {
    	Statistic statistics = new Statistic();
    	statistics.setId(iDJUEGO);
    	statistics.setIdUsuario(uSUARIO);
    	statistics.setIdPartida(iDJUEGO*iDJUEGO);
    	statistics.setGameDate(new Date().toString());
    	statistics.setPlayTime("10:30");
    	
    	statistics.set("ModuloSeleccionGondolas", getAFakeSelecGondolas(iDJUEGO,uSUARIO));
    	statistics.set("ModuloSeleccionProducto", getAFakeSeleccionProducto(iDJUEGO,uSUARIO));
    	statistics.set("ModuloPago", getAFakeModuloPago(iDJUEGO,uSUARIO));
    	statistics.set("ModuloVuelto", getAFakeModVuelto(iDJUEGO,uSUARIO));
    	
    	statistics.set("Aciertos", getEventosSumarizados(statistics, "aciertos"));
    	statistics.set("Errores", getEventosSumarizados(statistics, "errores"));
    	
    	return statistics;
    }

    private Integer getEventosSumarizados(Statistic statistic, String lookup) {
    	Integer sumarizado = 0;
    	
    	sumarizado += getValoresIntermedios(statistic, lookup,"ModuloSeleccionGondolas", sumarizado);
    	sumarizado += getValoresIntermedios(statistic, lookup,"ModuloSeleccionProducto", sumarizado);
    	sumarizado += getValoresIntermedios(statistic, lookup,"ModuloPago", sumarizado);
    	sumarizado += getValoresIntermedios(statistic, lookup,"ModuloVuelto", sumarizado);
    	
    	return sumarizado;
	}

	private Integer getValoresIntermedios(Statistic statistic, String lookup,String lookupEscena,Integer sumarizado) {
		Integer intermedio = 0;
		
		Statistic escena = (Statistic) statistic.getSharedObject(lookupEscena);
    	if (escena != null){
    		intermedio = (Integer) escena.get(lookup);
    		if(intermedio != null){
    			sumarizado += intermedio;
    		}
    	}
		return sumarizado;
	}


	private Object getAFakeSelecGondolas(long iDJUEGO, long uSUARIO) {
    	Statistic selecGondolas = new Statistic();
    	selecGondolas.setId(iDJUEGO);
    	selecGondolas.setIdUsuario(uSUARIO);
    	selecGondolas.setIdPartida(iDJUEGO*iDJUEGO);
    	selecGondolas.setGameDate(new Date().toString());
    	selecGondolas.setPlayTime("05:45");
    	selecGondolas.set("aciertos", 6);
    	selecGondolas.set("errores", 2);
    	
    	return selecGondolas;
    }
    private Object getAFakeSeleccionProducto(long iDJUEGO, long uSUARIO) {
    	Statistic seleccionProducto = new Statistic();
    	seleccionProducto.setId(iDJUEGO);
    	seleccionProducto.setIdUsuario(uSUARIO);
    	seleccionProducto.setIdPartida(iDJUEGO*iDJUEGO);
    	seleccionProducto.setGameDate(new Date().toString());
    	seleccionProducto.setPlayTime("03:30");
    	seleccionProducto.set("aciertos", 4);
    	seleccionProducto.set("errores", 7);
    	
    	return seleccionProducto;
    }
    private Object getAFakeModuloPago(long iDJUEGO, long uSUARIO) {
    	Statistic moduloPago = new Statistic();
    	moduloPago.setId(iDJUEGO);
    	moduloPago.setIdUsuario(uSUARIO);
    	moduloPago.setIdPartida(iDJUEGO*iDJUEGO);
    	moduloPago.setGameDate(new Date().toString());
    	moduloPago.setPlayTime("08:30");
    	moduloPago.set("aciertos", 2);
    	moduloPago.set("errores", 3);
    	
    	return moduloPago;
    }
    private Object getAFakeModVuelto(long iDJUEGO, long uSUARIO) {
    	Statistic modVuelto = new Statistic();
    	modVuelto.setId(iDJUEGO);
    	modVuelto.setIdUsuario(uSUARIO);
    	modVuelto.setIdPartida(iDJUEGO*iDJUEGO);
    	modVuelto.setGameDate(new Date().toString());
    	modVuelto.setPlayTime("08:56");
    	modVuelto.set("aciertos", 2);
    	modVuelto.set("errores", 3);
    	
    	return modVuelto;
    }

}
