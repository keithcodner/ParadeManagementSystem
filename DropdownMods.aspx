<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropdownMods.aspx.cs" Inherits="DropdownMods" %>

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

 
<font color="#990000" size="+3">Administrator Area: Drop Down List Modification</font>
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
    <br /><h2>Modify Dropdown Lists for different pages :</h2><br />

    <div style="position: absolute; left: 873px; top: 182px; z-index: 2; height: 334px;
        width: 380px;" id="Div4" runat="server">
     <h3><u>Float Add/Edit Page(s) [Status]:</u></h3><br />
        Status Dropdown List:
     
        
        
     <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" 
         CellPadding="4" DataKeyNames="ddStatusID" DataSourceID="SqlDataSource3" 
         ForeColor="#333333" AllowPaging="True" AllowSorting="True" 
         onrowcommand="GridView3_RowCommand">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="ddStatusID" HeaderText="ID" 
                 InsertVisible="False" ReadOnly="True" SortExpression="ddStatusID" />
             <asp:BoundField DataField="Status" HeaderText="Status" 
                 SortExpression="Status" />

                 <asp:ButtonField ButtonType="Image" ImageUrl="images/edit_button25.png" CommandName="UpdateStatus"
                HeaderText="Modify&nbsp;&nbsp;" Text="Modify" />
            
            <asp:ButtonField ButtonType="Image" CommandName="DeleteStatus" HeaderText="Delete&nbsp;&nbsp;"
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
     
    <asp:Label ID="StatusLbl" runat="server" Text="Add"></asp:Label>  a Status:<asp:TextBox 
            ID="txtStatus" runat="server"></asp:TextBox>
     <asp:Button ID="addStatus" runat="server" Text="Add" onclick="addStatus_Click"  />
     <asp:Button ID="applyStatus" runat="server" Text="Apply" Enabled="False" onclick="applyStatus_Click"  
          />
     <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
         ConnectionString="<%$ ConnectionStrings:pmsConnectionString1 %>" 
         ProviderName="<%$ ConnectionStrings:pmsConnectionString1.ProviderName %>" 
         SelectCommand="SELECT ddStatusID, Status FROM ddStatus"></asp:SqlDataSource>

     
        
        
    </div>

    <br /> &nbsp;<a name="gettingStarted"></a></a><div style="position: absolute; left: 59px; top: 177px; z-index: 2; height: 334px;
        width: 377px;" id="Div3" runat="server">
     <h3><u>Float Add/Edit Page(s) [Entry Type]:</u></h3><br />
     Entry Type Dropdown List:
     
        
        
     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
         CellPadding="4" DataKeyNames="ddEntryTypeID" DataSourceID="SqlDataSource2" 
         ForeColor="#333333" AllowPaging="True" AllowSorting="True" 
         onrowcommand="GridView1_RowCommand">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="ddEntryTypeID" HeaderText="ID" 
                 InsertVisible="False" ReadOnly="True" SortExpression="ddEntryTypeID" />
             <asp:BoundField DataField="EntryType" HeaderText="EntryType" 
                 SortExpression="EntryType" />
                 <asp:ButtonField ButtonType="Image" ImageUrl="images/edit_button25.png" CommandName="UpdateEntryType"
                HeaderText="Modify&nbsp;&nbsp;" Text="Modify" />
            
            <asp:ButtonField ButtonType="Image" CommandName="DeleteEntryType" HeaderText="Delete&nbsp;&nbsp;"
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
     
    <asp:Label ID="cityLbl" runat="server" Text="Add"></asp:Label>  a Entry Type:<asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
     <asp:Button ID="cityBtn" runat="server" Text="Add" onclick="cityBtn_Click" />
     <asp:Button ID="cityApplyBtn" runat="server" Text="Apply" Enabled="False" onclick="cityApplyBtn_Click" 
          />
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
         ConnectionString="<%$ ConnectionStrings:pmsConnectionString1 %>" 
         ProviderName="<%$ ConnectionStrings:pmsConnectionString1.ProviderName %>" 
         SelectCommand="SELECT ddEntryTypeID, EntryType FROM ddEntryType"></asp:SqlDataSource>

     
        
        
    </div>

    <div style="position: absolute; left: 49px; top: 622px; z-index: 2; height: 204px;
        width: 1146px;" id="Div2" runat="server">
     
    </div>
   
   
    <div style="position: absolute; left: 491px; top: 180px; z-index: 2; height: 334px;
        width: 334px;" id="Div5" runat="server">
     <h3><u>Float Add/Edit Page(s) [Float Type] :</u></h3><br />
        Float Type Dropdown List:
     
        
        
     <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" 
         CellPadding="4" DataKeyNames="ddFloatTypeID" DataSourceID="SqlDataSource4" 
         ForeColor="#333333" AllowPaging="True" AllowSorting="True" 
         onrowcommand="GridView2_RowCommand">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="ddFloatTypeID" HeaderText="ID" 
                 InsertVisible="False" ReadOnly="True" SortExpression="ddFloatTypeID" />
             <asp:BoundField DataField="FloatType" HeaderText="FloatType" 
                 SortExpression="FloatType" />

                  <asp:ButtonField ButtonType="Image" ImageUrl="images/edit_button25.png" CommandName="UpdateFloatType"
                HeaderText="Modify&nbsp;&nbsp;" Text="Modify" />
            
            <asp:ButtonField ButtonType="Image" CommandName="DeleteFloatType" HeaderText="Delete&nbsp;&nbsp;"
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
     
    <asp:Label ID="floatTypeLbl" runat="server" Text="Add"></asp:Label>  a Float Type:<asp:TextBox 
            ID="txtFloatType" runat="server"></asp:TextBox>
     <asp:Button ID="addFloatType" runat="server" Text="Add" 
            onclick="addFloatType_Click"  />
     <asp:Button ID="applyFloatType" runat="server" Text="Apply" Enabled="False" onclick="applyFloatType_Click"  
          />
     <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
         ConnectionString="<%$ ConnectionStrings:pmsConnectionString1 %>" 
         ProviderName="<%$ ConnectionStrings:pmsConnectionString1.ProviderName %>" 
         SelectCommand="SELECT ddFloatTypeID, FloatType FROM ddFloatType"></asp:SqlDataSource>

     
        
        
    </div>

   
        </form >
</body>
</html>