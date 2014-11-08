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


			<div id="mycontainer" style="width:100%; height:400px; display:none"></div>

	 		<div id="containerGenerales" style="width:100%; height:400px;"></div>
			<div id="containerSelecGondolas" style="width:100%; height:400px;"></div>
			<div id="containerSelecProducto" style="width:100%; height:400px;"></div>
			<div id="containerModVuelto" style="width:100%; height:400px;"></div>
	 		<div id="containerModPago" style="width:100%; height:400px;"></div>

			<input type="submit" value="Guardar"> | <input type="button" value="compartir">

			</form>	
		
		</div>
	</div>
	</div>

 <script src="/static/highcharts/highcharts.js"></script>
 <script src="/static/highcharts/drilldown.js"></script>
<!--  <script src="http://code.highcharts.com/modules/drilldown.js"></script> -->
 <script src="/static/d3/d3.js"></script>
 <script src="/static/d3/radialProgress/radialProgress.js"></script>
 <script src="/static/statics.js"></script>
</body>