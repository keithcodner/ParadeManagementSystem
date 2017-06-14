﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userDetailsEdit.aspx.cs" Inherits="userDetailsEdit" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>User Area</title>


     <script type="text/javascript" src="js/jquery.min2.js"></script>
    <script type="text/javascript" src="js/MaxLength.min.js"></script>
    <script type="text/javascript">
        $(function () {

            //Normal Configuration
            $("[id*=desc]").MaxLength({ MaxLength: 1000 });

            //Normal Configuration
            $("[id*=scriptLbl]").MaxLength({ MaxLength: 1000 });

            //Normal Configuration
            $("[id*=banner]").MaxLength({ MaxLength: 100 });



        });
    </script>


    <style type="text/css"> body{padding:5px; font-family:Helvetica, Arial, Sans-Serif; color:Black;} *{padding:0; margin:0;}
        .BackColorTab
        {
            font-family:Verdana, Arial, Courier New;
            font-size: 10px;
            color:Gray;
            background-color:Silver;
        }
    </style>
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
<body  bgcolor="#ffffFF">
    <form id="form1"  runat="server">
    <font color="#990000" size="+3">User Area: Edit My Details</font><p></p>



    <div id="Layer11" style="position: absolute; left: 62px; top: 64px; width: 371px;
        height: 45px; z-index: 7">
        Welcome :<asp:Label ID="usernameSession" runat="server" Text=""></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="logoutButton" runat="server" Text=" Logout "  CausesValidation="false"  OnClick="logoutButton_Click" />
        
                 <ul>
            <li><a href="userHomeLogin.aspx">Home</a><ul><li><a href="userPasswordManagment.aspx">Change Password</a></li><li><a href="contactAdmin.aspx">Contact Admin</a></li><li><a href="userHelpDoc.aspx">Get Help</a></li></ul>
         
                   
 
             <%--  
                    <li><a href="adminConfig.aspx">Configure</a><ul><li><a href="Recover.aspx">Recover Users</a></ul></li>
                    <li><a href="#">Tools</a><ul>
                        <li><a href="addChangebanner.aspx">Add/Delete Banner</a></li><li><a href="addChangeWaiveraspx.aspx">
                            Add/Delete Waiver</a></li> <li><a href="trasnferOrg.aspx">Transfer Org. Or User</a></li> <li><a href="DropdownMods.aspx">DropdownList Mods</a></li><li><a href="activityLog.aspx">Activity Log</a></li><li><a href="Donwloads.aspx">Manage Downloads</a></li><li><a href="adminEmail.aspx">Email Settings</a></li></ul>
                    </li>
                </ul> --%>
            </li>
            <li><a href="#">View</a><ul><li><a href="userDetailsView.aspx">My Details</a></li></ul>
                <%--  <ul>
                    <li><a href="viewParadeInfo.aspx">View Organization Information</a></li>
                    <li><a href="adminArea.aspx">User Details</a></li>
                    <li><a href="paradeDetails.aspx">Parade Details</a></li><li><a href="floatDetails.aspx">Float Details</a></li>
                </ul> --%>
            </li>
            <li><a href="#">Edit</a><ul><li><a href="userDetailsEdit.aspx">Edit My Details</a></li></ul>
                <%--  <ul>
                    <li><a href="adminCreateUser.aspx">Create a User</a>
                        <ul>
                            <li><a href="addOrganization.aspx">Add Organization   </a><ul><li><a href="addFloat.aspx">Add Float</a></li></ul></li>
                        </ul>
                    </li>
                    <li><a href="editOrDeleteUser.aspx">Edit or Delete User</a></li>
                    <li><a href="editParadeInfo.aspx">Edit Organization Details</a></li><li><a href="editFloatDetailsaspx.aspx">Edit Float Details</a></li><li><a href="editParades.aspx">Edit Parade Details</a></li>
                </ul> --%>
            </li>
            
        </ul>
    </div>
    &nbsp;
   <%-- ////////////////////////////////////////////////////////////////////////////////////////////////////////
         /////////////////////////////////////////////////////////////////////////////////////////////////////////--%>
    <div id="Div1"  runat="server" style="position: absolute; left: 24px; top: 206px; z-index: 5; height: 492px;
        width: 1520px;" >
         <asp:ToolkitScriptManager  ID="toolkitscriptmgr" runat="server">         
