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

	$("#ver_st").on("click", function(){ $("#featured-wrapper").load("/statics") ;});
	$("#ver_conf").on("click", function(){ $("#featured-wrapper").load("/configuration") ;});
	$("#ver_part").on("click", function(){ $("#featured-wrapper").load("/partidas") ;});
	
});

var logout = function(){
	console.log("is time bye bye");
	$.cookie("loged","N");
	$.cookie("onLoadGoTo", "login");

	$("#stats").remove();
	$("#configuration").remove();
	$("#partidas").remove();
	
	$("#loginLink").text("Login");

	$("#featured-wrapper").load("/login");
} 