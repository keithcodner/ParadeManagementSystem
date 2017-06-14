<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminCreateUser.aspx.cs"
    Inherits="adminCreateUser" %>

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
    <form id="form1" defaultbutton="createUserSubmit" runat="server">
    <font color="#990000" size="+3">Administrator Area: Create User</font></p>
    <div id="Layer1" style="position: absolute; left: 62px; top: 64px; width: 362px;
        height: 111px; z-index: 1">
        Welcome :<asp:Label ID="usernameSession" runat="server" Text=""></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="logoutButton" runat="server" Text=" Logout "  CausesValidation="false"   OnClick="logoutButton_Click" />
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
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    Create a User:
    <asp:Label ID="UserNameExists" runat="server" ForeColor="Red" Text=""></asp:Label>
    <br />
    <br />
    <table class="style1">
    <tr>
            <td class="style6">
                Select Account Type:
            </td>
            <td class="style3">
                <asp:DropDownList ID="eAccountType" runat="server" Height="20px" Width="158px" 
                    AutoPostBack="True">
                    <asp:ListItem Value="">-Select Account Type-</asp:ListItem>
                    <asp:ListItem Value="Administrator">Administrator</asp:ListItem>
                    <asp:ListItem Value="Participant">Participant</asp:ListItem>
                    <asp:ListItem Value="Volunteer">Volunteer</asp:ListItem>
                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RFVeAccountType" runat="server" ErrorMessage="*Account Type is Required*"
                    ForeColor="Red" ControlToValidate="eAccountType"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                First Name:
            </td>
            <td class="style3">
                <asp:TextBox ID="eFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateFirstName" runat="server" ErrorMessage="*First Name is required"
                    ControlToValidate="eFirstName" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Last Name :
            </td>
            <td class="style3">
                <asp:TextBox ID="eLastName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateLastName" runat="server" ErrorMessage="*Last Name is required"
                    ForeColor="Red" ControlToValidate="eLastName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                UserName:<font color="#FFFFFF">.</font>
            </td>
            <td class="style3">
                <asp:TextBox ID="eUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateUserName" runat="server" ErrorMessage="*Username is required"
                    ForeColor="Red" ControlToValidate="eUsername"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Password:
            </td>
            <td class="style3">
                <asp:TextBox ID="ePassword" runat="server" TextMode="Password"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator
                        ID="validatePassword" runat="server" ErrorMessage="*Password is required" ForeColor="Red"
                        ControlToValidate="ePassword"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Re-type Password:
            </td>
            <td class="style3">
                <asp:TextBox ID="Re_ePassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validatePasswordReEntry" runat="server" ControlToValidate="Re_ePassword"
                    ErrorMessage="*You did not re-type password" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="validatePasswordMatch" runat="server" ErrorMessage="*Password did not match"
                    ForeColor="Red" ControlToCompare="ePassword" ControlToValidate="Re_ePassword"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
                    <td class="style4">
                        Street :
                    </td>
                    <td>
                        <asp:TextBox ID="eeStreet" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Street name is required"
                    ForeColor="Red" ControlToValidate="eeStreet"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        City:
                    </td>
                    <td>
                        
                        <asp:TextBox ID="eeCity" runat="server"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*City name is required"
                    ForeColor="Red" ControlToValidate="eeCity"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Province :
                    </td>
                    <td>
                        <asp:DropDownList ID="eeProv" runat="server" Height="20px" Width="158px">
                            <asp:ListItem Value="">-Select Province-</asp:ListItem>
                            <asp:ListItem Value="Alberta">Alberta</asp:ListItem>
                            <asp:ListItem Value="British Columbia">British Columbia</asp:ListItem>
                            <asp:ListItem Value="Ontario">Ontario</asp:ListItem>
                            <asp:ListItem Value="Prince Edward Island">Prince Edward Island</asp:ListItem>
                            <asp:ListItem Value="Manitoba">Manitoba</asp:ListItem>
                            <asp:ListItem Value="New Brunswick">New Brunswick</asp:ListItem>
                            <asp:ListItem Value="Nova Scotia">Nova Scotia</asp:ListItem>
                            <asp:ListItem Value="Saskatchewan">Saskatchewan</asp:ListItem>
                            <asp:ListItem Value="Newfoundland and Labrador">Newfoundland and Labrador</asp:ListItem>
                            <asp:ListItem Value="Northwest Territories">Northwest Territories</asp:ListItem>
                            <asp:ListItem Value="Nunavut">Nunavut</asp:ListItem>
                            <asp:ListItem Value="Quebec">Quebec</asp:ListItem>
                            <asp:ListItem Value="Yukon">Yukon</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Province is Required*"
                    ForeColor="Red" ControlToValidate="eeProv"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Postal Code:
                    </td>
                    <td>
                        <asp:TextBox ID="eePost" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Postal Code name is required"
                    ForeColor="Red" ControlToValidate="eePost"></asp:RequiredFieldValidator>
                    </td>
                </tr>
        <tr>
            <td class="style6">
                Home/Cell Number:
            </td>
            <td class="style3">
                <asp:TextBox ID="eHomeNumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Business Number:
            </td>
            <td class="style3">
                <asp:TextBox ID="eBusinessNumber" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style4">
                Email :
            </td>
            <td class="style5">
                <asp:TextBox ID="eEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateEmail" runat="server" ErrorMessage="*Email is Required*"
                    ForeColor="Red" ControlToValidate="eEmail"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
              <asp:Label ID="OrgLabel" runat="server" Text="Organization Name: "></asp:Label>
            </td>
            <td class="style5">
                <asp:TextBox ID="OrgName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVORganizaitonName" runat="server" ErrorMessage="*Organization is Required*"
                    ForeColor="Red" ControlToValidate="OrgName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        

        <tr>
            <td class="style6">
               <!-- Waiver Agreement: --></td>
            <td class="style3">
               
                <asp:TextBox ID="waiverEditBody" runat="server" Height="222px" Visible = "False"
                    TextMode="MultiLine" Width="672px" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        
         <tr>
            <td class="style6">
              </td>
            <td class="style3"><br /><br /><br />
                <asp:CheckBox ID="checkBoxAgree" runat="server" 
                    Text="  I accept these Terms and Conditions" CausesValidation="True" />
                
                
                <asp:Label ID="Label1" runat="server" ForeColor="Red" 
                    Text="* You did not check the agreement box."></asp:Label>
                
                
            </td>
        </tr>
    </table>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="createUserSubmit" runat="server" Text=" Submit " OnClick="createUserSubmit_Click" />
    <br />
    <br />
    <p>
        &nbsp;<p>
            &nbsp;<p>
                &nbsp;</p>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </p>
            <asp:Label ID="rePassValid" runat="server" Text=""></asp:Label>
            <br />
            <asp:Label ID="test" runat="server" Text="Label"></asp:Label>
            <br />
    </form>
</body>
</html>
