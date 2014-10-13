var tiempoJugado;
var testObjectSeries ;
var testObjectXAxis ;

$(function() {
////  $( "#tabs" ).tabs();
//	var createStats = function () { 
//	    $('#container').highcharts({
//	        chart: {
//	            type: 'bar'
//	        },
//	        title: {
//	            text: 'Fruit Consumption'
//	        },
//	        xAxis: {
//	            categories: ['Apples', 'Bananas', 'Oranges']
//	        },
//	        yAxis: {
//	            title: {
//	                text: 'Fruit eaten'
//	            }
//	        },
//	        series: [{
//	            name: 'Jane',
//	            data: [1, 0, 4]
//	        }, {
//	            name: 'John',
//	            data: [5, 7, 3]
//	        }]
//	    });
//	};

	var createChanguitoStats = function (data) { 
		var objectSeries = getSeries(data);
		var objectXAxis = getGamesDate(data);
		testObjectSeries = objectSeries;
		testObjectXAxis = objectXAxis;
		
		$('#mycontainer').highcharts({
			chart: {
				type: 'column'
			},
			title: {
				text: 'Fechas partidas'
			},
			xAxis: {
				categories: objectXAxis
			},
			yAxis: {
				title: {
					text: 'Aciertos'
				}
			},
			series: objectSeries
		});
	};
	
  var getGamesDate = function(info){
	var toReturn = [] ;

	for (i = 0; i < info.listaPartidas; i++) { 
		
		 toReturn.push( info.listaPartidas[i].fechaPartida );
	}
		
	 return toReturn;
  }
  
  var getMeAGame = function(partida){
	  var game = {};
	  game.name = partida.fechaPartida;
	  game.data = [ ]; 
	  game.data.push(partida.listaModulos[0].aciertos);
	  
	  console.log("A game: "+ game);
	  return game;
  }
  
  var getSeries = function(info){
	var arraySeries = [];
	console.log("In getSeries: "+ info.listaPartidas );
	var partidas = info.listaPartidas;  
	
	for (i = 0; i < partidas.length; i++) { 
		
		arraySeries.push(getMeAGame(partidas[i]));
	}
	
	console.log("Array series: " + arraySeries);	 
	
	return arraySeries;
  }

	$.ajax({
	  type: "GET",
	  url: "/statics",
	  data: { axn:"init" }
  }).done(function( msg ) {
    console.log( msg );
    tiempoJugado = msg;
    createChanguitoStats(msg);
  
  });

  var init = function(){
//	  createStats();
  }
  
  init();
  
});