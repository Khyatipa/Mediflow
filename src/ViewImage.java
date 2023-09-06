

import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;

import javax.servlet.ServletException;
import javax.servlet.ServletOutputStream;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;


@WebServlet("/ViewImage")
public class ViewImage extends HttpServlet {
	private static final long serialVersionUID = 1L;


	protected void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException
	{
		byte[] img=null;
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
		String query="select cid,ctype,cdesc,cdays,cimg,cdate,modifydate,modifyby,statusid from complainuser where uid="+id;
	
		ResultSet rs=stmt.executeQuery(query);
		
		
		
		
		
		
		
		
	}

}
