<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
	pageEncoding="ISO-8859-1"%>
<%@ page import="java.io.*"%>
<%@ page import="java.sql.*"%>
<%@ page import="javax.servlet.*"%>
<%@page import="java.util.*"%>
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
			String sid=(String)request.getParameter("status1");
			HttpSession ss=request.getSession(false);
			String aname=(String)ss.getAttribute("adminname");
			String sc=(String)ss.getAttribute("cityname");
			//String sc1=(String)ss.getAttribute("flag");
			
			//ystem.out.print("\n\n\n here :"+sc1);
			try
			{	
				
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
				<br>
			
				<div id="displayShift">
			
			<form action="DisplayAndFilterComplain.jsp" class="displayForm">
			<table class="filterTable">
			<tr>
					<td>
				<header class="w3-container">
			    	<b><i class="fa fa-dashboard"></i> Edit Complains</b>
			  	</header>
			
			</td><td>
				
					<b>Filter Complain </b> </td>
					</tr>
					<tr>
					<td></td>
					<td>
						
						
						<label>SELECT AREA :</label> 
						<select name="selectarea" style="margin-left:92px;">
							<option value="">ALL</option>
			<%
				Connection con = null;
					
				String dbURL = "jdbc:mysql://localhost:3306/projectcity";
				String dbUserName = "root";
				String dbPassword = "";	
								
				DriverManager.registerDriver(new com.mysql.jdbc.Driver());
				Class.forName("com.mysql.jdbc.Driver");
				con = DriverManager.getConnection(dbURL, dbUserName, dbPassword);
				Statement stmt=con.createStatement();
				/*Enumeration keys = ss.getAttributeNames();
					while (keys.hasMoreElements())
						{
						  String key = (String)keys.nextElement();
						  System.out.println(key + ": " + ss.getValue(key)+"\n");
						}
				
				*/
				
				String query="select DISTINCT  uar from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where uct='"+ sc +"'"; 						
				ResultSet rs1=stmt.executeQuery(query);
				while(rs1.next())
				{
			%>

				<option value="<%out.print(rs1.getString(1)); %>">
				<%out.print(rs1.getString(1)); %>
				</option>
			<%
				}
				
				rs1.close();
				stmt.close();
				con.close();
			%>
				</td>
				</tr>
				
				<tr>
				<td></td>
				<td>
				</select> <label>SELECT COMPLAINTYPE :</label> <select name="selecttype">
				<option value="">ALL</option>
			<%
			
				con = DriverManager.getConnection(dbURL, dbUserName, dbPassword);
				Statement stmt3=con.createStatement();
				String query3="select DISTINCT  ctype from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where uct='"+ sc +"'"; 					
			
				ResultSet rs3=stmt3.executeQuery(query3);
				while(rs3.next())
				{
			%>
					<option value="<%out.print(rs3.getString(1)); %>">
						<%out.print(rs3.getString(1)); %>
					</option>

			<%
				}
				rs3.close();
				stmt3.close();
				con.close();
			%>
				</td>
				</tr>
				
				<tr>
				<td></td>
				<td>
					</select>
					
					<label>SELECT COMPLAINTYPE :</label> <select name="selectstatus">
					<option value="">ALL</option>
			<%
			
				con = DriverManager.getConnection(dbURL, dbUserName, dbPassword);
				stmt3=con.createStatement();
				query3="select DISTINCT  statusid from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where uct='"+ sc +"'"; 					
			
				rs3=stmt3.executeQuery(query3);
				
				while(rs3.next())
				{
			%>
					<option value="<%out.print(rs3.getString(1)); %>">
						<%out.print(rs3.getString(1)); %>
					</option>
			<%
				}
				rs3.close();
				stmt3.close();
				con.close();
			%>
			</td>
			</tr>
			<tr>
			<td colspan="2"  style="padding-left:520px;">
				</select> <input type="submit" name="" value="Filter">
				
				</td>
				</tr>
				</table>
			</form><hr>
			
			<%
			}
			catch(Exception e)
			{
			System.out.print("ERROR IN TOP FILTER :"+e.getMessage());
			}
			
			%>
				<form action="EditComplain" name="f1" method="post" align="center">
				<table border="2" class="displayTable">
				<tr>
					<th>C-ID</th>
					<th>NAME</th>
					<th>TYPE</th>
					<th>DESC</th>
					<th>DAYS</th>
					<th>CDATE</th>
					<th>CITY</th>
					<th>AREA</th>
					<th>ADDRESS</th>
					<th>MFY-DATE</th>
					<th>MFY-BY</th>
					<th align="center">STATUS-ID</th>
					<th>SELECT</th>
					<th>EDIT</th>
				</tr>
			
			
			
			<%
			
		try{
					
			System.out.print("\n BEFORE IF "+sid);
				if(sid.equals("Pending") || sid.equals("Approve") || sid.equals("FullList") || sid.equals("curDate") || sid.equals("Completed") || sid.equals("WorkinProgress"))
				{
					System.out.print("\n INSIDE IF "+sid);
				
			%>
				<div align="center">
					<h3><b> COMPLAINS BASESD ON :<%out.print(sid);%></b></h3>
				</div>
			
		

			<%	
				String dbURL = "jdbc:mysql://localhost:3306/projectcity";
				String dbUserName = "root";
				String dbPassword = "";	
											
				DriverManager.registerDriver(new com.mysql.jdbc.Driver());
				Class.forName("com.mysql.jdbc.Driver");
				Connection con2=DriverManager.getConnection(dbURL, dbUserName, dbPassword);
				Statement stmt2=con2.createStatement();
				ResultSet rs2=null;			
				String query2="";
				if(sid.equals("Completed") || sid.equals("Approve") || sid.equals("Pending") || sid.equals("WorkinProgress"))
					{
						System.out.print("\nSTATUS filter"+sid);
						query2="select cid,una,ctype,cdesc,cdays,cdate,uct,uar,uadd,modifydate,modifyby,statusid from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where statusid='"+sid+"' and uct='"+sc+"'";
						rs2=stmt2.executeQuery(query2);		
					}
				else if (sid.equals("FullList"))
					{
						System.out.print("COMPLETE filter "+sid);
						query2="select cid,una,ctype,cdesc,cdays,cdate,uct,uar,uadd,modifydate,modifyby,statusid from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where uct='"+sc+"'";	
					  	rs2=stmt2.executeQuery("select cid,una,ctype,cdesc,cdays,cdate,uct,uar,uadd,modifydate,modifyby,statusid from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where uct='"+sc+"'");
					}
				else
					{
						System.out.print("\n filter"+sid);
						query2="Select cid,una,ctype,cdesc,cdays,cdate,uct,uar,uadd,modifydate,modifyby,statusid from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where  uct='Vadodara' and DATE(cdate)=CURDATE()"; 
					  	rs2=stmt2.executeQuery(query2);
					}
							
				
				System.out.print("\nupper WHILE\n");
				while(rs2.next())
						{
							System.out.print("INSIDE WHILE\n");
							%>	
					<tr>
					<td>
						<%out.print(rs2.getInt(1)); %>
					</td>
					<td>
						<%out.print(rs2.getString(2)); %>
					</td>
					<td>
						<%out.print(rs2.getString(3)); %>
					</td>
					<td>
						<%out.print(rs2.getString(4)); %>
					</td>
					<td>
						<%out.print(rs2.getInt(5)); %>
					</td>
					
					<td>
						<%out.print(rs2.getTimestamp(6));%>
					</td>
					<td>
						<%out.print(rs2.getString(7)); %>
					</td>
					<td>
						<%out.print(rs2.getString(8)); %>
					</td>
					<td>
						<%out.print(rs2.getString(9)); %>
					</td>
		
					<td>
						<%out.print(rs2.getTimestamp(10)); %>
					</td>
					<td>
						<%out.print(rs2.getString(11)); %>
					</td>
					<td align="center">
						<%out.print(rs2.getString(12));%>
					</td>

					<td><input type="radio" name="sc"
						value="<%out.print(rs2.getInt(1));%>"></td>
					<td><input type="submit" name="sub" value="EDIT"></td>
				</tr>


		<%				}
						rs2.close();
						stmt2.close();
						con2.close();
				}
				else{
					System.out.print("NOT GOING IN BUTTON FILTER");
				}
				
				}
				catch(Exception e)
				{
					System.out.print("YOU HAVE ERROR IN BUTTON SIDE FILTER :"+e.getMessage());
				}
		
		
		%>
		
			
	
		
			
	
	<%	
		//if(sid.equals(null))
			//{	
				System.out.print("\nnot in buttons");
				try{
						
						String stype=request.getParameter("selecttype");
						String sarea=request.getParameter("selectarea");
						String sstatus=request.getParameter("selectstatus");
						System.out.print("not in buttons" + stype+sarea+sstatus);
						
						String dbURL = "jdbc:mysql://localhost:3306/projectcity";
						String dbUserName = "root";
						String dbPassword = "";	
										
						DriverManager.registerDriver(new com.mysql.jdbc.Driver());
						Class.forName("com.mysql.jdbc.Driver");
						Connection con=DriverManager.getConnection(dbURL, dbUserName, dbPassword);
						Statement stmt2=con.createStatement();
								
						String query2="";
						
						if(sarea!="" && stype=="" && sstatus=="")
							{
							
							out.print("<h3> FILTER ON AREA :<b> "+sarea+"</b></h3>");
							System.out.print("only area\n");
							query2="select cid,una,ctype,cdesc,cdays,cdate,uct,uar,uadd,modifydate,modifyby,statusid from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where uar='"+sarea+"' and uct='"+sc+"'";
						
							}
						else if(sarea=="" && stype!="" && sstatus=="")
							{
							out.print("<h3> FILTER ON TYPE :<b> "+stype+"</b></h3>");
							System.out.print("only type\n");
							query2="select cid,una,ctype,cdesc,cdays,cdate,uct,uar,uadd,modifydate,modifyby,statusid from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where ctype='"+stype+"' and uct='"+sc+"'";
							}
						else if(sarea=="" && stype=="" && sstatus!="")
						{
							out.print("<h3> FILTER ON STATUS :<b> "+sstatus+"</b></h3>");
							System.out.print("only status\n");
							query2="select cid,una,ctype,cdesc,cdays,cdate,uct,uar,uadd,modifydate,modifyby,statusid from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where statusid='"+sstatus+"' and uct='"+sc+"'";
						
						}
						
						else if(sarea=="" && stype!="" && sstatus!="")
						{
							out.print("<h3> FILTER ON TYPE :<b> "+stype+"</b> AND STATUS <b>"+sstatus+"</b></h3>");
							System.out.print("In Type and Status\n");
							query2="select cid,una,ctype,cdesc,cdays,cdate,uct,uar,uadd,modifydate,modifyby,statusid from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where ctype='"+stype+"' and statusid='"+sstatus+"' and uct='"+sc+"'";
						
						}
					
						else if(sarea!="" && stype=="" && sstatus!="")
						{
							out.print("<h3> FILTER ON AREA :<b> "+sarea+"</b> AND STATUS <b>"+sstatus+"</b></h3>");
							System.out.print("In Area and Status \n");
							query2="select cid,una,ctype,cdesc,cdays,cdate,uct,uar,uadd,modifydate,modifyby,statusid from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where uar='"+sarea+"' and statusid='"+sstatus+"' and uct='"+sc+"'";
						}
							else if(sarea!="" && stype!="" && sstatus=="")
							{
								out.print("<h3> FILTER ON AREA :<b> "+sarea+"</b> AND TYPE <b>"+stype+"</b></h3>");
								System.out.print("Area and Type\n");
								query2="select cid,una,ctype,cdesc,cdays,cdate,uct,uar,uadd,modifydate,modifyby,statusid from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where ctype='"+stype+"' and uar='"+sarea+"' and uct='"+sc+"'";
							
							}	
													
						else if(sarea!="" && stype!="" && sstatus!="")
							{
						
											out.print("<h3> FILTER ON AREA :<b> "+sarea+"</b> AND TYPE :<b> "+stype+"</b> AND STATUS <b>"+sstatus+"</b></h3>");
															System.out.print("All 3 parameter\n");
									query2="select cid,una,ctype,cdesc,cdays,cdate,uct,uar,uadd,modifydate,modifyby,statusid from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where uar='"+sarea+"' and ctype='"+stype+"' and statusid='"+sstatus+"' and uct='"+sc+"'";
									
							}
						else if(sarea=="" && stype=="" && sstatus=="")
						{
							out.print("<h3> WITHOUT FILTER :<b>ALL COMPLAINS</b></h3>");
							query2="select cid,una,ctype,cdesc,cdays,cdate,uct,uar,uadd,modifydate,modifyby,statusid from complainuser INNER JOIN registeruser on ComplainUser.uid = registeruser.uid where uct='"+sc+"'";	
							
						}
						
						ResultSet  rs2=stmt2.executeQuery(query2);
						while(rs2.next())
						{
			%>
							<tr>
								<td>
									<%out.print(rs2.getInt(1)); %>
								</td>
								<td>
									<%out.print(rs2.getString(2)); %>
								</td>
								<td>
									<%out.print(rs2.getString(3)); %>
								</td>
								<td>
									<%out.print(rs2.getString(4)); %>
								</td>
								<td>
									<%out.print(rs2.getInt(5)); %>
								</td>
				
								<td>
									<%out.print(rs2.getTimestamp(6));%>
								</td>
								<td>
									<%out.print(rs2.getString(7)); %>
								</td>
								<td>
									<%out.print(rs2.getString(8)); %>
								</td>
								<td>
									<%out.print(rs2.getString(9)); %>
								</td>
				
								<td>
									<%out.print(rs2.getTimestamp(10)); %>
								</td>
								<td>
									<%out.print(rs2.getString(11)); %>
								</td>
								<td align="center">
									<%out.print(rs2.getString(12));%>
								</td>
				
								<td><input type="radio" name="sc"
									value="<%out.print(rs2.getInt(1));%>"></td>
								<td><input type="submit" name="sub" value="EDIT"></td>
								</tr>

			<%   
				}
					%>

	

	<%
					rs2.close();
				    stmt2.close(); 
				    con.close();
				 }
					catch(Exception e)
					{
						System.out.print("ERROR IN TABLE RETRIVING IN ADMIN "+e.getMessage());
				    }
			
			//}
	//	else
	//	{
	//		System.out.print("\nNOT GOING IN MANUAL FILTER");
			
	//	}
			
			
			
	%>
</table>
</form>
</div>
</body>
</html>