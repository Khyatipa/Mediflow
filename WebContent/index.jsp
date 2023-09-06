<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>


	<%@ page import="java.io.*"%>
	<%@ page import="java.sql.*" %>
	<%@ page import="javax.servlet.*" %>
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




<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">

<link href="css/indexheader.css" rel="stylesheet" type="text/css"> 

<link href="css/SideBar.css" rel="stylesheet" type="text/css">
<link href="css/MenuTop.css" rel="stylesheet" type="text/css">
<link href="css/ButtonReport.css" rel="stylesheet" type="text/css">
<link href="css/ButtonPopup.css" rel="stylesheet" type="text/css">
<link href="css/DashBoardTable.css" rel="stylesheet" type="text/css">
<!--    linked font awesome -->

<script src="https://kit.fontawesome.com/63678e90c0.js" crossorigin="anonymous"></script>

<!--    linked favicon -->
<link rel="shortcut icon" type="image/png" href="images/logo.png">

<!--    linked header font -->
<link href="https://fonts.googleapis.com/css2?family=Contrail+One&family=Fredoka+One&family=Merienda:wght@700&display=swap" rel="stylesheet">

<!--    linked body font -->
<link href="https://fonts.googleapis.com/css2?family=Antic+Didone&family=Arapey&family=Contrail+One&family=Fredoka+One&family=Merienda+One&family=Merienda:wght@700&family=Nanum+Gothic+Coding&display=swap" rel="stylesheet">
     <title> Home </title>

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">			
<link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css">

<body>
<%
	HttpSession ss=request.getSession(false);
	String st=(String)ss.getAttribute("username");
	int id = Integer.parseInt(session.getAttribute("userid").toString());
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
	

	<div id="displayShift"> <!-- DISPLAY SHIFTER CONTENTS WHEN CLICK MENU --> 
	
	<header class="w3-container" style="padding-top:22px; padding-left:70px">
    	<h5><b><i class="fa fa-dashboard"></i> My Dashboard</b></h5>
  	</header>
	
	
	<div align="center" >
	<ul style="list-style-type:none;">			
		

	<li>
			<%
		
			try{
				
				String dbURL = "jdbc:mysql://localhost:3306/projectcity";
				String dbUserName = "root";
				String dbPassword = "";	
								
				DriverManager.registerDriver(new com.mysql.jdbc.Driver());
				Class.forName("com.mysql.jdbc.Driver");
				Connection con=DriverManager.getConnection(dbURL, dbUserName, dbPassword);
				Statement stmt2=con.createStatement();
				String city="";			
				String query2="";
				int a=0;
				
				ResultSet rs4=stmt2.executeQuery("Select uct from registeruser where una='"+st+"'");
				while(rs4.next())
				{
					city=rs4.getString(1);
				}
				rs4.close();
				query2="Select COUNT(statusid) from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where  uct='"+city+"' and statusid='Pending' and una='"+st+"'"; 
				ResultSet  rs2=stmt2.executeQuery(query2);
				rs2=stmt2.executeQuery(query2);
				while(rs2.next())
				{
				 a=rs2.getInt(1);
				}
				rs2.close();
								
			
			%>
	<div class="tooltip">
		<span class="tooltiptext">Show List Of Pending Complains</span>
		<a href="./DisplayAndFilterComplain.jsp?status1=Pending" class="notification">
		  <span id="bor">PendComplain</span><br> <br>
		  <span style="font-size:30px;"><%out.print(a);%></span>
		</a>
	</div>
	</li>
	<li>
		<%
			int b=0;		
			query2="Select DISTINCT COUNT(cid) from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where  uct='"+city+"' and una='"+st+"'"; 
			rs2=stmt2.executeQuery(query2);
			while(rs2.next())
			{
			
				b=rs2.getInt(1);
			}
			rs2.close();
		%>		
		
		<div class="tooltip">
		<span class="tooltiptext">Show List Of Total<br> Complains</span>	
			<a href="./DisplayAndFilterComplain.jsp?status1=FullList" class="notification">
			  <span id="bor">TotalComplain</span><br> <br>
			  <span style="font-size:30px;"><%out.print(b);%></span>
			</a>
		</div>	
	</li>
	<li>		
			<%	int c=0;
				query2="Select COUNT(statusid) from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where  uct='"+city+"' and statusid='Approve' and una='"+st+"'";  
				rs2=stmt2.executeQuery(query2);
						while(rs2.next())
						{
							c=rs2.getInt(1);
						}
							rs2.close();
			%>					
				
			<div class="tooltip">
			<span class="tooltiptext">Show List Of Approved Complains</span>								
			<a href="./DisplayAndFilterComplain.jsp?status1=Approve" class="notification">
			  <span id="bor">TotalApproved</span><br> <br>
			  <span style="font-size:30px;"><%out.print(c);%></span>
			</a>
			</div>
		
				
			<%
			
				}
			catch(Exception e)
			{
				System.out.print("ERROR IN REPORT BUTTON ON USER SIDE"+e.getMessage());
			}
			
			
			
			%>
			</li>
		</div>	
		
	<li style="float:right;">

	
		<div class="slideshow-container">

		<div class="mySlides fade">
		  <div class="numbertext">1 / 4</div>
		  <img src="images/adopt.jpg" style="width:400; height:267;">
		</div>
		
		<div class="mySlides fade">
		  <div class="numbertext">2 / 4</div>
		  <img src="images/traffic.jpg" style="width:400; height:267;">
		</div>
		
		<div class="mySlides fade">
		  <div class="numbertext">3 / 4</div>
		  <img src="images/garbage.jpg" style="width:400; height:267;">
		</div>
		
		<div class="mySlides fade">
		  <div class="numbertext">4 / 4</div>
		  <img src="images/gogreen.jpg" style="width:400; height:267;">
		</div>


		</div>
