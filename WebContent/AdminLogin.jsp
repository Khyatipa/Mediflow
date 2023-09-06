<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title> City Administration | Admin </title>

<!--    linked css file-->
<link href="css/adminHeader.css" rel="stylesheet" type="text/css">
<link href="css/adminLogin.css" rel="stylesheet" type="text/css">

<!--    linked font awesome -->
<script src="https://kit.fontawesome.com/63678e90c0.js" crossorigin="anonymous"></script>

<!--    linked favicon -->
<link rel="shortcut icon" type="image/png" href="images/logo.png">

<!--    linked header font -->
<link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@1,900&display=swap" rel="stylesheet">

<!--    linked body font -->
<link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">



</head>
<body>

	 <div class="head">
        <a href="RegisterUser.jsp"> 
        <!--    logo -->
        <img src="images/logo.png" height="48px" width="48px"> 
        <b> City Administration </b>
        </a>
    </div>

<ul>
<li></li>
<li>
<form name="f1" action="AdminLogin" class="login">

<fieldset>

	<div class="icon">
	<i class="fas fa-user"></i></div> 
	 <br>
	 
	<table>
	<tr>
	<td> <label> Admin name  </label> </td>
	<td> <input type="text" name="name"> </td>
	</tr>
	
	<tr>
	<td> <br> <label> City </label> </td>
	<td> <br> <select name="city" >
	  <option></option>
	  <option value="Ahmedabad"> Ahmedabad </option>
	  <option value="Vadodara"> Vadodara </option>
	  <option value="Surat"> Surat </option>
	  <option value="Rajkot"> Rajkot </option>
	  <option value="Jamnagar"> Jamnagar </option>
	  <option value="Bharuch"> Bharuch </option>
	</select> </td>
	</tr>  

	<tr>
	<td> <br> <label> Password </label> </td> 
	<td> <br> <input type="password" name="pass"> </td>
	</tr>

	<tr>
	<td></td>
	<td> <br> <input type="submit" name="sub" value="Login" class="submit"> </td>
	</tr>
	</table>

</fieldset>

</form>

</li>

<li></li>
</ul>



</body>
</html>