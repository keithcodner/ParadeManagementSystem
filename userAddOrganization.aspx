<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userAddOrganization.aspx.cs" Inherits="userAddOrganization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000" bgcolor="#ffffff">
    <form id="form1" defaultbutton="Button1" runat="server">
    <font color="#990000" size="+3">User Area: Add An Organization</font>
    <div id="Layer1" style="position: absolute; left: 62px; top: 64px; width: 1019px;
        height: 60px; z-index: 7">
        Welcome :<asp:Label ID="usernameSession" runat="server" Text=""></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="logoutButton" runat="server" Text=" Logout "  CausesValidation="false"  OnClick="logoutButton_Click" />
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
   
    <br />
    <br />
    <br />
    <br />
    <br />
    <br /><br /><br />
    Create a Organization:
    <br />
    <br />

    <div id="Div2" style="position: absolute; left: 67px; top: 220px; width: 1112px;
        height: 615px; z-index: 2">
    <table class="style1">
        <tr>
            <td class="style3">
          <font color="#ffffff">   Organization:  </font>
            </td>
            <td>
                
                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                    SelectCommand="SELECT uID, uFName FROM user WHERE uStatus = 'Participant'">
                </asp:SqlDataSource>
                
            </td>
        </tr>
        <tr>
            <td class="style3">
             <font color="#ffffff">   Contact Name: </font>
            </td>
            <td>
               
                
                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                    SelectCommand="SELECT uID, uFName FROM user WHERE uStatus = 'Participant'">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="style3">
             <font color="#ffffff">   Address 1: </font>
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" BorderColor="#ffffff" 
                    BorderStyle="Solid" BackColor="#ffffff"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td class="style3">
             <font color="#ffffff">   City: </font>
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" BorderColor="#ffffff" 
                    BorderStyle="Solid" BackColor="#ffffff" ></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td class="style3">
             <font color="#ffffff">   Province: </font>
            </td>
            <td>
               
                
            </td>
        </tr>
        <tr>
            <td class="style3">
               <font color="#ffffff"> Country: </font>
            </td>
            <td>
                
                
            </td>
        </tr>
        <tr>
            <td class="style3">
              <font color="#ffffff">  Postal Code: </font>
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" BorderColor="#ffffff" 
                    BorderStyle="Solid" BackColor="#ffffff" ></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"         
        ErrorMessage="*Postal/Zip code format must be ei. A1A 1A1 or 12345 " 
        ValidationExpression="(^[ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]\d[ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvxy]( )?\d[ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvxy]\d$)|(^\d{5}(-\d{4})?$)" 
        ControlToValidate="ePostal" ForeColor="Red"></asp:RegularExpressionValidator>
                
            </td>
        </tr>
        <tr>
            <td class="style3">
              <font color="#ffffff">  Home/Cell #: </font>
            </td>
            <td>
                <asp:TextBox ID="TextBox4" runat="server" BorderColor="#ffffff" 
                    BorderStyle="Solid" BackColor="#ffffff" ></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"         
        ErrorMessage="*Number must be in following format ei. 1234567891" 
        ValidationExpression="1?\W*([2-9][0-8][0-9])\W*([2-9][0-9]{2})\W*([0-9]{4})(\se?x?t?(\d*))?" 
        ControlToValidate="ePhone" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
             <font color="#ffffff">   Email: </font>
            </td>
            <td>
                <asp:TextBox ID="TextBox5" runat="server" BorderColor="#ffffff" 
                    BorderStyle="Solid" BackColor="#ffffff" ></asp:TextBox>
                 <asp:RegularExpressionValidator ID="emailREV" runat="server"         
        ErrorMessage="*Email is case in-sensitive. Must be in email format ie. paradems@example.com " 
        ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" 
        ControlToValidate="eEmail" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
              <font color="#ffffff">  Web Site: </font>
            </td>
            <td>
                <asp:TextBox ID="TextBox6" runat="server" BorderColor="#ffffff" 
                    BorderStyle="Solid" BackColor="#ffffff" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                
            </td>
            <td>
              
            </td>
        </tr>
         <tr>
            <td class="style3">
                
            <font color="#ffffff">    Waiver Agreement:  </font> </td>
            <td>
              
               
              
            </td>
        </tr>
        <tr>
            <td class="style3">
                
                &nbsp;</td>
            <td>
              
                <br />
                
              
            </td>
        </tr>
    </table>
    </ div>

    <%-- //////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////--%>

    <div id="Div1" style="position: absolute; left: -1px; top: 1px; width: 993px;
        height: 615px; z-index: 1">
    <table class="style1">
        <tr>
            <td class="style3">
                  Organization: 
            </td>
            <td>
                
                <asp:DropDownList ID="eOrganizaiton" runat="server" 
                    DataSourceID="SqlDataSource1" DataTextField="uOrgName" DataValueField="uID" 
                     Width="162px">
                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                    SelectCommand="SELECT uID, uFName FROM user WHERE uStatus = 'Participant'">
                </asp:SqlDataSource>
                <asp:RequiredFieldValidator ID="eOrganizationCtrl" runat="server" ControlToValidate="eOrganizaiton"
                    ErrorMessage="*Organization is required" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                 Contact Name: 
            </td>
            <td>
                <asp:DropDownList ID="eContact" runat="server" DataSourceID="SqlDataSource2" DataTextField="concat (ufname,' ', ulname)"
                    DataValueField="uID" Width="164px" AppendDataBoundItems="True">
                    <asp:ListItem Value="">-Select Contact-</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="eContact"
                    ErrorMessage="*Valid Contact Name  is Required*" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>"
                    ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
                    
                    SelectCommand="SELECT uID, concat (ufname,' ', ulname)  FROM user WHERE uStatus = 'Participant'">
                </asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="style3">
              Address 1: 
            </td>
            <td>
                <asp:TextBox ID="eAddress1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="eAddress1"
                    ErrorMessage="*Address is Required*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
               City: 
            </td>
            <td>
                
               
                    
                <asp:TextBox ID="eCity" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="eCity"
                    ErrorMessage="*City is Required*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Province: 
            </td>
            <td>
                <asp:DropDownList ID="eProvince" runat="server" Height="20px" Width="158px">
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
                    <asp:ListItem Value="AL">Alabama</asp:ListItem>
                    <asp:ListItem Value="AK">Alaska</asp:ListItem>
                    <asp:ListItem Value="AZ">Arizona</asp:ListItem>
                    <asp:ListItem Value="AR">Arkansas</asp:ListItem>
                    <asp:ListItem Value="CA">California</asp:ListItem>
                    <asp:ListItem Value="CO">Colorado</asp:ListItem>
                    <asp:ListItem Value="CT">Connecticut</asp:ListItem>
                    <asp:ListItem Value="DC">District of Columbia</asp:ListItem>
                    <asp:ListItem Value="DE">Delaware</asp:ListItem>
                    <asp:ListItem Value="FL">Florida</asp:ListItem>
                    <asp:ListItem Value="GA">Georgia</asp:ListItem>
                    <asp:ListItem Value="HI">Hawaii</asp:ListItem>
                    <asp:ListItem Value="ID">Idaho</asp:ListItem>
                    <asp:ListItem Value="IL">Illinois</asp:ListItem>
                    <asp:ListItem Value="IN">Indiana</asp:ListItem>
                    <asp:ListItem Value="IA">Iowa</asp:ListItem>
                    <asp:ListItem Value="KS">Kansas</asp:ListItem>
                    <asp:ListItem Value="KY">Kentucky</asp:ListItem>
                    <asp:ListItem Value="LA">Louisiana</asp:ListItem>
                    <asp:ListItem Value="ME">Maine</asp:ListItem>
                    <asp:ListItem Value="MD">Maryland</asp:ListItem>
                    <asp:ListItem Value="MA">Massachusetts</asp:ListItem>
                    <asp:ListItem Value="MI">Michigan</asp:ListItem>
                    <asp:ListItem Value="MN">Minnesota</asp:ListItem>
                    <asp:ListItem Value="MS">Mississippi</asp:ListItem>
                    <asp:ListItem Value="MO">Missouri</asp:ListItem>
                    <asp:ListItem Value="MT">Montana</asp:ListItem>
                    <asp:ListItem Value="NE">Nebraska</asp:ListItem>
                    <asp:ListItem Value="NV">Nevada</asp:ListItem>
                    <asp:ListItem Value="NH">New Hampshire</asp:ListItem>
                    <asp:ListItem Value="NJ">New Jersey</asp:ListItem>
                    <asp:ListItem Value="NM">New Mexico</asp:ListItem>
                    <asp:ListItem Value="NY">New York</asp:ListItem>
                    <asp:ListItem Value="NC">North Carolina</asp:ListItem>
                    <asp:ListItem Value="ND">North Dakota</asp:ListItem>
                    <asp:ListItem Value="OH">Ohio</asp:ListItem>
                    <asp:ListItem Value="OK">Oklahoma</asp:ListItem>
                    <asp:ListItem Value="OR">Oregon</asp:ListItem>
                    <asp:ListItem Value="PA">Pennsylvania</asp:ListItem>
                    <asp:ListItem Value="RI">Rhode Island</asp:ListItem>
                    <asp:ListItem Value="SC">South Carolina</asp:ListItem>
                    <asp:ListItem Value="SD">South Dakota</asp:ListItem>
                    <asp:ListItem Value="TN">Tennessee</asp:ListItem>
                    <asp:ListItem Value="TX">Texas</asp:ListItem>
                    <asp:ListItem Value="UT">Utah</asp:ListItem>
                    <asp:ListItem Value="VT">Vermont</asp:ListItem>
                    <asp:ListItem Value="VA">Virginia</asp:ListItem>
                    <asp:ListItem Value="WA">Washington</asp:ListItem>
                    <asp:ListItem Value="WV">West Virginia</asp:ListItem>
                    <asp:ListItem Value="WI">Wisconsin</asp:ListItem>
                    <asp:ListItem Value="WY">Wyoming</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="eProvince"
                    ErrorMessage="*Province is Required*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
                Country:
            </td>
            <td>
                <asp:DropDownList ID="eCountry" runat="server" Height="20px" Width="158px">
                    <asp:ListItem Value="">-Select Country-</asp:ListItem>
                    <asp:ListItem Value="Canada">Canada</asp:ListItem>
                    <asp:ListItem Value="United States">United States</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="eCountry"
                    ErrorMessage="*Country is Required*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
              Postal Code:
            </td>
            <td>
                <asp:TextBox ID="ePostal" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ePostal"
                    ErrorMessage="*Postal Code is Required*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
              Home/Cell #:
            </td>
            <td>
                <asp:TextBox ID="ePhone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ePhone"
                    ErrorMessage="*Phone or Cell is Required*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
              Email:
            </td>
            <td>
                <asp:TextBox ID="eEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateEmail" runat="server" ControlToValidate="eEmail"
                    ErrorMessage="*Email is Required*" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style3">
              Web Site:
            </td>
            <td>
                <asp:TextBox ID="eWeb" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style3">
                
            </td>
            <td>
              
            </td>
        </tr>
         <tr>
            <td class="style3">
                
               Waiver Agreement:</td>
            <td>
              
                <asp:TextBox ID="waiverEditBody" runat="server" Height="222px" 
                    TextMode="MultiLine" Width="672px" ReadOnly="true"></asp:TextBox>
              
            </td>
        </tr>
        <tr>
            <td class="style3">
                
                &nbsp;</td>
            <td>
              
                <br />
                <asp:CheckBox ID="checkBoxAgree" runat="server" CausesValidation="True" 
                    Text="  I accept these Terms and Conditions" ForeColor="Black" />
                <asp:Label ID="Label1" runat="server" ForeColor="Red" 
                    Text="* You did not check the agreement box."></asp:Label>
              
            </td>
        </tr>
    </table>
    </ div>


    <%-- 
    ///////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////
    --%>
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <asp:Label ID="test" runat="server" Text=""></asp:Label>
    <asp:Label ID="rePassValid" runat="server" Text=""></asp:Label>
    <asp:Label ID="maxID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="maxContactID" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="getParadeID" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="maxEntryNo" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="getUOrgName" runat="server" Visible="false"></asp:Label>
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text=" Submit " />
    <br />
    <br />
    <br />
    <br />
    </form>
</body>
</html>
