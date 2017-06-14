<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HelpDoc.aspx.cs" Inherits="HelpDoc" %>

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

 
<font color="#990000" size="+3">Administrator Area: Help Documentation</font>
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
    <br /><h2>This is the Help Documentation :</h2><br />
    <br /> &nbsp;<asp:Panel ID="Panel1" runat="server" Height="163px">

        &nbsp;&nbsp;
             
        
    </asp:Panel>
    <div style="border: 1px solid #000000; position: absolute; left: 60px; top: 242px; z-index: 4; height: 252px;
        width: 286px; background-color: #5F9EA0;" id="spare" runat="server">
     
        
        
        
       <a href="#top" ></a>
        <br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Table of Contents: <br /><br />
        &nbsp;
        1.<asp:HyperLink ID="changePassword" runat="server" href="#gettingStarted">Getting Started</asp:HyperLink><br />
        &nbsp;
        2.<asp:HyperLink ID="HyperLink1" runat="server" href="#createNewUser">Creating new account as user</asp:HyperLink><br />
        &nbsp;
        3.<asp:HyperLink ID="HyperLink2" runat="server" href="#createNewAdminUser">Creating new account as admin</asp:HyperLink><br />
        &nbsp;
        4.<asp:HyperLink ID="HyperLink3" runat="server" href="#approveNewAccount">Approve New Account</asp:HyperLink><br />
        &nbsp;
        5.<asp:HyperLink ID="HyperLink4" runat="server" href="#newOrg">Creating new Organization</asp:HyperLink><br />
        &nbsp;
        6.<asp:HyperLink ID="HyperLink5" runat="server" href="#approveNewOrg">Approve New Organization</asp:HyperLink><br />
        &nbsp;
        7.<asp:HyperLink ID="HyperLink6" runat="server" href="#newFloat">Creating new Float</asp:HyperLink><br />
        &nbsp;
        8.<asp:HyperLink ID="HyperLink7" runat="server" href="#approveNewFloat">Approve New Float</asp:HyperLink><br />
        
     &nbsp;&nbsp;&nbsp;&nbsp;  
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
    </div>
    <a name="gettingStarted"></a> 
    <div style="position: absolute; left: 237px; top: 546px; z-index: 2; height: 204px;
        width: 889px;" id="Div1" runat="server">
     
        <b>1. Getting Started </b>
        <p>What you need to know about the Parade Management System (PMS) is that things in the parade system  are related. The PMS is comprised of four main parts the  parade, user, organizations, and the floats. There are a lot of other parts that make the System convenient but those will be explain later. First we start with the Parade, a parade must be created first as almost every other part in the PMS relies on a parade existing.  Next  a user must be made, a user can have three kinds of status. These status' are Administrator, Volunteer and Participant, for now we will focus on the participant status. Only users that have the participant status are permitted to make organizations and go on to have floats in the parade. So have the parade and the user with the particpant status are created the next phase is making an organization. An organization is an entity that is permitted to enter floats in the current parade, the organization must be connected to a user by the field of (Contact) in the organization table. When a orgniazation is generated a float is also generated automatically with the (Contact) connecting the float to the organization and the (Contact) connecting the organization to the user, however if an orgniazation so wishes they can add additional floats to their organization, but ofcourse being approved by administration first. This concludes a basic description of what the PMS requires to operate for first time or quick 'know-how' use. For more indepth Help and Tutorials look below or check out the table of contents. <br /><br /><br />
       <b> <u>INSTRUCTIONS AFTER PARADE IS RESET: </u></b> <br />

