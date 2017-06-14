using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.Security;
using System.Net.Mail;



public partial class userLogin : System.Web.UI.Page
{
    static string counter;
    static int intCounter;
    static string convCounter;
    static string getScrollTextCode;
    static string getScrollText;
    static string hash;
    static bool validLogin = false;
    static bool valideEmailAndUName = false;
    static string getRandomPassword;
    static string getUserType;
    static string checkValidation;

    //get email data from database
    static string getFromEmail;
    static string getSMTPHost;
    static string getUserNameDetail;
    static string getPasswordDetail;
    static string getHostPort;
   

    private static readonly Random Random = new Random();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Password reset buttons that go invisable at page load
        passResetLbl.Visible = false;
        passResetTxt.Visible = false;
        passResetOkBtn.Visible = false;
        passResetCancelBtn.Visible = false;
        userNameLbl.Visible = false;
        userNameTxt.Visible = false;

        //for activity log
        try
        {
            //get date and time
            String years = DateTime.Now.Year.ToString();
            String months = DateTime.Now.Month.ToString();
            String days = DateTime.Now.Day.ToString();
            String hours = DateTime.Now.Hour.ToString();
            String mins = DateTime.Now.Minute.ToString();
            String secs = DateTime.Now.Second.ToString();
            String fullDate = years + "-" + months + "-" + days;
            String fullTime = hours + ":" + mins + ":" + secs;

            MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con1.Open();
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','A Guest has visited the user log-in page.' );");
            cmd1.Connection = con1;
            MySqlDataReader reader3 = cmd1.ExecuteReader();
            con1.Close(); con1.Dispose();
        }
        catch (Exception ex)
        {


        }

        ///////////////////////get from db//////////////////////////////////////////
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT other FROM pageconfig WHERE configID = 11;");
            cmd.Connection = con;
            getScrollTextCode = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 11;");
            cmd.Connection = con;
            getScrollText = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        scrollText.Text = getScrollText;

        ////////////////////////////////// get email data from the database ////////////////////////////////////

