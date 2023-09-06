
import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

@WebServlet("/AdminLogin")
public class AdminLogin extends HttpServlet 
{
	private static final long serialVersionUID = 1L;

	protected void service(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException 
	{
		
		String na=request.getParameter("name");
		String pw=request.getParameter("pass");
		
		String sub=request.getParameter("sub");
		
		HttpSession hs=request.getSession();
		
		hs.setAttribute("adminname",request.getParameter("name"));
		//hs.removeAttribute("cityname");
		hs.setAttribute("cityname",request.getParameter("city"));
		//String s=(String)hs.getAttribute("cityname");
		//hs.setAttribute("flag","0");//used in displaying complain filters of all 3 parameters
		//System.out.print(cityname);
		if(sub.equals("Login"))
		{
			try
			{
				Class.forName("com.mysql.jdbc.Driver");
				
				Connection con = DriverManager.getConnection(
						"jdbc:mysql://localhost/projectcity", "root", "");

				Statement st = con.createStatement();
				//ResultSet rs1=st.executeQuery("select act from admin where ana")
				ResultSet rs = st
						.executeQuery("select * from admin where ana='" + na
								+ "' and apw='" + pw + "'");
				
				if(rs.next())
				{
					//String ctna=rs.getString(4);
					//hs.setAttribute("cityname",ctna);
					request.getRequestDispatcher("/AdminPage.jsp").forward(request, response);;
				}
				else
				{
					System.out.println("\n Data Error");
				}
				
				rs.close();
				st.close();
				con.close();
				
			}
			catch(Exception e)
			{
				System.out.println("\n Login Error : "+e.getMessage());
			}
		}

		
	}

}