</asp:ToolkitScriptManager >
   <asp:TabContainer ID="ditTabbedPanel" runat="server" ActiveTabIndex="0" 
            Height="684px" Width="1702px" BackColor="#FF0066" >
            
       
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="adminTab" runat="server" HeaderText="Edit My User Account Details" BackColor="#99FF66" ForeColor="#FF6666">
                <ContentTemplate><div id="Layer12" style="position: absolute; left: 10px; top: 13px; width: 1064px;
        height: 256px; z-index: 1"><br /><br /><br />
                    <asp:Label ID="userEditMode" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label> :
                    <asp:Label ID="userEditMsg" runat="server" ForeColor="Red" ></asp:Label>
                    <br />Edit items here:<asp:Label ID="userTabSavedLabel" 
                        runat="server" ForeColor="Red"></asp:Label>
                    <br /> <table class="style1"><tr><td class="style4">&#160;</td><td>&#160;</td></tr><tr><td class="style4">First Name : </td><td><asp:TextBox ID="eeFName" runat="server"></asp:TextBox></td></tr><tr><td class="style4">Last Name : </td><td><asp:TextBox ID="eeLName" runat="server"></asp:TextBox></td></tr><tr><td class="style4">Home Phone #: </td><td><asp:TextBox ID="eeHNo" runat="server"></asp:TextBox></td></tr><tr><td class="style4">Business #: </td><td><asp:TextBox ID="eeBNo" runat="server"></asp:TextBox></td></tr><tr><td class="style4">Street : </td><td><asp:TextBox ID="eeStreet" runat="server"></asp:TextBox></td></tr><tr><td class="style4">City: </td><td><asp:TextBox ID="eeCity" runat="server"></asp:TextBox></td></tr><tr><td class="style4">Province : </td><td><asp:DropDownList ID="eeProv" runat="server" Height="20px" Width="158px" 
                            onselectedindexchanged="eeProv_SelectedIndexChanged"><asp:ListItem>-Select Province-</asp:ListItem><asp:ListItem Value="Alberta">Alberta</asp:ListItem><asp:ListItem Value="British Columbia">British Columbia</asp:ListItem><asp:ListItem Value="Ontario">Ontario</asp:ListItem><asp:ListItem Value="Prince Edward Island">Prince Edward Island</asp:ListItem><asp:ListItem Value="Manitoba">Manitoba</asp:ListItem><asp:ListItem Value="New Brunswick">New Brunswick</asp:ListItem><asp:ListItem Value="Nova Scotia">Nova Scotia</asp:ListItem><asp:ListItem Value="Saskatchewan">Saskatchewan</asp:ListItem><asp:ListItem Value="Newfoundland and Labrador">Newfoundland and Labrador</asp:ListItem><asp:ListItem Value="Northwest Territories">Northwest Territories</asp:ListItem><asp:ListItem Value="Nunavut">Nunavut</asp:ListItem><asp:ListItem Value="Quebec">Quebec</asp:ListItem><asp:ListItem Value="Yukon">Yukon</asp:ListItem></asp:DropDownList></td></tr><tr><td class="style4">Postal Code: </td><td><asp:TextBox ID="eePost" runat="server"></asp:TextBox></td></tr><tr><td class="style4">Email: </td><td>
                        <asp:TextBox ID="eeEmail" runat="server" ReadOnly="True" ></asp:TextBox>
                        <asp:CheckBox ID="changeEmail" runat="server" Enabled="False"  Text="Change Email" 
                            AutoPostBack="True" />
                        </td></tr>
                        
                        <tr>
                                <td class="style4">
                                    <asp:Label ID="verifyEmailLbl" runat="server" Text="Verify Email:" Visible ="False"></asp:Label>
                                </td>
                        
                                <td>
                                    <asp:TextBox ID="verifyEmail" runat="server" Visible ="False"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVEmail" runat="server" Visible="False" Enabled="False" ControlToValidate="verifyEmail" ErrorMessage="*This field is required and cannot be left blank." ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                        
                        </tr>

                        <tr><td class="style4">&#160;</td><td>
                            <asp:CompareValidator ID="CVEmail" runat="server" ControlToCompare="eeEmail" 
                                ControlToValidate="verifyEmail" Enabled="False" 
                                ErrorMessage="*Emails did not match." ForeColor="Red" Visible="False"></asp:CompareValidator>
                            <br />
                             <asp:RegularExpressionValidator ID="REVEmail" runat="server"         
        ErrorMessage="*Email is case in-sensitive. Must be in email format ie. paradems@example.com " 
        ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" Visible="False" Enabled="False"
        ControlToValidate="eeEmail" ForeColor="Red"></asp:RegularExpressionValidator>
                            </td></tr>
                        
                        <tr><td class="style4"><asp:Label ID="test" runat="server" Visible="False"></asp:Label></td><td>&#160;&nbsp;<asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                            Text="  Apply  " /></td>
                            </tr>
                            
                            
                            </table><p>&#160;</p><font color="#FFFFFF">........<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </font><br />My Information: <asp:Label ID="test1" runat="server" 
        ForeColor="#FF3300"></asp:Label><br />&nbsp;<asp:SqlDataSource ID="editTable" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                        SelectCommand="SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user ">
                    </asp:SqlDataSource>
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                        AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                        DataKeyNames="uID" DataSourceID="editTable" ForeColor="#333333" 
                        OnRowCommand="GridView1_RowCommand" PageSize="2" Width="1650px">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="uID" HeaderText="ID" InsertVisible="False" 
                                ReadOnly="True" SortExpression="uID" />
                            <asp:BoundField DataField="uUsername" HeaderText="Username" 
                                SortExpression="uUsername" />
                            <asp:BoundField DataField="uOrgName" HeaderText="Organization" 
                                SortExpression="Organization" />
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
                            <asp:BoundField DataField="uEmail" HeaderText="Email" SortExpression="uEmail" />
                            <asp:BoundField DataField="uPostal" HeaderText="Postal Code" 
                                SortExpression="uPostal" />
                            <asp:BoundField DataField="uProv" HeaderText="Province" 
                                SortExpression="uProv" />
                            <asp:BoundField DataField="uDateJoined" DataFormatString="{0:d}" 
                                HeaderText="Date Joined" HtmlEncode="False" SortExpression="uDateJoined" />
                            <asp:BoundField DataField="uDateExpire" DataFormatString="{0:d}" 
                                HeaderText="Date Expire" HtmlEncode="False" SortExpression="uDateExpire" />
                            <asp:BoundField DataField="uActivation" HeaderText="Activation" 
                                SortExpression="uActivation" />
                            <asp:ButtonField ButtonType="Image" CommandName="UpdateUser" 
                                HeaderText="Modify&nbsp;&nbsp;" ImageUrl="images/edit_button25.png" 
                                Text="Modify" />
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
                    </div></ContentTemplate>
            

