<%@ Page Language="C#" AutoEventWireup="true" CodeFile="validateAccount.aspx.cs" Inherits="validateAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1"  runat="server"><link rel="shortcut icon" href="images/santaIcon.ico" /><link rel="shortcut icon" href="images/santaIcon.ico" />
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

        <script type="text/javascript">
          
            // create as many regular expressions here as you need:
            var digitsOnly = /[1234567890]/g;
            var integerOnly = /[0-9\.]/g;
            var alphaOnly = /[A-Za-z0-9\.]/g;

            function restrictCharacters(myfield, e, restrictionType) {
                if (!e) var e = window.event
                if (e.keyCode) code = e.keyCode;
                else if (e.which) code = e.which;
                var character = String.fromCharCode(code);

                // if they pressed esc... remove focus from field...
                if (code == 27) { this.blur(); return false; }

                // ignore if they are press other keys
                // strange because code: 39 is the down key AND ' key...
                // and DEL also equals .
                if (!e.ctrlKey && code != 9 && code != 8 && code != 36 && code != 37 && code != 38 && (code != 39 || (code == 39 && character == "'")) && code != 40) {
                    if (character.match(restrictionType)) {
                        return true;
                    } else {
                        return false;
                    }

                }
            }
</script>

<link rel="shortcut icon" href="images/santaIcon.ico" /></head>
<body link="#006600" vlink="#990000" bgcolor="#ffff99">
<form id="form1" runat="server">

 
<font color="#990000" size="+3">User Area: Account Validation</font></p>
    <br /><br /><br />
    <br />
    <br />
    <br /><h2>Congratulations! This is your first time logging in! Please fill out the validation code 
    to verify your account :)</h2><br />
    <br /> &nbsp;<asp:Panel ID="Panel1" runat="server" Height="163px">

        &nbsp;&nbsp;Please enter&nbsp; the code you were given in your email:
        
        <asp:Label ID="error" runat="server" Text="" ></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="codeTxt" onkeypress="return restrictCharacters(this, event, alphaOnly);" runat="server" ></asp:TextBox>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Button ID="Submit" runat="server" Text="Submit" 
            onclick="Submit_Click" />
            &nbsp;&nbsp;
            <asp:Button ID="Cancel" runat="server" Text="Get me out of here!" onclick="Cancel_Click" 
             />
             
        
    </asp:Panel>
    <div style="position: absolute; left: 465px; top: 447px; z-index: 3; height: 63px;
        width: 566px;">
    
        

       <h1> <asp:Label ID="redirectingLabel" runat="server" Text="Redirecting...Please Wait..." Visible="false"></asp:Label> <h1> 
    
        

    </div>
   
        </form >
</body>
</html>
