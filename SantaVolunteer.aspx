<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SantaVolunteer.aspx.cs" Inherits="SantaVolunteer" %>

<!DOCTYPE aspxl PUBLIC "-//W3C//DTD XaspxL 1.0 Transitional//EN" "http://www.w3.org/TR/xaspxl1/DTD/xaspxl1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xaspxl">
<head runat="server"><link rel="shortcut icon" href="images/santaIcon.ico" />
    <title>bamnf Santa Claus Parade Get Involved</title>
    <meta http-equiv="Content-Type" content="text/aspxl; charset=iso-8859-1">

<script language="JavaScript" type="text/JavaScript">

<!--
    function MM_reloadPage(init) {  //reloads the window if Nav4 resized
        if (init == true) with (navigator) {
            if ((appName == "Netscape") && (parseInt(appVersion) == 4)) {
                document.MM_pgW = innerWidth; document.MM_pgH = innerHeight; onresize = MM_reloadPage;
            } 
        }
        else if (innerWidth != document.MM_pgW || innerHeight != document.MM_pgH) location.reload();
    }
    MM_reloadPage(true);

//-->

</script>

<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000">

<div id="Layer1" style="position:absolute; left:578px; top:332px; width:207px; height:273px; z-index:1"> 

  <p><font color="#006600"><strong><font color="#336633">&gt;</font> <a href="SantaHistory.aspx">History 

    of the Parade</a></strong></font></p>

  <p><strong><font color="#336633">&gt;</font><font color="#006600"> <a href="SantaRoute.aspx">Parade 

    Route</a></font></strong></p>

  <p><strong><font color="#336633">&gt;</font><font color="#006600"> <a href="SantaSponsor.aspx">Current 

    Sponsors</a></font></strong></p>

  <p><strong><font color="#006600">&gt; <a href="SantaInvolved.aspx">Get Involved</a></font></strong></p>

  <p><strong><font color="#006600">&gt; <a href="userLogin.aspx">User Login</a></font></strong></p>

    

    <p><strong><font color="#006600">&gt; <a href="adminLogin.aspx">Administrative Login</a></font></strong></p>

  <p><strong><font color="#006600">&gt;&gt; <a href="SantaHelpSponsor.aspx">Sponsor</a></font></strong></p>

  <p><strong><font color="#006600">&gt; <a href="SantaPress.aspx">Press Release</a></font></strong></p>

  <p><strong><font color="#006600">&gt; <a href="SantaPhoto.aspx">Photo Gallary</a></font></strong></p>

  <p><strong><font color="#006600">&gt; <a href="SantaSocialMedia.aspx">Twitter 

    / Facebook</a></font></strong></p>

</div>

<div id="Layer2" style="position:absolute; left:10px; top:395px; width:555px; height:224px; z-index:2"> 

  <hr/>
  <form id="form1" runat="server">
  Login: 

  <asp:TextBox ID="VolunteerLogin" runat="server"></asp:TextBox>

  <br>

  Pass: <font color="#FFFFFF">.</font> 

  <asp:TextBox ID="VolunteerPass" runat="server"></asp:TextBox>

  <p><asp:ImageButton ID="VolunteerSubmit" runat="server" 
          ImageUrl="~/images/Login.png"></asp:ImageButton></p>

  <p><a href="SantaVolunteerReg.aspx">Regester</a></p>

  <p>&nbsp;</p>
  </form>
  <form name="form1" method="post" action="">

  </form>

</div>

<div id="Layer3" style="position:absolute; left:11px; top:626px; width:555px; height:168px; z-index:3">

  <hr/>

  <font color="#990000" size="+3">News Updates<br>

  <br>

  </font><font color="#000000"><a href="SantaSponsor.aspx">Thanks to our sponsors, 

  partners and volunteers!</a></font> 

  <p><a href="http://www.bamnfbot.com/santa2/2011%20Santa%20Claus%20Parade%20Regulations.pdf">2011 

    Santa Claus Parade Regulations</a><font color="#990000" size="+3"> </font></p>

  </div>

<p><img src="images/mypic.png" width="532" height="285"> <a href="SantaHome.aspx"><img src="images/santaface.JPG" width="248" height="290" border="0"></a></p>

<p><font color="#990000" size="+3">Volunteer Login</font></p>
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><marquee><h1><asp:Label ID="scrollText" runat="server" Text="bamnf Santa Claus Parade"></asp:Label></h1></marquee>
<p>&nbsp;</p>

<p>&nbsp;</p>

</body>


</html>