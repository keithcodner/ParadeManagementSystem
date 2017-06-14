﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="floatDetails.aspx.cs" Inherits="floatDetails" %>

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
<form id="form1"  runat="server">

 
<font color="#990000" size="+3">Administrator Area: Float Information</font></p>
<div id="Layer1" 
        
        
        
    style="position:absolute; left:62px; top:64px; width:371px; height:111px; z-index:1"> 
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
    <br />All Parade Parades
<asp:Label ID="label1" runat="server" Text=""></asp:Label>
:
    <asp:Panel ID="Panel1" runat="server" Height="163px">

        &nbsp;&nbsp;
             
        
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
            DataKeyNames="floatID" DataSourceID="SqlDataSource2" ForeColor="#333333" 
            PageSize="7">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="floatID" HeaderText="Float ID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="floatID" />
                <asp:BoundField DataField="porgID" HeaderText="Org ID" 
                    SortExpression="porgID" />
                    <asp:BoundField DataField="parade" HeaderText="Parade" 
                    SortExpression="parade" />
                <asp:BoundField DataField="contact" HeaderText="Contact" 
                    SortExpression="contact" />
                <asp:BoundField DataField="organization" HeaderText="Organization" 
                    SortExpression="organization" />
                <asp:BoundField DataField="entry" HeaderText="Entry" 
                    SortExpression="entry" />
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
                <asp:BoundField DataField="noOfMarchers" HeaderText="# Of Marchers" 
                    SortExpression="noOfMarchers" />
                <asp:BoundField DataField="soundSystem" HeaderText="Sound System" 
                    SortExpression="soundSystem" />
                <asp:BoundField DataField="floatDesc" HeaderText="Float Desc." 
                    SortExpression="floatDesc" />
                <asp:BoundField DataField="comments" HeaderText="Script" 
                    SortExpression="comments" />

                    <asp:BoundField DataField="banner" HeaderText="Banner" 
                    SortExpression="banner" />
               
                <asp:BoundField DataField="waiverAccepter" HeaderText="Waiver Accepter" 
                    SortExpression="waiverAccepter" />
                <asp:BoundField DataField="receivedFee" HeaderText="Received Fee" 
                    SortExpression="receivedFee" />
                <asp:BoundField DataField="amount" HeaderText="Amount" 
                    SortExpression="amount" />
                <asp:BoundField DataField="status" HeaderText="Status" 
                    SortExpression="status" />
                <asp:BoundField DataField="entryNo" HeaderText="Entry #:" 
                    SortExpression="entryNo" />
                     <asp:BoundField DataField="entryCode" HeaderText="Entry Code" 
                SortExpression="entryCode" />
                    <asp:BoundField DataField="approved" HeaderText="Approved:" 
                    SortExpression="approved" />
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
            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
            SelectCommand="SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noOfMarchers, soundSystem, floatDesc, comments, waiverAccepter, receivedFee, amount,  status, entryno, entryCode, entryCode, approved FROM floatDetails">
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
            SelectCommand="SELECT *  FROM parade"></asp:SqlDataSource>
             
        
    </asp:Panel>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
        </form >
</body>
</html>