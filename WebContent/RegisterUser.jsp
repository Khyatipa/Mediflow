<%@ page language="java" contentType="text/html; charset=ISO-8859-1"
    pageEncoding="ISO-8859-1"%>
   

<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=ISO-8859-1">

<!--    linked css file-->
<link href="css/header.css" rel="stylesheet" type="text/css">
<link href="css/register.css" rel="stylesheet" type="text/css">

<title> City Administration </title>

<!--    linked font awesome -->
<script src="https://kit.fontawesome.com/63678e90c0.js" crossorigin="anonymous"></script>

<!--    linked favicon -->
<link rel="shortcut icon" type="image/png" href="images/logo.png">

<!--    linked header font -->
<link href="https://fonts.googleapis.com/css2?family=Contrail+One&family=Fredoka+One&family=Merienda:wght@700&display=swap" rel="stylesheet">

<!--    linked body font -->
<link href="https://fonts.googleapis.com/css2?family=Antic+Didone&family=Arapey&family=Contrail+One&family=Fredoka+One&family=Merienda+One&family=Merienda:wght@700&family=Nanum+Gothic+Coding&display=swap" rel="stylesheet">

	<script>
	
      function checkid()
  	{
  	var e=document.getElementById("iid");
  	var data=f1.name.value;
  	var pat="^[a-z]{2}[0-9]{2}$";
  	var reg=new RegExp(pat);
  		
  		if(reg.test(data))
  		{
  			e.src="green.png";	
  		}
  		else
  		{
  			
  		alert("ENTER USERID ex:ab22");
  	f1.name.focus();
  		e.src="red.png";
  		
  		}
  	}
	function checkarea()
  	{
  	var e=document.getElementById("iarea");
  	var data=f1.area.value;
  	var pat="^[A-Z a-z]*$";
  	var reg=new RegExp(pat);
  		
  		if(reg.test(data))
  		{
  		e.src="green.png";	
  		}
  		else
  		{
  		alert("Select area");	
  		e.src="red.png";
  		}

  	}

  	function checkcity()
  	{
  	var e=document.getElementById("ict");
  	var data=f1.city.value;
  	var pat="^[A-Z a-z]*$";

  	var reg=new RegExp(pat);
  		
  		if(reg.test(data))
  		{
  		e.src="green.png";	
  		}
  		else
  		{
  		alert("Select city");		
  		e.src="red.png";
  		}
  	}


  	function checkemail()
  	{
  	var e=document.getElementById("iemail");
  	var data=f1.email.value;
  	var pat="[\\w]*[\\w]\\@[\\w]+[\\w][\\.][\\w]+[\\w]";
  	var reg=new RegExp(pat);
  		
  		if(reg.test(data))
  		{
  		e.src="green.png";	
  		}
  		else
  		{
  		alert("Enter valid email");		
  		e.src="red.png";
  		}

  	}


  	function checkaadhar()
  	{
  	var e=document.getElementById("iaa");
  	var data=f1.aadhar.value;
  	var pat="^[0-9]{12}$";
  	var reg=new RegExp(pat);
  		
  		if(reg.test(data))
  		{
  		e.src="green.png";	
  		}
  		else
  		{
  		alert("ENTER 12 digit aadhar");	
  		e.src="red.png";
  		}

  	}
  	
  	function checkadd()
  	{
  	var e=document.getElementById("iadd");
  	var data=f1.add.value;
  	var pat="^[a-zA-Z0-9\s\,\''\-]{3,}$";
  	var reg=new RegExp(pat);
  		
  		if(reg.test(data))
  		{
  		e.src="green.png";	
  		}
  		else
  		{
  		alert("Enter Proper address");	
  		e.src="red.png";
  		}

  	}
  	
  	function checkpass()
  	{
  	var e=document.getElementById("ipwd");
  	var data=f1.pass.value;
  	var pat="^[a-zA-Z0-9!@#$%^&*]{6,16}$";//at least one numeric digit, one uppercase and one lowercase letter
  	var reg=new RegExp(pat);
  		
  		if(reg.test(data))
  		{
  		e.src="green.png";	
  		}
  		else
  		{
  		alert("at least one numeric digit, one-one upperlower letter 6-20 char");	
  		e.src="red.png";
  		}

  	}
  	function checkrepass()
  	{
  	var e=document.getElementById("irpwd");
  	var data=f1.pass.value;
  	var data1=f1.repass.value;
  	 
  		
  		if(data==data1)
  		{
  		e.src="green.png";	
  		}
  		else
  		{
  		alert("ReEnter password Wrong Match");
  		e.src="red.png";
  		}

  	}
  	
	</script>

</head>

 <body> 
 
	 <div class="head">
        <a href="RegisterUser.jsp"> 
        <!--    logo -->
        <img src="images/logo.png" height="48px" width="48px"> 
        City Administration 
        </a>
    </div>
   <br> 
   
 <ul>
 <li>
 <br><br><br>
 <div class="slideshow-container">

<div class="mySlides fade">
  <div class="numbertext">1 / 4</div>
  <img src="images/6.jpg" style="width:765 height:425">
</div>

<div class="mySlides fade">
  <div class="numbertext">2 / 4</div>
  <img src="images/5.jpg" style="width:765 height:425">
</div>

