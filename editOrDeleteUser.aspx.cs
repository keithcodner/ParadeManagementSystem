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


public partial class editOrDeleteUser : System.Web.UI.Page
{
    public static DataTable fullTable;
    static bool update = false;
    static string authNum;
    static string confirmType;
    static string getConfrimCmd;
    static string getEmail;
    static string getFName;
    static string getLName;
    static string getUserStatus;
    static string subAccountType;

    //get the users first name from session
    static string getUsersFName;

    //check if exists
    static string doesNameExist;
    static string doesOrgNameExist;
    static string doesEmailExist;
    static string frmDBNameExist;
    static string frmDBOrgNameExist;
    static string frmDBEmailExist;



    //if users are in-active then deactivate/disapprove orgs and floats
    static string disApproveFloats;
    static string disApproveOrg;
    static string gotOrgID4Float;

    //email data
    static string adminFromAddress;
    static string hostAddress;
    static string emailUsername;
    static string emailPassword;
    static string emailPort;

    //email data - admin 
    static string activationSubject;
    static string inActivationSubject;
    static string ActivationBody;
    static string inActivationBody;
    static string ActivationFooter;
    static string inActivationFooter;
    static string isUserSuperUser;

    //email data - participant 
    static string partActiveSubject;
    static string partInactiveSubject;
    static string partActiveBody;
    static string partInactiveBody;
    static string partActiveFooter;
    static string partInactiveFooter;

    //email data - volunteer 
    static string volActiveSubject;
    static string volInActiveSubject;
    static string volActiveBody;
    static string volInActiveBody;
    static string volActivefooter;
    static string volInActiveFooter;

    //selective or global
    static string getSelect;
    static string getParadeID;
    static string nbsp = "&nbsp;";

    static string uploadPath = "C://ProgramData//1UPSolutionsParadeMS//";
    static string uploadVirtualPath = "1UPSolutionsParadeMS\\";



    static string getTempUsername;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session.Remove("SessionSearch");
        normalEdit.Visible = false;

        if (Session["SessionSearch"] == "SessionSearch")
        {
            normalEdit.Visible = true;
            searchBtn.Enabled = false;
            searchTxt.Enabled = false;
        }

        //disables the confirm box
        disableConfirm.Visible = false;

        //disables apply button
        Button1.Enabled = false;

        //------ get  enable/disable confirmations check ----------------------

        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 8;");
            cmd.Connection = con;
            getConfrimCmd = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //check if selective or global
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
        //getting the parade ID
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
        //selective or global depending on user selection
        if (getSelect == "Selective")
        {
            editTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user WHERE paradeID='" + getParadeID.ToString() + "';";
        }

        if (getSelect == "Global")
        {
            editTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user;  ";
        }


        //adv search options
        //------   ----------------------

