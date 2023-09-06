import java.io.IOException;
import java.io.InputStream;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.Statement;


import javax.servlet.ServletException;
import javax.servlet.annotation.MultipartConfig;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import javax.servlet.http.Part;

@WebServlet("/ComplainStore")
@MultipartConfig(maxFileSize = 1024000000)
public class ComplainStore extends HttpServlet {
	private static final long serialVersionUID = 1L;

	Connection con = null;
	String message = null;

	// declare your db settings here as a private variables
	private String dbURL = "jdbc:mysql://localhost:3306/projectcity";
	private String dbUserName = "root";
	private String dbPassword = "";

	// input stream of the image file

	protected void doPost(HttpServletRequest request,
			HttpServletResponse response) throws ServletException, IOException {

		String complain = request.getParameter("comp");
		String problem = request.getParameter("prb");
		int d1 = Integer.parseInt(request.getParameter("days"));

		InputStream inputStream = null;
		Part img = request.getPart("upload");
		int a = 0;

		HttpSession ss = request.getSession(false);
		String st = (String) ss.getAttribute("username");

		try {
			if (img != null) {
				// debugging mate
				System.out.println(img.getName());
				System.out.println(img.getSize());
				System.out.println(img.getContentType());

				inputStream = img.getInputStream();

			} else {
				System.out.print("it is null");
			}
		} catch (NullPointerException e) {
			System.out.print("EERRROR " + e.getMessage());
		}

		try {
			DriverManager.registerDriver(new com.mysql.jdbc.Driver());
			Class.forName("com.mysql.jdbc.Driver");
			con = DriverManager.getConnection(dbURL, dbUserName, dbPassword);

			String sql = "insert into complainuser(uid,ctype,cdesc,cdays,cimg,cdate) values (?,?,?,?,?,CURRENT_TIMESTAMP)";

			PreparedStatement ps = con.prepareStatement(sql);
			Statement s = con.createStatement();
			ResultSet rs = s.executeQuery("select uid from registeruser where una='"+ st + "'");
			
			if (rs.next()) {
				a = rs.getInt(1);
				ss.setAttribute("userid",a);
			}
			ps.setInt(1, a);
			ps.setString(2, complain);
			ps.setString(3, problem);
			ps.setInt(4, d1);
			if (inputStream != null) {
				ps.setBlob(5, inputStream);
			} else {
				ps.setBlob(5, inputStream);
			}

			ps.execute();

			ps.close();
			con.close();

			request.getRequestDispatcher("/index.jsp").include(request, response);
			
		}

		catch (Exception e) {
			System.out.println(" COMPLAIN ERROR :" + e.getMessage());
		}

	}

}
