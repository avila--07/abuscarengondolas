import java.io.IOException;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.json.simple.JSONArray;

import statics.ModuloControlDeVueltoDto;
import statics.ModuloDto;
import statics.ModuloPagoDto;
import statics.ModuloSeleccionGondolaDto;
import statics.ModuloSeleccionProductoDto;
import statics.PartidaDto;
import statics.StaticsObjectDto;
import ar.com.utn.changuito.model.statistics.JuegoStatistic;
import ar.com.utn.changuito.model.statistics.Statistic;
import ar.com.utn.changuito.persistence.StatisticDAO;

import com.google.gson.Gson;

public class StaticsServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

  @Override
  public void doGet(HttpServletRequest req, HttpServletResponse resp)
      throws IOException {
	  
	try {
		
		String axn = req.getParameter("axn");
		if(axn != null){
			if("init".equals(axn)){
				dispatchInit(req,resp);	
			}

		}else{
			resp.setCharacterEncoding("UTF-8");
			req.getRequestDispatcher("/statics.jsp").forward(req, resp);
		}
	
	} catch (ServletException e) {
		e.printStackTrace();
	}

  }

  private void dispatchInit(HttpServletRequest req, HttpServletResponse resp) {
	  Gson gson = new Gson();
//	  StaticsObjectDto statics = crearObjetoDeStadisticas();
	  Statistic statics = getAllGames(1L);
	  String response = gson.toJson(statics);
	  
	  resp.setContentType("application/json");
	  try {
		resp.getWriter().write(response);
	  
	  } catch (IOException e) {
		e.printStackTrace();
	  }
	  
  }

private Statistic getAllGames(long uSUARIO) {
	StatisticDAO dao = new StatisticDAO();	
	System.out.println("Get All Games");
	Statistic statistics = dao.getEntityById(uSUARIO);
	System.out.println("Got All Games");

	return statistics;
}


//private JuegoStatistic getAJuego(long IDJUEGO, long USUARIO) {
//	JuegoStatistic juego = new JuegoStatistic();
//		juego.setId(IDJUEGO);
//		juego.setCantidadModulos(4);
//		juego.setCantidadGondolas(4);
//		juego.setIdUsuario(USUARIO);
//		juego.setIdPartida(IDJUEGO);
//		juego.setPlayTime("17/10/14 21:00");
//		juego.setIdEvento("Inicio");
//	return juego;	
//}
//
//private StaticsObjectDto crearObjetoDeStadisticas() {
//	StaticsObjectDto statics = new StaticsObjectDto();
//	  statics.setMinutosJugados(90);	
//	  statics.setPartidasJugados(10);
//	  Calendar cal = Calendar.getInstance();
//	  
//	  List<PartidaDto> listaPartidas = new ArrayList<PartidaDto>();
//	  
//	  PartidaDto partida1 = dameUnaPartida(0,new Date());
//
//	  cal.setTime(new Date());
//	  cal.add(Calendar.DATE, +1);
//	  PartidaDto partida2 = dameUnaPartida(1,cal.getTime());
//
//	  cal.setTime(new Date());
//	  cal.add(Calendar.DATE, +2);
//	  PartidaDto partida3 = dameUnaPartida(2,cal.getTime());
//
//	  cal.setTime(new Date());
//	  cal.add(Calendar.DATE, +3);
//	  PartidaDto partida4 = dameUnaPartida(3,cal.getTime());
//	  
//	  listaPartidas.add(partida1);	  
//	  listaPartidas.add(partida2);	  
//	  listaPartidas.add(partida3);	  
//	  listaPartidas.add(partida4);
//	  
//	  statics.setListaPartidas(listaPartidas);
//	  
//	return statics;
//}
//
//private PartidaDto dameUnaPartida(Integer partida, Date fecha) {
//	PartidaDto partida1 = new PartidaDto();
//		  partida1.setFechaPartida(fecha);
//		  
//		  List<ModuloDto> listaModulos = new ArrayList<ModuloDto>();
//		  	ModuloControlDeVueltoDto mcdv1 = new ModuloControlDeVueltoDto();
//			  	mcdv1.setAciertos(partida*2 + 1);	
//			  	mcdv1.setErrores(partida*3 + 2);
//			  	mcdv1.setMinutosJugados(partida/2);
//			  	mcdv1.setTrayectoRecorrido(10);
//		  	listaModulos.add(mcdv1);
//		  	
//		  	ModuloPagoDto mdp1 = new ModuloPagoDto();
//			  	mdp1.setAciertos(partida*3 + 1);	
//			  	mdp1.setErrores(partida*4 + 2);
//			  	mdp1.setMinutosJugados(partida/3);
//			  	mdp1.setTrayectoRecorrido(11);
//		  	listaModulos.add(mdp1);
//		  	
//		  	ModuloSeleccionGondolaDto msg1 = new ModuloSeleccionGondolaDto();
//		  		msg1.setAciertos(partida*1 + 1);	
//		  		msg1.setErrores(partida*2 + 2);
//		  		msg1.setMinutosJugados(partida/1);
//		  		msg1.setTrayectoRecorrido(9);
//		  	listaModulos.add(msg1);
//		  	
//		  	ModuloSeleccionProductoDto msp1 = new ModuloSeleccionProductoDto();
//		  		msp1.setAciertos(partida*3 + 1);	
//		  		msp1.setErrores(partida*2 + 5);
//		  		msp1.setMinutosJugados(partida/4);
//		  		msp1.setTrayectoRecorrido(20);
//		  	listaModulos.add(msp1);
//		  	
//		  partida1.setListaModulos(listaModulos);
//	return partida1;
//}

}