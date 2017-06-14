<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editFloatDetailsaspx.aspx.cs" Inherits="editFloatDetailsaspx" %>

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

    <script type="text/javascript" src="js/jquery.min2.js"></script>
    <script type="text/javascript" src="js/MaxLength.min.js"></script>
    <script type="text/javascript">
        $(function () {

            //Normal Configuration
            $("[id*=Description]").MaxLength({ MaxLength: 1000 });

            //Normal Configuration
            $("[id*=scriptLbl]").MaxLength({ MaxLength: 1000 });

            //Normal Configuration
            $("[id*=banner]").MaxLength({ MaxLength: 100 });



        });
    </script>

<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000" bgcolor="#ffff99">
    <form id="form1" defaultbutton="searchBtn" runat="server">
    <font color="#990000" size="+3">Administrator Area: Edit Float Details</font></p>
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
                       
                            <ul><li><a href="addOrganization.aspx">Add Organization   </a><ul><li><a href="addFloat.aspx">Add Float</a></li></ul></li></ul>
                        
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
        left: 847px; top: 222px; width: 328px; height: 136px; z-index: 2" 
        Visible="false" DefaultButton="searchBtn" >
        <table>
        <tr>
            <td>
            &nbsp;&nbsp;&nbsp; Advanced Search Options: <br />
            </td>
            <td>

            </td>
        </tr>
        <tr>
            <td>
             &nbsp;&nbsp;
        <asp:RadioButton ID="cParade" runat="server" Text=" Parade" Visible="true"
            GroupName="a" />
            </td>
            <td>
              <asp:RadioButton ID="cContact" runat="server" Text=" Contact" Visible="true" GroupName="a" />
            </td>
        </tr>
         <tr>
            <td>
             &nbsp;&nbsp;
        <asp:RadioButton ID="cOrganization" runat="server" Text=" Organization" Visible="true" GroupName="a" />
            </td>
            <td>
             <asp:RadioButton ID="cFloatType" runat="server" Text=" Float Type" Visible="true" GroupName="a" />
            </td>
        </tr>
         <tr>

            <td>
              &nbsp;&nbsp;
        <asp:RadioButton ID="cWavierAcceptor" runat="server" Text=" Wavier Acceptor" Visible="true" GroupName="a" />
            </td>
            <td>
              <asp:RadioButton ID="cStatus" runat="server" Text=" Status" Visible="true"
            GroupName="a" />
            </td>
        </tr>
         <tr>
            <td>
            &nbsp;&nbsp;
        <asp:RadioButton ID="cEntryType" runat="server" Text=" Entry Type" Visible="true" GroupName="a" />
            </td>
            <td>
            <asp:RadioButton ID="cDesc" runat="server" Text=" Description" Visible="true" GroupName="a" />
            </td>
        </tr>
         <tr>
            <td>
            &nbsp;&nbsp;
        <asp:RadioButton ID="cComments" runat="server" Text=" Comments" Visible="true" GroupName="a" />
            </td>
            <td>
              <asp:RadioButton ID="cApproval" runat="server" Text=" Approval" Visible="true" GroupName="a" />
            </td>
        </tr>
        
       </table>

    </asp:Panel>
    &nbsp;
    <div id="Layer11" style="position: absolute; left: 10px; top: 160px; width: 1064px;
        height: 256px; z-index: 1">
        <asp:Panel ID="Panel1" runat="server" Height="271px">
            Edit items here:<asp:Label ID="test" runat="server" Text="" Visible="false"></asp:Label><br />
            <br />
            <table class="style1">
                <tr>
                    <td class="style4">
                        Parade:
                    </td>
                    <td>
                      <asp:DropDownList ID="Parade" runat="server" Height="20px" Width="158px" 
                            DataTextField="paradeName" DataValueField="paradeName" 
                            AppendDataBoundItems="True" DataSourceID="paradeNames">
                            <asp:ListItem Value="">-Select Parade-</asp:ListItem>
                        </asp:DropDownList>
                        
                        <asp:SqlDataSource ID="paradeNames" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                            SelectCommand="SELECT paradeID, paradeName FROM parade"></asp:SqlDataSource>
                        
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Organization:
                    </td>
                    <td>
                        <asp:DropDownList ID="Organization" runat="server" Height="20px" Width="158px" 
                            DataTextField="oOrganization" DataValueField="oOrganization" 
                            AppendDataBoundItems="True" DataSourceID="OrgName">
                            <asp:ListItem Value="">-Select Organizaiton-</asp:ListItem>
                        </asp:DropDownList>
                       
                        <asp:SqlDataSource ID="OrgName" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                            SelectCommand="SELECT pOrgID, oOrganization FROM orginfo">
                        </asp:SqlDataSource>
                       
                    </td>
                </tr>
                
                <tr>
                    <td class="style4">
                        Entry Type:
                    </td>
                    <td>
                        <asp:DropDownList ID="Entry" runat="server" Height="20px" Width="158px" 
                            DataTextField="EntryType" DataValueField="EntryType" 
                            AppendDataBoundItems="True" DataSourceID="entryTypeDS">
                            <asp:ListItem Value="0">-Select Entry Type-</asp:ListItem>
                       

                        </asp:DropDownList>
                        <asp:SqlDataSource ID="entryTypeDS" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                            SelectCommand="SELECT EntryType FROM ddEntryType ORDER BY EntryType ">
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Float Type:
                    </td>
                    <td>
                        <asp:DropDownList ID="floatType" runat="server" Height="20px" Width="158px" 
                            DataTextField="FloatType" DataValueField="FloatType" 
                            AppendDataBoundItems="True" DataSourceID="floatTypeDS">
                            <asp:ListItem Value="">-Select Float Type-</asp:ListItem>
                            
                              
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="floatTypeDS" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                            SelectCommand="SELECT FloatType FROM ddFloatType ORDER BY FloatType ">
                        </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Float Length(ft) :
                    </td>
                    <td>

                        <asp:TextBox ID="floatLength" runat="server" Text="0" Width="61px"  
                           ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Float Height(ft):
                    </td>
                    <td>
                        <asp:TextBox ID="floatHeight" runat="server" Text="0" Width="61px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Float Width (ft):
                    </td>
                    <td>
                         <asp:TextBox ID="floatWidth" runat="server" Text="0" Width="61px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Marchers:
                    </td>
                    <td>
                         <asp:DropDownList ID="Marchers" runat="server" Height="20px" Width="158px" 
                            DataTextField="uFName" DataValueField="uFName" AppendDataBoundItems="True">
                            <asp:ListItem Value="No">No</asp:ListItem>
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        # of Marchers:
                    </td>
                    <td>
                        <asp:TextBox ID="noOfMarchers" runat="server" Text="0" Width="61px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Sound System:
                    </td>
                    <td>
                        <asp:DropDownList ID="SoundSystem" runat="server" Height="20px" Width="158px">
                            <asp:ListItem Value="No">No</asp:ListItem>
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td class="style4">
                      Waiver Acceptor:
                       
                    </td>
                    <td>
                            <asp:DropDownList ID="Acceptor" runat="server" Height="20px" Width="158px" 
                                DataSourceID="waiverAcceptor" DataTextField="uFName" DataValueField="uFName" AppendDataBoundItems="True">
                            <asp:ListItem Value="0">-Select Acceptor-</asp:ListItem>
                           
                        </asp:DropDownList>
                            <asp:SqlDataSource ID="waiverAcceptor" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                                SelectCommand="SELECT uID, uFName from user WHERE uStatus ='Administrator' AND uActivation = 'Active'">
                            </asp:SqlDataSource>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                      Fee's Received:
                       
                    </td>
                    <td>
                            <asp:DropDownList ID="Fees" runat="server" Height="20px" Width="158px">
                            <asp:ListItem Value="No">No</asp:ListItem>
                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                  <tr>
                    <td class="style4">
                        Amount($):
                       
                    </td>
                    <td>
                           <asp:TextBox ID="Amount" runat="server" Text="0.00" Width="61px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td class="style4">
                      Status:
                       
                    </td>
                    <td>
                            <asp:DropDownList ID="Status" runat="server" Height="20px" Width="158px" AppendDataBoundItems="True"
                                DataSourceID="StatusDS" DataTextField="Status" DataValueField="Status">
                            <asp:ListItem Value="New">New</asp:ListItem>
                        </asp:DropDownList>
                            <asp:SqlDataSource ID="StatusDS" runat="server" 
                                ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                                ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                                SelectCommand="SELECT Status FROM ddStatus ORDER BY Status ">
                            </asp:SqlDataSource>
                    </td>
                </tr>
               
                <tr>
                    <td class="style4">
                      Entry #:
                       
                    </td>
                    <td>
                           <asp:TextBox ID="EntryNo" runat="server" Width="80px"></asp:TextBox>
                           &nbsp;<br /> Current Max. Entry :<asp:Label ID="maxEntry" runat="server" Text=""></asp:Label>
