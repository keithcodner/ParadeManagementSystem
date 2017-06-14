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

public partial class contactAdmin : System.Web.UI.Page
{
    static string getDateTime;
    static string getParadeID;
    static string getUID;
    static string getUserName;

  

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


         userName.Text = usernameSession.Text ;

         ////////////////////////Date Getter//////////////////
         String dyear = DateTime.Now.Year.ToString();
         String dmonth = DateTime.Now.Month.ToString();
         String dday = DateTime.Now.Day.ToString();
         String hour = DateTime.Now.Hour.ToString();
         String min = DateTime.Now.Minute.ToString();
         String sec = DateTime.Now.Second.ToString();
         String fullDate = dyear + "-" + dmonth + "-" + dday;
         //String fullTime = hour + ":" + min + ":" + sec;
         getDateTime = fullDate;

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

         //get the user id

         try
         {

             MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
             con.Open();
             MySqlCommand cmd = new MySqlCommand("SELECT uID FROM user WHERE uUsername = '" + Session["userSessionU"].ToString() + "'  ;");
             cmd.Connection = con;
             getUID = (cmd.ExecuteScalar().ToString());
             con.Close(); con.Dispose();
         }
         catch (Exception ex)
         {

             //Response.Write("    There is no organization information related to this user.");

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

             MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
             con.Open();
             MySqlCommand cmd = new MySqlCommand("SELECT uUsername FROM user WHERE uID = '" + getUID + "' AND paradeID ='" + getParadeID + "' ;");
             cmd.Connection = con;
             getUserName = (cmd.ExecuteScalar().ToString());
             con.Close(); con.Dispose();
         }
         catch (Exception ex)
         {

             //Response.Write("    There is no organization information related to this user.");

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
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/try {/*get date and time*/String years = DateTime.Now.Year.ToString(); String months = DateTime.Now.Month.ToString(); String days = DateTime.Now.Day.ToString(); String hours = DateTime.Now.Hour.ToString(); String mins = DateTime.Now.Minute.ToString(); String secs = DateTime.Now.Second.ToString(); String fullDate = years + "-" + months + "-" + days; String fullTime = hours + ":" + mins + ":" + secs; MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString); con.Open(); MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSessionU"].ToString() + "','User : " + Session["userSessionU"].ToString() + " has signed out.' );"); cmd.Connection = con; MySqlDataReader reader3 = cmd.ExecuteReader(); con.Close(); con.Dispose(); }catch (Exception ex) { } Session.Remove("userSessionU"); Session.Remove("userSessionU");
        if (Session["userSessionU"] == null)
        {
            Response.Redirect("userLogin.aspx", true);
        }

    }
    protected void submitMessage_Click(object sender, EventArgs e)
    {
        if ((subjectTxt.Text.Length == 0) || (messageDescTxt.Text.Length == 0))
        {
            Response.Write("Subject or Description field cannot be left blank.");

        }
        else 
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDates + "','" + fullTimes + "','" + Session["userSessionU"].ToString() + "','User: " + Session["userSessionU"].ToString() + " submitted a new message to admin.' );");
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
            
            //insert the message
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertMessage";
                MySqlParameter p1 = new MySqlParameter("eParadeID", getParadeID);
                MySqlParameter p2 = new MySqlParameter("eUID", getUID);
                MySqlParameter p3 = new MySqlParameter("eUserName", Session["userSessionU"].ToString());
                MySqlParameter p4 = new MySqlParameter("eMessageName", subjectTxt.Text);
                MySqlParameter p5 = new MySqlParameter("eMessageDesc", messageDescTxt.Text);
                MySqlParameter p6 = new MySqlParameter("eMessageDate", getDateTime);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close(); con.Dispose();
                submitMessage.Enabled = false;
                Response.Write("Message was successfully sent. Administation will contact you soon.");
                Response.AddHeader("REFRESH", "5;URL= userHomeLogin.aspx");

            }
            catch (Exception ex)
            {

                Response.Write("There was an error messaging the Administrator. Try again at a later time.");

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

          

           
        }
    }
}