        //////////////////////////////////////////////////////////////
        searchBtn.Focus();
        searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation  FROM user  WHERE (uUsername LIKE '%" + searchTxt.Text.ToString() + "%' )";
        if (cbFName.Checked)
        {
            searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation  FROM user  WHERE (uFName LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }
        else if (cbLName.Checked)
        {
            searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation  FROM user  WHERE (uLName LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }
        else if (cbStatus.Checked)
        {
            searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation  FROM user  WHERE (uStatus LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }

        else if (cbStreet.Checked)
        {
            searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation  FROM user  WHERE (uStreet LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }

        else if (cbProv.Checked)
        {
            searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation  FROM user  WHERE (uProv LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }

        else if (cbPostal.Checked)
        {
            searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user  WHERE (uPostal LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }

        else if (cbEmail.Checked)
        {
            searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user  WHERE (uEmail LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }

        else if (cbCity.Checked)
        {
            searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user  WHERE (uCity LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }
        else
        {
            searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user  WHERE (uUsername LIKE '%" + searchTxt.Text.ToString() + "%' )";
        }


        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSession"].ToString();
        }

        try
        {
            GridView1.DataSource = fullTable;
            GridView1.DataBind();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);

        }

        if (cbFName.Checked)
        {
            searchLbl.Text = "First Name";
        }
        else if (cbLName.Checked)
        {
            searchLbl.Text = "Last Name";
        }
        else if (cbStatus.Checked)
        {
            searchLbl.Text = "Status";
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



        /////////////////////////Admin Email///////////////////////////////////////



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
        //get activation subject
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT activesubject FROM email WHERE emailID = 1;");
            cmd.Connection = con;
            activationSubject = (cmd.ExecuteScalar().ToString());
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
            inActivationSubject = (cmd.ExecuteScalar().ToString());
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
            ActivationBody = (cmd.ExecuteScalar().ToString());
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
            inActivationBody = (cmd.ExecuteScalar().ToString());
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
            ActivationFooter = (cmd.ExecuteScalar().ToString());
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
            inActivationFooter = (cmd.ExecuteScalar().ToString());
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
        /////////////////////Participant Email/////////////////////////////////

        //get activation subject
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT activesubject FROM email WHERE emailID = 2;");
            cmd.Connection = con;
            partActiveSubject = (cmd.ExecuteScalar().ToString());
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
            partInactiveSubject = (cmd.ExecuteScalar().ToString());
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
            partActiveBody = (cmd.ExecuteScalar().ToString());
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
            partInactiveBody = (cmd.ExecuteScalar().ToString());
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
            partActiveFooter = (cmd.ExecuteScalar().ToString());
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
            partInactiveFooter = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }
        ///////////////////Volunteer Email///////////////////////////////////////////////
        //get activation subject
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT activesubject FROM email WHERE emailID = 3;");
            cmd.Connection = con;
            volActiveSubject = (cmd.ExecuteScalar().ToString());
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
            volInActiveSubject = (cmd.ExecuteScalar().ToString());
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
            volActiveBody = (cmd.ExecuteScalar().ToString());
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
            volInActiveBody = (cmd.ExecuteScalar().ToString());
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
            volActivefooter = (cmd.ExecuteScalar().ToString());
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
            volInActiveFooter = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("Some of the fields are empty.");
        }

        if (Session["SessionSearch"] == "SessionSearch")
        {
            searchedTable.SelectCommand = "";

            //GridView1.AllowPaging = false;
            //GridView1.AllowSorting = false;
            //Response.Write(Session["getUserID"]);

            editTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user  WHERE uID = '" + Session["getUserID"].ToString() + "'";

            //GridView1.DataSourceID = "searchedTable";
            //GridView1.DataBind();

            // test1.Text = "Before Editing you must search this user first.";
            //get the users first name and put it in the text box
            //try
            //{
            //     
            //    MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            //    con1.Open();
            //    MySqlCommand cmd1 = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + Session["getUserID"].ToString() + "'");
            //    cmd1.Connection = con1;
            //    getUsersFName = (cmd1.ExecuteScalar().ToString());
            //    con1.Close(); con1.Dispose();
            //}
            //catch (Exception ex)
            //{

            //    Response.Write("");
            //}


            //searchTxt.Text = getUsersFName.ToString();

            //auto clicks search button
            searchBtn_Click(null, null);
            // GridView1.DataSourceID = "searchedTable";
            //Session.Remove("SessionSearch");


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
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string key = e.CommandName;
        //delete
        if (key == "DeleteUser")
        {
            ConfirmBtn.Focus();

            AlertLbl.Text = "By clicking confirm, you are deleting this User from the Parade Management System and it cannot be recovered. Do you confirm these changes?";
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

            TableCell checkIfSuperAdmin = row.Cells[9];
            isUserSuperUser = checkIfSuperAdmin.Text;


            confirmType = "Delete";
        }
        //




        //update



        if (key == "UpdateUser")
        {


            ///////////////////////////////////

            Button1.Focus();
            Button1.Enabled = true;
            try
            {
                /////////////////////////////////////////////////////
                update = true;
                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];

                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;


                TableCell place1 = row.Cells[1];
                eeUsername.Text = place1.Text.Replace(nbsp, "");
                //gets and temporarily stores orginal username before edit
                getTempUsername = eeUsername.Text;

                //for checks later when updating
                frmDBNameExist = eeUsername.Text;

                TableCell place2 = row.Cells[2];
                eeOrganization.Text = place2.Text.Replace(nbsp, "");

                //for checks later when updating
                frmDBOrgNameExist = eeOrganization.Text;

                TableCell place3 = row.Cells[3];
                eeFName.Text = place3.Text.Replace(nbsp, "");

                TableCell place4 = row.Cells[4];
                eeLName.Text = place4.Text.Replace(nbsp, "");

                TableCell place5 = row.Cells[5];
                eeHNo.Text = place5.Text.Replace(nbsp, "");

                TableCell place6 = row.Cells[6];
                eeBNo.Text = place6.Text.Replace(nbsp, "");

                TableCell place7 = row.Cells[7];
                eeCity.Text = place7.Text.Replace(nbsp, "");

                TableCell place8 = row.Cells[8];
                eeStreet.Text = place8.Text.Replace(nbsp, "");


                TableCell place12 = row.Cells[12];

                eeProv.SelectedIndex = eeProv.Items.IndexOf
                      (eeProv.Items.FindByText(place12.Text));


                TableCell place10 = row.Cells[10];
                eeEmail.Text = place10.Text.Replace(nbsp, ""); 

                //for checks later when updating
                frmDBEmailExist = eeEmail.Text;

                TableCell place11 = row.Cells[11];
                eePost.Text = place11.Text.Replace(nbsp, ""); 
                //eePost.Text = place11.Text;
                //eePost.Text.Trim();

                TableCell place9 = row.Cells[9];
                //Label1.Text = place9.Text;

                if (place9.Text == "Super-Administrator")
                {
                    eeAccountType.Enabled = false;

                }

                if (place9.Text == "Administrator")
                {
                    eeAccountType.SelectedIndex = 1;
                    eeOrganization.ReadOnly = false;
                    eeAccountType.Enabled = true;
                }
                else if (place9.Text == "Participant")
                {
                    eeAccountType.SelectedIndex = 2;

                    //field manipulation depending if its a volunteer or participant

                    eeOrganization.ReadOnly = false;
                    eeAccountType.Enabled = true;
                }
                else if (place9.Text == "Volunteer")
                {
                    eeAccountType.SelectedIndex = 3;

                    eeOrganization.Text = "";
                    eeOrganization.ReadOnly = true;
                    eeAccountType.Enabled = true;
                }
                else
                {
                    eeAccountType.SelectedIndex = 0;

                }


            }
            catch (Exception)
            {

            }


            confirmType = "Update";

        }

        //Activate
        if (key == "activate")
        {
            disableConfirm.Visible = true;
            if (getConfrimCmd == "Enabled")
            {
                AlertLbl.Text = "By clicking confirm, you are activating this user account. An confirmation of activation email will be sent to the user. Do you confirm these changes?";
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
            //sending activation email
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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has activated a user account with the ID[" + int.Parse(authNum) + "]' );");
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
                    cmd.CommandText = "activateUser";
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
                    //Response.Redirect("editOrDeleteUser.aspx");
                    reader.Close();
                    con.Close(); con.Dispose();

                }
                catch (Exception ex)
                {

                }

                //get the user status
                try
                {



                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT uStatus FROM user WHERE uID = '" + int.Parse(authNum) + "' ;");
                    cmd.Connection = con;
                    getUserStatus = (cmd.ExecuteScalar().ToString());
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
                    MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uID = '" + int.Parse(authNum) + "' AND uStatus = '" + getUserStatus.ToString() + "';");
                    cmd.Connection = con;
                    getLName = (cmd.ExecuteScalar().ToString());
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
                    MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + int.Parse(authNum) + "' AND uStatus =  '" + getUserStatus.ToString() + "';");
                    cmd.Connection = con;
                    getFName = (cmd.ExecuteScalar().ToString());
                    con.Close(); con.Dispose();
                }
                catch (Exception ex)
                {

                    Response.Write("");
                }



                // get the email
                try
                {



                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT uEmail FROM user WHERE uID = '" + int.Parse(authNum) + "' AND uStatus = '" + getUserStatus.ToString() + "';");
                    cmd.Connection = con;
                    getEmail = (cmd.ExecuteScalar().ToString());
                    con.Close(); con.Dispose();
                }
                catch (Exception ex)
                {

                    Response.Write("");
                }

                //email the user
                if (getUserStatus == "Administrator")
                {
                    try
                    {

                        MailMessage mail = new MailMessage(adminFromAddress.ToString(), getEmail.ToString(), activationSubject.ToString(), "Hello" + " " + getFName.ToString() + " " + getLName.ToString() + "," + "\r\n" + "\r\n" + ActivationBody.ToString() + "\r\n" + "\r\n" + ActivationFooter.ToString());
                        SmtpClient client = new SmtpClient(hostAddress.ToString());
                        client.Port = int.Parse(emailPort);
                        client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                        client.EnableSsl = true;
                        client.Send(mail);
                        Response.Write("Email has been successfully Sent!");
                        Response.AddHeader("REFRESH", "1;URL= editOrDeleteUser.aspx");
                    }
                    catch (Exception exs1)
                    {

                        Response.Write(" Email was not sent.");

                        if (exs1 is SmtpException)
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
                            cmd.CommandText = "In_ActivateUser";
                            //here


                            MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                            cmd.Parameters.Add(p1);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            //Response.Write("<script>alert('Hello');</script>");
                            // Response.Redirect("editOrDeleteUser.aspx");
                            GridView1.DataBind();
                            reader.Close();
                            con.Close(); con.Dispose();


                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex);
                        }

                    }
                }

                if (getUserStatus == "Participant")
                {
                    try
                    {

                        MailMessage mail = new MailMessage(adminFromAddress.ToString(), getEmail.ToString(), partActiveSubject.ToString(), "Hello" + " " + getFName.ToString() + " " + getLName.ToString() + "," + "\r\n" + "\r\n" + partActiveBody.ToString() + "\r\n" + "\r\n" + partActiveFooter.ToString());
                        SmtpClient client = new SmtpClient(hostAddress.ToString());
                        client.Port = int.Parse(emailPort);
                        client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                        client.EnableSsl = true;
                        client.Send(mail);
                        Response.Write("Email has been successfully Sent!");
                        Response.AddHeader("REFRESH", "1;URL= editOrDeleteUser.aspx");
                    }
                    catch (Exception exs2)
                    {

                        Response.Write(" Email was not sent.");

                        //if there is a progbleme with the server, it will prompt the user to try again
                        if (exs2 is SmtpException)
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
                            cmd.CommandText = "In_ActivateUser";
                            //here


                            MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                            cmd.Parameters.Add(p1);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            //Response.Write("<script>alert('Hello');</script>");
                            // Response.Redirect("editOrDeleteUser.aspx");
                            GridView1.DataBind();
                            reader.Close();
                            con.Close(); con.Dispose();


                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex);
                        }

                    }
                }

                if (getUserStatus == "Volunteer")
                {
                    try
                    {

                        MailMessage mail = new MailMessage(adminFromAddress.ToString(), getEmail.ToString(), volActiveSubject.ToString(), "Hello" + " " + getFName.ToString() + " " + getLName.ToString() + "," + "\r\n" + "\r\n" + volActiveBody.ToString() + "\r\n" + "\r\n" + volActivefooter.ToString());
                        SmtpClient client = new SmtpClient(hostAddress.ToString());
                        client.Port = int.Parse(emailPort);
                        client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                        client.EnableSsl = true;
                        client.Send(mail);
                        Response.Write("Email has been successfully Sent!");
                        Response.AddHeader("REFRESH", "1;URL= editOrDeleteUser.aspx");
                    }
                    catch (Exception exs3)
                    {

                        Response.Write(" Email was not sent.");

                        //if there is a progbleme with the server, it will prompt the user to try again
                        if (exs3 is SmtpException)
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
                            cmd.CommandText = "In_ActivateUser";
                            //here


                            MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                            cmd.Parameters.Add(p1);
                            MySqlDataReader reader = cmd.ExecuteReader();

                            //Response.Write("<script>alert('Hello');</script>");
                            // Response.Redirect("editOrDeleteUser.aspx");
                            GridView1.DataBind();
                            reader.Close();
                            con.Close(); con.Dispose();


                        }
                        catch (Exception ex)
                        {

                            Console.WriteLine(ex);
                        }

                    }
                }
                //clear fields
                adminFromAddress = "";
                hostAddress = "";
                emailUsername = "";
                emailPassword = "";
                emailPort = "";
                activationSubject = "";
                inActivationSubject = "";
                ActivationBody = "";
                inActivationBody = "";
                ActivationFooter = "";
                inActivationFooter = "";
                partActiveSubject = "";
                partInactiveSubject = "";
                partActiveBody = "";
                partInactiveBody = "";
                partActiveFooter = "";
                partInactiveFooter = "";
                volActiveSubject = "";
                volInActiveSubject = "";
                volActiveBody = "";
                volInActiveBody = "";
                volActivefooter = "";
                volInActiveFooter = "";

