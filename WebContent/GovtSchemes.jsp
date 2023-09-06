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
<link href="css/govt.css" rel="stylesheet" type="text/css">
<link href="css/SideBar.css" rel="stylesheet" type="text/css">
<link href="css/MenuTop.css" rel="stylesheet" type="text/css">
<title>City Administration</title>

<!--    linked font awesome -->
<script src="https://kit.fontawesome.com/63678e90c0.js"
	crossorigin="anonymous"></script>

<!--    linked favicon -->
<link rel="shortcut icon" type="image/png" href="images/logo.png">

<!--    linked header font -->
<link
	href="https://fonts.googleapis.com/css2?family=Contrail+One&family=Fredoka+One&family=Merienda:wght@700&display=swap"
	rel="stylesheet">

<!--    linked body font -->
<link
	href="https://fonts.googleapis.com/css2?family=Antic+Didone&family=Arapey&family=Contrail+One&family=Fredoka+One&family=Merienda+One&family=Merienda:wght@700&family=Nanum+Gothic+Coding&display=swap"
	rel="stylesheet">
</head>

<body>
	<%
	HttpSession ss=request.getSession(false);
	String st=(String)ss.getAttribute("username");
	
	%>
	<div class="head">
		<a href="RegisterUser.jsp"> <!--    logo --> <img
			src="images/logo.png" height="48px" width="48px"> City
			Administration
		</a>
	</div>

	<div class="topnav">
		<a id="main" class="openbtn" onclick="openNav()">Menu</a> <a
			class="active" href="index.jsp">Home</a> <a href="#news">News</a> <a
			href="#contact">Contact</a> <a href="#about">About</a>
		<div class="i">
			<a href="RegisterUser.jsp" class="i">Logout</a>
		</div>
	</div>

	<div id="mySidebar" class="sidebar">
		<h3>
			<a href="#" class="welcome" style="color: black;"> <b>
					Welcome : <%out.print(st); %>
			</b></a>
		</h3>
		<br> <a href="javascript:void(0)" class="closebtn"
			onclick="closeNav()">x</a><br> <a href="ComplaintForm.jsp">Register
			Complain</a><br> <a href="userComplainTable.jsp">View Complain</a> <br>
		<a href="GovtSchemes.jsp">GoGreen</a> <br> <a href="#">Contact</a>
	</div>

	
	
	<div id="displayShift">
		<div style="float:right; padding:20px;" align="center">
		<br>	<b>GO-GREEN</b>
			<br><br>
			PLANT A TREE AT YOUR HOUSE<br> 
			<form>
				<input type="submit" value="PLANT TREE" class="submit">
			</form> <br>
			<img alt="Plant a tree " src="images/1.jpg" style="border:2px solid darkgrey;"><br> <br>
			

		</div>
	
	
	<br>
	<h3>Benefits of Planting Trees</h3>

	<p>Most often we plant trees to provide shade and beautify our
		landscapes. These are great benefits but trees also provide other less
		obvious benefits.</p>

	<h3>Social Benefits</h3>

	<p>Trees make life nicer. It has been shown that spending time
		among trees and green spaces reduces the amount of stress that we
		carry around with us in our daily lives. Hospital patients have been
		shown to recover from surgery more quickly when their hospital room
		offered a view of trees. Children have been shown to retain more of
		the information taught in schools if they spend some of their time
		outdoors in green spaces. Trees are often planted as living memorials
		or reminders of loved ones or to commemorate significant events in our
		lives.</p>

	<h3>Communal Benefits</h3>

	<p>Even though you may own the trees on your property your
		neighbors may benefit from them as well. Through careful planning
		trees can be an asset to your entire community. Tree lined streets
		have a traffic calming effect, traffic moves more slowly and safely.
		Trees can be placed to screen unwanted views or noise from busy
		highways. Trees can complement the architecture or design of buildings
		or entire neighborhoods.</p>

	<h3>Environmental Benefits</h3>

	<p>Trees offer many environmental benefits. Trees reduce the urban
		heat island effect through evaporative cooling and reducing the amount
		of sunlight that reaches parking lots and buildings. This is
		especially true in areas with large impervious surfaces, such as
		parking lots of stores and industrial complexes. Trees improve our air
		quality by filtering harmful dust and pollutants such as ozone, carbon
		monoxide, and sulfur dioxide from the air we breathe. Trees give off
		oxygen that we need to breathe. Trees reduce the amount of storm water
		runoff, which reduces erosion and pollution in our waterways and may
		reduce the effects of flooding. Many species of wildlife depend on
		trees for habitat. Trees provide food, protection, and homes for many
		birds and mammals.</p>

	<h3>Economic Benefits</h3>

	<p>Well placed trees can reduce your cooling costs in the summer by
		shading the south and west sides of your home. If deciduous trees are
		used they will allow the sun to pass through and warm your home in the
		winter. Evergreen trees on the north side of your home and shrubs
		around the foundation of your home can act as a windbreak to reduce
		the cooling effects of winter winds. The value of a well landscaped
		home with mature healthy trees can be as much as 10% higher than a
		similar home with no or little landscaping. (Topping will reduce the
		value of your trees) Some indirect economic benefits of trees are that
		if we reduce the energy we use then utility companies will have less
		demand placed on the infrastructure, thus reducing operating costs
		which can be passed on to the consumer.</p>
</div>
</body>
</html>