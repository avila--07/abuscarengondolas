<html>
<head><title>P�gina de configuraci�n</title></head>
  <body>
        <font size="10"><%="P�gina de configuraci�n!" %></font>
    <form action="/home" method="get">
	    <br>
	    	<label>Cantidad de productos: </label>  <input type="number" name="quantity" min="1" max="5">
	    <br>
	    	<label>Habilitar m�dulo de pagos: </label>  <input type="checkbox" name="modpagos" >
	    <br>
	    	<label>Habilitar m�dulo control de vuelto: </label> <input type="checkbox" name="modvuelto" >
	    <br>
	    	<label>Habilitar m�dulo de estad�sticas: </label>  <input type="checkbox" name="modstadisticas" >
	    <br>
	    
	    <input type="submit" value="Guardar">
	    
    </form>	

  </body>
</html>