&nbsp;</td>
                </tr>
                <tr>
                    <td class="style4">
                      Entry Code:
                      
                    </td>
                    <td>
                           <asp:TextBox ID="entryCode" runat="server" Width="80px"></asp:TextBox>
                            <br /> 
                    </td>
                </tr>
                                <tr>
                    <td class="style4">
                      <asp:Button ID="Button1" runat="server" Text="  Apply  " 
        onclick="Button1_Click"  />
                      
                    </td>
                    <td>
                          
                            <br /> 
                    </td>
                </tr>
                <caption>
                    <br />
                </caption>
                </table>

                <div style="position: absolute; left: 305px; top: 20px;  z-index: 2; height: 309px; width: 539px;">
                <table class="style1">
                <tr>
                    <td class="style4">
                      
                       Float Description:<br />
                    </td>
                    <td>
                         <asp:TextBox ID="Description" runat="server" TextMode="MultiLine" Height="65px" 
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
                    </td>
                </tr>
                 <tr>
                    <td class="style4">
                      Banner:<br />
                       
                    </td>
                    <td>
                          <asp:TextBox ID="banner" runat="server" TextMode="MultiLine" Height="38px" 
                              Width="332px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td class="style4">
                      Waiver:
                       
                    </td>
                    <td>
                          <asp:TextBox ID="Waiver" runat="server" TextMode="MultiLine" Height="220px" 
                              Width="588px" ReadOnly="true" ontextchanged="Waiver_TextChanged"  ></asp:TextBox> 
                    </td>
                </tr>

              
            </table>
            </div>
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
    <br /><br />
    <font color="#FFFFFF">........
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        
        <br />
    </font>
    
    
    <br />
    
    <br /><br /><br />
    <br />
    <br />
    <br /><br /><br />
        <asp:Label ID="Label1" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="Label2" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="Label3" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="" Visible="false"></asp:Label>
        <asp:Label ID="Label5" runat="server" Text="" Visible="false"></asp:Label>
    All Parade Organization Information:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Search by
    <asp:Label ID="searchLbl" runat="server" Text="Name"></asp:Label>
    :&nbsp;
    <asp:TextBox ID="searchTxt" runat="server" 
       ></asp:TextBox>
    <asp:Button ID="searchBtn" runat="server" Text="Search" 
        onclick="searchBtn_Click"  />
    &nbsp;<asp:Button ID="advSearch" runat="server" Text="Advanced Search" 
        onclick="advSearch_Click"  />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Export Table:<asp:ImageButton 
        ID="ImageButton1" runat="server" ImageUrl="~/images/Download.png" 
        onclick="ImageButton1_Click" /> &nbsp;&nbsp;&nbsp; Toggle Lock All Scripts to : 
    <asp:CheckBox ID="safeCheck" runat="server" AutoPostBack="True" 
        oncheckedchanged="safeCheck_CheckedChanged" />
    <asp:Button ID="lockAllScriptBtn" runat="server" Text="Locked" Enabled="False" 
        onclick="lockAllScriptBtn_Click"/>
    <br /><br />
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
        DataSourceID="SqlDataSource2" ForeColor="Black" OnRowCommand="GridView1_RowCommand"
        DataKeyNames="floatID" PageSize="4" BackColor="White" 
        BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
        AllowPaging="True" AllowSorting="True" >
        <Columns>
            <asp:BoundField DataField="floatID" HeaderText="Float ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="floatID" />
            <asp:BoundField DataField="porgID" HeaderText="Org ID" 
                SortExpression="porgID" />
            <asp:BoundField DataField="parade" HeaderText="Parade" 
                SortExpression="parade" />
            <asp:BoundField DataField="contact" HeaderText="Contact" 
                SortExpression="contact" />
            <asp:BoundField DataField="organization" HeaderText="Org." 
                SortExpression="organization" />
            <asp:BoundField DataField="entry" HeaderText="Entry" 
                SortExpression="entry" />
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
            <asp:BoundField DataField="floatDesc" HeaderText="Desc." 
                SortExpression="floatDesc" />
            <asp:BoundField DataField="comments" HeaderText="Script" 
                SortExpression="comments" />
                <asp:BoundField DataField="banner" HeaderText="Banner" 
                SortExpression="banner" />
            <asp:BoundField DataField="approved" HeaderText="Approval" 
                SortExpression="approved" />
                <asp:BoundField DataField="scriptLock" HeaderText="Script Lck." 
                SortExpression="scriptLock" />
                 <asp:ButtonField ButtonType="Image" ImageUrl="images/Lock.png" CommandName="scriptLock"
                HeaderText="Lock Toggle&nbsp;&nbsp;" Text="Mod." />
                <asp:ButtonField ButtonType="Image" ImageUrl="images/edit_button25.png" CommandName="UpdateFloat"
                HeaderText="Mod.&nbsp;&nbsp;" Text="Mod." />
            <asp:ButtonField ButtonType="Image" ImageUrl="images/list_add.png" CommandName="approved"
                HeaderText="Appr.&nbsp;&nbsp;" Text="Appr." />
            <asp:ButtonField ButtonType="Image" CommandName="notApproved" HeaderText="Not Appr.&nbsp;&nbsp;"
                ImageUrl="images/list_minus.png" Text="Not Appr." />
            <asp:ButtonField ButtonType="Image" CommandName="DeleteFloat" HeaderText="Delete&nbsp;&nbsp;"
                ImageUrl="images/delete_button25.png" Text="Delete" />
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
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
        ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
        ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" SelectCommand="SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved, scriptLock
