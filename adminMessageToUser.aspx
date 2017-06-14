<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminMessageToUser.aspx.cs" Inherits="adminMessageToUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server"><link rel="shortcut icon" href="images/santaIcon.ico" />
    <title>Administrator Area</title>
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
<body link="#006600" vlink="#990000" bgcolor="#ffff99">
<form id="form1" runat="server">

 
<font color="#990000" size="+3">Administrator Area: 
    <asp:Label ID="orgOrUSer" runat="server" Text="Reply To User Messages"></asp:Label></font></p>
<div id="Layer1" 
        
        
        
    
    style="position:absolute; left:63px; top:76px; width:583px; height:74px; z-index:6"> 
 Welcome :<asp:Label ID="usernameSession" runat="server" Text=""></asp:Label> 
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
    <asp:Button ID="logoutButton" runat="server" Text=" Logout "  CausesValidation="false"  
        onclick="logoutButton_Click" />

 <ul>
     <li><a href="adminHomeArea.aspx">Home</a>
             <ul>
            <li><a href="myAdmin.aspx">My Admin</a>
                <ul>
                
                </ul>
            </li>
            <li><a href="adminConfig.aspx">Configure</a><ul><li><a href="Recover.aspx">Recover Users</a></ul></li>
            <li><a href="#">Tools</a><ul><li><a href="addChangebanner.aspx">Add/Delete Banner</a></li><li><a href="addChangeWaiveraspx.aspx">Add/Delete Waiver</a></li><li><a href="trasnferOrg.aspx">Transfer Org. Or User</a></li> <li><a href="DropdownMods.aspx">DropdownList Mods</a></li><li><a href="activityLog.aspx">Activity Log</a></li><li><a href="Donwloads.aspx">Manage Downloads</a></li><li><a href="adminEmail.aspx">Email Settings</a></li></ul></li>
            </ul>
    </li>
    <li><a href="#">View</a>
             <ul>
            <li><a href="viewParadeInfo.aspx">View Organization Information</a></li>
            <li><a href="adminArea.aspx"> User Details</a></li>
            <li><a href="paradeDetails.aspx">Parade Details</a></li><li><a href="floatDetails.aspx">Float Details</a></li>
            </ul>
    </li>
  <li><a href="#">Edit</a>
             <ul>
            <li><a href="adminCreateUser.aspx">Create a User</a>
                  <ul>
                <li><a href="addOrganization.aspx">Add Organization   </a><ul><li><a href="addFloat.aspx">Add Float</a></li></ul></li>
                </ul>
            </li>
            <li><a href="editOrDeleteUser.aspx">Edit or Delete User</a></li>
            <li><a href="editParadeInfo.aspx">Edit Organization Details</a></li><li><a href="editFloatDetailsaspx.aspx">Edit Float Details</a></li><li><a href="editParades.aspx">Edit Parade Details</a></li>
            </ul>
    </li>
    <li><a href="#">Reports</a>
             <ul>
            <li><a href="#">List's</a><ul><li><a href="#">Attendance</a><ul><li><a href="reportGen.aspx">Org. Attendance List</a><ul><li><a href="VolAttendanceList.aspx">Vol. Attendance List</a></li></ul></li></ul></li><li><a href="#">Float's</a><ul><li><a href="ApprovedFloats.aspx">Approved Floats</a></li></ul></li></ul></li><li><a href="#">Statistics</a> <ul><li><a href="statReport.aspx">Stat Report</a></li></ul></li> 
            
            </ul>
    </li>
 </ul>

    </div>
    <br /><br /><br />
    <br />
    <br />
    <br /><h2>Message To User:
    
 
    
 </h2> <asp:Label ID="error" runat="server" ForeColor="#33CC33"></asp:Label> <br />
    <br /> &nbsp;<div style="position: absolute; left: 73px; top: 273px; z-index: 2; height: 515px;
        width: 957px;" id="userTable" runat="server">
     
        
        
        <table class="style1" style="border: thin solid #000000;">
            <tr>
                <td class="style2">
       
        
        
        <asp:Label ID="fromLabelLbl" runat="server" Font-Bold="True" Text="From :"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="admin" runat="server" Text="Administrator"></asp:Label>
     
        
        
                </td>
            </tr>
            <tr>
                <td class="style2">
        <asp:Label ID="toLabelLbl" runat="server" Font-Bold="True" Text="To :"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="getEmail" runat="server" Height="20px" Width="310px" 
                        DataSourceID="SqlDataSource1" DataTextField="uEmail" DataValueField="uID" 
                        AutoPostBack="True" AppendDataBoundItems="True">
                        <asp:ListItem Value="0">-Select a User Email-</asp:ListItem>
                        <asp:ListItem Value="one">All(All users in System)</asp:ListItem>
                        <asp:ListItem Value="two">All(Volunteers)</asp:ListItem>
                        <asp:ListItem Value="three">All(Participant)</asp:ListItem>
                        <asp:ListItem Value="four">All(Admin)</asp:ListItem>
                    </asp:DropDownList>
     
        
        
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                        SelectCommand="Select uID, uEmail FROM user "></asp:SqlDataSource>
     
        
        
                    <asp:Label ID="getFirstName" runat="server" Text=""></asp:Label>
                    <asp:Label ID="getLastName" runat="server" Text=""></asp:Label>
     
        
        
                    <asp:Label ID="getUserNames" runat="server" Text=""></asp:Label>
     
        
        
                </td>
            </tr>
            <tr>
                <td class="style2">
        <asp:Label ID="subjects" runat="server" Font-Bold="True" Text="Subject Name :"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="subjectTxt" runat="server" Width="308px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
        <asp:Label ID="messageDescLbl" runat="server" Font-Bold="True" Text="Description :"></asp:Label>
     
        
        
                </td>
                <td class="style4">
        <asp:TextBox ID="messageDescTxt" runat="server" Height="174px" TextMode="MultiLine" 
            Width="750px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td>
        <asp:Button ID="submitMessage" runat="server" Text="Submit" onclick="submitMessage_Click" 
            />
     
        
        
                 </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        &nbsp;<br />
     
        
        
        <br />
        <br />
     
        
        
        <br />
        <br />
        <br />
     
        
        
    <br />
    <br />
        <asp:Label ID="test" runat="server" Text=""></asp:Label>
    <br />
     
        
      
    <br />
     
        
    </div>


        </form >
</body>
</html>



