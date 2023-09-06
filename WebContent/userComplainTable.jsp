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
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<link href="css/SideBar.css" rel="stylesheet" type="text/css">
<link href="css/MenuTop.css" rel="stylesheet" type="text/css">
<link href="css/header.css" rel="stylesheet" type="text/css">
<link href="css/viewComplain.css" rel="stylesheet" type="text/css">
<title>City Administration</title>
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">		
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
		int id = Integer.parseInt(session.getAttribute("userid").toString());
		System.out.print("I M HERE"+id+st);
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
	<header class="w3-container" style="padding-top:25px; padding-left:20px">
    	<h4 style="font-size:24px;"><b><i class="fa fa-dashboard"></i> My Complains</b></h4>
  	</header>
	
	
	
		<form>
		
			<div id="hidetable" class="table-users" align="center">
				<table>
					<thead>
					<tr>
						<th>COMPLAIN-ID</th>
						<th>TYPE</th>
						<th>DESC</th>
						<th>DAYS</th>
	
						<th> COMPLAIN-DATE </th>
						<th> MODIFY-DATE </th>
						<th>MODIFY-BY</th>
						<th>STATUS</th>
	
					</tr>
					</thead>
					
					
					<%
				try
				{	//byte[] img=null;
					
					Connection con = null;
					String message = null;
					ServletOutputStream sos=null;
					String dbURL = "jdbc:mysql://localhost:3306/projectcity";
					String dbUserName = "root";
					String dbPassword = "";	
									
					DriverManager.registerDriver(new com.mysql.jdbc.Driver());
					Class.forName("com.mysql.jdbc.Driver");
					con = DriverManager.getConnection(dbURL, dbUserName, dbPassword);
					
					Statement stmt=con.createStatement();
					String query="select cid,ctype,cdesc,cdays,cdate,modifydate,modifyby,statusid from complainuser where uid="+id;
				
					ResultSet rs=stmt.executeQuery(query);
				
						while(rs.next())
						{
							int aa;	
						%>
	
					<tbody>
					
					<tr>
						<td>
							<%out.print(rs.getInt(1));%>
						</td>
						<td>
							<%out.print(rs.getString(2)); %>
						</td>
						<td>
							<%out.print(rs.getString(3)); %>
						</td>
						<td>
							<%out.print(rs.getInt(4)); %>
						</td>
						<td>
							<%out.print(rs.getTimestamp(5)); %>
						</td>
						<td>
							<%out.print(rs.getTimestamp(6)); %>
						</td>
						<td>
							<%out.print(rs.getString(7)); %>
						</td>
						<td>
							<%
								out.print(rs.getString(8));
							%>
						</td>
					</tr>
	
					</tbody>
					<%
						}
					%>
	
	
				</table>
				</div>
				
				<%	rs.close();
				    stmt.close();
				    con.close();
				    }
				catch(Exception e)
				{
				   System.out.println(e.getMessage());
			    }
				%>
				
				</form>
		</div>










</body>
</html>