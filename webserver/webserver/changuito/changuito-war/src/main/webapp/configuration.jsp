<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>

<html>

<head><title>Página de configuración</title><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Le styles -->
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
        <h1><%="Configurá la forma de jugar" %></h1>
		<br>
			<form action="/home" method="get">
			<div class="styleform">
			<fieldset id="inputs">
				<p> <label>Cantidad de productos:</label>
					<input name="quantity" type="number" min="2" max="6" title="Cantidad de productos que deberán ser comprados en el juego"></p>
				<br>
				<p> <label for="modpago">Habilitar Módulo de pago:</label>
					<input name="modpago" type="checkbox" title="Luego de completar la selección de los productos se activará la actividad para pagar la compra"></p>
				<br>
				<p> <label for="modvuelto">Habilitar Módulo de control de vuelto:</label>
					<input name="modvuelto" type="checkbox" title="Luego de completar el pago, se activará la actividad para verificar el vuelto a recibir"></p>
				<br>
				<p> <label for="savepart">Guardar partidas:</label>
					<input name="savepart" type="checkbox" title="Las partidas serán guardadas para poder ser reproducidas en la web desde la página Partidas"></p>
			</fieldset>
			</div>
				<br>
				<br>
				<p><input id="submitButton" type="button" value="Guardar"></p>  <!-- type="submit" , sin id -->
				<br>
			
			</form>

		</div>
	</div>
	</div>
	
  </body>
</html>