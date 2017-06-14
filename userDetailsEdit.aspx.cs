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
using System.Drawing;

public partial class userDetailsEdit : System.Web.UI.Page
{
    static string authNum;

    static string hash;
    static string lIUserName;
    static string lIUserPwd;
    static string doesEmailExist;
    static bool checkEmail = false;
    static string frmDBEmailExist;

    static string getParadeName;
    static string getUserStatus;
    static string getParadeID;
    static string getUID4Org;
    static string getPOrgID4Float;
    static string getFloatID;
    static string getScript;

    //float gridview pre-defined variables
    static string getParadeNameForFloat;
    static string getWaiverAcceptor;
    static string getFeesRecieved;
    static string getAmount;
    static string getEntryNumber;
    static string getEntryCode;

    //activation label checks
    static string getUserStatusLbl;
    static string getOrgStatusLbl;
    static string getFloatStatusLbl;
    static string getUFName;
    static string getPOrgID;
    static string nbsp = "&nbsp;";
    static string singleQuote = "&#39;";
    static string checkIfScriptLocked;
    

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session: session should always be loaded first, to eliminated possible errors in the future
        if (Session["userSessionU"] == null)
        {
            Response.Redirect("userLogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSessionU"].ToString();
        }
        //Status.Visible = false;



     
    getParadeName = null;
    getUserStatus = null;
    getParadeID = null;
    getUID4Org = null;
    getPOrgID4Float = null;
    getFloatID = null;


    //GridView1.Enabled = false;
    //GridView2.Enabled = false;
    //GridView3.Enabled = false;

        ////////////////////Universal pre-loaded tab info gathering and data setting////////////////////
        
        //disable buttons on page load : user tab button
        Button1.Enabled = false;


        OrgName.SelectCommand = "";

        //assigning sessions strings to strings : easier to manage
        lIUserName = Session["userSessionU"].ToString();
        lIUserPwd = Session["userSessionPWU"].ToString();

