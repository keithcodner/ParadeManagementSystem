using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Web.Security;
using System.IO;

public partial class adminConfig : System.Web.UI.Page
{
    //@"C:\ProgramData\1UPSolutionsParadeMS"
    bool userActiveFalse = false;
    bool userActiveTrue = true;
    static string uploadServerFilePath = "images\\";
    public static object temps;
    static string checkIfSuperAdmin;
    static string hash;
    static bool SUConfirmed = false;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSession"].ToString();
        }

        setScrollText.Attributes.Add("onkeypress", "javascript:return setScrollText(event);");

        //Get data from the database
        ////////////////Options table onlad from the database////////////////////////
        //-------------------changes global user activation status------------------
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 1;");
            cmd.Connection = con;
            userGlobalActive.Text = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //-------------------changes global org activation status------------------
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 2;");
            cmd.Connection = con;
            OrgGlobalActive.Text = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //------changes global user expiry date as well as global user activation-------
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT pdValue FROM pagedateconfig WHERE paradeDateID = 1;");
            cmd.Connection = con;
            userGlobalExpire.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //------changes global org expiry date as well as global user activation-------
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT pdValue FROM pagedateconfig WHERE paradeDateID = 2;");
            cmd.Connection = con;
            OrgGlobalExpire.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }


        //------  waiver edit ----------------------
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 7;");
            cmd.Connection = con;
            waiverEdit.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }


        //------ get  enable/disable confirmations check for users activation----------------------

        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 8;");
            cmd.Connection = con;
            confirmEnaDis.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //------ get  enable/disable confirmations check for Organization activation  ----------------------



        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 9;");
            cmd.Connection = con;
            confirmEnaDisOrg.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //------ current parade   ----------------------

        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 10;");
            cmd.Connection = con;
            currentParadeLbl.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //------ get scroll text  ----------------------

        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 11;");
            cmd.Connection = con;
            scrollLbl.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //------ load counter to the config  ----------------------

        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM stats WHERE statID = 1;");
            cmd.Connection = con;
            loginCounter.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //------ Approve/not approve all floats  ----------------------
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 13;");
            cmd.Connection = con;
            approvalLbl.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //------Enable/Disabled confirmations check for floats   ----------------------
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 14;");
            cmd.Connection = con;
            floatDisEnaLbl.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //------ Selective Global for parade vew  ----------------------
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 15;");
            cmd.Connection = con;
            globalSelectLbl.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //-------------------user  about description------------------
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 20;");
            cmd.Connection = con;
            userAboutDesc.Text = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //-------------------user home image------------------
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 21;");
            cmd.Connection = con;
            userHomePageImage.Text = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //----------------------snow label--------------------------------------


        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 27;");
            cmd.Connection = con;
            snowLbl.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //----------------------get number of files to delete--------------------------------------


        int fCount = Directory.GetFiles(@"C:\ProgramData\1UPSolutionsParadeMS", "*.csv", SearchOption.TopDirectoryOnly).Length;
        fileCache.Text = fCount.ToString();

    }
    //actions for each button
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/
        try {/*get date and time*/String years = DateTime.Now.Year.ToString(); String months = DateTime.Now.Month.ToString(); String days = DateTime.Now.Day.ToString(); String hours = DateTime.Now.Hour.ToString(); String mins = DateTime.Now.Minute.ToString(); String secs = DateTime.Now.Second.ToString(); String fullDate = years + "-" + months + "-" + days; String fullTime = hours + ":" + mins + ":" + secs; MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString); con.Open(); MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has signed out.' );"); cmd.Connection = con; MySqlDataReader reader3 = cmd.ExecuteReader(); con.Close(); con.Dispose(); }
        catch (Exception ex) { } Session.Remove("userSession");




        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx", true);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }

    //0000000000000000000000000000000000000000000000000000000000000000000000000000000
    //0000000000000000000000000000000000000000000000000000000000000000000000000000000
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void userGlobalActiveBtn_Click(object sender, EventArgs e)
    {
        //if (userGlobalIn_ActiveRadio.Checked)
        //{


        //}
        if (!userGlobalActiveRadio.Checked && !userGlobalIn_ActiveRadio.Checked)
        {
            Response.Write("");
        }

        if (userGlobalActiveRadio.Checked)
        {
            userGlobalActive.Text = "Active";
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Active' WHERE configID = 1;");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has activated all users.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

        }
        //else 
        //{
        //    userGlobalActive.Text = "Active";
        //}

        ////////////////////////////////////////////////////////////////////

        if (userGlobalIn_ActiveRadio.Checked)
        {
            userGlobalActive.Text = "In-Active";
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='In-Active' WHERE configID = 1;");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                reader3.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has Inactivated all users.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

        }
        //else
        //{
        //    userGlobalActive.Text = "In-Active";
        //}
        //-------------------------------------------------------------
        if (userGlobalIn_ActiveRadio.Checked)
        {

            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE user SET uActivation='In-Active' ");
                cmd.Connection = con;
                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }



        }
        /////////////////////////////////////////////////////////////
        if (userGlobalActiveRadio.Checked)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE user SET uActivation='Active' ");
                cmd.Connection = con;
                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();

            }
            catch (Exception ex)
            {


            }


        }

    }
    //1111111111111111111111111111111111111111111111111111111111111111111111111111111
    //11111111111111111111111111111111111111111111111111111111111111111111111111111111
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void OrgGlobalActiveBtn_Click(object sender, EventArgs e)
    {
        if (OrgGlobalActiveRadio.Checked)
        {
            OrgGlobalActive.Text = "Active";
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Active' WHERE configID = 2;");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has activated all organizations.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }
        }
        //else
        //{
        //    OrgGlobalActive.Text = "In-Active";
        //}

        //-------------------------------------------------------------

        if (OrgGlobalIn_ActiveRadio.Checked)
        {
            OrgGlobalActive.Text = "In-Active";
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='In-Active' WHERE configID = 2;");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                reader3.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has Inactivated all organizations.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }
        }
        //else
        //{
        //    OrgGlobalActive.Text = "Active";
        //}
        //////////////////////////////////////////////////////////////////////////
        if (OrgGlobalIn_ActiveRadio.Checked)
        {

            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE orginfo SET oActivation='In-Active' ");
                cmd.Connection = con;
                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();

            }
            catch (Exception ex)
            {


            }


        }
        //-------------------------------------------------------------
        if (OrgGlobalActiveRadio.Checked)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE orginfo SET oActivation='Active' ");
                cmd.Connection = con;
                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

        }
    }
    //2222222222222222222222222222222222222222222222222222222222222222222222222222222
    //2222222222222222222222222222222222222222222222222222222222222222222222222222222
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void userGlobalExpireBtn_Click(object sender, EventArgs e)
    {

        Boolean setTrue = false;
        String ddFullDate;
        String ddFullDateTxtFile;
        String ddDay;
        String ddMonth;
        String ddYear;

        if ((userGlobalExpireDay.SelectedIndex != 0) &&
            (userGlobalExpireMonth.SelectedIndex != 0) &&
            (userGlobalExpireYear.SelectedIndex != 0))
        {

            ddDay = userGlobalExpireDay.SelectedValue.ToString();
            ddMonth = userGlobalExpireMonth.SelectedValue.ToString();
            ddYear = userGlobalExpireYear.SelectedValue.ToString();
            ddFullDate = ddYear + "-" + ddMonth + "-" + ddDay;
            ddFullDateTxtFile = ddDay + "/" + ddMonth + "/" + ddYear;
            //incase of error with db this will be backup, to test remove comments
            // userGlobalExpire.Text = ddFullDate;

            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageDateConfig SET pdValue='" + ddFullDate + "' WHERE paradeDateID = 1");

                cmd.Connection = con;
                MySqlDataReader reader = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader.Close();
                con.Close(); con.Dispose();
                setTrue = true;
            }
            catch (Exception ex)
            {


            }



            //write to file for pms service to read

            try
            {

                string dir = @"C:\ProgramData\1UPSolutionsParadeMS";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\ProgramData\1UPSolutionsParadeMS\UserGlobalExpiry.txt");
                file.WriteLine(ddFullDateTxtFile);

                file.Close();
            }
            catch (Exception)
            {

                Response.Write("File could not be written to.");
            }


        }
        //----------------------------------------------------------------
        if ((userGlobalExpireDay.SelectedIndex != 0) &&
            (userGlobalExpireMonth.SelectedIndex != 0) &&
            (userGlobalExpireYear.SelectedIndex != 0) && setTrue == true)
        {

            ddDay = userGlobalExpireDay.SelectedValue.ToString();
            ddMonth = userGlobalExpireMonth.SelectedValue.ToString();
            ddYear = userGlobalExpireYear.SelectedValue.ToString();
            ddFullDate = ddYear + "-" + ddMonth + "-" + ddDay;
            String tempFulldate = ddFullDate;
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has set a user global expiry date.[" + tempFulldate + "]' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }


            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE user SET uDateExpire = CAST('" + ddFullDate + "' AS DATETIME) ");
                cmd.Connection = con;
                cmd.Connection = con;
                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();
                Response.Redirect("adminConfig.aspx");
            }
            catch (Exception ex)
            {

            }


        }
    }
    //333333333333333333333333333333333333333333333333333333333333333333333333333333
    //333333333333333333333333333333333333333333333333333333333333333333333333333333
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void OrgGlobalExpireBtn_Click(object sender, EventArgs e)
    {
        Boolean setTrue = false;
        String ddFullDate;
        String ddFullDateTxtFile;
        String ddDay;
        String ddMonth;
        String ddYear;

        if ((OrgGlobalExpireDay.SelectedIndex != 0) &&
            (OrgGlobalExpireMonth.SelectedIndex != 0) &&
            (OrgGlobalExpireYear.SelectedIndex != 0))
        {

            ddDay = OrgGlobalExpireDay.SelectedValue.ToString();
            ddMonth = OrgGlobalExpireMonth.SelectedValue.ToString();
            ddYear = OrgGlobalExpireYear.SelectedValue.ToString();
            ddFullDate = ddYear + "-" + ddMonth + "-" + ddDay;
            ddFullDateTxtFile = ddDay + "/" + ddMonth + "/" + ddYear;
            //incase of error with db this will be backup, to test remove comments
            // userGlobalExpire.Text = ddFullDate;

            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageDateConfig SET pdValue='" + ddFullDate + "' WHERE paradeDateID = 2");

                cmd.Connection = con;
                MySqlDataReader reader = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader.Close();
                con.Close(); con.Dispose();
                setTrue = true;

            }
            catch (Exception ex)
            {


            }

            //write to file for pms service to read

            try
            {
                string dir = @"C:\ProgramData\1UPSolutionsParadeMS";
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\ProgramData\1UPSolutionsParadeMS\OrganizationGlobalExpiry.txt");
                file.WriteLine(ddFullDateTxtFile);

                file.Close();
            }
            catch (Exception)
            {

                Response.Write("File could not be written to.");
            }

        }
        //----------------------------------------------------------------
        if ((OrgGlobalExpireDay.SelectedIndex != 0) &&
            (OrgGlobalExpireMonth.SelectedIndex != 0) &&
            (OrgGlobalExpireYear.SelectedIndex != 0) && setTrue == true)
        {

            ddDay = OrgGlobalExpireDay.SelectedValue.ToString();
            ddMonth = OrgGlobalExpireMonth.SelectedValue.ToString();
            ddYear = OrgGlobalExpireYear.SelectedValue.ToString();
            ddFullDate = ddYear + "-" + ddMonth + "-" + ddDay;

            String tempFulldate = ddFullDate;

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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has set a organization global expiry date.[" + tempFulldate + "]' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE orginfo SET oDateExpire = CAST('" + ddFullDate + "' AS DATETIME) ");
                cmd.Connection = con;
                cmd.Connection = con;
                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();
                Response.Redirect("adminConfig.aspx");
            }
            catch (Exception ex)
            {


            }


        }
    }
    //444444444444444444444444444444444444444444444444444444444444444444444444444444
    //444444444444444444444444444444444444444444444444444444444444444444444444444444
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void bannerNameBtn_Click(object sender, EventArgs e)
    {

    }
    //555555555555555555555555555555555555555555555555555555555555555555555555555555
    //555555555555555555555555555555555555555555555555555555555555555555555555555555
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void userEditDeleteBtn_Click(object sender, EventArgs e)
    {

    }
    protected void Button1_Click1(object sender, EventArgs e)
    {

        if (DropDownList1.SelectedValue.ToString() == "0")
        {
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 7;");
                cmd.Connection = con;
                waiverEdit.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        }
        else
        {
            Label1.Text = DropDownList1.SelectedValue.ToString();

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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has changed the global waiver description.[" + DropDownList1.Text + "]' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='" + DropDownList1.Text + "' WHERE configID = 7;");
                cmd.Connection = con;

                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();
                Response.Redirect("adminConfig.aspx");
            }
            catch (Exception ex)
            {


            }

        }

    }
    //666666666666666666666666666666666666666666666666666666666666666666666666666666
    //666666666666666666666666666666666666666666666666666666666666666666666666666666
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void confirmEnaDisBtn_Click(object sender, EventArgs e)
    {
        if (enableConfirm.Checked)
        {
            confirmEnaDis.Text = "Enabled";
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Enabled' WHERE configID = 8;");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has Enabled user activation pop display.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

        }
        //else
        //{
        //    confirmEnaDis.Text = "Disabled";
        //}

        //-------------------------------------------------------------

        if (disableConfirm.Checked)
        {
            confirmEnaDis.Text = "Disabled";
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Disabled' WHERE configID = 8;");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                reader3.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has Disabled user activation pop display.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

        }
        //else
        //{
        //    confirmEnaDis.Text = "Enabled";
        //}

    }
    //777777777777777777777777777777777777777777777777777777777777777777777777777777
    //777777777777777777777777777777777777777777777777777777777777777777777777777777
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void confirmEnaDisOrgBtn_Click(object sender, EventArgs e)
    {
        if (confirmOrgEnable.Checked)
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has Enabled organization activation pop display.' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {


            }


            confirmEnaDisOrg.Text = "Enabled";
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Enabled' WHERE configID = 9;");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }



        }
        //else
        //{
        //    confirmEnaDisOrg.Text = "Disabled";
        //}

        //-------------------------------------------------------------

        if (confirmOrgDisable.Checked)
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

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has Disabled organization activation pop display.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

            confirmEnaDisOrg.Text = "Disabled";
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Disabled' WHERE configID = 9;");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                reader3.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }



        }
        //else
        //{
        //    confirmEnaDisOrg.Text = "Enabled";
        //}
    }
    //888888888888888888888888888888888888888888888888888888888888888888888888888888
    //888888888888888888888888888888888888888888888888888888888888888888888888888888
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void currentParade_Click(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedValue.ToString() == "0")
        {
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 10;");
                cmd.Connection = con;
                currentParadeLbl.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }
        }
        else
        {
            //////////////////GETTING DATA//////////////////////////////////////
            try
            {

                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT paradeName FROM parade WHERE paradeID = '" + DropDownList2.Text + "'");
                cmd1.Connection = con1;
                currentIDValue.Text = (cmd1.ExecuteScalar().ToString());
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has Changed the current parade.[" + currentIDValue.Text + "]' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

            //////////////////UPDATES TO THE CONFIG TABLE//////////////////
            try
            {
                // currentParadeLbl.Text = DropDownList2.SelectedValue.ToString();


                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='" + currentIDValue.Text + "' WHERE configID = 10;");
                cmd.Connection = con;

                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
            // -------------------------------Update ID ---------------------------------
            try
            {


                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET IDs='" + DropDownList2.Text + "' WHERE configID = 10;");
                cmd.Connection = con;

                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();
                Response.Redirect("adminConfig.aspx");
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        }

    }
    //999999999999999999999999999999999999999999999999999999999999999999999999999999
    //999999999999999999999999999999999999999999999999999999999999999999999999999999
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void scrollBtn_Click(object sender, EventArgs e)
    {
        //////Set size and color code in database///////////////////////
        string sizeColourCode;
        sizeColourCode = ddSize.Text + ddColour.Text;

        try
        {


            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET other='" + sizeColourCode + "' WHERE configID = 11;");
            cmd.Connection = con;

            MySqlDataReader reader2 = cmd.ExecuteReader();
            //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
            reader2.Close();
            con.Close(); con.Dispose();
            // Response.Redirect("adminConfig.aspx");
        }
        catch (Exception ex)
        {

            Response.Write("");
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
            MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has changed the scroll text.[" + setScrollText.Text + "]' );");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {


        }

        ////////////////set scroll text in database/////////////////////////////////////////////

        try
        {


            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='" + setScrollText.Text + "' WHERE configID = 11;");
            cmd.Connection = con;

            MySqlDataReader reader2 = cmd.ExecuteReader();
            //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
            reader2.Close();
            con.Close(); con.Dispose();
            Response.Redirect("adminConfig.aspx");
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

       
    }
    //101010101010101010101010101010101010101010101010101010101010101010101010101010
    //101010101010101010101010101010101010101010101010101010101010101010101010101010
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void resetCounter_Click(object sender, EventArgs e)
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

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has reset the login counter.' );");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {


        }

        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE stats SET value=0 WHERE statID=1;");
            cmd.Connection = con;
            MySqlDataReader reader2 = cmd.ExecuteReader();
            //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
            reader2.Close();
            con.Close(); con.Dispose();
            Response.Redirect("adminConfig.aspx");
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
    }
    //11111111111111111111111111111111111111111111111111111111111111111111111111111
    //11111111111111111111111111111111111111111111111111111111111111111111111111111
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void approvalBtn_Click(object sender, EventArgs e)
    {
        if (approveR1.Checked)
        {
            approvalLbl.Text = "Approved";
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Approved' WHERE configID = 13;");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has approved all floats.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

        }
        //else
        //{
        //    
        //}

        //-------------------------------------------------------------

        if (notApproveR2.Checked)
        {
            approvalLbl.Text = "Not Approved";
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Not Approved' WHERE configID = 13;");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                reader3.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has dis-approved all floats.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

        }
        //else
        //{
        //    approvalLbl.Text = "Approved";
        //}

        ///////////////////////////////////////////////////////////////////////////////////////////////
        if (approveR1.Checked)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE floatdetails SET approved='Approved' ");
                cmd.Connection = con;
                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();

            }
            catch (Exception ex)
            {


            }


        }
        //-------------------------------------------------------------
        if (notApproveR2.Checked)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE floatdetails SET approved='Not Approved' ");
                cmd.Connection = con;
                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

        }
    }
    //12121212121212121212121212121212121212121212121212212121212121212121221212121212
    //12121212121212121212121212121212121212121212121212212121212121212121221212121212
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void floatEnaDisBtn_Click(object sender, EventArgs e)
    {
        if (EnableFloatR1.Checked)
        {
            floatDisEnaLbl.Text = "Enabled";

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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has Enabled global float confirmation pop-up display.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Enabled' WHERE configID = 14;");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }



        }
        //else
        //{
        //    floatDisEnaLbl.Text = "Disabled";
        //}

        //-------------------------------------------------------------

        if (DisableFloatR2.Checked)
        {
            floatDisEnaLbl.Text = "Disabled";

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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has Disabled global float confirmation pop-up display.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

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

                Response.Write("");
            }

        }
        //else
        //{
        //    floatDisEnaLbl.Text = "Enabled";
        //}

    }
    //13131313131313131313131313131313131313131313131313131313131313131313131313131313
    //13131313131313131313131313131313131313131313131313131313131313131313131313131313
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void globalSelect_Click(object sender, EventArgs e)
    {
        if (selectSelective.Checked)
        {
            globalSelectLbl.Text = "Selective";

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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has set the Parade Management System to Selective Mode.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }


            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Selective' WHERE configID = 15;");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        }
        //else
        //{
        //    globalSelectLbl.Text = "Global";
        //}

        //-------------------------------------------------------------

        if (selectGlobal.Checked)
        {
            globalSelectLbl.Text = "Global";

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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has set the Parade Management System to Global Mode.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }


            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Global' WHERE configID = 15;");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                reader3.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        }
        //else
        //{
        //    globalSelectLbl.Text = "Selective";
        //}
    }
    //1414141414141414141414141414141414141414141414141414141414141414141414141414141414
    //1414141414141414141414141414141414141414141414141414141414141414141414141414141414
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void PMSReset_Click(object sender, EventArgs e)
    {


        //Position the confirmation panel
        confirmPanel.Visible = true;
        confirmPanelDiv.Style.Add("left", "515px");
        confirmPanelDiv.Style.Add("top", "366px");

        //change text
        AlertLbl.Text = " <b>       ***!!!! WARNING !!!!*** </b>" + "<br />" + "<b> UNLESS THE DATABASE IS BACKED UP, THE DATA YOU ARE ABOUT TO DELETE WILL NOT BE ABLE TO BE RECOVERED. ARE YOU *ABSOLUTELY* SURE YOU CONFIRM THESE CHANGES? </b>";


        //Activate the confirmation

        Button1.Enabled = false;
        PMSReset.Enabled = false;
        userGlobalActiveBtn.Enabled = false;
        OrgGlobalActiveBtn.Enabled = false;
        userGlobalExpireBtn.Enabled = false;
        OrgGlobalExpireBtn.Enabled = false;
        confirmEnaDisBtn.Enabled = false;
        confirmEnaDisOrgBtn.Enabled = false;
        currentParade.Enabled = false;
        scrollBtn.Enabled = false;
        resetCounter.Enabled = false;
        approvalBtn.Enabled = false;
        floatEnaDisBtn.Enabled = false;
        globalSelect.Enabled = false;
        deleteFileBtn.Enabled = false;
        UserHomePageImageBtn.Enabled = false;
        UserAboutDescBtn.Enabled = false;
        enableOrDisableSnow.Enabled = false;


    }
    protected void ConfirmBtn_Click(object sender, EventArgs e)
    {

        //check to see if the user is super admin
        try
        {
            hash = FormsAuthentication.HashPasswordForStoringInConfigFile(passTxt.Text + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");


            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uStatus FROM user WHERE uUsername = '" + usernameTxt.Text + "' AND uPassword = '" + hash + "';");
            cmd.Connection = con;
            checkIfSuperAdmin = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Your credentials were not correct! ");
        }

        if (checkIfSuperAdmin == "Super-Administrator")
        {
            SUConfirmed = true;
        }
        else 
        {
            SUConfirmed = false;
        }


        if (SUConfirmed == true)
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

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has reset the Parade Management System.' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }


            //***************************Reset the Parade*****************************************************

            //delete all floats
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(" ALTER TABLE floatdetails DROP FOREIGN KEY fk_pOrgID; TRUNCATE TABLE floatdetails;  ");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //delete all organization
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("ALTER TABLE orginfo DROP FOREIGN KEY fk_uID; TRUNCATE TABLE orginfo;  ");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }



            //delete all users
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("ALTER TABLE user DROP FOREIGN KEY paradeID_fk; TRUNCATE TABLE user; ");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //delete all parades
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM parade");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //delete all banners
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("TRUNCATE TABLE bannertable");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
            //delete all waiver
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("TRUNCATE TABLE waiver");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //add all foreign key constraints back
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("ALTER TABLE floatdetails ADD CONSTRAINT fk_pOrgID FOREIGN KEY (porgID) REFERENCES orginfo (pOrgID); ALTER TABLE orginfo ADD CONSTRAINT fk_uID FOREIGN KEY (uID) REFERENCES user (uID); ALTER TABLE user ADD CONSTRAINT paradeID_fk FOREIGN KEY (paradeID) REFERENCES parade (paradeID);");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //delete all notes
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("TRUNCATE TABLE datenote");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
            //Add one default admin account
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO user(uUsername, uPassword, uFName, uLName, uStatus, uActivation ) VALUES('administrator', 'AC79920F2A3826F13B1FEE6F7378398EC6BBADD2', 'Administrator', 'Password', 'Super-Administrator', 'Active');");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //delete email data
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("TRUNCATE TABLE email");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //delete user messages
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("TRUNCATE TABLE messageFromUser");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }


            //delete general email data
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("TRUNCATE TABLE generalemail");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }


            //insert rows for email
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO email (emailID) VALUES(1); INSERT INTO email (emailID) VALUES(2); INSERT INTO email (emailID) VALUES(3);INSERT INTO email (emailID) VALUES(4);INSERT INTO email (emailID) VALUES(5);INSERT INTO email (emailID) VALUES(6);");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //insert rows for generalemail
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO generalemail (generalemailID) VALUES(1); INSERT INTO generalemail (generalemailID) VALUES(2); INSERT INTO generalemail (generalemailID) VALUES(3);INSERT INTO generalemail (generalemailID) VALUES(4);INSERT INTO generalemail (generalemailID) VALUES(5);INSERT INTO generalemail (generalemailID) VALUES(6);");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }


            //Re-Enable buttons
            PMSReset.Enabled = true;
            userGlobalActiveBtn.Enabled = true;
            OrgGlobalActiveBtn.Enabled = true;
            userGlobalExpireBtn.Enabled = true;
            OrgGlobalExpireBtn.Enabled = true;
            confirmEnaDisBtn.Enabled = true;
            confirmEnaDisOrgBtn.Enabled = true;
            currentParade.Enabled = true;
            scrollBtn.Enabled = true;
            resetCounter.Enabled = true;
            approvalBtn.Enabled = true;
            floatEnaDisBtn.Enabled = true;
            globalSelect.Enabled = true;
            Button1.Enabled = true;

            //Position the confirmation panel
            confirmPanel.Visible = false;
            confirmPanelDiv.Style.Add("left", "301px");
            confirmPanelDiv.Style.Add("top", "253px");

            Label1.Visible = true;
            Label1.Text = "PARADE WAS SUCCESSFULY RESET! Once you log out or  the user session expires, you will need to login in with the default administration account. Once logged in please make a new admin account and delete the defualt account or change the credentials on the default account.";
            SUConfirmed = false;
            checkIfSuperAdmin = "";
        }
        else 
        {

            error.Text = "Wrong credentials. Try again.";
        }
    }
    protected void CanelBtn_Click(object sender, EventArgs e)
    {


        //Re-Enable buttons
        PMSReset.Enabled = true;
        userGlobalActiveBtn.Enabled = true;
        OrgGlobalActiveBtn.Enabled = true;
        userGlobalExpireBtn.Enabled = true;
        OrgGlobalExpireBtn.Enabled = true;
        confirmEnaDisBtn.Enabled = true;
        confirmEnaDisOrgBtn.Enabled = true;
        currentParade.Enabled = true;
        scrollBtn.Enabled = true;
        resetCounter.Enabled = true;
        approvalBtn.Enabled = true;
        floatEnaDisBtn.Enabled = true;
        globalSelect.Enabled = true;
        Button1.Enabled = true;
        deleteFileBtn.Enabled = true;
        UserHomePageImageBtn.Enabled = true;
        UserAboutDescBtn.Enabled = true;
        enableOrDisableSnow.Enabled = true;

        usernameTxt.Text = "";
        passTxt.Text = "";
        error.Text = "";

        //Position the confirmation panel
        confirmPanel.Visible = false;
        confirmPanelDiv.Style.Add("left", "301px");
        confirmPanelDiv.Style.Add("top", "253px");

    }
    //1515151515151515151515151515151515151515151515151515151515151515151515151515151515
    //1515151515151515151515151515151515151515151515151515151515151515151515151515151515
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void test_Click(object sender, EventArgs e)
    {
        //////  String ddFullDate;
        //////String ddDay;
        //////String ddMonth;
        //////String ddYear;



        //////    ddDay = OrgGlobalExpireDay.SelectedValue.ToString();
        //////    ddMonth = OrgGlobalExpireMonth.SelectedValue.ToString();
        //////    ddYear = OrgGlobalExpireYear.SelectedValue.ToString();
        //////    ddFullDate = ddYear + "-" + ddMonth + "-" + ddDay;


        //////    String year = DateTime.Now.Year.ToString();
        //////    String month = DateTime.Now.Month.ToString();
        //////    String day = DateTime.Now.Day.ToString();
        //////    String hour = DateTime.Now.Hour.ToString();
        //////    String min = DateTime.Now.Minute.ToString();
        //////    String sec = DateTime.Now.Second.ToString();
        //////    String fullDate = year + "-" + month + "-" + day;
        //////    String fullTime = hour + ":" + min + ":" + sec;
        //////    test.Text = fullDate + " " + fullTime;


        //    //write to file for pms service to read

        //    try
        //    {
        //        System.IO.StreamWriter file = new System.IO.StreamWriter(Server.MapPath(@"App_Data\\test.txt"));
        //        file.WriteLine(DateTime.Now.Date.ToString("dd/MM/yyyy"));

        //        file.Close();
        //    }
        //    catch (Exception)
        //    {

        //        Response.Write("File could not be written to.");
        //    }

    }
    //161616161616161616161616161616161616161616161616161616161616161616161616161616161616
    //161616161616161616161616161616161616161616161616161616161616161616161616161616161616
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void UserAboutDescBtn_Click(object sender, EventArgs e)
    {
        if (ddUserAboutDesc.SelectedValue.ToString() == "0")
        {
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 20;");
                cmd.Connection = con;
                userAboutDesc.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        }
        else
        {
            Label1.Text = ddUserAboutDesc.SelectedValue.ToString();

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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has changed the user about. [" + ddUserAboutDesc.Text + "]' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='" + ddUserAboutDesc.Text + "' WHERE configID = 20;");
                cmd.Connection = con;

                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();
                Response.Redirect("adminConfig.aspx");
            }
            catch (Exception ex)
            {


            }



        }
    }
    //17171717171717171717171717171717171717171717171717171717171717171717171717171717171717
    //17171717171717171717171717171717171717171717171717171717171717171717171717171717171717
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void UserHomePageImageBtn_Click(object sender, EventArgs e)
    {




        ////////////////////////////////////////////////////////////////////////////
        if (ddUserHomePageImage.SelectedValue.ToString() == "0")
        {
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 21;");
                cmd.Connection = con;
                userHomePageImage.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        }
        else
        {
            //update page config
            Label1.Text = ddUserAboutDesc.SelectedValue.ToString();

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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has changed the user home page image. [" + ddUserHomePageImage.Text + "]' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='" + ddUserHomePageImage.Text + "' WHERE configID = 21;");
                cmd.Connection = con;

                MySqlDataReader reader2 = cmd.ExecuteReader();

                reader2.Close();
                con.Close(); con.Dispose();

            }
            catch (Exception ex)
            {


            }

            //change image
            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT banner FROM bannerTable WHERE bName = '" + ddUserHomePageImage.Text + "';");
                cmd.Connection = con;

                temps = (cmd.ExecuteScalar());

                System.IO.File.WriteAllBytes(Server.MapPath(@uploadServerFilePath + "userImage.png"), (byte[])temps);
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            Image5.ImageUrl = "images\\userImage.png" + "?" + "tn=" + Server.UrlEncode(DateTime.Now.Ticks.ToString());
            //Response.Redirect("adminConfig.aspx");
        }
    }
    //1818181818181818181818181818181818181818181818181818181818181818181818181818181818181818
    //1818181818181818181818181818181818181818181818181818181818181818181818181818181818181818
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void enableOrDisableSnow_Click(object sender, EventArgs e)
    {
        if (enableSnow.Checked)
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

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has enabled snow flakes on the user home page. ' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }



            snowLbl.Text = "Enabled";
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Enabled' WHERE configID = 27;");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
        }

        /////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////

        if (disableSnow.Checked)
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

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has disabled snow flakes on the user home page. ' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }



            snowLbl.Text = "Disabled";

            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Disabled' WHERE configID = 27;");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
        }
    }
    //191919191919191919191919191919191919191919191919191919191919191919191919191919191919191919
    //191919191919191919191919191919191919191919191919191919191919191919191919191919191919191919
    //+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+=+
    protected void deleteFileBtn_Click(object sender, EventArgs e)
    {
        //@"C:\ProgramData\1UPSolutionsParadeMS"

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
                String fullDate = years + "-" + months + "-" + days;
                String fullTime = hours + ":" + mins + ":" + secs;

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has deleted " + fileCache.Text + " chached files from the server. ' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }



            var files = Directory.GetFiles(@"C:\ProgramData\1UPSolutionsParadeMS", "*.csv", SearchOption.AllDirectories)
           .Where(s => s.EndsWith(".csv"));

            foreach (string file in files)
            {
                File.Delete(file);
            }

            Response.Redirect("adminConfig.aspx");
        }
        catch(Exception)
        {
        
        }

      

    }
}