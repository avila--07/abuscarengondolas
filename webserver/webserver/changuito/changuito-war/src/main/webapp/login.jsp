<html>
<head><title>Login</title></head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">

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
			<h1><%="Configuraci�n de administrador" %></h1>
			<br>
			<form action="/login" method="post">
			
				<div class="styleform">
				<fieldset id="inputs">
					<p> <label for="nickname">Usuario:</label>
						<input type="text" required name="nickname" id="nickname" placeholder="Ingrese su usuario"/></p>
					<br>
					<p> <label for="password">Contrase�a:</label>
						<input type="password" required name="password" id="password" placeholder="Ingrese su contrase�a"></p>
					<br>
					<p> <label for="secondpassword">Confirmar Contrase�a:</label>
						<input type="password" required name="secondpassword" id="secondpassword" placeholder="Repita su contrase�a"></p>
				</fieldset>
				</div>
			<br>
			<br>
				<p><input id="submitButton" type="button" value="Aceptar" onclick="show()"></p> <!-- type="submit" , sin id -->
			<br>
			</form>
  
		</div>
	</div>
	</div>

	<script src="/static/login.js"></script>
</body>
</html>