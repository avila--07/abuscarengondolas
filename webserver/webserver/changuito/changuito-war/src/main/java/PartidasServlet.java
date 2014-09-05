import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class PartidasServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

  @Override
  public void doGet(HttpServletRequest req, HttpServletResponse resp)
      throws IOException {

	try {
		resp.setCharacterEncoding("UTF-8");
		String gameSelected = req.getParameter("id");
		
		if( gameSelected != null){
			
		}
		
		req.getRequestDispatcher("/partidas.jsp").forward(req, resp);
	
	} catch (ServletException e) {
		e.printStackTrace();
	}

  }
}
