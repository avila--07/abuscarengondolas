import ar.com.utn.changuito.model.replay.GameRound;
import ar.com.utn.changuito.persistence.GameRoundDAO;

import javax.servlet.ServletException;
import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import java.io.IOException;
import java.util.ArrayList;
import java.util.List;

public final class PartidasServlet extends HttpServlet {
    private static final long serialVersionUID = 1L;

    @Override
    protected void doGet(final HttpServletRequest req, final HttpServletResponse resp) throws ServletException, IOException {

        resp.setCharacterEncoding("UTF-8");
        Cookie userCookie = this.getCookieByName(req, "uidValue");

        final String userId = userCookie.getValue().toString();
        final GameRoundDAO gameRoundDAO = new GameRoundDAO();

        final List<String> gameRounds = new ArrayList<>(10);

        for (final GameRound gameRound : gameRoundDAO.getRecentGameRoundsForUser(userId)) {
            gameRounds.add(gameRound.toString());
        }
        req.setAttribute("gameRounds", gameRounds);

        req.getRequestDispatcher("/partidas.jsp").forward(req, resp);
    }

    private boolean isLogued(HttpServletRequest req) {
        Cookie[] cookies = req.getCookies();

        for (int i = 0; i < cookies.length; i++) {
            Cookie cookie1 = cookies[i];
            if (cookie1.getName().equals("loged")) {
                return "Y".equals(cookie1.getValue());
            }
        }
        return false;
    }


    private Cookie getCookieByName(final HttpServletRequest request, String cookieName) {

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

