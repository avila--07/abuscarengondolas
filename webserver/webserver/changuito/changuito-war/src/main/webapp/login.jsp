<html>
<head><title>Login</title></head>

<body>
    <h3><font size="10"><%="Configuraci�n de administrador" %></font> </h3>
    <br>

  <form action="/login" method="post">
	  Usuario: 					<input type="text" name="nickname" id="nickname"><br>
	  Contraseña: 				<input type="password" name="password" id="password"><br>
	  Confirmar Contraseña: 	<input type="password" name="secondpassword" id="secondpassword"><br>
	
	
  	<input type="submit" value="Aceptar"><br>
  
  </form>
</body>
</html>