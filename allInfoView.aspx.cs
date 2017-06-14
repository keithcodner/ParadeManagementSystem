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

public partial class allInfoView : System.Web.UI.Page
{
    static string getUID;
    static string getPOrgID;
    static string getFloatID;
    static string getUFName;
    static string getParadeID;

    protected void Page_Load(object sender, EventArgs e)
    {
        //session
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSession"].ToString();
        }
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

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uID FROM user WHERE uID = '" + Session["getUserID"].ToString() + "' ");
            cmd.Connection = con;
            getUID = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            //Response.Write("    There is no organization information related to this user.");
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



        if (Session["SessionUserInfo"] == "SessionUserInfo")
        {
            try
            {
                SqlDataSource1.SelectCommand = "SELECT uID, uUsername, uPassword, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user WHERE uID = '" + getUID.ToString() + "' ";
            }
            catch(Exception)
            {
            
            }

            try
            {

                SqlDataSource2.SelectCommand = "SELECT pOrgID, uID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo WHERE (porgid = '" + getPOrgID.ToString() + "' OR uID = '" + getUID.ToString() + "'); ";
            }
            catch(Exception)
            {
                orgDiv.Visible = false;
                GridView2.Visible = false;
            }

            //get the float contacts

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



            try{
                SqlDataSource3.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, floatDesc,comments,approved, banner FROM floatdetails WHERE uID = '" + getUID + "'  ; ";

                //(contact = '" + getUFName.ToString() + "' OR floatID = '" + getFloatID.ToString() + "') AND porgID =  '" + getPOrgID.ToString() + "'
            }
            catch (Exception)
            {
                floatDiv.Visible = false;
                GridView3.Visible = false;
            }
            //Session.Remove("SessionUserInfo");

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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}