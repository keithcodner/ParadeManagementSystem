using System;
using System.Configuration;
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


public partial class editParadeInfo : System.Web.UI.Page
{
    public static DataTable fullTable;
    static bool update = false;
    static string authNum;
    static string confirmType;
    static string getConfrimCmd;
    static string getSelect;
    static string getParadeName;
    static string getParadeID;

    //Inactivatation/dis-aproval heirarchy
    static string disApproveFloats;


    //active user validation
    static string verifyActiveUser;
    static string getActiveUserID;

    //proper credentials
    static string userID;
    static string getUFName;
    static string getULName;
    static string getEmail;

    //email config variables
    static string fromAddress;
    static string smtpHost;
    static string emailUsername;
    static string emailPassword;
    static string port;

    //Email Variales
    static string orgActivationSubject;
    static string orgInActivationSubject;
    static string orgActivationBody;
    static string orgInActivationBody;
    static string orgActivationFooter;
    static string orgInActivationFooter;
    static string nbsp = "&nbsp;";

    static string uploadPath = "C://ProgramData//1UPSolutionsParadeMS//";
    static string uploadVirtualPath = "1UPSolutionsParadeMS\\";

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

        //see if its a search session from viewsfortoday page
        if (Session["SessionSearchOrg"] == "SessionSearchOrg")
        {
            normalEdit.Visible = true;
            searchBtn.Enabled = false;
            searchTxt.Enabled = false;
        }

        disableConfirm.Visible = false;
        //--------------------tests to see what the getSelect command gets from the database----------------
        //Response.Write(getSelect);
      
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

        //------ gets the select state either global or selective----------------------

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 15;");
            cmd.Connection = con;
            getSelect = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //--------get the parade ID from get ParadeName from the config page -----------------
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT paradeID FROM parade WHERE paradeName = '" + getParadeName + "';");
            cmd.Connection = con;
            getParadeID = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {
            if (getParadeID == null)
            {
                Response.Write("");
            }
            else
            {
                Response.Write("There are no Organizations.");
            }
        }
        

        //------ get  enable/disable confirmations check ----------------------

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 9;");
            cmd.Connection = con;
            getConfrimCmd = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        /*

        searchBtn.Focus();
        if (cbOrganization.Checked)
        {
            searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (uOrganization LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }
        else if (cbContact.Checked)
        {
            searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oContact LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }
        else if (cbWebsite.Checked)
        {
            searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oWebsite LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }

        else if (cbStreet.Checked)
        {
            searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oAddress1 LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }

        else if (cbProv.Checked)
        {
            searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oProvince LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }

        else if (cbPostal.Checked)
        {
            searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oPostal LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }

        else if (cbEmail.Checked)
        {
            searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oEmail LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }

        else if (cbCity.Checked)
        {
            searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oCity LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }
        else
        {
            searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oOrganization LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }


        test.Visible = false; //makes the label below seminar attendence not visible
        //do not remove label as it takes value from dropdownlist and from there updates the value in the database
       
        if (cbOrganization.Checked)
        {
            searchLbl.Text = "Organization";
        }
        else if (cbContact.Checked)
        {
            searchLbl.Text = "Contact";
        }
        else if (cbWebsite.Checked)
        {
            searchLbl.Text = "Website";
        }

        else if (cbStreet.Checked)
        {
            searchLbl.Text = "Street Name";
        }

        else if (cbProv.Checked)
        {
            searchLbl.Text = "Province";
        }

        else if (cbPostal.Checked)
        {
            searchLbl.Text = "Postal/ Zip Code";
        }

        else if (cbEmail.Checked)
        {
            searchLbl.Text = "Email";
        }

        else if (cbCity.Checked)
        {
            searchLbl.Text = "City";
        }


        //GridView1.DataSource = fullTable;
        //GridView1.DataBind();


        //getSelect command will determine which parade is selected or to get all regardless






        */ 
        //----------------------------------------------------------------------------------------------------------------------
        if (getSelect == "Selective")
        {
            editTables.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE paradeID='" + getParadeID + "';";
        }

        if (getSelect == "Global")
        {
            editTables.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo;  ";
        }

        //////////////////////////////////////////get email config variables/////////////////////
        
