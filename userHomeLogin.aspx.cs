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
using System.Drawing;


public partial class userHomeLogin : System.Web.UI.Page
{
    static string dDay;
    static string dMonth;
    static string dYear;
    static string getAllUsers;
    static int getToInt;
    static string getCurrentParaeID;
    static string getUID;
    static string getParadeID;
    static string getPorgID;
    static string test;
    static string getUserStatus;
    static string hash;
    static bool doesOrgExistForUser = false;
    static string getOrgname;
    static bool doesFileExistForUser = false;
    static string uploadFilePath = "C:\\Users\\ikjblue\\Desktop\\Y3S5\\Capstone 2\\ParadeManagementSys2\\uploads\\";
    static string uploadServerFilePath = "uploads\\";
    static string userAboutDescName;
    static string userAboutDesc;
    static string userHomePageImage;
    static string authNum;

    //file name
    static string getFileName;
    static string checkIfActive;

    static string checkSnowFlakes;
    
  



    static String years = DateTime.Now.Year.ToString();
    static String months = DateTime.Now.Month.ToString();
    static String days = DateTime.Now.Day.ToString();
    static String hours = DateTime.Now.Hour.ToString();
    static String mins = DateTime.Now.Minute.ToString();
    static String secs = DateTime.Now.Second.ToString();
    static String fullDate = years + "-" + months + "-" + days;
    static String fullTime = hours + ":" + mins + ":" + secs;
    //   test.Text = fullDate + " " + fullTime;

    //file name
    static string filename;
    static String modifiedFileName;



    protected void Page_Load(object sender, EventArgs e)
    {
        //Session
        if (Session["userSessionU"] == null)
        {
            Response.Redirect("userLogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSessionU"].ToString();
        }

        
        ///////

        //Calculate the date
        dDay = DateTime.Now.DayOfWeek.ToString();
        day.Text = dDay;
        dMonth = String.Format("{0:MMMM}", DateTime.Now).ToString();
        month.Text = dMonth;
        dYear = DateTime.Now.Year.ToString();
        year.Text = dYear;
        monthInt.Text = DateTime.Now.Day.ToString();


        //-------------------user  about description name------------------
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 20;");
            cmd.Connection = con;
            userAboutDescName = ((string)cmd.ExecuteScalar());
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

        //select user  about description

        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT wWaiver FROM waiver WHERE wName = '" + userAboutDescName + "' AND wType = 'About'; ");
            cmd.Connection = con;
            userAboutDesc = ((string)cmd.ExecuteScalar());
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
        
        //load user description
        userDesc.Text = userAboutDesc;

        //-------------------user home image------------------
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 21;");
            cmd.Connection = con;
            userHomePageImage = ((string)cmd.ExecuteScalar());
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

        //Get the Current parade
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT IDs FROM pageconfig WHERE configID = 10;");
            cmd.Connection = con;
            getCurrentParaeID = (cmd.ExecuteScalar().ToString());
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


        //determine user type
        try
        {

            if (Session["getUserType"].ToString().Equals("Participant"))
            {
                volOrPart.Text = " Participant ";
                Session["getUserType"].ToString().Equals(test);
                checkFloatDiv.Visible = true;

                SqlDataSource1.SelectCommand = "SELECT dfilename, ddescription, dfiledate FROM download WHERE (dFileUserType = 'Participant' OR dFileUserType = 'Both' ) ORDER BY dfiledate DESC";
            }

            if (Session["getUserType"].ToString().Equals("Volunteer"))
            {
                volOrPart.Text = " Volunteer ";
                Div1.Visible = false;
                Div1.Disabled = true;

                SqlDataSource1.SelectCommand = "SELECT dfilename, ddescription, dfiledate FROM download WHERE (dFileUserType = 'Volunteer' OR dFileUserType = 'Both' ) ORDER BY dfiledate DESC";
            }

            if (Session["getUserType"].ToString().Equals("Administrator"))
            {
                volOrPart.Text = " Administrator ";
            }

        }
        catch (Exception)
        {

        }




        //hash password
        hash = FormsAuthentication.HashPasswordForStoringInConfigFile(Session["userSessionPWU"].ToString() + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");

        //get user id
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uID FROM user WHERE uUsername = '" + Session["userSessionU"].ToString() + "' AND uPassword = '" + hash + "'; ");
            cmd.Connection = con;
            getUID = (cmd.ExecuteScalar().ToString());
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
            //Response.Write("    There is no organization information related to this user.");
        }


        //check if user is active
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uActivation FROM user WHERE uID = '" + getUID + "'; ");
            cmd.Connection = con;
            checkIfActive = (cmd.ExecuteScalar().ToString());
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
            //Response.Write("    There is no organization information related to this user.");
        }

