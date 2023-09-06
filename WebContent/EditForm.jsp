<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
    <%@ page import="java.io.*"%>
	<%@ page import="java.sql.*" %>
	<%@ page import="javax.servlet.*" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>

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

<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title> City Administration | Admin </title>

<!--    linked css file-->
<link href="css/adminHeader.css" rel="stylesheet" type="text/css">
<link href="css/displayFilterComplain.css" rel="stylesheet" type="text/css">
<link href="css/editForm.css" rel="stylesheet" type="text/css">

<!--    linked font awesome -->
<script src="https://kit.fontawesome.com/63678e90c0.js" crossorigin="anonymous"></script>

<!--    linked favicon -->
<link rel="shortcut icon" type="image/png" href="images/logo.png">

<!--    linked header font -->
<link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@1,900&display=swap" rel="stylesheet">

<!--    linked body font -->
<link href="https://fonts.googleapis.com/css2?family=Roboto&display=swap" rel="stylesheet">
<link href="css/SideBar.css" rel="stylesheet" type="text/css">
<link href="css/MenuTop.css" rel="stylesheet" type="text/css">
<link href="css/ButtonReport.css" rel="stylesheet" type="text/css">
<link href="css/ButtonPopup.css" rel="stylesheet" type="text/css">
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">
			
</head>
	

<body>


<%
  HttpSession ss=request.getSession(false);
  String s=(String)ss.getAttribute("adminname");
 
  String cidd=(String) request.getAttribute("complainid");
  String ctype = (String) request.getAttribute("comp");
  String cprb = (String) request.getAttribute("prb");
  String cday = (String) request.getAttribute("days");

  System.out.println(s+" "+ctype+" "+cprb);
   %>
   		 <div class="head">
			        <a href="RegisterUser.jsp"> 
			        <!--    logo -->
			        <img src="images/logo.png" height="48px" width="48px"> 
			        <b> City Administration </b>
			        </a>
			    </div>
			    
			    
			    	
				<div class="topnav">
					  <a id="main" class="openbtn" onclick="openNav()">Menu</a>  
					  <a class="active" href="AdminPage.jsp">Home</a>
					  <a href="#news">News</a>
					  <a href="#contact">Contact</a>
					  <a href="#about">About</a>
					  <div class="i"><a href="AdminLogin.jsp" class="i">Logout</a></div>
					</div>  
					
			
			
				<div id="mySidebar" class="sidebar">
					<h3><a href="#" class="welcome" style="color:black;"> <b> Welcome : 
					<%out.print(s); %> </b></a> </h3><br>
				  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">x</a><br>
				  
				  <a href="DisplayAndFilterComplain.jsp">View Complain</a> <br>
				  <a href="GovtSchemes.jsp">GoGreen</a> <br>
				  <a href="#">Contact</a>
				</div>
				<br>	
				<br>
				<br>
				
				
<div id="displayShift">

	<form id="f1" action="EditComplainStore" enctype="multipart/form-data" class="edit" style="float:left;">
				
	<fieldset>
			<legend >
				<b>EDIT COMPLAIN</b>
			</legend>
			<table>
					<tr>
						<td>	<label> Complaint Type </label> </td>
						<td>	<input type="text" name="ct" value=" <%out.print(ctype); %>" disabled> </td>
					</tr>	
					<tr>
						<td>	<label> Problem Desc </label> </td>
						<td>	<textarea name="prb" disabled><%out.print(cprb); %></textarea> </td>
					</tr>	
					<tr>
						<td></td>
						<td>	<button onclick="myFunction()"  class="submit">Image</button> </td>
					</tr>
					<tr>	
						<td>	<label> Days Suffered </label> </td>
						<td>	<input type="text" name="days" value="<%out.print(cday); %>" disabled> </td> 
					</tr>
					<tr>
						<td>	<label> Modify-By </label> </td>
						<td>	<input type="text" name="mname" value="<%out.print(s);%>" > </td>
					</tr>	
					<tr>			
						<td>	<label>	Change Status ID </label>	</td>	
						<td>	<select name="status">
								<option></option>
								<option value="Pending">Pending</option>
								<option value="Approve">Approve</option>
								<option value="Reject">Rejected</option>
								<option value="WorkinProgress">In Progress</option>
								<option value="Completed">Completed</option>
							</select>   
			        	</td>
					</tr>					
					<tr>		
						<td></td>
						<td><br>	<input type="submit" name="sub" value="COMPLAIN!"  class="submit"> </td>
						
					</tr>
			</table>
				</fieldset>
			</form>
		
	
	</div>
	
</body>
</html>