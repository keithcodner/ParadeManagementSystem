<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Donwloads.aspx.cs" Inherits="Donwloads" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server"><link rel="shortcut icon" href="images/santaIcon.ico" />
    <title>Administrator Area</title>
    <style type="text/css"> body{padding:5px; font-family:Helvetica, Arial, Sans-Serif; color:Black;} *{padding:0; margin:0 0 0 84;
        }
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

        .style1
        {
            width: 187px;
        }

    </style>

        <script type="text/javascript" src="js\jquery.min.js"></script>
        <script type="text/javascript" src="js\scrolltopcontrol.js"></script>
<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000" bgcolor="#ffff99">
<form id="form1" runat="server">

 
<font color="#990000" size="+3">Administrator Area: Manage Downloads</font>
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
    

    <br /> &nbsp;<a name="gettingStarted"></a></a><div style="position: absolute; left: 23px; top: 433px; z-index: 2; height: 636px;
        width: 1431px;" id="Div3" runat="server">
     <h3><u>Download List:</u></h3> *File will have to be deleted and re-uploaded if you wish to change the name.&nbsp;&nbsp; <br />
    Maximum upload size is 60MB:<asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
&nbsp;<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
         CellPadding="4" DataKeyNames="downloadID" DataSourceID="SqlDataSource2" 
         ForeColor="#333333" AllowPaging="True" AllowSorting="True" 
         onrowcommand="GridView1_RowCommand" Width="1532px" PageSize="19" 
         Height="339px">
         <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
         <Columns>
             <asp:BoundField DataField="downloadID" HeaderText="ID" 
                 InsertVisible="False" ReadOnly="True" SortExpression="downloadID" />
             <asp:BoundField DataField="dFileDate" HeaderText="File Date" DataFormatString="{0:d}"
                 SortExpression="dFileDate" />
                 
             <asp:BoundField DataField="dFileName" HeaderText="File Name" 
                 SortExpression="dFileName" />
             <asp:BoundField DataField="dDescription" HeaderText="File Description" 
                 SortExpression="dDescription" />
                 <asp:BoundField DataField="dFileUserType" HeaderText="File User Type" 
                 SortExpression="dFileUserType" />
                 
                  <asp:ButtonField ButtonType="Image" ImageUrl="images/edit_button25.png" CommandName="UpdateDownload"
                HeaderText="Modify&nbsp;&nbsp;" Text="Modify" />
                  <asp:ButtonField ButtonType="Image" ImageUrl="images/Load.png" CommandName="Download"
                HeaderText="Download&nbsp;&nbsp;" Text="Download" />
                <asp:ButtonField ButtonType="Image" CommandName="DeleteDownload" HeaderText="Delete&nbsp;&nbsp;"
                ImageUrl="images/delete_button25.png" Text="Delete" />
         </Columns>
         <EditRowStyle BackColor="#999999" />
         <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
         <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#E9E7E2" />
         <SortedAscendingHeaderStyle BackColor="#506C8C" />
         <SortedDescendingCellStyle BackColor="#FFFDF8" />
         <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
     </asp:GridView>
     
     
        
        
    </div>

    <div style="position: absolute; left: 45px; top: 144px; z-index: 2; height: 159px;
        width: 1146px;" id="Div2" runat="server">
        <h2>Upload File's for Users to Download:</h2><br />
        <table>
            <tr>
                <td><asp:Label ID="fileName" runat="server" Text="File Name"></asp:Label>  : </td>
                <td class="style1"> <asp:TextBox ID="txtFileName" runat="server"></asp:TextBox> </td>
            </tr>
            <tr>
               <td><asp:Label ID="Label1" runat="server" Text="Browse for File"></asp:Label> : </td>
               <td class="style1">    <asp:FileUpload ID="uploadControl" runat="server" 
                       Width="371px" /> </td>
            </tr>
             <tr>
                <td>
                    <asp:Label ID="fileTypeForUser" runat="server" Text="File User Type"></asp:Label>
                    : </td>
                <td class="style1"> 
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="179px">
                        <asp:ListItem Value="Both">Both</asp:ListItem>
                        <asp:ListItem Value="Admin">Admin</asp:ListItem>
                         <asp:ListItem Value="Participant">Participant</asp:ListItem>
                          <asp:ListItem Value="Volunteer">Volunteer</asp:ListItem>
                    </asp:DropDownList> </td>
            </tr>
            <tr>
                <td> <asp:Label ID="fileDesc" runat="server" Text="File Description"></asp:Label> : </td>
                <td class="style1"> <asp:TextBox 
            ID="txtFielDesc" runat="server" Height="89px" TextMode="MultiLine" Width="502px"></asp:TextBox> </td>
            </tr>
           
            <tr>
               <td></td>
               <td class="style1">  </td>
            </tr>
             <tr>
               <td><asp:Button ID="addFile" runat="server" Text="Add" Enabled="True" onclick="addFile_Click" 
          />  &nbsp; 
                   <asp:Button ID="apply" runat="server" Text="Apply" Enabled = "false" 
                       onclick="apply_Click" /></td>
               <td class="style1">  </td>
            </tr>
        </table>
     
   
      
     <br /><br />
     
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
         ConnectionString="<%$ ConnectionStrings:pmsConnectionString1 %>" 
         ProviderName="<%$ ConnectionStrings:pmsConnectionString1.ProviderName %>" 
         SelectCommand="SELECT downloadID, dFileName, dDescription, dFileDate, dFileUserType FROM download ORDER BY downloadID DESC"></asp:SqlDataSource>

     
        
        
    </div>
   
   
        </form >
</body>
</html>
