$( document ).ready(function() {

	FB.api(
	    "/me/picture",
	    function (response) {
	      if (response && !response.error) {
	        /* handle the result */
	    	  console.log(response);
	    	  console.log(response.url);
	      }
	    }
	);

});