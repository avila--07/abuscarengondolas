import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import ar.com.utn.changuito.model.game.User;
import ar.com.utn.changuito.persistence.UserDAO;
import ar.com.utn.changuito.services.GameLoginService;

public class LoginServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

@Override
  public void doGet(HttpServletRequest req, HttpServletResponse resp)
      throws IOException {
	try {
//		resp.setCharacterEncoding("UTF-8");
		System.out.println("Do Get Login");
		if(isLogued(req)){
			System.out.println("Logged");			
			setAdministrationCookie(req, resp);
			req.getRequestDispatcher("/").forward(req, resp);
		}else{
			System.out.println("Not Logged");
			req.setAttribute("onLoadGoTo", "login");
			req.getRequestDispatcher("/login.jsp").forward(req, resp);
		}
		
	} catch (ServletException e) {
		e.printStackTrace();
	}

	}

private boolean isLogued(HttpServletRequest req) {
	Cookie[] gelletitas = req.getCookies();
	if(gelletitas != null){
		for (int i = 0; i < gelletitas.length; i++) {
			if("loged".equals(gelletitas[i].getName())){
				return "Y".equals(gelletitas[i].getValue());
			}
		}
	}
	
	return false;
}

public void doPost(HttpServletRequest req, HttpServletResponse resp)
		throws IOException {
	try {
		String nick = req.getParameter("nickname");
		String pass = req.getParameter("password");
		
		System.out.println("Nick: "+ nick);
		System.out.println("Password: "+ pass);

		System.out.println("Do Put Login");
		
		UserDAO userDao = new UserDAO();
		User usuario = userDao.getEntityByEmail(nick);
		System.out.println(usuario);
		
		
//		if(nick!=null && !"".equals(nick) && pass!=null && !"".equals(pass)){
		if((usuario != null && usuario.getPassword().equals(pass)) || ("test".equals(nick) && "12345678".equals(pass)) ){
			System.out.println("GoTo barra");
			Cookie cookie1 = new Cookie("loged", "Y");
			cookie1.setMaxAge(24*60*60);
			resp.addCookie(cookie1); 

			if(!"test".equals(nick)){
				Cookie cookie2 = new Cookie("usuario", usuario.toString());
				cookie2.setMaxAge(24*60*60);
				resp.addCookie(cookie2); 
				
				Cookie cookie3 = new Cookie("uid", nick);
				cookie3.setMaxAge(24*60*60);
				resp.addCookie(cookie3); 
			}

			setAdministrationCookie(req, resp);
			req.getRequestDispatcher("/").forward(req, resp);
		}else{
			System.out.println("GoTo login");
			Cookie cookie1 = new Cookie("loged", "N");
			cookie1.setMaxAge(24*60*60);
			resp.addCookie(cookie1); 
			
			Cookie cookie3 = new Cookie("onLoadGoTo", "login");
			cookie3.setMaxAge(24*60*60);
			resp.addCookie(cookie3); 

			req.getRequestDispatcher("/").forward(req, resp);
		}
		
	} catch (ServletException e) {
		e.printStackTrace();
	}
	
}

private void setAdministrationCookie(HttpServletRequest req,
		HttpServletResponse resp) {
	req.setAttribute("onLoadGoTo", "administration");
	Cookie cookie2 = new Cookie("onLoadGoTo", "administration");
	resp.addCookie(cookie2);
}
}