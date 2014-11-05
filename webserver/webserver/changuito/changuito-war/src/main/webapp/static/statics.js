var tiempoJugado;
var partidasJugadas;
var testObjectSeries ;
var testObjectXAxis ;
var testing ;

$( function() {
////  $( "#tabs" ).tabs();
	//containerSelecProducto, containerModPago,containerModVuelto, containerGenerales
	var createStatsSelecGondolas = function (data) { 
	    var nombresPartidas = getNombresPartidasFromData(data);
	    
		$('#containerSelecGondolas').highcharts({
	        chart: {
	            type: 'column'
	        },
	        title: {
	            text: 'Desempeño en Selección de Góndolas'
	        },
	        xAxis: {
//	            categories: ['Partida 1', 'Partida 2', 'Partida 3', 'Partida 4', 'Partida 5']
	            categories: nombresPartidas
	        },
	        yAxis: {
	            title: {
	                text: 'Cantidad'
	            }
	        },
	        series: [{
	            name: 'Aciertos',
	            data: [1, 0, 4, 8, 6],
	            color: 'green'
	        }, {
	            name: 'Errores',
	            data: [5, 7, 3, 3, 5],
	            color: 'red'
	        }]
	    });
	};
	
	var getNombresPartidasFromData = function(data){
		var array = [];
		var nombrePartida;
		var i;
		for (i = 0; i < data.partidas.length; i++) { 
			nombrePartida = data.partidas[i].data.idPartida + " " + data.partidas[i].data.gameDate ;
			array.push(nombrePartida);
		}
		return array;

	};
	
	var createStatsSelecProducto = function (data) { 
		$('#containerSelecProducto').highcharts({
			chart: {
				type: 'column'
			},
			title: {
				text: 'Desempeño en Selección de Góndolas'
			},
			xAxis: {
				categories: ['Partida 1', 'Partida 2', 'Partida 3', 'Partida 4', 'Partida 5']
			},
			yAxis: {
				title: {
					text: 'Cantidad'
				}
			},
			series: [{
				name: 'Aciertos',
				data: [2, 3, 4, 8, 6],
				color: 'green'
			}, {
				name: 'Errores',
				data: [5, 4, 3, 3, 2],
				color: 'red'
			}]
		});
	};
	
	var createStatsModVuelto = function (data) { 
		$('#containerModVuelto').highcharts({
			chart: {
				type: 'column'
			},
			title: {
				text: 'Desempeño en Selección de Góndolas'
			},
			xAxis: {
				categories: ['Partida 1', 'Partida 2', 'Partida 3', 'Partida 4', 'Partida 5']
			},
			yAxis: {
				title: {
					text: 'Cantidad'
				}
			},
			series: [{
				name: 'Opción 1',
				data: [2, 1, 4, 8, 6],
				color:'yellow'
			}, {
				name: 'Opción 2',
				data: [5, 4, 1, 3, 2],
				color:'blue'
			}
			, {
				name: 'Opción 3',
				data: [1, 4, 3, 3, 2],
				color:'orange'
			}
			, {
				name: 'Opción 4',
				data: [5, 4, 3, 3, 1],
				color:'brown'
			}
			]
		});
	};
	
	var createStatsSelecProducto2 = function () { 
		$('#containerSelecProducto2').highcharts({
			chart: {
				type: 'column'
			},
			title: {
				text: 'Desempeño en Selección de Producto'
			},
			xAxis: {
	            type: 'category'
			},
			yAxis: {
				title: {
					text: 'Cantidad'
				}
			},

	        legend: {
	            enabled: false
	        },

	        plotOptions: {
	            series: {
	                borderWidth: 0,
	                dataLabels: {
	                    enabled: true
	                }
	            }
	        },
	        
			series:[ {
				name:'Partidas',
	            colorByPoint: true,
	            data: [
				{
					name: 'Partida 1',
					y: 2,
					color: 'green',
				    drilldown: 'aciertos1'
				
				},{
					name: 'Partida 2',
					y: 3,
					color: 'green',
					drilldown: 'aciertos2'
							
					},{
						name: 'Partida 3',
						y: 5,
						color: 'green',
						drilldown: 'aciertos3'
								
					}, {
						name: 'Partida 4',
						y: 8,
						color: 'green',
						drilldown: 'aciertos4'
									
					},{
						name: 'Partida 5',
						y:4,
						color: 'green',
						drilldown: 'aciertos5'
					}
				]
				}
			],
			 drilldown: {
		            series: [{
		                id: 'aciertos1',
		                data: [
		                    ['Manzana', 1],
		                    ['Chocolate', 1],
		                    ['Tomate', 1],
		                    ['Agua', 1],
		                    ['Jabón', 1]
		                ]
		            }, {
		                id: 'errores',
		                data: [
		                    ['Banana', 4],
		                    ['Galletitas', 1],
		                    ['Lechuga', 1],
		                    ['Gaseosa', 3],
		                ]
		      }]
			}
		});
	};

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
				text: 'Desempeño'
			},
			xAxis: {
				title: {
					text: 'Fechas partidas'
				},
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
	var i;
	for (i = 0; i < info.listaPartidas; i++) { 
		
		 toReturn.push( info.listaPartidas[i].fechaPartida );
	}
		
	 return toReturn;
  };
  
  var getMeAGame = function(partida){
	  var game = {};
	  game.name = partida.fechaPartida;
	  game.data = [ ]; 
	  game.data.push(partida.listaModulos[0].aciertos);
	  
	  console.log("A game: "+ game);
	  return game;
  };
  
  var getSeries = function(info){
	var arraySeries = [];
	console.log("In getSeries: "+ info.listaPartidas );
	var partidas = info.listaPartidas;  
	var i;
	for (i = 0; i < partidas.length; i++) { 
		
		arraySeries.push(getMeAGame(partidas[i]));
	}
	
	console.log("Array series: " + arraySeries);	 
	
	return arraySeries;
  };


  var init = function(){
	  console.log("Init");

	  $.ajax({
		  type: "GET",
		  url: "/statics",
		  data: { axn:"init" }
	  }).done(function( msg ) {
	    console.log( msg );
	    if (msg!= null){
	    	var data = msg.data;
	    	testing = data; 
	    		
	    	tiempoJugado = data.playTime;
	    	partidasJugadas = data.partidas.length;
	    	
	    	$("#tiempoJugado").text(tiempoJugado+" min");
	    	$("#partidasJugadas").text(partidasJugadas);
	    	
	    	//createChanguitoStats(msg);
	    	createStatsSelecGondolas(data);
	    	createStatsSelecProducto(data);
	    	createStatsModVuelto(data);
	    	
	    }else{
	    	console.log("Errores en la carga de la página");
	    };
	  
	  });

  };
  
  init();
  
});