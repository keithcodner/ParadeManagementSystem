<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editOrDeleteUser.aspx.cs"
    Inherits="editOrDeleteUser" %>

<%@ Import Namespace="System" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><link rel="shortcut icon" href="images/santaIcon.ico" />
    <title>Administrator Area</title>
    
    
    <style type="text/css"> 
        *{padding:0; margin:0;}
        body{padding:5px; font-family:Helvetica, Arial, Sans-Serif; color:Black;} *{padding:0; margin:0;}
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
<body  bgcolor="#ffff99">
    <form id="form1" defaultbutton="searchBtn" runat="server">
    <font color="#990000" size="+3">Administrator Area: Edit or Delete User</font><p></p>
    <div id="Layer11" style="position: absolute; left: 47px; top: 87px; width: 371px;
        height: 45px; z-index: 2">
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
                    <li><a href="adminConfig.aspx">Configure</a><ul><li><a href="Recover.aspx">Recover Users</a></li></ul></li>
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
        left: 512px; top: 185px; width: 293px; height: 203px; z-index: 4" 
        Visible="False" DefaultButton="searchBtn">
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp; Advanced Search Options:<br />
        <br />
        &nbsp;&nbsp;
        <asp:RadioButton ID="cbFName" runat="server" Text=" First Name" Visible="False" GroupName="a" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="cbLName" runat="server" Text=" Last Name" Visible="False" GroupName="a" />
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:RadioButton ID="cbStreet" runat="server" Text=" Street" Visible="False" GroupName="a" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="cbCity" runat="server" Text=" City" Visible="False" GroupName="a" />
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:RadioButton ID="cbProv" runat="server" Text=" Province" Visible="False" GroupName="a" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="cbPostal" runat="server" Text=" Postal/Zip Code" Visible="False"
            GroupName="a" />
        <br />
        <br />
        &nbsp;&nbsp;
        <asp:RadioButton ID="cbEmail" runat="server" Text=" Email" Visible="False" GroupName="a" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="cbStatus" runat="server" Text=" Status" Visible="False" GroupName="a" /><br />
    </asp:Panel>
    &nbsp;
    <div id="Layer12" style="position: absolute; left: 10px; top: 160px; width: 1064px;
        height: 256px; z-index: 1">
        <asp:Panel ID="Panel1" runat="server" Height="271px">
            Edit items here:<br />
            
            <asp:Label ID="checkIfOrgExists" runat="server" Text="" ForeColor="Red" 
                Visible="true"></asp:Label>
            <br />
            <asp:Label ID="checkIfUserExists" runat="server" Text="" ForeColor="Red" 
                Visible="true"></asp:Label>
            
            <br />
            <asp:Label ID="checkIfEmailExists" runat="server" Text="" ForeColor="Red" 
                Visible="true"></asp:Label>
            <br />
            <table class="style1">
            <tr>
                    <td class="style4">
                        Organization:
                    </td>
                    <td>
                        <asp:TextBox ID="eeOrganization" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        User Name:
                    </td>
                    <td>
                        <asp:TextBox ID="eeUsername" runat="server"></asp:TextBox>
                    </td>
                </tr>
                
                <tr>
                    <td class="style4">
                        First Name :
                    </td>
                    <td>
                        <asp:TextBox ID="eeFName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Last Name :
                    </td>
                    <td>
                        <asp:TextBox ID="eeLName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Home Phone #:
                    </td>
                    <td>
                        <asp:TextBox ID="eeHNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Business #:
                    </td>
                    <td>
                        <asp:TextBox ID="eeBNo" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Street :
                    </td>
                    <td>
                        <asp:TextBox ID="eeStreet" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        City:
                    </td>
                    <td>
                        <asp:TextBox ID="eeCity" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Province :
                    </td>
                    <td>
                        <asp:DropDownList ID="eeProv" runat="server" Height="20px" Width="158px">
                            <asp:ListItem Value="">-Select Province-</asp:ListItem>
                            <asp:ListItem Value="Alberta">Alberta</asp:ListItem>
                            <asp:ListItem Value="British Columbia">British Columbia</asp:ListItem>
                            <asp:ListItem Value="Ontario">Ontario</asp:ListItem>
                            <asp:ListItem Value="Prince Edward Island">Prince Edward Island</asp:ListItem>
                            <asp:ListItem Value="Manitoba">Manitoba</asp:ListItem>
                            <asp:ListItem Value="New Brunswick">New Brunswick</asp:ListItem>
                            <asp:ListItem Value="Nova Scotia">Nova Scotia</asp:ListItem>
                            <asp:ListItem Value="Saskatchewan">Saskatchewan</asp:ListItem>
                            <asp:ListItem Value="Newfoundland and Labrador">Newfoundland and Labrador</asp:ListItem>
                            <asp:ListItem Value="Northwest Territories">Northwest Territories</asp:ListItem>
                            <asp:ListItem Value="Nunavut">Nunavut</asp:ListItem>
                            <asp:ListItem Value="Quebec">Quebec</asp:ListItem>
                            <asp:ListItem Value="Yukon">Yukon</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Postal Code:
                    </td>
                    <td>
                        <asp:TextBox ID="eePost" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Email:
                    </td>
                    <td>
                        <asp:TextBox ID="eeEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Status:
                    </td>
                    <td>
                        <asp:DropDownList ID="eeAccountType" runat="server" Height="20px" Width="158px">
                            <asp:ListItem Value="">-Select Account Type-</asp:ListItem>
                            <asp:ListItem Value="Administrator">Administrator</asp:ListItem>
                            <asp:ListItem Value="Participant">Participant</asp:ListItem>
                            <asp:ListItem Value="Volunteer">Volunteer</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                       <asp:Label ID="test" runat="server" Text="" Visible="false"></asp:Label>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </div>
    <asp:Panel ID="Panel2" runat="server" Height="271px" DefaultButton="searchBtn">
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
        <br /> <br /> <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="  Apply  " OnClick="Button1_Click" />
        <br />
    </font>
    <br />
    All Parade Users Information: <asp:Label ID="test1" runat="server" 
        ForeColor="#FF3300"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Search by
    <asp:Label ID="searchLbl" runat="server" Text="Username"></asp:Label>
    :&nbsp;
    <asp:TextBox ID="searchTxt" runat="server"></asp:TextBox>
    <asp:Button ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click" />
    &nbsp;<asp:Button ID="advSearch" runat="server" Text="Advanced Search" OnClick="advSearch_Click" />
    &nbsp;
    <asp:Button ID="normalEdit" runat="server" Text="Normal Edit" 
        onclick="normalEdit_Click" />
    &nbsp;&nbsp;&nbsp; Export Table:
    <asp:ImageButton ID="ImageButton1" runat="server" 
        ImageUrl="~/images/Download.png" onclick="ImageButton1_Click" />
    <br />
    &nbsp;<asp:SqlDataSource ID="editTable" runat="server" ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>"
        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" SelectCommand="SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user ">
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="searchedTable" runat="server" ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>"
        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" SelectCommand="">
       
    </asp:SqlDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
        DataSourceID="editTable" ForeColor="#333333" OnRowCommand="GridView1_RowCommand"
        DataKeyNames="uID" OnRowEditing="GridView1_Edit" OnRowUpdating="GridView1_Update"
        OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" 
        AllowPaging="True" AllowSorting="True" PageSize="6">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="uID" HeaderText="ID" SortExpression="uID" InsertVisible="False"
                ReadOnly="True" />
            <asp:BoundField DataField="uUsername" HeaderText="Username" SortExpression="uUsername" />
            <asp:BoundField DataField="uOrgName" HeaderText="Organization" SortExpression="uOrgName" />
            <asp:BoundField DataField="uFName" HeaderText="First Name" SortExpression="uFName" />
            
            <asp:BoundField DataField="uLName" HeaderText="Last Name" SortExpression="uLName" />
            <asp:BoundField DataField="uHPhone" HeaderText="Home #" SortExpression="uHPhone" />
            <asp:BoundField DataField="uBPhone" HeaderText="Business #" SortExpression="uBPhone" />
            <asp:BoundField DataField="uCity" HeaderText="City" SortExpression="uCity" />
            <asp:BoundField DataField="uStreet" HeaderText="Street" SortExpression="uStreet" />
            <asp:BoundField DataField="uStatus" HeaderText="Status" SortExpression="uStatus" />
            <asp:BoundField DataField="uEmail" HeaderText="Email" SortExpression="uEmail" />
            <asp:BoundField DataField="uPostal" HeaderText="Postal Code" SortExpression="uPostal" />
            <asp:BoundField DataField="uProv" HeaderText="Province" SortExpression="uProv" />
            <asp:BoundField DataField="uDateJoined" HeaderText="Date Joined"  DataFormatString="{0:d}" HtmlEncode="false"  SortExpression="uDateJoined" />
            <asp:BoundField DataField="uDateExpire" HeaderText="Date Expire" DataFormatString="{0:d}"  HtmlEncode="false" SortExpression="uDateExpire" />
            <asp:BoundField DataField="uActivation" HeaderText="Activation" SortExpression="uActivation" />
            <asp:ButtonField ButtonType="Image" ImageUrl="images/edit_button25.png" CommandName="UpdateUser"
                HeaderText="Modify&nbsp;&nbsp;" Text="Modify" />
            <asp:ButtonField ButtonType="Image" ImageUrl="images/tup.png" CommandName="activate"
                HeaderText="Activate&nbsp;&nbsp;" Text="Activate" />
            <asp:ButtonField ButtonType="Image" CommandName="inactive" HeaderText="In-Activate&nbsp;&nbsp;"
                ImageUrl="images/tdown.png" Text="In-Activate" />
            <asp:ButtonField ButtonType="Image" CommandName="DeleteUser" HeaderText="Delete&nbsp;&nbsp;"
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

     <div  style="position: absolute; left: 837px; top: 286px;  z-index: 5; height: 243px; width: 339px;">
                 <asp:Panel ID="confirmPanel" runat="server" Height="226px" Width="303px" 
                     BackColor="#33CC33" BorderColor="#009900" Visible="False" 
                     BorderWidth="4px">
                     <br/><br/><br/><br/><br/><br/><br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:CheckBox ID="disableConfirm" runat="server" 
                         Text=" Click to Disable Confirmations" Visible="False" />
                     <br/>
                     &nbsp;&nbsp;&nbsp;
                  <div style="position: absolute; left: 20px; top: 27px;  z-index: 6; height: 31px; width: 259px; ">  <p> &nbsp;&nbsp;&nbsp; <asp:Label ID="AlertLbl" runat="server" Text=""></asp:Label></p></div>
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
