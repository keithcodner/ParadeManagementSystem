<%@ Page Language="C#" AutoEventWireup="true" CodeFile="activityLog.aspx.cs" Inherits="activityLog" %>

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

        <script type="text/javascript" src="js\jquery.min.js"></script>
        <script type="text/javascript" src="js\scrolltopcontrol.js"></script>
<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000" bgcolor="#ffff99">
<form id="form1" runat="server">

 
<font color="#990000" size="+3">Administrator Area: Activity Log</font>
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
    <br /><h2>Modify Activity Log (Edit and Delete for Super Administrator only) :</h2><br /><br />

    <br /> &nbsp;<a name="gettingStarted"></a></a><div style="position: absolute; left: 34px; top: 355px; z-index: 2; height: 636px;
        width: 1431px;" id="Div3" runat="server">
     <h3><u>Activity Logs:</u></h3>&nbsp;&nbsp; <br />
     Entry Type Dropdown List:<asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
&nbsp;<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
         CellPadding="4" DataKeyNames="ALID" DataSourceID="SqlDataSource2" 
         ForeColor="#333333" AllowPaging="True" AllowSorting="True" 
         onrowcommand="GridView1_RowCommand" Width="1532px" PageSize="19" 
         Height="495px">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="ALID" HeaderText="ID" 
                 InsertVisible="False" ReadOnly="True" SortExpression="ALID" />
             <asp:BoundField DataField="aLDate" HeaderText="Log Date" DataFormatString="{0:d}"
                 SortExpression="aLDate" />
                 <asp:BoundField DataField="aLTime" HeaderText="Log Time" 
                 SortExpression="aLTime" />
             <asp:BoundField DataField="aLUser" HeaderText="User" 
                 SortExpression="aLUser" />
             <asp:BoundField DataField="aLDesc" HeaderText="Log Description" 
                 SortExpression="aLDesc" />
                  <asp:ButtonField ButtonType="Image" ImageUrl="images/edit_button25.png" CommandName="UpdateLog"
                HeaderText="Modify&nbsp;&nbsp;" Text="Modify" />
                <asp:ButtonField ButtonType="Image" CommandName="DeleteLog" HeaderText="Delete&nbsp;&nbsp;"
                ImageUrl="images/delete_button25.png" Text="Delete" />
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
     
     
        
        
    </div>

    <div style="position: absolute; left: 751px; top: 220px; z-index: 5; height: 71px;
        width: 549px;" id="advSearchOptions" runat="server">
        <b>Advanced Search:</b>(Search by Date format must be YYYY-MM-DD :) <br />
        <asp:RadioButton ID="rbDate" runat="server" Text="Log Date" GroupName="log" />&nbsp;&nbsp; <asp:RadioButton ID="rbDesc" runat="server" Text="Log Description" GroupName="log" />
        <br />
        <asp:RadioButton ID="rbTime" runat="server" Text="Log Time" GroupName="log" /> &nbsp; 
        <asp:RadioButton ID="rbUser" runat="server" Text="User" GroupName="log" />
        
        
        &nbsp; <asp:RadioButton ID="rbExcludeErrors" runat="server" 
            Text="Exclude Errors" AutoPostBack="True" 
            oncheckedchanged="rbExcludeErrors_CheckedChanged" />
        
        
        <asp:Button ID="excludeReset" runat="server" Text="Reset Exclude" 
            onclick="excludeReset_Click" />
        
        
        </div>

        <div style="position: absolute; left: 541px; top: 363px; z-index: 2; height: 43px;
        width: 605px;" id="advSearch" runat="server">
        
            Search by Username:<asp:TextBox ID="searchTxt" runat="server"></asp:TextBox>
            <asp:Button ID="search" runat="server" Text="Search" onclick="search_Click" />
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Export Table:<asp:ImageButton 
        ID="ImageButton1" runat="server" ImageUrl="~/images/Download.png" 
        onclick="ImageButton1_Click" />

        
        </div>

    <div style="position: absolute; left: 53px; top: 182px; z-index: 2; height: 159px;
        width: 1146px;" id="Div2" runat="server">
     
    <asp:Label ID="username" runat="server" Text="Username"></asp:Label> :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
        <br />
      <asp:Label ID="log" runat="server" Text="Log Description"></asp:Label> :<asp:TextBox 
            ID="txtLogDesc" runat="server" Height="89px" TextMode="MultiLine" Width="502px"></asp:TextBox>
     <br /><br />
     <asp:Button ID="logApplyBtn" runat="server" Text="Apply" Enabled="False" onclick="logApplyBtn_Click" 
          />
        <asp:Button ID="cancel" runat="server" Text="Cancel" Enabled = "False" 
            onclick="cancel_Click"/>
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
         ConnectionString="<%$ ConnectionStrings:pmsConnectionString1 %>" 
         ProviderName="<%$ ConnectionStrings:pmsConnectionString1.ProviderName %>" 
         SelectCommand="SELECT ALID, aLDate, aLTime, aLUser, aLDesc FROM activityLog ORDER BY ALID DESC"></asp:SqlDataSource>

     
        
        
    </div>
   
   
        </form >
</body>
</html>