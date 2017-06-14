<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addChangeWaiveraspx.aspx.cs" Inherits="addChangeWaiveraspx"  validateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
<body link="Silver" vlink="#990000" bgcolor="#ffff99">
    <form id="form1" runat="server">
    <font color="#990000" size="+3">Administrator Area: Add/Delete Waivers</font></p>
    <div id="Layer1" style="position: absolute; left: 62px; top: 64px; width: 397px;
        height: 111px; z-index: 1">
        Welcome :<asp:Label ID="usernameSession" runat="server" Text=""></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="logoutButton" runat="server" Text=" Logout "  CausesValidation="false"  OnClick="logoutButton_Click" />
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
                    <li><a href="adminArea.aspx">User Details</a></li>
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
    <div style="position: absolute; left: 4px; top: 202px; w z-index: 1; height: 520px;
        width: 1062px;">
        <b>Add a Waiver:</b>
        <asp:Label ID="checkIfNameExists" runat="server" Text="" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
                    Waiver Name:</td>
                <td>
                    <asp:TextBox ID="waiverEditTitle" runat="server" Width="265px"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style2">
                    Waiver Type:</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" 
                         DataTextField="wName" enabled = "false" 
                        Width="183px">
                        <asp:ListItem Value="0">--Select A Waiver Type--</asp:ListItem>
                        <asp:ListItem Value="Waiver">Waiver</asp:ListItem>
                        <asp:ListItem Value="About">About</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Body:</td>
                <td>
                <asp:TextBox ID="waiverEditBody" runat="server" TextMode="MultiLine" Height="222px" 
                        Width="672px"></asp:TextBox>
                    &nbsp;</td>
            </tr>
           
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Button ID="BannerBtn" runat="server" Text="Submit" onclick="BannerBtn_Click1" 
                         />
                </td>
                <td> 
                    <asp:Button ID="applyUpdate" runat="server" Text="Apply" onclick="applyUpdate_Click"  
                         />
                    &nbsp;</td>
            </tr>
        </table>
        <br /><hr><hr><br />
        <b>Edit/Delete existing Waiver Submissions:</b><br />
        
        <br />
       
      
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataKeyNames="waiverID" DataSourceID="SqlDataSource1" AllowPaging="True" 
            AllowSorting="True" CellPadding="4" ForeColor="#333333" 
            Width="1381px" onrowcommand="GridView1_RowCommand" BorderColor="Black" 
            BorderStyle="Solid" BorderWidth="1px">
            <AlternatingRowStyle  backcolor="White" />

            <Columns>
                <asp:BoundField DataField="waiverID" HeaderText="ID&nbsp;&nbsp;&nbsp;&nbsp;" InsertVisible="False" 
                    ReadOnly="True" SortExpression="waiverID" />
                    <asp:BoundField DataField="wType" HeaderText="Waiver Type" 
                    SortExpression="wType" />
                <asp:BoundField DataField="wName" HeaderText="Waiver Title" 
                    SortExpression="wName" />
                    <asp:BoundField DataField="wWaiver" HeaderText="Waiver Description" 
                    SortExpression="wWaiver" />
                    <asp:ButtonField ButtonType="Image" ImageUrl="images/edit_button25.png" CommandName="UpdateWaiver"
                HeaderText="Modify&nbsp;&nbsp;" Text="Modify" />
            
            <asp:ButtonField ButtonType="Image" CommandName="DeleteWaiver" HeaderText="Delete&nbsp;&nbsp;"
                ImageUrl="images/delete_button25.png" Text="Delete" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
            
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
            SelectCommand="SELECT waiverID, wType, wName, wWaiver FROM waiver;">
        </asp:SqlDataSource>
        <br />
       
      
        
    </div>
    </form>
</body>
</html>