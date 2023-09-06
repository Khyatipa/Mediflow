<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
	pageEncoding="ISO-8859-1"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">
<title>Insert title here</title>
</head>
<body>
	<%
	HttpSession ss=request.getSession(false);
	String st=(String)ss.getAttribute("username");
	out.println("<br><br> USER NAME : "+st);
	
	%>
	<form name="f1" method="post" action="ComplainStore"
		enctype="multipart/form-data">
		<h1>
			<u><b>MAKE COMPLAINT!</b></u>
		</h1>
		<br>
		<fieldset>
			<legend>
				<b>We are here to assist you!</b>
			</legend>

			<br>
			<fieldset>
				<legend>
					<label>Choose Complaint Type:</label>
				</legend>
				<select name="comp">
					<option></option>
					<option value="Water">Water</option>
					<option value="Electricity">Electricity</option>
					<option value="GasLine">GasLine</option>
					<option value="Drainage">Drainage</option>
					<option value="Garbage">Garbage</option>
					<option value="StrayAnimal">StrayAnimal</option>
				</select>
			</fieldset>
			<br> <label>Enter your Problem:</label><br>
			<textarea name="prb"></textarea>
			<br> <br> <label>Enter Days Suffered</label><br> <input
				type="text" name="days"> <br>
			<br> <label>Upload Images</label><br> <input type="file"
				name="upload"><br> <br> <input type="submit"
				name="sub" value="COMPLAIN!">


		</fieldset>


	</form>



</body>
</html>