</asp:TabPanel>
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%--  1111111111111111111111111111111111111111111111111111111111111111111111111111111
            1111111111111111111111111111111111111111111111111111111111111111111111111111111111111 --%>
       
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Edit My Organization Details">
              <ContentTemplate><div id="Div2" style="position: absolute; left: 10px; top: 13px; width: 1364px;
        height: 256px; z-index: "><br /><br /><br />
                  <asp:Label ID="orgEditMode" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                  :
                  <asp:Label ID="orgEditMsg" runat="server" ForeColor="Red"></asp:Label>
                  <br />Edit items here:<asp:Label 
                      ID="userTabSavedLabel0" runat="server" ForeColor="Red"></asp:Label>
                  <br /> <table class="style1"><tr><td class="style4">Organization: </td><td><asp:TextBox ID="eeOrganization" runat="server"></asp:TextBox></td></tr><tr><td class="style4">Contact Name: </td><td>
                      <asp:DropDownList ID="selectContact" runat="server" Height="20px" Width="158px" DataSourceID="contName"
                            DataTextField="concat (ufname,' ', ulname)" 
                          DataValueField="concat (ufname,' ', ulname)" AppendDataBoundItems="True"></asp:DropDownList>
                      <asp:SqlDataSource ID="contName" runat="server" ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>"
                            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                          SelectCommand="SELECT concat (ufname,' ', ulname)FROM user"></asp:SqlDataSource></td></tr><tr><td class="style4">Phone # : </td><td><asp:TextBox ID="eePhone" runat="server"></asp:TextBox></td></tr><tr><td class="style4">Website: </td><td><asp:TextBox ID="eeWebsite" runat="server"></asp:TextBox></td></tr><tr><td class="style4">Email: </td><td><asp:TextBox ID="eEmail" runat="server"></asp:TextBox></td></tr><tr><td class="style4">Street : </td><td><asp:TextBox ID="eStreet" runat="server"></asp:TextBox></td></tr><tr><td class="style4">City: </td><td><asp:TextBox ID="eCity" runat="server"></asp:TextBox></td></tr><tr><td class="style4">Province : </td><td><asp:DropDownList ID="eProv" runat="server" Height="20px" Width="158px"><asp:ListItem>-Select Province-</asp:ListItem><asp:ListItem Value="Alberta">Alberta</asp:ListItem><asp:ListItem Value="British Columbia">British Columbia</asp:ListItem><asp:ListItem Value="Ontario">Ontario</asp:ListItem><asp:ListItem Value="Prince Edward Island">Prince Edward Island</asp:ListItem><asp:ListItem Value="Manitoba">Manitoba</asp:ListItem><asp:ListItem Value="New Brunswick">New Brunswick</asp:ListItem><asp:ListItem Value="Nova Scotia">Nova Scotia</asp:ListItem><asp:ListItem Value="Saskatchewan">Saskatchewan</asp:ListItem><asp:ListItem Value="Newfoundland and Labrador">Newfoundland and Labrador</asp:ListItem><asp:ListItem Value="Northwest Territories">Northwest Territories</asp:ListItem><asp:ListItem Value="Nunavut">Nunavut</asp:ListItem><asp:ListItem Value="Quebec">Quebec</asp:ListItem><asp:ListItem Value="Yukon">Yukon</asp:ListItem><asp:ListItem Value="AL">Alabama</asp:ListItem>
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
                    <asp:ListItem Value="WY">Wyoming</asp:ListItem></asp:DropDownList></td></tr><tr><td class="style4">Postal Code: </td><td><asp:TextBox ID="ePost" runat="server"></asp:TextBox></td></tr><tr><td class="style4">Country: </td><td><asp:DropDownList ID="DropDownList2" runat="server" Height="20px" Width="158px"><asp:ListItem>-Country-</asp:ListItem><asp:ListItem Value="Canada">Canada</asp:ListItem><asp:ListItem Value="United States">United States</asp:ListItem></asp:DropDownList></td></tr><tr><td class="style4">&#160;</td><td>&#160;</td></tr><tr><td class="style4"><asp:Label ID="Label1" runat="server" Visible="False"></asp:Label><br /></td><td>&#160;&nbsp;<asp:Button 
                          ID="orgButton" runat="server"  
                            Text="  Apply  " onclick="orgButton_Click"  enabled="False" /></td></tr></table><p>&#160;</p><font color="#FFFFFF">........&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </font><br />My Information: <asp:Label ID="Label2" runat="server" 
        ForeColor="#FF3300"></asp:Label>
                  
                  
               
                  <br>
                  <br />
                  <br />
                  <asp:SqlDataSource ID="editTablesOrg" runat="server" 
                      ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                      ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                      SelectCommand="SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  ">
                  </asp:SqlDataSource>
                  <asp:GridView ID="GridView2" runat="server" AllowPaging="True" 
                      AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                      DataKeyNames="pOrgID" DataSourceID="editTablesOrg" ForeColor="#333333" 
                      OnRowCommand="GridView1_RowCommand_Org" PageSize="2" Width="1590px">
                      <AlternatingRowStyle BackColor="White" />
                      <Columns>
                          <asp:BoundField DataField="pOrgID" HeaderText="ID" InsertVisible="False" 
                              ReadOnly="True" SortExpression="pOrgID" />
                          <asp:BoundField DataField="oOrganization" HeaderText="Organization" 
                              SortExpression="oOrganization" />
                          <asp:BoundField DataField="oContact" HeaderText="Contact" 
                              SortExpression="oContact" />
                          <asp:BoundField DataField="oPhone" HeaderText="Phone #" 
                              SortExpression="oPhone" />
                          <asp:BoundField DataField="oWebsite" HeaderText="Website" 
                              SortExpression="oWebsite" />
                          <asp:BoundField DataField="oEmail" HeaderText="Email" SortExpression="oEmail" />
                          <asp:BoundField DataField="oAddress1" HeaderText="Street" 
                              SortExpression="oAddress1" />
                          <asp:BoundField DataField="oCity" HeaderText="City" SortExpression="oCity" />
                          <asp:BoundField DataField="oProvince" HeaderText="Province" 
                              SortExpression="oProvince" />
                          <asp:BoundField DataField="oPostal" HeaderText="Postal" 
                              SortExpression="oPostal" />
                          <asp:BoundField DataField="oCountry" HeaderText="Country" 
                              SortExpression="oCountry" />
                          <asp:BoundField DataField="oDateJoined" DataFormatString="{0:d}" 
                              HeaderText="Date Joined" HtmlEncode="False" SortExpression="oDateJoined" />
                          <asp:BoundField DataField="oDateExpire" DataFormatString="{0:d}" 
                              HeaderText="Date Expired" HtmlEncode="False" SortExpression="oDateExpire" />
                          <asp:BoundField DataField="oSeminarAtt" HeaderText="Seminar Attendance" 
                              SortExpression="oSeminarAtt" />
                          <asp:BoundField DataField="oActivation" HeaderText="Activation" 
                              SortExpression="oActivation" />
                          <asp:ButtonField ButtonType="Image" CommandName="UpdateUser" 
                              HeaderText="Modify&nbsp;&nbsp;" ImageUrl="images/edit_button25.png" 
                              Text="Modify" />
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
                  <br>
                
                  </div></ContentTemplate>
            

