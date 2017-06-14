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

public partial class passwordManagement : System.Web.UI.Page
{
    static string hash;
    static string hash1;

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
    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/ try{/*get date and time*/String years = DateTime.Now.Year.ToString();String months = DateTime.Now.Month.ToString();String days = DateTime.Now.Day.ToString();String hours = DateTime.Now.Hour.ToString();String mins = DateTime.Now.Minute.ToString();String secs = DateTime.Now.Second.ToString();String fullDate = years + "-" + months + "-" + days;String fullTime = hours + ":" + mins + ":" + secs;MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);con.Open();MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has signed out.' );");cmd.Connection = con;MySqlDataReader reader3 = cmd.ExecuteReader();con.Close(); con.Dispose();}catch (Exception ex){}Session.Remove("userSession");
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx", true);
        }
    }
   
    protected void changePassword_Click1(object sender, EventArgs e)
    {
        if ((oldPass.Text == Session["userSessionPW"].ToString()) &&
            (newPass.Text == reNewPass.Text) && (oldPass.Text != null ||
            newPass.Text != null || reNewPass.Text != null))
        {
            hash = FormsAuthentication.HashPasswordForStoringInConfigFile(newPass.Text + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");
            hash1 = FormsAuthentication.HashPasswordForStoringInConfigFile(oldPass.Text + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE user SET uPassword='" + hash.ToString() + "' WHERE uUsername = '" + Session["userSession"].ToString() + "' AND upassword = '" + hash1.ToString() + "' AND (uStatus = 'Administrator' OR uStatus = 'Super-Administrator');");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

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

            reply.Text = "Password has successfully been change.";
            reNewPass.Text = "";
            newPass.Text = "";
            oldPass.Text = "";

            //makes user log back in with new password
            Response.Write("  You will be logged out shortly. Please log back in with your new password.");
            /*for activity log*/try {/*get date and time*/String years = DateTime.Now.Year.ToString(); String months = DateTime.Now.Month.ToString(); String days = DateTime.Now.Day.ToString(); String hours = DateTime.Now.Hour.ToString(); String mins = DateTime.Now.Minute.ToString(); String secs = DateTime.Now.Second.ToString(); String fullDate = years + "-" + months + "-" + days; String fullTime = hours + ":" + mins + ":" + secs; MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString); con.Open(); MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSessionU"].ToString() + "','User : " + Session["userSessionU"].ToString() + " has signed out.' );"); cmd.Connection = con; MySqlDataReader reader3 = cmd.ExecuteReader(); con.Close(); con.Dispose(); }catch (Exception ex) { } Session.Remove("userSessionU"); Session.Remove("userSessionU");
            Response.AddHeader("REFRESH", "5;URL= adminLogin.aspx");
        }
        else 
        {
            reply.Text = "Sorry. Passwords did not match Please try again.";
            reNewPass.Text = "";
            newPass.Text = "";
            oldPass.Text = "";
        }
    }
}