<br>

		<div style="text-align:center">
		  <span class="dot"></span> 
		  <span class="dot"></span> 
		  <span class="dot"></span> 
		  <span class="dot"></span>
		</div>
 
	  	<script>
		  	var slideIndex = 0;
		  	showSlides();
		
		  	function showSlides() {
		  	  var i;
		  	  var slides = document.getElementsByClassName("mySlides");
		  	  var dots = document.getElementsByClassName("dot");
		  	  for (i = 0; i < slides.length; i++) {
		  	    slides[i].style.display = "none";  
		  	  }
		  	  slideIndex++;
		  	  if (slideIndex > slides.length) {slideIndex = 1}    
		  	  for (i = 0; i < dots.length; i++) {
		  	    dots[i].className = dots[i].className.replace(" active", "");
		  	  }
		  	  slides[slideIndex-1].style.display = "block";  
		  	  dots[slideIndex-1].className += " active";
		  	  setTimeout(showSlides, 2000); // Change image every 2 seconds
		  	}
	  	</script> 
 
	</li>
	</ul>
	
		
		
		<br><br>

           
       	<div class="dastab" > 
    	<h4><b><i class="fas fa-table"   ></i> My Records</b></h4>
  			
		 
        <table>
        	
        
          <tr>
            <td><i class="fas fa-tree"></i></td>
            <td>Trees Planted</td>
            <td></td>
            <td><i>0</i></td>
          </tr>
          <tr>
            <td><i class="fas fa-hands-helping"></i></td>
            <td>Govt. Schemes</td>
            <td></td>
            <td><i>0</i></td>
          </tr>
          <tr>
            <td><i class="fas fa-exclamation-circle"></i></td>
            <td>Total Complain</td>
            <td></td>
            <td><i>3</i></td>
          	
          </tr>
          <tr>
            <td><i class="fa fa-comment w3-text-red w3-large"></i></td>
            <td>New comments</td>
            
          </tr>
          
        </table>
      </div>






</div>

			
	</body>
</html>
	