<%@ page language="java" contentType="text/html; charset=UTF-8" pageEncoding="UTF-8"%>
<head><title>Administración</title></head>
<body>
        <h1><font size="10"><%="Panel de control" %></font> </h1>
        <br>
        
<div style="float: left; width: 45%;">
	<table style="width:100%">
		  <tr>
		    <td>
				<fb:login-button scope="public_profile,email" onlogin="checkLoginState();">
				</fb:login-button>
			</td>
		  </tr>
		 
	</table>
</div>

<div style="float: right; width: 45%;">
	<img src="/static/images/mystery-man.jpg"  width="160" height="160" alt="usuario desconocido">
</div>

<script src="/static/home.js"></script>
</body>
