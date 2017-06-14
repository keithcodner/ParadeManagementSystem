<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminHomeArea.aspx.cs" Inherits="adminHomeArea" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
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
<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000" bgcolor="#ffff99">
    <form id="form1" runat="server">
    <font color="#990000" size="+3">Administrator Area: Home</font></p>
    <div id="Layer1" style="position: absolute; left: 62px; top: 64px; width: 475px;
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
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div style="position: absolute; left: 35px; top: 165px; z-index: 3; height: 38px;
        width: 640px;">
        <h2>
            &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Today's date is"></asp:Label>
            &nbsp;<asp:Label ID="day" runat="server" Text="Label"></asp:Label>
            &nbsp;<asp:Label ID="month" runat="server" Text="Label"></asp:Label>&nbsp;<asp:Label
                ID="monthInt" runat="server" Text="Label"></asp:Label>, &nbsp;&nbsp;<asp:Label ID="year"
                    runat="server" Text="Label"></asp:Label></h2>
    </div>
    <div style="position: absolute; left: 34px; top: 237px; z-index: 3; height: 247px;
        width: 378px;">
        <table bgcolor="Silver" border="1" style="border: 6px solid #33CC33; padding: 2px;
            margin-top: auto" frame="border">
            <tr>
                <td class="style4">
                    <b>&nbsp;<u><h2>
                        Statistics:</u> <asp:Label ID="globalOrSelective"
                    runat="server" Text=""></asp:Label> </h2>
                    </b>
                    <br />
                </td>
                <td class="style5">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <b>Login Counter:</b>
                </td>
                <td align="left" class="style5">
                    &nbsp;<asp:Label ID="loginCounter" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    <b>Number of Users:</b>
                </td>
                <td align="left" class="style7">
                    <asp:Label ID="getNoOfUser" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    Active Users:
                </td>
                <td align="left" class="style9">
                    <asp:Label ID="allActiveUsers" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style8">
                    In-Active Users:
                </td>
                <td align="left" class="style9" headers="s">
                    <asp:Label ID="allInActiveUsers" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
             <tr>
                <td class="style6">
                    Number of Administrators:
                </td>
                <td class="style7">
                    <asp:Label ID="NoOfAdmin" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Number of Participants:
                </td>
                <td class="style7">
                    <asp:Label ID="NoOfPart" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Number of Volunteers:
                </td>
                <td class="style7">
                    <asp:Label ID="NoOfVol" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    <b>Number of Organizations:</b>
                </td>
                <td class="style5">
                    <asp:Label ID="allOrganizations" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    Active Organizations:
                </td>
                <td class="style5">
                    <asp:Label ID="allActiveOrg" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style4">
                    In-Active Organizations:
                </td>
                <td class="style5">
                    <asp:Label ID="allInActiveOrg" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">
                   <b> Number of Floats:</b>
                </td>
                <td class="style7">
                    <asp:Label ID="noOfFloats" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    Number of Approved Floats:
                </td>
                <td class="style7">
                    <asp:Label ID="noOfApprovedFloats" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style6">
                    Number of Not Approved Floats:
                </td>
                <td class="style7">
                    <asp:Label ID="noOfNotAppvdFloats" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div style="position: absolute; left: 410px; top: 204px; z-index: 3; height: 87px;
        width: 759px;">
        
        <h3>
            &nbsp;&nbsp;
           <h2> <asp:Label ID="currentParade" runat="server" ForeColor="#33CC33"></asp:Label> </h2>
            <br />
            <br />
            
    </div>
     <div style="position: absolute; left: 1082px; top: 273px; z-index: 3; height: 87px;
        width: 230px;">
    
        <%-- This tutorial is sponsored by http://www.ServerIntellect.com web hosting. 
	     Check out http://v4.aspnettutorials.com/ for more great tutorials! 

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        --%>

    </div>
    <p>
        &nbsp;</p>
    <div style="position: absolute; left: 1016px; top: 340px; z-index: 3; height: 254px;
        width: 338px;">
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="Black"
            BorderStyle="Solid" CellSpacing="1" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black"
            Height="250px" NextPrevFormat="ShortMonth" Width="330px">
            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" Height="8pt" />
            <DayStyle BackColor="#CCCCCC" />
            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="White" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
            <TitleStyle BackColor="#333399" BorderStyle="Solid" Font-Bold="True" Font-Size="12pt"
                ForeColor="White" Height="12pt" />
            <TodayDayStyle BackColor="#999999" ForeColor="White" />
        </asp:Calendar>
    </div>
    <div style="border: 5px solid blue; position: absolute; left: 690px; top: 310px; z-index: 4; height: 200px;
        width: 225px; background-color: #FF9900;">
         <b>&nbsp; View organizations that have been added today?</b><br />
        <br />
        There 
         <asp:Label ID="change2" runat="server" Text=""></asp:Label>
&nbsp;currently <b>
        <asp:Label ID="getNewOrg" runat="server" Text="" ForeColor="Red"></asp:Label></b>
&nbsp;<br />
        new organizations added today, press the button to view all of them:<br />
        
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ActiveOrgBtn" runat="server" Text=" View! " Height="31px" 
            Width="124px" onclick="ActiveOrgBtn_Click"  />
    </div>
    <div   style="border: 1px solid blue; position: absolute; top: 601px; left: 1013px; height: 142px; width: 334px; background-color: #00FF00;">
        
        
        <b>&nbsp; Additional Links:</b><br />
        <br />
        <asp:HyperLink ID="changePassword" runat="server" href="passwordManagement.aspx">Change Password</asp:HyperLink> <br />
        <asp:HyperLink ID="viewUserMessages" runat="server" href="adminUserMessages.aspx">User Messages</asp:HyperLink>
        <asp:Label
            ID="newMessages" runat="server" ForeColor="Red" Font-Bold="True"></asp:Label>
        </div>
    <div   style="border-style: solid; border-color: blue; border-width: 5px; position: absolute; top: 310px; left: 439px; height: 200px; width: 225px; background-color: #00FF00;">
        
        
        <b>&nbsp; View users that have been added today?</b><br />
        <br />
        There
        <asp:Label ID="chang1" runat="server" Text=""></asp:Label>
