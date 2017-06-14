<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminEmail.aspx.cs" Inherits="adminEmail" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

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
        <script type="text/javascript">

            //for Email port validation
            function emailPort(e) {
                var key = window.event ? e.keyCode : e.which;
                var keychar = String.fromCharCode(key);
                var reg = new RegExp("[0-9]")
                if (key == 8) {
                    keychar = String.fromCharCode(key);
                }
                if (key == 13) {
                    key = 8;
                    keychar = String.fromCharCode(key);
                }
                return reg.test(keychar);
            }

            //for email testing text field
            function emailTestTxt(e) {
                var key = window.event ? e.keyCode : e.which;
                var keychar = String.fromCharCode(key);
                var reg = new RegExp("[a-zA-Z0-9._%-@]")
                if (key == 8) {
                    keychar = String.fromCharCode(key);
                }
                if (key == 13) {
                    key = 8;
                    keychar = String.fromCharCode(key);
                }
                return reg.test(keychar);
            }

            //for host address
            function hostAddress(e) {
                var key = window.event ? e.keyCode : e.which;
                var keychar = String.fromCharCode(key);
                var reg = new RegExp("[a-zA-Z0-9._%-@]")
                if (key == 8) {
                    keychar = String.fromCharCode(key);
                }
                if (key == 13) {
                    key = 8;
                    keychar = String.fromCharCode(key);
                }
                return reg.test(keychar);
            }

