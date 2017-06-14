<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SantaParticipateReg.aspx.cs" Inherits="SantaParticipateReg" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xaspxl">
<head id="Head1" runat="server">
    <title>bamnf Santa Claus Parade Get Involved</title>
    <meta http-equiv="Content-Type" content="text/aspxl; charset=iso-8859-1">

<script language="JavaScript" type="text/JavaScript">

<!--
    function MM_reloadPage(init) {  //reloads the window if Nav4 resized
        if (init == true) with (navigator) {
            if ((appName == "Netscape") && (parseInt(appVersion) == 4)) {
                document.MM_pgW = innerWidth; document.MM_pgH = innerHeight; onresize = MM_reloadPage;
            }
        }
        else if (innerWidth != document.MM_pgW || innerHeight != document.MM_pgH) location.reload();
    }
    MM_reloadPage(true);

//-->

</script>

    <style type="text/css"> body{padding:5px; font-family:Helvetica, Arial, Sans-Serif; color:Black;} *{padding:0; margin:0;}
        .style1
        {
            width: 1052px;
        }
        .style2
        {
            width: 811px;
        }
    </style>

<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000">

<p><img src="images/mypic.png" width="532" height="285"> <a href="SantaHome.htm"><img src="images/santaface.JPG" width="248" height="290" border="0"><br>

  </a><font color="#990000" size="+3">User Sign-up</font>[#CHANGE: ParadeMS currently not checking email when registering.]</p>

 
<form id="form1" runat="server">

<div id="completedForm"  runat="server" style="position:absolute; left:10px; top:357px; width:754px; height:162px; z-index:1"> 

<p> Your form completed successfully! Check your email for more information, click <asp:Button
        ID="gotoMainPage" runat="server" Text="here" 
        onclick="gotoMainPage_Click" /> to go to the main page.</p>

</div>

<div id="FirstNameRegexDiv"  runat="server" 
    
    style="position:absolute; left:15px; top:360px; width:1041px; height:670px; z-index:1"> 
     
          <table class="style1">
          <tr>
        <td>
        <asp:Label ID="Label3" runat="server" ForeColor="White" 
                    Text="" Visible = "true"></asp:Label>
                    <br />
                    <asp:Label ID="Label4" runat="server" ForeColor="White" 
                    Text="" Visible = "true"></asp:Label>
                     <br />
                    <asp:Label ID="Label5" runat="server" ForeColor="White" 
                    Text="" Visible = "true"></asp:Label>
        </td>

        <td>
        </td>
  </tr>
           <tr>
            <td class="style6">
                <font color="#FFFFFF">Select Account Type:</font>
            </td>
            <td class="style2">
                <asp:DropDownList ID="DropDownList1" runat="server" Height="20px" Width="158px" Visible="False">
                    <asp:ListItem Value="">-Select Account Type-</asp:ListItem>
                    
                    <asp:ListItem Value="Participant">Participant</asp:ListItem>
                    <asp:ListItem Value="Volunteer">Volunteer</asp:ListItem>
                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage=""
                    ForeColor="Red" ControlToValidate="eAccountType"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
           <font color="#FFFFFF">First Name:</font>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox1" runat="server" Visible="true" Width="108px" 
                    BorderColor="White" BorderStyle="Solid"></asp:TextBox>
           <font color="#FFFFFF"></font>      <asp:RegularExpressionValidator ID="firstNameREV" runat="server" 
        ControlToValidate="eFirstName" 
        ErrorMessage="*First Name must be 3-30 characters and must be upper or lower case lettering only." 
        ForeColor="Red" ValidationExpression="([a-zA-Z]'?[A-Za-z.-]{2,30}\s*)+"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <font color="#FFFFFF">Last Name :</font>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox2" runat="server" Visible="true" width="108px" BorderColor="White" BorderStyle="Solid"></asp:TextBox>
                
            <font color="#FFFFFF"></font>      <asp:RegularExpressionValidator ID="lastNameREV" runat="server"         
        ErrorMessage="*Last Name must be 3-30 characters and must be upper or lower case lettering only." 
        ValidationExpression="[a-zA-Z]{3,30}" ControlToValidate="eLastName" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <font color="#FFFFFF">UserName:</font>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox3" runat="server" Visible="true"  width="108px" 
                    BorderColor="White" BorderStyle="Solid" ></asp:TextBox>
                
            <font color="#FFFFFF"></font>      <asp:RegularExpressionValidator ID="userNameREV" runat="server"         
        ErrorMessage="*Username must be 5-20 characters, can have underscores and periods only." 
        ValidationExpression="[A-Za-z][A-Za-z0-9._]{4,20}" 
        ControlToValidate="eUsername" ForeColor="Red" ></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                 <font color="#FFFFFF">Password:</font>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" Visible="true" width="108px" style="border:none"></asp:TextBox>
                &nbsp;<asp:RegularExpressionValidator ID="passwordREV" runat="server"         
        ErrorMessage="*Password is case sensitive and must be 6-20 characters and alphanumeric." 
        ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{6,20})$" 
        ControlToValidate="ePassword" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                <font color="#FFFFFF">Re-type Password:</font>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox5" runat="server" TextMode="Password" Visible="true" width="108px" style="border:none"> </asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Re_ePassword"
                    ErrorMessage="*You did not re-type password" ForeColor="Red"></asp:RequiredFieldValidator> 
            </td>
        </tr>
        <tr>
            <td class="style6">
                <font color="#FFFFFF">Home/Cell Number:</font>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox6" runat="server" Visible="true" Width="108px" style="border:none"></asp:TextBox>
                  <asp:RegularExpressionValidator ID="REVHomePhone" runat="server"         
        ErrorMessage="*Phone number not complete." 
        ValidationExpression="[0-9]{9,15}" ControlToValidate="eHomeNumber" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
               <font color="#FFFFFF">Business Number:</font>

            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox7" runat="server" Visible="true" Width="108px" style="border:none"></asp:TextBox>
              
            </td>
        </tr>
        <tr>
            <td class="style4">
                <font color="#FFFFFF">Email :</font>
            </td>
            <td class="style2">
                <asp:TextBox ID="TextBox8" runat="server" Visible="true" Width="108px" style="border:none"></asp:TextBox>
                <%-- <asp:RegularExpressionValidator ID="emailREV" runat="server"         
        ErrorMessage="*Email is case in-sensitive. Must be in email format ie. paradems@example.com " 
        ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" 
        ControlToValidate="eEmail" ForeColor="Red"></asp:RegularExpressionValidator> --%>  
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"         
        ErrorMessage="*Email is case in-sensitive. Must be in email format ie. paradems@example.com " 
        ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" 
        ControlToValidate="eEmail" ForeColor="Red"></asp:RegularExpressionValidator>
            </td>
        </tr>
         <tr>
            <td class="style4">
             <font color="#FFFFFF">Verify Email :</font>
            </td>
            <td class="style5">
                <asp:TextBox ID="TextBox10" runat="server" Visible="true" Width="108px" style="border:none" ></asp:TextBox>
              <%--  <asp:CompareValidator ID="validateEmailMatch" runat="server" ErrorMessage="*Email did not match"
                    ForeColor="Red" ControlToCompare="verifyEmail" ControlToValidate="eEmail"></asp:CompareValidator>  --%> 
            </td>
        </tr>
       

        <tr>
            <td class="style6">
                 <font color="#FFFFFF">Waiver Agreement:</font> </td>
            <td class="style2">
               
                <asp:TextBox ID="TextBox9" runat="server" Height="222px" 
                    TextMode="MultiLine" Width="672px" ReadOnly="true" Visible="False"></asp:TextBox>
            </td>
        </tr>
        
         <tr>
            <td >
            
              </td>
            <td class="style2"><br /><br /><br />
                <asp:CheckBox ID="checkBox1" runat="server" 
                    Text="  I accept these Terms and Conditions" CausesValidation="True" Visible="False" />
                
                
                
                <asp:Label ID="Label2" runat="server" ForeColor="Red" 
                    Text="* You did not check the agreement box." Visible="False"></asp:Label>
                
                
            </td>
        </tr>
    </table>

    </div>




