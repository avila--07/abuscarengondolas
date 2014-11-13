import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.management.RuntimeErrorException;
import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.AbstractService;
import ar.com.utn.changuito.architecture.services.GameServicesServlet;
import ar.com.utn.changuito.architecture.services.ServiceLocator;
import ar.com.utn.changuito.model.game.User;
import ar.com.utn.changuito.model.replay.GameRound;
import ar.com.utn.changuito.persistence.UserDAO;
import ar.com.utn.changuito.services.GetRecentGameRoundsForUserService;

public final class PartidasServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

  @Override
  protected void doGet(final HttpServletRequest req, final HttpServletResponse resp) throws ServletException, IOException {

        resp.setCharacterEncoding("UTF-8");
        Cookie userCookie = this.getCookieByName(req, "uid");
        //TODO: con estos objetos armo la tabla ...
        SharedObject objects = callGameRoundsForUserService(userCookie.getValue().toString());
		
        req.getRequestDispatcher("/partidas.jsp").forward(req, resp);
  }
  
  private SharedObject callGameRoundsForUserService(String user){
	
	  //REVIEW: tal vez podriamos tener un catalogo de servicios.
	  String serviceId = new GetRecentGameRoundsForUserService().getId();
	  SharedObject serviceResponse = null;
	  try {
		  UserDAO userDao = new UserDAO();
   		  User usuario = userDao.getEntityByEmail(user);
		  
		  final GetRecentGameRoundsForUserService service = (GetRecentGameRoundsForUserService) ServiceLocator.getInstance().getService(serviceId);
	
	      serviceResponse = service.call(usuario);
	      
	      if (serviceResponse == null) {
	          serviceResponse = new SharedObject();
	      }
	  } catch (final Exception exception) {
		  Logger.getLogger(AbstractService.class.getName()).log(Level.SEVERE, "Exception calling [" + serviceId + "] service the reason is [" + exception.getMessage() + "]");
	  }
	  return serviceResponse; 
  }
      
  private boolean isLogued(HttpServletRequest req) {
    Cookie[] cookies = req.getCookies();
    
    for(int i = 0; i < cookies.length; i++) { 
        Cookie cookie1 = cookies[i];
        if (cookie1.getName().equals("loged")) {
        	return "Y".equals(cookie1.getValue());
        }
    }  
    return false;
}

  
  private Cookie getCookieByName(final HttpServletRequest request, String cookieName){
	  
    Cookie[] cookies = request.getCookies();
	
	  if (cookies != null) {
	   for (Cookie cookie : cookies) {
	     if (cookie.getName().equals(cookieName)) {
	    	 return cookie;
	     }
	    }
	  }
	  
	  throw new RuntimeException("No se encuentra la cookie");
  }
}

