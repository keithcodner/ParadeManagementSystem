<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trasnferOrg.aspx.cs" Inherits="trasnferOrg" %>

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
           width: 324px;
       }
       .style2
       {
           width: 270px;
       }
       .style3
       {
           width: 360px;
       }
       .style4
       {
           width: 238px;
       }

       .style5
       {
           width: 215px;
       }
       .style6
       {
           width: 164px;
       }

    </style>
<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000" bgcolor="#ffff99">
<form id="form1" runat="server">

 
<font color="#990000" size="+3">Administrator Area: Transfer Organization or User</font></p>
<div id="Layer1" 
        
        
        
    style="position:absolute; left:62px; top:64px; width:371px; height:111px; z-index:6"> 
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
    <br /><b>Transfer an Organization to another Parade  :</b><br />
    <br /> The Current Parade is: 
    <asp:Label ID="currentParade" runat="server" Text=""></asp:Label>
    <asp:Label ID="test" runat="server"></asp:Label>
    <asp:Panel ID="Panel1" runat="server" Height="163px">

        &nbsp;&nbsp;
             
        
    </asp:Panel>
    <div style="border: 5px solid blue; position: absolute; left: 253px; top: 237px; z-index: 4; height: 128px;
        width: 741px; background-color: #FF6600;" id="spare" runat="server">
     
        
        
        
       
        Options: 
        <asp:Button ID="resetDeleteFloat" runat="server" Text="Reset" 
            onclick="resetDeleteFloat_Click" />
        <br />
     &nbsp;&nbsp;&nbsp;&nbsp;   <asp:RadioButton ID="deleteFloatTran" runat="server" 
            Text="Delete floats when organization  is transferred.(Option only applies when Org. is transferred. Admin should be prepared to create blank/specified floats for these Organizations. )" />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
       
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton ID="groupTrasnfer" 
            runat="server" 
            Text="Group Trasnfer (User, Org. and Float. Opntions and Sub Option only applies when Org. User is transferred.)" 
            AutoPostBack="True" Visible="False" />
        <br />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton 
            ID="gtExcludeFloat" runat="server" Text="Exclude Float from Transfer(Floats will be deleted.)" 
            GroupName="a" Visible="False" />
            <br />
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:RadioButton 
            ID="gtExcludeOrg" runat="server" 
            Text="Exclude Organization from Transfer. (Org and Float will be deleted.)" 
            GroupName="a" Visible="False" />
                                                                          <asp:Button 
            ID="gtOptionSave" runat="server" Text=" Save Options " 
            onclick="gtOptionSave_Click" />
    </div>

    
    <div style="position: absolute; left: 26px; top: 475px; z-index: 2; height: 88px;
        width: 965px; margin-top: 0px;" id="Div2" runat="server">
     
        
        
        
        <table border="1" style="border: 5px solid green; width: 1280px;" class="style1" 
            bgcolor="#999999">

         <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                    <td class="style6">
                        &nbsp;</td>
            </tr>
        <tr>
                <td class="style3">
                    1 . Pick the Current Parade:</td>
                <td class="style4">
                    <asp:DropDownList ID="pickCurrentParade" runat="server" Height="20px" 
                        Width="200px" DataSourceID="SqlDataSource1" DataTextField="paradeName" 
                        DataValueField="paradeID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                        SelectCommand="SELECT paradeID, paradeName FROM parade;">
                    </asp:SqlDataSource>
                </td>
                <td class="style2">
                    <asp:Button ID="makeCurrentParadeBtn" runat="server" 
                        Text="  Make Parade Current  " onclick="makeCurrentParadeBtn_Click" 
                        />
                </td>
                <td class="style5">
                    &nbsp;</td>
                    <td class="style6">
                        &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    &nbsp;</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                    <td class="style6">
                        &nbsp;</td>
            </tr>
            <tr>
                <td class="style3">
                    2.
                    Pick an Organization from the Current Parade :</td>
                <td class="style4">
                    <asp:DropDownList ID="tOrganization" runat="server" Height="20px" Width="200px" 
                        DataSourceID="SqlDataSource2" DataTextField="oorganization" 
                        DataValueField="porgid">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                        SelectCommand="SELECT porgid, oorganization FROM orginfo">
                    </asp:SqlDataSource>
                </td>
                <td class="style2">
                    &nbsp;Pick a Parade to transfer an Organization to:</td>
                <td class="style5">
                    <asp:DropDownList ID="tParade" runat="server" Height="20px" Width="200px" 
                        DataSourceID="SqlDataSource3" DataTextField="paradeName" 
                        DataValueField="paradeID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                        SelectCommand="SELECT paradeID, paradeName FROM parade"></asp:SqlDataSource>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td class="style6">
                    &nbsp;
                    
                                        <asp:Button ID="Button2" runat="server" Text="  Transfer!  " 
                        onclick="trasnfer_Click" />
                
                    </td>
            </tr>
            <tr>
                <td class="style3">
                    OR</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                    <td class="style6">
                        &nbsp;</td>
            </tr>
             <tr>
                <td class="style3">
                    3.
                    Pick a Participant User from the Current Parade :</td>
                <td class="style4">
                    <asp:DropDownList ID="tUser" runat="server" Height="20px" Width="200px" 
                        DataSourceID="SqlDataSource5" DataTextField="uusername" 
                        DataValueField="uid">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource5" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                        SelectCommand="SELECT uid, uusername FROM user  WHERE uStatus = 'Participant'">
                    </asp:SqlDataSource>
                </td>
                <td class="style2">
                    &nbsp;Pick a Parade to transfer a Participant
                    User to:</td>
                <td class="style5">
                    <asp:DropDownList ID="tUserParade" runat="server" Height="20px" Width="200px" 
                        DataSourceID="SqlDataSource6" DataTextField="paradeName" 
                        DataValueField="paradeID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource6" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                        SelectCommand="SELECT paradeID, paradeName FROM parade"></asp:SqlDataSource>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                <td class="style6">
                    &nbsp;                     <asp:Button ID="UserTrasnfer" runat="server" Text="  Transfer!  " onclick="UserTrasnfer_Click" 
                         />
                </td>
            </tr>
               <tr>
                <td class="style3">
                    OR</td>
                <td class="style4">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style5">
                    &nbsp;</td>
                    <td class="style6">
                        &nbsp;</td>
            </tr>
             <tr>
                <td class="style3">
                    4.
                    Pick a Volunteer User from the Current Parade :</td>
                <td class="style4">
                    <asp:DropDownList ID="tVolUser" runat="server" Height="20px" Width="200px" 
                        DataSourceID="SqlDataSource4" DataTextField="uusername" 
                        DataValueField="uid">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                        
                        SelectCommand="SELECT uid, uusername FROM user WHERE uStatus = 'Volunteer'">
                    </asp:SqlDataSource>
                </td>
                <td class="style2">
                    &nbsp;Pick a Parade to transfer a
                    Volunteer User to:</td>
                <td class="style5">
                    <asp:DropDownList ID="tVolParade" runat="server" Height="20px" Width="200px" 
                        DataSourceID="SqlDataSource7" DataTextField="paradeName" 
                        DataValueField="paradeID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource7" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                        SelectCommand="SELECT paradeID, paradeName FROM parade"></asp:SqlDataSource>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                </td>
                <td class="style6">
                    &nbsp;
                    <asp:Button ID="tVolBtn" runat="server" Text="  Transfer!  " onclick="tVolBtn_Click"
                         />
                    </td>
            </tr>
        </table>
    </div>
   
   
        </form >
</body>
</html>

