<html>
<head><title>Página de configuración</title></head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
  <body>
        <font size="10"><%="Página de configuración!" %></font>
    <form action="/home" method="get">
	    <br>
	    	<label>Cantidad de productos: </label>  <input type="number" name="quantity" min="1" max="5">
	    <br>
	    	<label>Habilitar módulo de pagos: </label>  <input type="checkbox" name="modpagos" >
	    <br>
	    	<label>Habilitar módulo control de vuelto: </label> <input type="checkbox" name="modvuelto" >
	    <br>
	    	<label>Habilitar módulo de estadísticas: </label>  <input type="checkbox" name="modstadisticas" >
	    <br>
	    
	    <input type="submit" value="Guardar">
	    
    </form>	

  </body>
</html>