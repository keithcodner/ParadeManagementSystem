<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SantaVolunteerReg.aspx.cs" Inherits="SantaVolunteerReg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><link rel="shortcut icon" href="images/santaIcon.ico" />
    <title></title>
<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000">
<form id="form1" runat="server">
<p><img src="images/mypic.png" width="532" height="285"> <a href="SantaHome.htm"><img src="images/santaface.JPG" width="248" height="290" border="0"><br>

  </a><font color="#990000" size="+3">Volunteer Signup</font></p>

<div id="Layer1" style="position:absolute; left:10px; top:357px; width:754px; height:162px; z-index:1"> 



<asp:Panel ID="volSignUpPanel" runat="server" >

  <p> First Name: <font color="#FFFFFF"> ............... </font> 

   

      <asp:TextBox ID="eFirstName" runat="server"></asp:TextBox>
    <font color="#FF0000"></font><asp:RequiredFieldValidator ID="validateFirstName"
        runat="server" ErrorMessage="*First Name is required" 
            ControlToValidate="eFirstName" ForeColor="Red"></asp:RequiredFieldValidator><br>

    Last Name :<font color="#FFFFFF"> .............. </font> 

    <asp:TextBox ID="eLastName" runat="server"></asp:TextBox>

    <font color="#FF0000"></font><asp:RequiredFieldValidator ID="validateLastName"
        runat="server" ErrorMessage="*Last Name is required" ForeColor="Red" 
            ControlToValidate="eLastName"></asp:RequiredFieldValidator><br>

    UserName:<font color="#FFFFFF">................</font> 

    <asp:TextBox ID="eUsername" runat="server"></asp:TextBox>
    <font color="#FF0000"></font><asp:RequiredFieldValidator
        ID="validateUserName" runat="server" ErrorMessage="*Username is required" 
            ForeColor="Red" ControlToValidate="eUsername"></asp:RequiredFieldValidator>
    <br>

    Password:<font color="#FFFFFF"> ................. </font> 

    <asp:TextBox ID="ePassword" runat="server" TextMode="Password"></asp:TextBox>

    <font color="#FF0000"></font>
        <asp:CompareValidator ID="validatePasswordMatch" runat="server"
        ErrorMessage="*Password did not match" ForeColor="Red" 
            ControlToCompare="Re_ePassword" ControlToValidate="ePassword"></asp:CompareValidator><asp:RequiredFieldValidator
        ID="validatePassword" runat="server" ErrorMessage="*Password is required" 
            ForeColor="Red" ControlToValidate="ePassword"></asp:RequiredFieldValidator>
        <br>

    Re-type Password:<font color="#FFFFFF">.....</font> 

    <asp:TextBox ID="Re_ePassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatePasswordReEntry" runat="server" 
            ControlToValidate="Re_ePassword" ErrorMessage="*You did not re-type password" 
            ForeColor="Red"></asp:RequiredFieldValidator>
    <br>

    Home/Cell Number: <font color="#FFFFFF">...</font> 

    <asp:TextBox ID="eHomeNumber" runat="server"></asp:TextBox>

    <br>

    <font color="#FF0000"></font><font color="#FF0000"></font>Business Number: <font color="#FFFFFF">......</font> 

    <asp:TextBox ID="eBusinessNumber" runat="server"></asp:TextBox>

    <br>

    Email : <font color="#FFFFFF">.......................</font> 

    <asp:TextBox ID="eEmail" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator
        ID="validateEmail" runat="server" ErrorMessage="*Email is Required*" 
            ForeColor="Red" ControlToValidate="eEmail"></asp:RequiredFieldValidator>
            <br>
            <br><br>
            <font id="changeColor" color="#FF0000">*Manditory</font> </p>
            <br><br><br><br>
            <asp:HyperLink
        ID="HyperLink1" href="SantaInvolved.aspx" runat="server">
        <img src="images/Back.png" alt ="" width="84" height="43"></asp:HyperLink>
         <font color="#FFFFFF"> ......................................</font>
      <asp:ImageButton ID="VolunteerSubmit" ImageUrl="images/Continue.png" 
        runat="server" onclick="VolunteerSubmit_Click" />
    </asp:Panel>
    <br>

    
<asp:Panel ID="afterSubmitPanel" runat="server" visible="false"
            style="position:absolute; left:4px; top:16px; width:453px; height:226px; z-index:2">
            <p> An email has been sent to your inbox.<br />
            Click
                <asp:HyperLink ID="HyperLink2" runat="server" href="SantaVolunteer.aspx">Here</asp:HyperLink>
               to sign in once your account is verified. </p>
               
</asp:Panel>
    
    

 

  <p><br>

    <br>

    

  <!-- <p><a href="SantaInvolved.htm"><img src="images/Back.png" width="61" height="43" border="0"></a> -->

   <!--   -->
   </p>

</div>
</form >
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><marquee><h1><asp:Label ID="scrollText" runat="server" Text="Brampton Santa Claus Parade"></asp:Label></h1></marquee>
<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

</body>
</html>
