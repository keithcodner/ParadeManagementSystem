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


public partial class adminHomeArea : System.Web.UI.Page
{
    static string dDay;
    static string dMonth;
    static string dYear;
    static string getAllUsers;
    static int getToInt;
    static string getCurrentParaeID;
    static string getSelect;
    static string getParadeID;
    static string getParadeName;
    static string getNewMessages;


   static String years = DateTime.Now.Year.ToString();
    static    String months = DateTime.Now.Month.ToString();
    static    String days = DateTime.Now.Day.ToString();
    static    String hours = DateTime.Now.Hour.ToString();
     static   String mins = DateTime.Now.Minute.ToString();
     static   String secs = DateTime.Now.Second.ToString();
     static String fullDate = years + "-" + months + "-" + days;
     static   String fullTime = hours + ":" + mins + ":" + secs;
     //   test.Text = fullDate + " " + fullTime;

    

     

    protected void Page_Load(object sender, EventArgs e)
    {
        cancelBtn.Visible = false;
        //get the current parade
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT IDs FROM pageconfig WHERE configID = 10 ;");
            cmd.Connection = con;
            getCurrentParaeID = Convert.ToString(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //get the current parade name
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 10 ;");
            cmd.Connection = con;
            getParadeName = Convert.ToString(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //check if selective or global
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
        }
        //getting the parade ID
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT IDs FROM pageconfig WHERE configID = 10;");
            cmd.Connection = con;
            getParadeID = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //get all new meassages
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM messageFromUser WHERE messageStatus = 'new' AND paradeID = '" + getParadeID.ToString() + "' ; ");
            cmd.Connection = con;
            getNewMessages = Convert.ToString(cmd.ExecuteScalar());

            newMessages.Text = "(" + getNewMessages + ")";

            if (Int32.Parse(getNewMessages) == 0)
            {
                newMessages.Text = "";
            }

        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        
        //statistic data
        createParadeTable.Visible = false;
        currentParade.Text = getParadeName.ToString();
        ////////////////////Session ////////////////////
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSession"].ToString();
        }

        //Calculate the date
        dDay = DateTime.Now.DayOfWeek.ToString();
        day.Text = dDay;
        dMonth = String.Format("{0:MMMM}", DateTime.Now).ToString();
        month.Text = dMonth;
        dYear = DateTime.Now.Year.ToString();
        year.Text = dYear;
        monthInt.Text = DateTime.Now.Day.ToString();

        //selective or global depending on user selection
        if (getSelect == "Global")
        {
            globalOrSelective.Text = "Global";


        //-----------------------------login counter---------------------------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM stats WHERE statID = 1;");
            cmd.Connection = con;
            loginCounter.Text = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //-----------------------------count all users---------------------------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user;");
            cmd.Connection = con;
            getAllUsers = Convert.ToString(cmd.ExecuteScalar()); 
            getToInt = Convert.ToInt16(getAllUsers);
            getNoOfUser.Text = Convert.ToString(getToInt);
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //-----------------------------count all active users---------------------------------

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE uActivation = 'Active';");
            cmd.Connection = con;
            allActiveUsers.Text = Convert.ToString(cmd.ExecuteScalar());
           
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //-----------------------------count all inactive users---------------------------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE uActivation = 'In-Active';");
            cmd.Connection = con;
            allInActiveUsers.Text = Convert.ToString(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //-----------------------------count all organizations---------------------------------

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM orginfo;");
            cmd.Connection = con;
            allOrganizations.Text = Convert.ToString(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //-----------------------------count all active organizations---------------------------------
        
            try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM orginfo WHERE oActivation = 'Active';");
            cmd.Connection = con;
            allActiveOrg.Text = Convert.ToString(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //-----------------------------count all inactive organizations---------------------------------


            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM orginfo WHERE oActivation = 'In-Active';");
                cmd.Connection = con;
                allInActiveOrg.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        //-----------------------------count all admin users---------------------------------
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE uStatus = 'Administrator';");
                cmd.Connection = con;
                NoOfAdmin.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
        //-----------------------------count all participant users---------------------------------

            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE uStatus = 'Participant';");
                cmd.Connection = con;
                NoOfPart.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
        //-----------------------------count all volunteer users---------------------------------
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE uStatus = 'Volunteer';");
                cmd.Connection = con;
                NoOfVol.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        //-----------------------------count new user of the date---------------------------------

            //when value hangs, attemp to refresh selecting updated values - test did not resolve issue
            //try
            //{
            //     
            //    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            //    con.Open();
            //    MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE uDateJoined = '" + fullDate + "' ");
            //    cmd.Connection = con;
            //    getNewUsers.Text = Convert.ToString(cmd.ExecuteScalar());
            //    //  Response.Write(getNewUsers.Text);
            //}
            //catch (Exception ex)
            //{

            //    Response.Write("");
            //}

            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE uDateJoined = '" + fullDate + "' AND paradeID = '" + getParadeID.ToString() + "'   ;");
                cmd.Connection = con;
                getNewUsers.Text = Convert.ToString(cmd.ExecuteScalar());
              //  Response.Write(getNewUsers.Text);
            }
            catch (Exception ex)
            {

                Response.Write("");
            }
        //-----------------------------count new org of the date----------------------------------

            //when value hangs, attemp to refresh selecting updated values - test did not resolve issue
            //try
            //{
            //     
            //    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            //    con.Open();
            //    MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM orginfo WHERE oDateJoined = '" + fullDate + "'  ;");
            //    cmd.Connection = con;
            //    getNewOrg.Text = Convert.ToString(cmd.ExecuteScalar());
            //    // Response.Write(getNewOrg.Text);
            //}
            //catch (Exception ex)
            //{

            //    Response.Write("");
            //}
            
            
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM orginfo WHERE oDateJoined = '" + fullDate + "' AND paradeID = '" + getParadeID.ToString() + "'  ;");
                cmd.Connection = con;
                getNewOrg.Text = Convert.ToString(cmd.ExecuteScalar());
               // Response.Write(getNewOrg.Text);
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        //-----------------------------grammar checks---------------------------------
            if (getNewUsers.Text == "1")
            {
                chang1.Text = "is";
            }
            else
            {
                chang1.Text = "are";
            }

            if (getNewOrg.Text == "1")
            {
                change2.Text = "is";
            }
            else
            {
                change2.Text = "are";
            }
        //-----------------------------Number of floats---------------------------------
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM floatdetails ;");
                cmd.Connection = con;
                noOfFloats.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        //-----------------------------Number of approved floats---------------------------------
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM floatdetails WHERE approved='Approved' ;");
                cmd.Connection = con;
                noOfApprovedFloats.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        //-----------------------------Number of Not Approved Floats---------------------------------
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM floatdetails WHERE approved='Not Approved' ;");
                cmd.Connection = con;
                noOfNotAppvdFloats.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }


            

            }

            if (getSelect == "Selective")
            {
                globalOrSelective.Text = "Selective";

               //-----------------------------login counter---------------------------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM stats WHERE statID = 1;");
            cmd.Connection = con;
            loginCounter.Text = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //-----------------------------count all users---------------------------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE paradeID = '" + getCurrentParaeID.ToString() + "';");
            cmd.Connection = con;
            getAllUsers = Convert.ToString(cmd.ExecuteScalar()); 
            getToInt = Convert.ToInt16(getAllUsers);
            getNoOfUser.Text = Convert.ToString(getToInt);
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //-----------------------------count all active users---------------------------------

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE uActivation = 'Active' AND paradeID = '" + getCurrentParaeID.ToString() + "';");
            cmd.Connection = con;
            allActiveUsers.Text = Convert.ToString(cmd.ExecuteScalar());
           
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //-----------------------------count all inactive users---------------------------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE uActivation = 'In-Active' AND paradeID = '" + getCurrentParaeID.ToString() + "';");
            cmd.Connection = con;
            allInActiveUsers.Text = Convert.ToString(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //-----------------------------count all organizations---------------------------------

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM orginfo WHERE paradeID = '" + getCurrentParaeID.ToString() + "';");
            cmd.Connection = con;
            allOrganizations.Text = Convert.ToString(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //-----------------------------count all active organizations---------------------------------
        
            try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM orginfo WHERE oActivation = 'Active' AND paradeID = '" + getCurrentParaeID.ToString() + "';");
            cmd.Connection = con;
            allActiveOrg.Text = Convert.ToString(cmd.ExecuteScalar());

        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //-----------------------------count all inactive organizations---------------------------------


            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM orginfo WHERE oActivation = 'In-Active' AND paradeID = '" + getCurrentParaeID.ToString() + "';");
                cmd.Connection = con;
                allInActiveOrg.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        //-----------------------------count all admin users---------------------------------
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE uStatus = 'Administrator' AND paradeID = '" + getCurrentParaeID.ToString() + "'");
                cmd.Connection = con;
                NoOfAdmin.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
        //-----------------------------count all participant users---------------------------------

            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE uStatus = 'Participant' AND paradeID = '" + getCurrentParaeID.ToString() + "';");
                cmd.Connection = con;
                NoOfPart.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
        //-----------------------------count all volunteer users---------------------------------
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE uStatus = 'Volunteer' AND paradeID = '" + getCurrentParaeID.ToString() + "';");
                cmd.Connection = con;
                NoOfVol.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        //-----------------------------count new user of the date---------------------------------

            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM user WHERE uDateJoined = '" + fullDate + "' AND paradeID = '" + getCurrentParaeID.ToString() + "' ;");
                cmd.Connection = con;
                getNewUsers.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
        //-----------------------------count new org of the date----------------------------------
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM orginfo WHERE oDateJoined = '" + fullDate + "' AND paradeID = '" + getCurrentParaeID.ToString() + "';");
                cmd.Connection = con;
                getNewOrg.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        //-----------------------------grammar checks---------------------------------
            if (getNewUsers.Text == "1")
            {
                chang1.Text = "is";
            }
            else
            {
                chang1.Text = "are";
            }

            if (getNewOrg.Text == "1")
            {
                change2.Text = "is";
            }
            else
            {
                change2.Text = "are";
            }
        //-----------------------------Number of floats---------------------------------
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM floatdetails WHERE paradeID = '" + getCurrentParaeID.ToString() + "';");
                cmd.Connection = con;
                noOfFloats.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        //-----------------------------Number of approved floats---------------------------------
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM floatdetails WHERE approved='Approved' AND paradeID = '" + getCurrentParaeID.ToString() + "';");
                cmd.Connection = con;
                noOfApprovedFloats.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        //-----------------------------Number of Not Approved Floats---------------------------------
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM floatdetails WHERE approved='Not Approved' AND paradeID = '" + getCurrentParaeID.ToString() + "';");
                cmd.Connection = con;
                noOfNotAppvdFloats.Text = Convert.ToString(cmd.ExecuteScalar());

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        //-----------------------------count all users---------------------------------
        //-----------------------------count all users---------------------------------
        //-----------------------------count all users---------------------------------
        //-----------------------------count all users---------------------------------
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        //create a new parade


    }


    protected void ActivateBtn_Click(object sender, EventArgs e)
    {
      
        //Activate by date - not going to be used
        //try 
        //{
        //     
        //    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
        //    con.Open();
        //    MySqlCommand cmd = new MySqlCommand("UPDATE user SET uActivation='Active' WHERE uDateJoined='" + fullDate + "';");
        //    cmd.Connection = con;
           
        //    MySqlDataReader reader2 = cmd.ExecuteReader();
        //    //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
        //    reader2.Close();
        //    con.Close(); con.Dispose();
        //    Response.Redirect("adminHomeArea.aspx");
        //}
        //catch (Exception ex)
        //{
		
        //    Response.Write("");
        //}
        
        //make session then redirect

        //org session becomes null
        Session["Org"] = "";
        Session.Remove("Org");

        Session["User"] = "User";
        Response.Redirect("VeiwsForToday.aspx");

    }
    protected void ActiveOrgBtn_Click(object sender, EventArgs e)
    {
        //activated by date - no longer being used
        //try
        //{
        //     
        //    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
        //    con.Open();
        //    MySqlCommand cmd = new MySqlCommand("UPDATE orginfo SET oActivation='Active' WHERE oDateJoined='" + fullDate + "';");
        //    cmd.Connection = con;
            
        //    MySqlDataReader reader2 = cmd.ExecuteReader();
        //    //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
        //    reader2.Close();
        //    con.Close(); con.Dispose();
        //    Response.Redirect("adminHomeArea.aspx");
        //}
        //catch (Exception ex)
        //{

        //    Response.Write("");
        //}

        Session["User"] = "";
        Session.Remove("User");

        Session["Org"] = "Org";
        Response.Redirect("VeiwsForToday.aspx");
    }
    protected void createParade_Click(object sender, EventArgs e)
    {
        s.Visible = false;
        createParadeDiv.Style.Add("width","400px");
        createParadeDiv.Style.Add("height", "250px");
        paradeSubmit.Visible = true;
        createAParadeLbl.Text = "                       You are now creating a Parade!";
        createParade.Visible = false;
        createParadeLbl.Visible = false;
        //////////////table visible is true/////////////////////
        createParadeTable.Visible = true;
        cancelBtn.Visible = true;

       
    }
   
    protected void paradeSubmit_Click(object sender, EventArgs e)
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
            MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has created a new Parade.[ " + paradeNameTxt.Text + " ]' );");
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
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertParade";
            MySqlParameter p1 = new MySqlParameter("eParadeName", paradeNameTxt.Text);
            MySqlParameter p2 = new MySqlParameter("eParadeYear", paradeYearTxt.Text);
            MySqlParameter p3 = new MySqlParameter("eParadeType", paradeTypeTxt.Text);
            MySqlParameter p4 = new MySqlParameter("eParadeDate", paradeDateTxt.Text);
            MySqlParameter p5 = new MySqlParameter("eParadeStartTime", paradeStartTimeTxt.Text);
            MySqlParameter p6 = new MySqlParameter("eParadeEndTime", paradeEndTimeTxt.Text);


            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p5);
            cmd.Parameters.Add(p6);


            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            con.Close(); con.Dispose();





        }
        catch (Exception ex)
        {
            Response.Write("");
        }

       

        //By default set it to the latest parade and makes its the current one 
       
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='" + paradeNameTxt.Text + "' WHERE configID = 10 ;");
            cmd.Connection = con;

            MySqlDataReader reader2 = cmd.ExecuteReader();
            //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
            reader2.Close();
            con.Close(); con.Dispose();
            Response.Redirect("adminHomeArea.aspx");
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

       

        Response.Redirect("adminHomeArea.aspx");

    }
    protected void help_Click(object sender, EventArgs e)
    {
        Response.Redirect("HelpDoc.aspx");
    }
    protected void cancelBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("adminHomeArea.aspx");
    }
}