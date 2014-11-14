<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<link href="/frontendhome/css/bootstrap.min.css" rel="stylesheet">
<link href="/frontendhome/css/bootstrap-responsive.min.css" rel="stylesheet">
<link href='http://fonts.googleapis.com/css?family=Fjalla+One' rel='stylesheet' type='text/css'>
<link href='http://fonts.googleapis.com/css?family=Merienda:700' rel='stylesheet' type='text/css'>
<link href="/frontendhome/css/style.css" rel="stylesheet">
	
<body>
	<div id="wrapper">
	<div id="featured-wrapper">
		<div class="container">
		<br>
			<h1><%="Configuración de administrador" %></h1>
			<br>
			<form action="/login" method="post">
				<div class="styleform">
				<fieldset id="inputs">
					<p> <label for="nickname">Usuario:</label>
						<input type="text" required name="nickname" id="nickname" placeholder="Ingrese su usuario"/></p>
					<br>
					<p> <label for="password">Contraseña:</label>
						<input type="password" required name="password" id="password" placeholder="Ingrese su contraseña"></p>
				</fieldset>
				</div>
			<br>
			<br>
				<p><input id="submitButton" type="submit" value="Aceptar" ></p> <!-- type="submit" , sin id -->
			<br>
			</form>
  
		</div>
	</div>
	</div>
	
	<script src="/static/jquery-2.1.1.min.js"></script>
	<script src="/static/jquery.cookie.js"></script>
	<script src="/static/login.js"></script>
</body>