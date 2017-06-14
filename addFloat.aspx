<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addFloat.aspx.cs" Inherits="addFloat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Administrator Area</title>

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
    <form id="form1" defaultbutton="Button1" runat="server">
    <font color="#990000" size="+3">Administrator Area: Add Floats</font></p>

   

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

    </asp:Panel>
    &nbsp;
    <div id="Layer1" style="position: absolute; left: 10px; top: 160px; width: 1064px;
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
                            DataTextField="oOrganization" DataValueField="pOrgID" 
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
                            AppendDataBoundItems="True" DataSourceID="EntryTypeDS">
                            <asp:ListItem Value="0">-Select Entry Type-</asp:ListItem>
                            

                        </asp:DropDownList>
                        <asp:SqlDataSource ID="EntryTypeDS" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                            SelectCommand="SELECT EntryType FROM ddEntryType ORDER BY EntryType">
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
                            AppendDataBoundItems="True" DataSourceID="FloatTypeDS">
                            <asp:ListItem Value="">-Select Float Type-</asp:ListItem>
                           
                              
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="FloatTypeDS" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                            SelectCommand="SELECT FloatType FROM ddFloatType ORDER BY FloatType">
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
                                SelectCommand="SELECT uID, uFName from user WHERE uStatus ='Administrator'">
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
                                SelectCommand="SELECT Status FROM ddStatus ORDER BY Status">
                            </asp:SqlDataSource>
                    </td>
                </tr>
               
                <tr>
                    <td class="style4">
                      Entry #:
                      
                    </td>
                    <td>
                           <asp:TextBox ID="EntryNo" runat="server" Width="80px"></asp:TextBox>
                            <br /> Current Max. Entry #:<asp:Label ID="maxEntry" runat="server" Text=""></asp:Label>
                    </td>
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
                </table>

                <div  style="position: absolute; left: 305px; top: 20px;  z-index: 5; height: 309px; width: 871px;" >
                <table >
                <tr>
                    <td >
                      
                       Float Description:<br />
                    </td>
                    <td>
                         <asp:TextBox ID="Description" runat="server" TextMode="MultiLine" Height="65px"   Width="331px"></asp:TextBox>
                     

                    </td>
                </tr>
                 <tr>
                    <td >
                      Scripts:<br />
                       
                    </td>
                    <td>
                    
                   
                        <asp:TextBox ID="scriptLbl" runat="server" TextMode="MultiLine" Height="65px" 
                              Width="331px"></asp:TextBox>


                       
                    </td> 
                </tr>
                 <tr>
                    <td >
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
                              Width="671px" ReadOnly="true"   ></asp:TextBox> <br /><br /><br />
                          <asp:CheckBox ID="cTerms" runat="server" 
                              Text="  I accept these Terms &amp; Agreements " />
                          <asp:Label ID="notChecked" Visible = "False" runat="server" ForeColor="Red" Text="You did not accept the Terms and Conditions"></asp:Label>
                          <br />
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
    <br />
    <font color="#FFFFFF">........<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
        <asp:Button ID="Button1" runat="server" Text="  Apply  " 
        onclick="Button1_Click"  /><br /><br />
    </form>
</body>
</html>

