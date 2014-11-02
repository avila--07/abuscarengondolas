import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

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
			req.setAttribute("onLoadGoTo", "administration");
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
		
		Cookie cookie1 = new Cookie("loged", "Y");
		cookie1.setMaxAge(24*60*60);
		resp.addCookie(cookie1); 

		System.out.println("Do Put Login");

		if(nick!=null && !"".equals(nick) && pass!=null && !"".equals(pass)){
			System.out.println("GoTo barra");
			req.setAttribute("onLoadGoTo", "administration");
			Cookie cookie2 = new Cookie("onLoadGoTo", "administration");
			resp.addCookie(cookie2);
			req.getRequestDispatcher("/").forward(req, resp);
		}else{
			System.out.println("GoTo login");
			req.setAttribute("onLoadGoTo", "login");
			req.getRequestDispatcher("/login.jsp").forward(req, resp);
		}
		
	} catch (ServletException e) {
		e.printStackTrace();
	}
	
}
}