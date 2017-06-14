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
using System.Net.Mail;
using System.Drawing;

public partial class adminEmail : System.Web.UI.Page
{
    static string emailPasswordString;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session load
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSession"].ToString();
        }
        //disable update buttons
        updateEmail.Enabled = false;

        //Text field validation
        emailTestTxt.Attributes.Add("onkeypress", "javascript:return emailTestTxt(event);");
        emailPort.Attributes.Add("onkeypress", "javascript:return emailPort(event);");
        hostAddress.Attributes.Add("onkeypress", "javascript:return hostAddress(event);");
        
        
        //get email password
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT userpass FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            emailPasswordString = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }

       ////////////////////////////////the different tabs///////////////////////////////////////
        //admin tab
        if (!IsPostBack)
        {
            //admin tab

            //get the admin from address
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT fromaddress FROM email WHERE emailID = 1;");
                cmd.Connection = con;
                adminFromAddress.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get activation subject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activesubject FROM email WHERE emailID = 1;");
                cmd.Connection = con;
                activationSubject.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

            //get inactivation subject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivesubject FROM email WHERE emailID = 1;");
                cmd.Connection = con;
                inActivationSubject.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get activation body
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activebody FROM email WHERE emailID = 1;");
                cmd.Connection = con;
                ActivationBody.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get inactivation body
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivebody FROM email WHERE emailID = 1;");
                cmd.Connection = con;
                inActivationBody.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get activation footer
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activefooter FROM email WHERE emailID = 1;");
                cmd.Connection = con;
                ActivationFooter.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get inactivation footer
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivefooter FROM email WHERE emailID = 1;");
                cmd.Connection = con;
                inActivationFooter.Text = (cmd.ExecuteScalar().ToString());
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
                hostAddress.Text = (cmd.ExecuteScalar().ToString());
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
                emailUsername.Text = (cmd.ExecuteScalar().ToString());
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
                emailPassword.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //email port
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT port FROM email WHERE emailID = 6;");
                cmd.Connection = con;
                emailPort.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

        }

        //participant tab
        if (!IsPostBack)
        {

            
            //get activation subject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activesubject FROM email WHERE emailID = 2;");
                cmd.Connection = con;
                partActiveSubject.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

            //get inactivation subject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivesubject FROM email WHERE emailID = 2;");
                cmd.Connection = con;
                partInactiveSubject.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get activation body
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activebody FROM email WHERE emailID = 2;");
                cmd.Connection = con;
                partActiveBody.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get inactivation body
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivebody FROM email WHERE emailID = 2;");
                cmd.Connection = con;
                partInactiveBody.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get activation footer
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activefooter FROM email WHERE emailID = 2;");
                cmd.Connection = con;
                partActiveFooter.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

            //get inactive footer
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivefooter FROM email WHERE emailID = 2;");
                cmd.Connection = con;
                partInactiveFooter.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }


        }

        //volunteer tab
        if (!IsPostBack)
        {


            //get activation subject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activesubject FROM email WHERE emailID = 3;");
                cmd.Connection = con;
                volActiveSubject.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

            //get inactivation subject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivesubject FROM email WHERE emailID = 3;");
                cmd.Connection = con;
                volInActiveSubject.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get activation body
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activebody FROM email WHERE emailID = 3;");
                cmd.Connection = con;
                volActiveBody.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get inactivation body
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivebody FROM email WHERE emailID = 3;");
                cmd.Connection = con;
                volInActiveBody.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get activation footer
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activefooter FROM email WHERE emailID = 3;");
                cmd.Connection = con;
                volActivefooter.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

            //get inactive footer
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivefooter FROM email WHERE emailID = 3;");
                cmd.Connection = con;
                volInActiveFooter.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }


        }

        //organization tab
        if (!IsPostBack)
        {


            //get activation subject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activesubject FROM email WHERE emailID = 4;");
                cmd.Connection = con;
                orgActivationSubject.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

            //get inactivation subject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivesubject FROM email WHERE emailID = 4;");
                cmd.Connection = con;
                orgInActivationSubject.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get activation body
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activebody FROM email WHERE emailID = 4;");
                cmd.Connection = con;
                orgActivationBody.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get inactivation body
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivebody FROM email WHERE emailID = 4;");
                cmd.Connection = con;
                orgInActivationBody.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get activation footer
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activefooter FROM email WHERE emailID = 4;");
                cmd.Connection = con;
                orgActivationFooter.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

            //get inactive footer
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivefooter FROM email WHERE emailID = 4;");
                cmd.Connection = con;
                orgInActivationFooter.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
        }

        ////float tab
        if (!IsPostBack)
        {


            //get activation subject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activesubject FROM email WHERE emailID = 5;");
                cmd.Connection = con;
                floatActiveSubject.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

            //get inactivation subject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivesubject FROM email WHERE emailID = 5;");
                cmd.Connection = con;
                floatInActivesSubject.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get activation body
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activebody FROM email WHERE emailID = 5;");
                cmd.Connection = con;
                floatActiveBody.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get inactivation body
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivebody FROM email WHERE emailID = 5;");
                cmd.Connection = con;
                floatInActiveBody.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get activation footer
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activefooter FROM email WHERE emailID = 5;");
                cmd.Connection = con;
                floatActiveFooter.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

            //get inactive footer
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT inactivefooter FROM email WHERE emailID = 5;");
                cmd.Connection = con;
                floatInActiveFooter.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
        }

        //user, org, float creation email
        
        if (!IsPostBack)
        {

            //get the first Subject : userSubject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT subjectOne FROM generalEmail WHERE generalEmailID = 1;");
                cmd.Connection = con;
                userSubject.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get the second subject : orgSubject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT subjectTwo FROM generalEmail WHERE generalEmailID = 1;");
                cmd.Connection = con;
                orgSubject.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

            //get the third subject : floatSubject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT subjectThree FROM generalEmail WHERE generalEmailID = 1;");
                cmd.Connection = con;
                floatSubject.Text = (cmd.ExecuteScalar().ToString());
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
                userBody.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            //get the second body : orgBody
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT bodyTwo FROM generalEmail WHERE generalEmailID = 1;");
                cmd.Connection = con;
                orgBody.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

            //get the third body : floatBody
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT bodyThree FROM generalEmail WHERE generalEmailID = 1;");
                cmd.Connection = con;
                floatBody.Text = (cmd.ExecuteScalar().ToString());
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
                userFooter.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

            //get the second footer : orgFooter
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT footerTwo FROM generalEmail WHERE generalEmailID = 1;");
                cmd.Connection = con;
                orgFooter.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

            //get the third footer : floatFooter
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT footerThree FROM generalEmail WHERE generalEmailID = 1;");
                cmd.Connection = con;
                floatFooter.Text = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }
            
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
    protected void editEmail_Click(object sender, EventArgs e)
    {
        //toggle update and edit
        updateEmail.Enabled = true;
        editEmail.Enabled = false;

        //enabling text editing
        adminFromAddress.ReadOnly = false;
        emailPort.ReadOnly = false;
        activationSubject.ReadOnly = false;
        inActivationSubject.ReadOnly = false;
        ActivationBody.ReadOnly = false;
        inActivationBody.ReadOnly = false;
        ActivationFooter.ReadOnly = false;
        inActivationFooter.ReadOnly = false;
        hostAddress.ReadOnly = false;
        emailUsername.ReadOnly = false;
        emailPassword.ReadOnly = false;

      
    }
    protected void updateEmail_Click(object sender, EventArgs e)
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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has updated Admin Activation Email settings.' );");
            cmd1.Connection = con1;
            MySqlDataReader reader3 = cmd1.ExecuteReader();
            con1.Close(); con1.Dispose();
        }
        catch (Exception ex)
        {


        }

        //toggle update and edit
        editEmail.Enabled = true;
        updateEmail.Enabled = false;

        
        adminFromAddress.ReadOnly = true;
        activationSubject.ReadOnly = true;
        inActivationSubject.ReadOnly = true;
        ActivationBody.ReadOnly = true;
        inActivationBody.ReadOnly = true;
        ActivationFooter.ReadOnly = true;
        inActivationFooter.ReadOnly = true;
        hostAddress.ReadOnly = true;
        emailUsername.ReadOnly = true;
        emailPassword.ReadOnly = true;
        emailPort.ReadOnly = true;

        try
        {
       
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE email SET fromaddress='" + adminFromAddress.Text + "',  activesubject='" + activationSubject.Text.Replace("'", "''") + "',  inactivesubject='" + inActivationSubject.Text.Replace("'", "''") + "',  activebody='" + ActivationBody.Text.Replace("'", "''") + "',  inactivebody='" + inActivationBody.Text.Replace("'", "''") + "' ,  activefooter='" + ActivationFooter.Text.Replace("'", "''") + "' ,  inactivefooter='" + inActivationFooter.Text.Replace("'", "''") + "' WHERE emailID = 1 ");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();

        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //update host and credentials 
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE email  SET smtphost='" + hostAddress.Text + "' ,  useremail='" + emailUsername.Text + "' ,  userpass='" + emailPassword.Text + "',  port='" + emailPort.Text + "'   WHERE emailID = 6;");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();

        }
        catch (Exception ex)
        {

            Response.Write("");
        }
       
    }
    protected void partEditBtn_Click(object sender, EventArgs e)
    {
        //toggle update and edit
        partUpdateBtn.Enabled = true;
        partEditBtn.Enabled = false;

        //enabling text editing
        partActiveSubject.ReadOnly = false;
        partInactiveSubject.ReadOnly = false;
        partActiveBody.ReadOnly = false;
        partInactiveBody.ReadOnly = false;
        partActiveFooter.ReadOnly = false;
        partInactiveFooter.ReadOnly = false;
       

    }
    protected void partUpdateBtn_Click(object sender, EventArgs e)
    {
        //toggle update and edit
        partUpdateBtn.Enabled = false;
        partEditBtn.Enabled = true;

        //disabling text editing
        partActiveSubject.ReadOnly = true;
        partInactiveSubject.ReadOnly = true;
        partActiveBody.ReadOnly = true;
        partInactiveBody.ReadOnly = true;
        partActiveFooter.ReadOnly = true;
        partInactiveFooter.ReadOnly = true;

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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has updated Participant Activation Email settings.' );");
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
            MySqlCommand cmd = new MySqlCommand("UPDATE email SET activesubject='" + partActiveSubject.Text.Replace("'", "''") + "',  inactivesubject='" + partInactiveSubject.Text.Replace("'", "''") + "',  activebody='" + partActiveBody.Text.Replace("'", "''") + "',  inactivebody='" + partInactiveBody.Text.Replace("'", "''") + "' ,  activefooter='" + partActiveFooter.Text.Replace("'", "''") + "' ,  inactivefooter='" + partInactiveFooter.Text.Replace("'", "''") + "' WHERE emailID = 2 ");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();

        }
        catch (Exception ex)
        {

            Response.Write("");
        }


    }
    protected void volEdit_Click(object sender, EventArgs e)
    {
        //toggle update and edit
        volEdit.Enabled = false;
        volUpdate.Enabled = true;

        //Disabled Readonly
        volActiveSubject.ReadOnly = false;
        volInActiveSubject.ReadOnly = false;
        volActiveBody.ReadOnly = false;
        volInActiveBody.ReadOnly = false;
        volActivefooter.ReadOnly = false;
        volInActiveFooter.ReadOnly = false;


    }
    protected void volUpdate_Click(object sender, EventArgs e)
    {
        //reverse toggle update and edit
        volEdit.Enabled = true;
        volUpdate.Enabled = false;

        //Enable Readonly
        volActiveSubject.ReadOnly = true;
        volInActiveSubject.ReadOnly = true;
        volActiveBody.ReadOnly = true;
        volInActiveBody.ReadOnly = true;
        volActivefooter.ReadOnly = true;
        volInActiveFooter.ReadOnly = true;

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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has updated Volunteer Activation Email settings.' );");
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
            MySqlCommand cmd = new MySqlCommand("UPDATE email SET activesubject='" + volActiveSubject.Text.Replace("'", "''") + "',  inactivesubject='" + volInActiveSubject.Text.Replace("'", "''") + "',  activebody='" + volActiveBody.Text.Replace("'", "''") + "',  inactivebody='" + volInActiveBody.Text.Replace("'", "''") + "' ,  activefooter='" + volActivefooter.Text.Replace("'", "''") + "' ,  inactivefooter='" + volInActiveFooter.Text.Replace("'", "''") + "' WHERE emailID = 3 ");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();

        }
        catch (Exception ex)
        {

            Response.Write("");
        }

    }
    protected void orgEdit_Click(object sender, EventArgs e)
    {
        //toggle update and edit
        orgEdit.Enabled = false;
        orgupdate.Enabled = true;

        //Disabled Readonly
        orgActivationSubject.ReadOnly = false;
        orgInActivationSubject.ReadOnly = false;
        orgActivationBody.ReadOnly = false;
        orgInActivationBody.ReadOnly = false;
        orgActivationFooter.ReadOnly = false;
        orgInActivationFooter.ReadOnly = false;

    }
    protected void orgupdate_Click(object sender, EventArgs e)
    {
        //reverse toggle update and edit
        orgEdit.Enabled = true;
        orgupdate.Enabled = false;

        //Enable Readonly
        orgActivationSubject.ReadOnly = true;
        orgInActivationSubject.ReadOnly = true;
        orgActivationBody.ReadOnly = true;
        orgInActivationBody.ReadOnly = true;
        orgActivationFooter.ReadOnly = true;
        orgInActivationFooter.ReadOnly = true;

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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has updated Organization Activation Email settings.' );");
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
            MySqlCommand cmd = new MySqlCommand("UPDATE email SET activesubject='" + orgActivationSubject.Text.Replace("'", "''") + "',  inactivesubject='" + orgInActivationSubject.Text.Replace("'", "''") + "',  activebody='" + orgActivationBody.Text.Replace("'", "''") + "',  inactivebody='" + orgInActivationBody.Text.Replace("'", "''") + "' ,  activefooter='" + orgActivationFooter.Text.Replace("'", "''") + "' ,  inactivefooter='" + orgInActivationFooter.Text.Replace("'", "''") + "' WHERE emailID = 4 ");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();

        }
        catch (Exception ex)
        {

            Response.Write("");
        }
    }
    protected void floatEdit_Click(object sender, EventArgs e)
    {
        //toggle update and edit
        floatEdit.Enabled = false;
        floatUpdate.Enabled = true;

        //Disabled Readonly
        floatActiveSubject.ReadOnly = false;
        floatInActivesSubject.ReadOnly = false;
        floatActiveBody.ReadOnly = false;
        floatInActiveBody.ReadOnly = false;
        floatActiveFooter.ReadOnly = false;
        floatInActiveFooter.ReadOnly = false;
    }
    protected void floatUpdate_Click(object sender, EventArgs e)
    {
        //reverse toggle update and edit
        floatEdit.Enabled = true;
        floatUpdate.Enabled = false;

        //Enable Readonly
        floatActiveSubject.ReadOnly = true;
        floatInActivesSubject.ReadOnly = true;
        floatActiveBody.ReadOnly = true;
        floatInActiveBody.ReadOnly = true;
        floatActiveFooter.ReadOnly = true;
        floatInActiveFooter.ReadOnly = true;

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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has updated Float Approval Email settings.' );");
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
            MySqlCommand cmd = new MySqlCommand("UPDATE email SET activesubject='" + floatActiveSubject.Text.Replace("'", "''") + "',  inactivesubject='" + floatInActivesSubject.Text.Replace("'", "''") + "',  activebody='" + floatActiveBody.Text.Replace("'", "''") + "',  inactivebody='" + floatInActiveBody.Text.Replace("'", "''") + "' ,  activefooter='" + floatActiveFooter.Text.Replace("'", "''") + "' ,  inactivefooter='" + floatInActiveFooter.Text.Replace("'", "''") + "' WHERE emailID = 5 ");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();

        }
        catch (Exception ex)
        {

            Response.Write("");
        }
    }
    protected void createEdit_Click(object sender, EventArgs e)
    {
        //toggle update and edit
        createEdit.Enabled = false;
        createUpdate.Enabled = true;

        //Disabled Readonly
        userSubject.ReadOnly = false;
        orgSubject.ReadOnly = false;
        userBody.ReadOnly = false;
        orgBody.ReadOnly = false;
        floatBody.ReadOnly = false;
        userFooter.ReadOnly = false;
        orgFooter.ReadOnly = false;
        floatFooter.ReadOnly = false;
        floatSubject.ReadOnly = false;
    }
    protected void createUpdate_Click(object sender, EventArgs e)
    {
        //reverse toggle update and edit
         createEdit.Enabled = true;
        createUpdate.Enabled = false;

        //Enable Readonly
        userSubject.ReadOnly = true;
        orgSubject.ReadOnly = true;
        floatSubject.ReadOnly = true;
        userBody.ReadOnly = true;
        orgBody.ReadOnly = true;
        floatBody.ReadOnly = true;
        userFooter.ReadOnly = true;
        orgFooter.ReadOnly = true;
        floatFooter.ReadOnly = true;

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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has updated Account Creation Email settings.' );");
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
            MySqlCommand cmd = new MySqlCommand("UPDATE generalEmail SET subjectOne='" + userSubject.Text.Replace("'", "''") + "',  subjectTwo='" + orgSubject.Text.Replace("'", "''") + "',  subjectThree ='" + floatSubject.Text.Replace("'", "''") + "',  bodyOne='" + userBody.Text.Replace("'", "''") + "' ,  bodyTwo='" + orgBody.Text.Replace("'", "''") + "' ,  bodyThree='" + floatBody.Text.Replace("'", "''") + "',  footerOne ='" + userFooter.Text.Replace("'", "''") + "' ,  footerTwo ='" + orgFooter.Text.Replace("'", "''") + "',  footerThree ='" + floatFooter.Text.Replace("'", "''") + "'   WHERE generalEmailID = 1 ");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();

        }
        catch (Exception ex)
        {

            Response.Write("");
        }
    }
    protected void testEmailSettings_Click(object sender, EventArgs e)
    {

        if (emailTestTxt.ToString() == null || emailTestTxt.ToString() == "")
        {
            checkIfEmailWasSent.ForeColor = Color.Red;
            checkIfEmailWasSent.Text = "Please put an email address to test.";
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

                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has tested Admin Activation Email settings.' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {


            }

            try
            {

                MailMessage mail = new MailMessage(adminFromAddress.Text, emailTestTxt.Text, "This is a test from the BBOT Parade Management System", "This email is a test. If you have recieved it then your settings are correct.");
                SmtpClient client = new SmtpClient(hostAddress.Text);
                client.Port = int.Parse(emailPort.Text);
                client.Credentials = new System.Net.NetworkCredential(emailUsername.Text, emailPasswordString.ToString());
                client.EnableSsl = true;
                client.Send(mail);
                //Response.Write("Email has been successfully Sent!");

                checkIfEmailWasSent.ForeColor = Color.Green;
                checkIfEmailWasSent.Text = "Email was successfully sent. Please check your inbox.";
            }
            catch (Exception exs1)
            {
                checkIfEmailWasSent.ForeColor = Color.Red;
                checkIfEmailWasSent.Text = "Email was not sent. Please look over your settings.";
                //Response.Write(exs1);
            }
        }
    }
}