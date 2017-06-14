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

public partial class userDetailsView : System.Web.UI.Page
{

    static string getUID;
    static string getPOrgID;
    static string getFloatID;
    static string getUFName;
    static string hash;
    static string getParadeID;

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

        /////////////////////////////////////////////

        //make the spare div visibility to false
        spare.Visible = false;

        //------ current parade   ----------------------

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

        //get the user id

        //hash the password first
        hash = FormsAuthentication.HashPasswordForStoringInConfigFile(Session["userSessionPWU"].ToString() + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");


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

            //Response.Write("    There is no organization information related to this user.");
        }


        //////////get the float contacts
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + getUID.ToString() + "';");
            cmd.Connection = con;
            getUFName = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("    There is no float information related to this user.");

        }

        //get the org id

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT porgid FROM orginfo WHERE uID = '" + getUID.ToString() + "' ;");
            cmd.Connection = con;
            getPOrgID = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("    There is no organization information related to this user.");
            orgDiv.Visible = false;
            GridView2.Visible = false;

            floatDiv.Visible = false;
            GridView3.Visible = false;
        }

        //get the float id

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT floatID FROM floatdetails WHERE porgID = '" + getPOrgID.ToString() + "';");
            cmd.Connection = con;
            getFloatID = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("    There is no float information related to this user.");
            floatDiv.Visible = false;
            GridView3.Visible = false;

            orgDiv.Visible = false;
            GridView2.Visible = false;
        }

            try
            {
                SqlDataSource1.SelectCommand = "SELECT uID, paradeID,  uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user WHERE uID = '" + getUID.ToString() + "'  ";
            }
            catch (Exception)  
            {

            }

            try
            {

                SqlDataSource2.SelectCommand = "SELECT pOrgID, uID, paradeID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo WHERE uID = '" + getUID.ToString() + "' AND paradeID = '" + getParadeID + "'; ";
            }
            catch (Exception)
            {
                orgDiv.Visible = false;
                GridView2.Visible = false;
            }

            try
            {
                SqlDataSource3.SelectCommand = "SELECT floatID, uID, porgID, parade, paradeID, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, floatDesc,comments,approved, banner FROM floatdetails WHERE uID = '" + getUID + "'  AND paradeID = '" + getParadeID + "'; ";

                //( contact = '" + getUFName.ToString() + "' OR floatID = '" + getFloatID.ToString() + "' )  AND paradeID = '" + getParadeID + "'
            }
            catch (Exception)
            {
                floatDiv.Visible = false;
                GridView3.Visible = false;
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


}