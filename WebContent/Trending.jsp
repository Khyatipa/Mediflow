<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
    <%@ page import="java.io.*"%>
	<%@ page import="java.sql.*" %>
	<%@ page import="javax.servlet.*" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Insert title here</title>
</head>
<body>
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
				String query="select ctype,cimg from complainuser ";
				String type="";
				ResultSet rs=stmt.executeQuery(query);
				
				while(rs.next())
				{
					type=rs.getString(1);
					InputStream is=rs.getBinaryStream(2);
					OutputStream os=new FileOutputStream(new File(src/newimages/"+type+".jpg"));
				}

			}
			catch(Exception e)
			{
				System.out.print("TRENDING ERROR"+e.getMessage());
			}


	%>




</body>
</html>





	
	
  	