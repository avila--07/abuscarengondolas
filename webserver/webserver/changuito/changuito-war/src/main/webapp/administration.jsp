<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<head><title>Administración</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <!-- Le styles -->
    <link href="/frontendhome/css/bootstrap.min.css" rel="stylesheet">
    <link href="/frontendhome/css/bootstrap-responsive.min.css" rel="stylesheet">
    <link href='http://fonts.googleapis.com/css?family=Fjalla+One' rel='stylesheet' type='text/css'>
    <link href='http://fonts.googleapis.com/css?family=Merienda:700' rel='stylesheet' type='text/css'>
    <link href="/frontendhome/css/style.css" rel="stylesheet">

    <!-- Fav and touch icons -->
    <link rel="apple-touch-icon-precomposed" sizes="144x144" href="http://twitter.github.com/bootstrap/assets/ico/apple-touch-icon-144-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="114x114" href="http://twitter.github.com/bootstrap/assets/ico/apple-touch-icon-114-precomposed.png">
    <link rel="apple-touch-icon-precomposed" sizes="72x72" href="http://twitter.github.com/bootstrap/assets/ico/apple-touch-icon-72-precomposed.png">
    <link rel="apple-touch-icon-precomposed" href="http://twitter.github.com/bootstrap/assets/ico/apple-touch-icon-57-precomposed.png">
    <link rel="shortcut icon" href="http://twitter.github.com/bootstrap/assets/ico/favicon.png">
</head>
<body>
	<div id="wrapper">
		<div id="featured-wrapper">
			<div class="container">
			<br>
			<h1><%="Panel de control" %></h1>
			<br>
        
<!--<div style="float: right; width: 45%;">
	<img src="/static/images/mystery-man.jpg"  width="160" height="160" alt="usuario desconocido">
</div> -->

			<div class="row">
				<div class="span6 offset13">
					<p class="lead">
					Ahora que te logueaste, aprovechá las funcionalidades<br>para conocer el desarrollo de tu usuario asignado.<br><br>
					
					<a href="#" style="text-decoration: none;display: in-line" id="ver_st">Visualizá las estadísticas</a> que la aplicación prepara con la info de las jugadas.<br><br>
					
					Personalizá la forma de jugar, accediendo a la <a href="#" style="text-decoration: none;display: in-line" id="ver_conf">configuración de la aplicación</a>.<br><br>
					
					Mirá las <a href="#" style="text-decoration: none;display: in-line" id="ver_part">partidas ya jugadas</a> para ver el desarrollo y avance de tu usuario.<br>
					</p>
				</div>
						
				<div class="span4 offset1">
					<img src="/static/images/mystery-man.jpg" width="160" height="160" alt="usuario desconocido">
					<br><br>
					<!--<div <!--style="float: left; width: 45%;">-->
						<table style="width:100%">
						<tr>
						<td>
							<fb:login-button scope="public_profile,email" onlogin="checkLoginState();">
							</fb:login-button>
						</td>
						</tr>
					 
					<!--</table>
					</div>-->
				</div>
			</div>

		</div>
		</div>
	</div>

<script src="/static/home.js"></script>
<script src="/static/administration.js"></script>
</body>