&nbsp;currently <b>
        <asp:Label ID="getNewUsers" runat="server" Text="" ForeColor="Red"></asp:Label></b>
&nbsp;<br />
        new users added today, press the button to view all of them:<br />
        
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ActivateBtn" runat="server" Text=" View! " Height="31px" 
            Width="124px" onclick="ActivateBtn_Click"  />
        
    </div>

    <div style="border: 5px solid blue; position: absolute; left: 438px; top: 524px; z-index: 4; height: 200px;
        width: 225px; background-color: #00FFFF;" id="createParadeDiv" 
        runat="server">

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />

         <b> <asp:Label ID="createAParadeLbl" runat="server" Text="           Create A Parade?"></asp:Label></b><br />
        <br />
      <br />
    &nbsp; &nbsp;  <asp:Label ID="createParadeLbl" runat="server" Text=" Create a new parade here:"></asp:Label> <br />
        <br /><br /><br />
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="createParade" runat="server" Text=" Create! " Height="31px" 
            Width="124px" onclick="createParade_Click"  />
    </div>

    <div   style=" position: absolute; top: 746px; left: 567px; height: 28px; width: 257px;  z-index: 7;">
  
        <asp:Button ID="paradeSubmit" runat="server" Text="  Submit!  " 
            onclick="paradeSubmit_Click" Visible="False" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="cancelBtn" runat="server" Text=" Cancel " onclick="cancelBtn_Click"/>
 
    </div>

     <div  style=" position: absolute; top: 575px; left: 515px; height: 289px; width: 520px;  z-index: 6;"  
        id="createParadeTable" runat="server">
             <table  
            >
            <tr>
                <td class="style10">
                    
                    
                    
                    <asp:Label ID="paradeName" runat="server" Text="Parade Name: "></asp:Label>
                    
                    
                    
                    <br />
                </td>
                <td class="style11">
                    &nbsp;
                    <asp:TextBox ID="paradeNameTxt" runat="server"></asp:TextBox>
                </td>
            </tr>
             <tr>
                <td class="style10">
                    
                    <asp:Label ID="paradeYear" runat="server" Text="Parade Year:"></asp:Label>
                    
                    <br />
                </td>
                <td class="style11">
                    &nbsp;
                    <asp:TextBox ID="paradeYearTxt" runat="server"></asp:TextBox>
                     <asp:MaskedEditExtender runat="server"  ID="paradeYearTxtMEE" Mask="9999"
        TargetControlID="paradeYearTxt"></asp:MaskedEditExtender> 
                </td>
            </tr>
             <tr>
                <td class="style10">
                    
                    <asp:Label ID="paradeType" runat="server" Text="Parade Type:"></asp:Label>
                    
                    <br />
                </td>
                <td class="style11">
                    &nbsp;
                    <asp:TextBox ID="paradeTypeTxt" runat="server"></asp:TextBox>
                    

                </td>
            </tr>
             <tr>
                <td class="style10">
                    
                    <asp:Label ID="paradeDate" runat="server" Text="Parade Date:"></asp:Label>
                    
                    <br />
                </td>
                <td class="style11">
                    &nbsp;
                    <asp:TextBox ID="paradeDateTxt" runat="server"></asp:TextBox>
                    <asp:MaskedEditExtender runat="server"  ID="paradeDateTxtMEE" Mask="99/99/9999"
        TargetControlID="paradeDateTxt" MaskType="Date" ></asp:MaskedEditExtender> 
                </td>
            </tr>
             <tr>
                <td class="style10">
                    
                    <asp:Label ID="paradeStartTime" runat="server" Text="Start Time:"></asp:Label>
                    
                    <br />
                </td>
                <td class="style11">
                    &nbsp;
                    <asp:TextBox ID="paradeStartTimeTxt" runat="server"></asp:TextBox>
                     <asp:MaskedEditExtender runat="server"  ID="paradeStartTimeTxtMEE" Mask="99:99:99"
        TargetControlID="paradeStartTimeTxt" MaskType="Time" ></asp:MaskedEditExtender> 
                </td>
            </tr>
             <tr>
                <td class="style10">
                    
                    <asp:Label ID="paradeEndTime" runat="server" Text="End Time :"></asp:Label>
                    
                    <br />
                </td>
                <td class="style11">
                    &nbsp;
                    <asp:TextBox ID="paradeEndTimeTxt" runat="server"></asp:TextBox>
                    <asp:MaskedEditExtender runat="server"  ID="paradeEndTimeTxtMEE" Mask="99:99:99"
        TargetControlID="paradeEndTimeTxt" MaskType="Time"></asp:MaskedEditExtender> 
                </td>
            </tr>

            </table>
    </div>

      <div style="border: 5px solid blue; position: absolute; left: 690px; top: 525px; z-index: 4; height: 200px;
        width: 225px; background-color: #FF33CC;" id="s" runat="server">
         <b>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;  &nbsp; &nbsp; &nbsp; Help?</b><br />
        <br />
        <br />
        Click here if you need some help:<br /><br /><br />
        
        
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="help" runat="server" Text=" Get Help " Height="31px" 
            Width="124px" onclick="help_Click"  />
    </div>

    
    </form>
</body>
</html>
