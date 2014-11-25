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
    	
    	System.out.println("Get Games for 81IQL5EEV5QZ30G");
    	return crearUnFalsoObjetoDeStadisticas("81IQL5EEV5QZ30G");
    }
    
    public Statistic getEntityById(String idUser) {
    	
    	System.out.println("Get Games for "+idUser);
    	return crearUnFalsoObjetoDeStadisticas(idUser);
    }
    
    private Statistic crearUnFalsoObjetoDeStadisticas(String usuario) {
    	System.out.println("Get filter for "+usuario);
    	Filter sameUserFilter =
    			  new FilterPredicate("uid",
    			                      FilterOperator.EQUAL,
    			                      usuario);
    	
    	Iterable<Statistic> entities = getEntitiesAndIterate(sameUserFilter,10,0);
    	
    	System.out.println("Entyties for "+ usuario + entities);
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
    	
    	System.out.println("eventosPorPartida: "+ eventosPorPartida.size());
    	
    	JSONArray partidas = new JSONArray();
    	for (Agrupacion agrupacion : eventosPorPartida) {
    		System.out.println("Partida: "+ agrupacion.getNumeroPartida() +" eventos: "+ agrupacion.getEventos().size());
    		Statistic juego = getAGameFromEvents(agrupacion);
    		partidas.add(juego);
		}
    	
    	Statistic estadisticas = new Statistic();
    	estadisticas.set("partidas",partidas);
    	
    	try {
    		estadisticas.setPlayTime(getTiempoJugadoSumarizados(estadisticas));
		} catch (Exception e) {
			System.out.println(e.getStackTrace());
			estadisticas.setPlayTime("56:45");
		}
    	
    	
    	return estadisticas;
    }

    private String getTiempoJugadoSumarizados(Statistic estadisticas) {
    	Long sumaTotal = 0L;
    	List<Statistic> partidas = (List<Statistic>) estadisticas.get("partidas");
    	for (Statistic object : partidas) {
    		try {
    			System.out.println(object.getPlayTime());
    			
    			Long parcial = getSumaPorModulos(object);
       			if(parcial != null){
    				sumaTotal += parcial;
    			}
			} catch (NumberFormatException e) {
				// TODO: handle exception
			}
			
		}
    	return sumaTotal.toString();
	}

	private Long getSumaPorModulos(Statistic object) {
		return getSuma(object,"playTime");
	}

	private Statistic getAGameFromEvents(Agrupacion agrupacion) {
    	List<Statistic> listaEventos = agrupacion.getEventos();
    	Statistic statistics = new Statistic();

    	if(listaEventos != null && listaEventos.size() > 0){
    		statistics.setId(listaEventos.get(0).getIdPartida());
    		statistics.setIdUsuario(listaEventos.get(0).getIdUsuario());
    		statistics.setIdPartida(listaEventos.get(0).getIdPartida());
    		statistics.setGameDate(listaEventos.get(0).getGameDate());
    		
    		for (Statistic evento : listaEventos) {
    			System.out.println("Id evento: "+evento.getIdEvento());
    			if("fin_gondolas".equals(evento.getIdEvento())){
    				statistics.set("ModuloSeleccionGondolas", getSelectGondolas(evento));
    			}
    			
    			if("fin_producto".equals(evento.getIdEvento())){
    				statistics.set("ModuloSeleccionProducto", getSeleccionProducto(evento));
    			}

    			if("fin_CV".equals(evento.getIdEvento())){
    				statistics.set("ModuloVuelto", getModVuelto(evento));
    			}


    			if("fin_pago".equals(evento.getIdEvento())){
    				statistics.set("ModuloPago", getModuloPago(evento));
    			}
    			
    			if("fin_juego".equals(evento.getIdEvento())){
    				//statistics
    			}
    		}
    		    		
    	}else{
    		System.out.println("No hay estadísticas para mostrar");
    	}
    	
    	statistics.set("Aciertos", getSuma(statistics, "aciertos"));
    	statistics.set("Errores", getSuma(statistics, "errores"));

    	return statistics;
	}

    private Object getModuloPago(Statistic evento) {
    	Statistic moduloPago = setCommond(evento);
    	
    	moduloPago.set("monto", evento.getLong("monto"));
    	moduloPago.set("pago", evento.getLong("pago"));
    	
    	return moduloPago;
	}

	private Object getSelectGondolas(Statistic evento) {
    	Statistic selectGondolas = setCommond(evento);
    	
    	selectGondolas.set("aciertos", 1);
    	selectGondolas.set("errores", evento.getLong("failedGondolas"));
    	
    	return selectGondolas;
	}

	private Object getSeleccionProducto(Statistic evento) {
    	Statistic seleccionProducto = setCommond(evento);
    	
    	seleccionProducto.set("aciertos", 1);
    	seleccionProducto.set("errores", evento.getLong("failedProducts"));
    	
    	return seleccionProducto;
    }
    
    private Object getModVuelto(Statistic evento) {
    	Statistic modVuelto = setCommond(evento);
    	
    	modVuelto.set("aciertos", 1);
    	modVuelto.set("errores", evento.getLong("failedVuelto"));
    	
    	return modVuelto;
    }

	private Statistic setCommond(Statistic evento) {	
		Statistic seleccionProducto = new Statistic();
    	seleccionProducto.setIdUsuario(evento.getIdUsuario());
    	seleccionProducto.setIdPartida(evento.getIdPartida());
    	seleccionProducto.setGameDate(evento.getGameDate());
    	seleccionProducto.setPlayTime(evento.getPlayTime());
		return seleccionProducto;
	}


	private void agregarUnEvento(List<Agrupacion> eventosPorPartida,Statistic evento) {
    	boolean createNew = true;
    	
    	for (Agrupacion agrupacion : eventosPorPartida) {
			if(agrupacion.getNumeroPartida() == evento.getIdPartida() ){
				agrupacion.agregarEvento(evento);
				createNew = false;
				break;
			}
		}

    	if(createNew){
    		Agrupacion nuevoElemento = new Agrupacion(evento.getIdPartida());
    		nuevoElemento.agregarEvento(evento);
    		eventosPorPartida.add(nuevoElemento);
    	}
	}

	private Long getSuma(Statistic statistic, String lookup) {
		Long sumarizado = new Long(0L);
		if(statistic != null){
			sumarizado += newGetSumasIntermedias(statistic, lookup,"ModuloSeleccionGondolas");
			sumarizado += newGetSumasIntermedias(statistic, lookup,"ModuloSeleccionProducto");
			sumarizado += newGetSumasIntermedias(statistic, lookup,"ModuloVuelto");
			System.out.println("lookup: " + lookup +" sumarizado: "+sumarizado);
			
		}else{
			System.out.println("Tenemos un error estamos intentando hacer sumas para stadíscticas nulas");
		}
		
		return sumarizado;
	}
	
	private Long newGetSumasIntermedias(Statistic statistic, String lookup,String lookupEscena) {
		Long intermedio = new Long(0L);
		try {
			System.out.println("lookupEscena: "+ lookupEscena);
			Statistic escena = (Statistic) statistic.getSharedObject(lookupEscena);
			if (escena != null){
				System.out.println("lookup: " + lookup +" value: "+escena.getLong(lookup));
				intermedio = escena.getLong(lookup);
				if(intermedio != null){
					return intermedio;
				}else{
					return 0L;
				}
			}			
		} catch (NullPointerException e) {
			//You are far far away from home if this code doesnt like you I really sorry
			System.out.println("Este módulo no existe para esta partida "+ lookupEscena);
		}	
		return intermedio;
	}
	
	private Long getSumasIntermedias(Statistic statistic, String lookup,String lookupEscena,Long sumarizado) {
		Long intermedio = new Long(0L);
		try {
			System.out.println("lookupEscena: "+ lookupEscena);
			Statistic escena = (Statistic) statistic.getSharedObject(lookupEscena);
			if (escena != null){
				System.out.println("lookup: " + lookup +" value: "+escena.getLong(lookup));
				intermedio = escena.getLong(lookup);
				if(intermedio != null){
					intermedio = sumarizado + intermedio;
				}
			}			
		} catch (NullPointerException e) {
			//You are far far away from home if this code doesnt like you I really sorry
			System.out.println("Este módulo no existe para esta partida "+ lookupEscena);
		}	
		return intermedio;
	}
	
	
	//De acá para abajo son datos harcodeados
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
    	sumarizado += getValoresIntermedios(statistic, lookup,"ModuloVuelto", sumarizado);
//    	sumarizado += getValoresIntermedios(statistic, lookup,"ModuloPago", sumarizado);
    	
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