1.Reset the parade.<br />
2.Before logging out, make sure you take down the default credentials.<br />
3.Log out .<br />
4.Log into the 'Super-Administrator' Account the  with the default credentials. Create a waiver for users to be created.<br />
5.Change the default password and/or username of the 'Super-Administrator' Account.<br />
6.Optional: Create a normal Administrator account for admin use, and the super admin account for back-up.<br />
7.Create a new parade on the admin home page.<br />
8.Go to the Home > Configure page, at the 'Set the current Parade:' option, select the parade you just created as the current parade and click OK.<br />
9.Create an about description for users to see when they log in. This is located in the waiver section and switching the waiver type to 'About'.<br />
10.Go to the Home > Configure page, at the 'User About Description:' select the user about description you just created as the current description for users to see and select OK.<br />
11.Set-Up Email settings<br />

         </p>
        
    </div>

    <div style="position: absolute; left: 235px; top: 1220px; z-index: 2; height: 204px;
        width: 889px;" id="Div2" runat="server">
     </p><a name="createNewUser"></a> 
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <u style="line-height: 21px;"><span style="line-height: 31px; font-size: 20pt;">
            2.
            Help: Creating new account as user</span></u>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">Go to Website URL and select “<b 
                style="line-height: 22px; font-weight: bold;">User Login</b>” from the menu.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">Click the button to register a 
            new account. It should be located next to the following line:<br 
                style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">Don’t have a user account? 
            Click [here] to register.</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">Fill out Information.<br 
                style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">Account Type, First Name, Last 
            Name, UserName, Password, Phone#, and Email</b>&nbsp;are all required fields. Along 
            with&nbsp;<b style="line-height: 22px; font-weight: bold;">Street Name, City, 
            Province, Postal Code.</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <b style="line-height: 21px; font-weight: bold;">
            <span style="line-height: 18px; font-size: 12pt; color: red;">Volunteer:&nbsp;</span></b><span 
                style="line-height: 18px; font-size: 12pt; color: red;">Someone taking part 
            in the parade.<b style="line-height: 22px; font-weight: bold;"><br 
                style="line-height: 22px;" />
            Participant:&nbsp;</b>An Organization with a Float.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">Accept the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Waiver&nbsp;</b>and hit&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Continue</b>, an Email will be 
            sent to the email address on the form.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <b style="line-height: 21px; font-weight: bold;">
            <span style="line-height: 18px; font-size: 12pt;">Logon</span></b><span 
                style="line-height: 18px; font-size: 12pt;">&nbsp;with the credentials given and 
            input the&nbsp;<b style="line-height: 22px; font-weight: bold;">code</b>&nbsp;sent to&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">your email.</b><br 
                style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">Click Submit.</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">
            <br style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">
            <span style="line-height: 22px; color: red;">Volunteer:&nbsp;</span></b><span 
                style="line-height: 22px; color: red;">Thank you, at any point you can go 
            to&nbsp;<b style="line-height: 22px; font-weight: bold;">Edit &gt; Edit my Details</b>&nbsp;go 
            to the bottom item and click the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">image/link</b>&nbsp;to fill in the 
            fields, click&nbsp;<b style="line-height: 22px; font-weight: bold;">apply</b>&nbsp;to save 
            the information.&nbsp;<b style="line-height: 22px; font-weight: bold;"><br 
                style="line-height: 22px;" />
            <br style="line-height: 22px;" />
            </b></span></span>
        </p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <b style="line-height: 21px; font-weight: bold;">
            <span style="line-height: 18px; font-size: 12pt; color: red;">Participant:&nbsp;</span></b><span 
                style="line-height: 18px; font-size: 12pt; color: red;">&nbsp;You cannot create 
            an&nbsp;<b style="line-height: 22px; font-weight: bold;">Organization</b>&nbsp;in the 
            system until after your account has been approved, and cannot create a&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Float</b>&nbsp;in the system until 
            after your organization has been approved.&nbsp;<br style="line-height: 22px;" />
            <br style="line-height: 22px;" />
            An administrator will review the newly created users and approve your account; 
            this will likely be done after attendance of a meeting. Please see relevant&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Help</b>&nbsp;sections to aid in 
            these actions.<br style="line-height: 22px;" />
            <br style="line-height: 22px;" />
            </span>
        </p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt; color: red;">
            <br style="line-height: 22px;" />
            </span>
        </p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt; color: red;">
            <br style="line-height: 22px;" />
            </span>
        </p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt; color: red;">
            <br style="line-height: 22px;" />
            </span>
        </p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt; color: red;">
            <br style="line-height: 22px;" />
            </span>
        </p>
        <p style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
        </p>
        <a name="createNewAdminUser"></a> 
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153); text-align: center;">
            <u style="line-height: 21px;"><span style="line-height: 31px; font-size: 20pt;">
            3.
            Help: Creating new account as admin</span></u></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">Select<b 
                style="line-height: 22px; font-weight: bold;">&nbsp;Edit &gt; Create a User</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">Fill out Information.<br 
                style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">Account Type, First Name, Last 
            Name, UserName, Password, and Email</b>&nbsp;are all required fields.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <b style="line-height: 21px; font-weight: bold;">
            <span style="line-height: 18px; font-size: 12pt; color: red;">Volunteer:&nbsp;</span></b><span 
                style="line-height: 18px; font-size: 12pt; color: red;">Someone taking part 
            in the parade.<b style="line-height: 22px; font-weight: bold;"><br 
                style="line-height: 22px;" />
            Participant:&nbsp;</b>An Organization with a Float.<b 
                style="line-height: 22px; font-weight: bold;"><br 
                style="line-height: 22px;" />
            Administrator:&nbsp;</b>A new Admin account.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">Accept the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Waiver&nbsp;</b>and hit&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Submit</b>, an Email will be 
            sent to the email address on the form.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">A List of all users will 
            appear, moving to the last page will show you the most recently added.</span></p>
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153); text-align: center;">
            <br style="line-height: 21px;" />
        </p>
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153); text-align: center;">
            <br style="line-height: 21px;" />
        </p>
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153); text-align: center;">
            <br style="line-height: 21px;" />
        </p>
        <a name="approveNewAccount"></a> 
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153); text-align: center;">
            <u style="line-height: 21px;"><span style="line-height: 31px; font-size: 20pt;">
            4.
            Help: Approve New Account</span></u></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">From the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Home</b>&nbsp;page find the green “<b 
                style="line-height: 22px; font-weight: bold;">View users that have been 
            added today</b>” and select&nbsp;<b style="line-height: 22px; font-weight: bold;">View</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">A list of all the newly added 
            users will appear.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <b style="line-height: 21px; font-weight: bold;">
            <span style="line-height: 18px; font-size: 12pt;">Click&nbsp;</span></b><span 
                style="line-height: 18px; font-size: 12pt;">on the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">image/link</b>&nbsp;under the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">search</b>&nbsp;under a user to 
            bring you to an edit/delete area.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <i style="line-height: 21px; font-style: italic;">
            <span style="line-height: 18px; font-size: 12pt;">Alternately:</span></i><span 
                style="line-height: 18px; font-size: 12pt;">&nbsp;You can go to&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Edit &gt; Edit or Delete Users</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <b style="line-height: 21px; font-weight: bold;">
            <span style="line-height: 18px; font-size: 12pt;">Click&nbsp;</span></b><span 
                style="line-height: 18px; font-size: 12pt;">on the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">image/link</b>&nbsp;under the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">activate</b>&nbsp;to activate the 
            user account.&nbsp;<br style="line-height: 22px;" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;this can be used to activate accounts after a user has visited a 
            presentation.</span></p>
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153); text-align: center;">
            <br style="line-height: 21px;" />
        </p>
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153); text-align: center;">
            <br style="line-height: 21px;" />
        </p>
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153); text-align: center;">
            <br style="line-height: 21px;" />
        </p>
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153); text-align: center;">
            <br style="line-height: 21px;" />
        </p>
        <a name="newOrg"></a> 
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153); text-align: center;">
            <u style="line-height: 21px;"><span style="line-height: 31px; font-size: 20pt;">
            5.
            Help: Creating new Organization</span></u></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">Select<b 
                style="line-height: 22px; font-weight: bold;">&nbsp;Edit &gt; Create a User &gt; Add 
            Organization</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">Fill out Information.<br 
                style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">Organization Name, Contact 
            Name, Phone#, Email</b>&nbsp;are all required fields.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">Accept the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Waiver&nbsp;</b>and hit&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Submit</b>, an Email will be 
            sent to the email address on the form.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">A List of all users will 
            appear, moving to the last page will show you the most recently added.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">&nbsp;</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">
            <br style="line-height: 22px;" />
            </span>
        </p>
        <a name="approveNewOrg"></a> 
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153); text-align: center;">
            <u style="line-height: 21px;"><span style="line-height: 31px; font-size: 20pt;">
            6.
            Help: Approve New Organization</span></u></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">From the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Home</b>&nbsp;page find the green “<b 
                style="line-height: 22px; font-weight: bold;">View organizations that have 
            been added today</b>” and select&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">View<br 
                style="line-height: 22px;" />
            </b>A list of all the newly added users will appear.&nbsp;<br 
                style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">Click&nbsp;</b>on the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">image/link</b>&nbsp;under the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">search</b>&nbsp;under a user to 
            bring you to an edit/delete area.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <i style="line-height: 21px; font-style: italic;">
            <span style="line-height: 18px; font-size: 12pt;">Alternately:</span></i><span 
                style="line-height: 18px; font-size: 12pt;">&nbsp;You can go to&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Edit &gt; Edit Organization 
            Details&nbsp;<br style="line-height: 22px;" />
            <br style="line-height: 22px;" />
            Click&nbsp;</b>on the&nbsp;<b style="line-height: 22px; font-weight: bold;">image/link</b>&nbsp;under 
            the&nbsp;<b style="line-height: 22px; font-weight: bold;">activate</b>&nbsp;to activate 
            the user account.&nbsp;<br style="line-height: 22px;" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;this can be used to activate accounts after a user has visited a 
            presentation.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">&nbsp;</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">&nbsp;</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">&nbsp;</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">&nbsp;</span></p>
            <a name="newFloat"></a> 
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153); text-align: center;">
            <u style="line-height: 21px;"><span style="line-height: 31px; font-size: 20pt;">
            7.
            Help: Creating new Float</span></u></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">Select<b 
                style="line-height: 22px; font-weight: bold;">&nbsp;Edit &gt; Create a User &gt; Add 
            Organization &gt; Add Float</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">Fill out Information.<br 
                style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">Parade, Organization, Entry 
            Type, Float Type, Float Length, Height, Width, Marcher count, waiver acceptor, 
            Float Description, and Banner</b>&nbsp;are all required fields.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">Accept the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Terms &amp; Agreements&nbsp;</b>and 
            hit&nbsp;<b style="line-height: 22px; font-weight: bold;">Submit</b>.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">A List of all users will 
            appear, moving to the last page will show you the most recently added.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">&nbsp;</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">
            <br style="line-height: 22px;" />
            </span>
        </p>
        <a name="approveNewFloat"></a> 
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153); text-align: center;">
            <u style="line-height: 21px;"><span style="line-height: 31px; font-size: 20pt;">
            8.
            Help: Approve New Float</span></u></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">From the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Home</b>&nbsp;page find the green&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Edit &gt; Edit Float Details</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <span style="line-height: 18px; font-size: 12pt;">A list of all the added floats 
            will appear.&nbsp;<br style="line-height: 22px;" />
            <br style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">Click&nbsp;</b>on the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">image/link</b>&nbsp;under the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">search</b>&nbsp;under a user to 
            bring you to an edit/delete area.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 153);">
            <b style="line-height: 21px; font-weight: bold;">
            <span style="line-height: 18px; font-size: 12pt;">Click&nbsp;</span></b><span 
                style="line-height: 18px; font-size: 12pt;">on the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">image/link</b>&nbsp;under the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">activate</b>&nbsp;to activate the 
            user account.&nbsp;<br style="line-height: 22px;" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;this can be used to activate accounts after a user has visited a 
            presentation.</span></p>
        <br class="Apple-interchange-newline" />
        <p>  </p>
        
    </div>
   
   
        </form >
</body>
</html>