<div class="mySlides fade">
  <div class="numbertext">3 / 4</div>
  <img src="images/4.jpg" style="width:765 height:425">
</div>

<div class="mySlides fade">
  <div class="numbertext">4 / 4</div>
  <img src="images/1.jpg" style="width:765 height:425">
</div>


</div>
<br>

<div style="text-align:center">
  <span class="dot"></span> 
  <span class="dot"></span> 
  <span class="dot"></span> 
  <span class="dot"></span>
</div>
 
  	<script>
  	var slideIndex = 0;
  	showSlides();

  	function showSlides() {
  	  var i;
  	  var slides = document.getElementsByClassName("mySlides");
  	  var dots = document.getElementsByClassName("dot");
  	  for (i = 0; i < slides.length; i++) {
  	    slides[i].style.display = "none";  
  	  }
  	  slideIndex++;
  	  if (slideIndex > slides.length) {slideIndex = 1}    
  	  for (i = 0; i < dots.length; i++) {
  	    dots[i].className = dots[i].className.replace(" active", "");
  	  }
  	  slides[slideIndex-1].style.display = "block";  
  	  dots[slideIndex-1].className += " active";
  	  setTimeout(showSlides, 2000); // Change image every 2 seconds
  	}
  	</script> 
 
 </li>
 
 <li>   
    <form name="f2" action="RegisterStore"  class="login">
    <div class="h2"><b> Log In </b></div>
    <fieldset>  
        <legend>Login Information</legend>  
    <table>
        <tr>
            <td> Email </td>
            <td> Password </td>
        </tr>
        <tr>
            <td>
                <input type="text" name="tna" >
            </td>            
            <td>
                <input type="password" name="tpw">
            </td>
            <td class="submit">
               <input type="submit" name="sub" value="Login" class="submit">
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <a href="#"> Forgotten account? </a>
            </td>
        </tr>
    </table>
    </fieldset>
    <br>
    City Administration helps us to keep our city clean.
    </form>
   
  </li>
  
  <li> 
    <form name="f1" action="RegisterStore" class="registration">  
    <div class="h2"><b> Registration </b></div> 
     <fieldset >  
        <legend>User personal information</legend>  
        
        <table>
        <tr>
			<td>
				<label> Username  </label>  
			</td>
			<td>
		        <input type="text" name="name" onblur="checkid()"> 
		        <img id="iid" src="white.png" width=20 height=20><br> 
		    </td>
         </tr>
         
     <tr>
		<td>    
	<label> Email  </label> </td>
	<td> 
         <input type="text" name="email" onblur="checkemail()" >
          <img id="iemail" src="white.png" width=20 height=20><br> 
        </td>
     </tr>
     
     <tr>
		<td>    
	<label> City  </label> </td>
	<td>
	<select name="city"  onblur="checkcity()">
	  <option></option>
	  <option value="Ahmedabad"> Ahmedabad </option>
	  <option value="Vododara"> Vadodara </option>
	  <option value="Surat"> Surat </option>
	  <option value="Rajkot"> Rajkot </option>
	  <option value="Jamnagar"> Jamnagar </option>
	  <option value="Bharuch"> Bharuch </option>
	</select>  
	 <img id="ict" src="white.png" width=20 height=20><br>       
        </td>
     </tr>
     
     <tr>
			<td>
	<label> Area  </label>
	</td>
	<td>
	<select name="area" onblur="checkarea()" >
          <option></option>
	  <option value="sama">sama</option>
	  <option value="karelibaugh">karelibaugh</option>
	  <option value="channi">channi</option>
	  <option value="raopura">raopura</option>
	</select>
	 <img id="iarea" src="white.png" width=20 height=20><br> 
	 </td>
	 </tr>
	 
	<tr>
			<td>
	<label> Aadhar Card-No </label>
	</td>
	<td> 
	<input type="text" name="aadhar"  onblur="checkaadhar()">
	 <img id="iaa" src="white.png" width=20 height=20><br>         
	</td>
	</tr>
	
	<tr>
			<td>
	 <label> Gender  </label> 
	 </td>
	 <td>
         <input type="radio" id="gender" name="gender" value="male"/> Male    
         <input type="radio" id="gender" name="gender" value="female"/> Female     
         <input type="radio" id="gender" name="gender" value="others"/> Others <br/>   
      </td>
      </tr>
      
      <tr>
			<td>
	  <label> Address </label> </td>
	  <td> 
         <textarea name="add" onblur="checkadd()"></textarea>  
		 <img id="iadd"src="white.png" width=20 height=20><br> 
		</td>
		</tr>
		
		<tr>
			<td>
	 <label> Password  </label></td>
	 <td> 
         <input type="password" name="pass" onblur="checkpass()" >  
         <img id="ipwd"src="white.png" width=20 height=20> <br>
	 </td>
	 </tr>
	 
	 <tr>
			<td>
	 <label> Confirm password  </label>  
	 </td>
	 <td>
         <input type="password" name="repass" onblur="checkrepass()" >
          <img id="irpwd"src="white.png" width=20 height=20><br> 
          </td>
          </tr>

          <tr>
          <td></td>
			<td class="submit">  
         <input type="submit" name="sub" value="Register" class="submit">
         </td></tr>
         
         </table>  
     </fieldset>  
  </form>
  
  </li>
  </ul>
 </body>
</html>