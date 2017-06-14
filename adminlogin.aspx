<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminlogin.aspx.cs" Inherits="adminlogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><link rel="shortcut icon" href="images/santaIcon.ico" />
    <title>The Bramption Board of Trade Parade Management System</title>
<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000">
<form id="form1" runat="server">
    <div id="Layer1" style="position: absolute; left: 578px; top: 332px; width: 207px;
        height: 273px; z-index: 1">
        <p>
            <font color="#006600"><strong><font color="#336633">&gt;</font> <a href="SantaHistory.aspx">
                History of the Parade</a></strong></font></p>
        <p>
            <strong><font color="#336633">&gt;</font><font color="#006600"> <a href="SantaRoute.aspx">
                Parade Route</a></font></strong></p>
        <p>
            <strong><font color="#336633">&gt;</font><font color="#006600"> <a href="SantaSponsor.aspx">
                Current Sponsors</a></font></strong></p>
        <p>
            <strong><font color="#006600">&gt; <a href="SantaInvolved.aspx">Get Involved</a></font></strong></p>
         <p><strong><font color="#006600">&gt; <a href="userLogin.aspx">User Login</a></font></strong></p>


   

    <p><strong><font color="#006600">&gt; <a href="adminLogin.aspx">Administrative Login</a></font></strong></p>
        <p>
            <strong><font color="#006600">&gt; <a href="SantaPress.aspx">Press Release</a></font></strong></p>
        <p>
            <strong><font color="#006600">&gt; <a href="SantaPhoto.aspx">Photo Gallary</a></font></strong></p>
        <p>
            <strong><font color="#006600">&gt; <a href="SantaSocialMedia.aspx">Twitter / Facebook</a></font></strong></p>
    </div>
     <div id="Div1" style="position: absolute; left: 103px; top: 481px; width: 416px;
        height: 96px; z-index: 3">
        <asp:Label ID="userNameLbl" runat="server" Text="Enter Your Username:"></asp:Label>
         &nbsp;
         <asp:TextBox ID="userNameTxt" runat="server" ></asp:TextBox><br /><br />
        
         <asp:Label ID="passResetLbl" runat="server" Text="Enter Your Admin Email:"></asp:Label>
         &nbsp;
         <asp:TextBox ID="passResetTxt" runat="server"></asp:TextBox><br /><br />
                                               <asp:Button ID="passResetOkBtn" 
             runat="server" Text="OK" onclick="passResetOkBtn_Click" />
             <asp:Button ID="passResetCancelBtn" runat="server" Text="Cancel" 
             onclick="passResetCancelBtn_Click" />
    </div>
    <div id="Layer2" style="position: absolute; left: 10px; top: 395px; width: 555px;
        height: 96px; z-index: 2">
        <hr />
        
        <asp:Label ID="loginLbl" runat="server" Text="Login :"></asp:Label>
        <asp:TextBox ID="paradeAdminUser" runat="server"></asp:TextBox>
        <br>
        <asp:Label ID="passLbl" runat="server" Text="Pass :"></asp:Label>
        <font color="#FFFFFF">.</font>
        <asp:TextBox ID="paradeAdminPass" runat="server" TextMode="Password"></asp:TextBox>
        <p>
            <asp:ImageButton ID="paradeAdminSubmit1" runat="server" ImageUrl="~/images/Login.png"
                OnClick="paradeAdminSubmit1_Click"></asp:ImageButton></p>
        <p>
            <a href="SantaParticipateReg.aspx"></a>
            <asp:Label ID="textLbl" runat="server" Text=""></asp:Label></p>
        <asp:Label ID="textLbl2" runat="server" Text=""></asp:Label>
        <p>
            &nbsp;</p>
       
       
    </div>
   
    <div id="Layer3" style="position: absolute; left: 8px; top: 701px; width: 555px;
        height: 168px; z-index: 3">
        <hr />
        <font color="#990000" size="+3">News Updates<br>
            <br />
        </font><font color="#000000"><a href="SantaSponsor.aspx">Thanks to our sponsors, partners
            and volunteers!</a></font>
        <p>
            <a href="http://www.bamnfbot.com/santa2/2011%20Santa%20Claus%20Parade%20Regulations.pdf">
                2011 Santa Claus Parade Regulations</a><font color="#990000" size="+3"> </font>
        </p>
    </div>
    <p>
        <img src="images/mypic.png" width="532" height="285">
        <a href="SantaHome.aspx">
            <img src="images/santaface.JPG" width="248" height="290" border="0"></a></p>
    <p>
        <font color="#990000" size="+3">Administrative Login</font></p>

        <br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br />
    <br />
    <asp:Label ID="passwordLbl" runat="server" Text="Forgot your password? Click"></asp:Label>
    
    <asp:Button ID="passwordBtn" runat="server" Text="here" 
        onclick="passwordBtn_Click" />

    <br />
    <asp:Label ID="test" runat="server" Text=""></asp:Label>

    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><marquee><h1><asp:Label ID="scrollText" runat="server" Text="bamnf Santa Claus Parade"></asp:Label></h1></marquee>
     </form>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
        
</body>
</html>