</asp:TabPanel>


       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%--  22222222222222222222222222222222222222222222222222222222222222222222222222222222
             22222222222222222222222222222222222222222222222222222222222222222222222222222222--%>
       
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 

       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Edit My Float Details">
              <ContentTemplate><div id="Div3" style="position: absolute; left: 10px; top: 13px; width: 1064px;
        height: 256px; z-index: 1"><br /><br /><br /><br /><br /> 
                  <div id="Layer1" style="position: absolute; left: 11px; top: 45px; width: 1064px;
        height: 256px; z-index: 1"><asp:Panel ID="Panel1" runat="server" Height="271px">
        
          <asp:Label ID="floatEditMode" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
                  :
                  <asp:Label ID="floatEditMsg" runat="server" ForeColor="Red"></asp:Label>
        
        <br />
        Edit items here:<asp:Label 
                              ID="editItemStatusFloat" runat="server"  ForeColor="#FF3300"></asp:Label><br /><br /><table class="style1"><tr><td 
                                  class="style4">&nbsp;</td><td>
                                  <asp:SqlDataSource ID="paradeNames" runat="server" 
                                      ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                                      ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                                      SelectCommand="SELECT paradeID, paradeName FROM parade"></asp:SqlDataSource>
                              </td></tr><tr><td class="style4">Organization: </td><td><asp:DropDownList 
                                      ID="Organization" runat="server" AppendDataBoundItems="True" 
                                      DataSourceID="OrgName" DataTextField="oOrganization" 
                                      DataValueField="oOrganization" Height="20px" Width="158px"><asp:ListItem>-Select Organization-</asp:ListItem>
                                  </asp:DropDownList>
                                  <asp:SqlDataSource ID="OrgName" runat="server" 
                                      ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                                      ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                                      SelectCommand="SELECT organization FROM floatdetails">
                                  </asp:SqlDataSource>
                                  </td></tr><tr><td class="style4">Entry Type: </td><td><asp:DropDownList 
                                      ID="Entry" runat="server" AppendDataBoundItems="True" DataTextField="EntryType" 
                                      DataValueField="EntryType" Height="20px" Width="158px" 
                                      DataSourceID="EntryTypeDS"><asp:ListItem Value="0">-Select Entry Type-</asp:ListItem>
                                  </asp:DropDownList>
                                  <asp:SqlDataSource ID="EntryTypeDS" runat="server" 
                                      ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                                      ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                                      SelectCommand="SELECT EntryType FROM ddEntryType ORDER BY EntryType">
                                  </asp:SqlDataSource>
                                  </td></tr><tr><td class="style4">Float Length(ft) : </td><td><asp:TextBox 
                                      ID="floatLength" runat="server" Text="0" Width="61px"></asp:TextBox></td></tr><tr><td 
                                      class="style4">Float Height(ft): </td><td><asp:TextBox ID="floatHeight" 
                                          runat="server" Text="0" Width="61px"></asp:TextBox></td></tr><tr><td 
                                      class="style4">Float Width (ft): </td><td><asp:TextBox ID="floatWidth" 
                                          runat="server" Text="0" Width="61px"></asp:TextBox></td></tr><tr><td 
                                      class="style4">Marchers: </td><td>
                                      <asp:DropDownList ID="Marchers" 
                                          runat="server" AppendDataBoundItems="True" DataTextField="uFName" 
                                          DataValueField="uFName" Height="20px" Width="158px" AutoPostBack="True"><asp:ListItem 
                                          Value="No">No</asp:ListItem><asp:ListItem Value="Yes">Yes</asp:ListItem>
                                      </asp:DropDownList>
                                  </td></tr><tr><td class="style4"># of Marchers: </td><td><asp:TextBox 
                                      ID="noOfMarchers" runat="server" Text="0" Width="61px" Enabled = "False"></asp:TextBox></td></tr><tr><td 
                                      class="style4">Sound System: </td><td><asp:DropDownList ID="SoundSystem" 
                                          runat="server" Height="20px" Width="158px"><asp:ListItem Value="No">No</asp:ListItem><asp:ListItem 
                                          Value="Yes">Yes</asp:ListItem>
                                      </asp:DropDownList>
                                  </td></tr><tr><td class="style4">Float Type: </td><td><asp:DropDownList 
                                      ID="floatType" runat="server" AppendDataBoundItems="True" 
                                      DataTextField="FloatType" DataValueField="FloatType" Height="20px" 
                                      Width="158px" DataSourceID="FloatTypeDS"><asp:ListItem>-Select Float Type-</asp:ListItem>
                                  </asp:DropDownList>
                                  <asp:SqlDataSource ID="FloatTypeDS" runat="server" 
                                      ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                                      ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                                      SelectCommand="SELECT FloatType FROM ddFloatType ORDER BY FloatType">
                                  </asp:SqlDataSource>
                                  </td></tr><tr><td 
                                      class="style4"><asp:Label ID="Stats" runat="server" Text="Status:" Visible="False" ></asp:Label> </td><td><asp:DropDownList ID="Status" runat="server" Visible="False"
                                          Height="20px" Width="158px"><asp:ListItem Value="New">New</asp:ListItem><asp:ListItem 
                                          Value="In-Work">In-Work</asp:ListItem><asp:ListItem Value="Complete">Complete</asp:ListItem><asp:ListItem 
                                          Value="Inspected">Inspected</asp:ListItem>
                                      </asp:DropDownList>
                                  </td></tr><tr><td 
                                      class="style4">
                                      <br /><br />
                                  <asp:Button ID="floatBtn" runat="server" Text="  Apply  " 
                                      onclick="floatBtn_Click" enabled="False" />
                                      <br /><br />
                                  </td><td>
                                      <asp:Label ID="Label21" runat="server" Visible="False"></asp:Label>
                                      <asp:Label ID="Label31" runat="server" Visible="False"></asp:Label>
                                      <asp:Label ID="Label71" runat="server" Visible="False"></asp:Label>
                                      <br />
                                  </td></tr>
                              <caption>
                                  <br />
                              </caption>
                          </table>
                          <div style="position: absolute; left: 333px; top: 62px;  z-index: 2; height: 309px; width: 711px;"><table class="style1"><tr>
                    <td class="style4">
                      
                       Float Description:<br />
                    </td>
                    <td>
                         <asp:TextBox ID="desc" runat="server" TextMode="MultiLine" Height="65px" 
                             Width="331px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td class="style4">
                      Script:<br />
                       
                    </td>
                    <td>
                          <asp:TextBox ID="scriptLbl" runat="server" TextMode="MultiLine" Height="64px" 
                              Width="332px"></asp:TextBox>
                              
                             <asp:Button ID="editScript" runat="server" 
                              Text="Edit" onclick="editScript_Click" />
                              
                              <asp:Button
                                  ID="updateScript" runat="server" Text="Update" Enabled="False" 
                              onclick="updateScript_Click" />
                              <asp:Label ID="scriptNotice" runat="server" ForeColor="#CC00FF"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td class="style4">
                      Banner:<br />
                       
                    </td>
                    <td>
                    <br />
                          <asp:TextBox ID="banner" runat="server" TextMode="MultiLine" Height="38px" 
                              Width="332px"></asp:TextBox>
                    </td>
                </tr></tr>
                              <tr>
                                  <td class="style4">
                                      &nbsp;</td>
                                  <td>
                                     
                                  </td>
                              </tr>
                              </table></div></asp:Panel></div><p>&nbsp;</p><font color="#FFFFFF">........<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </font><br /><br />&#160;
        
       
                 
                  <asp:SqlDataSource ID="editTableFloat" runat="server" 
                      ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                      ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                      SelectCommand="SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved FROM floatdetails">
                  </asp:SqlDataSource>
                  <div ID="Div4" runat="server" style="position: absolute; left: -8px; top: 500px; z-index: 5; height: 94px;
        width: 1588px;">
                      My Information:<asp:Label ID="floatStatuses" runat="server"></asp:Label>
                      <br />
                      <br />
                      <asp:GridView ID="GridView3" runat="server" AllowPaging="True" 
                          AllowSorting="True" AutoGenerateColumns="False" BackColor="White" 
                          BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                          DataKeyNames="floatID" DataSourceID="editTableFloat" ForeColor="Black" 
                          OnRowCommand="GridView1_RowCommand_Float" PageSize="2" Width="1600px">
                          <Columns>
                              <asp:BoundField DataField="floatID" HeaderText="Float ID" InsertVisible="False" 
                                  ReadOnly="True" SortExpression="floatID" />
                              <asp:BoundField DataField="porgID" HeaderText="Org ID" 
                                  SortExpression="porgID" />
                              <asp:BoundField DataField="parade" HeaderText="Parade" 
                                  SortExpression="parade" />
                              <asp:BoundField DataField="contact" HeaderText="Contact" 
                                  SortExpression="contact" />
                              <asp:BoundField DataField="organization" HeaderText="Organization" 
                                  SortExpression="organization" />
                              <asp:BoundField DataField="entry" HeaderText="Entry" SortExpression="entry" />
                              <asp:BoundField DataField="vehicleType" HeaderText="Float Type" 
                                  SortExpression="vehicleType" />
                              <asp:BoundField DataField="floatLength" HeaderText="Float Length(ft)" 
                                  SortExpression="floatLength" />
                              <asp:BoundField DataField="floatHeight" HeaderText="Float Height(ft)" 
                                  SortExpression="floatHeight" />
                              <asp:BoundField DataField="floatWidth" HeaderText="Float Width(ft)" 
                                  SortExpression="floatWidth" />
                              <asp:BoundField DataField="marchers" HeaderText="Marchers" 
                                  SortExpression="marchers" />
                              <asp:BoundField DataField="noofmarchers" HeaderText="# Of Marchers" 
                                  SortExpression="noofmarchers" />
                              <asp:BoundField DataField="soundsystem" HeaderText="Sound System" 
                                  SortExpression="soundsystem" />
                              <asp:BoundField DataField="waiveraccepter" HeaderText="Waiver Acceptor" 
                                  SortExpression="waiveraccepter" />
                              <asp:BoundField DataField="receivedFee" HeaderText="Received Fee" 
                                  SortExpression="receivedFee" />
                              <asp:BoundField DataField="amount" HeaderText="Amount($)" 
                                  SortExpression="amount" />
                              <asp:BoundField DataField="status" HeaderText="Status" 
                                  SortExpression="status" />
                              <asp:BoundField DataField="entryno" HeaderText="Entry #" 
                                  SortExpression="entryno" />
                              <asp:BoundField DataField="entryCode" HeaderText="Entry Code" 
                                  SortExpression="entryCode" />
                              <asp:BoundField DataField="floatDesc" HeaderText="Description" 
                                  SortExpression="floatDesc" />
                              <asp:BoundField DataField="comments" HeaderText="Script" 
                                  SortExpression="comments" />
                              <asp:BoundField DataField="banner" HeaderText="Banner" 
                                  SortExpression="banner" />
                              <asp:BoundField DataField="approved" HeaderText="Approval" 
                                  SortExpression="approved" />
                              <asp:ButtonField ButtonType="Image" CommandName="UpdateFloat" 
                                  HeaderText="Modify&nbsp;&nbsp;" ImageUrl="images/edit_button25.png" 
                                  Text="Modify" />
                          </Columns>
                          <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                          <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                          <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                          <SortedAscendingCellStyle BackColor="#F7F7F7" />
                          <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                          <SortedDescendingCellStyle BackColor="#E5E5E5" />
                          <SortedDescendingHeaderStyle BackColor="#242121" />
                      </asp:GridView>
                  </div>
                 
           
                                   
                  </div></ContentTemplate>
            

</asp:TabPanel>


       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%-- 333333333333333333333333333333333333333333333333333333333333333333333333333333333
             333333333333333333333333333333333333333333333333333333333333333333333333333333333 --%>
       
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </asp:TabContainer>

    </div>
    </form>
</body>
</html>
