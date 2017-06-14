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
using System.IO;

public partial class adminlogin : System.Web.UI.Page
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
    static string getUStatus;
    static string getUserExpiryDate;
    static string getOrgExpirydate;
    static string getUserExpiryDateFormatted;
    static string getOrgExpirydateFormatted;


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

        //make super user always active
        try
        {
            

            MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con1.Open();
            MySqlCommand cmd1 = new MySqlCommand("UPDATE user SET uActivation = 'Active' WHERE uStatus = 'Super-Administrator'; ");
            cmd1.Connection = con1;
            MySqlDataReader reader3 = cmd1.ExecuteReader();
            con1.Close(); con1.Dispose();
        }
        catch (Exception ex)
        { 
        
        }

        //get user expiry date
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT pdValue FROM pageDateConfig WHERE paradeDateID = 1;");
            cmd.Connection = con;
            getUserExpiryDate = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");

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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception)
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
        }

        

        //get org expiry date

        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT pdValue FROM pageDateConfig WHERE paradeDateID = 2;");
            cmd.Connection = con;
            getOrgExpirydate = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");

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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception)
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
        }

        /*
          static string getUserExpiryDateFormatted;
          static string getOrgExpirydateFormatted;
         */
        //formatted uer and org date
        DateTime dtUser = Convert.ToDateTime(getUserExpiryDate);
        getUserExpiryDateFormatted = String.Format("{0}-{1}-{2}", dtUser.Year, dtUser.Month, dtUser.Day);

        DateTime dtOrg = Convert.ToDateTime(getOrgExpirydate);
        getOrgExpirydateFormatted = String.Format("{0}-{1}-{2}", dtOrg.Year, dtOrg.Month, dtOrg.Day);


        ///////////////////////get configuration from db//////////////////////////////////////////
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception)
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception)
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception)
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception)
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception)
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception)
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception)
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
        }

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

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','A Guest has entered the Admin log-in page. ');");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
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
                String fullDateUnique = years + "-" + months + "-" + days;
                String fullTimeUnique = hours + ":" + mins + ":" + secs;

                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDateUnique + "','" + fullTimeUnique + "','System','Error : " + ex + " ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception)
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
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

    protected void paradeAdminSubmit1_Click(object sender, ImageClickEventArgs e)
    {
        //checking hashed password before comparing to the database
        hash = FormsAuthentication.HashPasswordForStoringInConfigFile(paradeAdminPass.Text + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");
        //paradeAdminPass.Text = hash;

        /////////////////////login counter//////////////////////////////i
        //27CFB46EDD672489EBEC04EF408C983DA16D5C30
        
        ///////////////////////////////////////////////////////////////////////////////
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "AdminLoginProcedure";
            MySqlParameter p1 = new MySqlParameter("p_AdminUser", paradeAdminUser.Text);
            MySqlParameter p2 = new MySqlParameter("p_AdminPass", hash.ToString());
            //MySqlParameter p3 = new MySqlParameter("ofTypeAdmin", p);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            MySqlDataReader reader = cmd.ExecuteReader();

            if ((reader.HasRows) && (paradeAdminUser.Text != "") && (paradeAdminPass.Text != ""))
            {
                reader.Read();
                Session["userSession"] = paradeAdminUser.Text;
                Session["userSessionPW"] = paradeAdminPass.Text;
                Session.Timeout = 40;
                validLogin = true;

               
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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + paradeAdminUser.Text + "','Failed Log-in attempt by : " + paradeAdminUser.Text + " . ');");
                    cmd1.Connection = con1;
                    MySqlDataReader reader3 = cmd1.ExecuteReader();
                    con1.Close(); con1.Dispose();
                }
                catch (Exception ex)
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
                        MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                        cmd1.Connection = con1;
                        MySqlDataReader reader3 = cmd1.ExecuteReader();
                        con1.Close(); con1.Dispose();
                    }
                    catch (Exception)
                    {

                        Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
                    }
                }

                validLogin = false;
            }

            reader.Close();
            con.Close();  con.Dispose();
        }
        catch (Exception ex)
        {

            textLbl.Text.Equals(ex);
        }


        if (validLogin == true)
        {
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT value FROM stats WHERE statID = 1;");
                cmd.Connection = con;
                counter = ((string)cmd.ExecuteScalar());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");

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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                    cmd1.Connection = con1;
                    MySqlDataReader reader3 = cmd1.ExecuteReader();
                    con1.Close(); con1.Dispose();
                }
                catch (Exception)
                {

                    Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
                }
            }

            intCounter = Convert.ToInt16(counter);
            intCounter++;
            convCounter = Convert.ToString(intCounter);


            //update user expiry date
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE user SET uDateExpire ='" + getUserExpiryDateFormatted + "' ;");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                reader3.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");

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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                    cmd1.Connection = con1;
                    MySqlDataReader reader3 = cmd1.ExecuteReader();
                    con1.Close(); con1.Dispose();
                }
                catch (Exception)
                {

                    Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
                }
            }

            //update org expiry date
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE orginfo SET oDateExpire  ='" + getOrgExpirydateFormatted + "';");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                reader3.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");

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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                    cmd1.Connection = con1;
                    MySqlDataReader reader3 = cmd1.ExecuteReader();
                    con1.Close(); con1.Dispose();
                }
                catch (Exception)
                {

                    Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
                }
            }

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

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + paradeAdminUser.Text + "','Administrator : " + Session["userSession"].ToString() + " has logged in. ');");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                    cmd1.Connection = con1;
                    MySqlDataReader reader3 = cmd1.ExecuteReader();
                    con1.Close(); con1.Dispose();
                }
                catch (Exception)
                {

                    Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
                }

            }

			string dir = @"C:\ProgramData\1UPSolutionsParadeMS";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            //update counter
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE stats SET value='" + convCounter + "' WHERE statID = 1;");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                reader3.Close();
                Response.Redirect("adminHomeArea.aspx");
            }
            catch (Exception ex)
            {

                Response.Write("");
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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                    cmd1.Connection = con1;
                    MySqlDataReader reader3 = cmd1.ExecuteReader();
                    con1.Close(); con1.Dispose();
                }
                catch (Exception)
                {

                    Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
                }
            }

        }

        //update user expiry dates
        /*
          static string getUserExpiryDateFormatted;
          static string getOrgExpirydateFormatted;
         */

       

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
    protected void passResetOkBtn_Click(object sender, EventArgs e)
    {
        //get the random password and then hash it so it can be update in the database
      getRandomPassword =  PasswordGenerator(10, false);
      hash = FormsAuthentication.HashPasswordForStoringInConfigFile(getRandomPassword.ToString() + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");

        //Verify if the admin and email are valid
      try
      {
           
          MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
          con.Open();
          MySqlCommand cmd = new MySqlCommand();
          cmd.Connection = con;

          cmd.CommandType = CommandType.StoredProcedure;
          cmd.CommandText = "adminPasswordReset";
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
              MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDates + "','" + fullTimes + "','" + userNameTxt.Text + "','Administrator: " + userNameTxt.Text + " has reset their password.' );");
              cmd1.Connection = con1;
              MySqlDataReader reader3 = cmd1.ExecuteReader();
              con1.Close(); con1.Dispose();
          }
          catch (Exception ex)
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
                  MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                  cmd1.Connection = con1;
                  MySqlDataReader reader3 = cmd1.ExecuteReader();
                  con1.Close(); con1.Dispose();
              }
              catch (Exception)
              {

                  Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
              }

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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','System','Error : " + ex + " ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception)
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
        }


        try
        {
            MailMessage mail = new MailMessage(getFromEmail, passResetTxt.Text, "Notification: Password Reset for the bamnf Board of Trade Parade Management System", "This is your temporary password to log into the Parade Management System. You may change it once you've logged in. Your temporary " +
        "\r\n" + " Password is : " + getRandomPassword.ToString() + " ");
            SmtpClient client = new SmtpClient(getSMTPHost);
            client.Port = Int32.Parse(getHostPort);
            client.Credentials = new System.Net.NetworkCredential(getUserNameDetail, getPasswordDetail);
            client.EnableSsl = true;
            client.Send(mail);
        }
        catch (Exception)
        {

            Response.Write("No email credentials setup.");
        }


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
}