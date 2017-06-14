<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userHomeLogin.aspx.cs" Inherits="userHomeLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server"><link rel="shortcut icon" href="images/santaIcon.ico" />
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

        
</head>
<body link="#006600" vlink="#990000" bgcolor="#ffffFF">
    <form id="form1" runat="server" enctype="MULTIPART/FORM-DATA">
    <font color="#990000" size="+3">User <asp:Label ID="volOrPart" runat="server" Text=""></asp:Label> Area: Home</font></p>
    <div id="Layer1" style="position: absolute; left: 62px; top: 64px; width: 475px;
        height: 111px; z-index: 4">
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
    <br />
    <div style="position: absolute; left: 357px; top: 150px; z-index: 3; height: 38px;
        width: 640px;">
        <h2>
            &nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Today's date is"></asp:Label>
            &nbsp;<asp:Label ID="day" runat="server" Text="Label"></asp:Label>
            &nbsp;<asp:Label ID="month" runat="server" Text="Label"></asp:Label>&nbsp;<asp:Label
                ID="monthInt" runat="server" Text="Label"></asp:Label>, &nbsp;&nbsp;<asp:Label ID="year"
                    runat="server" Text="Label"></asp:Label></h2>
        <p>
            &nbsp;</p>
       
        <p>
            About:</p>
    </div>
     <div style="position: absolute; left: 1153px; top: 146px; z-index: 3; height: 63px;
        width: 120px;">
    
        <%-- This tutorial is sponsored by http://www.ServerIntellect.com web hosting. 
	     Check out http://v4.aspnettutorials.com/ for more great tutorials! --%>

        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>

        

    </div>

    <div style="position: absolute; left: 1120px; top: 257px; z-index: 3; height: 228px;
        width: 287px;" align="center">
    

       <b> <u><asp:Label ID="downloadsLbl" runat="server" Text="Downloads :"></asp:Label></u>  </b><br /><br />

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            CellPadding="4" DataKeyNames="dFileDate" DataSourceID="SqlDataSource1" 
            ForeColor="#333333" onrowcommand="GridView1_RowCommand" AllowPaging="True" 
            AllowSorting="True" PageSize="6">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
           
                <asp:BoundField DataField="dFileName" HeaderText="Doc Name" 
                    SortExpression="dFileName" />
                <asp:BoundField DataField="dDescription" HeaderText="Description" 
                    SortExpression="dDescription" />
                <asp:BoundField DataField="dFileDate" HeaderText="Date" DataFormatString="{0:d}"
                    SortExpression="dFileDate" />
                    <asp:ButtonField ButtonType="Image" ImageUrl="images/Load.png" CommandName="Download"
                HeaderText="Download&nbsp;&nbsp;" Text="Download" />
                
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:pmsConnectionString %>" 
            ProviderName="<%$ ConnectionStrings:pmsConnectionString.ProviderName %>" 
            SelectCommand="SELECT dfilename, ddescription, dfiledate FROM download ORDER BY dfiledate DESC"></asp:SqlDataSource>
    

        

    </div>
    <p>
        &nbsp;</p>
    
        
        
       
        
       
    <div   style=" position: absolute; top: 415px; left: 8px; height: 28px; width: 229px;  z-index: 7;">
  
        &nbsp;&nbsp;&nbsp;&nbsp;
             
        <asp:Label ID="Error" runat="server" Text="" ForeColor="Red"></asp:Label>
             
    </div>

    <div   style=" position: absolute; top: 790px; left: 10px; height: 38px; width: 229px;  z-index: 7;">
  
        &nbsp;&nbsp;&nbsp;&nbsp;
             
        <asp:Label ID="error2" runat="server" Text="" ForeColor="Red"></asp:Label>
             
    </div>

     <div style="border: 5px solid #FFFFFF; position: absolute; left: 5px; top: 237px; z-index: 0; height: 200px;
        width: 214px; background-color: white;" id="checkFloatDiv" runat="server" 
        visible="False">
         <b>&nbsp; &nbsp; &nbsp;  Create an Organization</b><br />
        <br />
        
       &nbsp; &nbsp; &nbsp;  Click here to create an organization once your account is activated:<br /><br />
        
        
      
      

         <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" Enabled="true" 
             oncheckedchanged="CheckBox1_CheckedChanged" 
             Text="" 
             Font-Size="Small" />
                  <asp:Button ID="createOrg" runat="server" Text="Create!" Height="31px" 
            Width="124px" onclick="createOrg_Click1"/>
    </div>

     <div style="border: 5px solid #FFFFFF; position: absolute; left: 7px; top: 536px; z-index: 4; height: 200px;
        width: 254px; background-color: white;" id="Div1" runat="server" 
        visible="true">
         <b>&nbsp; &nbsp; &nbsp;  Upload a File/Document about your float<i>(file must not 
         exceed 10MB)</i></b><br />
        <br />
        
       &nbsp; &nbsp; &nbsp;  Click here and upload a file once your organization is created, so your float can be properly evaluated:<br /><br />
        
        
      
      

         <asp:CheckBox ID="actiavteUpload" runat="server" AutoPostBack="True" Enabled="true" 
             
             Text=" " 
             Font-Size="Small" oncheckedchanged="actiavteUpload_CheckedChanged" />
         <asp:FileUpload ID="uploadControl" runat="server" 
             Width="218px" Enabled=false />
                  <asp:Button ID="uploadFileBtn" runat="server" Text="Upload!" Height="31px" 
            Width="124px"  Enabled=false onclick="uploadFileBtn_Click"/>
    </div>
    
     <div   style=" position: absolute; top: 261px; left: 359px; height: 288px; width: 673px;  z-index: 7;">
  
       <p>
       
        <asp:Label ID="userDesc" runat="server" Text="" ></asp:Label> <br /><br /><br /><br />
              <div   >
  </p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:Image ID="Image1" runat="server" ImageUrl="~/images/userImage.png" 
                      ImageAlign="Middle" />
        
             
    </div>
         

         <!-- snow flake logic -->
       <div   style=" position: absolute; top: 403px; left: 541px; height: 35px; width: 55px;  z-index: 8;"> 
    <asp:TextBox ID="TextBox1" runat="server" Height="0px" Width="0px" ></asp:TextBox>
    </div>

    <SCRIPT type="text/javascript">
        /*
        Snow Fall 1 - no images - Java Script
        Visit http://rainbow.arch.scriptmania.com/scripts/
        for this script and many more
        */

        // Set the number of snowflakes (more than 30 - 40 not recommend
        var snowmax = 35

        // Set the colors for the snow. Add as many colors as you like
        var snowcolor = new Array("#aaaacc", "#ddddff", "#ccccdd", "#f3f3f3", "#f0ffff")

        // Set the fonts, that create the snowflakes. Add as many fonts as you like
        var snowtype = new Array("Times", "Arial", "Times", "Verdana")

        // Set the letter that creates your snowflake (recommended: * )
        var txt = document.getElementById("<%=TextBox1.ClientID %>");
        var snowletter = txt.value

        // Set the speed of sinking (recommended values range from 0.3 to 2)
        var sinkspeed = 0.6

        // Set the maximum-size of your snowflakes
        var snowmaxsize = 30

        // Set the minimal-size of your snowflakes
        var snowminsize = 8

        // Set the snowing-zone
        // Set 1 for all-over-snowing, set 2 for left-side-snowing
        // Set 3 for center-snowing, set 4 for right-side-snowing
        var snowingzone = 1

        ///////////////////////////////////////////////////////////////////////////
        // CONFIGURATION ENDS HERE
        ///////////////////////////////////////////////////////////////////////////


        // Do not edit below this line
        var snow = new Array()
        var marginbottom
        var marginright
        var timer
        var i_snow = 0
        var x_mv = new Array();
        var crds = new Array();
        var lftrght = new Array();
        var browserinfos = navigator.userAgent
        var ie5 = document.all && document.getElementById && !browserinfos.match(/Opera/)
        var ns6 = document.getElementById && !document.all
        var opera = browserinfos.match(/Opera/)
        var browserok = ie5 || ns6 || opera

        function randommaker(range) {
            rand = Math.floor(range * Math.random())
            return rand
        }

        function initsnow() {
            if (ie5 || opera) {
                marginbottom = document.body.scrollHeight
                marginright = document.body.clientWidth - 15
            }
            else if (ns6) {
                marginbottom = document.body.scrollHeight
                marginright = window.innerWidth - 15
            }
            var snowsizerange = snowmaxsize - snowminsize
            for (i = 0; i <= snowmax; i++) {
                crds[i] = 0;
                lftrght[i] = Math.random() * 15;
                x_mv[i] = 0.03 + Math.random() / 10;
                snow[i] = document.getElementById("s" + i)
                snow[i].style.fontFamily = snowtype[randommaker(snowtype.length)]
                snow[i].size = randommaker(snowsizerange) + snowminsize
                snow[i].style.fontSize = snow[i].size + 'px';
                snow[i].style.color = snowcolor[randommaker(snowcolor.length)]
                snow[i].style.zIndex = 1000
                snow[i].sink = sinkspeed * snow[i].size / 5
                if (snowingzone == 1) { snow[i].posx = randommaker(marginright - snow[i].size) }
                if (snowingzone == 2) { snow[i].posx = randommaker(marginright / 2 - snow[i].size) }
                if (snowingzone == 3) { snow[i].posx = randommaker(marginright / 2 - snow[i].size) + marginright / 4 }
                if (snowingzone == 4) { snow[i].posx = randommaker(marginright / 2 - snow[i].size) + marginright / 2 }
                snow[i].posy = randommaker(2 * marginbottom - marginbottom - 2 * snow[i].size)
                snow[i].style.left = snow[i].posx + 'px';
                snow[i].style.top = snow[i].posy + 'px';
            }
            movesnow()
        }

        function movesnow() {
            for (i = 0; i <= snowmax; i++) {
                crds[i] += x_mv[i];
                snow[i].posy += snow[i].sink
                snow[i].style.left = snow[i].posx + lftrght[i] * Math.sin(crds[i]) + 'px';
                snow[i].style.top = snow[i].posy + 'px';

                if (snow[i].posy >= marginbottom - 2 * snow[i].size || parseInt(snow[i].style.left) > (marginright - 3 * lftrght[i])) {
                    if (snowingzone == 1) { snow[i].posx = randommaker(marginright - snow[i].size) }
                    if (snowingzone == 2) { snow[i].posx = randommaker(marginright / 2 - snow[i].size) }
                    if (snowingzone == 3) { snow[i].posx = randommaker(marginright / 2 - snow[i].size) + marginright / 4 }
                    if (snowingzone == 4) { snow[i].posx = randommaker(marginright / 2 - snow[i].size) + marginright / 2 }
                    snow[i].posy = 0
                }
            }
            var timer = setTimeout("movesnow()", 50)
        }

        for (i = 0; i <= snowmax; i++) {
            document.write("<span id='s" + i + "' style='position:absolute;top:-" + snowmaxsize + "'>" + snowletter + "</span>")
        }
        if (browserok) {
            window.onload = initsnow
        }

    </SCRIPT>

    </form>
</body>
</html>

