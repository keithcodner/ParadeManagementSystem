<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Recover.aspx.cs" Inherits="Recover" %>

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

    </style>
<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000" bgcolor="#ffff99">
<form id="form1" runat="server">

 
<font color="#990000" size="+3">Administrator Area: 
    <asp:Label ID="orgOrUSer" runat="server" Text="Recover Users"></asp:Label></font></p>
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
    <br /><h2>You can recover user's that have been deleted : <asp:Label ID="orgOrUser2" runat="server" Text=""></asp:Label> </h2><br />
    <br /> &nbsp;<div style="position: absolute; left: 44px; top: 262px; z-index: 2; height: 175px;
        width: 1528px;" id="userDiv" runat="server">
     
        <b> User Information: 
        <asp:Button ID="removeAll" runat="server" Text="Remove All Users" 
            onclick="removeAll_Click" />
        <br />
        <br />
        <br />
      
        </b>
       *If you are unable to delete some users from the edit page, it's because the user ID already exists here. Clear the recovery table, so they can be deleted. If you wish to keep some users in the recovery table; recover them, clear the table then delete them again. Unfortunatley, it's 
        currently impossible to recover a user that already exists with the same user 
        ID. It is suggested you create a new user with the same credentials.<br /><br /><br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            AutoGenerateColumns="False" DataKeyNames="uID" 
            DataSourceID="SqlDataSource1" AllowPaging="True" 
            PageSize="8" Width="1605px" onrowcommand="GridView1_RowCommand" AllowSorting="True" 
            >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="uID" HeaderText="User ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="uID" />
                <asp:BoundField DataField="uUsername" HeaderText="Username" 
                    SortExpression="uUsername" />
                <asp:BoundField DataField="uPassword" HeaderText="Password(Encrypted)" 
                    SortExpression="uPassword" />
                <asp:BoundField DataField="uFName" HeaderText="First Name" 
                    SortExpression="uFName" />
                <asp:BoundField DataField="uLName" HeaderText="Last Name" 
                    SortExpression="uLName" />
                <asp:BoundField DataField="uHPhone" HeaderText="Home #" 
                    SortExpression="uHPhone" />
                <asp:BoundField DataField="uBPhone" HeaderText="Business #" 
                    SortExpression="uBPhone" />
                <asp:BoundField DataField="uCity" HeaderText="City" SortExpression="uCity" />
                <asp:BoundField DataField="uStreet" HeaderText="Street" 
                    SortExpression="uStreet" />
                <asp:BoundField DataField="uStatus" HeaderText="Status" 
                    SortExpression="uStatus" />
                <asp:BoundField DataField="uEmail" HeaderText="Email" 
                    SortExpression="uEmail" />
                <asp:BoundField DataField="uPostal" HeaderText="Postal" 
                    SortExpression="uPostal" />
                <asp:BoundField DataField="uProv" HeaderText="Province" 
                    SortExpression="uProv" />
                <asp:BoundField DataField="uDateJoined" HeaderText="Date Joined"  DataFormatString="{0:d}" HtmlEncode="false"  
                    SortExpression="uDateJoined" />
                <asp:BoundField DataField="uDateExpire" HeaderText="Date Expire" DataFormatString="{0:d}"  HtmlEncode="false" 
                    SortExpression="uDateExpire" />
                <asp:BoundField DataField="uActivation" HeaderText="Activated?" 
                    SortExpression="uActivation" />
            </Columns>
            <Columns>
            <asp:ButtonField ButtonType="Image" CommandName="RecoverUser" HeaderText="Recover&nbsp;&nbsp;"
                ImageUrl="images/Redo.png" Text="Search" />
</Columns>

            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
        
     
        
        
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:pmsConnectionString1 %>" 
            ProviderName="<%$ ConnectionStrings:pmsConnectionString1.ProviderName %>" 
            SelectCommand="SELECT uID, uUsername, uPassword, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM bckup_user">
        </asp:SqlDataSource>
        
     
        
        
    </div>
        </form >
</body>
</html>

