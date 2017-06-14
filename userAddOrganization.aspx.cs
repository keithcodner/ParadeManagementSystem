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

public partial class userAddOrganization : System.Web.UI.Page
{
    public string getParadeName;
    public string getContactID;
    public string gotContact;
    static string gotParadeID;
    static string getUserIDToInsertToFloatTable;
    static string hash;

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

    public string uFirstName;
    public string uLastName;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session for loggin
        if (Session["userSessionU"] == null)
        {
            Response.Redirect("userLogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSessionU"].ToString();
        }

        //session to make sure the user has an active redirection
        if (Session["createOrgSession"] != "true")
        {
            Response.Redirect("userHomeLogin.aspx");
        }
        else
        {
            Session["createOrgSession"] = "true";
        }

        //--------get the parade name from page config-----------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 10;");
            cmd.Connection = con;
            getParadeName = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //select only this user for the contact name
        hash = FormsAuthentication.HashPasswordForStoringInConfigFile(Session["userSessionPWU"].ToString() + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");

      

        //get the time
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

       

        ///////////////////Receiving waiver from database////////////////////
        rePassValid.Visible = false;
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 7;");
            cmd.Connection = con;
            rePassValid.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT IDs FROM pageconfig WHERE configID = 10;");
            cmd.Connection = con;
            gotParadeID = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
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
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("A Waiver should be added/created before you create an organization.");
        }

        //get the contact only for this user
        SqlDataSource2.SelectCommand = "SELECT uID, concat (ufname,' ', ulname) FROM user WHERE uStatus = 'Participant' AND uUsername = '" + Session["userSessionU"].ToString() + "' AND uPassword = '" + hash + "'; ";

        SqlDataSource1.SelectCommand = "SELECT uID, uOrgName FROM user WHERE uStatus = 'Participant' AND uUsername = '" + Session["userSessionU"].ToString() + "' AND uPassword = '" + hash + "'; ";


        ////////////////////////////////PREPARING THE EMAIL////////////////////////////////////////////////
        //get first name and last name