<div id="regFormDiv" runat="server" style="position:absolute; left:15px; top:360px; width:1041px; height:670px; z-index:2"> 
  <table class="style1">

  <tr>
        <td>
        
            </td>

        <td>
        <asp:Label ID="UserNameExists" runat="server" ForeColor="Red" 
                    Text="" Visible = "true"></asp:Label>
                    <br />
                    <asp:Label ID="OrgExists" runat="server" ForeColor="Red" 
                    Text="" Visible = "true"></asp:Label>
                    <br />
                    <asp:Label ID="EmailExists" runat="server" ForeColor="Red" 
                    Text="" Visible = "true"></asp:Label>
        </td>
  </tr>
  <tr>
            <td class="style6">
                Select Account Type<font color="#FF0000" >*</font>:
            </td>
            <td class="style3">
                <asp:DropDownList ID="eAccountType" runat="server" Height="20px" Width="158px" 
                    AutoPostBack="True">
                    <asp:ListItem Value="">-Select Account Type-</asp:ListItem>
                    
                    <asp:ListItem Value="Participant">Participant</asp:ListItem>
                    <asp:ListItem Value="Volunteer">Volunteer</asp:ListItem>
                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RFVeAccountType" runat="server" ErrorMessage="*Status is Required*"
                    ForeColor="Red" ControlToValidate="eAccountType"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                First Name<font color="#FF0000" >*</font>:
            </td>
            <td class="style3">
                <asp:TextBox ID="eFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateFirstName" runat="server" ErrorMessage="*First Name is required"
                    ControlToValidate="eFirstName" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Last Name<font color="#FF0000" >*</font>:
            </td>
            <td class="style3">
                <asp:TextBox ID="eLastName" runat="server" onkeypress=""></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateLastName" runat="server" ErrorMessage="*Last Name is required"
                    ForeColor="Red" ControlToValidate="eLastName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                UserName<font color="#FF0000" >*</font>:<font color="#FFFFFF">.</font>
            </td>
            <td class="style3">
                <asp:TextBox ID="eUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateUserName" runat="server" ErrorMessage="*Username is required"
                    ForeColor="Red" ControlToValidate="eUsername"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Password<font color="#FF0000" >*</font>:
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
                Re-type Password<font color="#FF0000" >*</font>:
            </td>
            <td class="style3">
                <asp:TextBox ID="Re_ePassword" runat="server" TextMode="Password"></asp:TextBox>
              <asp:CompareValidator ID="validatePasswordMatch" runat="server" ErrorMessage="*Password did not match"
                    ForeColor="Red" ControlToCompare="ePassword" ControlToValidate="Re_ePassword"></asp:CompareValidator> 
                    <font color="#FFFFFF">.</font>   
            </td>
        </tr>
        <tr>
            <td class="style6">
                Home/Cell Number<font color="#FF0000" >*</font>:
            </td>
            <td class="style3">
                <asp:TextBox ID="eHomeNumber" runat="server"></asp:TextBox>
                 <asp:MaskedEditExtender runat="server"  ID="maskedEditorHomePhone" Mask="(999) 999-9999"
        TargetControlID="eHomeNumber"></asp:MaskedEditExtender> 

                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Home number is Required*"
                    ForeColor="Red" ControlToValidate="eHomeNumber"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="style6">
                Business Number:
            </td>
            <td class="style3">
                <asp:TextBox ID="eBusinessNumber" runat="server"></asp:TextBox>
                <asp:MaskedEditExtender runat="server"  ID="MaskedEditExtender1" Mask="(999) 999-9999"
        TargetControlID="eBusinessNumber"></asp:MaskedEditExtender> 
            </td>
        </tr>
        <tr>
            <td class="style4">
                Email<font color="#FF0000" >*</font>:
            </td>
            <td class="style5">
                <asp:TextBox ID="eEmail" runat="server"></asp:TextBox>

                <asp:RequiredFieldValidator ID="validateEmail" runat="server" ErrorMessage="*Email is Required"
                    ForeColor="Red" ControlToValidate="eEmail"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="emailREV" runat="server"         
        ErrorMessage="*________________________________________________________________ " 
        ValidationExpression="^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$" 
        ControlToValidate="eEmail" ForeColor="white"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="style4">
               Verify Email<font color="#FF0000" >*</font>:
            </td>
            <td class="style5">
                <asp:TextBox ID="verifyEmail" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CVEmail" runat="server" ErrorMessage="*Email did not match"
                    ForeColor="Red" ControlToCompare="eEmail" ControlToValidate="verifyEmail"></asp:CompareValidator>
                   
            </td>
        </tr>
        <tr>
                    <td class="style4">
                        Street<font color="#FF0000" >*</font>:
                    </td>
                    <td>
                        <asp:TextBox ID="eeStreet" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Street name is required"
                    ForeColor="Red" ControlToValidate="eeStreet"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        City<font color="#FF0000" >*</font>:
                    </td>
                    <td>
                        
                        <asp:TextBox ID="eeCity" runat="server"></asp:TextBox>
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*City name is required"
                    ForeColor="Red" ControlToValidate="eeCity"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        Province<font color="#FF0000" >*</font>:
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
                        Postal Code<font color="#FF0000" >*</font>:
                    </td>
                    <td>
                        <asp:TextBox ID="eePost" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Postal Code name is required"
                    ForeColor="Red" ControlToValidate="eePost"></asp:RequiredFieldValidator>
                    </td>
                </tr>
        
        <tr>
                    <td class="style4">
                        <asp:Label ID="OrgLabel" runat="server" Text="Organization Name:  " Visible="false"></asp:Label><asp:Label
                            ID="asterisk" runat="server" Text="*" ForeColor="Red" Visible = "false"></asp:Label> 
                    </td>
                    <td>
                        <asp:TextBox ID="OrgName" runat="server" Visible="false" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVORganizaitonName" runat="server" ErrorMessage="*Organization name is required if you are a Participant"
                    ForeColor="Red" ControlToValidate="OrgName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
        <tr>
            <td class="style6">
                
                <asp:Label ID="waiverLbl" runat="server" Text="Waiver Agreement:  " Visible="false"></asp:Label>
                </td>
            <td class="style3">
               
                <asp:TextBox ID="waiverEditBody" runat="server" Height="222px" 
                    TextMode="MultiLine" Width="672px" ReadOnly="true"></asp:TextBox>
            </td>
        </tr>
        
         <tr>
            <td >
            
              </td>
            <td class="style3"><br /><br /><br />
                <asp:CheckBox ID="checkBoxAgree" runat="server" 
                    Text="  I accept these Terms and Conditions" CausesValidation="True" 
                    oncheckedchanged="checkBoxAgree_CheckedChanged" />
                
                
                
                <asp:Label ID="Label1" runat="server" ForeColor="Red" 
                    Text="* You did not check the agreement box." ></asp:Label>
                
                
            </td>
        </tr>
        <tr>
        <td>
        <font color="#FF0000">Mandatory*</font>
        </td>
        </tr>
    </table>
    

      <p>
      
       
                    <br />
                    
      <br />
      <asp:Label ID="rePassValid" runat="server" ForeColor="Red" 
                    Text="" Visible = "true"></asp:Label>
      <br>
      <asp:Label ID="test" runat="server" ForeColor="Red" 
                    Text="* You did not check the agreement box." Visible = "false"></asp:Label>
    <br>

    &nbsp;</p>

  <!-- <p><a href="SantaInvolved.htm"><img src="images/Back.png" width="61" height="43" border="0"></a> -->

   <!--   --><asp:HyperLink
        ID="HyperLink1" href="SantaInvolved.aspx" runat="server">
        <img src="images/Back.png" width="84" height="43"></asp:HyperLink>
         <font color="#FFFFFF"> ......................................</font><asp:ImageButton 
      ID="continue" runat="server" ImageUrl="images/Continue.png" onclick="continue_Click" 
        />
   <p>
  </div>
  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="Server" />

   </form >
</div>
<br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><marquee><h1><asp:Label ID="scrollText" runat="server" Text="bamnf Santa Claus Parade"></asp:Label></h1></marquee>

<p>&nbsp;</p>

<p>&nbsp;</p>

<p>&nbsp;</p>

</body>


</html>
