<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>

<html>

<head><title>Página de configuración</title><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <!-- Le styles -->
    <link href="/frontendhome/css/bootstrap.min.css" rel="stylesheet">
    <link href="/frontendhome/css/bootstrap-responsive.min.css" rel="stylesheet">
    <link href='http://fonts.googleapis.com/css?family=Fjalla+One' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Merienda:700' rel='stylesheet' type='text/css'>
    <link href="/frontendhome/css/style.css" rel="stylesheet">
<script>
function submitMyForm(){
 document.forms["submitButton"].submit();
}
</script>
</head>

  <body>
	<div id="wrapper">
	<div id="featured-wrapper">
		<div class="container">
		<br>
        <h1><%="Configurá la forma de jugar" %></h1>
		<br>
			<form id="configForm" action="/home" method="get">
			<div class="styleform">
			<fieldset id="inputs">
				<p> <label>Cantidad de productos:</label>
					<input name="quantity" type="number" min="2" max="6" value="quantity" title="Cantidad de productos que deberán ser comprados en el juego"></p>
				<br>
				<p> <label for="modpago">Habilitar Módulo de pago:</label>
					<input name="modpago" id="modpago" type="checkbox" value="modpago" onclick="checkmp()" title="Luego de completar la selección de los productos se activará la actividad para pagar la compra"></p>
				<br>
				<p> <label for="modvuelto">Habilitar Módulo de control de vuelto:</label>
					<input name="modvuelto" id="modvuelto" type="checkbox" value="modvuelto" onclick="checkmv()" title="Luego de completar el pago, se activará la actividad para verificar el vuelto a recibir"></p>
				<br>
				<p> <label for="savepart">Guardar partidas:</label>
					<input name="savepart" id="savepart" type="checkbox" value="savepart" title="Las partidas serán guardadas para poder ser reproducidas en la web desde la página Partidas"></p>
				<br>
				<p> <label for="sounds">Habilitar sonidos:</label>
					<input name="sounds" id="sounds" type="checkbox" value="" title="Podemos habilitar los sonidos del juego"></p>
			</fieldset>
			</div>
				<br>
				<br>
				<p><input id="submitButton" type="button" value="Guardar" onClick="updateStatus()"></p>  <!-- type="submit" , sin id -->
				<br>
			</form>
		</div>
	</div>
	</div>
	
	<script>
	function updateStatus(Status)
	 {
		var form = $('#configForm');

		$.ajax({
			  type: "POST",
			  url: "/configuration",
			  data:form.serialize(),
			  success: function(){
					alert("la configuración se ha guardado satisfactoriamente");
			  }
		});
	}
	</script>
	
	<script src="/static/checkmodules.js"></script>
  </body>
</html>