        //get user ID
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uID FROM user WHERE uStatus = 'Participant' AND uUsername = '" + Session["userSessionU"].ToString() + "' AND uPassword = '" + hash + "'; ");
            cmd.Connection = con;
            getUserIDToInsertToFloatTable = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }
         
        //first name
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uStatus = 'Participant' AND uUsername = '" + Session["userSessionU"].ToString() + "' AND uPassword = '" + hash + "'; ");
            cmd.Connection = con;
            uFirstName = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }

        //last name
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uStatus = 'Participant' AND uUsername = '" + Session["userSessionU"].ToString() + "' AND uPassword = '" + hash + "'; ");
            cmd.Connection = con;
            uLastName = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }



        //////////////////////////////get the email sections////////////////////////////////
        
        //get the first Subject : userSubject
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT subjectTwo FROM generalEmail WHERE generalEmailID = 1;");
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
            MySqlCommand cmd = new MySqlCommand("SELECT bodyTwo FROM generalEmail WHERE generalEmailID = 1;");
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
            MySqlCommand cmd = new MySqlCommand("SELECT footerTwo FROM generalEmail WHERE generalEmailID = 1;");
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
    
    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/try {/*get date and time*/String years = DateTime.Now.Year.ToString(); String months = DateTime.Now.Month.ToString(); String days = DateTime.Now.Day.ToString(); String hours = DateTime.Now.Hour.ToString(); String mins = DateTime.Now.Minute.ToString(); String secs = DateTime.Now.Second.ToString(); String fullDate = years + "-" + months + "-" + days; String fullTime = hours + ":" + mins + ":" + secs; MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString); con.Open(); MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSessionU"].ToString() + "','User : " + Session["userSessionU"].ToString() + " has signed out.' );"); cmd.Connection = con; MySqlDataReader reader3 = cmd.ExecuteReader(); con.Close(); con.Dispose(); }catch (Exception ex) { } Session.Remove("userSessionU"); Session.Remove("userSessionU");
        Session.Remove("createOrgSession");
        if (Session["userSessionU"] == null)
        {
            Response.Redirect("userLogin.aspx", true);
        }

        
        if (Session["createOrgSession"] == null)
        {
            Response.Redirect("userHomeLogin.aspx", true);
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (checkBoxAgree.Checked == true)
        {


            //getContactID = ;
            //////////////////////////////gets contact name from uID////////////////////////////
            try
            {

                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT concat (ufname,' ', ulname) FROM user WHERE uID = '" + eContact.Text + "'");
                cmd1.Connection = con1;
                rePassValid.Text = (cmd1.ExecuteScalar().ToString());
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //////////////////////////////gets org name from uorgname id////////////////////////////
            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT uOrgName FROM user WHERE uID = '" + eOrganizaiton.Text + "'");
                cmd1.Connection = con1;
                getUOrgName.Text = (cmd1.ExecuteScalar().ToString());
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            ///////////////////////////////////////////////////////////////////////////////////
            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 10 ");
                cmd1.Connection = con1;
                gotParadeID = (cmd1.ExecuteScalar().ToString());
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }
            ////////////////////////////////////////////////////////////////////////////
            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT paradeID FROM parade WHERE paradeName = '" + gotParadeID.ToString() + "' ");
                cmd1.Connection = con1;
                getParadeID.Text = (cmd1.ExecuteScalar().ToString());
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("There are no Parades, You need to make a parade and/or user before you can add an organization.");
            }

            /////////////////////////////////////////////////////////////////////////
            if (checkBoxAgree.Checked)
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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDates + "','" + fullTimes + "','" + Session["userSessionU"].ToString() + "','User: " + Session["userSessionU"].ToString() + " has created a new organization.' );");
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
                    cmd.CommandText = "InsertOrganization";
                    MySqlParameter p1 = new MySqlParameter("eOrganization", getUOrgName.Text);
                    MySqlParameter p2 = new MySqlParameter("eAddress1", eAddress1.Text);
                    MySqlParameter p3 = new MySqlParameter("eCity", eCity.Text);
                    MySqlParameter p4 = new MySqlParameter("eProvince", eProvince.Text);
                    MySqlParameter p5 = new MySqlParameter("eCountry", eCountry.Text);
                    MySqlParameter p6 = new MySqlParameter("ePostal", ePostal.Text);
                    MySqlParameter p7 = new MySqlParameter("eContact", rePassValid.Text);
                    MySqlParameter p8 = new MySqlParameter("ePhone", ePhone.Text);
                    MySqlParameter p9 = new MySqlParameter("eEmail", eEmail.Text);
                    MySqlParameter p10 = new MySqlParameter("eWebsite", eWeb.Text);
                    MySqlParameter p11 = new MySqlParameter("eDJ", test.Text);
                    MySqlParameter p12 = new MySqlParameter("eConID", eContact.Text);
                    MySqlParameter p13 = new MySqlParameter("eParID", getParadeID.Text);
                    cmd.Parameters.Add(p12);
                    cmd.Parameters.Add(p13);
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

                    MySqlDataReader reader = cmd.ExecuteReader();
                    reader.Close();
                    con.Close(); con.Dispose();



                }
                catch (Exception ex)
                {
                    rePassValid.Text = ex.ToString();
                }

                /////////Set the max id to be inserted into the float table//////// 


                try
                {
                     
                    MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con1.Open();
                    MySqlCommand cmd1 = new MySqlCommand("SELECT MAX(pOrgID) FROM orginfo;");
                    cmd1.Connection = con1;
                    maxID.Text = (cmd1.ExecuteScalar().ToString());
                    con1.Close(); con1.Dispose();
                }
                catch (Exception ex)
                {

                    Response.Write("");
                }
                //------------------get contect and store in string---------------------------------------
                try
                {
                     
                    MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con1.Open();
                    MySqlCommand cmd1 = new MySqlCommand("SELECT oContact FROM orginfo WHERE porgid = (SELECT MAX(porgid) FROM orginfo)");
                    cmd1.Connection = con1;
                    maxContactID.Text = (cmd1.ExecuteScalar().ToString());
                    con1.Close(); con1.Dispose();
                }
                catch (Exception ex)
                {

                    Response.Write("");
                }
                //-------------------insert into the floatdetails table-------------------------
                try
                {
                     
                    MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con1.Open();
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO floatdetails(porgid, uid, contact, paradeID, parade, amount) VALUES ('" + maxID.Text + "', '" + getUserIDToInsertToFloatTable + "' ,'" + maxContactID.Text + "', '" + getParadeID.Text + "','" + getParadeName + "', 0);");
                    cmd1.Connection = con1;
                    MySqlDataReader reader1 = cmd1.ExecuteReader();
                    reader1.Close();
                    con1.Close(); con1.Dispose();
                }
                catch (Exception ex)
                {

                    Response.Write("");
                }
                rePassValid.Visible = true;
                rePassValid.Text = gotContact;
                //Response.Redirect("viewParadeInfo.aspx", true);
            }
            else
            {
                Label1.Visible = true;
            }

            ///////////////////////////////////Sending email/////////////////////////////////////////////
            try
            {

                MailMessage mail = new MailMessage(adminFromAddress.ToString(), eEmail.Text, userSubject, "Hello" + " " + uFirstName.ToString() + " " + uLastName.ToString() + "," + "\r\n" + "\r\n" + userBody + "\r\n" + "\r\n" + userFooter);
                SmtpClient client = new SmtpClient(hostAddress.ToString());
                client.Port = int.Parse(emailPort);
                client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                client.EnableSsl = true;
                client.Send(mail);
                //Response.Write("Email has been successfully Sent!");

                //once everything is done hide completed form and reveal hidden form
                //regFormDiv.Visible = false;
                //completedForm.Visible = true;

            }
            catch (Exception exs1)
            {

                Response.Write(" Email was not sent.");
            }


            //kills session for creating an organization and redirects

            Session.Remove("createOrgSession");
            if (Session["createOrgSession"] == null)
            {
                Response.Redirect("userHomeLogin.aspx", true);
            }

            Label1.Visible = false;
        }
        else 
        {
            Label1.Visible = true;

        }
    }
}