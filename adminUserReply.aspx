<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminUserReply.aspx.cs" Inherits="adminUserReply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

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

       .style1
       {
           width: 730px;
       }
       .style2
       {
           width: 155px;
       }
       .style3
       {
           width: 156px;
       }
       .style4
       {
           width: 160px;
       }
       .style5
       {
           width: 87px;
       }
       .style7
       {
           width: 276px;
       }

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
    <br /><h2>Reply Message:
    
 
    
 </h2> <asp:Label ID="error" runat="server" ForeColor="#33CC33"></asp:Label> <br />
    <br /> &nbsp;<div style="position: absolute; left: 73px; top: 273px; z-index: 2; height: 515px;
        width: 957px;" id="userTable" runat="server">
     
        
        
        <table class="style1" style="border: thin solid #000000;">
            <tr>
                <td class="style2">
       
        
        
        <asp:Label ID="fromLabelLbl" runat="server" Font-Bold="True" Text="From:"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="admin" runat="server" Text="Administrator"></asp:Label>
     
        
        
                </td>
            </tr>
            <tr>
                <td class="style2">
        <asp:Label ID="toLabelLbl" runat="server" Font-Bold="True" Text="To:"></asp:Label>
                </td>
                <td>
        <asp:Label ID="userName" runat="server" Text=""></asp:Label>
     
        
        
                </td>
            </tr>
            <tr>
                <td class="style2">
        <asp:Label ID="subjects" runat="server" Font-Bold="True" Text="Subject Name:"></asp:Label>
                </td>
                <td>
        <asp:TextBox ID="subjectTxt" runat="server" Width="217px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
        <asp:Label ID="messageDescLbl" runat="server" Font-Bold="True" Text="Description:"></asp:Label>
     
        
        
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
    <br />
     
        
      
    <br />
     
        
    </div>


    <div  style="position: absolute; left: 152px; top: 560px; z-index: 2; height: 428px;
        width: 817px;" id="orgTable" runat="server">
     
          <p>
          <br />
    <asp:Label ID="usernameLbl0" runat="server" Text="User Message:" Font-Bold="True"></asp:Label> 
     
        </p>
        <div  style="position: absolute; left: 62px; top: 65px; z-index: 2; height: 379px;
        width: 716px;" id="Div1" runat="server">
          <p>
              <br />
     
          <table class="style1" style="border: thin solid #000000; height: 254px;">
            <tr>
                <td class="style5">
    <asp:Label ID="usernameLbl" runat="server" Text="User Name: " Font-Bold="True"></asp:Label> </td>
                <td class="style7">
              <asp:Label ID="messageUserName" runat="server" Text=""></asp:Label>  </td>
                
            </tr>
            <tr>
                <td class="style5">
    <asp:Label ID="userMsgDate" runat="server" Text="Message Date: " 
        Font-Bold="True"></asp:Label> </td>
                <td class="style7">
                    <asp:Label ID="messageDate" runat="server" Text=""></asp:Label> </td>
                
            </tr>
            <tr>
                <td class="style5">
    <asp:Label ID="userMsgName" runat="server" Text="Message Subject: " 
        Font-Bold="True"></asp:Label> </td>
                <td class="style7">
                    <asp:Label ID="messageName" runat="server" Text=""></asp:Label>  </td>
             
            </tr>
            <tr>
                <td class="style5">
    <asp:Label ID="userMsgDesc" runat="server" Text="Message Description: " 
        Font-Bold="True"></asp:Label> </td>
                <td class="style7">
                    <asp:Label ID="messageDesc" runat="server" Text=""></asp:Label> </td>
               
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                
            </tr>
            <tr>
                <td class="style5">
                    &nbsp;</td>
                <td class="style7">
                    &nbsp;</td>
                
            </tr>
            <tr>
                <td class="style5">
                    </td>
                <td class="style7">
                    </td>
             
            </tr>
        </table>
       
        
        
            </p>
        </div>
    </div>
   
   
        </form >
</body>
</html>


