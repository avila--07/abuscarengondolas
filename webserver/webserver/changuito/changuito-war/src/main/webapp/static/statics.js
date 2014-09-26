var tiempoJugado;

$(function() {
  $( "#tabs" ).tabs();
    
  $.ajax({
	  type: "GET",
	  url: "/statics",
	  data: { axn:"init" }
  }).done(function( msg ) {
    console.log( msg );
    tiempoJugado = msg;
    
    $("#tiempoJugado").text(msg.minutosJugados);
    $("#partidasJugadas").text(msg.partidasJugados);
  
  });
    
});
  