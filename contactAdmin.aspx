<%@ Page Language="C#" AutoEventWireup="true" CodeFile="contactAdmin.aspx.cs" Inherits="contactAdmin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server"><link rel="shortcut icon" href="images/santaIcon.ico" />
    <title>User Area</title>
   <style type="text/css"> body{padding:5px; font-family:Helvetica, Arial, Sans-Serif; color:Black;} *{padding:0; margin:0;}
        ul {
  font-family: Arial, Verdana;
  font-size: 14px;
  margin: 0;
  padding: 0;
  list-style: none;
}
ul li {
  display: block;
  position: relative;
  float: left;
}
li ul { display: none; }
ul li a {
  display: block;
  text-decoration: none;
  color: #ffffff;
  border-top: 1px solid #ffffff;
  padding: 5px 15px 5px 15px;
  background: #2C5463;
  margin-left: 1px;
  white-space: nowrap;
}
ul li a:hover { background: #617F8A; }
li:hover ul {
  display: block;
  position: absolute;
}
li:hover li {
  float: none;
  font-size: 11px;
}
li:hover a { background: #617F8A; }
li:hover li a:hover { background: #95A9B1; }

 li > ul li > ul {left: 100%; top: 0; padding-left: 1px; }
li > ul li > ul li{ width: 130px;   }

    </style>
<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000" bgcolor="#ffffff">
<form id="form1" runat="server">

 
<font color="#990000" size="+3">User <asp:Label ID="volOrPart" runat="server" Text=""></asp:Label>  Area: Contact Administration</font></p>
<div id="Layer1" 
        
        
        
    style="position:absolute; left:62px; top:64px; width:371px; height:111px; z-index:6"> 
 Welcome :<asp:Label ID="usernameSession" runat="server" Text=""></asp:Label> 
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
    <asp:Button ID="logoutButton" runat="server" Text=" Logout "  CausesValidation="false"  
        onclick="logoutButton_Click" />

<ul>
           <li><a href="userHomeLogin.aspx">Home</a><ul><li><a href="userPasswordManagment.aspx">Change Password</a></li><li><a href="contactAdmin.aspx">Contact Admin</a></li><li><a href="userHelpDoc.aspx">Get Help</a></li></ul>
         
                   
 
             <%--  
                    <li><a href="adminConfig.aspx">Configure</a><ul><li><a href="Recover.aspx">Recover Users</a></ul></li>
                    <li><a href="#">Tools</a><ul>
                        <li><a href="addChangebanner.aspx">Add/Delete Banner</a></li><li><a href="addChangeWaiveraspx.aspx">
                            Add/Delete Waiver</a></li> <li><a href="trasnferOrg.aspx">Transfer Org. Or User</a></li> <li><a href="DropdownMods.aspx">DropdownList Mods</a></li><li><a href="activityLog.aspx">Activity Log</a></li><li><a href="Donwloads.aspx">Manage Downloads</a></li><li><a href="adminEmail.aspx">Email Settings</a></li></ul>
                    </li>
                </ul> --%>
            </li>
            <li><a href="#">View</a><ul><li><a href="userDetailsView.aspx">My Details</a></li></ul>
                <%--  <ul>
                    <li><a href="viewParadeInfo.aspx">View Organization Information</a></li>
                    <li><a href="adminArea.aspx">User Details</a></li>
                    <li><a href="paradeDetails.aspx">Parade Details</a></li><li><a href="floatDetails.aspx">Float Details</a></li>
                </ul> --%>
            </li>
            <li><a href="#">Edit</a><ul><li><a href="userDetailsEdit.aspx">Edit My Details</a></li></ul>
                <%--  <ul>
                    <li><a href="adminCreateUser.aspx">Create a User</a>
                        <ul>
                            <li><a href="addOrganization.aspx">Add Organization   </a><ul><li><a href="addFloat.aspx">Add Float</a></li></ul></li>
                        </ul>
                    </li>
                    <li><a href="editOrDeleteUser.aspx">Edit or Delete User</a></li>
                    <li><a href="editParadeInfo.aspx">Edit Organization Details</a></li><li><a href="editFloatDetailsaspx.aspx">Edit Float Details</a></li><li><a href="editParades.aspx">Edit Parade Details</a></li>
                </ul> --%>
            </li>
            
        </ul>

    </div>
    <br /><br /><br />
    <br />
    <br />
    <br /><h2>Use this form to contact Administration:</h2><br />
    <br /> &nbsp;<asp:Panel ID="Panel1" runat="server" Height="163px">

        &nbsp;&nbsp;
             
        
    </asp:Panel>

    <div style="position: absolute; left: 145px; top: 241px; z-index: 2; height: 327px;
        width: 889px;" id="Div1" runat="server">
     
        
        
        <asp:Label ID="fromLabelLbl" runat="server" Font-Bold="True" Text="From :"></asp:Label>
        <asp:Label ID="userName" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="toLabelLbl" runat="server" Font-Bold="True" Text="To :"></asp:Label>
        <asp:Label ID="admin" runat="server" Text="Administrator"></asp:Label>
     
        
        
        <br />
        <asp:Label ID="subjects" runat="server" Font-Bold="True" Text="Subject Name :"></asp:Label>
        <asp:TextBox ID="subjectTxt" runat="server" Width="217px"></asp:TextBox>
        <br />
        <asp:Label ID="messageDescLbl" runat="server" Font-Bold="True" Text="Description :"></asp:Label>
     
        
        
        <br />
        <asp:TextBox ID="messageDescTxt" runat="server" Height="174px" TextMode="MultiLine" 
            Width="750px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="submitMessage" runat="server" Text="Submit" 
            onclick="submitMessage_Click" />
     
        
        
    </div>
   
   
        </form >
</body>
</html>