                GridView1.DataBind();
            }
            
        }


        //In-active
        if (key == "inactive")
        {

            if (getConfrimCmd == "Enabled")
            {
                disableConfirm.Visible = true;
                AlertLbl.Text = "By clicking confirm, you are de-activating this user account. An confirmation of de-activation email will be sent to the user. Do you confirm these changes?";
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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has inactivated a user account with the ID[" + int.Parse(authNum) + "]' );");
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
                    cmd.CommandText = "In_ActivateUser";
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
                    GridView1.DataBind();
                    reader.Close();
                    con.Close(); con.Dispose();


                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }

                /////////////////////////In-Activates/Disapproves floats related organizaiton/////////////////////////////

                //get the org id for floats
                try
                {



                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT porgid FROM orginfo WHERE uID = '" + int.Parse(authNum) + "' ;");
                    cmd.Connection = con;
                    gotOrgID4Float = (cmd.ExecuteScalar().ToString());
                    con.Close(); con.Dispose();
                }
                catch (Exception ex)
                {

                    Response.Write("");
                }


                //disable floats
                try
                {

                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(" SELECT DISTINCT floatID FROM floatdetails f, orginfo o WHERE f.porgID = o.porgid AND o.porgid ='" + gotOrgID4Float.ToString() + "'  ;");
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
                catch (Exception)
                {

                    Response.Write("No floats or organizations found to de-activate for this user. ");
                }

                //-----------------------------------------------------------------------------------------------------

                //disable orgs
                try
                {

                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand(" SELECT DISTINCT porgID FROM orginfo o WHERE uid = '" + int.Parse(authNum) + "'  ;");
                    cmd.Connection = con;
                    MySqlDataReader reader = cmd.ExecuteReader();

                    //updates row from the float
                    if (reader.HasRows)
                    {
                        while (reader.Read() && reader.HasRows)
                        {

                            disApproveOrg = reader.GetString(0);


                            MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                            con1.Open();
                            MySqlCommand cmd1 = new MySqlCommand(" UPDATE orginfo SET oActivation = 'In-Active' WHERE porgid = '" + disApproveOrg.ToString() + "' ;");
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


                //get the user status
                try
                {



                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT uStatus FROM user WHERE uID = '" + int.Parse(authNum) + "' ;");
                    cmd.Connection = con;
                    getUserStatus = (cmd.ExecuteScalar().ToString());
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
                    MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uID = '" + int.Parse(authNum) + "' AND uStatus = '" + getUserStatus.ToString() + "';");
                    cmd.Connection = con;
                    getLName = (cmd.ExecuteScalar().ToString());
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
                    MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + int.Parse(authNum) + "' AND uStatus = '" + getUserStatus.ToString() + "';");
                    cmd.Connection = con;
                    getFName = (cmd.ExecuteScalar().ToString());
                    con.Close(); con.Dispose();
                }
                catch (Exception ex)
                {

                    Response.Write("");
                }


                // get the email
                try
                {



                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT uEmail FROM user WHERE uID = '" + int.Parse(authNum) + "' AND uStatus = '" + getUserStatus.ToString() + "';");
                    cmd.Connection = con;
                    getEmail = (cmd.ExecuteScalar().ToString());
                    con.Close(); con.Dispose();
                }
                catch (Exception ex)
                {

                    Response.Write("");
                }
                //email the user
                if (getUserStatus == "Administrator")
                {
                    try
                    {

                        MailMessage mail = new MailMessage(adminFromAddress.ToString(), getEmail.ToString(), inActivationSubject.ToString(), "Hello" + " " + getFName.ToString() + " " + getLName.ToString() + "," + "\r\n" + "\r\n" + inActivationBody.ToString() + "\r\n" + "\r\n" + inActivationFooter.ToString());
                        SmtpClient client = new SmtpClient(hostAddress.ToString());
                        client.Port = int.Parse(emailPort);
                        client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                        client.EnableSsl = true;
                        client.Send(mail);
                        Response.Write("Email has been successfully Sent!");
                        Response.AddHeader("REFRESH", "1;URL= editOrDeleteUser.aspx");
                    }
                    catch (Exception exs1)
                    {

                        Response.Write(" Email was not sent.");

                        //if there is a progbleme with the server, it will prompt the user to try again
                        if (exs1 is SmtpException)
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
                            cmd.CommandText = "activateUser";
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
                            //Response.Redirect("editOrDeleteUser.aspx");
                            reader.Close();
                            con.Close(); con.Dispose();

                        }
                        catch (Exception ex1)
                        {

                        }

                    }
                }

                if (getUserStatus == "Participant")
                {
                    try
                    {

                        MailMessage mail = new MailMessage(adminFromAddress.ToString(), getEmail.ToString(), partInactiveSubject.ToString(), "Hello" + " " + getFName.ToString() + " " + getLName.ToString() + "," + "\r\n" + "\r\n" + partInactiveBody.ToString() + "\r\n" + "\r\n" + partInactiveFooter.ToString());
                        SmtpClient client = new SmtpClient(hostAddress.ToString());
                        client.Port = int.Parse(emailPort);
                        client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                        client.EnableSsl = true;
                        client.Send(mail);
                        Response.Write("Email has been successfully Sent!");
                        Response.AddHeader("REFRESH", "1;URL= editOrDeleteUser.aspx");
                    }
                    catch (Exception exs2)
                    {

                        Response.Write(" Email was not sent.");

                        //if there is a progbleme with the server, it will prompt the user to try again
                        if (exs2 is SmtpException)
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
                            cmd.CommandText = "activateUser";
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
                            //Response.Redirect("editOrDeleteUser.aspx");
                            reader.Close();
                            con.Close(); con.Dispose();

                        }
                        catch (Exception ex1)
                        {

                        }

                    }
                }

                if (getUserStatus == "Volunteer")
                {
                    try
                    {

                        MailMessage mail = new MailMessage(adminFromAddress.ToString(), getEmail.ToString(), volInActiveSubject.ToString(), "Hello" + " " + getFName.ToString() + " " + getLName.ToString() + "," + "\r\n" + "\r\n" + volInActiveBody.ToString() + "\r\n" + "\r\n" + volInActiveFooter.ToString());
                        SmtpClient client = new SmtpClient(hostAddress.ToString());
                        client.Port = int.Parse(emailPort);
                        client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                        client.EnableSsl = true;
                        client.Send(mail);
                        Response.Write("Email has been successfully Sent!");
                        Response.AddHeader("REFRESH", "1;URL= editOrDeleteUser.aspx");
                    }
                    catch (Exception exs3)
                    {

                        Response.Write(" Email was not sent.");

                        //if there is a progbleme with the server, it will prompt the user to try again
                        if (exs3 is SmtpException)
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
                            cmd.CommandText = "activateUser";
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
                            //Response.Redirect("editOrDeleteUser.aspx");
                            reader.Close();
                            con.Close(); con.Dispose();

                        }
                        catch (Exception ex1)
                        {

                        }

                    }
                }

                //clear fields
                adminFromAddress = "";
                hostAddress = "";
                emailUsername = "";
                emailPassword = "";
                emailPort = "";
                activationSubject = "";
                inActivationSubject = "";
                ActivationBody = "";
                inActivationBody = "";
                ActivationFooter = "";
                inActivationFooter = "";
                partActiveSubject = "";
                partInactiveSubject = "";
                partActiveBody = "";
                partInactiveBody = "";
                partActiveFooter = "";
                partInactiveFooter = "";
                volActiveSubject = "";
                volInActiveSubject = "";
                volActiveBody = "";
                volInActiveBody = "";
                volActivefooter = "";
                volInActiveFooter = "";

                GridView1.DataBind();
            }

           
        }
    }
    protected void GridView1_Edit(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GridView1_Update(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Enabled = false;

        if (confirmType == "Update")
        {
            AlertLbl.Text = "By clicking confirm, you are editing this User's information from the Parade Management System and it cannot be recovered once changes have been made. Do you confirm these changes?";
            confirmPanel.Visible = true;
            //  GridView1.Visible = false;
            GridView1.Enabled = false;
            Button1.Enabled = false;
            searchBtn.Enabled = false;
            advSearch.Enabled = false;


            confirmType = "Update";

        }



    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {

    }
    protected void searchBtn_Click(object sender, EventArgs e)
    {

        try
        {

            GridView1.AllowPaging = false;
            GridView1.AllowSorting = false;
            if (Session["SessionSearch"] == "SessionSearch")
            {
                searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user  WHERE  uID = '" + Session["getUserID"].ToString() + "' ";

                test1.Text = "";

                //if (IsPostBack)
                //{


                GridView1.DataSourceID = "searchedTable";
                GridView1.DataBind();
                // Session.Remove("SessionSearch");
                //}
            }
            else
            {

                if (cbFName.Checked)
                {
                    searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation  FROM user  WHERE (uFName LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }
                else if (cbLName.Checked)
                {
                    searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation  FROM user  WHERE (uLName LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }
                else if (cbStatus.Checked)
                {
                    searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation  FROM user  WHERE (uStatus LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }

                else if (cbStreet.Checked)
                {
                    searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation  FROM user  WHERE (uStreet LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }

                else if (cbProv.Checked)
                {
                    searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation  FROM user  WHERE (uProv LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }

                else if (cbPostal.Checked)
                {
                    searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user  WHERE (uPostal LIKE '%" + searchTxt.Text.ToString() + "%' )";
                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }

                else if (cbEmail.Checked)
                {
                    searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user  WHERE (uEmail LIKE '%" + searchTxt.Text.ToString() + "%' )";
                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }

                else if (cbCity.Checked)
                {
                    searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user  WHERE (uCity LIKE '%" + searchTxt.Text.ToString() + "%' )";

                    GridView1.DataSourceID = "searchedTable";
                    GridView1.DataBind();
                }
                else
                {

                    searchedTable.SelectCommand = "SELECT uID, uUsername, uOrgName, uFName, uLName, uHPhone, uBPhone, uCity, uStreet, uStatus, uEmail, uPostal, uProv, uDateJoined, uDateExpire, uActivation FROM user  WHERE (uUsername LIKE '%" + searchTxt.Text.ToString() + "%' )";

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
        cbStatus.Visible = true;
        cbFName.Visible = true;
        cbLName.Visible = true;
        advSearchPanel.Visible = true;


    }
    protected void ConfirmBtn_Click(object sender, EventArgs e)
    {

   

        //delete
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

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has deleted a user account with the ID[" + int.Parse(authNum) + "]' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

            ////////DELETE FLOATS RELATED TO THE ORGS/////////////////////////
            /*
             These must be deleted first before the organization can be delete and before the user can be delete.
             */

            //Selects the users id that are related to the
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(" SELECT DISTINCT floatID FROM floatdetails f, orginfo o, user u  WHERE f.porgID = o.porgid AND o.uid = u.uid AND u.uid = '" + int.Parse(authNum) + "' ;");
                cmd.Connection = con;
                MySqlDataReader reader = cmd.ExecuteReader();

                //Deletes row from the float
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

            /////////DELETE ORG THAT HAS THE SAME USER ID ///////////////
            try
            {

                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("DELETE FROM orginfo WHERE uID = '" + int.Parse(authNum) + "'");
                cmd1.Connection = con1;
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                reader1.Close();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }
            //////////////////////DELETEING THE USER///////////////////////////////////////


            if (isUserSuperUser == "Super-Administrator")
            {
                Response.Write(" This user is of type 'Super-Administrator' and cannot be deleted from the system. ");
            }
            else
            {

                

                try
                {

                    MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con1.Open();
                    MySqlCommand cmd1 = new MySqlCommand("UPDATE user SET uActivation = 'Active' WHERE uID = '" + int.Parse(authNum) + "'; ");
                    cmd1.Connection = con1;
                    MySqlDataReader reader1 = cmd1.ExecuteReader();
                    reader1.Close();
                    con1.Close(); con1.Dispose();
                }
                catch (Exception ex)
                {

                    // Response.Write("");
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
                    cmd.CommandText = "DeleteUser";
                    //here


                    MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                    cmd.Parameters.Add(p1);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    //Response.Write("<script>alert('Hello');</script>");

                    // Response.Redirect("editOrDeleteUser.aspx");
                    GridView1.DataBind();
                    reader.Close();
                    con.Close(); con.Dispose();
                    AlertLbl.Text = "";
                    confirmPanel.Visible = false;
                    GridView1.Enabled = true;
                    Button1.Enabled = true;
                    searchBtn.Enabled = true;
                    advSearch.Enabled = true;

                    confirmType = "";
                }
                catch (Exception ex)
                {

                    Response.Write("");
                }
            }

        }


        //if YES - user name
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "checkUserName";
            MySqlParameter p1 = new MySqlParameter("chckUName", eeUsername.Text);

            //MySqlParameter p3 = new MySqlParameter("ofTypeAdmin", p);
            cmd.Parameters.Add(p1);


            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows && eeUsername.Text != null)
            {

                doesNameExist = "Yes";

                if (frmDBNameExist == eeUsername.Text)
                {
                    doesNameExist = "No";
                }

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

        //if YES - org name
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "checkOrgName";
            MySqlParameter p1 = new MySqlParameter("chckOrgName", eeOrganization.Text);

            //MySqlParameter p3 = new MySqlParameter("ofTypeAdmin", p);
            cmd.Parameters.Add(p1);


            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows && eeOrganization.Text != null)
            {

                doesOrgNameExist = "Yes";

                if (frmDBOrgNameExist == eeOrganization.Text)
                {
                    doesOrgNameExist = "No";
                }

            }
            else
            {
                doesOrgNameExist = "No";
            }


            reader.Close();
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {


        }

        //if YES - email name
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "checkEmailUName";
            MySqlParameter p1 = new MySqlParameter("chckEmailName", eeEmail.Text);

            //MySqlParameter p3 = new MySqlParameter("ofTypeAdmin", p);
            cmd.Parameters.Add(p1);


            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows && eeEmail.Text != null )
            {

                doesEmailExist = "Yes";

                if (frmDBEmailExist == eeEmail.Text )
                {
                    doesEmailExist = "No";
                }

            }
            else
            {
                doesEmailExist = "No";
            }
            reader.Close();
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {


        }

        ////////////////////////////////////Update///////////////////////////////////////////////



        if ((confirmType == "Update") && (eeUsername.Text.Length != 0) && (eeEmail.Text.Length != 0))
        {
            if (doesNameExist == "Yes")
            {
                checkIfUserExists.Text = "*The username already exits, please choose another.";

            }
            else
            {
                checkIfUserExists.Text = "";
            }

            //check if the org name exists
            if (doesOrgNameExist == "Yes")
            {
                checkIfOrgExists.Text = "*The Organization Name already exits, please choose another.";

            }
            else
            {
                checkIfOrgExists.Text = "";
            }

            //check if the email exists
            if (doesEmailExist == "Yes")
            {
                checkIfEmailExists.Text = "*The Email already exits, please choose another.";

            }
            else
            {
                checkIfEmailExists.Text = "";
            }
           
            /////////////////when button pressed check for conditions below if they exist///////////////////////////////////////////////
            if ((doesNameExist == "No" && doesOrgNameExist == "No" && doesEmailExist == "No"))
            {
                //eeAccountType.Text
                //subAccountType

                if (eeAccountType.Enabled == false)
                {
                    subAccountType = "Super-Administrator";
                }
                else
                {
                    subAccountType = eeAccountType.Text;
                }

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
                    MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has updated a user account with the username [" + eeUsername.Text + "]' );");
                    cmd1.Connection = con1;
                    MySqlDataReader reader3 = cmd1.ExecuteReader();
                    con1.Close(); con1.Dispose();
                }
                catch (Exception ex)
                {


                }

                //need this to connect to mysql database from here to

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                //get name of stored procedure
                cmd.CommandText = "UpdateUser";
                //here
                try
                {
                    MySqlParameter p1 = new MySqlParameter("eFirstName", eeFName.Text);
                    MySqlParameter p2 = new MySqlParameter("eLastName", eeLName.Text);
                    MySqlParameter p3 = new MySqlParameter("eUsername", eeUsername.Text);
                    MySqlParameter p5 = new MySqlParameter("eHomeNumber", eeHNo.Text);
                    MySqlParameter p6 = new MySqlParameter("eBusinessNumber", eeBNo.Text);
                    MySqlParameter p7 = new MySqlParameter("eEmail", eeEmail.Text);
                    MySqlParameter p8 = new MySqlParameter("eAccountType", subAccountType);
                    MySqlParameter p9 = new MySqlParameter("ePostal", eePost.Text);
                    MySqlParameter p10 = new MySqlParameter("eCity", eeCity.Text);
                    MySqlParameter p11 = new MySqlParameter("eProv", eeProv.Text);
                    MySqlParameter p12 = new MySqlParameter("eStreet", eeStreet.Text);
                    MySqlParameter p13 = new MySqlParameter("eID", int.Parse(authNum));
                    MySqlParameter p14 = new MySqlParameter("eOrganization", eeOrganization.Text);

                    cmd.Parameters.Add(p14);
                    cmd.Parameters.Add(p13);
                    cmd.Parameters.Add(p1);
                    cmd.Parameters.Add(p2);
                    cmd.Parameters.Add(p3);

                    cmd.Parameters.Add(p5);
                    cmd.Parameters.Add(p6);
                    cmd.Parameters.Add(p7);
                    cmd.Parameters.Add(p8);
                    cmd.Parameters.Add(p9);
                    cmd.Parameters.Add(p10);
                    cmd.Parameters.Add(p11);
                    cmd.Parameters.Add(p12);
                    //cmd.Parameters.Add(p13);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    // Response.Redirect("editOrDeleteUser.aspx", true);
                    GridView1.DataBind();
                    reader.Close();
                    con.Close(); con.Dispose();

                    ////////////////update username message to new user name if applicable////////////////////////////////////
                    try
                    {

                        MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con1.Open();
                        MySqlCommand cmd1 = new MySqlCommand("UPDATE messagefromuser SET userName = '" + eeUsername.Text + "' WHERE userName = '" + getTempUsername + "' ; ");
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
                catch (Exception ex)
                {
                    // Console.WriteLine(ex);

                }
            }
            //else  // CONDITIONS REMINDER:(doesNameExist == "No" && doesOrgNameExist == "No" && doesEmailExist == "No")
            //{

            //Check if the username is exists
            
            //}
        }
        else // CONDITIONS REMINDER:(confirmType == "Update") && (eeUsername.Text.Length != 0) && (eeEmail.Text.Length != 0)
        {

            if (confirmType == "Activate" || confirmType == "InActivate")
            {
                Response.Write("Email has been successfully Sent!"); Response.AddHeader("REFRESH", "1;URL= editOrDeleteUser.aspx");
            }
            else 
            {
                Response.Write("Update Failed. Username field and/or email field cannot be null."); Response.AddHeader("REFRESH", "1;URL= editOrDeleteUser.aspx");
            }
            
          
        }

       

        ///////////////////////////////////////////activate user account
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        if (confirmType == "Activate")
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has activated a user account with the ID[" + int.Parse(authNum) + "]' );");
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

                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand();
                cmd1.Connection = con1;
                cmd1.CommandType = CommandType.StoredProcedure;
                //get name of stored procedure
                cmd1.CommandText = "activateUser";
                //here


                MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                cmd1.Parameters.Add(p1);
                MySqlDataReader reader = cmd1.ExecuteReader();

                //Response.Write("<script>alert('Hello');</script>");
                //Response.Redirect("editOrDeleteUser.aspx");
                reader.Close();
                con1.Close(); con1.Dispose();

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            //get the user status
            try
            {



                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT uStatus FROM user WHERE uID = '" + int.Parse(authNum) + "' ;");
                cmd.Connection = con;
                getUserStatus = (cmd.ExecuteScalar().ToString());
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
                MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uID = '" + int.Parse(authNum) + "' AND uStatus = '" + getUserStatus.ToString() + "';");
                cmd.Connection = con;
                getLName = (cmd.ExecuteScalar().ToString());
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
                MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + int.Parse(authNum) + "' AND uStatus =  '" + getUserStatus.ToString() + "';");
                cmd.Connection = con;
                getFName = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }



            // get the email
            try
            {



                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT uEmail FROM user WHERE uID = '" + int.Parse(authNum) + "' AND uStatus = '" + getUserStatus.ToString() + "';");
                cmd.Connection = con;
                getEmail = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //email the user
            if (getUserStatus == "Administrator")
            {
                try
                {

                    MailMessage mail = new MailMessage(adminFromAddress.ToString(), getEmail.ToString(), activationSubject.ToString(), "Hello" + " " + getFName.ToString() + " " + getLName.ToString() + "," + "\r\n" + "\r\n" + ActivationBody.ToString() + "\r\n" + "\r\n" + ActivationFooter.ToString());
                    SmtpClient client = new SmtpClient(hostAddress.ToString());
                    client.Port = int.Parse(emailPort);
                    client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                    client.EnableSsl = true;
                    client.Send(mail);
                    Response.Write("Email has been successfully Sent!");
                    

                }
                catch (Exception exs1)
                {

                    Response.Write(" Email was not sent.");

                    //if there is a progbleme with the server, it will prompt the user to try again
                    if (exs1 is SmtpException)
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
                        cmd.CommandText = "In_ActivateUser";
                        //here


                        MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                        cmd.Parameters.Add(p1);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //Response.Write("<script>alert('Hello');</script>");
                        // Response.Redirect("editOrDeleteUser.aspx");
                        GridView1.DataBind();
                        reader.Close();
                        con.Close(); con.Dispose();


                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex);
                    }
                }
            }

            if (getUserStatus == "Participant")
            {
                try
                {

                    MailMessage mail = new MailMessage(adminFromAddress.ToString(), getEmail.ToString(), partActiveSubject.ToString(), "Hello" + " " + getFName.ToString() + " " + getLName.ToString() + "," + "\r\n" + "\r\n" + partActiveBody.ToString() + "\r\n" + "\r\n" + partActiveFooter.ToString());
                    SmtpClient client = new SmtpClient(hostAddress.ToString());
                    client.Port = int.Parse(emailPort);
                    client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                    client.EnableSsl = true;
                    client.Send(mail);
                    Response.Write("Email has been successfully Sent!");
                    
                }
                catch (Exception exs2)
                {

                    Response.Write(" Email was not sent.");

                    //if there is a progbleme with the server, it will prompt the user to try again
                    if (exs2 is SmtpException)
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
                        cmd.CommandText = "In_ActivateUser";
                        //here


                        MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                        cmd.Parameters.Add(p1);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //Response.Write("<script>alert('Hello');</script>");
                        // Response.Redirect("editOrDeleteUser.aspx");
                        GridView1.DataBind();
                        reader.Close();
                        con.Close(); con.Dispose();


                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex);
                    }
                }
            }

            if (getUserStatus == "Volunteer")
            {
                try
                {

                    MailMessage mail = new MailMessage(adminFromAddress.ToString(), getEmail.ToString(), volActiveSubject.ToString(), "Hello" + " " + getFName.ToString() + " " + getLName.ToString() + "," + "\r\n" + "\r\n" + volActiveBody.ToString() + "\r\n" + "\r\n" + volActivefooter.ToString());
                    SmtpClient client = new SmtpClient(hostAddress.ToString());
                    client.Port = int.Parse(emailPort);
                    client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                    client.EnableSsl = true;
                    client.Send(mail);
                    Response.Write("Email has been successfully Sent!");
                    

                }
                catch (Exception exs3)
                {

                    Response.Write(" Email was not sent.");

                    //if there is a progbleme with the server, it will prompt the user to try again
                    if (exs3 is SmtpException)
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
                        cmd.CommandText = "In_ActivateUser";
                        //here


                        MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                        cmd.Parameters.Add(p1);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        //Response.Write("<script>alert('Hello');</script>");
                        // Response.Redirect("editOrDeleteUser.aspx");
                        GridView1.DataBind();
                        reader.Close();
                        con.Close(); con.Dispose();


                    }
                    catch (Exception ex1)
                    {

                        Console.WriteLine(ex1);
                    }
                }
            }
            //clear fields
            adminFromAddress = "";
            hostAddress = "";
            emailUsername = "";
            emailPassword = "";
            emailPort = "";
            activationSubject = "";
            inActivationSubject = "";
            ActivationBody = "";
            inActivationBody = "";
            ActivationFooter = "";
            inActivationFooter = "";
            partActiveSubject = "";
            partInactiveSubject = "";
            partActiveBody = "";
            partInactiveBody = "";
            partActiveFooter = "";
            partInactiveFooter = "";
            volActiveSubject = "";
            volInActiveSubject = "";
            volActiveBody = "";
            volInActiveBody = "";
            volActivefooter = "";
            volInActiveFooter = "";

            GridView1.DataBind();

            AlertLbl.Text = "";
            confirmPanel.Visible = false;
            GridView1.Enabled = true;
            Button1.Enabled = true;
            searchBtn.Enabled = true;
            advSearch.Enabled = true;
            confirmType = "";

            
        }






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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has Inactivated a user account with the ID[" + int.Parse(authNum) + "]' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {

            }

            //updating user to inactive
            try
            {
                //need this to connect to mysql database from here to

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();


                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                //get name of stored procedure
                cmd.CommandText = "In_ActivateUser";
                //here


                MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                cmd.Parameters.Add(p1);
                MySqlDataReader reader = cmd.ExecuteReader();

                //Response.Write("<script>alert('Hello');</script>");
                // Response.Redirect("editOrDeleteUser.aspx");
                GridView1.DataBind();
                reader.Close();
                con.Close(); con.Dispose();


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            /////////////////////////In-Activates/Disapproves floats related organizaiton/////////////////////////////

            //get the org id for floats
            try
            {



                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT porgid FROM orginfo WHERE uID = '" + int.Parse(authNum) + "' ;");
                cmd.Connection = con;
                gotOrgID4Float = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }


            //disable floats
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(" SELECT DISTINCT floatID FROM floatdetails f, orginfo o WHERE f.porgID = o.porgid AND o.porgid ='" + gotOrgID4Float.ToString() + "'  ;");
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

                // Response.Write("This is user is either an Admin or Volunteer. ");
            }

            //-----------------------------------------------------------------------------------------------------

            //disable orgs
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(" SELECT DISTINCT porgID FROM orginfo o WHERE uid = '" + int.Parse(authNum) + "'  ;");
                cmd.Connection = con;
                MySqlDataReader reader = cmd.ExecuteReader();

                //updates row from the float
                if (reader.HasRows)
                {
                    while (reader.Read() && reader.HasRows)
                    {

                        disApproveOrg = reader.GetString(0);


                        MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con1.Open();
                        MySqlCommand cmd1 = new MySqlCommand(" UPDATE orginfo SET oActivation = 'In-Active' WHERE porgid = '" + disApproveOrg.ToString() + "' ;");
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


            //get the user status
            try
            {



                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT uStatus FROM user WHERE uID = '" + int.Parse(authNum) + "' ;");
                cmd.Connection = con;
                getUserStatus = (cmd.ExecuteScalar().ToString());
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
                MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uID = '" + int.Parse(authNum) + "' AND uStatus = '" + getUserStatus.ToString() + "';");
                cmd.Connection = con;
                getLName = (cmd.ExecuteScalar().ToString());
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
                MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uID = '" + int.Parse(authNum) + "' AND uStatus =  '" + getUserStatus.ToString() + "';");
                cmd.Connection = con;
                getFName = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }



            // get the email
            try
            {



                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT uEmail FROM user WHERE uID = '" + int.Parse(authNum) + "' AND uStatus = '" + getUserStatus.ToString() + "';");
                cmd.Connection = con;
                getEmail = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }


            //email the user
            if (getUserStatus == "Administrator")
            {
                try
                {

                    MailMessage mail = new MailMessage(adminFromAddress.ToString(), getEmail.ToString(), inActivationSubject.ToString(), "Hello" + " " + getFName.ToString() + " " + getLName.ToString() + "," + "\r\n" + "\r\n" + inActivationBody.ToString() + "\r\n" + "\r\n" + inActivationFooter.ToString());
                    SmtpClient client = new SmtpClient(hostAddress.ToString());
                    client.Port = int.Parse(emailPort);
                    client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                    client.EnableSsl = true;
                    client.Send(mail);
                    Response.Write("Email has been successfully Sent!");

                }
                catch (Exception exs1)
                {

                    Response.Write(" Email was not sent.");

                    //if there is a progbleme with the server, it will prompt the user to try again
                    if (exs1 is SmtpException)
                    {
                        Response.Write(" Due to server error. Please try again.");
                    }

                    try
                    {
                        //need this to connect to mysql database from here to

                        MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con1.Open();
                        MySqlCommand cmd1 = new MySqlCommand();
                        cmd1.Connection = con1;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        //get name of stored procedure
                        cmd1.CommandText = "activateUser";
                        //here


                        MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                        cmd1.Parameters.Add(p1);
                        MySqlDataReader reader = cmd1.ExecuteReader();

                        //Response.Write("<script>alert('Hello');</script>");
                        //Response.Redirect("editOrDeleteUser.aspx");
                        reader.Close();
                        con1.Close(); con1.Dispose();

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex);
                    }

                }
            }

            if (getUserStatus == "Participant")
            {
                try
                {

                    MailMessage mail = new MailMessage(adminFromAddress.ToString(), getEmail.ToString(), partInactiveSubject.ToString(), "Hello" + " " + getFName.ToString() + " " + getLName.ToString() + "," + "\r\n" + "\r\n" + partInactiveBody.ToString() + "\r\n" + "\r\n" + partInactiveFooter.ToString());
                    SmtpClient client = new SmtpClient(hostAddress.ToString());
                    client.Port = int.Parse(emailPort);
                    client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                    client.EnableSsl = true;
                    client.Send(mail);
                    Response.Write("Email has been successfully Sent!");

                }
                catch (Exception exs2)
                {

                    Response.Write("Email was not sent.");

                    //if there is a progbleme with the server, it will prompt the user to try again
                    if (exs2 is SmtpException)
                    {
                        Response.Write(" Due to server error. Please try again.");
                    }

                    try
                    {
                        //need this to connect to mysql database from here to

                        MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con1.Open();
                        MySqlCommand cmd1 = new MySqlCommand();
                        cmd1.Connection = con1;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        //get name of stored procedure
                        cmd1.CommandText = "activateUser";
                        //here


                        MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                        cmd1.Parameters.Add(p1);
                        MySqlDataReader reader = cmd1.ExecuteReader();

                        //Response.Write("<script>alert('Hello');</script>");
                        //Response.Redirect("editOrDeleteUser.aspx");
                        reader.Close();
                        con1.Close(); con1.Dispose();

                    }
                    catch (Exception ex1)
                    {

                        Console.WriteLine(ex1);
                    }

                }
            }

            if (getUserStatus == "Volunteer")
            {
                try
                {

                    MailMessage mail = new MailMessage(adminFromAddress.ToString(), getEmail.ToString(), volInActiveSubject.ToString(), "Hello" + " " + getFName.ToString() + " " + getLName.ToString() + "," + "\r\n" + "\r\n" + volInActiveBody.ToString() + "\r\n" + "\r\n" + volInActiveFooter.ToString());
                    SmtpClient client = new SmtpClient(hostAddress.ToString());
                    client.Port = int.Parse(emailPort);
                    client.Credentials = new System.Net.NetworkCredential(emailUsername.ToString(), emailPassword.ToString());
                    client.EnableSsl = true;
                    client.Send(mail);
                    Response.Write("Email has been successfully Sent!");

                }
                catch (Exception exs3)
                {

                    Response.Write(" Email was not sent.");

                    //if there is a progbleme with the server, it will prompt the user to try again
                    if (exs3 is SmtpException)
                    {
                        Response.Write(" Due to server error. Please try again.");
                    }

                    try
                    {
                        //need this to connect to mysql database from here to

                        MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con1.Open();
                        MySqlCommand cmd1 = new MySqlCommand();
                        cmd1.Connection = con1;
                        cmd1.CommandType = CommandType.StoredProcedure;
                        //get name of stored procedure
                        cmd1.CommandText = "activateUser";
                        //here


                        MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                        cmd1.Parameters.Add(p1);
                        MySqlDataReader reader = cmd1.ExecuteReader();

                        //Response.Write("<script>alert('Hello');</script>");
                        //Response.Redirect("editOrDeleteUser.aspx");
                        reader.Close();
                        con1.Close(); con1.Dispose();

                    }
                    catch (Exception ex1)
                    {

                        Console.WriteLine(ex1);
                    }
                }
            }
            //clear fields
            adminFromAddress = "";
            hostAddress = "";
            emailUsername = "";
            emailPassword = "";
            emailPort = "";
            activationSubject = "";
            inActivationSubject = "";
            ActivationBody = "";
            inActivationBody = "";
            ActivationFooter = "";
            inActivationFooter = "";
            partActiveSubject = "";
            partInactiveSubject = "";
            partActiveBody = "";
            partInactiveBody = "";
            partActiveFooter = "";
            partInactiveFooter = "";
            volActiveSubject = "";
            volInActiveSubject = "";
            volActiveBody = "";
            volInActiveBody = "";
            volActivefooter = "";
            volInActiveFooter = "";

            GridView1.DataBind();






            AlertLbl.Text = "";
            confirmPanel.Visible = false;
            GridView1.Enabled = true;
            Button1.Enabled = true;
            searchBtn.Enabled = true;
            advSearch.Enabled = true;
            confirmType = "";

            
        }

        //delete the user
        if (disableConfirm.Checked)
        {
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value='Disabled' WHERE configID = 8;");
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
        Button1.Enabled = false;
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
        Session.Remove("SessionSearch");
        Response.Redirect("editOrDeleteUser.aspx");
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

             string fileName= "ParadeMSUserTable"+"_"+fullDate1+"_"+fullTime1+".csv";

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * INTO OUTFILE '" + uploadPath + fileName + "' FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '\"'LINES TERMINATED BY '\n' FROM user;", con);
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
            System.IO.FileInfo Dfile = new System.IO.FileInfo(uploadPath  + fileName);
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