package ar.com.utn.changuito.architecture.services;

import ar.com.utn.changuito.architecture.net.SharedObject;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

public final class GameServicesServlet extends HttpServlet {

    private static final long serialVersionUID = 121258125781781L;

    @Override
    protected void doGet(final HttpServletRequest req, final HttpServletResponse resp) throws ServletException, IOException {

        String serviceId = "unknown";
        try {
            resp.setCharacterEncoding("UTF-8");

            serviceId = req.getPathInfo().substring(1);
            final SharedObject serviceParameter = getServiceParamaterFromRequest(req);

            final AbstractService service = ServiceLocator.getInstance().getService(serviceId);

            final SharedObject serviceResponse = service.call(serviceParameter);
            resp.getOutputStream().write(serviceResponse.serialize());
        } catch (final Exception exception) {
            Logger.getLogger(AbstractService.class.getName()).log(Level.SEVERE, "Exception calling [" + serviceId + "] service the reason is [" + exception.getMessage() + "]");
            resp.getWriter().write("Server Error");
        }
    }

    @Override
    protected void doPost(final HttpServletRequest req, final HttpServletResponse resp) throws ServletException, IOException {
        doGet(req, resp);
    }

    private SharedObject getServiceParamaterFromRequest(final HttpServletRequest request) {
        try {
            return SharedObject.deserialize(request.getReader().readLine().getBytes() );
        } catch (final Exception exception) {
            throw new RuntimeException(exception.getMessage(), exception);
        }
    }

}
