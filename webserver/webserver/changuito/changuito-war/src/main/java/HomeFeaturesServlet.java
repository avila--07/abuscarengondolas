import java.io.IOException;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class HomeFeaturesServlet extends HttpServlet {
	private static final long serialVersionUID = 1L;

@Override
  public void doGet(HttpServletRequest req, HttpServletResponse resp)
      throws IOException {

	try {
	    resp.setCharacterEncoding("UTF-8");
		req.getRequestDispatcher("/features.html").forward(req, resp);
	} catch (ServletException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}

	}
}