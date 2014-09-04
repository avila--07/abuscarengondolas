import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class ConfigurationServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

  @Override
  public void doGet(HttpServletRequest req, HttpServletResponse resp)
      throws IOException {

	try {
		req.getRequestDispatcher("/configuration.jsp").forward(req, resp);
	
	} catch (ServletException e) {
		e.printStackTrace();
	}

  }
}