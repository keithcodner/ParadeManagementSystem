<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editParades.aspx.cs" Inherits="editParades" %>

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
<body link="#006600" vlink="#990000" bgcolor="#ffff99">
    <form id="form1" defaultbutton="searchBtn"  runat="server">
    <font color="#990000" size="+3">Administrator Area: Edit Parade Details</font></p>
    <div id="Layer1" style="position: absolute; left: 62px; top: 64px; width: 371px;
        height: 111px; z-index: 2">
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
    <asp:Panel ID="advSearchPanel" runat="server" Style="border-style: groove; position: absolute;
        left: 522px; top: 220px; width: 282px; height: 173px; z-index: 3" 
        Visible="False" DefaultButton="searchBtn" >
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp; Advanced Search Options:<br />
        <br />
        &nbsp;&nbsp;
        <asp:RadioButton ID="cParadeName" runat="server" Text=" Parade Name" Visible="true"
            GroupName="a" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="cParadeYear" runat="server" Text=" Parade Year" Visible="true" GroupName="a" />
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:RadioButton ID="cParadeType" runat="server" Text=" Parade Type" Visible="true" GroupName="a" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="cParadeDate" runat="server" Text=" Parade Date" Visible="true" GroupName="a" />
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:RadioButton ID="cParadeStartTime" runat="server" Text=" Start Time" Visible="true" GroupName="a" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="cParadeEndTime" runat="server" Text=" End Time" Visible="true" GroupName="a" /><br />
    </asp:Panel>
    &nbsp;
    <div id="Layer1" style="position: absolute; left: 10px; top: 160px; width: 1064px;
        height: 256px; z-index: 1">
        <asp:Panel ID="Panel1" runat="server" Height="271px" ForeColor="Black">
            Edit items here: <br /> 
            <asp:Label ID="Label1" runat="server" 
                Text="*Before deleting a parade it is recommended to be used as a last resort and that *Organizations* and *Users* you do not wish to delete be transfered to another parade.*" 
                ForeColor="Red"></asp:Label><br />
                  <asp:Label ID="Label2" runat="server" 
                Text="*This is located at Home > Tools > Transfer Org or Users*" 
                ForeColor="Red"></asp:Label><br /><br />
            <br />
            <table class="style1">
                <tr>
                    <td class="style4">
                        Parade Name:
                    </td>
                    <td>
                        <asp:TextBox ID="paradeName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Parade Year:
                    </td>
                    <td>
                        <asp:TextBox ID="paradeYear" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Parade Type:
                    </td>
                    <td>
                        <asp:TextBox ID="paradeType" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Parade Date:
                    </td>
                    <td>
                        <asp:TextBox ID="paradeDate" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Start Time:
                    </td>
                    <td>
                        <asp:TextBox ID="paradeStartTime" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        End Time:
                    </td>
                    <td>
                        <asp:TextBox ID="paradeEndTime" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Button ID="Button2" runat="server" Text="  Apply  " 
                            onclick="Button2_Click" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
             
                <tr>
                    <td class="style4">
                       
                        Current Parade :<br />
                    </td>
                    <td>
                    <asp:Label ID="currentParade" runat="server" Text=""></asp:Label>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <asp:Panel ID="Panel2" runat="server" Height="271px">
        <font color="#FFFFFF">......</font>
    </asp:Panel>
    <p>
        &nbsp;</p>
    <br />
    <br />
    <br />
    <br />
    <br />
    <font color="#FFFFFF">........<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
    </font>
    <br />
    All Parade Organization Information:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Search by
    <asp:Label ID="searchLbl" runat="server" Text="Name"></asp:Label>
    :&nbsp;
    <asp:TextBox ID="searchTxt" runat="server" 
        ></asp:TextBox>
    <asp:Button ID="searchBtn" runat="server" Text="Search" 
        onclick="searchBtn_Click"  />
    &nbsp;<asp:Button ID="advSearch" runat="server" Text="Advanced Search" OnClick="advSearch_Click" />

     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Export Table:<asp:ImageButton 
        ID="ImageButton1" runat="server" ImageUrl="~/images/Download.png" 
        onclick="ImageButton1_Click" />

    <br />
    &nbsp;<asp:SqlDataSource ID="editTable" runat="server" ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>"
        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" SelectCommand="SELECT pOrgID, oOrganization,   oCountry, oProvince, oCity, oContact, oPhone, oWebsite, oEmail,  oAddress1, oSeminarAtt, oDateJoined, oDateExpire,  oActivation FROM orginfo">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="searchedTable" runat="server" ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>"
        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" SelectCommand="">
        <SelectParameters>
            <asp:ControlParameter ControlID="searchTxt" Name="uFName" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="editTables" ForeColor="#333333" OnRowCommand="GridView1_RowCommand"
        DataKeyNames="paradeID"
        
        AllowPaging="True" AllowSorting="True">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="paradeID" HeaderText="Parade ID" 
                SortExpression="paradeID" InsertVisible="False"
                ReadOnly="True" />
            <asp:BoundField DataField="paradeName" HeaderText="Parade Name" 
                SortExpression="paradeName" />
            <asp:BoundField DataField="paradeYear" HeaderText="Parade Year" 
                SortExpression="paradeYear" />
            <asp:BoundField DataField="paradeType" HeaderText="Parade Type" 
                SortExpression="paradeType" />
            <asp:BoundField DataField="paradeDate" HeaderText="Parade Date" 
                SortExpression="paradeDate" />
            <asp:BoundField DataField="paradeStartTime" HeaderText="Parade Start Time" 
                SortExpression="paradeStartTime" />
            <asp:BoundField DataField="paradeEndTime" HeaderText="Parade End Time" 
                SortExpression="paradeEndTime" />
                <asp:ButtonField ButtonType="Image" ImageUrl="images/edit_button25.png" CommandName="UpdateParade"
                HeaderText="Modify&nbsp;&nbsp;" Text="Modify" />
           
            <asp:ButtonField ButtonType="Image" CommandName="makeCurrent" HeaderText="Make Current&nbsp;&nbsp;"
                ImageUrl="images/yellow_star.png" Text="Make Current" />
            <asp:ButtonField ButtonType="Image" CommandName="DeleteParade" HeaderText="Delete&nbsp;&nbsp;"
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
    <asp:SqlDataSource ID="editTables" runat="server" ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>"
        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
        SelectCommand="SELECT paradeID, paradeName, paradeYear, paradeType, paradeDate, paradeStartTime, paradeEndTime FROM parade">
    </asp:SqlDataSource>

    <div style="position: absolute; left: 792px; top: 246px;  z-index: 5; height: 243px; width: 339px;">
                 <asp:Panel ID="confirmPanel" runat="server" Height="226px" Width="303px" 
                     BackColor="#33CC33" BorderColor="#009900" Visible="False" 
                     BorderWidth="4px">
                     <br/><br/><br/><br/><br/><br/><br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:CheckBox ID="disableConfirm" runat="server" 
                         Text=" Click to Disable Confirmations" Visible="False" />
                     <br/>
                     &nbsp;&nbsp;&nbsp;
                  <div style="position: absolute; left: 20px; top: 27px; w z-index: 6; height: 31px; width: 259px; ">  <p> &nbsp;&nbsp;&nbsp; <asp:Label ID="AlertLbl" runat="server" Text=""></asp:Label></p></div>
                 <br/>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="ConfirmBtn" runat="server" Text="Confirm" 
                         onclick="ConfirmBtn_Click" Height="33px" Width="97px" />
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="CanelBtn" runat="server" Text="Cancel" 
                         onclick="CanelBtn_Click" Height="34px" Width="89px" />
                 </asp:Panel>
        </div>
    </form>
</body>
</html>
