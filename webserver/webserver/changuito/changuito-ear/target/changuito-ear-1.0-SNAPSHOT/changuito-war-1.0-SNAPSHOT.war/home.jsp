<html>
<head><title>Home</title></head>
<style>
h1 {
    text-align: center;
}

h3 {
    text-align: center;
}

</style>
<body>
        <h3><font size="10"><%="Panel de control" %></font> </h3>
        <br>

        <h1><font size="15"><%="A buscar en góndolas" %></font></h1>
        <br>
<div style="float: left; width: 45%;">
	<table style="width:100%">
		  
		  <tr>
		    <td>
				<button type="button"  onClick="location.href='/configuration'" >Configuración del juego</button> 
			</td>
		  </tr>
		  <tr>
		    <td>
				<button type="button"  onClick="location.href='/partidas'" >Visualización partidas</button> 
			</td>
		  </tr>
		  <tr>
		    <td>
				<button type="button"  onClick="location.href='/statics'" >Visualizar estadísticas</button>
			</td>
		  </tr>
		  <tr>
		    <td>
				<button type="button"  onClick="location.href='/'" >Visualizar online</button> 
			</td>
		  </tr>
		 
	</table>
</div>

<div style="float: right; width: 45%;">
	<img src="/static/mystery-man.jpg"  width="160" height="160" alt="usuario desconocido">
	<br>
	<img src="/static/somos.jpg" height="46" width="90">
</div>

</body>
</html>