<html>
<head>
<title>Página de estadísticas</title>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<link rel="stylesheet" href="/stylesheets/themes/smoothness/jquery-ui.css">
	<link rel="stylesheet" href="/static/d3/radialProgress/radialProgressStyle.css">

    <link href="/frontendhome/css/bootstrap.min.css" rel="stylesheet">
    <link href="/frontendhome/css/bootstrap-responsive.min.css" rel="stylesheet">
    <link href='http://fonts.googleapis.com/css?family=Fjalla+One' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Merienda:700' rel='stylesheet' type='text/css'>
    <link href="/frontendhome/css/style.css" rel="stylesheet">
</head>
  <body>
	<div id="wrapper">
	<div id="featured-wrapper">
		<div class="container">
		<br>
        <h1><%="Estadísticas" %></h1>
		<br>
		<form action="/home" method="get">

				<label>Estadísticas de usuario:</label>  
				<br>
				<p><label>Tiempo total jugado:</label>  <span id="tiempoJugado">80min</span></p>
				<br>
				<p><label>Partidas total jugadas:</label>  <span id="partidasJugadas">6min</span></p>
			
			<br>

<!-- 		<div id="tabs"> -->
<!-- 		  <ul> -->
<!-- 		    <li><a href="#tabs-1">Selección de góndola</a></li> -->
<!-- 		    <li><a href="#tabs-2">Selección de producto</a></li> -->
<!-- 		    <li><a href="#tabs-3">Pago</a></li> -->
<!-- 		    <li><a href="#tabs-4">Control de vuelto</a></li> -->
<!-- 		  </ul> -->
<!-- 		  <div id="tabs-1"> -->
<!-- 			<br> -->
<!-- 	    		<label>Aciertos: </label>  <span>20</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Promedio de desaciertos por aciertos: </label>  <span>20%</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Trayecto recorrido: </label>  <span>100cm</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Partidas finalizadas: </label>  <span>3</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Promedio de tiempo de partidas finalizadas: </label>  <span>10min</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Tiempo total jugado en el módulo: </label>  <span>30min</span> -->
			
<!-- 		  </div> -->
<!-- 		  <div id="tabs-2"> -->
<!-- 			<br> -->
<!-- 	    		<label>Aciertos: </label>  <span>30</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Promedio de desaciertos por aciertos: </label>  <span>10%</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Trayecto recorrido: </label>  <span>100cm</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Partidas finalizadas: </label>  <span>3</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Promedio de tiempo de partidas finalizadas: </label>  <span>10min</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Tiempo total jugado en el módulo: </label>  <span>30min</span> -->

<!-- 		  </div> -->
<!-- 		  <div id="tabs-3"> -->
<!-- 			<br> -->
<!-- 	    		<label>Aciertos: </label>  <span>40</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Promedio de desaciertos por aciertos: </label>  <span>50%</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Trayecto recorrido: </label>  <span>100cm</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Partidas finalizadas: </label>  <span>4</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Promedio de tiempo de partidas finalizadas: </label>  <span>10min</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Tiempo total jugado en el módulo: </label>  <span>10min</span> -->

<!-- 		  </div> -->
<!-- 		  <div id="tabs-4"> -->
<!-- 			<br> -->
<!-- 	    		<label>Aciertos: </label>  <span>10</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Promedio de desaciertos por aciertos: </label>  <span>56%</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Trayecto recorrido: </label>  <span>100cm</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Partidas finalizadas: </label>  <span>3</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Promedio de tiempo de partidas finalizadas: </label>  <span>17min</span> -->
<!-- 			<br> -->
<!-- 	    		<label>Tiempo total jugado en el módulo: </label>  <span>57min</span> -->

<!-- 		  </div> -->
<!-- 		</div> -->
			<div id="mycontainer" style="width:100%; height:400px; display:none"></div>

			<div id="containerSelecGondolas" style="width:100%; height:400px;"></div>
			<div id="containerSelecProducto" style="width:100%; height:400px;"></div>
	<!--  		<div id="containerModPago" style="width:100%; height:400px;"></div> -->
			<div id="containerModVuelto" style="width:100%; height:400px;"></div>
	<!--  		<div id="containerGenerales" style="width:100%; height:400px;"></div> -->

			<input type="submit" value="Guardar"> | <input type="button" value="compartir">

			</form>	
		
		</div>
	</div>
	</div>
		
	  <script src="/static/jquery-2.1.1.min.js"></script>
	  <script src="/static/d3/d3.js"></script>
	  <script src="/static/d3/radialProgress/radialProgress.js"></script>
	  <script src="/static/highcharts/highcharts.js"></script>
	  <script src="/static/statics.js"></script>
	  <script src="http://code.highcharts.com/modules/drilldown.js"></script>
  </body>
</html>