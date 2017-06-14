<%@ Page Language="C#" AutoEventWireup="true" CodeFile="VeiwsForToday.aspx.cs" Inherits="VeiwsForToday" %>

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
    <asp:Label ID="orgOrUSer" runat="server" Text=""></asp:Label></font></p>
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
    <br /><h2>This is the view for the <asp:Label ID="orgOrUser2" runat="server" Text=""></asp:Label> added today:</h2><br />
    <br /> &nbsp;<asp:Panel ID="Panel1" runat="server" Height="163px">

        &nbsp;&nbsp;
             
        
    </asp:Panel>
    <div style="border: 5px solid blue; position: absolute; left: 350px; top: 162px; z-index: 4; height: 77px;
        width: 741px; background-color: #FF6600;" id="spare" runat="server">
     
        
        
        
       
        Options: <br /><br />
     &nbsp;&nbsp;&nbsp;&nbsp;   <asp:RadioButton ID="deleteFloatTran" runat="server" 
            Text="   Delete floats when organization  is transferred." />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
    </div>

    <div style="position: absolute; left: 35px; top: 270px; z-index: 2; height: 280px;
        width: 370px;" id="userTable" runat="server">
     
        
        
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" 
            CellPadding="4" ForeColor="#333333" onrowcommand="GridView1_RowCommand" 
            Width="604px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="uID" HeaderText="ID" 
                    SortExpression="uID" />
                  

            </Columns>
            <Columns>
                <asp:BoundField DataField="uUsername" HeaderText="Username" 
                    SortExpression="uUsername" />
                  

            </Columns>
            <Columns>
                <asp:BoundField DataField="uFName" HeaderText="First Name" 
                    SortExpression="uFName" />
            </Columns>
            <Columns>
                <asp:BoundField DataField="uLName" HeaderText="Last Name" 
                    SortExpression="uLName" />
            </Columns>
            <Columns>
                <asp:BoundField DataField="uEmail" HeaderText="Email" 
                    SortExpression="uEmail" />
            </Columns>
            <Columns>
                <asp:BoundField DataField="uStatus" HeaderText="Status" 
                    SortExpression="uStatus" />
            </Columns>
             
                  <Columns>
            <asp:ButtonField ButtonType="Image" CommandName="searchUser" HeaderText="Search&nbsp;&nbsp;"
                ImageUrl="images/Search.png" Text="Search" />
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
            SelectCommand="SELECT oOrganization, oContact, oPhone, oEmail FROM orginfo"></asp:SqlDataSource>
     
        
        
    </div>


    <div  style="position: absolute; left: 31px; top: 273px; z-index: 2; height: 280px;
        width: 410px;" id="orgTable" runat="server">
     
        
        
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True"  onrowcommand="GridView1_RowCommand1" 
            CellPadding="4" ForeColor="#333333" Width="658px" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="pOrgID" HeaderText="Org ID" 
                    SortExpression="pOrgID" />
                  

            </Columns>
            <Columns>
                <asp:BoundField DataField="oOrganization" HeaderText="Organization Name" 
                    SortExpression="oOrganization" />
                  

            </Columns>
            <Columns>
                <asp:BoundField DataField="oContact" HeaderText="Contact" 
                    SortExpression="oContact" />
            </Columns>
            <Columns>
                <asp:BoundField DataField="oPhone" HeaderText="Phone #" 
                    SortExpression="oPhone" />
            </Columns>
            <Columns>
                <asp:BoundField DataField="oEmail" HeaderText="Email" 
                    SortExpression="oEmail" />
            </Columns>
            <Columns>
                <asp:BoundField DataField="oActivation" HeaderText="Status" 
                    SortExpression="oActivation" />
            </Columns>
             
                  <Columns>
            <asp:ButtonField ButtonType="Image" CommandName="searchOrg" HeaderText="Search&nbsp;&nbsp;"
                ImageUrl="images/Search.png" Text="Search" />
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
     
        
        
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
            ConnectionString="<%$ ConnectionStrings:pmsConnectionString1 %>" 
            ProviderName="<%$ ConnectionStrings:pmsConnectionString1.ProviderName %>" 
            SelectCommand="SELECT pOrgID, oOrganization, oContact, oPhone, oEmail,  FROM orginfo"></asp:SqlDataSource>
     
        
        
    </div>
   
   
        </form >
</body>
</html>
