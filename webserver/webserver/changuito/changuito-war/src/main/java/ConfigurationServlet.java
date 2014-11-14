import java.io.IOException;
import java.io.PrintWriter;
import java.util.HashMap;
import java.util.logging.Level;
import java.util.logging.Logger;

import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.google.appengine.api.search.Document;

import ar.com.utn.changuito.architecture.net.SharedObject;
import ar.com.utn.changuito.architecture.services.AbstractService;
import ar.com.utn.changuito.architecture.services.ServiceLocator;
import ar.com.utn.changuito.model.game.Configuration;
import ar.com.utn.changuito.model.game.User;
import ar.com.utn.changuito.persistence.UserDAO;
import ar.com.utn.changuito.services.GetRecentGameRoundsForUserService;
import ar.com.utn.changuito.services.SaveConfigurationService;
import ar.com.utn.utn.changuito.utils.CookiesSomosUtils;

public class ConfigurationServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

  @Override
  public void doGet(HttpServletRequest req, HttpServletResponse resp)
      throws IOException {

	try {
		resp.setCharacterEncoding("UTF-8");
		UserDAO user = new UserDAO();
		Cookie userCookie = CookiesSomosUtils.getCookieByName(req, "uid");
		user.getEntityByEmail(userCookie.getValue());
		Configuration config = (Configuration)user.getEntityByEmail(userCookie.getValue()).getConfiguration();
		req.setAttribute("sounds", config.getEnabledSound());
		req.setAttribute("modpago", config.getPurchaseModule());
		req.setAttribute("quantity", config.getGondolasCount());
		req.setAttribute("savepart", config.getGuardarPartidas());
		req.setAttribute("modvuelto", config.getChangeControlModule());
		
		req.getRequestDispatcher("/configuration.jsp").forward(req, resp);
	
	} catch (ServletException e) {
		e.printStackTrace();
	}

  }
  
  public void doPost(HttpServletRequest req, HttpServletResponse resp)
      throws IOException {  

	try {
		callSaveConfigurationService(req);	
		req.getRequestDispatcher("/configuration.jsp").forward(req, resp);
	} catch (ServletException e) {
		e.printStackTrace();
	}

  } 
		
  private void callSaveConfigurationService(HttpServletRequest req){
	  
	boolean moduloPago  = new Boolean(req.getParameter("modpago"));
	boolean moduloCV = new Boolean( req.getParameter("modvuelto")); 
	int cantidadGondolas =  new Integer(req.getParameter("quantity").toString());
	boolean	sonidos =  new Boolean(req.getParameter("sounds"));
	boolean guardarPartida = new Boolean(req.getParameter("savepart"));  
	
	Configuration config = new Configuration();
	config.set("purm", moduloPago);
	config.set("chcom", moduloCV);
	config.set("goncou", cantidadGondolas);
	config.set("enso", sonidos);
	config.set("guapar", guardarPartida);
	
	
	//Te juro que un dia vengo y te refactorizo! 
	Cookie cookieUser = CookiesSomosUtils.getCookieByName(req,"uid");
	UserDAO userDao = new UserDAO(); 
	User user = userDao.getEntityByEmail(cookieUser.getValue());
	user.setConfiguration(config);
	
	userDao.persist(user);
  }
    
} 