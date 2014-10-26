<html>
<head>
	<title>Partidas históricas</title><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<script type='text/javascript' src='/static/unityPlayer/jquery.min.js'></script>
	<script type="text/javascript" src='/static/unityPlayer/UnityObject2.js'></script>
	<script type="text/javascript" src='/static/unityPlayer/unityPlayer.js'></script>
	
	<!--<link rel="stylesheet" href="/static/unityPlayer/unityStyle.css" type="text/css"/>-->
	
    <link href="/frontendhome/css/bootstrap.min.css" rel="stylesheet">
    <link href="/frontendhome/css/bootstrap-responsive.min.css" rel="stylesheet">
    <link href='http://fonts.googleapis.com/css?family=Fjalla+One' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Merienda:700' rel='stylesheet' type='text/css'>
    <link href="/frontendhome/css/style.css" rel="stylesheet">
</head>
<body>

		<div id="wrapper">
		<div id="featured-wrapper">
			<div class="container">
			<br>
			<h1><%="Seleccioná una partida para verla" %></h1>
			<form action="/partidas" method="get">
				<div id="page_container">
					<h3>
					<a href="/partidas?id=1" style="text-decoration: none">Partida fecha 04/09/2014 - 21:59</a> <br> 
					<a href="/partidas?id=2" style="text-decoration: none">Partida fecha 04/09/2014 - 22:40</a> <br>
					</h3>
				</div>				
			</form>	

				<div class="content">
					<div id="unityPlayer">
						<div class="missing">
							<a href="http://unity3d.com/webplayer/" title="Unity Web Player. Install now!">
								<img alt="Unity Web Player. Install now!" src="http://webplayer.unity3d.com/installation/getunity.png" width="193" height="63" />
							</a>
						</div>
						<div class="broken">
							<a href="http://unity3d.com/webplayer/" title="Unity Web Player. Install now! Restart your browser after install.">
								<img alt="Unity Web Player. Install now! Restart your browser after install." src="http://webplayer.unity3d.com/installation/getunityrestart.png" width="193" height="63" />
							</a>
						</div>
					</div>
				</div>

			</div>
		</div>
		</div>
			
	<script src="/static/jquery-2.1.1.min.js"></script>
</body>
</html>