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
using System.Net.Mail;


public partial class editFloatDetailsaspx : System.Web.UI.Page
{

   
    static bool update = false;
    static string authNum;
    static string confirmType;
    static string getConfirmCmd;
    static string getParadeName;
    static string getSelect;
    static string getParadeID;
    static string getFloatID;
    static string getOrgID;
    static int entryString2Int;
    static string scriptLockString;

	//verify that the org is active before activating the float
	static string verifyActiveOrg;
    static string getActiveOrgID;
	static string verifyActiveUser;
    //proper credentials
    static string userID;
    static string getUFName;
    static string getULName;
    static string getEmail;
    static string globalScriptLock;

    //email config variables
    static string fromAddress;
    static string smtpHost;
    static string emailUsername;
    static string emailPassword;
    static string port;

    //Email Variales
    static string floatActiveSubject;
    static string floatInActivesSubject;
    static string floatActiveBody;
    static string floatInActiveBody;
    static string floatActiveFooter;
    static string floatInActiveFooter;
    static string nbsp = "&nbsp;";
    static string singleQuote = "&#39;";

    static string uploadPath = "C://ProgramData//1UPSolutionsParadeMS//";
    static string uploadVirtualPath = "1UPSolutionsParadeMS\\";

    protected void Page_Load(object sender, EventArgs e)
    {
        //login session
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSession"].ToString();
        }

        

