<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>Changuito</title>
<link rel="shortcut icon" type="image/png" href="/static/images/favicon.ico"/>
<meta name="keywords" content="" />
<meta name="description" content="" />
<link href="http://fonts.googleapis.com/css?family=Source+Sans+Pro:200,300,400,600,700,900" rel="stylesheet" />
<link href="/frontend/default.css" rel="stylesheet" type="text/css" media="all" />
<link href="/frontend/fonts.css" rel="stylesheet" type="text/css" media="all" />

<!--[if IE 6]><link href="default_ie6.css" rel="stylesheet" type="text/css" /><![endif]-->
</head>

<body>
<div id="header-wrapper">
	<div id="header" class="container">
		<div id="logo">
			<span><img src="/static/images/changuito.jpg" height="160" width="160"/></span>
			<h1><a href="#">Changuito</a></h1>
			<span>Aprendiendo juntos</span>
		</div>
		<!--<div id="triangle-up"></div> -->
	</div>
</div>
<div id="menu-wrapper">
	<!--<div class="row">-->
	<div id="menu">
		<ul>
			<li id="inicio" class="current_page_item"><a href="#" accesskey="1" title="" id="inicioLink">Inicio</a></li>
			<li id="about"><a href="#" accesskey="6" title="" id="aboutLink">¿Quiénes somos?</a></li>
			<li id="demo"><a href="#" accesskey="7" title="">Demo</a></li>
			<li id="login"><a href="#" accesskey="5" title="" id="loginLink">Login</a></li>
		</ul>
	</div>
 
	<div id="menu_opt">
		<ul>
			<li id="stats"><a href="#" accesskey="2" title="" id="statsLink">Estadísticas</a></li>
			<li id="configuration"><a href="#" accesskey="3" title="" id="configLink">Configuración</a></li>
			<li id="partidas"><a href="#" accesskey="4" title="" id="partidasLink">Partidas</a></li>		
		</ul>
	</div>
	
	<!--</div>-->
</div>
<div id="wrapper">
	<div id="featured-wrapper">
			
				

	</div>
	
</div>

<div id="copyright" class="container">
	<p>&copy; Changuito. All rights reserved. | Arte por <a href="http://lvcascist.blogspot.com.ar/">Lvcas</a></p>
</div>

<script src="/static/jquery-2.1.1.min.js"></script>
<script src="/static/jquery.cookie.js"></script>
<script src="/static/home.js"></script>

<script>
$( document ).ready(function() {
	
	if($.cookie('onLoadGoTo')){
		
		if("administration" == $.cookie('onLoadGoTo')){
			$("#featured-wrapper").load("/administration");	
			$.removeCookie('onLoadGoTo'); 
			$("#menu ul").append($("#stats"));
			$("#menu ul").append($("#configuration"));
			$("#menu ul").append($("#partidas"));
			$("#loginLink").text("Administración");
		}

		if("login" == $.cookie('onLoadGoTo')){
			$("#featured-wrapper").load("/login");	
			$.removeCookie('onLoadGoTo'); 
		}else{
			$("#featured-wrapper").load("/homefatures");
		}
	}else{
		$("#featured-wrapper").load("/homefatures");
	}
});
</script>

<script>
  // This is called with the results from from FB.getLoginStatus().
  function statusChangeCallback(response) {
    console.log('statusChangeCallback');
    console.log(response);
    // The response object is returned with a status field that lets the
    // app know the current login status of the person.
    // Full docs on the response object can be found in the documentation
    // for FB.getLoginStatus().
    if (response.status === 'connected') {
      // Logged into your app and Facebook.
      testAPI();
    }
  }

  // This function is called when someone finishes with the Login
  // Button.  See the onlogin handler attached to it in the sample
  // code below.
  function checkLoginState() {
    FB.getLoginStatus(function(response) {
      statusChangeCallback(response);
    });
  }

  window.fbAsyncInit = function() {
  FB.init({
    appId      : '274024806132796',
    cookie     : true,  // enable cookies to allow the server to access 
                        // the session
    xfbml      : true,  // parse social plugins on this page
    version    : 'v2.1' // use version 2.1
  });

  FB.getLoginStatus(function(response) {
    statusChangeCallback(response);
  });

  };

  // Load the SDK asynchronously
  (function(d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) return;
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/es_LA/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
  }(document, 'script', 'facebook-jssdk'));

  // Here we run a very simple test of the Graph API after login is
  // successful.  See statusChangeCallback() for when this call is made.
  function testAPI() {
    console.log('Welcome!  Fetching your information.... ');
    FB.api('/me', function(response) {
      console.log('Successful login for: ' + response.name);
      document.getElementById('status').innerHTML =
        'Thanks for logging in, ' + response.name + '!';
    });
  }
</script>

<div id="status">
</div>
<div id="fb-root"></div>

</body>
</html>
