<html>
<head>
	<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>

	<title>Partidas históricas</title><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<script type="text/javascript" src="//ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
	<script type='text/javascript' src='/static/loadGame.js'></script>
    <link href="/frontendhome/css/bootstrap.min.css" rel="stylesheet">
    <link href="/frontendhome/css/bootstrap-responsive.min.css" rel="stylesheet">
    <link href='http://fonts.googleapis.com/css?family=Fjalla+One' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Merienda:700' rel='stylesheet' type='text/css'>
    <link href="/frontendhome/css/style.css" rel="stylesheet">
    <script type='text/javascript' src='/static/unityPlayer/jquery.min.js'></script>
	<script type="text/javascript" src='/static/unityPlayer/UnityObject2.js'></script>
	<script type="text/javascript" src='/static/unityPlayer/unityPlayer.js'></script>

	<script src="/static/jquery-2.1.1.min.js"></script>
	
	<!-- DataTables CSS -->
	<link rel="stylesheet" type="text/css" href="//cdn.datatables.net/1.10.4/css/jquery.dataTables.css">
	<!-- DataTables -->
	<script type="text/javascript" charset="utf8" src="//cdn.datatables.net/1.10.4/js/jquery.dataTables.js"></script>

</head>
<body>
	<script>
	$(document).ready( function () {
    $('#table_id').DataTable();
	} );
	</script>	
	<div id="wrapper">
		<div id="featured-wrapper">
			<div class="container">
				<br>
				<h1><%="Seleccioná una partida para verla"%></h1>
					<table id="partidas" style="width:100%">
					    <thead>
					        <tr>
					            <th>Partida</th>
					            <th>Fecha</th>
					             <c:forEach var="element" items="${listData}">
      							  <tr>
						            <td>${element}</td> 
						            <td>${element}</td> 
						        </tr> 
						 	   </c:forEach>
					        </tr>
					    </thead>
					    <tbody>
					        <tr>
					            <td></td>
					            <td></td>
					        </tr>
					    </tbody>
					</table>
					<p><input id="submitButton" type="submit" value="Aceptar" onclick="load()"></p> <!-- type="submit" , sin id -->					
			</div>
		</div>
	</div>
	<br>
    <div id='resultado'>
    </div>
</body>


</html>