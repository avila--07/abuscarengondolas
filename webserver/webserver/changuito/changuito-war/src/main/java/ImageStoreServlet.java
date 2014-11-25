import java.io.IOException;
import java.net.URL;

import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import com.google.appengine.api.datastore.*;

import com.google.appengine.api.urlfetch.HTTPHeader;
import com.google.appengine.api.urlfetch.HTTPResponse;
import com.google.appengine.api.urlfetch.URLFetchService;
import com.google.appengine.api.urlfetch.URLFetchServiceFactory;

/**
 * GET requests fetch the image at the URL specified by the url query string
 * parameter, then persist this image along with the title specified by the
 * title query string parameter as a new Movie object in App Engine's
 * datastore.
 */
public class ImageStoreServlet extends HttpServlet {

    /**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Override
    public void doPost(HttpServletRequest req, HttpServletResponse resp) throws IOException {
		
		System.out.println(req.toString());
		
//        URLFetchService fetchService =
//            URLFetchServiceFactory.getURLFetchService();
//
//        // Fetch the image at the location given by the url query string parameter
//        HTTPResponse fetchResponse = fetchService.fetch(new URL(
//                req.getParameter("url")));
//        
//        String fetchResponseContentType = null;
//        for (HTTPHeader header : fetchResponse.getHeaders()) {
//            // For each request header, check whether the name equals
//            // "Content-Type"; if so, store the value of this header
//            // in a member variable
//            if (header.getName().equalsIgnoreCase("content-type")) {
//                fetchResponseContentType = header.getValue();
//                break;
//            }
//        }

//        if (fetchResponseContentType != null) {
//            // Create a new Movie instance
//        	ImageStatics movie = new ImageStatics();
//            movie.setTitle(req.getParameter("title"));
//            movie.setImageType(fetchResponseContentType);
//
//            // Set the movie's promotional image by passing in the bytes pulled
//            // from the image fetched via the URL Fetch service
//            movie.setImage(fetchResponse.getContent());
//            DatastoreService datastore = DatastoreServiceFactory.getDatastoreService();
//            
//            Entity et = new Entity(KeyFactory.createKey(ImageStatics.class.toString(), movie.hashCode()));
//            et.setProperty("data", movie);
//            datastore.put(et);
//
////            PersistenceManager pm = JDOEntityManagerFactory.get().getPersistenceManager();
////            try {
////                // Store the image in App Engine's datastore
////                pm.makePersistent(movie);
////            } finally {
////                pm.close();
////            }
//        }
    }
}