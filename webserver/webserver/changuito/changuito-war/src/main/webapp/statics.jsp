<html>
<head>
<title>P�gina de estad�sticas</title>
  <meta charset="utf-8">
  <title>jQuery UI Tabs - Default functionality</title>
  <link rel="stylesheet" href="/stylesheets/themes/smoothness/jquery-ui.css">
  <script src="/static/jquery-1.11.1.min.js"></script>
  <script src="/static/jquery-ui.min.js"></script>
  <script>
  $(function() {
    $( "#tabs" ).tabs();
  });
  </script>
</head>

  <body>
        <font size="10"><%="P�gina de estad�sticas!" %></font>
    <br>
    <form action="/home" method="get">

	    	<label>Estad�sticas de usuario: </label>  
	    <br>
	    	<label>Tiempo total jugado: </label>  <span>80min</span>
	    <br>
	    	<label>Partidas total jugadas: </label>  <span>6</span>
	    <br>

		<div id="tabs">
		  <ul>
		    <li><a href="#tabs-1">Selecci�n de g�ndola</a></li>
		    <li><a href="#tabs-2">Selecci�n de producto</a></li>
		    <li><a href="#tabs-3">Pago</a></li>
		    <li><a href="#tabs-4">Control de vuelto</a></li>
		  </ul>
		  <div id="tabs-1">
			<br>
	    		<label>Aciertos: </label>  <span>20</span>
			<br>
	    		<label>Promedio de desaciertos por aciertos: </label>  <span>20%</span>
			<br>
	    		<label>Trayecto recorrido: </label>  <span>100cm</span>
			<br>
	    		<label>Partidas finalizadas: </label>  <span>3</span>
			<br>
	    		<label>Promedio de tiempo de partidas finalizadas: </label>  <span>10min</span>
			<br>
	    		<label>Tiempo total jugado en el m�dulo: </label>  <span>30min</span>
			
		  </div>
		  <div id="tabs-2">
			<br>
	    		<label>Aciertos: </label>  <span>30</span>
			<br>
	    		<label>Promedio de desaciertos por aciertos: </label>  <span>10%</span>
			<br>
	    		<label>Trayecto recorrido: </label>  <span>100cm</span>
			<br>
	    		<label>Partidas finalizadas: </label>  <span>3</span>
			<br>
	    		<label>Promedio de tiempo de partidas finalizadas: </label>  <span>10min</span>
			<br>
	    		<label>Tiempo total jugado en el m�dulo: </label>  <span>30min</span>

		  </div>
		  <div id="tabs-3">
			<br>
	    		<label>Aciertos: </label>  <span>40</span>
			<br>
	    		<label>Promedio de desaciertos por aciertos: </label>  <span>50%</span>
			<br>
	    		<label>Trayecto recorrido: </label>  <span>100cm</span>
			<br>
	    		<label>Partidas finalizadas: </label>  <span>4</span>
			<br>
	    		<label>Promedio de tiempo de partidas finalizadas: </label>  <span>10min</span>
			<br>
	    		<label>Tiempo total jugado en el m�dulo: </label>  <span>10min</span>

		  </div>
		  <div id="tabs-4">
			<br>
	    		<label>Aciertos: </label>  <span>10</span>
			<br>
	    		<label>Promedio de desaciertos por aciertos: </label>  <span>56%</span>
			<br>
	    		<label>Trayecto recorrido: </label>  <span>100cm</span>
			<br>
	    		<label>Partidas finalizadas: </label>  <span>3</span>
			<br>
	    		<label>Promedio de tiempo de partidas finalizadas: </label>  <span>17min</span>
			<br>
	    		<label>Tiempo total jugado en el m�dulo: </label>  <span>57min</span>

		  </div>
		</div>

	   	<input type="submit" value="Guardar"> | <input type="button" value="compartir">
	     	
    </form>	

  </body>
</html>