        //--------get the parade name from page config-----------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 10;");
            cmd.Connection = con;
            getParadeName = (cmd.ExecuteScalar().ToString());
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
            catch (Exception )
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
        }

        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 25;");
            cmd.Connection = con;
            globalScriptLock = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();

            lockAllScriptBtn.Text = globalScriptLock;
        }
        catch (Exception ex)
        {
            Response.Write("Unable to perform global lock");
        }


        //------ gets the select state either global or selective----------------------

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 15;");
            cmd.Connection = con;
            getSelect = (cmd.ExecuteScalar().ToString());
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
        //--------get the parade ID fromget ParadeName from the config page -----------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT paradeID FROM parade WHERE paradeName = '" + getParadeName + "';");
            cmd.Connection = con;
            getParadeID = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {
            if (getParadeID == null)
            {
                Response.Write("");
            }
            else
            {
                Response.Write("There are no floats.");
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

        //get the current max entry number so far
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT MAX(entryNo) FROM floatdetails WHERE paradeID= '" + getParadeID.ToString() + "'");
            cmd.Connection = con;
              maxEntry.Text  = (cmd.ExecuteScalar().ToString());
         
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

        //Checks if the confirmation for approve/not approved is enabled or disabled
        
        
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 14;");
            cmd.Connection = con;
            getConfirmCmd = (cmd.ExecuteScalar().ToString());
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
                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
            Response.Write("");
        }




        ///////////////////Receiving waiver from database////////////////////
        test.Visible = false;


        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 7;");
            cmd.Connection = con;
            test.Text = (cmd.ExecuteScalar().ToString());
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
            Response.Write("");
        }

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT wWaiver FROM waiver WHERE wName = '" + test.Text + "';");
            cmd.Connection = con;
            Waiver.Text = (cmd.ExecuteScalar().ToString());
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

            Response.Write("A Waiver should be added/created before you edit a Float.");
        }
        //Selective or global
        if (getSelect == "Selective")
        {
            SqlDataSource2.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc, banner, comments,approved, banner, scriptLock FROM floatdetails  WHERE paradeID='" + getParadeID + "';";

            OrgName.SelectCommand = "SELECT pOrgID, oOrganization FROM orginfo WHERE paradeID = '" + getParadeID.ToString() + "';";
        }

        if (getSelect == "Global")
        {
            SqlDataSource2.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc, banner, comments,approved, banner, scriptLock FROM floatdetails;  ";


        }

        Button1.Enabled = false;


        ///////////////////////////////get email config///////////////////////////////////////////////////
        //get the from address
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT fromaddress FROM email WHERE emailID = 1;");
            cmd.Connection = con;
            fromAddress = (cmd.ExecuteScalar().ToString());
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
            Response.Write("Some of the fields are empty.");
        }

        //get the smtp host

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT smtphost FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            smtpHost = (cmd.ExecuteScalar().ToString());
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
            Response.Write("Some of the fields are empty.");
        }

        //get the email username
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT useremail FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            emailUsername = (cmd.ExecuteScalar().ToString());
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
            Response.Write("Some of the fields are empty.");
        }


        //get the email password
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT userpass FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            emailPassword = (cmd.ExecuteScalar().ToString());
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
            Response.Write("Some of the fields are empty.");
        }
        //get the port
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT port FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            port = (cmd.ExecuteScalar().ToString());
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
            Response.Write("Some of the fields are empty.");
        }


        ////////////////////////////get email content////////////////////////////////////

        //get activation subject
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT activesubject FROM email WHERE emailID = 5;");
            cmd.Connection = con;
            floatActiveSubject = (cmd.ExecuteScalar().ToString());
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
            Response.Write("Some of the fields are empty.");
        }

        //get inactivation subject
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT inactivesubject FROM email WHERE emailID = 5;");
            cmd.Connection = con;
            floatInActivesSubject = (cmd.ExecuteScalar().ToString());
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
            Response.Write("Some of the fields are empty.");
        }
        //get activation body
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT activebody FROM email WHERE emailID = 5;");
            cmd.Connection = con;
            floatActiveBody = (cmd.ExecuteScalar().ToString());
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
            Response.Write("Some of the fields are empty.");
        }
        //get inactivation body
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT inactivebody FROM email WHERE emailID = 5;");
            cmd.Connection = con;
            floatInActiveBody = (cmd.ExecuteScalar().ToString());
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
            Response.Write("Some of the fields are empty.");
        }
        //get activation footer
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT activefooter FROM email WHERE emailID = 5;");
            cmd.Connection = con;
            floatActiveFooter = (cmd.ExecuteScalar().ToString());
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
            Response.Write("Some of the fields are empty.");
        }

        //get inactive footer
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT inactivefooter FROM email WHERE emailID = 5;");
            cmd.Connection = con;
            floatInActiveFooter = (cmd.ExecuteScalar().ToString());
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
            Response.Write("Some of the fields are empty.");
        }

        

    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/ try{/*get date and time*/String years = DateTime.Now.Year.ToString();String months = DateTime.Now.Month.ToString();String days = DateTime.Now.Day.ToString();String hours = DateTime.Now.Hour.ToString();String mins = DateTime.Now.Minute.ToString();String secs = DateTime.Now.Second.ToString();String fullDate = years + "-" + months + "-" + days;String fullTime = hours + ":" + mins + ":" + secs;MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);con.Open();MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has signed out.' );");cmd.Connection = con;MySqlDataReader reader3 = cmd.ExecuteReader();con.Close(); con.Dispose();}catch (Exception ex){}Session.Remove("userSession");
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx", true);
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        string key = e.CommandName;

        //Lock Toggle Control
        if (key == "scriptLock")
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridView grid = (GridView)e.CommandSource;
            GridViewRow row = grid.Rows[index];

            TableCell tblCell = row.Cells[0];
            authNum = tblCell.Text;

            //script lock
            TableCell place23 = row.Cells[23];
            scriptLockString = place23.Text.Trim();

            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            if (scriptLockString == "Locked")
            {
                try
                {
                    
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("UPDATE floatdetails SET scriptLock='Unlocked' WHERE floatID = '" + authNum + "'; ");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
                }
                catch (Exception)
                {
                    
                    
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

                    MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con1.Open();
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has Unlocked a script for a float with the ID[" + int.Parse(authNum) + "] ' );");
                    cmd1.Connection = con1;
                    GridView1.DataBind();
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

            }
            else
            {
            
            }

            ////////////////////////////////////////////////////////////////////////////////////////
            if (scriptLockString == "Unlocked")
            {
                try
                {

                    MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con1.Open();
                    MySqlCommand cmd1 = new MySqlCommand(" UPDATE floatdetails SET scriptLock='Locked' WHERE floatID = '" + authNum + "'; ");
                    cmd1.Connection = con1;
                    MySqlDataReader reader3 = cmd1.ExecuteReader();
                    con1.Close(); con1.Dispose();
                }
                catch (Exception)
                {


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

                    MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con1.Open();
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has Locked a script for a float with the ID[" + int.Parse(authNum) + "] ' );");
                    cmd1.Connection = con1;
                    GridView1.DataBind();
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



            }
            else 
            {
            
            }

        }

        //Delete Float Command
        if (key == "DeleteFloat")
        {
            try
            {
                AlertLbl.Text = "By clicking confirm, you are deleting this float from the Parade Management System and it cannot be recovered. Do you confirm these changes?";
                confirmPanel.Visible = true;
                //  GridView1.Visible = false;
                GridView1.Enabled = false;
                Button1.Enabled = false;
                searchBtn.Enabled = false;
                advSearch.Enabled = false;

                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];

                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;

                disableConfirm.Visible = false;
                confirmType = "Delete";
            }
            catch(Exception ex)
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

        }

        //Update Float Command
        if (key == "UpdateFloat")
        {
            try
            {
                Button1.Enabled = true;
                disableConfirm.Visible = false;
                confirmType = "Update";
                update = true;
                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];

                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;

                //Parade Drop Down
                TableCell place1 = row.Cells[2];
                Parade.SelectedIndex = Parade.Items.IndexOf
                    (Parade.Items.FindByText(place1.Text));

                //Organization Drop Down
                TableCell place2 = row.Cells[4];
                Organization.SelectedIndex = Organization.Items.IndexOf
                    (Organization.Items.FindByText(place2.Text));

                //Entry Type DropDown
                TableCell place3 = row.Cells[5];
                if (place3.Text == "Float Band" || place3.Text == "FloatBand")
                {
                    Entry.SelectedIndex = 3;
                }
                else
                {
                    Entry.SelectedIndex = Entry.Items.IndexOf
                    (Entry.Items.FindByText(place3.Text));
                }



                //Float Type DropDown
                TableCell place4 = row.Cells[6];
                //floatType.SelectedIndex = floatType.Items.IndexOf
                //     (floatType.Items.FindByText(place4.Text));
                if (place4.Text == "Car")
                {
                    floatType.SelectedIndex = 1;
                }
                else if (place4.Text == "Flat Bed Truck")
                {
                    floatType.SelectedIndex = 2;
                }

                else if (place4.Text == "Flat Bed Rig")
                {
                    floatType.SelectedIndex = 3;
                }
                else
                {
                    floatType.SelectedIndex = 0;
                }



                //Float Length
                TableCell place5 = row.Cells[7];
                floatLength.Text = place5.Text;

                //Float Height
                TableCell place6 = row.Cells[8];
                floatHeight.Text = place6.Text.Replace(nbsp, "");

                //Float Width
                TableCell place7 = row.Cells[9];
                floatWidth.Text = place7.Text;

                //Marchers Drop Down
                TableCell place8 = row.Cells[10];
                Marchers.SelectedIndex = Marchers.Items.IndexOf
                     (Marchers.Items.FindByText(place8.Text));

                //Number of Marchers
                TableCell place9 = row.Cells[11];
                noOfMarchers.Text = place9.Text.Replace(nbsp, "");

                //Sound system
                TableCell place10 = row.Cells[12];
                SoundSystem.SelectedIndex = SoundSystem.Items.IndexOf
                     (SoundSystem.Items.FindByText(place10.Text));



                //Waiver acceptor
                TableCell place12 = row.Cells[13];
                Acceptor.SelectedIndex = Acceptor.Items.IndexOf
                     (Acceptor.Items.FindByText(place12.Text));

                //Fees
                TableCell place13 = row.Cells[14];
                Fees.SelectedIndex = Fees.Items.IndexOf
                     (Fees.Items.FindByText(place13.Text));

                //Amount
                TableCell place14 = row.Cells[15];
                Amount.Text = place14.Text;

                //Status
                TableCell place15 = row.Cells[16];
                Status.SelectedIndex = Status.Items.IndexOf
                     (Status.Items.FindByText(place15.Text));

                //Entry
                TableCell place16 = row.Cells[17];
                EntryNo.Text = place16.Text.Replace(nbsp, "");

                //Entry
                TableCell place17 = row.Cells[18];
                entryCode.Text = place17.Text.Replace(nbsp, "");

                //Description
                TableCell place18 = row.Cells[19];
                Description.Text = place18.Text.Replace(nbsp, "").Replace(singleQuote, "'");

                //script
                TableCell place19 = row.Cells[20];
                scriptLbl.Text = place19.Text.Replace(nbsp, "").Replace(singleQuote, "'");

                //banner
                TableCell place20 = row.Cells[21];
                banner.Text = place20.Text.Replace(nbsp, "").Replace(singleQuote, "'");



                //erase non break line spaces
                if (floatLength.Text.Equals(nbsp))
                {
                    floatLength.Text = "";
                }
                if (floatHeight.Equals(nbsp))
                {
                    floatHeight.Text = "";
                }

                if (floatWidth.Text.Equals(nbsp))
                {
                    floatWidth.Text = "";
                }

                if (Marchers.Equals(nbsp))
                {
                    Marchers.Text = "";
                }


                if (noOfMarchers.Equals(nbsp))
                {
                    noOfMarchers.Text = "";
                }

                if (Amount.Text.Equals(nbsp))
                {
                    Amount.Text = "";
                }

                if (EntryNo.Text.Equals(nbsp))
                {
                    EntryNo.Text = "";
                }

                if (Description.Text.Equals(nbsp))
                {
                    Description.Text = "";
                }

                if (scriptLbl.Text.Equals(nbsp))
                {
                    scriptLbl.Text = "";
                }
                if (banner.Text.Equals(nbsp))
                {
                    banner.Text = "";
                }
            }
            catch(Exception ex)
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
                Response.Write("There was a an error lines 459 - 635 in userFloatDetailsaspx.aspx.cs. Please contact your local Admin.");
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

                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has updated a float with the ID[" + int.Parse(authNum) + "] Some details before the change are[Fees: " + Amount.Text + ", Status: " + Status.Text + ", Entry #: " + EntryNo.Text + ", Entry Code: " + entryCode.Text + ", Waiver Acceptor: " + Acceptor.SelectedValue.ToString() + "]. ' );");
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
        }

        //Approved Command
        if (key == "approved")
        {
            disableConfirm.Visible = true;
            if (getConfirmCmd == "Enabled")
            {
                AlertLbl.Text = "By clicking confirm, you are Approving this float. An confirmation of Approval email will be sent to the orgnaization  and/or users involved. Do you confirm these changes?";
                confirmPanel.Visible = true;
                //  GridView1.Visible = false;
                GridView1.Enabled = false;
                Button1.Enabled = false;
                searchBtn.Enabled = false;
                advSearch.Enabled = false;

                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];

                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;

                confirmType = "Approved";
            }

            if (getConfirmCmd == "Disabled")
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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has approved a float with the ID[" + int.Parse(authNum) + "]. ' );");
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
					//gets the id of the gridview table
                    int index = int.Parse(e.CommandArgument.ToString());
                    GridView grid = (GridView)e.CommandSource;
                    GridViewRow row = grid.Rows[index];

                    TableCell tblCell = row.Cells[0];
                    authNum = tblCell.Text;

				   //get the user id related to the organization
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT porgID FROM floatdetails WHERE floatID = '" + int.Parse(authNum) + "' ;");
                        cmd.Connection = con;
                        getActiveOrgID = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }


                    // Check to see if the user related is already activated
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT oActivation FROM orginfo WHERE porgID = '" + getActiveOrgID.ToString() + "' ;");
                        cmd.Connection = con;
                        verifyActiveOrg = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    if (verifyActiveOrg == "Active")
                    {
                
                    try
                    {
                        //need this to connect to mysql database from here to
                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //get name of stored procedure
                        cmd.CommandText = "ApproveFloat";
                  
                        MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                        cmd.Parameters.Add(p1);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //Response.Write("<script>alert('Hello');</script>");
                        //Response.Redirect("editOrDeleteUser.aspx");
                        reader.Close();
                        con.Close(); con.Dispose();
                   

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }

                    // get the org ID from float tabel
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT porgid FROM floatdetails WHERE floatID = '" + int.Parse(authNum) + "' ;");
                        cmd.Connection = con;
                        getOrgID = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    // get the user ID
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uid FROM orginfo WHERE porgid = '" + int.Parse(getOrgID) + "' ;");
                        cmd.Connection = con;
                        userID = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    //get the first name
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getUFName = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    //get the last name
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getULName = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    //get email
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uEmail FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getEmail = (cmd.ExecuteScalar().ToString());
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

                    //email the user           
                    try
                    {

                        MailMessage mail = new MailMessage(fromAddress.ToString(), getEmail.ToString(), floatActiveSubject.ToString(), "Hello" + " " + getUFName.ToString() + " " + getULName.ToString() + "," + "\r\n" + "\r\n" + floatActiveBody.ToString() + "\r\n" + "\r\n" + floatActiveFooter.ToString());
                        SmtpClient client = new SmtpClient(smtpHost.ToString());
                        client.Port = int.Parse(port);
                        client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                        client.EnableSsl = true;
                        client.Send(mail);
                        Response.Write("Email has been successfully Sent!");
                        Response.AddHeader("REFRESH", "1;URL= editFloatDetailsaspx.aspx");
                    }
                    catch (Exception exs)
                    {

                        Response.Write(" Email was not sent.");

                        //if there is a progbleme with the server, it will prompt the user to try again
                        if (exs is SmtpException)
                        {
                            Response.Write(" Due to server error. Please try again.");
                        }

                        try
                        {
                            //need this to connect to mysql database from here to
                             
                            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            //get name of stored procedure
                            cmd.CommandText = "Not_ApproveFloat";
                            //here

                            //int index = int.Parse(e.CommandArgument.ToString());
                            //GridView grid = (GridView)e.CommandSource;
                            //GridViewRow row = grid.Rows[index];

                            //TableCell tblCell = row.Cells[0];
                            //authNum = tblCell.Text;
                            MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                            cmd.Parameters.Add(p1);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            //Response.Write("<script>alert('Hello');</script>");
                            //Response.Redirect("editOrDeleteUser.aspx");
                            reader.Close();
                            con.Close(); con.Dispose();


                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex);
                        }
                    }
            




                GridView1.DataBind();


                fromAddress = "";
                smtpHost = "";
                emailUsername = "";
                emailPassword = "";
                port = "";
                floatActiveSubject = "";
                floatInActivesSubject = "";
                floatActiveBody = "";
                floatInActiveBody = "";
                floatActiveFooter = "";
                floatInActiveFooter = "";
            
					}
                    else
                    {
                        Response.Write("You cannot approve this Float. The Organization related to it, has yet to be activated.");
                    }
			}

            //Response.AddHeader("REFRESH", "1;URL= editFloatDetailsaspx.aspx");
        }


        //Not Approved Command
        if (key == "notApproved")
        {
            disableConfirm.Visible = true;
            if (getConfirmCmd == "Enabled")
            {
                AlertLbl.Text = "By clicking confirm, you are Disapproving this float. An confirmation of Disapproval email will be sent to the orgnaization  and/or users involved. Do you confirm these changes?";
                confirmPanel.Visible = true;
                //  GridView1.Visible = false;
                GridView1.Enabled = false;
                Button1.Enabled = false;
                searchBtn.Enabled = false;
                advSearch.Enabled = false;

                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];

                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;

                confirmType = "Not_Approved";
            }

            if (getConfirmCmd == "Disabled")
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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has disapproved a float with the ID[" + int.Parse(authNum) + "]. ' );");
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
                
                    try
                    {
                        //need this to connect to mysql database from here to
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //get name of stored procedure
                        cmd.CommandText = "Not_ApproveFloat";
                        //here

                        int index = int.Parse(e.CommandArgument.ToString());
                        GridView grid = (GridView)e.CommandSource;
                        GridViewRow row = grid.Rows[index];

                        TableCell tblCell = row.Cells[0];
                        authNum = tblCell.Text;
                        MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                        cmd.Parameters.Add(p1);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //Response.Write("<script>alert('Hello');</script>");
                        //Response.Redirect("editOrDeleteUser.aspx");
                        reader.Close();
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
                    Console.WriteLine(ex);
                }

                    // get the org ID from float tabel
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT porgid FROM floatdetails WHERE floatID = '" + int.Parse(authNum) + "' ;");
                        cmd.Connection = con;
                        getOrgID = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    // get the user ID
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uid FROM orginfo WHERE porgid = '" + int.Parse(getOrgID) + "' ;");
                        cmd.Connection = con;
                        userID = (cmd.ExecuteScalar().ToString());
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
                            Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
                        }
                        Response.Write("");
                    }

                    //get the first name
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getUFName = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    //get the last name
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getULName = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    //get email
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uEmail FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getEmail = (cmd.ExecuteScalar().ToString());
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

                    //email the user           
                    try
                    {

                        MailMessage mail = new MailMessage(fromAddress.ToString(), getEmail.ToString(), floatInActivesSubject.ToString(), "Hello" + " " + getUFName.ToString() + " " + getULName.ToString() + "," + "\r\n" + "\r\n" + floatInActiveBody.ToString() + "\r\n" + "\r\n" + floatInActiveFooter.ToString());
                        SmtpClient client = new SmtpClient(smtpHost.ToString());
                        client.Port = int.Parse(port);
                        client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                        client.EnableSsl = true;
                        client.Send(mail);
                        Response.Write("Email has been successfully Sent!");
                        Response.AddHeader("REFRESH", "1;URL= editFloatDetailsaspx.aspx");
                    }
                    catch (Exception exs)
                    {

                        Response.Write(" Email was not sent.");

                        //if there is a progbleme with the server, it will prompt the user to try again
                        if (exs is SmtpException)
                        {
                            Response.Write(" Due to server error. Please try again.");
                        }

                      try
                    {
                        //need this to connect to mysql database from here to
                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //get name of stored procedure
                        cmd.CommandText = "ApproveFloat";
                        //here

                        int index = int.Parse(e.CommandArgument.ToString());
                        GridView grid = (GridView)e.CommandSource;
                        GridViewRow row = grid.Rows[index];

                        TableCell tblCell = row.Cells[0];
                        authNum = tblCell.Text;
                        MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                        cmd.Parameters.Add(p1);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //Response.Write("<script>alert('Hello');</script>");
                        //Response.Redirect("editOrDeleteUser.aspx");
                        reader.Close();
                        con.Close(); con.Dispose();
                   

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
                    }

                GridView1.DataBind();

                fromAddress = "";
                smtpHost = "";
                emailUsername = "";
                emailPassword = "";
                port = "";
                floatActiveSubject = "";
                floatInActivesSubject = "";
                floatActiveBody = "";
                floatInActiveBody = "";
                floatActiveFooter = "";
                floatInActiveFooter = "";
            }

            //Response.AddHeader("REFRESH", "1;URL= editFloatDetailsaspx.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Apply Button

        AlertLbl.Text = "By clicking confirm, you are updating this float in the Parade Management System. Do you confirm these changes?";
            confirmPanel.Visible = true;
            //  GridView1.Visible = false;
            GridView1.Enabled = false;
            Button1.Enabled = false;
            searchBtn.Enabled = false;
            advSearch.Enabled = false;

            confirmType = "Update";
    }
    protected void searchBtn_Click(object sender, EventArgs e)
    {
        try
        {

            GridView1.AllowPaging = false;
            GridView1.AllowSorting = false;

            //advance search options
            if (cParade.Checked)
            {
                searchedTable.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved, banner, scriptLock FROM floatdetails  WHERE (parade LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Parade";
            }
            else if (cContact.Checked)
            {
                searchedTable.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved, banner, scriptLock FROM floatdetails  WHERE (Contact LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Contact";
            }
            else if (cOrganization.Checked)
            {
                searchedTable.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved, banner, scriptLock FROM floatdetails  WHERE (organization LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Organization";
            }

            else if (cFloatType.Checked)
            {
                searchedTable.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved, banner, scriptLock FROM floatdetails  WHERE (vehicleType LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Float Type";
            }

            else if (cWavierAcceptor.Checked)
            {
                searchedTable.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved, banner, scriptLock FROM floatdetails  WHERE (waiveraccepter LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Waiver Acceptor";
            }

            else if (cStatus.Checked)
            {
                searchedTable.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved, banner, scriptLock FROM floatdetails   WHERE (status LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Status";
            }

            else if (cEntryType.Checked)
            {
                searchedTable.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved, banner, scriptLock FROM floatdetails   WHERE (entry LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Entry Type";
            }

            else if (cDesc.Checked)
            {
                searchedTable.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved, banner, scriptLock FROM floatdetails  WHERE (floatDesc LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Description";
            }
            else if (cComments.Checked)
            {
                searchedTable.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved, banner, scriptLock FROM floatdetails   WHERE (comments LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Comments";
            }
            else if (cApproval.Checked)
            {
                searchedTable.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved, banner, scriptLock FROM floatdetails   WHERE (approved LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Approval";
            }
            else
            {
                searchedTable.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved, banner, scriptLock FROM floatdetails WHERE (contact LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Name";
            }


            GridView1.DataSourceID = "searchedTable";
        }
        catch(Exception ex)
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
            Response.Write("");
        }
    }
    protected void advSearch_Click(object sender, EventArgs e)
    {
        advSearchPanel.Visible = true;
    }
    protected void ConfirmBtn_Click(object sender, EventArgs e)
    {
        //Confirming Delete Command
        if (confirmType == "Delete")
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has deleted a float with the ID[" + int.Parse(authNum) + "]. ' );");
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


            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                //get name of stored procedure
                cmd.CommandText = "DeleteFloat";
                //here


                MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                cmd.Parameters.Add(p1);
                MySqlDataReader reader = cmd.ExecuteReader();
                //Response.Write("<script>alert('Hello');</script>");
                reader.Close();
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
                Response.Write("");
            }

            // Response.Redirect("editOrDeleteUser.aspx");
            GridView1.DataBind();


            AlertLbl.Text = "";
            confirmPanel.Visible = false;
            GridView1.Enabled = true;
            Button1.Enabled = true;
            searchBtn.Enabled = true;
            advSearch.Enabled = true;

            confirmType = "";
        }

        //Confirming Update Command
        if (confirmType == "Update")
        {
            //some fields that might be left null

            if (Amount.Text.Length == 0 )
            {
                Amount.Text = "0";
            }

            if (EntryNo.Text.Length == 0)
            {
                EntryNo.Text = "0";
            }

            

            try
            {
            //TODO:
            //need this to connect to mysql database from here to
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //get name of stored procedure
            cmd.CommandText = "UpdateFloat";
            //here

            
                //TODO: 
                Label1.Text = Parade.SelectedValue.ToString();
                Label2.Text = Organization.SelectedValue.ToString();
                Label3.Text = Entry.Text;
                Label4.Text = floatType.Text;
                Label5.Text = Acceptor.SelectedValue.ToString();
                MySqlParameter p1 = new MySqlParameter("eParade", Label1.Text);
                MySqlParameter p2 = new MySqlParameter("eOrganization", Label2.Text);
                MySqlParameter p3 = new MySqlParameter("eEntry", Label3.Text);
                MySqlParameter p4 = new MySqlParameter("eVehicleType", Label4.Text);
                MySqlParameter p5 = new MySqlParameter("eFloatLength", floatLength.Text);
                MySqlParameter p6 = new MySqlParameter("eFloatHeight", floatHeight.Text);
                MySqlParameter p7 = new MySqlParameter("eFloatWidth", floatWidth.Text);
                MySqlParameter p8 = new MySqlParameter("eMarchers", Marchers.Text);
                MySqlParameter p9 = new MySqlParameter("eNoOfmarchers", noOfMarchers.Text);
                MySqlParameter p10 = new MySqlParameter("eSoundsystem", SoundSystem.Text);
                MySqlParameter p11 = new MySqlParameter("eWaiveraccepter", Label5.Text);
                MySqlParameter p12 = new MySqlParameter("eReceivedFee",Fees.Text);
                MySqlParameter p13 = new MySqlParameter("eAmount",int.Parse( Amount.Text));
                MySqlParameter p14 = new MySqlParameter("eStatus", Status.Text);
                MySqlParameter p15 = new MySqlParameter("eEntryno", int.Parse(EntryNo.Text));
                MySqlParameter p16 = new MySqlParameter("eFloatDesc", Description.Text);
                MySqlParameter p17 = new MySqlParameter("eComments", scriptLbl.Text);
                MySqlParameter p18 = new MySqlParameter("eID", int.Parse(authNum));
                MySqlParameter p19 = new MySqlParameter("eEntryCode", entryCode.Text);
                MySqlParameter p20 = new MySqlParameter("eBanner", banner.Text);

                cmd.Parameters.Add(p20);
                cmd.Parameters.Add(p19);
                cmd.Parameters.Add(p18);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
                cmd.Parameters.Add(p9);
                cmd.Parameters.Add(p10);
                cmd.Parameters.Add(p11);
                cmd.Parameters.Add(p12);
                cmd.Parameters.Add(p13);
                cmd.Parameters.Add(p14);
                cmd.Parameters.Add(p15);
                cmd.Parameters.Add(p16);
                cmd.Parameters.Add(p17);
                
               
                
                MySqlDataReader reader = cmd.ExecuteReader();
                
                GridView1.DataBind();
                con.Close(); con.Dispose();
                reader.Close();
                con.Dispose();

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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has updated a float with the ID[" + int.Parse(authNum) + "] Some details after the change are[Fees: " + Amount.Text + ", Status: " + Status.Text + ", Entry #: " + EntryNo.Text + ", Entry Code: " + entryCode.Text + ", Waiver Acceptor: " + Acceptor.SelectedValue.ToString() + "]. ' );");
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


                Response.Redirect("editFloatDetailsaspx.aspx");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
           
           

        }




        
        //Approval

        if (confirmType == "Approved")
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has approved a float with the ID[" + int.Parse(authNum) + "]. ' );");
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

              //get the user id related to the organization
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT porgID FROM floatdetails WHERE floatID = '" + int.Parse(authNum) + "' ;");
                        cmd.Connection = con;
                        getActiveOrgID = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }


                    // Check to see if the user related is already activated
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT oActivation FROM orginfo WHERE porgID = '" + getActiveOrgID.ToString() + "' ;");
                        cmd.Connection = con;
                        verifyActiveOrg = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    if (verifyActiveOrg == "Active")
                    {
                
                    try
                    {
                         //need this to connect to mysql database from here to
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //get name of stored procedure
                        cmd.CommandText = "ApproveFloat";
                        //here
                        
                        MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                        cmd.Parameters.Add(p1);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //Response.Write("<script>alert('Hello');</script>");
                        //Response.Redirect("editOrDeleteUser.aspx");
                        reader.Close();
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
                    Console.WriteLine(ex);
                }

                    // get the org ID from float tabel
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT porgid FROM floatdetails WHERE floatID = '" + int.Parse(authNum) + "' ;");
                        cmd.Connection = con;
                        getOrgID = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    // get the user ID
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uid FROM orginfo WHERE porgid = '" + int.Parse(getOrgID) + "' ;");
                        cmd.Connection = con;
                        userID = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }


                    //get the first name
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getUFName = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    //get the last name
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getULName = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    //get email
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uEmail FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getEmail = (cmd.ExecuteScalar().ToString());
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

                    //email the user           
                    try
                    {

                        MailMessage mail = new MailMessage(fromAddress.ToString(), getEmail.ToString(), floatActiveSubject.ToString(), "Hello" + " " + getUFName.ToString() + " " + getULName.ToString() + "," + "\r\n" + "\r\n" + floatActiveBody.ToString() + "\r\n" + "\r\n" + floatActiveFooter.ToString());
                        SmtpClient client = new SmtpClient(smtpHost.ToString());
                        client.Port = int.Parse(port);
                        client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                        client.EnableSsl = true;
                        client.Send(mail);
                        Response.Write("Email has been successfully Sent!");
                        Response.AddHeader("REFRESH", "1;URL= editFloatDetailsaspx.aspx");
                    }
                    catch (Exception exs)
                    {

                        Response.Write(" Email was not sent.");

                        //if there is a progbleme with the server, it will prompt the user to try again
                        if (exs is SmtpException)
                        {
                            Response.Write(" Due to server error. Please try again.");
                        }

                        try
                    {
                         //need this to connect to mysql database from here to
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //get name of stored procedure
                        cmd.CommandText = "Not_ApproveFloat";
                        //here
                        
                        MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                        cmd.Parameters.Add(p1);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //Response.Write("<script>alert('Hello');</script>");
                        //Response.Redirect("editOrDeleteUser.aspx");
                        reader.Close();
                        con.Close(); con.Dispose();
                    

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
                    }
            
                

                GridView1.DataBind();
                
            fromAddress = "";
                smtpHost = "";
                emailUsername = "";
                emailPassword = "";
                port = "";
                floatActiveSubject = "";
                floatInActivesSubject = "";
                floatActiveBody = "";
                floatInActiveBody = "";
                floatActiveFooter = "";
floatInActiveFooter = "";
				}
                    else
                    {
                        Response.Write("You cannot approve this Float. The Organization related to it, has yet to be activated.");
                    }

                    //Response.AddHeader("REFRESH", "1;URL= editFloatDetailsaspx.aspx");
        }

        // Not Approved

        if (confirmType == "Not_Approved")
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has disapproved a float with the ID[" + int.Parse(authNum) + "]. ' );");
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
                try
                {
                     //need this to connect to mysql database from here to
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    //get name of stored procedure
                    cmd.CommandText = "Not_ApproveFloat";
                    //here

                    MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                    cmd.Parameters.Add(p1);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    //Response.Write("<script>alert('Hello');</script>");
                    //Response.Redirect("editOrDeleteUser.aspx");
                    reader.Close();
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
                Console.WriteLine(ex);
            }

                // get the org ID from float tabel
                try
                {


                     
                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT porgid FROM floatdetails WHERE floatID = '" + int.Parse(authNum) + "' ;");
                    cmd.Connection = con;
                    getOrgID = (cmd.ExecuteScalar().ToString());
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
                    Response.Write("");
                }

                // get the user ID
                try
                {


                     
                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT uid FROM orginfo WHERE porgid = '" + int.Parse(getOrgID) + "' ;");
                    cmd.Connection = con;
                    userID = (cmd.ExecuteScalar().ToString());
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
                    Response.Write("");
                }


                    //get the first name
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getUFName = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    //get the last name
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getULName = (cmd.ExecuteScalar().ToString());
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
                        Response.Write("");
                    }

                    //get email
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uEmail FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getEmail = (cmd.ExecuteScalar().ToString());
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

                    //email the user           
                    try
                    {

                    MailMessage mail = new MailMessage(fromAddress.ToString(), getEmail.ToString(), floatInActivesSubject.ToString(), "Hello" + " " + getUFName.ToString() + " " + getULName.ToString() + "," + "\r\n" + "\r\n" + floatInActiveBody.ToString() + "\r\n" + "\r\n" + floatInActiveFooter.ToString());
                        SmtpClient client = new SmtpClient(smtpHost.ToString());
                        client.Port = int.Parse(port);
                        client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                        client.EnableSsl = true;
                        client.Send(mail);
                        Response.Write("Email has been successfully Sent!");
                        Response.AddHeader("REFRESH", "1;URL= editFloatDetailsaspx.aspx");
                    }
                    catch (Exception exs)
                    {

                        Response.Write(" Email was not sent.");

                        //if there is a progbleme with the server, it will prompt the user to try again
                        if (exs is SmtpException)
                        {
                            Response.Write(" Due to server error. Please try again.");
                        }

                        try
                        {
                            //need this to connect to mysql database from here to
                             
                            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            //get name of stored procedure
                            cmd.CommandText = "ApproveFloat";
                            //here

                            MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                            cmd.Parameters.Add(p1);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            //Response.Write("<script>alert('Hello');</script>");
                            //Response.Redirect("editOrDeleteUser.aspx");
                            reader.Close();
                            con.Close(); con.Dispose();


                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex);
                        }
                    }
            



            GridView1.DataBind();

            fromAddress = "";
                smtpHost = "";
                emailUsername = "";
                emailPassword = "";
                port = "";
                floatActiveSubject = "";
                floatInActivesSubject = "";
                floatActiveBody = "";
                floatInActiveBody = "";
                floatActiveFooter = "";
floatInActiveFooter = "";

//Response.AddHeader("REFRESH", "1;URL= editFloatDetailsaspx.aspx");

        }
        
        //For every decision this is the outcome

        if (disableConfirm.Checked)
        {
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Disabled' WHERE configID = 14;");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                reader3.Close();

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
                Response.Write("");
            }

        }



        Button1.Enabled = false;
        AlertLbl.Text = "";
        confirmPanel.Visible = false;
        GridView1.Enabled = true;
        Button1.Enabled = true;
        searchBtn.Enabled = true;
        advSearch.Enabled = true;
        confirmType = "";

        //Response.Redirect("editFloatDetailsaspx.aspx");

    }
    protected void CanelBtn_Click(object sender, EventArgs e)
    {
        AlertLbl.Text = "";
        confirmPanel.Visible = false;
        GridView1.Enabled = true;
        Button1.Enabled = true;
        searchBtn.Enabled = true;
        advSearch.Enabled = true;
        //BannerBtn.Enabled = true;
        Button1.Enabled = false;
        confirmType = "";
    }
    protected void Waiver_TextChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {


            //get date and time
            String years1 = DateTime.Now.Year.ToString();
            String months1 = DateTime.Now.Month.ToString();
            String days1 = DateTime.Now.Day.ToString();
            String hours1 = DateTime.Now.Hour.ToString();
            String mins1 = DateTime.Now.Minute.ToString();
            String secs1 = DateTime.Now.Second.ToString();
            String fullDate1 = years1 + "-" + months1 + "-" + days1;
            String fullTime1 = hours1 + "-" + mins1 + "-" + secs1;

            string fileName = "ParadeMSFloatTable" + "_" + fullDate1 + "_" + fullTime1 + ".csv";

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * INTO OUTFILE '" + uploadPath + fileName + "' FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '\"'LINES TERMINATED BY '\n' FROM floatdetails;", con);
            con.Open();

            cmd.ExecuteNonQuery();

            con.Close(); con.Dispose();
            /*
             cmd.Connection = con;
                 MySqlDataReader reader3 = cmd.ExecuteReader();
                 reader3.Close();
             */

            Response.ContentType = "APPLICATION/OCTET-STREAM";
            String Header = "Attachment; Filename=" + fileName;
            Response.AppendHeader("Content-Disposition", Header);

            //needs to be modified when added to server
            System.IO.FileInfo Dfile = new System.IO.FileInfo(uploadPath + fileName);
            Response.WriteFile(Dfile.FullName);
            //Don't forget to add the following line
            Response.End();

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
            Response.Write("");
        }


    }
    protected void lockAllScriptBtn_Click(object sender, EventArgs e)
    {
        if (lockAllScriptBtn.Text == "Unlocked")
        {
               try
                {

                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value = 'Locked' WHERE configID = 25; UPDATE floatdetails SET scriptLock = 'Unlocked'; ");
                    cmd.Connection = con;
                    //globalScriptLock = (cmd.ExecuteScalar().ToString());
                    MySqlDataReader reader3 = cmd.ExecuteReader();
                    con.Close(); con.Dispose();
                    GridView1.DataBind();
                    Response.Redirect("editFloatDetailsaspx.aspx");
                    
                }
                catch (Exception ex)
                {
                    Response.Write("Unable to perform global lock");
                }
        }


        if (lockAllScriptBtn.Text == "Locked")
        {
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value = 'Unlocked' WHERE configID = 25; UPDATE floatdetails SET scriptLock = 'Locked';");
                cmd.Connection = con;
                //globalScriptLock = (cmd.ExecuteScalar().ToString());
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
                GridView1.DataBind();
                Response.Redirect("editFloatDetailsaspx.aspx");
            }
            catch (Exception ex)
            {
                Response.Write("Unable to perform global lock");
            }
        }

    }
    protected void safeCheck_CheckedChanged(object sender, EventArgs e)
    {
        lockAllScriptBtn.Enabled = true;
    }
}