        //get the from address
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT fromaddress FROM email WHERE emailID = 1;");
            cmd.Connection = con;
            fromAddress = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }

        //get the smtp host

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT smtphost FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            smtpHost = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }

        //get the email username
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


        //get the email password
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
        //get the port
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT port FROM email WHERE emailID = 6;");
            cmd.Connection = con;
            port = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }




        /////////////////////////get email messages from database /////////////////////////////////////    
            //get activation subject
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT activesubject FROM email WHERE emailID = 4;");
                cmd.Connection = con;
                orgActivationSubject = (cmd.ExecuteScalar().ToString());
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
                orgInActivationSubject = (cmd.ExecuteScalar().ToString());
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
                orgActivationBody = (cmd.ExecuteScalar().ToString());
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
                orgInActivationBody = (cmd.ExecuteScalar().ToString());
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
                orgActivationFooter = (cmd.ExecuteScalar().ToString());
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
                orgInActivationFooter = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("Some of the fields are empty.");
            }

        // perform the session search if exists
            if (Session["SessionSearchOrg"] == "SessionSearchOrg")
            {
                searchedTable.SelectCommand = "";

                editTables.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE pOrgID='" + Session["getOrgID"].ToString() + "';";

                //searchBtn_Click(null, null);

                //GridView1.DataBind();
            }

            //Response.Write(Session["getOrgID"].ToString());

    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/ try{/*get date and time*/String years = DateTime.Now.Year.ToString();String months = DateTime.Now.Month.ToString();String days = DateTime.Now.Day.ToString();String hours = DateTime.Now.Hour.ToString();String mins = DateTime.Now.Minute.ToString();String secs = DateTime.Now.Second.ToString();String fullDate = years + "-" + months + "-" + days;String fullTime = hours + ":" + mins + ":" + secs;MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);con.Open();MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has signed out.' );");cmd.Connection = con;MySqlDataReader reader3 = cmd.ExecuteReader();con.Close(); con.Dispose();}catch (Exception ex){}Session.Remove("userSession");
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx", true);
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Delete Command
        string key = e.CommandName;
        if (key == "DeleteUser")
        {

            AlertLbl.Text = "By clicking confirm, you are deleting this organization from the Parade Management System and it cannot be recovered.Float details for this organization will be lost as well. Do you confirm these changes?";
            confirmPanel.Visible = true;
            //  GridView1.Visible = false;
            GridView1.Enabled = false;
            Button1.Enabled = false;
            searchBtn.Enabled = false;
            advSearch.Enabled = false;

            int index = int.Parse(e.CommandArgument.ToString());
            GridView grid = (GridView)e.CommandSource;
            GridViewRow row = grid.Rows[index];

            TableCell tblCell = row.Cells[0];
            authNum = tblCell.Text;


            confirmType = "Delete";
           
            
        }

        //Update Command
        if (key == "UpdateUser")
        {
            confirmType = "Update";
            update = true;
            int index = int.Parse(e.CommandArgument.ToString());
            GridView grid = (GridView)e.CommandSource;
            GridViewRow row = grid.Rows[index];

            TableCell place1 = row.Cells[1];
            eeOrganization.Text = place1.Text.Replace(nbsp, "");

            TableCell place2 = row.Cells[2];
            //DropDownList2.Text = place2.Text;

            //if (place2.Text == DropDownList2.SelectedValue.ToString())
            //{
            DropDownList2.SelectedIndex = DropDownList2.Items.IndexOf
                (DropDownList2.Items.FindByText(place2.Text));
            //}

            TableCell place3 = row.Cells[3];
            eePhone.Text = place3.Text.Replace(nbsp, "");

            TableCell place4 = row.Cells[4];
            eeWebsite.Text = place4.Text.Replace(nbsp, "");

            TableCell place5 = row.Cells[5];
            eEmail.Text = place5.Text.Replace(nbsp, "");

            TableCell place6 = row.Cells[6];
            eeStreet.Text = place6.Text.Replace(nbsp, "");

            //TableCell place7 = row.Cells[9];
            //eeCity.Text = place7.Text;

            TableCell place7 = row.Cells[7];
            eeCity.Text = place7.Text.Replace(nbsp, "");


            TableCell place8 = row.Cells[8];
            eeProv.SelectedIndex = eeProv.Items.IndexOf
                  (eeProv.Items.FindByText(place8.Text));

            TableCell place10 = row.Cells[10];
            if (place10.Text == "Canada")
            {
                DropDownList1.SelectedIndex = 1;
            }
            else if (place10.Text == "United States")
            {
                DropDownList1.SelectedIndex = 2;
            }

            else
            {
                DropDownList1.SelectedIndex = 0;
            }

            TableCell place11 = row.Cells[9];
            eePost.Text = place11.Text;

            TableCell place9 = row.Cells[13];
            //Label1.Text = place9.Text;

            if (place9.Text == "Manditory")
            {
                eeSeminarAtt.SelectedIndex = 1;
            }
            else if (place9.Text == "Optional")
            {
                eeSeminarAtt.SelectedIndex = 2;
            }

            else
            {
                eeSeminarAtt.SelectedIndex = 0;
            }

            TableCell tblCell = row.Cells[0];
            authNum = tblCell.Text;


            
            
           
        }

        //Activate Command
        if (key == "activate")
        {

           

                disableConfirm.Visible = true;
                if (getConfrimCmd == "Enabled")
                {
                    AlertLbl.Text = "By clicking confirm, you are activating this organization account. An confirmation of activation email will be sent to the user. Do you confirm these changes?";
                    confirmPanel.Visible = true;
                    //  GridView1.Visible = false;
                    GridView1.Enabled = false;
                    Button1.Enabled = false;
                    searchBtn.Enabled = false;
                    advSearch.Enabled = false;

                    int index = int.Parse(e.CommandArgument.ToString());
                    GridView grid = (GridView)e.CommandSource;
                    GridViewRow row = grid.Rows[index];

                    TableCell tblCell = row.Cells[0];
                    authNum = tblCell.Text;

                    confirmType = "Activate";
                }
                //if disabled

                if (getConfrimCmd == "Disabled")
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
                        MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has activated an organization with the ID[" + int.Parse(authNum) + "]. ' );");
                        cmd1.Connection = con1;
                        MySqlDataReader reader3 = cmd1.ExecuteReader();
                        con1.Close(); con1.Dispose();
                    }
                    catch (Exception ex)
                    {


                    }


                    //gets the id of the gridview table
                    int index = int.Parse(e.CommandArgument.ToString());
                    GridView grid = (GridView)e.CommandSource;
                    GridViewRow row = grid.Rows[index];

                    TableCell tblCell = row.Cells[0];
                    authNum = tblCell.Text;

                    //get the user id related to the organization
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uid FROM orginfo WHERE porgid = '" + int.Parse(authNum) + "' ;");
                        cmd.Connection = con;
                        getActiveUserID = (cmd.ExecuteScalar().ToString());
                        con.Close(); con.Dispose();
                    }
                    catch (Exception ex)
                    {

                        Response.Write("");
                    }


                    // Check to see if the user related is already activated
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uActivation FROM user WHERE uid = '" + getActiveUserID.ToString() + "' ;");
                        cmd.Connection = con;
                        verifyActiveUser = (cmd.ExecuteScalar().ToString());
                        con.Close(); con.Dispose();
                    }
                    catch (Exception ex)
                    {

                        Response.Write("");
                    }

                    if (verifyActiveUser == "Active")
                    {

                        try
                        {

                            //need this to connect to mysql database from here to
                             
                            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            //get name of stored procedure
                            cmd.CommandText = "activateOrgInfo";
                            //here



                            MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                            cmd.Parameters.Add(p1);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            //Response.Write("<script>alert('Hello');</script>");
                            //Response.Redirect("editOrDeleteUser.aspx");



                            con.Close(); con.Dispose();


                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex);
                        }
                        //
                        // get the user ID
                        try
                        {


                             
                            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand("SELECT uid FROM orginfo WHERE porgid = '" + int.Parse(authNum) + "' ;");
                            cmd.Connection = con;
                            userID = (cmd.ExecuteScalar().ToString());
                            con.Close(); con.Dispose();
                        }
                        catch (Exception ex)
                        {

                            Response.Write("");
                        }

                        //get the first name
                        try
                        {


                             
                            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                            cmd.Connection = con;
                            getUFName = (cmd.ExecuteScalar().ToString());
                            con.Close(); con.Dispose();
                        }
                        catch (Exception ex)
                        {

                            Response.Write("");
                        }

                        //get the last name
                        try
                        {


                             
                            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                            cmd.Connection = con;
                            getULName = (cmd.ExecuteScalar().ToString());
                            con.Close(); con.Dispose();
                        }
                        catch (Exception ex)
                        {

                            Response.Write("");
                        }

                        //get email
                        try
                        {


                             
                            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand("SELECT uEmail FROM user WHERE uID = '" + userID.ToString() + "' ;");
                            cmd.Connection = con;
                            getEmail = (cmd.ExecuteScalar().ToString());
                            con.Close(); con.Dispose();
                        }
                        catch (Exception ex)
                        {

                        }

                        //email the user           
                        try
                        {

                            MailMessage mail = new MailMessage(fromAddress.ToString(), getEmail.ToString(), orgActivationSubject.ToString(), "Hello" + " " + getUFName.ToString() + " " + getULName.ToString() + "," + "\r\n" + "\r\n" + orgActivationBody.ToString() + "\r\n" + "\r\n" + orgActivationFooter.ToString());
                            SmtpClient client = new SmtpClient(smtpHost.ToString());
                            client.Port = int.Parse(port);
                            client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                            client.EnableSsl = true;
                            client.Send(mail);
                            Response.Write("Email has been successfully Sent!");
                            Response.AddHeader("REFRESH", "1;URL= editParadeInfo.aspx");
                        }
                        catch (Exception exs)
                        {

                            Response.Write(" Email was not sent.");

                            if (exs is SmtpException)
                            {
                                Response.Write(" Due to server error. Please try again.");
                            }

                            try
                            {
                                //need this to connect to mysql database from here to
                                 
                                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                                con.Open();
                                MySqlCommand cmd = new MySqlCommand();
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.StoredProcedure;
                                //get name of stored procedure
                                cmd.CommandText = "In_ActivateOrgInfo";
                                //here


                                MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                                cmd.Parameters.Add(p1);
                                MySqlDataReader reader = cmd.ExecuteReader();

                                //Response.Write("<script>alert('Hello');</script>");
                                // Response.Redirect("editOrDeleteUser.aspx");
                                GridView1.DataBind();
                            }

                            catch (Exception ex)
                            {

                                Console.WriteLine(ex);
                            }
                        }


                        GridView1.DataBind();

                        //clear email fields
                        fromAddress = "";
                        smtpHost = "";
                        emailUsername = "";
                        emailPassword = "";
                        port = "";
                        orgActivationSubject = "";
                        orgInActivationSubject = "";
                        orgActivationBody = "";
                        orgInActivationBody = "";
                        orgActivationFooter = "";
                        orgInActivationFooter = "";



                    }
                    else
                    {
                        Response.Write("You cannot activate this Organization. The user account related to it, is not yet activated.");
                    }
                }

              //  Response.Write("Email has been successfully Sent! "); Response.AddHeader("REFRESH", "1;URL= editParadeInfo.aspx");
        }


       //InActivate Command    
        
        if (key == "inactive")
        {
            if (getConfrimCmd == "Enabled")
            {
                disableConfirm.Visible = true;
                AlertLbl.Text = "By clicking confirm, you are de-activating this organization account. An confirmation of de-activation email will be sent to the user. Do you confirm these changes?";
                confirmPanel.Visible = true;
                //  GridView1.Visible = false;
                GridView1.Enabled = false;
                Button1.Enabled = false;
                searchBtn.Enabled = false;
                advSearch.Enabled = false;

                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];

                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;

                confirmType = "InActivate";
            }

            if (getConfrimCmd == "Disabled")
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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has inactivated an organization with the ID[" + int.Parse(authNum) + "]. ' );");
                    cmd1.Connection = con1;
                    MySqlDataReader reader3 = cmd1.ExecuteReader();
                    con1.Close(); con1.Dispose();
                }
                catch (Exception ex)
                {


                }

               
                    try
                    {
                        //need this to connect to mysql database from here to
                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.StoredProcedure;
                        //get name of stored procedure
                        cmd.CommandText = "In_ActivateOrgInfo";
                        //here
                        int index = int.Parse(e.CommandArgument.ToString());
                        GridView grid = (GridView)e.CommandSource;
                        GridViewRow row = grid.Rows[index];

                        TableCell tblCell = row.Cells[0];
                        authNum = tblCell.Text;


                        MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                        cmd.Parameters.Add(p1);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //Response.Write("<script>alert('Hello');</script>");
                        // Response.Redirect("editOrDeleteUser.aspx");
                      


                   

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
                /////////////////////////In-Activates/Disapproves floats related organizaiton/////////////////////////////
                    try
                    {
                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand(" SELECT DISTINCT floatID FROM floatdetails f, orginfo o WHERE f.porgID = o.porgid AND o.porgid ='" + int.Parse(authNum) + "'  ;");
                        cmd.Connection = con;
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //updates row from the float
                        if (reader.HasRows)
                        {
                            while (reader.Read() && reader.HasRows)
                            {

                               disApproveFloats = reader.GetString(0);

                                 
                                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                                con1.Open();
                                MySqlCommand cmd1 = new MySqlCommand(" UPDATE floatdetails SET approved = 'Not Approved' WHERE floatID = '" + disApproveFloats.ToString() + "' ;");
                                cmd1.Connection = con1;
                                MySqlDataReader reader1 = cmd1.ExecuteReader();
                                con1.Close(); con1.Dispose(); reader1.Close();
                            }
                        }
                        else
                        {
                            test.Text = "No rows found";
                        }

                        con.Close(); con.Dispose(); reader.Close();

                    }
                    catch (Exception ex)
                    {

                        Response.Write("");
                    }

                ////////////////////////////////////////////////////////////////////////////////////////////////

                    // get the user ID/////
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uid FROM orginfo WHERE porgid = '" + int.Parse(authNum) + "' ;");
                        cmd.Connection = con;
                        userID = (cmd.ExecuteScalar().ToString());
                        con.Close(); con.Dispose();
                    }
                    catch (Exception ex)
                    {

                        Response.Write("");
                    }

                    //get the first name
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getUFName = (cmd.ExecuteScalar().ToString());
                        con.Close(); con.Dispose();
                    }
                    catch (Exception ex)
                    {

                        Response.Write("");
                    }

                    //get the last name
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getULName = (cmd.ExecuteScalar().ToString());
                        con.Close(); con.Dispose();
                    }
                    catch (Exception ex)
                    {

                        Response.Write("");
                    }

                    //get email
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uEmail FROM user WHERE uID = '" + userID.ToString() + "' ;");
                        cmd.Connection = con;
                        getEmail = (cmd.ExecuteScalar().ToString());
                        con.Close(); con.Dispose();
                    }
                    catch (Exception ex)
                    {

                    }

                    //email the user           
                    try
                    {

                        MailMessage mail = new MailMessage(fromAddress.ToString(), getEmail.ToString(), orgInActivationSubject.ToString(), "Hello" + " " + getUFName.ToString() + " " + getULName.ToString() + "," + "\r\n" + "\r\n" + orgInActivationBody.ToString() + "\r\n" + "\r\n" + orgInActivationFooter.ToString());
                        SmtpClient client = new SmtpClient(smtpHost.ToString());
                        client.Port = int.Parse(port);
                        client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                        client.EnableSsl = true;
                        client.Send(mail);
                        Response.Write("Email has been successfully Sent!");
                        Response.AddHeader("REFRESH", "1;URL= editParadeInfo.aspx");
                    }
                    catch (Exception exs)
                    {

                        Response.Write(" Email was not sent.");

                        if (exs is SmtpException)
                        {
                            Response.Write(" Due to server error. Please try again.");
                        }

                        try
                        {
                            //need this to connect to mysql database from here to
                             
                            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            //get name of stored procedure
                            cmd.CommandText = "ActivateOrgInfo";
                            //here


                            MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                            cmd.Parameters.Add(p1);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            //Response.Write("<script>alert('Hello');</script>");
                            // Response.Redirect("editOrDeleteUser.aspx");
                            GridView1.DataBind();
                        }



                        catch (Exception ex)
                        {

                            Console.WriteLine(ex);
                        }
                    }

                    GridView1.DataBind();

                    //clear email fields
                    fromAddress = "";
                    smtpHost = "";
                    emailUsername = "";
                    emailPassword = "";
                    port = "";
                    orgActivationSubject = "";
                    orgInActivationSubject = "";
                    orgActivationBody = "";
                    orgInActivationBody = "";
                    orgActivationFooter = "";
                    orgInActivationFooter = "";
            
            }

           // Response.Write("Email has been successfully Sent! "); Response.AddHeader("REFRESH", "1;URL= editParadeInfo.aspx");
            }


       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (confirmType == "Update")
        {
            AlertLbl.Text = "By clicking confirm, you are editing this Organization's information from the Parade Management System and it cannot be recovered once changes have been made. Do you confirm these changes?";
            confirmPanel.Visible = true;
            //  GridView1.Visible = false;
            GridView1.Enabled = false;
            Button1.Enabled = false;
            searchBtn.Enabled = false;
            advSearch.Enabled = false;


            confirmType = "Update";

        }

        
    }
    protected void searchBtn_Click(object sender, EventArgs e)
    {
        try
        {

            GridView1.AllowPaging = false;
            GridView1.AllowSorting = false;
            if (Session["SessionSearchOrg"] == "SessionSearchOrg")
            {
                searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE pOrgID = '" + Session["getOrgID"].ToString() + "'; ";

                //test1.Text = "";

                //if (IsPostBack)
                //{


                GridView1.DataSourceID = "searchedTable";
                GridView1.DataBind();
                // Session.Remove("SessionSearch");
                //}
            }
            else
            {

                if (cbOrganization.Checked)
                {
                    searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oOrganization LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }
                else if (cbContact.Checked)
                {
                    searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oContact LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }
                else if (cbWebsite.Checked)
                {
                    searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oWebsite LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }

                else if (cbStreet.Checked)
                {
                    searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oAddress1 LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }

                else if (cbProv.Checked)
                {
                    searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oProvince LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }

                else if (cbPostal.Checked)
                {
                    searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oPostal LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }

                else if (cbEmail.Checked)
                {
                    searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oEmail LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }

                else if (cbCity.Checked)
                {
                    searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oCity LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }
                else
                {
                    searchedTable.SelectCommand = "SELECT pOrgID, oOrganization,  oContact,  oPhone, oWebsite, oEmail,  oAddress1, oCity, oProvince, oPostal, oCountry,  oDateJoined, oDateExpire,  oSeminarAtt,  oActivation FROM orginfo  WHERE (oOrganization LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }


                GridView1.DataSourceID = "searchedTable";
                GridView1.DataBind();
                // GridView1.DataSource = ;
                // GridView1.DataBind();
            }
            GridView1.DataSourceID = "searchedTable";
            GridView1.DataBind();
        }
        catch (Exception ex)
        {

            Console.WriteLine(ex);
        }
        GridView1.DataSourceID = "searchedTable";
        GridView1.DataBind();
    }
    protected void advSearch_Click(object sender, EventArgs e)
    {
        cbCity.Visible = true;
        cbEmail.Visible = true;
        cbProv.Visible = true;
        cbStreet.Visible = true;
        cbPostal.Visible = true;
        cbWebsite.Visible = true;
        cbContact.Visible = true;
        cbOrganization.Visible = true;
        advSearchPanel.Visible = true;

    }
    protected void searchTxt_TextChanged(object sender, EventArgs e)
    {
        searchBtn.Focus();
    }
    protected void ConfirmBtn_Click(object sender, EventArgs e)
    {
        //Delete
        if (confirmType == "Delete")
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has deleted an organization with the ID[" + int.Parse(authNum) + "]. ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {


            }

            //TODO: There foreign key for the float data so it cant be deleted because its connected, there fore
            //have to find a way to delete a record from organization and also delete the field in the float table
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(" SELECT DISTINCT floatID FROM floatdetails f, orginfo o WHERE f.porgID = o.porgid AND o.porgid ='" + int.Parse(authNum) + "'  ;");
                cmd.Connection = con;
                MySqlDataReader reader = cmd.ExecuteReader();

                //updates row from the float
                if (reader.HasRows)
                {
                    while (reader.Read() && reader.HasRows)
                    {

                        test.Text = reader.GetString(0);

                         
                        MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con1.Open();
                        MySqlCommand cmd1 = new MySqlCommand(" DELETE FROM floatDetails WHERE floatID = '" + test.Text + "' ;");
                        cmd1.Connection = con1;
                        MySqlDataReader reader1 = cmd1.ExecuteReader();
                        con1.Close(); con1.Dispose(); reader1.Close();
                    }
                }
                else
                {
                    test.Text = "No rows found";
                }

                con.Close(); con.Dispose(); reader.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
        //Delete float table data with the same orgID
        if (confirmType == "Delete")
        {
            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("DELETE FROM orginfo WHERE porgID = '" + int.Parse(authNum) + "'");
                cmd1.Connection = con1;
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                reader1.Close();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }
        }

        
            
            // Response.Redirect("editOrDeleteUser.aspx");
            GridView1.DataBind();

           
            AlertLbl.Text = "";
            confirmPanel.Visible = false;
            GridView1.Enabled = true;
            Button1.Enabled = true;
            searchBtn.Enabled = true;
            advSearch.Enabled = true;

            confirmType = "";
        }

        /////////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////////
        //Update
        if (confirmType == "Update")
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has updated an organization with the ID[" + int.Parse(authNum) + "]. ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {


            }


         //TODO:
            //need this to connect to mysql database from here to
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //get name of stored procedure
            cmd.CommandText = "UpdateOrganization";
            //here

            try
            {
               //TODO: 
                test.Text = DropDownList2.Text;
                MySqlParameter p1 = new MySqlParameter("eOrganization", eeOrganization.Text);
                MySqlParameter p2 = new MySqlParameter("eContact", test.Text);
                MySqlParameter p3 = new MySqlParameter("ePhone", eePhone.Text);
                MySqlParameter p4 = new MySqlParameter("eWebsite", eeWebsite.Text);
                MySqlParameter p5 = new MySqlParameter("eEmail", eEmail.Text);
                MySqlParameter p6 = new MySqlParameter("eAddress1", eeStreet.Text);
                MySqlParameter p7 = new MySqlParameter("eCity", eeCity.Text);
                MySqlParameter p8 = new MySqlParameter("eProvince", eeProv.Text);
                MySqlParameter p9 = new MySqlParameter("ePostal", eePost.Text);
                MySqlParameter p10 = new MySqlParameter("eCountry", DropDownList1.Text);
                MySqlParameter p11 = new MySqlParameter("eAttend", eeSeminarAtt.Text);

                MySqlParameter p12 = new MySqlParameter("eID", int.Parse(authNum));

                cmd.Parameters.Add(p12);
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

                //cmd.Parameters.Add(p13);
                MySqlDataReader reader = cmd.ExecuteReader();
                // Response.Redirect("editOrDeleteUser.aspx", true);
                GridView1.DataBind();
                con.Close(); con.Dispose();
                reader.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            confirmType = "";
        }


        //Activate
        if (confirmType == "Activate")
        {         
       
                    //get the user id related to the organization
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uid FROM orginfo WHERE porgid = '" + int.Parse(authNum) + "' ;");
                        cmd.Connection = con;
                        getActiveUserID = (cmd.ExecuteScalar().ToString());
                        con.Close(); con.Dispose();
                    }
                    catch (Exception ex)
                    {

                        Response.Write("");
                    }


                    // Check to see if the user related is already activated
                    try
                    {


                         
                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT uActivation FROM user WHERE uid = '" + getActiveUserID.ToString() + "' ;");
                        cmd.Connection = con;
                        verifyActiveUser = (cmd.ExecuteScalar().ToString());
                        con.Close(); con.Dispose();
                    }
                    catch (Exception ex)
                    {

                        Response.Write("");
                    }

                    if (verifyActiveUser == "Active")
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
                            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has activated an organization with the ID[" + int.Parse(authNum) + "]. ' );");
                            cmd1.Connection = con1;
                            MySqlDataReader reader3 = cmd1.ExecuteReader();
                            con1.Close(); con1.Dispose();
                        }
                        catch (Exception ex)
                        {


                        }


                        try
                        {

                            //need this to connect to mysql database from here to
                             
                            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            //get name of stored procedure
                            cmd.CommandText = "activateOrgInfo";
                            //here


                            MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                            cmd.Parameters.Add(p1);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            //Response.Write("<script>alert('Hello');</script>");
                            //Response.Redirect("editOrDeleteUser.aspx");



                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex);
                        }

                        // get the user ID
                        try
                        {


                             
                            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand("SELECT uid FROM orginfo WHERE porgid = '" + int.Parse(authNum) + "' ;");
                            cmd.Connection = con;
                            userID = (cmd.ExecuteScalar().ToString());
                            con.Close(); con.Dispose();
                        }
                        catch (Exception ex)
                        {

                            Response.Write("");
                        }

                        //get the first name
                        try
                        {


                             
                            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                            cmd.Connection = con;
                            getUFName = (cmd.ExecuteScalar().ToString());
                            con.Close(); con.Dispose();
                        }
                        catch (Exception ex)
                        {

                            Response.Write("");
                        }

                        //get the last name
                        try
                        {


                             
                            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                            cmd.Connection = con;
                            getULName = (cmd.ExecuteScalar().ToString());
                            con.Close(); con.Dispose();
                        }
                        catch (Exception ex)
                        {

                            Response.Write("");
                        }

                        //get email
                        try
                        {


                             
                            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con.Open();
                            MySqlCommand cmd = new MySqlCommand("SELECT uEmail FROM user WHERE uID = '" + userID.ToString() + "' ;");
                            cmd.Connection = con;
                            getEmail = (cmd.ExecuteScalar().ToString());
                            con.Close(); con.Dispose();
                        }
                        catch (Exception ex)
                        {

                        }

                        //email the user           
                        try
                        {

                            MailMessage mail = new MailMessage(fromAddress.ToString(), getEmail.ToString(), orgActivationSubject.ToString(), "Hello" + " " + getUFName.ToString() + " " + getULName.ToString() + "," + "\r\n" + "\r\n" + orgActivationBody.ToString() + "\r\n" + "\r\n" + orgActivationFooter.ToString());
                            SmtpClient client = new SmtpClient(smtpHost.ToString());
                            client.Port = int.Parse(port);
                            client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                            client.EnableSsl = true;
                            client.Send(mail);
                            Response.Write("Email has been successfully Sent!");
                            Response.AddHeader("REFRESH", "1;URL= editParadeInfo.aspx");
                        }
                        catch (Exception exs)
                        {

                            Response.Write(" Email was not sent.");

                            if (exs is SmtpException)
                            {
                                Response.Write(" Due to server error. Please try again.");
                            }

                            try
                            {
                                //need this to connect to mysql database from here to
                                 
                                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                                con.Open();
                                MySqlCommand cmd = new MySqlCommand();
                                cmd.Connection = con;
                                cmd.CommandType = CommandType.StoredProcedure;
                                //get name of stored procedure
                                cmd.CommandText = "In_ActivateOrgInfo";
                                //here


                                MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                                cmd.Parameters.Add(p1);
                                MySqlDataReader reader = cmd.ExecuteReader();

                                //Response.Write("<script>alert('Hello');</script>");
                                // Response.Redirect("editOrDeleteUser.aspx");
                                GridView1.DataBind();
                            }



                            catch (Exception ex)
                            {

                                Console.WriteLine(ex);
                            }
                        }

                        //clear email fields
                        fromAddress = "";
                        smtpHost = "";
                        emailUsername = "";
                        emailPassword = "";
                        port = "";
                        orgActivationSubject = "";
                        orgInActivationSubject = "";
                        orgActivationBody = "";
                        orgInActivationBody = "";
                        orgActivationFooter = "";
                        orgInActivationFooter = "";


                        GridView1.DataBind();

                        AlertLbl.Text = "";
                        confirmPanel.Visible = false;
                        GridView1.Enabled = true;
                        Button1.Enabled = true;
                        searchBtn.Enabled = true;
                        advSearch.Enabled = true;
                        confirmType = "";
                    }
                    else
                    {
                        Response.Write("You cannot activate this Organization. The user account related to it, is not yet activated.");
                    }
                   // Response.Write("Email has been successfully Sent! "); Response.AddHeader("REFRESH", "1;URL= editParadeInfo.aspx");
        }

        //InActivate
        if (confirmType == "InActivate")
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has inactivated an organization with the ID[" + int.Parse(authNum) + "]. ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {


            }


             try
                {
                    //need this to connect to mysql database from here to
                     
                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    //get name of stored procedure
                    cmd.CommandText = "In_ActivateOrgInfo";
                    //here

                    
                    MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                    cmd.Parameters.Add(p1);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    //Response.Write("<script>alert('Hello');</script>");
                    // Response.Redirect("editOrDeleteUser.aspx");
                    GridView1.DataBind();
                }
               

            
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

             /////////////////////////In-Activates/Disapproves floats related organizaiton/////////////////////////////
             try
             {
                  
                 MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                 con.Open();
                 MySqlCommand cmd = new MySqlCommand(" SELECT DISTINCT floatID FROM floatdetails f, orginfo o WHERE f.porgID = o.porgid AND o.porgid ='" + int.Parse(authNum) + "'  ;");
                 cmd.Connection = con;
                 MySqlDataReader reader = cmd.ExecuteReader();

                 //updates row from the float
                 if (reader.HasRows)
                 {
                     while (reader.Read() && reader.HasRows)
                     {

                         disApproveFloats = reader.GetString(0);

                          
                         MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                         con1.Open();
                         MySqlCommand cmd1 = new MySqlCommand(" UPDATE floatdetails SET approved = 'Not Approved' WHERE floatID = '" + disApproveFloats.ToString() + "' ;");
                         cmd1.Connection = con1;
                         MySqlDataReader reader1 = cmd1.ExecuteReader();
                         con1.Close(); con1.Dispose(); reader1.Close();
                     }
                 }
                 else
                 {
                     test.Text = "No rows found";
                 }

                 con.Close(); con.Dispose(); reader.Close();

             }
             catch (Exception ex)
             {

                 Response.Write("");
             }

             ////////////////////////////////////////////////////////////////////////////////////////////////



            // get the user ID
            try
            {


                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT uid FROM orginfo WHERE porgid = '" + int.Parse(authNum) + "' ;");
                cmd.Connection = con;
                userID = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //get the first name
            try
            {


                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                cmd.Connection = con;
                getUFName = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //get the last name
            try
            {


                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uID = '" + userID.ToString() + "' ;");
                cmd.Connection = con;
                getULName = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //get email
            try
            {


                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT uEmail FROM user WHERE uID = '" + userID.ToString() + "' ;");
                cmd.Connection = con;
                getEmail = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

            }

            //email the user           
            try
            {

                MailMessage mail = new MailMessage(fromAddress.ToString(), getEmail.ToString(), orgInActivationSubject.ToString(), "Hello" + " " + getUFName.ToString() + " " + getULName.ToString() + "," + "\r\n" + "\r\n" + orgInActivationBody.ToString() + "\r\n" + "\r\n" + orgInActivationFooter.ToString());
                SmtpClient client = new SmtpClient(smtpHost.ToString());
                client.Port = int.Parse(port);
                client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                client.EnableSsl = true;
                client.Send(mail);
                Response.Write("Email has been successfully Sent!");
                Response.AddHeader("REFRESH", "1;URL= editParadeInfo.aspx");
            }
            catch (Exception exs)
            {

                Response.Write(" Email was not sent.");

                if (exs is SmtpException)
                {
                    Response.Write(" Due to server error. Please try again.");
                }

                try
                {
                    //need this to connect to mysql database from here to
                     
                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    //get name of stored procedure
                    cmd.CommandText = "ActivateOrgInfo";
                    //here


                    MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                    cmd.Parameters.Add(p1);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    //Response.Write("<script>alert('Hello');</script>");
                    // Response.Redirect("editOrDeleteUser.aspx");
                    GridView1.DataBind();
                }



                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
            }
            //clear email fields
            fromAddress = "";
            smtpHost = "";
            emailUsername = "";
            emailPassword = "";
            port = "";
            orgActivationSubject = "";
            orgInActivationSubject = "";
            orgActivationBody = "";
            orgInActivationBody = "";
            orgActivationFooter = "";
            orgInActivationFooter = "";

            GridView1.DataBind();

            AlertLbl.Text = "";
            confirmPanel.Visible = false;
            GridView1.Enabled = true;
            Button1.Enabled = true;
            searchBtn.Enabled = true;
            advSearch.Enabled = true;
            confirmType = "";

          //  Response.Write("Email has been successfully Sent! "); Response.AddHeader("REFRESH", "1;URL= editParadeInfo.aspx");
        }

        //Disable activation confirmation pop-up
        if (disableConfirm.Checked)
        {
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Disabled' WHERE configID = 9;");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                reader3.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
        }

        AlertLbl.Text = "";
        confirmPanel.Visible = false;
        GridView1.Enabled = true;
        Button1.Enabled = true;
        searchBtn.Enabled = true;
        advSearch.Enabled = true;
        confirmType = "";
    }
    protected void CanelBtn_Click(object sender, EventArgs e)
    {
        AlertLbl.Text = "";
        confirmPanel.Visible = false;
        GridView1.Enabled = true;
        Button1.Enabled = true;
        searchBtn.Enabled = true;
        advSearch.Enabled = true;
        //BannerBtn.Enabled = true;
        confirmType = "";
    }
    protected void normalEdit_Click(object sender, EventArgs e)
    {
        Session.Remove("SessionSearchOrg");
        Response.Redirect("editParadeInfo.aspx");
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {


            //get date and time
            String years1 = DateTime.Now.Year.ToString();
            String months1 = DateTime.Now.Month.ToString();
            String days1 = DateTime.Now.Day.ToString();
            String hours1 = DateTime.Now.Hour.ToString();
            String mins1 = DateTime.Now.Minute.ToString();
            String secs1 = DateTime.Now.Second.ToString();
            String fullDate1 = years1 + "-" + months1 + "-" + days1;
            String fullTime1 = hours1 + "-" + mins1 + "-" + secs1;

            string fileName = "ParadeMSOrganizationTable" + "_" + fullDate1 + "_" + fullTime1 + ".csv";

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * INTO OUTFILE '" + uploadPath + fileName + "' FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '\"'LINES TERMINATED BY '\n' FROM orginfo;", con);
            con.Open();

            cmd.ExecuteNonQuery();

            con.Close(); con.Dispose();
            /*
             cmd.Connection = con;
                 MySqlDataReader reader3 = cmd.ExecuteReader();
                 reader3.Close();
             */

            Response.ContentType = "APPLICATION/OCTET-STREAM";
            String Header = "Attachment; Filename=" + fileName;
            Response.AppendHeader("Content-Disposition", Header);

            //needs to be modified when added to server
            System.IO.FileInfo Dfile = new System.IO.FileInfo(uploadPath + fileName);
            Response.WriteFile(Dfile.FullName);
            //Don't forget to add the following line
            Response.End();

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
    }
}