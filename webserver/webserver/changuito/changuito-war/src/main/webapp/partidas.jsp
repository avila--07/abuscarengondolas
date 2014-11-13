<html>
<head>
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
</head>
<body>
		<div id="wrapper">
			<div id="featured-wrapper">
				<div class="container">
					<br>
					<h1><%="Seleccioná una partida para verla"%></h1>
						<p><input type="text" name="id" id="id"></p>
						<p><input id="submitButton" type="submit" value="Aceptar" onclick="load()"></p> <!-- type="submit" , sin id -->					
				</div>
			</div>
		</div>
		<div>
			
		</div>
	    <div id='resultado'></div>
	<script src="/static/jquery-2.1.1.min.js"></script>
</body>
</html>