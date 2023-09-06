

import java.io.IOException;
import java.io.PrintWriter;
import java.sql.Connection;

import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;


@WebServlet("/EditComplain")
public class EditComplain extends HttpServlet {
	private static final long serialVersionUID = 1L;

	protected void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException 
	
	{
		try
		{	
			String i=(request.getParameter("sc"));
			HttpSession ss=request.getSession(false);
			ss.setAttribute("cid",i);
			
			Connection con = null;
			
			System.out.print(i+"null");
			String dbURL = "jdbc:mysql://localhost:3306/projectcity";
			String dbUserName = "root";
			String dbPassword = "";	
							
			DriverManager.registerDriver(new com.mysql.jdbc.Driver());
			Class.forName("com.mysql.jdbc.Driver");
			con = DriverManager.getConnection(dbURL, dbUserName, dbPassword);
			
			Statement stmt=con.createStatement();
			String query="select ctype,cdesc,cdays from complainuser where cid="+i;
		
			ResultSet rs=stmt.executeQuery(query);
		
			request.setAttribute("complainid",i);
				while(rs.next())
				{
					
					request.setAttribute("comp",rs.getString(1));
					//System.out.println("COMPLAIN TYPE :"+rs.getString(1));
					request.setAttribute("prb",rs.getString(2));
					//System.out.println("DESCRIPTION   :"+rs.getString(2));
					request.setAttribute("days",String.valueOf(rs.getInt(3)));
					//System.out.println("NO. of Days   :"+rs.getInt(3)+"\n\n");
				}
				//System.out.print(comp);
				
		request.getRequestDispatcher("/EditForm.jsp").forward(request, response);
		
		
		}
		catch(Exception e)
		{
			System.out.print("EDIT ERROR :"+e.getMessage());
		
		
	}

}}