FROM floatdetails"></asp:SqlDataSource>
    

    <div style="position: absolute; left: 535px; top: 380px;  z-index: 5; height: 243px; width: 339px;">
                 <asp:Panel ID="confirmPanel" runat="server" Height="226px" Width="303px" 
                     BackColor="#33CC33" BorderColor="#009900" Visible="False" 
                     BorderWidth="4px">
                     
                     <br/><br/><br/><br/><br/><br/><br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:CheckBox ID="disableConfirm" runat="server" 
                         Text=" Click to Disable Confirmations" Visible="False" />
                     <br/>
                     &nbsp;&nbsp;&nbsp;
                  <div style="position: absolute; left: 20px; top: 27px;  z-index: 6; height: 31px; width: 259px; ">  <p> &nbsp;&nbsp;&nbsp;<asp:Label ID="AlertLbl" runat="server" Text=""></asp:Label> </p></div>
                 <br/>
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="ConfirmBtn" runat="server" Text="Confirm" 
                         Height="33px" Width="97px" onclick="ConfirmBtn_Click" />
                     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                     <asp:Button ID="CanelBtn" runat="server" Text="Cancel" 
                         Height="34px" Width="89px" onclick="CanelBtn_Click" />
                 </asp:Panel>
        </div>
    </form>
</body>
</html>
