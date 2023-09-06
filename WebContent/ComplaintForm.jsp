<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
	pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<script>

	
		function closeNav(){
			
			 document.getElementById("displayShift").style.marginLeft="0%";
			document.getElementById("main").style.marginLeft = "0%";
			  document.getElementById("mySidebar").style.display = "none";
			  document.getElementById("openNav").style.display = "inline-block";
		}
		
		function openNav(){ 
		 document.getElementById("displayShift").style.marginLeft="18%";
		 document.getElementById("main").style.marginLeft = "18%";
		  document.getElementById("mySidebar").style.width = "18%";
		  document.getElementById("mySidebar").style.display = "block";
		  document.getElementById("openNav").style.display = 'none';
		}
</script>

<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">

<!--    linked css file-->
<link href="css/header.css" rel="stylesheet" type="text/css">
<link href="css/complain.css" rel="stylesheet" type="text/css">
<link href="css/SideBar.css" rel="stylesheet" type="text/css">
<link href="css/MenuTop.css" rel="stylesheet" type="text/css">
<title> City Administration </title>

<!--    linked font awesome -->
<script src="https://kit.fontawesome.com/63678e90c0.js" crossorigin="anonymous"></script>

<!--    linked favicon -->
<link rel="shortcut icon" type="image/png" href="images/logo.png">

<!--    linked header font -->
<link href="https://fonts.googleapis.com/css2?family=Contrail+One&family=Fredoka+One&family=Merienda:wght@700&display=swap" rel="stylesheet">

<!--    linked body font -->
<link href="https://fonts.googleapis.com/css2?family=Antic+Didone&family=Arapey&family=Contrail+One&family=Fredoka+One&family=Merienda+One&family=Merienda:wght@700&family=Nanum+Gothic+Coding&display=swap" rel="stylesheet">

</head>

<body>

<%
	HttpSession ss=request.getSession(false);
	String st=(String)ss.getAttribute("username");
	
	%>
<div class="head">
        <a href="RegisterUser.jsp"> 
        <!--    logo -->
        <img src="images/logo.png" height="48px" width="48px">
        City Administration 
        </a>
</div>

	<div class="topnav">
		  <a id="main" class="openbtn" onclick="openNav()">Menu</a>  
		  <a class="active" href="index.jsp">Home</a>
		  <a href="#news">News</a>
		  <a href="#contact">Contact</a>
		  <a href="#about">About</a>
		  <div class="i"><a href="RegisterUser.jsp" class="i">Logout</a></div>
		</div>  

	<div id="mySidebar" class="sidebar">
		<h3><a href="#" class="welcome" style="color:black;"> <b> Welcome : 
		<%out.print(st); %> </b></a> </h3><br>
	  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">x</a><br>
	  <a href="ComplaintForm.jsp">Register Complain</a><br>
	  <a href="userComplainTable.jsp">View Complain</a> <br>
	  <a href="GovtSchemes.jsp">GoGreen</a> <br>
	  <a href="#">Contact</a>
	</div>
	

<%-- <h2>
<ul>
	<li>
	
	</li>
	<li class="side"><a href="RegisterUser.jsp"> Log out </a></li>
</ul>
</h2> --%>
<br>
<div id="displayShift">
<div class="side">
<img src="images/complaint.png"></div>
	
	<form name="f1" method="post" action="ComplainStore" enctype="multipart/form-data" >	
	<ul>
	<li></li>
	<li><br>
		<div class="title">
			<b> MAKE COMPLAINT! </b>
		</div>
		<br>
		<fieldset class="dist">
			<legend id="center"> 
				<b>We are here to assist you!</b>
			</legend>

			<table>
				<tr>
				<td>	<label> Choose Complaint Type </label>	</td>
				
				<td>
				
				<select name="comp">
					<option></option>
					<option value="Water">Water</option>
					<option value="Electricity">Electricity</option>
					<option value="GasLine">GasLine</option>
					<option value="Drainage">Drainage</option>
					<option value="Garbage">Garbage</option>
					<option value="StrayAnimal">StrayAnimal</option>
				</select>
						
				</td>
				</tr>
				
			<tr>
			<td><br>
			<label> Enter your Problem </label> </td>
			<td><br>
			<textarea name="prb"></textarea></td>
			</tr>

			<tr><td>
			<label> <br>Enter Days Suffered </label> </td>
			<td><br>
			<input type="text" name="days"></td>
			</tr>
			
			<tr><td>
			<label><br> Upload Images </label> </td>
			<td><br>
			<input type="file" name="upload"></td>
			</tr>
			
			<tr>
			
			<td align="center" colspan="2"><br><br>
			<input type="submit" name="sub" value="COMPLAIN"></td>
			</tr>
			
			</table>
			
		</fieldset>
	</li>
	</ul>
	
	</form>
	</div>
</body>
</html>