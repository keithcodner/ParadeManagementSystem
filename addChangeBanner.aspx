<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addChangeBanner.aspx.cs" Inherits="addChangeBanner" %>

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
    <font color="#990000" size="+3">Administrator Area: Add/Delete Banners</font></p>
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
    <div style="position: absolute; left: 2px; top: 181px; w z-index: 1; height: 788px;
        width: 2159px;">
        <b>Upload a Banner:</b>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label>
        &nbsp;Image dimensions should be (532 x 230) for best resolution and try to keep 
        each image under 1 megabyte.<br />
        <br />
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
                    Banner Name:</td>
                <td>
                    <asp:TextBox ID="bannerNametxt" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Description:</td>
                <td>
                    <asp:TextBox ID="bannerDesctxt" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Upload File:</td>
                <td>
                    <asp:FileUpload ID="bannerFileUpload" runat="server" Width="194px" />
                &nbsp;(Permitted image types are *.jpg and *.gif)</td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Button ID="BannerBtn" runat="server" Text="Submit" 
                        onclick="BannerBtn_Click" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br /><br />
        <hr><hr>
        <b>Existing Banners: </b><br />
        <br />
        
        </b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <br />
       
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/mypic.png" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Left: &nbsp;
        
        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/bluespacer.png" WIDTH="2" HEIGHT="200" BORDER="0"/>
        &nbsp;&nbsp;&nbsp;&nbsp;Right:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
               
        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/santaface.JPG" />
        
       
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image4" runat="server" BORDER="0" HEIGHT="200" 
            ImageUrl="~/images/bluespacer.png" WIDTH="2" />
        Preview:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/preview.png" />
        
       
        <br />
        <br />
        <br />
      <b>  1.Select which banner you wish to change: </b>
        <br />
        <asp:RadioButton ID="leftBanner" runat="server" Text="Left Banner" GroupName="banner" 
            />
        <asp:RadioButton ID="rightBanner" runat="server" Text="Right Banner" GroupName="banner" 
         />
        <br />
        <br />
        <b>2.Select the image you wish to display: </b>
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="bannerId" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" onrowcommand="GridView1_RowCommand" 
            Width="754px" AllowPaging="True" AllowSorting="True">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="bannerId" HeaderText="ID" 
                    InsertVisible="False" ReadOnly="True" SortExpression="bannerId" />
                <asp:BoundField DataField="bName" HeaderText="Banner Name" 
                    SortExpression="bName" />
                <asp:BoundField DataField="bDescription" HeaderText="Banner Description" 
                    SortExpression="bDescription" />
                     <asp:ButtonField ButtonType="Image" CommandName="Image" HeaderText="Display&nbsp;&nbsp;"
                ImageUrl="images/movie.png" Text="Delete" />
                <asp:ButtonField ButtonType="Image" CommandName="Preview" HeaderText="Preview&nbsp;&nbsp;"
                ImageUrl="images/Zoom.png" Text="Preview" />
                
                    <asp:ButtonField ButtonType="Image" CommandName="DeleteBanner" HeaderText="Delete&nbsp;&nbsp;"
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
            SelectCommand="SELECT bannerId, bName, bDescription FROM bannerTable"></asp:SqlDataSource><br /><br /><br />
             <div style="position: absolute; left: 383px; top: 118px; w z-index: 5; height: 200px; width: 300px;">
                 <asp:Panel ID="confirmPanel" runat="server" Height="200px" Width="300px" 
                     BackColor="#33CC33" BorderColor="#009900" Visible="False" 
                     BorderWidth="4px">
                     <br/><br/><br/><br/><br/><br/>
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
    </div>
    </form>
</body>
</html>

