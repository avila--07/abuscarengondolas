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
		
			<h1><%="Configuración de administrador" %></h1>
			<br>
			<form action="/login" method="post">
			
				<div class="styleform">
				<fieldset id="inputs">
					<p><label for="nickname">Usuario:</label> 						<input type="text" name="nickname" id="nickname"></p>
					<br>
					<p><label for="password">Contraseña:</label> 					<input type="password" name="password" id="password"></p>
					<br>
					<p><label for="secondpassword">Confirmar Contraseña:</label> 	<input type="password" name="secondpassword" id="secondpassword"></p>
				</fieldset>
				</div>
			<br>
			<br>
				<p><input id="submitButton" type="button" value="Aceptar"></p> <!-- type="submit" , sin id -->
			<br>
			</form>
  
		</div>
	</div>
	</div>
	
</body>
</html>