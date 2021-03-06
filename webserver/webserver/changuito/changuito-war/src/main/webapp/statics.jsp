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
				<p><label>Partidas total jugadas:</label>  <span id="partidasJugadas">6min</span></p>
				<br>
				<div style="display:none"> <p><label>Tiempo total jugado:</label>  <span id="tiempoJugado">80min</span></p> </div>
			
			<br>


			<div id="mycontainer" style="width:100%; height:400px; display:none"></div>
			
			<div id="containerGenerales" style="width:100%; height:400px;">
	 		</div>
<!-- 	 			<input type="button" id="containerGenerales-share" class="fb-share-button"> -->
			
			<div id="containerSelecGondolas" style="width:100%; height:400px;">
			</div>
<!-- 	 			<input type="button" id="containerSelecGondolas-share" class="fb-share-button"> -->
			
			<div id="containerSelecProducto" style="width:100%; height:400px;">
			</div>
<!-- 	 			<input type="button" id="containerSelecProducto-share" class="fb-share-button"> -->
			
	 		
	 		<div id="containerModPago" style="width:100%; height:400px;">
	 		</div>
<!-- 	 			<input type="button" id="containerModPago-share" class="fb-share-button"> -->

			<div id="containerModVuelto" style="width:100%; height:400px;">
			</div>
<!-- 	 			<input type="button" id="containerModVuelto-share" class="fb-share-button"> -->
			
			<input type="submit" value="Guardar"/> | <input type="button" value="compartir"/>

<!-- 			<input type="button" id="compartir2" value="compartir2"> -->

			</form>	
		
		</div>
	</div>
	</div>

<script src="/static/jquery-2.1.1.min.js"></script>
<script src="/static/highcharts/highcharts.js"></script>
<script src="/static/highcharts/drilldown.js"></script>
<script src="/static/highcharts/exporting.js"></script>
<script src="/static/d3/d3.js"></script>
<script src="/static/d3/radialProgress/radialProgress.js"></script>
<script src="/static/jquery.cookie.js"></script>
<script src="/static/statics.js"></script>

</body>