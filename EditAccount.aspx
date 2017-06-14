<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditAccount.aspx.cs" Inherits="EditAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000">
    <p>
        <img src="images/mypic.png" width="532" height="285">
        <a href="SantaHome.htm">
            <img src="images/santaface.JPG" width="248" height="290" border="0" /></a>Welcome
        :<asp:Label ID="usernameSession" runat="server" Text=""></asp:Label>
        <br>
        <font color="#990000" size="+3">Edit Account Info</font></p>
    <div id="Layer1" style="position: absolute; left: 10px; top: 357px; width: 754px;
        height: 162px; z-index: 1">
        <form id="form1" runat="server">
        <p>
            First Name:
            <asp:TextBox ID="txtBxFirstName" runat="server"></asp:TextBox>
            <font color="#FF0000">*</font><br>
            Last Name :
            <asp:TextBox ID="txtBxLastName" runat="server"></asp:TextBox>
            <font color="#FF0000">*</font><br>
            Email :<font color="#FFFFFF">..........</font>
            <asp:TextBox ID="txtBxEmail" runat="server"></asp:TextBox>
            <br>
            Phone # :<font color="#FFFFFF"> ..... </font>
            <asp:TextBox ID="txtBxPhoneNo" runat="server"></asp:TextBox>
            <font color="#FF0000">*</font><br>
            Cell Phone:<font color="#FFFFFF">...</font>
            <asp:TextBox ID="txtBxCellPhone" runat="server"></asp:TextBox>
            <br />
            Fax : <font color="#FFFFFF">...........</font>
            <asp:TextBox ID="txtBxFax" runat="server"></asp:TextBox>
            <br />
            <p>
                <br>
                <br>
                <font color="#FF0000">*Manditory</font>
            </p>
            <!-- <p><a href="SantaInvolved.htm"><img src="images/Back.png" width="61" height="43" border="0"></a> -->
            <!--   -->
            <asp:HyperLink ID="HyperLink1" href="SantaInvolved.aspx" runat="server">
        <img src="images/Back.png" alt ="" width="84" height="43"></asp:HyperLink>
            <font color="#FFFFFF">......................................</font>
            <asp:ImageButton ID="VolunteerSubmit" ImageUrl="images/Continue.png" runat="server" />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="signOut" runat="server" Text="Sign Out!" OnClick="signOut_Click" />
        </p>
    </div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    </form >
</body>
</html>
