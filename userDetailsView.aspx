﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userDetailsView.aspx.cs" Inherits="userDetailsView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server"><link rel="shortcut icon" href="images/santaIcon.ico" />
    <title>User Area</title>
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
<body link="#006600" vlink="#990000" bgcolor="#ffffFF">
<form id="form1" runat="server">

 
<font color="#990000" size="+3">User Area: 
    <asp:Label ID="orgOrUSer" runat="server" Text="My Info"></asp:Label></font></p>
<div id="Layer1" 
        
        
        
    style="position:absolute; left:62px; top:64px; width:371px; height:111px; z-index:6"> 
 Welcome :<asp:Label ID="usernameSession" runat="server" Text=""></asp:Label> 
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
    <asp:Button ID="logoutButton" runat="server" Text=" Logout "  CausesValidation="false"  
        onclick="logoutButton_Click" />

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
    <br /><br /><br />
    <br />
    <br />
    <br /><h2>This is a view of all this users related information if applicable: <asp:Label ID="orgOrUser2" runat="server" Text=""></asp:Label> </h2><br />
    <br /> &nbsp;<div style="border: 5px solid blue; position: absolute; left: 350px; top: 162px; z-index: 4; height: 77px;
        width: 741px; background-color: #FF6600;" id="spare" runat="server">
     
        
        
        
       
        Options: <br /><br />
     &nbsp;&nbsp;&nbsp;&nbsp;   <asp:RadioButton ID="deleteFloatTran" runat="server" 
            Text="   Delete floats when organization  is transferred." />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
    </div>

    <div style="position: absolute; left: 44px; top: 262px; z-index: 2; height: 175px;
        width: 1047px;" id="userDiv" runat="server">
     
        <b> User Information: 
        <br />
        <br />
      
        </b>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
            AutoGenerateColumns="False" DataKeyNames="uID" 
            DataSourceID="SqlDataSource1" AllowPaging="True" 
            PageSize="2" Width="1605px" 
            >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="uID" HeaderText="User ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="uID" />
                <asp:BoundField DataField="uUsername" HeaderText="Username" 
                    SortExpression="uUsername" />
                <asp:BoundField DataField="uOrgName" HeaderText="Organization" 
                    SortExpression="uOrgName" />
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
                    SortExpression="uDateJoined"  />
                <asp:BoundField DataField="uDateExpire" HeaderText="Date Expire" DataFormatString="{0:d}"  HtmlEncode="false" 
                    SortExpression="uDateExpire"/>
                <asp:BoundField DataField="uActivation" HeaderText="Activated?" 
                    SortExpression="uActivation" />
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
            SelectCommand="SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user">
        </asp:SqlDataSource>
        
     
        
        
    </div>
    <div style="position: absolute; left: 1020px; top: 169px; z-index: 2; height: 95px;
        width: 144px;" id="orgDiv" runat="server">
     
       
    </div>


    <div  style="position: absolute; left: 47px; top: 460px; z-index: 2; height: 166px;
        width: 1137px;" id="floatDiv" runat="server">
         <b>Organziation Information: </b>
        
        <br /><br />
     
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" 
            AutoGenerateColumns="False" DataKeyNames="pOrgID" 
            DataSourceID="SqlDataSource2" 
            PageSize="2" Width="1605px" AllowPaging="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="pOrgID" HeaderText="Org. ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="pOrgID" />
                      <asp:BoundField DataField="uID" HeaderText="User ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="uID" />
                <asp:BoundField DataField="oOrganization" HeaderText="Organization" 
                    SortExpression="oOrganization" />
                <asp:BoundField DataField="oContact" HeaderText="Contact" 
                    SortExpression="oContact" />
                <asp:BoundField DataField="oPhone" HeaderText="Phone #" 
                    SortExpression="oPhone" />
                <asp:BoundField DataField="oWebsite" HeaderText="Website" 
                    SortExpression="oWebsite" />
                <asp:BoundField DataField="oEmail" HeaderText="Email" 
                    SortExpression="oEmail" />
                <asp:BoundField DataField="oAddress1" HeaderText="Address " 
                    SortExpression="oAddress1" />
                <asp:BoundField DataField="oCity" HeaderText="City" SortExpression="oCity" />
                <asp:BoundField DataField="oProvince" HeaderText="Province" 
                    SortExpression="oProvince" />
                <asp:BoundField DataField="oPostal" HeaderText="Postal" 
                    SortExpression="oPostal" />
                <asp:BoundField DataField="oCountry" HeaderText="Country" 
                    SortExpression="oCountry" />
                <asp:BoundField DataField="oDateJoined" HeaderText="Date Joined" 
                    SortExpression="oDateJoined" DataFormatString="{0:d}"  HtmlEncode="false" />
                <asp:BoundField DataField="oDateExpire" HeaderText="Date Expire"  
                    SortExpression="oDateExpire"  DataFormatString="{0:d}"  HtmlEncode="false" />
                <asp:BoundField DataField="oSeminarAtt" HeaderText="Seminar Attendance" 
                    SortExpression="oSeminarAtt" />
                <asp:BoundField DataField="oActivation" HeaderText="Activated?" 
                    SortExpression="oActivation" />
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
            SelectCommand="SELECT pOrgID, uID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo">
        </asp:SqlDataSource>
        <br />

     <b>Float Information:</b>
        <br />
                
                <br />
<asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
            CellPadding="4" DataKeyNames="floatID" DataSourceID="SqlDataSource3" 
            ForeColor="Black" AllowPaging="True" PageSize="2" Width="1605px">
    <Columns>
        <asp:BoundField DataField="floatID" HeaderText="Float ID" InsertVisible="False" 
            ReadOnly="True" SortExpression="floatID" />
        <asp:BoundField DataField="porgID" HeaderText="Org. ID" 
            SortExpression="porgID" />
        <asp:BoundField DataField="parade" HeaderText="Parade Name" 
            SortExpression="parade" />
        <asp:BoundField DataField="contact" HeaderText="Contact" 
            SortExpression="contact" />
        <asp:BoundField DataField="organization" HeaderText="Organization" 
            SortExpression="organization" />
        <asp:BoundField DataField="entry" HeaderText="Entry " SortExpression="entry" />
        <asp:BoundField DataField="vehicleType" HeaderText="Vehicle Type" 
            SortExpression="vehicleType" />
        <asp:BoundField DataField="floatLength" HeaderText="Float Length" 
            SortExpression="floatLength" />
        <asp:BoundField DataField="floatHeight" HeaderText="Float Height" 
            SortExpression="floatHeight" />
        <asp:BoundField DataField="floatWidth" HeaderText="Float Width" 
            SortExpression="floatWidth" />
        <asp:BoundField DataField="marchers" HeaderText="Marchers" 
            SortExpression="marchers" />
        <asp:BoundField DataField="noofmarchers" HeaderText="# of Marchers" 
            SortExpression="noofmarchers" />
        <asp:BoundField DataField="soundsystem" HeaderText="Sound System" 
            SortExpression="soundsystem" />
        <asp:BoundField DataField="waiveraccepter" HeaderText="Waiver Accepter" 
            SortExpression="waiveraccepter" />
        <asp:BoundField DataField="receivedFee" HeaderText="Received Fee" 
            SortExpression="receivedFee" />
        <asp:BoundField DataField="amount" HeaderText="Amount" 
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
        <asp:BoundField DataField="approved" HeaderText="Approved?" 
            SortExpression="approved" />
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
        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
            ConnectionString="<%$ ConnectionStrings:pmsConnectionString1 %>" 
            ProviderName="<%$ ConnectionStrings:pmsConnectionString1.ProviderName %>" 
            SelectCommand="SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, floatDesc,comments,approved FROM floatdetails">
        </asp:SqlDataSource>

        <br /><br /><br /><br /><br /><br /><br /><br /><br />
</div>
        </form >
</body>
</html>
