using System;
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

public partial class userPasswordManagment : System.Web.UI.Page
{
    static string hash;
    static string hash1;


    protected void Page_Load(object sender, EventArgs e)
    {
        //Main Session
        if (Session["userSessionU"] == null)
        {
            Response.Redirect("userLogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSessionU"].ToString();
        }
    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        //userSessionU

       /*for activity log*/try {/*get date and time*/String years = DateTime.Now.Year.ToString(); String months = DateTime.Now.Month.ToString(); String days = DateTime.Now.Day.ToString(); String hours = DateTime.Now.Hour.ToString(); String mins = DateTime.Now.Minute.ToString(); String secs = DateTime.Now.Second.ToString(); String fullDate = years + "-" + months + "-" + days; String fullTime = hours + ":" + mins + ":" + secs; MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString); con.Open(); MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSessionU"].ToString() + "','User : " + Session["userSessionU"].ToString() + " has signed out.' );"); cmd.Connection = con; MySqlDataReader reader3 = cmd.ExecuteReader(); con.Close(); con.Dispose(); }catch (Exception ex) { } Session.Remove("userSessionU"); Session.Remove("userSessionU");
        if (Session["userSessionU"] == null)
        {
            Response.Redirect("userLogin.aspx", true);
        }
    }
    protected void changePassword_Click1(object sender, System.EventArgs e)
    {
         if ((oldPass.Text == Session["userSessionPWU"].ToString()) &&
            (newPass.Text == reNewPass.Text) && (oldPass.Text != null ||
            newPass.Text != null || reNewPass.Text != null))
        {
            hash = FormsAuthentication.HashPasswordForStoringInConfigFile(newPass.Text + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");
            hash1 = FormsAuthentication.HashPasswordForStoringInConfigFile(oldPass.Text + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");

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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDates + "','" + fullTimes + "','" + Session["userSessionU"].ToString() + "','User: " + Session["userSessionU"].ToString() + " changed their password.' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {


            }

            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE user SET uPassword='" + hash.ToString() + "' WHERE uUsername = '" + Session["userSessionU"].ToString() + "' AND upassword = '" + hash1.ToString() + "' AND (uStatus = 'Participant' OR  uStatus = 'Volunteer' );");
                cmd.Connection = con;
                MySqlDataReader reader1 = cmd.ExecuteReader();
                reader1.Close();

               

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
             


            reply.Text = "Password has successfully been change.";

             //clear fields
            reNewPass.Text = "";
            newPass.Text = "";
            oldPass.Text = "";
            changePassword.Enabled = false;

            //makes user log back in with new password
            Response.Write("  You will be logged out shortly. Please log back in with your new password.");
            /*for activity log*/try {/*get date and time*/String years = DateTime.Now.Year.ToString(); String months = DateTime.Now.Month.ToString(); String days = DateTime.Now.Day.ToString(); String hours = DateTime.Now.Hour.ToString(); String mins = DateTime.Now.Minute.ToString(); String secs = DateTime.Now.Second.ToString(); String fullDate = years + "-" + months + "-" + days; String fullTime = hours + ":" + mins + ":" + secs; MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString); con.Open(); MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSessionU"].ToString() + "','User : " + Session["userSessionU"].ToString() + " has signed out.' );"); cmd.Connection = con; MySqlDataReader reader3 = cmd.ExecuteReader(); con.Close(); con.Dispose(); }catch (Exception ex) { } Session.Remove("userSessionU"); Session.Remove("userSessionU");
            Response.AddHeader("REFRESH", "5;URL= userLogin.aspx");

            
           

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