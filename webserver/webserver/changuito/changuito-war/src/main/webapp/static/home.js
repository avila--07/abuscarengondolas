$( document ).ready(function() {
	
$("#stats").on("click", function(){ $("#featured-wrapper").load("/statics") ;});
$("#configuration").on("click", function(){ $("#featured-wrapper").load("/configuration"); });
$("#partidas").on("click", function(){ $("#featured-wrapper").load("/partidas"); });
$("#login").on("click", function(){ $("#featured-wrapper").load("/login") ;});
$("#inicio").on("click", function(){ $("#featured-wrapper").load("/homefatures") ;});

});