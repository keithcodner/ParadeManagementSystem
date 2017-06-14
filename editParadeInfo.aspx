<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editParadeInfo.aspx.cs" Inherits="editParadeInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><link rel="shortcut icon" href="images/santaIcon.ico" />
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
    <form id="form1" defaultbutton="searchBtn" runat="server">
    <font color="#990000" size="+3">Administrator Area: Edit Organization Details</font></p>
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
        left: 512px; top: 185px; width: 369px; height: 203px; z-index: 3" Visible="False" DefaultButton="searchBtn" >
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp; Advanced Search Options:<br />
        <br />
        &nbsp;&nbsp;
        <asp:RadioButton ID="cbOrganization" runat="server" Text=" Organization" Visible="False"
            GroupName="a" />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="cbContact" runat="server" Text=" Contact" Visible="False" GroupName="a" />
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
        <asp:RadioButton ID="cbWebsite" runat="server" Text=" Website" Visible="False" GroupName="a" /><br />
    </asp:Panel>
    &nbsp;
    <div id="Layer1" style="position: absolute; left: 10px; top: 160px; width: 1064px;
        height: 256px; z-index: 1">
        <asp:Panel ID="Panel1" runat="server" Height="271px">
            Edit items here:<br />
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
                        Contact Name:
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="158px" DataSourceID="contName"
                            DataTextField="concat (ufname,' ', ulname)" 
                            DataValueField="concat (ufname,' ', ulname)" AppendDataBoundItems="True">
                            <asp:ListItem Value="">-Select Contact-</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="contName" runat="server" ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>"
                            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" SelectCommand="SELECT concat (ufname,' ', ulname)  from user">
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Phone # :
                    </td>
                    <td>
                        <asp:TextBox ID="eePhone" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Website:
                    </td>
                    <td>
                        <asp:TextBox ID="eeWebsite" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Email:
                    </td>
                    <td>
                        <asp:TextBox ID="eEmail" runat="server"></asp:TextBox>
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
                            <asp:ListItem Value="AL">Alabama</asp:ListItem>
                    <asp:ListItem Value="AK">Alaska</asp:ListItem>
                    <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                    <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                    <asp:ListItem Value="CA">California</asp:ListItem>
                    <asp:ListItem Value="CO">Colorado</asp:ListItem>
                    <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                    <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                    <asp:ListItem Value="DE">Delaware</asp:ListItem>
                    <asp:ListItem Value="FL">Florida</asp:ListItem>
                    <asp:ListItem Value="GA">Georgia</asp:ListItem>
                    <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                    <asp:ListItem Value="ID">Idaho</asp:ListItem>
                    <asp:ListItem Value="IL">Illinois</asp:ListItem>
                    <asp:ListItem Value="IN">Indiana</asp:ListItem>
                    <asp:ListItem Value="IA">Iowa</asp:ListItem>
                    <asp:ListItem Value="KS">Kansas</asp:ListItem>
                    <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                    <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                    <asp:ListItem Value="ME">Maine</asp:ListItem>
                    <asp:ListItem Value="MD">Maryland</asp:ListItem>
                    <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                    <asp:ListItem Value="MI">Michigan</asp:ListItem>
                    <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                    <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                    <asp:ListItem Value="MO">Missouri</asp:ListItem>
                    <asp:ListItem Value="MT">Montana</asp:ListItem>
                    <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                    <asp:ListItem Value="NV">Nevada</asp:ListItem>
                    <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                    <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                    <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                    <asp:ListItem Value="NY">New York</asp:ListItem>
                    <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                    <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                    <asp:ListItem Value="OH">Ohio</asp:ListItem>
                    <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                    <asp:ListItem Value="OR">Oregon</asp:ListItem>
                    <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                    <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                    <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                    <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                    <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                    <asp:ListItem Value="TX">Texas</asp:ListItem>
                    <asp:ListItem Value="UT">Utah</asp:ListItem>
                    <asp:ListItem Value="VT">Vermont</asp:ListItem>
                    <asp:ListItem Value="VA">Virginia</asp:ListItem>
                    <asp:ListItem Value="WA">Washington</asp:ListItem>
                    <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                    <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                    <asp:ListItem Value="WY">Wyoming</asp:ListItem>
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
                        Country:
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="158px">
                            <asp:ListItem Value="">-Country-</asp:ListItem>
                            <asp:ListItem Value="Canada">Canada</asp:ListItem>
                            <asp:ListItem Value="United States">United States</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Seminar Attendence:
                    </td>
                    <td>
                        <asp:DropDownList ID="eeSeminarAtt" runat="server" Height="20px" Width="158px">
                            <asp:ListItem Value="">-Attendance Type-</asp:ListItem>
                            <asp:ListItem Value="Mandatory">Mandatory</asp:ListItem>
                            <asp:ListItem Value="Optional">Optional</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        <asp:Label ID="test" runat="server" Visible="false"></asp:Label>
                        <br />
                    </td>
                    <td>
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
        <asp:Button ID="Button1" runat="server" Text="  Apply  " OnClick="Button1_Click" />
        <br />
    </font>
    <br />
    All Parade Organization Information:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Search by
    <asp:Label ID="searchLbl" runat="server" Text="Name"></asp:Label>
    :&nbsp;
    <asp:TextBox ID="searchTxt" runat="server" 
        ontextchanged="searchTxt_TextChanged"></asp:TextBox>
    <asp:Button ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click" />
    &nbsp;<asp:Button ID="advSearch" runat="server" Text="Advanced Search" OnClick="advSearch_Click" />
    &nbsp;<asp:Button ID="normalEdit" runat="server" Text="Normal Edit" 
        visible="false" onclick="normalEdit_Click" />
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
        DataKeyNames="pOrgID" 
        AllowPaging="True" AllowSorting="True" PageSize="7">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="pOrgID" HeaderText="ID" SortExpression="pOrgID" InsertVisible="False"
                ReadOnly="True" />
            <asp:BoundField DataField="oOrganization" HeaderText="Organization" SortExpression="oOrganization" />
            <asp:BoundField DataField="oContact" HeaderText="Contact" SortExpression="oContact" />
            <asp:BoundField DataField="oPhone" HeaderText="Phone #" SortExpression="oPhone" />
            <asp:BoundField DataField="oWebsite" HeaderText="Website" SortExpression="oWebsite" />
            <asp:BoundField DataField="oEmail" HeaderText="Email" SortExpression="oEmail" />
            <asp:BoundField DataField="oAddress1" HeaderText="Street" SortExpression="oAddress1" />
            <asp:BoundField DataField="oCity" HeaderText="City" SortExpression="oCity" />
            <asp:BoundField DataField="oProvince" HeaderText="Province" SortExpression="oProvince" />
            <asp:BoundField DataField="oPostal" HeaderText="Postal" SortExpression="oPostal" />
            <asp:BoundField DataField="oCountry" HeaderText="Country" SortExpression="oCountry" />
            <asp:BoundField DataField="oDateJoined" HeaderText="Date Joined"  DataFormatString="{0:d}" HtmlEncode="false"  SortExpression="oDateJoined" />
            <asp:BoundField DataField="oDateExpire" HeaderText="Date Expired" SortExpression="oDateExpire" DataFormatString="{0:d}" HtmlEncode="false"  />
            <asp:BoundField DataField="oSeminarAtt" HeaderText="Seminar Attendance" SortExpression="oSeminarAtt" />
            <asp:BoundField DataField="oActivation" HeaderText="Activation" SortExpression="oActivation" />
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
    <asp:SqlDataSource ID="editTables" runat="server" ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>"
        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" SelectCommand="SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo">
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
