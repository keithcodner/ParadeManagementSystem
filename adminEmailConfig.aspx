﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminEmailConfig.aspx.cs"
    Inherits="adminEmailConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="shortcut icon" href="images/santaIcon.ico" />
    <title>Administrator Area</title>
    <style type="text/css">
        body
        {
            padding: 5px;
            font-family: Helvetica, Arial, Sans-Serif;
            color: Black;
        }
        *
        {
            padding: 0;
            margin: 0;
        }
        ul
        {
            font-family: Arial, Verdana;
            font-size: 14px;
            margin: 0;
            padding: 0;
            list-style: none;
        }
        ul li
        {
            display: block;
            position: relative;
            float: left;
        }
        li ul
        {
            display: none;
        }
        ul li a
        {
            display: block;
            text-decoration: none;
            color: #ffffff;
            border-top: 1px solid #ffffff;
            padding: 5px 15px 5px 15px;
            background: #2C5463;
            margin-left: 1px;
            white-space: nowrap;
        }
        ul li a:hover
        {
            background: #617F8A;
        }
        li:hover ul
        {
            display: block;
            position: absolute;
        }
        li:hover li
        {
            float: none;
            font-size: 11px;
        }
        li:hover a
        {
            background: #617F8A;
        }
        li:hover li a:hover
        {
            background: #95A9B1;
        }
        
        li > ul li > ul
        {
            left: 100%;
            top: 0;
            padding-left: 1px;
        }
        li > ul li > ul li
        {
            width: 130px;
        }
    </style>
<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000" bgcolor="#ffff99">
    <form id="form1" runat="server">
    <font color="#990000" size="+3">Administrator Area: Email Configuration Page</font></p>
    <div id="Layer1" style="position: absolute; left: 62px; top: 64px; width: 371px;
        height: 111px; z-index: 6">
        Welcome :<asp:Label ID="usernameSession" runat="server" Text=""></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="logoutButton" runat="server" Text=" Logout " CausesValidation="false"
            OnClick="logoutButton_Click" />
        <ul>
            <li><a href="adminHomeArea.aspx">Home</a>
                <ul>
                    <li><a href="myAdmin.aspx">My Admin</a>
                        <ul>
                        </ul>
                    </li>
                    <li><a href="adminConfig.aspx">Configure</a><ul>
                        <li><a href="Recover.aspx">Recover Users</a></ul>
                    </li>
                    <li><a href="#">Tools</a><ul>
                        <li><a href="addChangebanner.aspx">Add/Delete Banner</a></li><li><a href="addChangeWaiveraspx.aspx">
                            Add/Delete Waiver</a></li><li><a href="trasnferOrg.aspx">Transfer Org. Or User</a></li>
                        <li><a href="DropdownMods.aspx">DropdownList Mods</a></li><li><a href="activityLog.aspx">Activity Log</a></li><li><a href="Donwloads.aspx">Manage Downloads</a></li><li><a href="adminEmail.aspx">
                            Email Settings</a></li></ul>
                    </li>
                </ul>
            </li>
            <li><a href="#">View</a>
                <ul>
                    <li><a href="viewParadeInfo.aspx">View Organization Information</a></li>
                    <li><a href="adminArea.aspx">User Details</a></li>
                    <li><a href="paradeDetails.aspx">Parade Details</a></li><li><a href="floatDetails.aspx">
                        Float Details</a></li>
                </ul>
            </li>
            <li><a href="#">Edit</a>
                <ul>
                    <li><a href="adminCreateUser.aspx">Create a User</a>
                        <ul>
                            <li><a href="addOrganization.aspx">Add Organization </a>
                                <ul>
                                    <li><a href="addFloat.aspx">Add Float</a></li></ul>
                            </li>
                        </ul>
                    </li>
                    <li><a href="editOrDeleteUser.aspx">Edit or Delete User</a></li>
                    <li><a href="editParadeInfo.aspx">Edit Organization Details</a></li><li><a href="editFloatDetailsaspx.aspx">
                        Edit Float Details</a></li><li><a href="editParades.aspx">Edit Parade Details</a></li>
                </ul>
            </li>
            <li><a href="#">Reports</a>
                <ul>
                    <li><a href="#">List's</a><ul>
                        <li><a href="#">Attendance</a><ul>
                            <li><a href="reportGen.aspx">Org. Attendance List</a><ul>
                                <li><a href="VolAttendanceList.aspx">Vol. Attendance List</a></li></ul>
                            </li>
                        </ul>
                        </li>
                        <li><a href="#">Float's</a><ul>
                            <li><a href="ApprovedFloats.aspx">Approved Floats</a></li></ul>
                        </li>
                    </ul>
                    </li>
                    <li><a href="#">Statistics</a>
                        <ul>
                            <li><a href="statReport.aspx">Stat Report</a></li></ul>
                    </li>
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
    <b>Reset Your Pasword :</b><br />
    <br />
    &nbsp;&nbsp;
    <div id="spare" runat="server" visible="false" style="border: 5px solid blue; position: absolute;
        left: 253px; top: 237px; z-index: 4; height: 77px; width: 741px; background-color: #FF6600;">
        Options:
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RadioButton ID="deleteFloatTran" runat="server" Text="   Delete floats when organization  is transferred." />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </div>
    <div id="Div1" runat="server" style="position: absolute; left: 2px; top: 291px; z-index: 5;
        height: 88px; width: 965px;">
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
    </form>
</body>
</html>
