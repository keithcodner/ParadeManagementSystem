using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;

public partial class statReport : System.Web.UI.Page
{

    static string getParadeID;
    static int getPrevParade;

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

        // get the parade id
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

        //getting previous year
        getPrevParade = Int32.Parse(getParadeID) - 1;

        ///////////////////////////////////////////////get Current year figures/////////////////////////////////////////////////////////////

        ////get current year part users
        //SqlDataSource1.SelectCommand = "SELECT uID, uUsername, uPassword, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user WHERE paradeID = '" + getParadeID + "'; ";

        ////get current year part users
        //SqlDataSource2.SelectCommand = "SELECT pOrgID, uID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo WHERE paradeID = '" + getParadeID + "'; ";

        /////////////////////////////////////////////get Previous year figures/////////////////////////////////////////////////////////////

        ////get prev year part users
        //SqlDataSource3.SelectCommand = "SELECT floatID, porgID, parade, contact, organization, entry, vehicleType, floatLength, floatHeight, floatWidth, marchers, noofmarchers, soundsystem, waiveraccepter, receivedFee, amount, status,entryno, entryCode, floatDesc,comments,approved FROM floatdetails WHERE paradeID = '" + getParadeID + "'; ";

        ////get current year part users
        SqlDataSource8.SelectCommand = "SELECT COUNT(*) FROM user WHERE uStatus = 'Participant' AND  paradeID = '" + getParadeID + "';";

    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/ try{/*get date and time*/String years = DateTime.Now.Year.ToString();String months = DateTime.Now.Month.ToString();String days = DateTime.Now.Day.ToString();String hours = DateTime.Now.Hour.ToString();String mins = DateTime.Now.Minute.ToString();String secs = DateTime.Now.Second.ToString();String fullDate = years + "-" + months + "-" + days;String fullTime = hours + ":" + mins + ":" + secs;MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);con.Open();MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has signed out.' );");cmd.Connection = con;MySqlDataReader reader3 = cmd.ExecuteReader();con.Close(); con.Dispose();}catch (Exception ex){}Session.Remove("userSession");
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx", true);
        }
    }
}