package ar.com.utn.utn.changuito.utils;

import javax.servlet.http.Cookie;
import javax.servlet.http.HttpServletRequest;

public class CookiesSomosUtils {

	  public static Cookie getCookieByName(final HttpServletRequest request, String cookieName){
		  
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
