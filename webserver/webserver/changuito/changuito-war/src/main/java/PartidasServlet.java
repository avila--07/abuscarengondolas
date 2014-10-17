import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class PartidasServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

  @Override
  public void doGet(HttpServletRequest req, HttpServletResponse resp)
      throws IOException {

	try {
		
//		UserService userService = UserServiceFactory.getUserService();
//		if( userService.isUserLoggedIn() ){
//		if(isLogued(req)){
			resp.setCharacterEncoding("UTF-8");
			String gameSelected = req.getParameter("id");
			
			if( gameSelected != null){
				
			}
			req.getRequestDispatcher("/partidas.jsp").forward(req, resp);
//		}
//		else{
//			req.getRequestDispatcher("/login.jsp").forward(req, resp);
//		}
		
//		}else{
//			userService.createLoginURL("/");
//		}
	
	} catch (ServletException e) {
		e.printStackTrace();
	}

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
}

