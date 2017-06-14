<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userHelpDoc.aspx.cs" Inherits="userHelpDoc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server"><link rel="shortcut icon" href="images/santaIcon.ico" />
    <title>User Area</title>
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
<body link="#006600" vlink="#990000" bgcolor="#ffffff">
<form id="form1" runat="server">

 
<font color="#990000" size="+3">User <asp:Label ID="volOrPart" runat="server" Text=""></asp:Label>  Area: Help Documentation</font></p>
<div id="Layer1" 
        
        
        
    style="position:absolute; left:62px; top:64px; width:371px; height:111px; z-index:6"> 
 Welcome :<asp:Label ID="usernameSession" runat="server" Text=""></asp:Label> 
 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
    <asp:Button ID="logoutButton" runat="server" Text=" Logout "  CausesValidation="false"  
        onclick="logoutButton_Click" />

<ul>
            <li><a href="userHomeLogin.aspx">Home</a><ul><li><a href="userPasswordManagment.aspx">Change Password</a></li><li><a href="contactAdmin.aspx">Contact Admin</a></li><li><a href="userHelpDoc.aspx">Get Help</a></li></ul>
         
                   
 
             <%--  
                    <li><a href="adminConfig.aspx">Configure</a><ul><li><a href="Recover.aspx">Recover Users</a></ul></li>
                    <li><a href="#">Tools</a><ul>
                        <li><a href="addChangebanner.aspx">Add/Delete Banner</a></li><li><a href="addChangeWaiveraspx.aspx">
                            Add/Delete Waiver</a></li> <li><a href="trasnferOrg.aspx">Transfer Org. Or User</a></li> <li><a href="DropdownMods.aspx">DropdownList Mods</a></li><li><a href="activityLog.aspx">Activity Log</a></li><li><a href="Donwloads.aspx">Manage Downloads</a></li><li><a href="adminEmail.aspx">Email Settings</a></li></ul>
                    </li>
                </ul> --%>
            </li>
            <li><a href="#">View</a><ul><li><a href="userDetailsView.aspx">My Details</a></li></ul>
                <%--  <ul>
                    <li><a href="viewParadeInfo.aspx">View Organization Information</a></li>
                    <li><a href="adminArea.aspx">User Details</a></li>
                    <li><a href="paradeDetails.aspx">Parade Details</a></li><li><a href="floatDetails.aspx">Float Details</a></li>
                </ul> --%>
            </li>
            <li><a href="#">Edit</a><ul><li><a href="userDetailsEdit.aspx">Edit My Details</a></li></ul>
                <%--  <ul>
                    <li><a href="adminCreateUser.aspx">Create a User</a>
                        <ul>
                            <li><a href="addOrganization.aspx">Add Organization   </a><ul><li><a href="addFloat.aspx">Add Float</a></li></ul></li>
                        </ul>
                    </li>
                    <li><a href="editOrDeleteUser.aspx">Edit or Delete User</a></li>
                    <li><a href="editParadeInfo.aspx">Edit Organization Details</a></li><li><a href="editFloatDetailsaspx.aspx">Edit Float Details</a></li><li><a href="editParades.aspx">Edit Parade Details</a></li>
                </ul> --%>
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
    <div style="border: 1px solid #000000; position: absolute; left: 60px; top: 242px; z-index: 4; height: 153px;
        width: 243px; background-color: #5F9EA0;" id="spare" runat="server">
     
        
        
        
       <a href="#top" ></a>
        <br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Table of Contents: <br /><br />
        &nbsp;
        1.<asp:HyperLink ID="changePassword" runat="server" href="#gettingStarted">Getting Started</asp:HyperLink><br />
        &nbsp;
        2.<asp:HyperLink ID="HyperLink1" runat="server" href="#createNewUser">Creating new account as user</asp:HyperLink><br />
        &nbsp;
        3.<asp:HyperLink ID="HyperLink4" runat="server" href="#newOrg">Creating new Organization</asp:HyperLink><br />
        &nbsp;
        
       
        4.<asp:HyperLink ID="HyperLink6" runat="server" href="#newFloat">Creating new Float</asp:HyperLink><br />
        &nbsp;
       
        
     &nbsp;&nbsp;&nbsp;&nbsp;  
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       
    </div>

    <div style="position: absolute; left: 237px; top: 546px; z-index: 2; height: 204px;
        width: 889px;" id="Div1" runat="server">
     
        <b>1. Getting Started </b>
        <p>What you need to know about the Parade Management System (PMS) is that things in the parade system  are related. The PMS is comprised of four main parts the  parade, user, organizations, and the floats. There are a lot of other parts that make the System convenient but those will be explain later. First we start with the Parade, a parade must be created first as almost every other part in the PMS relies on a parade existing.  Next  a user must be made, a user can have three kinds of status. These status' are Administrator, Volunteer and Participant, for now we will focus on the participant status. Only users that have the participant status are permitted to make organizations and go on to have floats in the parade. So have the parade and the user with the particpant status are created the next phase is making an organization. An organization is an entity that is permitted to enter floats in the current parade, the organization must be connected to a user by the field of (Contact) in the organization table. When a orgniazation is generated a float is also generated automatically with the (Contact) connecting the float to the organization and the (Contact) connecting the organization to the user, however if an orgniazation so wishes they can add additional floats to their organization, but ofcourse being approved by administration first. This concludes a basic description of what the PMS requires to operate for first time or quick 'know-how' use. For more indepth Help and Tutorials look below or check out the table of contents.  </p>
        
    </div>
   <div style="position: absolute; left: 240px; top: 885px; z-index: 2; height: 204px;
        width: 889px;" id="Div2" runat="server">
     </p><a name="createNewUser"></a> 
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <u style="line-height: 21px;"><span style="line-height: 31px; font-size: 20pt;">
            2.
            Help: Creating new account as user</span></u>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">Go to Website URL and select “<b 
                style="line-height: 22px; font-weight: bold;">User Login</b>” from the menu.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">Click the button to register a 
            new account. It should be located next to the following line:<br 
                style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">Don’t have a user account? 
            Click [here] to register.</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">Fill out Information.<br 
                style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">Account Type, First Name, Last 
            Name, UserName, Password, Phone#, and Email</b>&nbsp;are all required fields. Along 
            with&nbsp;<b style="line-height: 22px; font-weight: bold;">Street Name, City, 
            Province, Postal Code.</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <b style="line-height: 21px; font-weight: bold;">
            <span style="line-height: 18px; font-size: 12pt; color: red;">Volunteer:&nbsp;</span></b><span 
                style="line-height: 18px; font-size: 12pt; color: red;">Someone taking part 
            in the parade.<b style="line-height: 22px; font-weight: bold;"><br 
                style="line-height: 22px;" />
            Participant:&nbsp;</b>An Organization with a Float.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">Accept the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Waiver&nbsp;</b>and hit&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Continue</b>, an Email will be 
            sent to the email address on the form.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <b style="line-height: 21px; font-weight: bold;">
            <span style="line-height: 18px; font-size: 12pt;">Logon</span></b><span 
                style="line-height: 18px; font-size: 12pt;">&nbsp;with the credentials given and 
            input the&nbsp;<b style="line-height: 22px; font-weight: bold;">code</b>&nbsp;sent to&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">your email.</b><br 
                style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">Click Submit.</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
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
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
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
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt; color: red;">
            <br style="line-height: 22px;" />
            </span>
        </p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt; color: red;">
            <br style="line-height: 22px;" />
            </span>
        </p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt; color: red;">
            <br style="line-height: 22px;" />
            </span>
        </p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt; color: red;">
            <br style="line-height: 22px;" />
            </span>
        </p>
        <p style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
        </p>
        <a name="newOrg"></a> 
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-align: center;">
            <u style="line-height: 21px;"><span style="line-height: 31px; font-size: 20pt;">
           
            
            3.
            Help: Creating new Organization</span></u></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">Select<b 
                style="line-height: 22px; font-weight: bold;">&nbsp;Edit &gt; Create a User &gt; Add 
            Organization</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">Fill out Information.<br 
                style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">Organization Name, Contact 
            Name, Phone#, Email</b>&nbsp;are all required fields.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">Accept the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Waiver&nbsp;</b>and hit&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Submit</b>, an Email will be 
            sent to the email address on the form.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">A List of all users will 
            appear, moving to the last page will show you the most recently added.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">&nbsp;</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">
            <br style="line-height: 22px;" />
            </span>
        </p>
        <a name="newFloat"></a> 
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-align: center;">
            <u style="line-height: 21px;"><span style="line-height: 31px; font-size: 20pt;">
           
            4.
            Help: Creating new Float</span></u></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">Select<b 
                style="line-height: 22px; font-weight: bold;">&nbsp;Edit &gt; Create a User &gt; Add 
            Organization &gt; Add Float</b></span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">Fill out Information.<br 
                style="line-height: 22px;" />
            <b style="line-height: 22px; font-weight: bold;">Parade, Organization, Entry 
            Type, Float Type, Float Length, Height, Width, Marcher count, waiver acceptor, 
            Float Description, and Banner</b>&nbsp;are all required fields.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">Accept the&nbsp;<b 
                style="line-height: 22px; font-weight: bold;">Terms &amp; Agreements&nbsp;</b>and 
            hit&nbsp;<b style="line-height: 22px; font-weight: bold;">Submit</b>.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">A List of all users will 
            appear, moving to the last page will show you the most recently added.</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">&nbsp;</span></p>
        <p class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);">
            <span style="line-height: 18px; font-size: 12pt;">
            <br style="line-height: 22px;" />
            </span>
        </p>
        <a name="approveNewFloat"></a> 
        <p align="center" class="ecxMsoNormal" 
            style="line-height: 21px; margin: 0px 0px 1.35em; color: rgb(0, 0, 0); font-family: Calibri, sans-serif; font-size: 15px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-align: center;">
            <u style="line-height: 21px;"><span style="line-height: 31px; font-size: 20pt;">
           
            </p>
        <br class="Apple-interchange-newline" />
        <p>  </p>
        
    </div>
        </form >
</body>
</html>