        //get the org id

        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT porgid FROM orginfo WHERE uID = '" + getUID.ToString() + "' ;");
            cmd.Connection = con;
            getPorgID = (cmd.ExecuteScalar().ToString());
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

        //for testing purposes
        //Response.Write(Session["getUserType"].ToString());

        //createOrg.Enabled = false;

        //hash the password so that it matches in the database
        hash = FormsAuthentication.HashPasswordForStoringInConfigFile(Session["userSessionPWU"].ToString() + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");
        //getting user status
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uActivation FROM user WHERE uUsername = '" + Session["userSessionU"].ToString() + "' AND uPassword = '" + hash + "'; ");
            cmd.Connection = con;
            getUserStatus = (cmd.ExecuteScalar().ToString());
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
            // Response.Write("");
        }

        //Response.Write(getUserStatus);
        //Response.Write(Session["userSessionPWU"].ToString());

        //check to see if the user already has an organization for the current parade year

        //get the orgname from the user table
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uOrgName FROM user WHERE uUsername = '" + Session["userSessionU"].ToString() + "' AND uPassword = '" + hash + "' ; ");
            cmd.Connection = con;
            getOrgname = (cmd.ExecuteScalar().ToString());
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
            // Response.Write("");
        }

        //check to see if the org already exists
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "CheckIfOrgAlreadyExists";
            MySqlParameter p1 = new MySqlParameter("getOrgName", getOrgname.Trim());
            MySqlParameter p2 = new MySqlParameter("getParadeID", Int32.Parse(getCurrentParaeID));

            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                doesOrgExistForUser = true;
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

        //if there are no rows for the download table then remove the download label

        if (GridView1.Rows.Count == 0)
        {
            downloadsLbl.Visible = false;
        }
        else 
        {
            downloadsLbl.Visible = true;
        }


        //check if active to disabled downloads

        if (checkIfActive == "Active")
        {

        }
        else 
        {
        GridView1.Visible = false;
        downloadsLbl.Visible = false;
        }

        ////check if its active
        if (doesOrgExistForUser == true && getUserStatus == "Active")
        {
            createOrg.Enabled = false;
        }
        if (doesOrgExistForUser == false)
        {
            createOrg.Enabled = true;
        }
        if (doesOrgExistForUser == true && getUserStatus == "In-Active")
        {
            createOrg.Enabled = false;
        }
        if (doesOrgExistForUser == false && getUserStatus == "In-Active")
        {
            createOrg.Enabled = false;
        }

        if (doesOrgExistForUser == false && getUserStatus == "Active" && createOrg.Enabled == false)
        {
            CheckBox1.Enabled = true;
        }


        //snow flakes enable or disable

        //----------------------snow label--------------------------------------

        //get the status of the snow flakes option
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 27;");
            cmd.Connection = con;
            checkSnowFlakes = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //according make the decision to enable or disable them
        if (checkSnowFlakes == "Enabled")
        {
            TextBox1.Text = "*";
        }

        if (checkSnowFlakes == "Disabled")
        {
            TextBox1.Text = "";
        }
        
        

    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/try {/*get date and time*/String years = DateTime.Now.Year.ToString(); String months = DateTime.Now.Month.ToString(); String days = DateTime.Now.Day.ToString(); String hours = DateTime.Now.Hour.ToString(); String mins = DateTime.Now.Minute.ToString(); String secs = DateTime.Now.Second.ToString(); String fullDate = years + "-" + months + "-" + days; String fullTime = hours + ":" + mins + ":" + secs; MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString); con.Open(); MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSessionU"].ToString() + "','User : " + Session["userSessionU"].ToString() + " has signed out.' );"); cmd.Connection = con; MySqlDataReader reader3 = cmd.ExecuteReader(); con.Close(); con.Dispose(); }catch (Exception ex) { } Session.Remove("userSessionU"); Session.Remove("userSessionU");
       


        if (Session["userSessionU"] == null)
        {
            Response.Redirect("userLogin.aspx", true);
        }

        //createOrg.Enabled = true;
    }
    protected void createParade_Click(object sender, EventArgs e)
    {

    }
    protected void help_Click(object sender, EventArgs e)
    {
        Response.Redirect("userHelpDoc.aspx");
    }
    protected void createOrg_Click1(object sender, EventArgs e)
    {
        if (getUserStatus == "Active")
        {
            //check to see if the org already exists
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckIfOrgAlreadyExists";
                MySqlParameter p1 = new MySqlParameter("getOrgName", getOrgname.Trim());
                MySqlParameter p2 = new MySqlParameter("getParadeID", Int32.Parse(getCurrentParaeID));

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    //Response.Redirect("userHomeLogin.aspx");
                    // Response.Write("You already have an organization for the current parade. Please contact administration to request adding additional organizations.");
                    Error.Text = "You already have an organization for the current parade. Please contact administration to request adding additional organizations.";
                    Response.AddHeader("REFRESH", "7;URL= userHomeLogin.aspx");
                }
                else
                {
                    //creates session so you can't redirect to page externally
                    Session["createOrgSession"] = "true";
                    Response.Redirect("userAddOrganization.aspx");
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
        else
        {
            // Response.Write("You already have an organization for the current parade. Please contact administration to request adding additional organizations.");
            Error.Text = "Your User Status is In-Active, you cannot create an organization. You will be redirected shortly.";
            Response.AddHeader("REFRESH", "7;URL= userHomeLogin.aspx");
        }



    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    { 
        string key = e.CommandName;
        if (key == "Download")
        {
            int index = int.Parse(e.CommandArgument.ToString());
            GridView grid = (GridView)e.CommandSource;
            GridViewRow row = grid.Rows[index];
            TableCell tblCell = row.Cells[0];
            authNum = tblCell.Text;

            
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT dFileName FROM download WHERE dFileName = '" + authNum + "';");
                cmd.Connection = con;
                getFileName = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            try
            {
                Response.ContentType = "APPLICATION/OCTET-STREAM";
                String Header = "Attachment; Filename=" + getFileName;
                Response.AppendHeader("Content-Disposition", Header);

                //needs to be modified when added to server
                System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath(@uploadServerFilePath + getFileName));
                Response.WriteFile(Dfile.FullName);
                //Don't forget to add the following line
                Response.End();
            }
            catch (Exception)
            {

                Response.Write("No file was found for this user.");
            }
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        createOrg.Enabled = true;
    }
    protected void contactAdmin_Click(object sender, EventArgs e)
    {
        Response.Redirect("contactAdmin.aspx");
    }
    protected void actiavteUpload_CheckedChanged(object sender, EventArgs e)
    {
        uploadControl.Enabled = true;
        uploadFileBtn.Enabled = true;
    }
    protected void uploadFileBtn_Click(object sender, EventArgs e)
    {
        try
        {
            //if (fileSize > (10240))
            //{

            //    error2.Text = "Filesize of image is too large. Maximum file size permitted is " + maxFileSize + "KB";
            //    return;
            //}

            if ((uploadControl.PostedFile != null) && (doesOrgExistForUser == true) && (uploadControl.HasFile != false))
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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDates + "','" + fullTimes + "','" + Session["userSessionU"].ToString() + "','User: " + Session["userSessionU"].ToString() + " has uploaded a new file.' );");
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
                    //get file name
                    filename = uploadControl.PostedFile.FileName;

                    //modify file name
                    modifiedFileName = Session["userSessionU"].ToString() + "_" + getOrgname + "_" + filename;
                    modifiedFileName = modifiedFileName.Replace(" ", "_");

                    //save file to location
                    uploadControl.PostedFile.SaveAs(Server.MapPath(@uploadServerFilePath + modifiedFileName));

                    //insert file name into organizaiton table

                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("UPDATE orginfo SET oFileName='" + modifiedFileName + "' WHERE pOrgID = '" + getPorgID + "'; ");
                    cmd.Connection = con;
                    MySqlDataReader reader2 = cmd.ExecuteReader();
                    //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                    reader2.Close();
                    con.Close(); con.Dispose();

                    error2.ForeColor = Color.Green;
                    error2.Text = "File was uploaded successfully!";

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
                    error2.ForeColor = Color.Red;
                    error2.Text = "File was not uploaded successfully. There might be an issue with illegal characters in the file name.";
                }

            }
            else
            {
                
                error2.ForeColor = Color.Red;
                error2.Text = "Organization for you account doesn't exist yet. Or no file was selected.";
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
            error2.ForeColor = Color.Red;
            error2.Text = "Error Uploading file. Check if organization exists.";
        }

    }

}