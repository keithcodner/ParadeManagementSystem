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
using System.Drawing;

public partial class adminMessageToUser : System.Web.UI.Page
{

    static string getDateTime;
    static string getUserEmail;
    static string getAllEmails;

    //email data
    static string adminFromAddress;
    static string hostAddress;
    static string emailUsername;
    static string emailPassword;
    static string emailPort;

    public string uFirstName;
    public string uLastName;
    public string getUserName;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSession"].ToString();
        }

        

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

        //Email details
        //get user email - email is selected from drop down
        //get user email
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uEmail FROM user WHERE  uID = '" + getEmail.Text + "' ; ");
            cmd.Connection = con;
            getUserEmail = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();

            
        }
        catch (Exception ex)
        {
            error.ForeColor = Color.Red;
            //error.Text = "could not get first  name";
        }

        //get first name and last name

        //getUserName
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uUsername FROM user WHERE  uID = '" + getEmail.Text + "' ; ");
            cmd.Connection = con;
            getUserName = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();

            if ((getEmail.Text == "one") || (getEmail.Text == "two") || (getEmail.Text == "three") || (getEmail.Text == "four"))
            {
                getUserNames.Text = "";
            }
            else
            {
                getUserNames.Text = getUserName + " ]";
            }

           
        }
        catch (Exception ex)
        {
            error.ForeColor = Color.Red;
            //error.Text = "could not get first  name";
        }

        //first name
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE  uID = '" + getEmail.Text + "' ; ");
            cmd.Connection = con;
            uFirstName = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();

            if ((getEmail.Text == "one") || (getEmail.Text == "two") || (getEmail.Text == "three") || (getEmail.Text == "four"))
            {
                getFirstName.Text = "";
            }
            else
            {
                getFirstName.Text = "[ Name: " + uFirstName;
            }

          
        }
        catch (Exception ex)
        {
            error.ForeColor = Color.Red;
           // error.Text = "could not get first  name";
        }

        //last name
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE  uID = '" + getEmail.Text + "' ; ");
            cmd.Connection = con;
            uLastName = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();

            if ((getEmail.Text == "one") || (getEmail.Text == "two") || (getEmail.Text == "three") || (getEmail.Text == "four"))
            {
                getLastName.Text = "";
            }
            else
            {
                getLastName.Text = ", " + uLastName + "] [ Username :";
            }

          
        }
        catch (Exception ex)
        {
            error.ForeColor = Color.Red;
            //error.Text = "could not get last name";
        }


        //get the admin from address
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT fromaddress FROM email WHERE emailID = 1;");
            cmd.Connection = con;
            adminFromAddress = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {
            error.ForeColor = Color.Red;
            error.Text = " could not get the admin from address ";
        }

        //get simple mail transfer protocol host
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT smtphost FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            hostAddress = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {
            error.ForeColor = Color.Red;
            error.Text = "could not get  simple mail transfer protocol host";
        }
        //get email username
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT useremail FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            emailUsername = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {
            error.ForeColor = Color.Red;
            error.Text = "could not get email username";
        }
        //get email password
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT userpass FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            emailPassword = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {
            error.ForeColor = Color.Red;
            error.Text = "could not get email password ";
        }
        //get email port

        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT port FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            emailPort = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {
            error.ForeColor = Color.Red;
            error.Text = "could not get email port";
        }
        error.Text = "";
    }

    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/ try{/*get date and time*/String years = DateTime.Now.Year.ToString();String months = DateTime.Now.Month.ToString();String days = DateTime.Now.Day.ToString();String hours = DateTime.Now.Hour.ToString();String mins = DateTime.Now.Minute.ToString();String secs = DateTime.Now.Second.ToString();String fullDate = years + "-" + months + "-" + days;String fullTime = hours + ":" + mins + ":" + secs;MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);con.Open();MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has signed out.' );");cmd.Connection = con;MySqlDataReader reader3 = cmd.ExecuteReader();con.Close(); con.Dispose();}catch (Exception ex){}Session.Remove("userSession");
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx", true);
        }
    }
    protected void submitMessage_Click(object sender, EventArgs e)
    {
       

           
        
        if (getEmail.Text == "one")
        {
            //////////////////////////////////////SENDING EMAIL TO EVERYONE/////////////////////////////////////////////////
            //get all emails
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT  GROUP_CONCAT(uemail ORDER BY uemail ASC SEPARATOR ',') FROM user; ");
                cmd.Connection = con;
                getAllEmails = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();

                //error.Text = getAllEmails;
            }
            catch (Exception ex)
            {
                error.ForeColor = Color.Red;
                error.Text = "could not get email password ";
            }
            
            //changes greetings to suit everyone
            uFirstName = "Valued";
            uLastName = "User";

            if ((subjectTxt.Text.Length == 0) || (messageDescTxt.Text.Length == 0) || (getEmail.Text == "0"))
            {
                error.ForeColor = Color.Red;
                error.Text = "Subject or Description field cannot be left blank. An email must also be selected.";
                //error.Text = getAllEmails;

            }
            else
            {
                //test.Text = getAllEmails;
                //try
                //{

                    MailMessage mail = new MailMessage();
                    mail.Subject = subjectTxt.Text;
                    mail.From = new MailAddress(adminFromAddress.ToString());
                    mail.To.Add(getAllEmails);
                    mail.Body = "Hello" + " " + uFirstName.ToString() + " " + uLastName.ToString() + "," + "\r\n" + "\r\n" + messageDescTxt.Text + "\r\n" + "\r\n" + "Regards, " + "\r\n" + "bamnf Board of Trade Administration ";
                    SmtpClient client = new SmtpClient(hostAddress.ToString());
                    client.Port = int.Parse(emailPort);
                    client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                    client.EnableSsl = true;
                    client.Send(mail);

                    error.ForeColor = Color.Green;
                    error.Text = "Message has been successfully Sent!";
                    Response.AddHeader("REFRESH", "2;URL= adminUserMessages.aspx");

                    //once everything is done hide completed form and reveal hidden form
                    //regFormDiv.Visible = false;
                    //completedForm.Visible = true;

                //}
                //catch (Exception exs1)
                //{
                //    error.ForeColor = Color.Red;
                //    error.Text = " Email was not sent.";
                //}
            }
        }
        else if (getEmail.Text == "two")
        {
            //////////////////////////////////////SENDING EMAIL TO ALL Volunteer/////////////////////////////////////////////////
            //get all emails
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT  GROUP_CONCAT(uemail ORDER BY uemail ASC SEPARATOR ',') FROM user WHERE uStatus = 'Volunteer'; ");
                cmd.Connection = con;
                getAllEmails = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();

                //error.Text = getAllEmails;
            }
            catch (Exception ex)
            {
                error.ForeColor = Color.Red;
                error.Text = "could not get email password ";
            }

            //changes greetings to suit everyone
            uFirstName = "Valued";
            uLastName = "User";

            if ((subjectTxt.Text.Length == 0) || (messageDescTxt.Text.Length == 0) || (getEmail.Text == "0"))
            {
                error.ForeColor = Color.Red;
                error.Text = "Subject or Description field cannot be left blank. An email must also be selected.";
                //error.Text = getAllEmails;

            }
            else
            {
                //test.Text = getAllEmails;
                try
                {

                    MailMessage mail = new MailMessage();
                    mail.Subject = subjectTxt.Text;
                    mail.From = new MailAddress(adminFromAddress.ToString());
                    mail.To.Add(getAllEmails);
                    mail.Body = "Hello" + " " + uFirstName.ToString() + " " + uLastName.ToString() + "," + "\r\n" + "\r\n" + messageDescTxt.Text + "\r\n" + "\r\n" + "Regards, " + "\r\n" + "bamnf Board of Trade Administration ";
                    SmtpClient client = new SmtpClient(hostAddress.ToString());
                    client.Port = int.Parse(emailPort);
                    client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                    client.EnableSsl = true;
                    client.Send(mail);

                    error.ForeColor = Color.Green;
                    error.Text = "Message has been successfully Sent!";
                    Response.AddHeader("REFRESH", "2;URL= adminUserMessages.aspx");

                    //once everything is done hide completed form and reveal hidden form
                    //regFormDiv.Visible = false;
                    //completedForm.Visible = true;

                }
                catch (Exception exs1)
                {
                    error.ForeColor = Color.Red;
                    error.Text = " Email was not sent.";
                }
            }
        }
        else if (getEmail.Text == "three")
        {
            //////////////////////////////////////SENDING EMAIL TO ALL Participants/////////////////////////////////////////////////
            //get all emails
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT  GROUP_CONCAT(uemail ORDER BY uemail ASC SEPARATOR ',') FROM user WHERE uStatus = 'Participant'; ");
                cmd.Connection = con;
                getAllEmails = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();

                //error.Text = getAllEmails;
            }
            catch (Exception ex)
            {
                error.ForeColor = Color.Red;
                error.Text = "could not get email password ";
            }

            //changes greetings to suit everyone
            uFirstName = "Valued";
            uLastName = "User";

            if ((subjectTxt.Text.Length == 0) || (messageDescTxt.Text.Length == 0) || (getEmail.Text == "0"))
            {
                error.ForeColor = Color.Red;
                error.Text = "Subject or Description field cannot be left blank. An email must also be selected.";
                //error.Text = getAllEmails;

            }
            else
            {
                //test.Text = getAllEmails;
                try
                {

                    MailMessage mail = new MailMessage();
                    mail.Subject = subjectTxt.Text;
                    mail.From = new MailAddress(adminFromAddress.ToString());
                    mail.To.Add(getAllEmails);
                    mail.Body = "Hello" + " " + uFirstName.ToString() + " " + uLastName.ToString() + "," + "\r\n" + "\r\n" + messageDescTxt.Text + "\r\n" + "\r\n" + "Regards, " + "\r\n" + "bamnf Board of Trade Administration ";
                    SmtpClient client = new SmtpClient(hostAddress.ToString());
                    client.Port = int.Parse(emailPort);
                    client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                    client.EnableSsl = true;
                    client.Send(mail);

                    error.ForeColor = Color.Green;
                    error.Text = "Message has been successfully Sent!";
                    Response.AddHeader("REFRESH", "2;URL= adminUserMessages.aspx");

                    //once everything is done hide completed form and reveal hidden form
                    //regFormDiv.Visible = false;
                    //completedForm.Visible = true;

                }
                catch (Exception exs1)
                {
                    error.ForeColor = Color.Red;
                    error.Text = " Email was not sent.";
                }
            }
        }
        else if (getEmail.Text == "four")
        {
            //////////////////////////////////////SENDING EMAIL TO ALL admins/////////////////////////////////////////////////
            //get all emails
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT  GROUP_CONCAT(uemail ORDER BY uemail ASC SEPARATOR ',') FROM user WHERE uStatus = 'Administrator' OR uStatus = 'Super-Administrator'; ");
                cmd.Connection = con;
                getAllEmails = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();

                //error.Text = getAllEmails;
            }
            catch (Exception ex)
            {
                error.ForeColor = Color.Red;
                error.Text = "could not get email password ";
            }

            //changes greetings to suit everyone
            uFirstName = "Valued";
            uLastName = "User";

            if ((subjectTxt.Text.Length == 0) || (messageDescTxt.Text.Length == 0) || (getEmail.Text == "0"))
            {
                error.ForeColor = Color.Red;
                error.Text = "Subject or Description field cannot be left blank. An email must also be selected.";
                //error.Text = getAllEmails;

            }
            else
            {
                //test.Text = getAllEmails;
                try
                {

                    MailMessage mail = new MailMessage();
                    mail.Subject = subjectTxt.Text;
                    mail.From = new MailAddress(adminFromAddress.ToString());
                    mail.To.Add(getAllEmails);
                    mail.Body = "Hello" + " " + uFirstName.ToString() + " " + uLastName.ToString() + "," + "\r\n" + "\r\n" + messageDescTxt.Text + "\r\n" + "\r\n" + "Regards, " + "\r\n" + "bamnf Board of Trade Administration ";
                    SmtpClient client = new SmtpClient(hostAddress.ToString());
                    client.Port = int.Parse(emailPort);
                    client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                    client.EnableSsl = true;
                    client.Send(mail);

                    error.ForeColor = Color.Green;
                    error.Text = "Message has been successfully Sent!";
                    Response.AddHeader("REFRESH", "2;URL= adminUserMessages.aspx");

                    //once everything is done hide completed form and reveal hidden form
                    //regFormDiv.Visible = false;
                    //completedForm.Visible = true;

                }
                catch (Exception exs1)
                {
                    error.ForeColor = Color.Red;
                    error.Text = " Email was not sent.";
                }
            }
        }
        else 
        {

            //////////////////////////////////////SENDING EMAIL TO ONE PERSON/////////////////////////////////////////////////

            if ((subjectTxt.Text.Length == 0) || (messageDescTxt.Text.Length == 0) || (getEmail.Text == "0"))
            {
                error.ForeColor = Color.Red;
                error.Text = "Subject or Description field cannot be left blank. An email must also be selected.";


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
                    String fullDate = years + "-" + months + "-" + days;
                    String fullTime = hours + ":" + mins + ":" + secs;

                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has sent a message to a user with the email [" + getUserEmail + "].' );");
                    cmd.Connection = con;
                    MySqlDataReader reader3 = cmd.ExecuteReader();
                    con.Close(); con.Dispose();
                }
                catch (Exception ex)
                {


                }

                //try
                //{

                MailMessage mail = new MailMessage(adminFromAddress.ToString(), getUserEmail, subjectTxt.Text, "Hello" + " " + uFirstName.ToString() + " " + uLastName.ToString() + "," + "\r\n" + "\r\n" + messageDescTxt.Text + "\r\n" + "\r\n" + "Regards, " + "\r\n" + "bamnf Board of Trade Administration ");
                SmtpClient client = new SmtpClient(hostAddress.ToString());
                client.Port = int.Parse(emailPort);
                client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                client.EnableSsl = true;
                client.Send(mail);

                error.ForeColor = Color.Green;
                error.Text = "Message has been successfully Sent!";
                Response.AddHeader("REFRESH", "2;URL= adminUserMessages.aspx");

                //once everything is done hide completed form and reveal hidden form
                //regFormDiv.Visible = false;
                //completedForm.Visible = true;

                //}
                //catch (Exception exs1)
                //{
                //    error.ForeColor = Color.Red;
                //    error.Text = " Email was not sent.";
                //}
            }
        
        }


        } 
}