        //get the admin from address
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT fromaddress FROM email WHERE emailID = 1;");
            cmd.Connection = con;
            getFromEmail = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }

        //get simple mail transfer protocol host
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT smtphost FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            getSMTPHost = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }
        //get email username
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT useremail FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            getUserNameDetail = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }
        //get email password
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT userpass FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            getPasswordDetail = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }
        //get email port

        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT port FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            getHostPort = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }



        /////////////////////if there is scroll text, change size and color///////////////////////
        if (getScrollTextCode == "BigRed")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Red;
        }
        if (getScrollTextCode == "BigBlue")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Blue;
        }
        if (getScrollTextCode == "BigBlack")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Black;
        }
        if (getScrollTextCode == "BigWhite")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.White;
        }
        if (getScrollTextCode == "BigPurple")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Purple;
        }
        if (getScrollTextCode == "BigYellow")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Yellow;
        }
        if (getScrollTextCode == "BigGreen")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Green;
        }
        if (getScrollTextCode == "BigOrange")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Orange;
        }
        if (getScrollTextCode == "MediumRed")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Red;
        }
        if (getScrollTextCode == "MediumBlue")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Blue;
        }
        if (getScrollTextCode == "MediumBlack")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Black;
        }
        if (getScrollTextCode == "MediumWhite")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.White;
        }
        if (getScrollTextCode == "MediumPurple")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Purple;
        }
        if (getScrollTextCode == "MediumYellow")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Yellow;
        }
        if (getScrollTextCode == "MediumGreen")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Green;
        }
        if (getScrollTextCode == "MediumOrange")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Orange;
        }
        if (getScrollTextCode == "SmallRed")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Red;
        }
        if (getScrollTextCode == "SmallBlue")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Blue;
        }
        if (getScrollTextCode == "SmallBlack")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Black;
        }
        if (getScrollTextCode == "SmallWhite")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.White;
        }
        if (getScrollTextCode == "SmallPurple")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Purple;
        }
        if (getScrollTextCode == "SmallYellow")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Yellow;
        }
        if (getScrollTextCode == "SmallGreen")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Green;
        }
        if (getScrollTextCode == "SmallOrange")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Orange;
        }
       
        

    }
    protected void passResetOkBtn_Click(object sender, EventArgs e)
    {
        //get the random password and then hash it so it can be update in the database
        getRandomPassword = PasswordGenerator(10, false);
        hash = FormsAuthentication.HashPasswordForStoringInConfigFile(getRandomPassword.ToString() + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");

        //Verify if the admin and email are valid
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "userPasswordReset";
            MySqlParameter p1 = new MySqlParameter("username", userNameTxt.Text);
            MySqlParameter p2 = new MySqlParameter("email", passResetTxt.Text);
            //MySqlParameter p3 = new MySqlParameter("ofTypeAdmin", p);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows && userNameTxt.Text != null && passResetTxt.Text != null)
            {
                textLbl2.Text = "Please check your email. A temporary password has been sent.";
                valideEmailAndUName = true;

            }
            else
            {
                textLbl2.Text = "Credentials are not correct or there was a  spelling mistake. Please try again. ";
                //contrals that go invisable
                loginLbl.Visible = true;
                paradeAdminUser.Visible = true;
                passLbl.Visible = true;
                paradeAdminPass.Visible = true;
                paradeAdminSubmit1.Visible = true;
                passwordLbl.Visible = true;
                passwordBtn.Visible = true;

                //controls that become visable
                passResetLbl.Visible = false;
                passResetTxt.Visible = false;
                passResetTxt.Text = "";
                passResetOkBtn.Visible = false;
                passResetCancelBtn.Visible = false;
                userNameLbl.Visible = false;
                userNameTxt.Visible = false;
                valideEmailAndUName = false;
            }
            reader.Close();
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            textLbl.Text.Equals(ex);
        }
        //username and email are verified
        if (valideEmailAndUName == true)
        {
            //for activity log
            try
            {
                //get date and time
                String years = DateTime.Now.Year.ToString();
                String months = DateTime.Now.Month.ToString();
                String days = DateTime.Now.Day.ToString();
                String hours = DateTime.Now.Hour.ToString();
                String mins = DateTime.Now.Minute.ToString();
                String secs = DateTime.Now.Second.ToString();
                String fullDates = years + "-" + months + "-" + days;
                String fullTimes = hours + ":" + mins + ":" + secs;

                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDates + "','" + fullTimes + "','" + userNameTxt.Text + "','User: " + userNameTxt.Text + " has reset their password.' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {


            }

            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE user SET uPassword='" + hash.ToString() + "' WHERE uUsername = '" + userNameTxt.Text + "' AND uEmail = '" + passResetTxt.Text + "';");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }


            MailMessage mail = new MailMessage(getFromEmail, passResetTxt.Text, "Notification: Password Reset for the bamnf Board of Trade Parade Management System", "This is your temporary password to log into the Parade Management System. You may change it once you've logged in. Your temporary " +
       "\r\n" + " Password is : " + getRandomPassword.ToString() + " ");
            SmtpClient client = new SmtpClient(getSMTPHost);
            client.Port = Int32.Parse(getHostPort);
            client.Credentials = new System.Net.NetworkCredential(getUserNameDetail, getPasswordDetail);
            client.EnableSsl = true;
            client.Send(mail);

            //contrals that go invisable
            loginLbl.Visible = true;
            paradeAdminUser.Visible = true;
            passLbl.Visible = true;
            paradeAdminPass.Visible = true;
            paradeAdminSubmit1.Visible = true;
            passwordLbl.Visible = true;
            passwordBtn.Visible = true;

            //controls that become visable
            passResetLbl.Visible = false;
            passResetTxt.Visible = false;
            passResetOkBtn.Visible = false;
            passResetCancelBtn.Visible = false;
            userNameLbl.Visible = false;
            userNameTxt.Visible = false;
            passResetTxt.Text = "";
        }
       

    }
    protected void passResetCancelBtn_Click(object sender, EventArgs e)
    {
        //contrals that go invisable
        loginLbl.Visible = true;
        paradeAdminUser.Visible = true;
        passLbl.Visible = true;
        paradeAdminPass.Visible = true;
        paradeAdminSubmit1.Visible = true;
        passwordLbl.Visible = true;
        passwordBtn.Visible = true;

        //controls that become visable
        passResetLbl.Visible = false;
        passResetTxt.Visible = false;
        passResetTxt.Text = "";
        passResetOkBtn.Visible = false;
        passResetCancelBtn.Visible = false;
        userNameLbl.Visible = false;
        userNameTxt.Visible = false;
    }
    protected void passwordBtn_Click(object sender, EventArgs e)
    {
        //contrals that go invisable
        loginLbl.Visible = false;
        paradeAdminUser.Visible = false;
        passLbl.Visible = false;
        paradeAdminPass.Visible = false;
        paradeAdminSubmit1.Visible = false;
        passwordLbl.Visible = false;
        passwordBtn.Visible = false;

        //controls that become visable
        passResetLbl.Visible = true;
        passResetTxt.Visible = true;
        passResetOkBtn.Visible = true;
        passResetCancelBtn.Visible = true;
        userNameLbl.Visible = true;
        userNameTxt.Visible = true;

        //Make sure everything is blank
        textLbl.Text = "";
        textLbl2.Text = "";
    }
    protected void paradeAdminSubmit1_Click(object sender, ImageClickEventArgs e)
    {
        //checking hashed password before comparing to the database
        hash = FormsAuthentication.HashPasswordForStoringInConfigFile(paradeAdminPass.Text + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");
        //paradeAdminPass.Text = hash;

        
        ///////////////////////////////////////////////////////////////////////////////
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UserLoginProcedure";
            MySqlParameter p1 = new MySqlParameter("p_User", paradeAdminUser.Text);
            MySqlParameter p2 = new MySqlParameter("p_Pass", hash.ToString());
            //MySqlParameter p3 = new MySqlParameter("ofTypeAdmin", p);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows && paradeAdminUser.Text != null && paradeAdminPass != null)
            {
                reader.Read();
                Session["userSessionU"] = paradeAdminUser.Text;
                Session["userSessionPWU"] = paradeAdminPass.Text;
                Session.Timeout = 40;
                validLogin = true;

                /////////////////////get the user type//////////////////////////////i
                try
                {
                     
                    MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con1.Open();
                    MySqlCommand cmd1 = new MySqlCommand("SELECT uStatus FROM user WHERE uUsername = '" + paradeAdminUser.Text + "' AND uPassword = '" + hash.ToString() + "';");
                    cmd1.Connection = con1;
                    getUserType = ((string)cmd1.ExecuteScalar());
                    con1.Close(); con1.Dispose();
                }
                catch (Exception ex)
                {

                    Response.Write("");
                }
                Session["getUserType"] = getUserType;
                            
                   /////////check if they validated their email////////////
                       
                            try
                            {

                                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                                con1.Open();
                                MySqlCommand cmd1 = new MySqlCommand("SELECT uEmailValidator FROM user WHERE uUsername = '" + paradeAdminUser.Text + "' AND uPassword = '" + hash.ToString() + "';");
                                cmd1.Connection = con1;
                                checkValidation = ((string)cmd1.ExecuteScalar());
                                con1.Close(); con1.Dispose();
                            }
                            catch (Exception ex)
                            {

                                Response.Write("");
                            }
                                

                            //checkes the validation and redirects accordingly
                            if (checkValidation == "notValid")
                            {
                                Response.Redirect("validateAccount.aspx");
                            }
                            else
                            {

                                //for activity log
                                try
                                {
                                    //get date and time
                                    String years = DateTime.Now.Year.ToString();
                                    String months = DateTime.Now.Month.ToString();
                                    String days = DateTime.Now.Day.ToString();
                                    String hours = DateTime.Now.Hour.ToString();
                                    String mins = DateTime.Now.Minute.ToString();
                                    String secs = DateTime.Now.Second.ToString();
                                    String fullDate = years + "-" + months + "-" + days;
                                    String fullTime = hours + ":" + mins + ":" + secs;

                                    MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                                    con1.Open();
                                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + paradeAdminUser.Text + "','User: " + paradeAdminUser.Text + " has logged in. ' );");
                                    cmd1.Connection = con1;
                                    MySqlDataReader reader3 = cmd1.ExecuteReader();
                                    con1.Close(); con1.Dispose();
                                }
                                catch (Exception ex)
                                {


                                }

                                Response.Redirect("userHomeLogin.aspx");
                            }

                

            }
            else
            {
                textLbl2.Text = "Credentials are not Correct! or  You do not have permission to access this area.";

                //for activity log
                try
                {
                    //get date and time
                    String years = DateTime.Now.Year.ToString();
                    String months = DateTime.Now.Month.ToString();
                    String days = DateTime.Now.Day.ToString();
                    String hours = DateTime.Now.Hour.ToString();
                    String mins = DateTime.Now.Minute.ToString();
                    String secs = DateTime.Now.Second.ToString();
                    String fullDate = years + "-" + months + "-" + days;
                    String fullTime = hours + ":" + mins + ":" + secs;

                    MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con1.Open();
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Failed Log-in attempt by: " + paradeAdminUser.Text + ". ' );");
                    cmd1.Connection = con1;
                    MySqlDataReader reader3 = cmd1.ExecuteReader();
                    con1.Close(); con1.Dispose();
                }
                catch (Exception ex)
                {


                }

                validLogin = false;
            }
            reader.Close();
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            textLbl.Text.Equals(ex);
        }

       

        //for testing purposes
        //Response.Write(Session["getUserType"].ToString());

       


        //if (validLogin == true)
        //{
        //    try
        //    {
        //         
        //        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
        //        con.Open();
        //        MySqlCommand cmd = new MySqlCommand("SELECT value FROM stats WHERE statID = 1;");
        //        cmd.Connection = con;
        //        counter = ((string)cmd.ExecuteScalar());
        //        con.Close(); con.Dispose();
        //    }
        //    catch (Exception ex)
        //    {

        //        Response.Write("");
        //    }

          
        //    //counter - only really needed for admin
        //    //intCounter = Convert.ToInt16(counter);
        //    //intCounter++;
        //    //convCounter = Convert.ToString(intCounter);

        //    //try
        //    //{
        //    //     
        //    //    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
        //    //    con.Open();
        //    //    MySqlCommand cmd = new MySqlCommand("UPDATE stats SET value='" + convCounter + "' WHERE statID = 1;");
        //    //    cmd.Connection = con;
        //    //    MySqlDataReader reader3 = cmd.ExecuteReader();
        //    //    reader3.Close();
        //    //   
        //    //}
        //    //catch (Exception ex)
        //    //{

        //    //    Response.Write("");
        //    //}

        //}
    }

    private static string PasswordGenerator(int passwordLength, bool strongPassword)
    {
        int seed = Random.Next(1, int.MaxValue);
        //const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
        const string specialCharacters = @"!#$%&'()*+,-./:;<=>?@[\]_";

        var chars = new char[passwordLength];
        var rd = new Random(seed);

        for (var i = 0; i < passwordLength; i++)
        {
            // If we are to use special characters
            if (strongPassword && i % Random.Next(3, passwordLength) == 0)
            {
                chars[i] = specialCharacters[rd.Next(0, specialCharacters.Length)];
            }
            else
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }
        }

        return new string(chars);
    }
    protected void registerBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("SantaParticipateReg.aspx");
    }
}