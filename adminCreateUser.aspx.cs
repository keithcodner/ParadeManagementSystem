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

public partial class adminCreateUser : System.Web.UI.Page
{

    static string hash;
    static string doesNameExist ;
    static string getParadeIDForUSER;
    static string getValidCode;

    //email data - admin 
    static string userSubject;
    static string userBody;
    static string userFooter;

    //email data
    static string adminFromAddress;
    static string hostAddress;
    static string emailUsername;
    static string emailPassword;
    static string emailPort;
    static bool checkIfEmailSent = false;



    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        test.Visible = false;
        String year = DateTime.Now.Year.ToString();
        String month = DateTime.Now.Month.ToString();
        String day = DateTime.Now.Day.ToString();
        String hour = DateTime.Now.Hour.ToString();
        String min = DateTime.Now.Minute.ToString();
        String sec = DateTime.Now.Second.ToString();
        String fullDate = year + "-" + month + "-" + day;
        String fullTime = hour + ":" + min + ":" + sec;
        test.Text = fullDate + " " + fullTime;

        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSession"].ToString();
        }

        /////////////////////////Changes fields depending if user is vol or part////////////////////////////

        if (eAccountType.SelectedValue.ToString().Equals("Participant"))
        {
            OrgName.Visible = true;
            OrgLabel.Visible = true;
           // RFVORganizaitonName.Enabled = true;
        }
        else
        {
            OrgName.Visible = false;
            OrgLabel.Visible = false;
            //RFVORganizaitonName.Enabled = false;
        }

        //get the user parade ID for the current parade
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT IDs FROM pageconfig WHERE configID = 10;");
            cmd.Connection = con;
            getParadeIDForUSER = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Parade must be created First. And/Or a Current Parade Must be selected.");
        }


        ///////////////////Receiving waiver from database////////////////////
        rePassValid.Visible = false;



        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 7;");
            cmd.Connection = con;
            rePassValid.Text = (cmd.ExecuteScalar().ToString());
            con.Close();  con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT wWaiver FROM waiver WHERE wName = '" + rePassValid.Text + "';");
            cmd.Connection = con;
            waiverEditBody.Text = (cmd.ExecuteScalar().ToString());
            con.Close();  con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("A Waiver should be added/created before you create a user.");
        }


        //////////////////////////////get the email sections////////////////////////////////

        //get the first Subject : userSubject
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT subjectOne FROM generalEmail WHERE generalEmailID = 1;");
            cmd.Connection = con;
            userSubject = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }

        //get the first body : userBody
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT bodyOne FROM generalEmail WHERE generalEmailID = 1;");
            cmd.Connection = con;
            userBody = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }

        //get the first footer : userFooter
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT footerOne FROM generalEmail WHERE generalEmailID = 1;");
            cmd.Connection = con;
            userFooter = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
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

            Response.Write("Some of the fields are empty.");
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

            Response.Write("Some of the fields are empty.");
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

            Response.Write("Some of the fields are empty.");
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

            Response.Write("Some of the fields are empty.");
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

            Response.Write("Some of the fields are empty.");
        }

        //disable check box
        checkBoxAgree.Visible = false;
        checkBoxAgree.Enabled = false;
    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        validateFirstName.Enabled = false;
        /*for activity log*/ try{/*get date and time*/String years = DateTime.Now.Year.ToString();String months = DateTime.Now.Month.ToString();String days = DateTime.Now.Day.ToString();String hours = DateTime.Now.Hour.ToString();String mins = DateTime.Now.Minute.ToString();String secs = DateTime.Now.Second.ToString();String fullDate = years + "-" + months + "-" + days;String fullTime = hours + ":" + mins + ":" + secs;MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);con.Open();MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has signed out.' );");cmd.Connection = con;MySqlDataReader reader3 = cmd.ExecuteReader();con.Close(); con.Dispose();}catch (Exception ex){}Session.Remove("userSession");
        if (Session["userSession"] == null)
        {
            
            Response.Redirect("adminlogin.aspx", true);
        }

    }
    protected void createUserSubmit_Click(object sender, EventArgs e)
    {

       

        //Check if the user Name exists already
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "checkUserName";
            MySqlParameter p1 = new MySqlParameter("chckUName", eUsername.Text);
            
            //MySqlParameter p3 = new MySqlParameter("ofTypeAdmin", p);
            cmd.Parameters.Add(p1);
            

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows && eUsername.Text != null)
            {

                doesNameExist = "Yes";

            }
            else
            {
                doesNameExist = "No";
            }
            reader.Close();
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            
        }

        if (doesNameExist == "No")
        {
            


            //if (checkBoxAgree.Checked )
            //{
                //get  the validator code
                emailValidationString createEmailValidatorCode = new emailValidationString();
                getValidCode = createEmailValidatorCode.makeAString(10, false);

                //Sending email - if email fails to send, data will not be entered into the database
                try
                {

                    MailMessage mail = new MailMessage(adminFromAddress.ToString(), eEmail.Text, userSubject, "Hello" + " " + eFirstName.Text + " " + eLastName.Text + "," + "\r\n" + "\r\n" + userBody + getValidCode + "\r\n" + "\r\n" + "Username : " + eUsername.Text + "\r\n" + "Password : " + ePassword.Text + "\r\n" + "\r\n" + userFooter);
                    SmtpClient client = new SmtpClient(hostAddress.ToString());
                    client.Port = int.Parse(emailPort);
                    client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                    client.EnableSsl = true;
                    client.Send(mail);
                    //Response.Write("Email has been successfully Sent!");

                    //once everything is done hide completed form and reveal hidden form
                    //regFormDiv.Visible = false;
                    //completedForm.Visible = true;

                    //FirstNameRegexDiv.Visible = false;
                    checkIfEmailSent = true;

                }
                catch (Exception exs1)
                {

                    Response.Write(" Email was not sent due to server error.Please try again at a later time.");
                }

                if (checkIfEmailSent == true)
                {

                    //hasing password before being entered into the database
                    hash = FormsAuthentication.HashPasswordForStoringInConfigFile(ePassword.Text + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");
                    //ePassword.Text = hash;
                    // eLastName.Text

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
                        MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has created a user with the username [" + eUsername.Text + "].' );");
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
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "adminInsertUser";
                        MySqlParameter p1 = new MySqlParameter("eFirstName", eFirstName.Text);
                        MySqlParameter p2 = new MySqlParameter("eLastName", eLastName.Text);
                        MySqlParameter p3 = new MySqlParameter("eUsername", eUsername.Text);
                        MySqlParameter p4 = new MySqlParameter("ePassword", hash.ToString());
                        MySqlParameter p5 = new MySqlParameter("eHomeNumber", eHomeNumber.Text);
                        MySqlParameter p6 = new MySqlParameter("eBusinessNumber", eBusinessNumber.Text);
                        MySqlParameter p7 = new MySqlParameter("eEmail", eEmail.Text);
                        MySqlParameter p8 = new MySqlParameter("eAccountType", eAccountType.Text);
                        MySqlParameter p9 = new MySqlParameter("eDateJoined", test.Text);
                        MySqlParameter p10 = new MySqlParameter("eParadeID", getParadeIDForUSER.ToString());
                        MySqlParameter p11 = new MySqlParameter("validEmail", getValidCode.ToString());
                        MySqlParameter p12 = new MySqlParameter("eOrgName", OrgName.Text);
                        MySqlParameter p13 = new MySqlParameter("eStreet", eeStreet.Text);
                        MySqlParameter p14 = new MySqlParameter("eCity", eeCity.Text);
                        MySqlParameter p15 = new MySqlParameter("ePostal", eePost.Text);
                        MySqlParameter p16 = new MySqlParameter("eProv", eeProv.SelectedValue.ToString());
                        //MySqlParameter p3 = new MySqlParameter("ofTypeAdmin", p);
                        cmd.Parameters.Add(p1);
                        cmd.Parameters.Add(p2);
                        cmd.Parameters.Add(p3);
                        cmd.Parameters.Add(p4);
                        cmd.Parameters.Add(p5);
                        cmd.Parameters.Add(p6);
                        cmd.Parameters.Add(p7);
                        cmd.Parameters.Add(p8);
                        cmd.Parameters.Add(p9);
                        cmd.Parameters.Add(p10);
                        cmd.Parameters.Add(p11);
                        cmd.Parameters.Add(p12);
                        cmd.Parameters.Add(p13);
                        cmd.Parameters.Add(p14);
                        cmd.Parameters.Add(p15);
                        cmd.Parameters.Add(p16);
                        MySqlDataReader reader = cmd.ExecuteReader();
                        Response.Redirect("adminArea.aspx", true);

                        Label1.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        rePassValid.Text.Equals(ex);
                        Response.Write("A parade MUST be created before creating a user!");

                    }

                }
                
            //}
            //else
            //{
            //    Label1.Visible = true;

            //}
        }
        else if(doesNameExist == "Yes")
        {
            UserNameExists.Text = "This username already exits, please choose another.";
        }
            
        // rePassValid.Text = "button pressed";
    }
}