</script>
<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000" bgcolor="#ffff99">
<form id="form1" runat="server">

 
<font color="#990000" size="+3">Administrator Area:  Assign Automated Email Sending </font></p>
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
                    <li><a href="#">Tools</a><ul>
                        <li><a href="addChangebanner.aspx">Add/Delete Banner</a></li><li><a href="addChangeWaiveraspx.aspx">
                            Add/Delete Waiver</a></li> <li><a href="trasnferOrg.aspx">Transfer Org. Or User</a></li> <li><a href="DropdownMods.aspx">DropdownList Mods</a></li><li><a href="activityLog.aspx">Activity Log</a></li><li><a href="Donwloads.aspx">Manage Downloads</a></li><li><a href="adminEmail.aspx">Email Settings</a></li></ul>
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
    <br /><br /><br />
    <br />
    <br />
    <br /><b>View/Edit the auto sending pre-texted email messages:</b><br />
    <br /> 
    

        &nbsp;&nbsp;
             
        
    
    <div id="spare" runat="server" Visible="false" style="border: 5px solid blue; position: absolute; left: 259px; top: 184px; z-index: 4; height: 77px;
        width: 741px; background-color: #FF6600;">
     
        
        
        
       
        Options: <br /><br />
     &nbsp;&nbsp;&nbsp;&nbsp;   <asp:RadioButton ID="deleteFloatTran" runat="server" 
            Text="   Delete floats when organization  is transferred." />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
    </div>

    <div id="Div1"  runat="server" style="position: absolute; left: 18px; top: 215px; z-index: 5; height: 612px;
        width: 1520px;" >
    
         
    <asp:ToolkitScriptManager  ID="toolkitscriptmgr" runat="server">
     
   </asp:ToolkitScriptManager >
    <asp:TabContainer ID="emailForUsers" runat="server" ActiveTabIndex="0" 
            Height="504px" Width="1502px">
            <asp:TabPanel ID="adminTab" runat="server" HeaderText="Admin Activation Email">
                <ContentTemplate>
                     <div id="Div2"  runat="server" style="position: absolute; left: 698px; top: 85px; z-index: 6; height: 384px;
        width: 798px;" >
        <table class="style1">
               <tr>
                    <td>
                        Activation Footer:</td>
                    <td>
                        <asp:TextBox ID="ActivationFooter" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Footer:</td>
                    <td>
                        <asp:TextBox ID="inActivationFooter" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                 <tr>
                    <td>
                        SMTP Host Address:</td>
                    <td>
                        <asp:TextBox ID="hostAddress" runat="server" Width="280px" ReadOnly="True"></asp:TextBox>
                        *Applies to all</td>
                </tr>
                 <tr>
                    <td>
                        Port:</td>
                    <td>
                        <asp:TextBox ID="emailPort" runat="server" ReadOnly="True" 
                            ></asp:TextBox>
                        *Applies to all</td>
                        <asp:MaskedEditExtender runat="server"  ID="emailPortMEE" Mask="9999"
        TargetControlID="emailPort" ></asp:MaskedEditExtender> 
                </tr>
                 <tr>
                    <td>
                        Username:</td>
                    <td>
                        <asp:TextBox ID="emailUsername" runat="server" ReadOnly="True"></asp:TextBox>
                        *Applies to all</td>
                </tr>
                 <tr>
                    <td>
                        Password:</td>
                    <td>
                        <asp:TextBox ID="emailPassword" runat="server" ReadOnly="True" 
                            TextMode="Password"></asp:TextBox>
                        *Password must be set every time an update is made. *Applies to this tab</td>
                </tr>
                
                 <tr>
                    <td>
                        <asp:Button ID="editEmail" runat="server" Text="  Edit  " 
                            onclick="editEmail_Click" />
                        &nbsp;&nbsp;
                     </td>
                    <td>
                        <asp:Button ID="updateEmail" runat="server" Text="Update" 
                            onclick="updateEmail_Click" />
                     </td>
                </tr>

            </table>
        </div>
        <div id="Div3"  runat="server" style="position: absolute; left: 21px; top: 84px; z-index: 6; height: 464px;
        width: 661px;" >
            <table class="style1">
                <tr>
                    <td>
                        From Address:</td>
                    <td>
                        <asp:TextBox ID="adminFromAddress" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                        *Applies to all</td>
                </tr>
                <tr>
                    <td>
                        Activation Subject:</td>
                    <td>
                        <asp:TextBox ID="activationSubject" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Subject :</td>
                    <td>
                        <asp:TextBox ID="inActivationSubject" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        Activation&nbsp; Body:</td>
                    <td>
                        <asp:TextBox ID="ActivationBody" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Body:</td>
                    <td>
                        <asp:TextBox ID="inActivationBody" runat="server" Width="374px" Height="151px" 
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                
                </tr>

            </table>
                     <br />
            Enter an email adress to test these settings:
            <asp:TextBox ID="emailTestTxt" runat="server" ReadOnly="false" Width="237px"></asp:TextBox>
            &nbsp;<asp:Button ID="testEmailSettings" runat="server"  
                Text="  Test  " onclick="testEmailSettings_Click" />
                     <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="checkIfEmailWasSent" runat="server"></asp:Label>
                     </div>
                     <h3> Auto Pre-Text Admin Active/In-Activation Email</h3>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="partTab" runat="server" HeaderText="Participant Activation Email">
                <ContentTemplate>
                    <div id="Div4"  runat="server" style="position: absolute; left: 698px; top: 85px; z-index: 6; height: 384px;
        width: 661px;" >
        <table class="style1">
               <tr>
                    <td>
                        Activation Footer:</td>
                    <td>
                        <asp:TextBox ID="partActiveFooter" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Footer:</td>
                    <td>
                        <asp:TextBox ID="partInactiveFooter" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        <asp:Button ID="partEditBtn" runat="server" Text="  Edit  " onclick="partEditBtn_Click" 
                            />
                        &nbsp;&nbsp;
                     </td>
                    <td>
                        <asp:Button ID="partUpdateBtn" runat="server" Text="Update" onclick="partUpdateBtn_Click" 
                          enabled="false"  />
                     </td>
                </tr>

            </table>
        </div>
        <div id="Div5"  runat="server" style="position: absolute; left: 21px; top: 84px; z-index: 6; height: 384px;
        width: 661px;" >
            <table class="style1">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Activation Subject:</td>
                    <td>
                        <asp:TextBox ID="partActiveSubject" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Subject :</td>
                    <td>
                        <asp:TextBox ID="partInactiveSubject" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        Activation&nbsp; Body:</td>
                    <td>
                        <asp:TextBox ID="partActiveBody" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Body:</td>
                    <td>
                        <asp:TextBox ID="partInactiveBody" runat="server" Width="374px" Height="151px" 
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                
                </tr>

            </table>
                     </div>
                     <h3> Auto Pre-Text Participant Active/In-Activation Email</h3>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="volTab" runat="server" HeaderText="Volunteer Activation Email">
            <ContentTemplate>
                    <div id="Div6"  runat="server" style="position: absolute; left: 698px; top: 85px; z-index: 6; height: 384px;
        width: 661px;" >
        <table class="style1">
               <tr>
                    <td>
                        Activation Footer:</td>
                    <td>
                        <asp:TextBox ID="volActivefooter" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Footer:</td>
                    <td>
                        <asp:TextBox ID="volInActiveFooter" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        <asp:Button ID="volEdit" runat="server" Text="  Edit  "  onclick="volEdit_Click"
                             />
                        &nbsp;&nbsp;
                     </td>
                    <td>
                        <asp:Button ID="volUpdate" runat="server" Text="Update"  enabled="False" onclick="volUpdate_Click" 
                            />
                     </td>
                </tr>

            </table>
        </div>
        <div id="Div7"  runat="server" style="position: absolute; left: 21px; top: 84px; z-index: 6; height: 384px;
        width: 661px;" >
            <table class="style1">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Activation Subject:</td>
                    <td>
                        <asp:TextBox ID="volActiveSubject" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Subject :</td>
                    <td>
                        <asp:TextBox ID="volInActiveSubject" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        Activation&nbsp; Body:</td>
                    <td>
                        <asp:TextBox ID="volActiveBody" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Body:</td>
                    <td>
                        <asp:TextBox ID="volInActiveBody" runat="server" Width="374px" Height="151px" 
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                
                </tr>

            </table>
                     </div>
                     <h3> Auto Pre-Text Volunteer Active/In-Activation Email</h3>
                </ContentTemplate>
            </asp:TabPanel>
            <asp:TabPanel ID="orgTab" runat="server" HeaderText="Organization Activation Email">
                <HeaderTemplate>
                    Organization Activation Email
                </HeaderTemplate>
            <ContentTemplate>
                    <div id="Div8"  runat="server" style="position: absolute; left: 698px; top: 85px; z-index: 6; height: 384px;
        width: 661px;" >
        <table class="style1">
               <tr>
                    <td>
                        Activation Footer:</td>
                    <td>
                        <asp:TextBox ID="orgActivationFooter" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Footer:</td>
                    <td>
                        <asp:TextBox ID="orgInActivationFooter" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        <asp:Button ID="orgEdit" runat="server" Text="  Edit  " onclick="orgEdit_Click" 
                            />
                        &nbsp;&nbsp;
                     </td>
                    <td>
                        <asp:Button ID="orgupdate" runat="server" Text="Update" onclick="orgupdate_Click" 
                         enabled="False"  />
                     </td>
                </tr>

            </table>
        </div>
        <div id="Div9"  runat="server" style="position: absolute; left: 21px; top: 84px; z-index: 6; height: 384px;
        width: 661px;" >
            <table class="style1">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Activation Subject:</td>
                    <td>
                        <asp:TextBox ID="orgActivationSubject" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Subject :</td>
                    <td>
                        <asp:TextBox ID="orgInActivationSubject" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        Activation&nbsp; Body:</td>
                    <td>
                        <asp:TextBox ID="orgActivationBody" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Body:</td>
                    <td>
                        <asp:TextBox ID="orgInActivationBody" runat="server" Width="374px" Height="151px" 
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                
                </tr>

            </table>
                     </div>
                     <h3> Auto Pre-Text Organization Active/In-Activation Email</h3>
                </ContentTemplate>
            </asp:TabPanel>

            <asp:TabPanel ID="floatTab" runat="server" HeaderText="Float Approval Email">
            <ContentTemplate>
                    <div id="Div10"  runat="server" style="position: absolute; left: 698px; top: 85px; z-index: 6; height: 384px;
        width: 661px;" >
        <table class="style1">
               <tr>
                    <td>
                        Activation Footer:</td>
                    <td>
                        <asp:TextBox ID="floatActiveFooter" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Footer:</td>
                    <td>
                        <asp:TextBox ID="floatInActiveFooter" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        <asp:Button ID="floatEdit" runat="server" Text="  Edit  " onclick="floatEdit_Click" 
                            />
                        &nbsp;&nbsp;
                     </td>
                    <td>
                        <asp:Button ID="floatUpdate" runat="server" Text="Update" onclick="floatUpdate_Click" 
                           enabled = "false" />
                     </td>
                </tr>

            </table>
        </div>
        <div id="Div11"  runat="server" style="position: absolute; left: 21px; top: 84px; z-index: 6; height: 384px;
        width: 661px;" >
            <table class="style1">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Activation Subject:</td>
                    <td>
                        <asp:TextBox ID="floatActiveSubject" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Subject :</td>
                    <td>
                        <asp:TextBox ID="floatInActivesSubject" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        Activation&nbsp; Body:</td>
                    <td>
                        <asp:TextBox ID="floatActiveBody" runat="server" Width="374px" Height="151px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        In-Activation Body:</td>
                    <td>
                        <asp:TextBox ID="floatInActiveBody" runat="server" Width="374px" Height="151px" 
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                
                </tr>

            </table>
                     </div>
                     <h3> Auto Pre-Text Float Active/In-Activation Email</h3>
                </ContentTemplate>

            </asp:TabPanel>


             <asp:TabPanel ID="createdAccount" runat="server" HeaderText="Account Created">
            <ContentTemplate>
             <div id="Div12"  runat="server" style="position: absolute; left: 698px; top: 85px; z-index: 6; height: 384px;
        width: 661px;" >
        <table class="style1">
               <tr>
                    <td>
                        User Footer:</td>
                    <td>
                        <asp:TextBox ID="userFooter" runat="server" Width="374px" Height="84px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        Organization Footer:</td>
                    <td>
                        <asp:TextBox ID="orgFooter" runat="server" Width="374px" Height="84px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                     </tr>
                       <tr>
                    <td>
                        Float Footer:</td>
                    <td>
                        <asp:TextBox ID="floatFooter" runat="server" Width="374px" Height="84px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                     </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                 <tr>
                    <td>
                        <asp:Button ID="createEdit" runat="server" Text="  Edit  " onclick="createEdit_Click"  
                            />
                        &nbsp;&nbsp;
                     </td>
                    <td>
                        <asp:Button ID="createUpdate" runat="server" Text="Update"  
                         enabled="False" onclick="createUpdate_Click"  />
                     </td>
                </tr>

            </table>
        </div>
        <div id="Div13"  runat="server" style="position: absolute; left: 21px; top: 84px; z-index: 6; height: 384px;
        width: 661px;" >
            <table class="style1">
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        User Subject:</td>
                    <td>
                        <asp:TextBox ID="userSubject" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Organization Subject:</td>
                    <td>
                        <asp:TextBox ID="orgSubject" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Float Subject :</td>
                    <td>
                        <asp:TextBox ID="floatSubject" runat="server" Width="317px" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        User&nbsp; Body:</td>
                    <td>
                        <asp:TextBox ID="userBody" runat="server" Width="374px" Height="84px"  
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                 <tr>
                    <td>
                        Organization Body:</td>
                    <td>
                        <asp:TextBox ID="orgBody" runat="server" Width="374px" Height="84px" 
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                <tr>
                    <td>
                        Float Body:</td>
                    <td>
                        <asp:TextBox ID="floatBody" runat="server" Width="374px" Height="84px" 
                            TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                     </td>
                </tr>
                </tr>

            </table>
                     </div>
            <h3> Automated Email Sending for User/Organizations/Floats</h3>
             </ContentTemplate>           
              </asp:TabPanel>
            
            
        </asp:TabContainer>
    
       
    
        
        
    </div>
   
   
        <p>
            &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    &nbsp;</p>
<p>
    <asp:Label ID="reply" runat="server" Text=""></asp:Label>
</p>
   
   
        </form >
</body>
</html>
