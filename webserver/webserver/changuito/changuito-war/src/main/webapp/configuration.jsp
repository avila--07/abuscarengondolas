<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>

<html>

<head><title>Página de configuración</title></head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Le styles -->
    <link href="/frontendhome/css/bootstrap.min.css" rel="stylesheet">
    <link href="/frontendhome/css/bootstrap-responsive.min.css" rel="stylesheet">
    <link href='http://fonts.googleapis.com/css?family=Fjalla+One' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Merienda:700' rel='stylesheet' type='text/css'>
    <link href="/frontendhome/css/style.css" rel="stylesheet">
	
  <body>

	<div id="wrapper">
	<div id="featured-wrapper">
		<div class="container">
  
        <h1><%="Configurá la forma de jugar" %></h1>
		<br>
			<form action="/home" method="get">
			<div class="styleform">
			<fieldset id="inputs">
				<p><label for="quantity">Cantidad de productos:</label>						<input name="quantity" 	type="number" min="2" max="6"></p>
				<br>
				<p><label for="modpago">Habilitar módulo de pago:</label>  					<input name="modpago" 	type="checkbox"></p>
				<br>
				<p><label for="modvuelto">Habilitar módulo control de vuelto:</label>  		<input name="modvuelto" type="checkbox"></p>
				<br>
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