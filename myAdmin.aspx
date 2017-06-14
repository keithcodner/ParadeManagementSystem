<%@ Page Language="C#" AutoEventWireup="true" CodeFile="myAdmin.aspx.cs" Inherits="myAdmin" %>

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
    <form id="form1" runat="server">
    <font color="#990000" size="+3">Administrator Area: MyAdmin Area</font></p>
    <div id="Layer1" style="position: absolute; left: 62px; top: 64px; width: 397px;
        height: 111px; z-index: 4">
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
                    <li><a href="#">Tools</a><ul>
                        <li><a href="addChangebanner.aspx">Add/Delete Banner</a></li><li><a href="addChangeWaiveraspx.aspx">
                            Add/Delete Waiver</a></li><li><a href="trasnferOrg.aspx">Transfer Org. Or User</a></li> <li><a href="DropdownMods.aspx">DropdownList Mods</a></li><li><a href="activityLog.aspx">Activity Log</a></li><li><a href="Donwloads.aspx">Manage Downloads</a></li><li><a href="adminEmail.aspx">Email Settings</a></li></ul>
                    </li>
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
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
   
    <div style="position: absolute; left: 34px; top: 237px; z-index: 3; height: 247px;
        width: 518px;">
       
        <br />
        Make Notes:<br />
        <br />
        Title:&nbsp; <asp:TextBox ID="noteTitle" runat="server"></asp:TextBox>
        <br />
        <br />
        Body:
        <asp:TextBox ID="noteBody" runat="server" Height="288px" TextMode="MultiLine" 
            Width="456px"></asp:TextBox>
            
       
    </div>
    
     <div style="position: absolute; left: 35px; top: 165px; z-index: 3; height: 38px;
        width: 1083px;">
        <h2>Welcome
            <asp:Label ID="getUFName" runat="server" Text=""></asp:Label>&nbsp;<asp:Label ID="getULName" runat="server" Text=""></asp:Label>, 
            Today's date is
            <asp:Label ID="day" runat="server" Text="Label"></asp:Label>
            &nbsp;<asp:Label ID="month" runat="server" Text="Label"></asp:Label>&nbsp;<asp:Label
                ID="monthInt" runat="server" Text="Label"></asp:Label>, &nbsp;&nbsp;<asp:Label ID="year"
                    runat="server" Text="Label"></asp:Label></h2>
    </div>
    <div style="position: absolute; left: 25px; top: 647px; z-index: 3; height: 40px;
        width: 1463px;">

            

            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="noteSubmit" runat="server" Text=" Submit " 
                onclick="noteSubmit_Click" />

            &nbsp;
            <asp:Button ID="noteApply" runat="server" Text=" Apply " onclick="noteApply_Click" 
                />
            <br /><br />

            <hr />

    </div>
    <p>
        &nbsp;</p>
    <div style="position: absolute; left: 589px; top: 401px; z-index: 3; height: 254px;
        width: 338px;">
         <asp:BulletedList  
             ID="BulletedList1"  
             runat="server"  
             Visible="false"  
             >  
        </asp:BulletedList>  
           <asp:Calendar  
            ID="Calendar1"   
            runat="server"  
            NextPrevFormat="FullMonth"  
            ForeColor="WhiteSmoke"  
            SelectionMode="Day"  
            DayNameFormat="Full"  
            Font-Names="Book Antiqua"  
            Font-Size="Medium"  
            OnSelectionChanged="Calendar1_SelectionChanged"  
            >  
            <DayHeaderStyle  
                 BackColor="OliveDrab"  
                 />  
            <DayStyle  
                 BackColor="DarkOrange"  
                 BorderColor="Orange"  
                 BorderWidth="1"  
                 Font-Bold="true"  
                 Font-Italic="true"  
                 Font-Size="Large"  
                 />  
            <NextPrevStyle  
                 Font-Italic="true"  
                 Font-Names="Arial CE"  
                 />  
            <OtherMonthDayStyle BackColor="Tomato" />  
            <SelectedDayStyle  
                 BackColor="Green"  
                 BorderColor="MediumSeaGreen"  
                 />  
            <TitleStyle  
                 BackColor="MidnightBlue"  
                 Height="36"  
                 Font-Size="Large"  
                 Font-Names="Courier New Baltic"  
                 />  
        </asp:Calendar>  
       
    </div>
    <div style="border: 0px solid blue; position: absolute; left: 26px; top: 714px; z-index: 4; height: 171px;
        width: 1264px;">
        
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" BorderStyle="Solid" 
            CellPadding="4" DataKeyNames="noteID" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" Width="1924px" onrowcommand="GridView1_RowCommand" 
            PageSize="3">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="noteID" HeaderText="ID" InsertVisible="False" 
                    ReadOnly="True" SortExpression="noteID" />
                <asp:BoundField DataField="noteDate" HeaderText="Date" 
                    SortExpression="noteDate" />
                <asp:BoundField DataField="noteName" HeaderText="Title" 
                    SortExpression="noteName" />
                <asp:BoundField DataField="noteBody" HeaderText="Body" 
                    SortExpression="noteBody" />
                    <asp:ButtonField ButtonType="Image" ImageUrl="images/edit_button25.png" CommandName="UpdateNote"
                HeaderText="Modify&nbsp;&nbsp;" Text="Modify" />
            
            <asp:ButtonField ButtonType="Image" CommandName="DeleteNote" HeaderText="Delete&nbsp;&nbsp;"
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
            SelectCommand="SELECT noteID, noteDate, noteName, noteBody FROM datenote">
        </asp:SqlDataSource>
        
    </div>
    <div   style="border: 0px solid blue; position: absolute; top: 224px; left: 566px; height: 106px; width: 667px; ">
        
        
       
        
        Search Notes by <asp:Label ID="searchSubject" runat="server" Text="Title"></asp:Label>:<asp:TextBox ID="searchTxt" runat="server"></asp:TextBox>
        <asp:Button ID="search" runat="server" Text=" Search " onclick="search_Click" />
        &nbsp;<asp:Button ID="advSearch" runat="server" Text="Advanced Search" 
            Width="171px" onclick="advSearch_Click" />
        
        
       
        
       
        <br /><br />
        <asp:Panel ID="AdvSearchPanel" runat="server" Visible="False" 
            BorderColor="Silver" BorderWidth="2px" Width="451px" Height="125px"> <br />&nbsp;&nbsp; 
            Search By:<br /><br />
            &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp; 
            <asp:RadioButton ID="TitleRB" runat="server" Text=" Title" GroupName="a" />
            

            &nbsp;&nbsp;
            <asp:RadioButton ID="BodyRB" runat="server" Text=" Word in Body" GroupName="a" />
            &nbsp;&nbsp;
            <asp:RadioButton ID="DateRB" runat="server" Text=" Date" GroupName="a" />
            &nbsp;&nbsp;
            <asp:RadioButton ID="IDRB" runat="server" Text=" ID" GroupName="a" />
            <br /><br />
            &nbsp;&nbsp; Search by Date format must be YYYY-MM-DD :
        </asp:Panel>
        
        
       
        
    </div>

    <div style="border: 0px solid blue; position: absolute; left: 588px; top: 625px; z-index: 4; height: 26px;
        width: 127px;">
       
    </div>

      <div style="position: absolute; left: 825px; top: 625px; z-index: 4; height: 44px;
        width: 406px;">
        
    &nbsp;Save selected dates:
       
        <asp:Button ID="saveDateBtn" runat="server" onclick="Button1_Click" Text="  Save!  " />
       
    </div>


    </form>
</body>
</html>