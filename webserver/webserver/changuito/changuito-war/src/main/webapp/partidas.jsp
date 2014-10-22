<html>
<head>
		<script type='text/javascript' src='/static/unityPlayer/jquery.min.js'></script>
		<script type="text/javascript" src='/static/unityPlayer/UnityObject2.js'></script>
		<script type="text/javascript" src='/static/unityPlayer/unityPlayer.js'></script>
		<link rel="stylesheet" href="/static/unityPlayer/unityStyle.css" type="text/css"/>
		<title>Partidas históricas</title><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<body>
    <font size="10"><%="Selecciona una partida para verla" %></font>
    <form action="/partidas" method="get">
		<div id="page_container">
			<a href="/partidas?id=1">Partida fecha 04/09/2014 - 21:59</a> <br> 
			<a href="/partidas?id=2">Partida fecha 04/09/2014 - 22:40</a> <br>
		</div>    
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
	</form>	
	<script src="/static/jquery-2.1.1.min.js"></script>
</body>
</html>