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
<link href="css/adminPage.css" rel="stylesheet" type="text/css">

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
String s=(String)ss.getAttribute("cityname");
String aname=(String)ss.getAttribute("adminname");
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
		<%out.print(aname); %> </b></a> </h3><br>
	  <a href="javascript:void(0)" class="closebtn" onclick="closeNav()">x</a><br>
	  
	  <a href="DisplayAndFilterComplain.jsp">View Complain</a> <br>
	  <a href="GovtSchemes.jsp">GoGreen</a> <br>
	  <a href="#">Contact</a>
	</div>
	

	<div id="displayShift">

	<header class="w3-container" style="padding-top:22px; padding-left:70px">
    	<h5><b><i class="fa fa-dashboard"></i> My Dashboard</b></h5>
  	</header>
  	<br>
	
	<%-- <h2> YOUR CITY : <%out.print(s); %></h2><hr> --%>

	
	<div align="center">
	<br><br>
			<%
			
			try{
				String sc=String.valueOf(ss.getAttribute("cityname"));
				
				String dbURL = "jdbc:mysql://localhost:3306/projectcity";
				String dbUserName = "root";
				String dbPassword = "";	
								
				DriverManager.registerDriver(new com.mysql.jdbc.Driver());
				Class.forName("com.mysql.jdbc.Driver");
				Connection con=DriverManager.getConnection(dbURL, dbUserName, dbPassword);
				Statement stmt2=con.createStatement();
							
				String query2="";
				int a=0;
				query2="Select COUNT(statusid) from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where  uct='"+sc+"' and statusid='Pending'"; 
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
		  <span >PendingComplain</span><br>
		  <span ><%out.print(a);%></span>
		</a>
	</div>
			<%
			int b=0;		
			query2="Select DISTINCT COUNT(cid) from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where  uct='"+sc+"'"; 
			rs2=stmt2.executeQuery(query2);
			while(rs2.next())
			{
			
				b=rs2.getInt(1);
			}
			rs2.close();
			%>	
	<div class="tooltip">
		<span class="tooltiptext">Show List Of Complains</span>		
			<a href="./DisplayAndFilterComplain.jsp?status1=FullList" class="notification">
			  <span >TotalComplain</span><br>
			  <span ><%out.print(b);%></span>
			</a>
	</div>		
			<%	int c=0;
				query2="Select COUNT(statusid) from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where  uct='"+sc+"' and statusid='Approve'"; 
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
			  <span>TotalApproved</span><br>
			  <span><%out.print(c);%></span>
			</a>
	</div>	
			<%
							int d=0;
							query2="Select COUNT(cdate) from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where  uct='"+sc+"' and DATE(cdate)=CURDATE()"; 
							rs2=stmt2.executeQuery(query2);
							while(rs2.next())
							{
							
								d=rs2.getInt(1);
							}
							rs2.close();
			%>	
	<div class="tooltip">
		<span class="tooltiptext">CurrentDate Complains</span>									
			
			<a href="./DisplayAndFilterComplain.jsp?status1=curDate" class="notification">
			  <span>TodaysComplain</span><br>
			  <span><%out.print(d);%></span>
			</a>
	</div>		
			<%
							int e=0;
							query2="Select COUNT(cid) from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where  uct='"+sc+"' and statusid='Completed'"; 
							rs2=stmt2.executeQuery(query2);
							while(rs2.next())
							{
							
								e=rs2.getInt(1);
							}
							rs2.close();
			%>	
	<div class="tooltip">
		<span class="tooltiptext">Show List Of Completed Complains</span>									
			
			<a href="./DisplayAndFilterComplain.jsp?status1=Completed" class="notification">
			  <span>Solved Complains</span><br>
			  <span><%out.print(d);%></span>
			</a>
	</div>		
			<%
							int f=0;
							query2="Select COUNT(cid) from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where  uct='"+sc+"' and statusid='WorkinProgress'"; 
							rs2=stmt2.executeQuery(query2);
							while(rs2.next())
							{
							
								e=rs2.getInt(1);
							}
							rs2.close();
			%>	
	<div class="tooltip">
		<span class="tooltiptext">Show List Of WorkinProgress Complains</span>								
		
			<a href="./DisplayAndFilterComplain.jsp?status1=WorkinProgress" class="notification">
			  <span>WorkinProgress</span><br>
			  <span><%out.print(e);%></span>
			</a>
	</div>		
			
			
			</div>
	
			
	
<br><br><br>
		
	<form action="./DisplayAndFilterComplain.jsp?flag=1" align=center>
	<input type="Submit" value="SHOW COMPLAINS" >
				
				
		<br><br>		
	</form>

		<%	
			stmt2.close();
			con.close();
			}
					catch(Exception e)
					{
					System.out.print(e.getMessage());
					}
						
			%>
</div>
</body>
</html>