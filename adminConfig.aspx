<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminConfig.aspx.cs" Inherits="adminConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"><link rel="shortcut icon" href="images/santaIcon.ico" />
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
    
    <SCRIPT type="text/javascript">

        function setScrollText(e) {
            var key = window.event ? e.keyCode : e.which;
            var keychar = String.fromCharCode(key);
            var reg = new RegExp("[A-Z0-9._%-@]");
            if (key == 8) {
                keychar = String.fromCharCode(key);
            }
            if (key == 13) {
                key = 8;
                keychar = String.fromCharCode(key);
            }
            return reg.test(keychar);
        }

</SCRIPT>

<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="Silver" vlink="#990000" bgcolor="#ffff99">
    <form id="form1" defaultbutton="ConfirmBtn" runat="server">
    <font color="#990000" size="+3">Administrator Area: Parade Configuration</font></p>
    <div id="Layer1" style="position: absolute; left: 62px; top: 64px; width: 397px;
        height: 111px; z-index: 8">
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
    <div style="position: absolute; left: 18px; top: 155px; w z-index: 1; height: 520px;
        width: 1267px;">
        Configure the Parade Managerment System:
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False" ForeColor="Red"></asp:Label>
        <br />
        <br />
        <table class="style1" bgcolor="Silver" border="1" style="border: 6px groove #00FF00;
            padding: 2px; margin-top: auto">
            <tr>
                <td class="style2">
                    <b>Option: </b>
                    <br />
                </td>
                <td class="style7">
                    <b>Value: </b>
                </td>
                <td class="style5">
                    <b>Control: </b>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Set all User&#39;s to Active/In-Active :<br />
                </td>
                <td class="style7">
                    <asp:Label ID="userGlobalActive" runat="server" Text="N/A"></asp:Label>
                </td>
                <td class="style5">
                    <asp:RadioButton ID="userGlobalActiveRadio" runat="server" Text="Active" GroupName="globalActive" />
                    <asp:RadioButton ID="userGlobalIn_ActiveRadio" runat="server" Text="In-Active" GroupName="globalActive"
                         />
                </td>
                <td class="style6">
                    <asp:Button ID="userGlobalActiveBtn" runat="server" Text="  OK  " OnClick="userGlobalActiveBtn_Click" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Set all Organization to Active/In Active :<br />
                </td>
                <td class="style7">
                    <asp:Label ID="OrgGlobalActive" runat="server" Text="N/A"></asp:Label>
                </td>
                <td class="style5">
                    <asp:RadioButton ID="OrgGlobalActiveRadio" runat="server" Text="Active"  GroupName="oGlobalActive" />
                    <asp:RadioButton ID="OrgGlobalIn_ActiveRadio" runat="server" Text="In-Active"  GroupName="oGlobalActive" />
                </td>
                <td class="style6">
                    <asp:Button ID="OrgGlobalActiveBtn" runat="server" Text="  OK  " 
                        onclick="OrgGlobalActiveBtn_Click" />
                </td>
            </tr>
             <tr>
                <td class="style2">
                     Set all Floats&#39;s to Approved/Not Approved:<br />
                </td>
                <td class="style7">
                    <asp:Label ID="approvalLbl" runat="server" Text="Not Approved"></asp:Label>
                </td>
                <td class="style5">
                    <asp:RadioButton ID="approveR1" runat="server" Text="Approved" GroupName="globalActives" />
                    <asp:RadioButton ID="notApproveR2" runat="server" Text="Not Approved" GroupName="globalActives"
                         />
                </td>
                <td class="style6">
                    <asp:Button ID="approvalBtn" runat="server" Text="  OK  " 
                        onclick="approvalBtn_Click"  />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Enable or Disable Confirmation Pop-Up for 
                    User Activation:<br />
                </td>
                <td class="style7">
                    <asp:Label ID="confirmEnaDis" runat="server" Text="N/A"></asp:Label>
                </td>
                <td class="style5">
                    <asp:RadioButton ID="enableConfirm" runat="server" Text="Enable"  GroupName="oGlobalActives" />
                    <asp:RadioButton ID="disableConfirm" runat="server" Text="Disable"  GroupName="oGlobalActives" />
                </td>
                <td class="style6">
                    <asp:Button ID="confirmEnaDisBtn" runat="server" Text="  OK  " onclick="confirmEnaDisBtn_Click" 
                         />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Enable or Disable Confirmation Pop-Up for Organization Activation:<br />
                </td>
                <td class="style7">
                    <asp:Label ID="confirmEnaDisOrg" runat="server" Text="N/A"></asp:Label>
                </td>
                <td class="style5">
                    <asp:RadioButton ID="confirmOrgEnable" runat="server" Text="Enable"  GroupName="oGlobalActived" />
                    <asp:RadioButton ID="confirmOrgDisable" runat="server" Text="Disable"  GroupName="oGlobalActived" />
                </td>
                <td class="style6">
                    <asp:Button ID="confirmEnaDisOrgBtn" runat="server" Text="  OK  " onclick="confirmEnaDisOrgBtn_Click"  
                         />
                </td>
            </tr>
             <tr>
                <td class="style2">
                    Enable or Disable Confirmation Pop-Up for Float Approval:<br />
                </td>
                <td class="style7">
                    <asp:Label ID="floatDisEnaLbl" runat="server" Text="Disabled"></asp:Label>
                </td>
                <td class="style5">
                    <asp:RadioButton ID="EnableFloatR1" runat="server" Text="Enable" GroupName="globalActiver" />
                    <asp:RadioButton ID="DisableFloatR2" runat="server" Text="Disable" GroupName="globalActiver"
                         />
                </td>
                <td class="style6">
                    <asp:Button ID="floatEnaDisBtn" runat="server" Text="  OK  " 
                        onclick="floatEnaDisBtn_Click" />
                </td>
            </tr>

                <tr>
                <td class="style2">
                    Enable or Disable Snow Flakes for User Home:<br />
                </td>
                <td class="style7">
                    <asp:Label ID="snowLbl" runat="server" Text="Disabled"></asp:Label>
                </td>
                <td class="style5">
                    <asp:RadioButton ID="enableSnow" runat="server" Text="Enable" GroupName="globalActivers" />
                    <asp:RadioButton ID="disableSnow" runat="server" Text="Disable" GroupName="globalActivers"
                         />
                </td>
                <td class="style6">
                    <asp:Button ID="enableOrDisableSnow" runat="server" Text="  OK  " onclick="enableOrDisableSnow_Click" 
                         />
                </td>
            </tr>
            
            <tr>
                <td class="style2">
                    Set Global Expiry date for Users :<br />
                </td>
                <td class="style7">
                    <asp:Label ID="userGlobalExpire" runat="server" Text="N/A"></asp:Label>
                </td>
                <td class="style5">
                    <asp:DropDownList ID="userGlobalExpireMonth" runat="server">
                        <asp:ListItem Selected="True" Value="0">Month</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                    /
                    <asp:DropDownList ID="userGlobalExpireDay" runat="server">
                        <asp:ListItem Selected="True" Value="0">Day</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>
                    /
                    <asp:DropDownList ID="userGlobalExpireYear" runat="server">
                        <asp:ListItem Value="0">Year</asp:ListItem>
                        <asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                        <asp:ListItem>2016</asp:ListItem>
                        <asp:ListItem>2017</asp:ListItem>
                        <asp:ListItem>2018</asp:ListItem>
                        <asp:ListItem>2019</asp:ListItem>
                        <asp:ListItem>2021</asp:ListItem>
                        <asp:ListItem>2022</asp:ListItem>
                        <asp:ListItem>2023</asp:ListItem>
                        <asp:ListItem>2024</asp:ListItem>
                        <asp:ListItem>2025</asp:ListItem>
                        <asp:ListItem>2025</asp:ListItem>
                        <asp:ListItem>2026</asp:ListItem>
                        <asp:ListItem>2027</asp:ListItem>
                        <asp:ListItem>2028</asp:ListItem>
                        <asp:ListItem>2029</asp:ListItem>
                        <asp:ListItem>2030</asp:ListItem>
                        <asp:ListItem>2031</asp:ListItem>
                        <asp:ListItem>2032</asp:ListItem>
                        <asp:ListItem>2033</asp:ListItem>
                        <asp:ListItem>2034</asp:ListItem>
                        <asp:ListItem>2035</asp:ListItem>
                        <asp:ListItem>2036</asp:ListItem>
                        <asp:ListItem>2037</asp:ListItem>
                        <asp:ListItem>2038</asp:ListItem>
                        <asp:ListItem>2039</asp:ListItem>
                        <asp:ListItem>2040</asp:ListItem>
                        <asp:ListItem>2041</asp:ListItem>
                        <asp:ListItem>2042</asp:ListItem>
                        <asp:ListItem>2043</asp:ListItem>
                        <asp:ListItem>2044</asp:ListItem>
                        <asp:ListItem>2045</asp:ListItem>
                        <asp:ListItem>2046</asp:ListItem>
                        <asp:ListItem>2047</asp:ListItem>
                        <asp:ListItem>2048</asp:ListItem>
                        <asp:ListItem>2049</asp:ListItem>
                        <asp:ListItem>2050</asp:ListItem>
                        <asp:ListItem>2051</asp:ListItem>
                        <asp:ListItem>2052</asp:ListItem>
                        <asp:ListItem>2053</asp:ListItem>
                        <asp:ListItem>2054</asp:ListItem>
                        <asp:ListItem>2055</asp:ListItem>
                        <asp:ListItem>2056</asp:ListItem>
                        <asp:ListItem>2057</asp:ListItem>
                        <asp:ListItem>2058</asp:ListItem>
                        <asp:ListItem>2059</asp:ListItem>
                        <asp:ListItem>2060</asp:ListItem>
                        <asp:ListItem>2061</asp:ListItem>
                        <asp:ListItem>2062</asp:ListItem>
                        <asp:ListItem>2063</asp:ListItem>
                        <asp:ListItem>2064</asp:ListItem>
                        <asp:ListItem>2065</asp:ListItem>
                        <asp:ListItem>2066</asp:ListItem>
                        <asp:ListItem>2067</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style6">
                    <asp:Button ID="userGlobalExpireBtn" runat="server" Text="  OK  " 
                        onclick="userGlobalExpireBtn_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Set Global Expiry date for Organziations:<br />
                </td>
                <td class="style7">
                    <asp:Label ID="OrgGlobalExpire" runat="server" Text="N/A"></asp:Label>
                </td>
                <td class="style5">
                    <asp:DropDownList ID="OrgGlobalExpireMonth" runat="server">
                        <asp:ListItem Selected="True" Value="0">Month</asp:ListItem>
                       <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                    </asp:DropDownList>
                    /
                    <asp:DropDownList ID="OrgGlobalExpireDay" runat="server">
                        <asp:ListItem Selected="True" Value="0">Day</asp:ListItem>
                        <asp:ListItem>01</asp:ListItem>
                        <asp:ListItem>02</asp:ListItem>
                        <asp:ListItem>03</asp:ListItem>
                        <asp:ListItem>04</asp:ListItem>
                        <asp:ListItem>05</asp:ListItem>
                        <asp:ListItem>06</asp:ListItem>
                        <asp:ListItem>07</asp:ListItem>
                        <asp:ListItem>08</asp:ListItem>
                        <asp:ListItem>09</asp:ListItem>
                        <asp:ListItem>10</asp:ListItem>
                        <asp:ListItem>11</asp:ListItem>
                        <asp:ListItem>12</asp:ListItem>
                        <asp:ListItem>13</asp:ListItem>
                        <asp:ListItem>14</asp:ListItem>
                        <asp:ListItem>15</asp:ListItem>
                        <asp:ListItem>16</asp:ListItem>
                        <asp:ListItem>17</asp:ListItem>
                        <asp:ListItem>18</asp:ListItem>
                        <asp:ListItem>19</asp:ListItem>
                        <asp:ListItem>20</asp:ListItem>
                        <asp:ListItem>21</asp:ListItem>
                        <asp:ListItem>22</asp:ListItem>
                        <asp:ListItem>23</asp:ListItem>
                        <asp:ListItem>24</asp:ListItem>
                        <asp:ListItem>25</asp:ListItem>
                        <asp:ListItem>26</asp:ListItem>
                        <asp:ListItem>27</asp:ListItem>
                        <asp:ListItem>28</asp:ListItem>
                        <asp:ListItem>29</asp:ListItem>
                        <asp:ListItem>30</asp:ListItem>
                        <asp:ListItem>31</asp:ListItem>
                    </asp:DropDownList>
                    /
                    <asp:DropDownList ID="OrgGlobalExpireYear" runat="server" >
                        <asp:ListItem Value="0">Year</asp:ListItem>
                        <asp:ListItem>2011</asp:ListItem>
                        <asp:ListItem>2012</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                        <asp:ListItem>2016</asp:ListItem>
                        <asp:ListItem>2017</asp:ListItem>
                        <asp:ListItem>2018</asp:ListItem>
                        <asp:ListItem>2019</asp:ListItem>
                        <asp:ListItem>2021</asp:ListItem>
                        <asp:ListItem>2022</asp:ListItem>
                        <asp:ListItem>2023</asp:ListItem>
                        <asp:ListItem>2024</asp:ListItem>
                        <asp:ListItem>2025</asp:ListItem>
                        <asp:ListItem>2025</asp:ListItem>
                        <asp:ListItem>2026</asp:ListItem>
                        <asp:ListItem>2027</asp:ListItem>
                        <asp:ListItem>2028</asp:ListItem>
                        <asp:ListItem>2029</asp:ListItem>
                        <asp:ListItem>2030</asp:ListItem>
                        <asp:ListItem>2031</asp:ListItem>
                        <asp:ListItem>2032</asp:ListItem>
                        <asp:ListItem>2033</asp:ListItem>
                        <asp:ListItem>2034</asp:ListItem>
                        <asp:ListItem>2035</asp:ListItem>
                        <asp:ListItem>2036</asp:ListItem>
                        <asp:ListItem>2037</asp:ListItem>
                        <asp:ListItem>2038</asp:ListItem>
                        <asp:ListItem>2039</asp:ListItem>
                        <asp:ListItem>2040</asp:ListItem>
                        <asp:ListItem>2041</asp:ListItem>
                        <asp:ListItem>2042</asp:ListItem>
                        <asp:ListItem>2043</asp:ListItem>
                        <asp:ListItem>2044</asp:ListItem>
                        <asp:ListItem>2045</asp:ListItem>
                        <asp:ListItem>2046</asp:ListItem>
                        <asp:ListItem>2047</asp:ListItem>
                        <asp:ListItem>2048</asp:ListItem>
                        <asp:ListItem>2049</asp:ListItem>
                        <asp:ListItem>2050</asp:ListItem>
                        <asp:ListItem>2051</asp:ListItem>
                        <asp:ListItem>2052</asp:ListItem>
                        <asp:ListItem>2053</asp:ListItem>
                        <asp:ListItem>2054</asp:ListItem>
                        <asp:ListItem>2055</asp:ListItem>
                        <asp:ListItem>2056</asp:ListItem>
                        <asp:ListItem>2057</asp:ListItem>
                        <asp:ListItem>2058</asp:ListItem>
                        <asp:ListItem>2059</asp:ListItem>
                        <asp:ListItem>2060</asp:ListItem>
                        <asp:ListItem>2061</asp:ListItem>
                        <asp:ListItem>2062</asp:ListItem>
                        <asp:ListItem>2063</asp:ListItem>
                        <asp:ListItem>2064</asp:ListItem>
                        <asp:ListItem>2065</asp:ListItem>
                        <asp:ListItem>2066</asp:ListItem>
                        <asp:ListItem>2067</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="style6">
                    <asp:Button ID="OrgGlobalExpireBtn" runat="server" Text="  OK  " 
                        onclick="OrgGlobalExpireBtn_Click" />
                </td>
                <%--<tr>
                    <td class="style2">
                        Change Banner of Parade (must be l x w in pixels):<br />
                    </td>
                    <td class="style7">
                        <asp:Label ID="bannerName" runat="server" Text="N/A"></asp:Label>
                        &nbsp;
                    </td>
                    <td class="style5">

                        <asp:DropDownList ID="dDLBanner" runat="server" Width="175px">
                            <asp:ListItem Value="0">Select Banner</asp:ListItem>
                        </asp:DropDownList>
                        
                    </td>
                    <td class="style6">
                        <asp:Button ID="bannerNameBtn" runat="server" Text="  OK  " 
                            onclick="bannerNameBtn_Click" />
                    </td>
                </tr>--%>
               <%-- <tr>
                    <td class="style2">
                        Enable User Edit/Delete Table Paging :
                    </td>
                    <td class="style7">
                        <asp:Label ID="userEditDelete" runat="server" Text="N/A"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:RadioButton ID="userEditDeleteRadioEnable" runat="server" Text="Enable" />
                        <asp:RadioButton ID="userEditDeleteRadioDisable" runat="server" Text="Disable" />
                    </td>
                    <td class="style6">
                        <asp:Button ID="userEditDeleteBtn" runat="server" Text="  OK  " 
                            onclick="userEditDeleteBtn_Click" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Enable Organization Edit/Delete Table Paging :
                    </td>
                    <td class="style7">
                        <asp:Label ID="OrguserEditDelete" runat="server" Text="N/A"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:RadioButton ID="OrguserEditDeleteRadioEnable" runat="server" Text="Enable" />
                        <asp:RadioButton ID="OrguserEditDeleteRadioDisable" runat="server" Text="Disable" />
                    </td>
                    <td class="style6">
                        <asp:Button ID="OrguserEditDeleteBtn" runat="server" Text="  OK  " />
                    </td>
                </tr>--%>
                <tr>
                    <td class="style2">
                        Set Waiver for user terms and Conditions(<i>Waivers listed will be from the waiver page, with the waiver type of 'Wavier'</i>):
                    </td>
                    <td class="style7">
                        <asp:Label ID="waiverEdit" runat="server" Text="N/A"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:DropDownList ID="DropDownList1" runat="server"  Width="183px" 
                            DataSourceID="SqlDataSource1" DataTextField="wName" DataValueField="wName"
                            AppendDataBoundItems="True">
                             <asp:ListItem Value="0">--Select A Waiver--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                            SelectCommand="SELECT wName FROM waiver WHERE wType = 'Waiver' ;"></asp:SqlDataSource>
                        <br />
                    </td>
                    <td class="style6">
                        <asp:Button ID="Button1" runat="server" Text="  OK  " 
                            onclick="Button1_Click1" />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        Set the current Parade:
                    </td>
                    <td class="style7">
                        <asp:Label ID="currentParadeLbl" runat="server" Text="N/A"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:DropDownList ID="DropDownList2" runat="server"  Width="183px" 
                            DataSourceID="SqlDataSource2" DataTextField="ParadeName" DataValueField="paradeId"
                            AppendDataBoundItems="True">
                             <asp:ListItem Value="0">--Select Current Parade--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                            SelectCommand="SELECT paradeName, paradeID FROM parade;"></asp:SqlDataSource>
                        <br />
                    </td>
                    <td class="style6">
                        <asp:Button ID="currentParade" runat="server" Text="  OK  " onclick="currentParade_Click" 
                             />
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                        User About Description(<i>Desc. listed will be from the waiver page, with the waiver type of 'About'</i>):
                    </td>
                    <td class="style7">
                    
                        <asp:Label ID="userAboutDesc" runat="server" Text="N/A"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:DropDownList ID="ddUserAboutDesc" runat="server"  Width="183px" 
                            DataSourceID="SqlDataSource3" DataTextField="wName" DataValueField="wName"
                            AppendDataBoundItems="True">
                             <asp:ListItem Value="0">--Select User Home About--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource3" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                            SelectCommand="SELECT wName, waiverID FROM waiver WHERE wType = 'About';"></asp:SqlDataSource>
                        <br />
                    </td>
                    <td class="style6">
                        <asp:Button ID="UserAboutDescBtn" runat="server" Text="  OK  " onclick="UserAboutDescBtn_Click"  
                             />
                    </td>
                </tr>
                 <tr>
                    <td class="style2">
                        User Home Page Image(<i>Images list will be from the banner page. You can preview them on that page, before selecting here.</i>):
                    </td>
                    <td class="style7">
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/images/userImage.png" 
                            Height="164px" Width="294px" />
                    <br />
                       Image Name: <asp:Label ID="userHomePageImage" runat="server" Text="N/A"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:DropDownList ID="ddUserHomePageImage" runat="server"  Width="183px" 
                            DataSourceID="SqlDataSource4" 
                            AppendDataBoundItems="True" DataTextField="bName" 
                            DataValueField="bName">
                             <asp:ListItem Value="0">--Select Image for User Home--</asp:ListItem>
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="SqlDataSource4" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
                            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                            SelectCommand="SELECT bannerId, bName, bDescription FROM bannerTable;"></asp:SqlDataSource>
                        <br />
                    </td>
                    <td class="style6">
                        <asp:Button ID="UserHomePageImageBtn" runat="server" Text="  OK  " onclick="UserHomePageImageBtn_Click"  
                             />
                    </td>
                </tr>
                  <tr>
                <td class="style2">
                    Set Global or Selective Parade View Mode:<br />
                </td>
                <td class="style7">
                    <asp:Label ID="globalSelectLbl" runat="server" Text="N/A"></asp:Label>
                </td>
                <td class="style5">
                    <asp:RadioButton ID="selectSelective" runat="server" Text="Selective" GroupName="globalActivess" />
                    <asp:RadioButton ID="selectGlobal" runat="server" Text="Global" GroupName="globalActivess"
                         />
                </td>
                <td class="style6">
                    <asp:Button ID="globalSelect" runat="server" Text="  OK  " onclick="globalSelect_Click" 
                        />
                </td>
            </tr>
            
                 <tr>
                    <td class="style2">
                        Set the Size and Colour of the front page scrolling text:
                    </td>
                    <td class="style7">
                        <asp:Label ID="scrollLbl" runat="server" Text="N/A"></asp:Label>
                    </td>
                    <td class="style5">
                        <asp:DropDownList ID="ddSize" runat="server">
                            <asp:ListItem Value="0">--Choose Size--</asp:ListItem>
                            <asp:ListItem>Big</asp:ListItem>
                            <asp:ListItem>Medium</asp:ListItem>
                            <asp:ListItem>Small</asp:ListItem>
                        </asp:DropDownList>
                        
                        <asp:DropDownList ID="ddColour" runat="server">
                            <asp:ListItem Value="0">--Choose Colour--</asp:ListItem>
                            <asp:ListItem>Red</asp:ListItem>
                            <asp:ListItem>Blue</asp:ListItem>
                            <asp:ListItem>Black</asp:ListItem>
                            <asp:ListItem>White</asp:ListItem>
                            <asp:ListItem>Purple</asp:ListItem>
                            <asp:ListItem>Yellow</asp:ListItem>
                            <asp:ListItem>Green</asp:ListItem>
                            <asp:ListItem>Orange</asp:ListItem>
                        </asp:DropDownList>
                        <br /><br />Set Scroll Text:
                        <asp:TextBox ID="setScrollText" runat="server"></asp:TextBox>
                    </td>
                    <td class="style6">
                        <asp:Button ID="scrollBtn" runat="server" Text="  OK  " onclick="scrollBtn_Click" 
                             />
                    </td>
                </tr>
                 <tr>
                <td class="style2">
                   Delete cached files that may speed up the server:
                    :<br />
                </td>
                <td class="style7">
                 Files that can be cleared:   <b>  <asp:Label ID="fileCache" runat="server" Text=""></asp:Label> </b> 
                </td>
                <td class="style5">
                  Clear cached files to: <b>0</b>
                </td>
                <td class="style5">
                    <asp:Button ID="deleteFileBtn" runat="server" Text="Delete" onclick="deleteFileBtn_Click" 
                         />
                </td>
            </tr>
                 <tr>
                <td class="style2">
                   Reset the Login Counter
                    :<br />
                </td>
                <td class="style7">
                 Counts so far: <b>   <asp:Label ID="loginCounter" runat="server" Text=""></asp:Label> </b> 
                </td>
                <td class="style5">
                  Reset counter to: <b>0</b>
                </td>
                <td class="style5">
                    <asp:Button ID="resetCounter" runat="server" Text="Reset" 
                        onclick="resetCounter_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                  Reset the Parade Management System :
                    <br />
                </td>
                <td class="style7">
                    ALL DATA WILL BE 
                    OR IS DELETED:<br />
                    Once you log out you will need to log in as the default administrator the 
                    ParadeMS creates.<br />
                    <br />
                    Username: administrator<br />
                    Password: password<br />
                    <br />
                    Delete once you&#39;ve made your own admin account.</td>
                <td class="style5">
                    This is only to be used when the Parade System needs to be reset.</td>
                <td class="style5">
                    <asp:Button ID="PMSReset" runat="server" Text="Reset" onclick="PMSReset_Click" 
                        />
                </td>
            </tr>
        </table>
        <div><asp:Label ID="currentIDValue" runat="server"  Visible="false" Text="N/A"></asp:Label>
        <asp:Label ID="Label3" runat="server" Visible="false"  Text="N/A"></asp:Label></div>
    </div>
    <div style="position: absolute; left: 301px; top: 253px;  z-index: 5; height: 328px; width: 339px;"
    ID="confirmPanelDiv" runat="server">
                 <asp:Panel ID="confirmPanel" runat="server" Height="370px" Width="303px" 
                     BackColor="#33CC33" BorderColor="#009900" Visible="false" 
                     BorderWidth="4px" >
                     <br/><br/><br/><br/><br/><br/><br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
                     <br/>
                     &nbsp;&nbsp;&nbsp;
                  <div style="position: absolute; left: 20px; top: 27px; w z-index: 6; height: 31px; width: 259px; ">  <p> &nbsp;&nbsp;&nbsp; 
                      <asp:Label ID="AlertLbl" runat="server" ForeColor="Red"></asp:Label></p>
                      <br/>
                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*Super-Admin credentials*
                      <br/>
                      <table>
                          <tr>
                                <td>
                                    <asp:Label ID="usernameLbl" runat="server" Text="Username:" Visible="True"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="usernameTxt" runat="server" Visible="True"></asp:TextBox></td>
                          </tr>

                          <tr>
                                 <td>
                                    <asp:Label ID="passLbl" runat="server" Text="Password:" Visible="True"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="passTxt" runat="server" Visible="True" TextMode="Password"></asp:TextBox></td>
                          </tr>

                      </table>
                      <asp:Label ID="error" runat="server" Text="" ForeColor="Red"></asp:Label>
                      </div>
                 <br/> <br/> <br/> <br/><br/> <br/> <br/> <br/> 
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