        //Response.Write(Session["userSessionPWU"].ToString());


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
            catch (Exception)
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }

        }


        //hash the password to get the users details so that it matches in the database
        hash = FormsAuthentication.HashPasswordForStoringInConfigFile(Session["userSessionPWU"].ToString() + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");

        //get the organization contact name
        //contName
        contName.SelectCommand = "SELECT concat (ufname,' ', ulname) FROM user WHERE uUsername = '" + Session["userSessionU"].ToString() + "' AND uPassword = '" + hash.ToString() + "' AND uStatus = 'Participant'";

       
        ////////////////////////////////User account tab//////////////////////////////////

        //--------get the account type for the user-----------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uStatus FROM user WHERE uUsername = '" + lIUserName + "' AND uPassword = '" + hash.ToString() + "';");
            cmd.Connection = con;
            getUserStatus = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
            userTabSavedLabel0.Text = "Please log out and back in again. An error has occured.";

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

        if (getUserStatus == "Volunteer")
        {
            //if volunteer disable these tabs
            TabPanel1.Enabled = false;
            TabPanel2.Enabled = false;
        }


        //get the users details
        editTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user WHERE uUsername = '" + Session["userSessionU"].ToString() + "' AND uPassword = '" + hash.ToString() + "' AND (uStatus = 'Volunteer' OR uStatus = 'Participant') AND (uActivation = 'Active' OR uActivation = 'In-Active') ;";

        GridView1.DataBind();

        ////////////////////////////////User organization tab//////////////////////////////////


        //--------get the contact name for the specific organization-----------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uID FROM user WHERE uUsername = '" + Session["userSessionU"].ToString() + "' AND uPassword = '" + hash.ToString() + "' AND  uStatus = 'Participant' ;");
            cmd.Connection = con;
            getUID4Org = (cmd.ExecuteScalar().ToString());
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
        
        //--------get the parade ID from get ParadeName from the config page -----------------
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
                Response.Write("There are no Organizations.");
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

        //get the org details
        editTablesOrg.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE paradeID='" + getParadeID + "' AND  uID = '" + getUID4Org + "';";

        GridView2.DataBind();

        ////////////////////////////////User float tab//////////////////////////////////getFloatID

        //--------get the porgID for the specific float-----------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT porgid FROM orginfo WHERE uID = '" + getUID4Org + "' AND paradeID='" + getParadeID + "'; ");
            cmd.Connection = con;
             getPOrgID4Float = (cmd.ExecuteScalar().ToString());
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

        //--------get the floatID for the specific float from porgid-----------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT floatID FROM floatdetails WHERE porgID = '" + getPOrgID4Float + "' AND paradeID='" + getParadeID + "'; ");
            cmd.Connection = con;
            getFloatID = (cmd.ExecuteScalar().ToString());
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

        // get organization id
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT porgid FROM orginfo WHERE uID = '" + getUID4Org.ToString() + "' ;");
            cmd.Connection = con;
            getPOrgID = (cmd.ExecuteScalar().ToString());
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

        //get the float contacts

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + getUID4Org.ToString() + "' AND paradeID='" + getParadeID + "';");
            cmd.Connection = con;
            getUFName = (cmd.ExecuteScalar().ToString());
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

        
        //get float details
        editTableFloat.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, entryCode, floatDesc,comments,approved, banner FROM floatdetails WHERE uID = '" + getUID4Org + "' AND  paradeID='" + getParadeID + "' ;";

        //(contact='" + getUFName + "' OR floatID='" + getFloatID + "')  AND pOrgID = '" + getPOrgID4Float + "' AND  paradeID='" + getParadeID + "'

        GridView3.DataBind();

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////


        ////////////check the label statuses ///////////////

        //the user
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uActivation FROM user WHERE uUsername = '" + lIUserName + "' AND uPassword = '" + hash.ToString() + "';");
            cmd.Connection = con;
            getUserStatusLbl = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();

            if (getUserStatusLbl == "Active" && getUserStatus == "Participant")
            {
                test1.Visible = true;
                test1.Text = "Your status is active. You are eligable to create/edit an Organization.";
                test1.ForeColor = Color.Green;
                //GridView2.Enabled = true;               
                TabPanel1.Enabled = true;
                
            }
            else if (getUserStatusLbl == "In-Active")
            {
                test1.Visible = true;
                test1.Text = "Your status is In-Active. You are not yet eligable to create/edit an Organization.";
                test1.ForeColor = Color.Red;
                //GridView2.Enabled = false;
                TabPanel1.Enabled = false;
                TabPanel2.Enabled = false;
            }
            else if ((getUserStatusLbl == "Active" || getUserStatusLbl == "In-Active") && (getUserStatus == "Volunteer"))
            {
              
                test1.Text = "";
            }

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

        //the orgnaization
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT  oActivation FROM orginfo  WHERE paradeID='" + getParadeID + "' AND  uID = '" + getUID4Org + "';");
            cmd.Connection = con;
            getOrgStatusLbl = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();

            if (getOrgStatusLbl == "Active")
            {
                Label2.Visible = true;
                Label2.Text = "Your organization status is active. You will be unable to edit your details.";
                Label2.ForeColor = Color.Green;
                GridView2.Enabled = false;
                TabPanel2.Enabled = true;
            }
            else if (getOrgStatusLbl == "In-Active" )
            {
                Label2.Visible = true;
                Label2.Text = "Your organization status is In-Active. You are eligable to edit your details until it's activated.";
                Label2.ForeColor = Color.Red;
                //GridView3.Enabled = false;
                TabPanel2.Enabled = false;
            }

            if (TabPanel1.Enabled == false)
            {
                TabPanel2.Enabled = false;
            }
            else 
            {
                TabPanel2.Enabled = true;
            }

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

        

        //the float
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT approved FROM floatdetails WHERE porgID = '" + getPOrgID4Float + "';");
            cmd.Connection = con;
            getFloatStatusLbl = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();

            if (getFloatStatusLbl == "Approved")
            {
                floatStatuses.Visible = true;
                floatStatuses.Text = "Your float status is Approved. You are eligable to be in the upcoming Parade!  You will be unable to edit your details. ";
                floatStatuses.ForeColor = Color.Green;
                GridView3.Enabled = false;
            }
            else if (getFloatStatusLbl == "Not Approved")
            {
                floatStatuses.Visible = true;
                floatStatuses.Text = "Your float status is Not-Approved. You are eligable to edit your details until it's approved.";
                floatStatuses.ForeColor = Color.Red;
              
            }
            

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
            //userTabSavedLabel.Text = "Please log out and back in again. An error has occured.";
        }

        //get the current user organization for float drop down
        OrgName.SelectCommand = "SELECT oOrganization FROM orginfo WHERE uid='" + getUID4Org + "' AND paradeID='" + getParadeID + "' ;";

        ///////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        userEditMode.Text = "[View Mode]";
        
        //this is needed so that the status change back to view mode after post back
        if (IsPostBack)
        {

        }
        else 
        {
            Button1.Enabled = false;
            orgButton.Enabled = false;
            floatBtn.Enabled = false;
        
        }

        

        if (Button1.Enabled == false)
        {
            userEditMode.Text = "[View Mode]";
            userEditMode.ForeColor = Color.Red;
            userEditMsg.Text = "* Before you fill out text boxes, please select 'Modify'. ";
            userEditMsg.ForeColor = Color.Red;
            userTabSavedLabel.Text = "";
        }

        if (orgButton.Enabled == false)
        {
            orgEditMode.Text = "[View Mode]";
            orgEditMode.ForeColor = Color.Red;
            orgEditMsg.Text = "* Before you fill out text boxes, please select 'Modify'. ";
            orgEditMsg.ForeColor = Color.Red;
            userTabSavedLabel0.Text = "";
        }

        if (floatBtn.Enabled == false)
        {
            floatEditMode.Text = "[View Mode]";
            floatEditMode.ForeColor = Color.Red;
            floatEditMsg.Text = "* Before you fill out text boxes, please select 'Modify'. ";
            floatEditMsg.ForeColor = Color.Red;
            editItemStatusFloat.Text = "";
        }

        //If email change is selected
        if (changeEmail.Checked == true)
        {
            eeEmail.ReadOnly = false;
            Button1.Enabled = true;
            verifyEmailLbl.Visible = true;
            verifyEmail.Visible = true;
            CVEmail.Visible = true;
            CVEmail.Enabled = true;
            RFVEmail.Visible = true;
            RFVEmail.Enabled = true;
            REVEmail.Visible = true;
            REVEmail.Enabled = true;
            
            checkEmail = true;

            userEditMode.Text = "[Edit Mode]";
            userEditMode.ForeColor = Color.Green;
            userEditMsg.Text = "* You can now freely edit your details.";
            userEditMsg.ForeColor = Color.Green;
        }

        // check to see if the script is locked or not
        //--------get the contact name for the specific organization-----------------
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT scriptLock from floatdetails WHERE floatID = '" + getFloatID + "'; ");
            cmd.Connection = con;
            checkIfScriptLocked = (cmd.ExecuteScalar().ToString());
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

        if (checkIfScriptLocked == "Locked")
        {
            editScript.Enabled = false;
            scriptNotice.Text = "Feature is now Locked"; 
        }
        else {  }


        if (Marchers.Text == "Yes")
        {
            noOfMarchers.Enabled = true;
        }
        else 
        {
            noOfMarchers.Enabled = false;
        }
      
    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/try {/*get date and time*/String years = DateTime.Now.Year.ToString(); String months = DateTime.Now.Month.ToString(); String days = DateTime.Now.Day.ToString(); String hours = DateTime.Now.Hour.ToString(); String mins = DateTime.Now.Minute.ToString(); String secs = DateTime.Now.Second.ToString(); String fullDate = years + "-" + months + "-" + days; String fullTime = hours + ":" + mins + ":" + secs; MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString); con.Open(); MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSessionU"].ToString() + "','User : " + Session["userSessionU"].ToString() + " has signed out.' );"); cmd.Connection = con; MySqlDataReader reader3 = cmd.ExecuteReader(); con.Close(); con.Dispose(); }catch (Exception ex) { } Session.Remove("userSessionU"); Session.Remove("userSessionU");
        if (Session["userSessionU"] == null)
        {
            Response.Redirect("userLogin.aspx", true);
        }
    }
    protected void eeProv_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string key = e.CommandName;

        if (key == "UpdateUser")
        {
            changeEmail.Enabled = true;
            try
            {
                /////////////////////////////////////////////////////
             
                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];

                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;

                TableCell place3 = row.Cells[3];
                eeFName.Text = place3.Text.Replace(nbsp, "");

                TableCell place4 = row.Cells[4];
                eeLName.Text = place4.Text.Replace(nbsp, "");

                TableCell place5 = row.Cells[5];
                eeHNo.Text = place5.Text.Replace(nbsp, "");

                TableCell place6 = row.Cells[6];
                eeBNo.Text = place6.Text.Replace(nbsp, "");

                TableCell place7 = row.Cells[7];
                eeCity.Text = place7.Text.Replace(nbsp, "");

                TableCell place8 = row.Cells[8];
                eeStreet.Text = place8.Text.Replace(nbsp, "");


                TableCell place12 = row.Cells[12];

                eeProv.SelectedIndex = eeProv.Items.IndexOf
                      (eeProv.Items.FindByText(place12.Text));


                TableCell place10 = row.Cells[10];
                eeEmail.Text = place10.Text.Replace(nbsp, ""); ;

                //for checks later when updating
                frmDBEmailExist = eeEmail.Text;

                TableCell place11 = row.Cells[11];
                eePost.Text = place11.Text.Replace(nbsp, ""); ;

                TableCell place9 = row.Cells[9];
                //Label1.Text = place9.Text;

             

            }
            catch (Exception)
            {

            }

           
            Button1.Enabled = true;
            userTabSavedLabel0.Visible = false;

            userEditMode.Text = "[Edit Mode]";
            userEditMode.ForeColor = Color.Green;
            userEditMsg.Text = "* You can now freely edit your details.";
            userEditMsg.ForeColor = Color.Green;
        }

    }
    protected void GridView1_RowCommand_Org(object sender, GridViewCommandEventArgs e)
    {
        string key = e.CommandName;

        if (key == "UpdateUser")
        {
            //enabled button
            orgButton.Enabled = true;

            try
            {
                /////////////////////////////////////////////////////

                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];

                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;

                TableCell place1 = row.Cells[1];
                eeOrganization.Text = place1.Text.Replace(nbsp, "");

                TableCell place2 = row.Cells[2];               
                selectContact.SelectedIndex = selectContact.Items.IndexOf
                    (selectContact.Items.FindByText(place2.Text));
               

                TableCell place3 = row.Cells[3];
                eePhone.Text = place3.Text.Replace(nbsp, "");

                TableCell place4 = row.Cells[4];
                eeWebsite.Text = place4.Text.Replace(nbsp, "");

                TableCell place5 = row.Cells[5];
                eEmail.Text = place5.Text.Replace(nbsp, "");

                TableCell place6 = row.Cells[6];
                eStreet.Text = place6.Text.Replace(nbsp, "");

                //TableCell place7 = row.Cells[9];
                //eeCity.Text = place7.Text;

                TableCell place7 = row.Cells[7];
                eCity.Text = place7.Text.Replace(nbsp, "");


                TableCell place8 = row.Cells[8];
                eProv.SelectedIndex = eProv.Items.IndexOf
                      (eProv.Items.FindByText(place8.Text));

                TableCell place10 = row.Cells[10];
                if (place10.Text == "Canada")
                {
                    DropDownList2.SelectedIndex = 1;
                }
                else if (place10.Text == "United States")
                {
                    DropDownList2.SelectedIndex = 2;
                }

                else
                {
                    DropDownList2.SelectedIndex = 0;
                }

                TableCell place11 = row.Cells[9];
                ePost.Text = place11.Text;

                TableCell place9 = row.Cells[13];
                //Label1.Text = place9.Text;


                
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
        userTabSavedLabel0.Text = "";

        //changes the user notification
        orgEditMode.Text = "[Edit Mode]";
        orgEditMode.ForeColor = Color.Green;
        orgEditMsg.Text = "* You can now freely edit your details.";
        orgEditMsg.ForeColor = Color.Green;
    }
    protected void GridView1_RowCommand_Float(object sender, GridViewCommandEventArgs e)
    {
        string key = e.CommandName;

        if (key == "UpdateFloat")
        {
            try
            {
                //enable button
                floatBtn.Enabled = true;

                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];

                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;

                TableCell place1 = row.Cells[2];
                getParadeNameForFloat = place1.Text.Replace(nbsp, "");

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
                floatLength.Text = place5.Text.Replace(nbsp, "");

                //Float Height
                TableCell place6 = row.Cells[8];
                floatHeight.Text = place6.Text.Replace(nbsp, "");

                //Float Width
                TableCell place7 = row.Cells[9];
                floatWidth.Text = place7.Text.Replace(nbsp, "");

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

                //waiver acceptor
                TableCell place13 = row.Cells[13];
                getWaiverAcceptor = place13.Text.Replace(nbsp, "");

                //fee's recieved
                TableCell place14 = row.Cells[14];
                getFeesRecieved = place14.Text.Replace(nbsp, "");

                //amount
                TableCell places15 = row.Cells[15];
                getAmount = places15.Text.Replace(nbsp, "");


              
                if (Marchers.Text == "Yes")
                {
                    noOfMarchers.Enabled = true;
                }
                else
                {
                    noOfMarchers.Enabled = false;
                    noOfMarchers.Text = "0";
                }

          

                


                //Status
                TableCell place15 = row.Cells[16];
                Status.SelectedIndex = Status.Items.IndexOf
                     (Status.Items.FindByText(place15.Text));

                //entry number
                TableCell places17 = row.Cells[17];
                getEntryNumber = places17.Text.Replace(nbsp, "");




                //entry code
                TableCell places18 = row.Cells[18];
                getEntryCode = places18.Text.Replace(nbsp, "");


                //Description
                TableCell place18 = row.Cells[19];
                desc.Text = place18.Text.Replace(nbsp, "").Replace(singleQuote, "'");

                //script
                TableCell place19 = row.Cells[20];
                scriptLbl.Text = place19.Text.Replace(nbsp, "").Replace(singleQuote, "'");

                //banner
                TableCell place20 = row.Cells[21];
                banner.Text = place20.Text.Replace(nbsp, "").Replace(singleQuote, "'");


                //erase non break line spaces
                if (floatLength.Text.Equals("&nbsp;"))
                {
                    floatLength.Text = "";
                }
                if (floatHeight.Equals("&nbsp;"))
                {
                    floatHeight.Text = "";
                }

                if (floatWidth.Text.Equals("&nbsp;"))
                {
                    floatWidth.Text = "";
                }

                if (Marchers.Equals("&nbsp;"))
                {
                    Marchers.Text = "";
                }


                if (noOfMarchers.Equals("&nbsp;"))
                {
                    noOfMarchers.Text = "";
                }


                if (desc.Text.Equals("&nbsp;"))
                {
                    desc.Text = "";
                }

                if (scriptLbl.Text.Equals("&nbsp;"))
                {
                    scriptLbl.Text = "";
                }

                floatEditMode.Text = "[Edit Mode]";
                floatEditMode.ForeColor = Color.Green;
                floatEditMsg.Text = "* You can now freely edit your details.";
                floatEditMsg.ForeColor = Color.Green;

            }
            catch(Exception ex)
            {
                Response.Write("There was a an error lines 630 - 797 in userDetailsEdit.aspx.cs. Please contact your local Admin or Developer.");

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
        

    }   
    protected void Button1_Click(object sender, EventArgs e)
    {
      
        
        //need this to connect to mysql database from here to see if the email exists
        if (checkEmail == true)
        {
             try
                {

                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "checkEmailUName";
                    MySqlParameter p1 = new MySqlParameter("chckEmailName", eeEmail.Text);

                    //MySqlParameter p3 = new MySqlParameter("ofTypeAdmin", p);
                    cmd.Parameters.Add(p1);


                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows && eeEmail.Text != null )
                    {

                        doesEmailExist = "Yes";

                        if (frmDBEmailExist == eeEmail.Text)
                        {
                            doesEmailExist = "No";
                        }

                    }
                    else
                    {
                        doesEmailExist = "No";
                    }
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

                }
        }

        if (doesEmailExist == "Yes")
        {
            userTabSavedLabel.ForeColor = Color.Red;
            userTabSavedLabel.Text = "This email already exists for another user! Please choose another.";
        }


        if ((doesEmailExist == "No") || checkEmail != true)
        {

            //here
            try
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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDates + "','" + fullTimes + "','" + Session["userSessionU"].ToString() + "','User: " + Session["userSessionU"].ToString() + " has updated their user account details.' );");
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

                Button1.Enabled = false;
                eeEmail.ReadOnly = true;
                CVEmail.Visible = false;
                CVEmail.Enabled = false;
                RFVEmail.Visible = false;
                RFVEmail.Enabled = false;
                REVEmail.Visible = false;
                REVEmail.Enabled = false;
                verifyEmailLbl.Visible = false;
                verifyEmail.Visible = false;
                verifyEmail.Text = "";
                changeEmail.Checked = false;

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                //get name of stored procedure
                cmd.CommandText = "UpdateEditUser";

                MySqlParameter p1 = new MySqlParameter("eFirstName", eeFName.Text);
                MySqlParameter p2 = new MySqlParameter("eLastName", eeLName.Text);
                MySqlParameter p3 = new MySqlParameter("eUsername", lIUserName.ToString());

                MySqlParameter p5 = new MySqlParameter("eHomeNumber", eeHNo.Text);
                MySqlParameter p6 = new MySqlParameter("eBusinessNumber", eeBNo.Text);
                MySqlParameter p7 = new MySqlParameter("eEmail", eeEmail.Text);
                MySqlParameter p8 = new MySqlParameter("eAccountType", getUserStatus.ToString());
                MySqlParameter p9 = new MySqlParameter("ePostal", eePost.Text);
                MySqlParameter p10 = new MySqlParameter("eCity", eeCity.Text);
                MySqlParameter p11 = new MySqlParameter("eProv", eeProv.Text);
                MySqlParameter p12 = new MySqlParameter("eStreet", eeStreet.Text);
                MySqlParameter p13 = new MySqlParameter("eID", int.Parse(authNum));

                cmd.Parameters.Add(p13);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p8);
                cmd.Parameters.Add(p9);
                cmd.Parameters.Add(p10);
                cmd.Parameters.Add(p11);
                cmd.Parameters.Add(p12);
                //cmd.Parameters.Add(p13);
                MySqlDataReader reader = cmd.ExecuteReader();
                // Response.Redirect("editOrDeleteUser.aspx", true);
                GridView1.DataBind();
                reader.Close();
                con.Close(); con.Dispose();

                userTabSavedLabel.Visible = true;
                userTabSavedLabel.ForeColor = Color.Blue;
                userTabSavedLabel.Text = "Your details have been saved!";





            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                userTabSavedLabel.Visible = true;
                userTabSavedLabel.Text = "Your details have NOT been saved!";
                Button1.Enabled = true;
            }
       
        Button1.Enabled = false;
        eeFName.Text = "";
        eeLName.Text = "";
        eeHNo.Text = "";
        eeBNo.Text = "";
        eeEmail.Text = "";
        eePost.Text = "";
        eeProv.SelectedIndex = 0;
        eeStreet.Text = "";
        eeCity.Text = "";
        checkEmail = false;
        changeEmail.Enabled = false;
        }
      
    }   
    protected void orgButton_Click(object sender, EventArgs e)
    {
        //disable button
        orgButton.Enabled = false;

        //TODO:
        //need this to connect to mysql database from here to

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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDates + "','" + fullTimes + "','" + Session["userSessionU"].ToString() + "','User: " + Session["userSessionU"].ToString() + " has updated their organization account details.' );");
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

        //update org info
        try
        {
        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
        con.Open();
        MySqlCommand cmd = new MySqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.StoredProcedure;
        //get name of stored procedure
        cmd.CommandText = "UpdateOrganization";
        //here

        
            //TODO: 
            test.Text = DropDownList2.SelectedValue.ToString();
            MySqlParameter p1 = new MySqlParameter("eOrganization", eeOrganization.Text);
            MySqlParameter p2 = new MySqlParameter("eContact", selectContact.Text);
            MySqlParameter p3 = new MySqlParameter("ePhone", eePhone.Text);
            MySqlParameter p4 = new MySqlParameter("eWebsite", eeWebsite.Text);
            MySqlParameter p5 = new MySqlParameter("eEmail", eEmail.Text);
            MySqlParameter p6 = new MySqlParameter("eAddress1", eStreet.Text);
            MySqlParameter p7 = new MySqlParameter("eCity", eCity.Text);
            MySqlParameter p8 = new MySqlParameter("eProvince", eProv.Text);
            MySqlParameter p9 = new MySqlParameter("ePostal", ePost.Text);
            MySqlParameter p10 = new MySqlParameter("eCountry", DropDownList2.Text);
            MySqlParameter p11 = new MySqlParameter("eAttend", "Manditory");

            MySqlParameter p12 = new MySqlParameter("eID", int.Parse(authNum));

            cmd.Parameters.Add(p12);
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

            //cmd.Parameters.Add(p13);
            MySqlDataReader reader = cmd.ExecuteReader();
            // Response.Redirect("editOrDeleteUser.aspx", true);
            GridView2.DataBind();
            con.Close(); con.Dispose();
            reader.Close();
            con.Dispose();

            userTabSavedLabel0.Visible = true;
            userTabSavedLabel0.Text = "Your details have been saved!";
            userTabSavedLabel0.ForeColor = Color.Blue;
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
            userTabSavedLabel0.Visible = true;
           userTabSavedLabel0.Text = "Your details have NOT been saved!";
           orgButton.Enabled = true;
        }

        orgButton.Enabled = false;
        //clear all text fields
        eeOrganization.Text = "";
        test.Text = "";
        eePhone.Text = "";
        eeWebsite.Text = "";
        eEmail.Text = "";
        eStreet.Text = "";
        eCity.Text = "";
        eProv.SelectedIndex = 0;
        ePost.Text = "";
        DropDownList2.SelectedIndex = 0;
        selectContact.SelectedIndex = 0;

    }
    protected void floatBtn_Click(object sender, EventArgs e)
    {
        if (getEntryNumber == "")
        {
            getEntryNumber = "0";
        }

        if (getParadeNameForFloat == "")
        {
           getParadeNameForFloat =  getParadeName.ToString();
        }

        if (Marchers.Text == "Yes")
        {
            
        }
        else
        {
           
            noOfMarchers.Text = "0";
        }


        //disable button
        floatBtn.Enabled = false;

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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDates + "','" + fullTimes + "','" + Session["userSessionU"].ToString() + "','User: " + Session["userSessionU"].ToString() + " has updated their float account details.' );");
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

        //update float details
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
                //Label1.Text = Parade.SelectedValue.ToString();
                Label21.Text = Organization.SelectedValue.ToString();
                Label31.Text = Entry.Text;
                Label71.Text = floatType.Text;
                //Label5.Text = Acceptor.SelectedValue.ToString();
                MySqlParameter p1 = new MySqlParameter("eParade", getParadeNameForFloat);
                MySqlParameter p2 = new MySqlParameter("eOrganization", Label21.Text);
                MySqlParameter p3 = new MySqlParameter("eEntry", Label31.Text);
                MySqlParameter p4 = new MySqlParameter("eVehicleType", Label71.Text);
                MySqlParameter p5 = new MySqlParameter("eFloatLength", floatLength.Text);
                MySqlParameter p6 = new MySqlParameter("eFloatHeight", floatHeight.Text);
                MySqlParameter p7 = new MySqlParameter("eFloatWidth", floatWidth.Text);
                MySqlParameter p8 = new MySqlParameter("eMarchers", Marchers.Text);
                MySqlParameter p9 = new MySqlParameter("eNoOfmarchers", noOfMarchers.Text);
                MySqlParameter p10 = new MySqlParameter("eSoundsystem", SoundSystem.Text);
                MySqlParameter p11 = new MySqlParameter("eWaiveraccepter", getWaiverAcceptor);
                MySqlParameter p12 = new MySqlParameter("eReceivedFee",getFeesRecieved);
                MySqlParameter p13 = new MySqlParameter("eAmount", getAmount);
                MySqlParameter p14 = new MySqlParameter("eStatus", Status.Text);
                MySqlParameter p15 = new MySqlParameter("eEntryno", getEntryNumber);
                MySqlParameter p16 = new MySqlParameter("eFloatDesc", desc.Text);
                MySqlParameter p17 = new MySqlParameter("eComments", scriptLbl.Text);
                MySqlParameter p18 = new MySqlParameter("eID", int.Parse(authNum));
                MySqlParameter p19 = new MySqlParameter("eEntryCode", getEntryCode);
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
                
                GridView3.DataBind();
                con.Close(); con.Dispose();
                reader.Close();
                con.Dispose();

                editItemStatusFloat.Text = "Your details have been saved!";
                editItemStatusFloat.ForeColor = Color.Blue;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                editItemStatusFloat.Text = "Your details have NOT been saved!";
                floatBtn.Enabled = true;
            }
            floatBtn.Enabled = false;

            Organization.SelectedIndex = 0;
            floatType.SelectedIndex = 0;
            floatLength.Text = "";
            floatHeight.Text = "";
            floatWidth.Text = "";
            Marchers.SelectedIndex = 0;
            noOfMarchers.Text = "";
            SoundSystem.SelectedIndex = 0;
            Status.SelectedIndex = 0;
            desc.Text = "";
            scriptLbl.Text = "";
            banner.Text = "";
            Entry.SelectedIndex = 0;
           
            

    }
    protected void eeFName_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void editScript_Click(object sender, EventArgs e)
    {

        //get the script from the database 
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT comments FROM floatdetails WHERE floatID = '" + getFloatID + "';");
            cmd.Connection = con;
            getScript = (cmd.ExecuteScalar().ToString());
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

        //assigned the getScript to the text box

        scriptLbl.Text = getScript;

        editScript.Enabled = false;
        updateScript.Enabled = true;
    }
    protected void updateScript_Click(object sender, EventArgs e)
    {
        editScript.Enabled = true;
        updateScript.Enabled = false;

      scriptLbl.Text =  scriptLbl.Text.Replace(nbsp, "").Replace(singleQuote, "'");
        //update the script
        //get the script from the database 

      try
      {

      MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
      con.Open();
      MySqlCommand cmd = new MySqlCommand();
      cmd.Connection = con;
      cmd.CommandType = CommandType.StoredProcedure;
      //get name of stored procedure
      cmd.CommandText = "UpdateScript";

      MySqlParameter p1 = new MySqlParameter("eComments", scriptLbl.Text);
      MySqlParameter p2 = new MySqlParameter("eID", getFloatID);
      cmd.Parameters.Add(p1);
      cmd.Parameters.Add(p2);

      MySqlDataReader reader = cmd.ExecuteReader();

      GridView3.DataBind();
      con.Close(); con.Dispose();
      reader.Close();
      con.Dispose();

      editItemStatusFloat.Text = "Your details have been saved!";
      editItemStatusFloat.ForeColor = Color.Blue;


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

        //last but not least, clear the script text field
        scriptLbl.Text = "";
    }
}