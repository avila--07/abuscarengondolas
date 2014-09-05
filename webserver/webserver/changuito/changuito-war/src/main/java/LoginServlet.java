import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class LoginServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

@Override
  public void doGet(HttpServletRequest req, HttpServletResponse resp)
      throws IOException {
	try {
		req.getRequestDispatcher("/home.jsp").forward(req, resp);
	} catch (ServletException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}

	}

public void doPost(HttpServletRequest req, HttpServletResponse resp)
		throws IOException {
	try {
		String nick = req.getParameter("nickname");
		String pass = req.getParameter("password");
		
		if(nick!=null && !"".equals(nick) && pass!=null && !"".equals(pass)){
			req.getRequestDispatcher("/home.jsp").forward(req, resp);
		}else{
			req.getRequestDispatcher("/login.jsp").forward(req, resp);
		}
		
	} catch (ServletException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}
	
}
}