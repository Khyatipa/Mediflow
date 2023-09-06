

import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;


import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import com.mysql.jdbc.exceptions.jdbc4.MySQLSyntaxErrorException;


@WebServlet("/EditComplainStore")
public class EditComplainStore extends HttpServlet {
	private static final long serialVersionUID = 1L;


	protected void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException 
	
	{
		try
		{	
			HttpSession ss=request.getSession(false);
			int id = Integer.parseInt(ss.getAttribute("cid").toString());
			System.out.print(id);
			Connection con = null;
			
			String dbURL = "jdbc:mysql://localhost:3306/projectcity";
			String dbUserName = "root";
			String dbPassword = "";	
			
			String adminna=request.getParameter("mname");
			String adminid=request.getParameter("status");
			
			System.out.print(adminna);
			System.out.print(adminid);
			DriverManager.registerDriver(new com.mysql.jdbc.Driver());
			Class.forName("com.mysql.jdbc.Driver");
			con = DriverManager.getConnection(dbURL, dbUserName, dbPassword);
			String query="update complainuser set modifyby=(?),statusid=(?),modifydate=CURRENT_TIMESTAMP where cid="+id;
									
			PreparedStatement ps=con.prepareStatement(query);
			
			ps.setString(1,adminna);
			ps.setString(2, adminid);
		
			ps.execute();
			
			System.out.print("SUCCESS");
			
			request.getRequestDispatcher("/AdminPage.jsp").include(request, response);
			
		}
		catch(MySQLSyntaxErrorException e)
		{
			System.out.print("SyntaxError :"+e.getMessage());
		}
		catch(Exception e)
			{
				System.out.print("INSERT ERROR FROM ADMIN"+e.getMessage());
			}
	}

}
