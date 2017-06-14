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
public partial class userHelpDoc : System.Web.UI.Page
{
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

        //determine user type
        if (Session["getUserType"].ToString().Equals("Participant"))
        {
            volOrPart.Text = " Participant ";
        }

        if (Session["getUserType"].ToString().Equals("Volunteer"))
        {
            volOrPart.Text = " Volunteer ";
        }

        if (Session["getUserType"].ToString().Equals("Administrator"))
        {
            volOrPart.Text = " Administrator ";
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