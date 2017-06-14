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

public partial class trasnferOrg : System.Web.UI.Page
{
    static string constantParadeID;
    static string getParadeName;
    static string getParadeID;
    static string getLatestParadeName;

    //get radio button options strings
    static string getDeleteFloatTran;
    static string getGroupTrasnfer;
    static string getGTExcludeFloat;
    static string getGTExcludeOrg;
    //get the orgid from the user id
    static string getUserPORGID;

    protected void Page_Load(object sender, EventArgs e)
    {

        gtExcludeFloat.Enabled = false;
        gtExcludeOrg.Enabled = false;

        //session
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSession"].ToString();
        }
        ////////////////////////get the group trasnfer options values//////////////////////////////
        if (!IsPostBack)
        {
            //delete float from ogranization
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 19;");
                cmd.Connection = con;
                getDeleteFloatTran = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }
            //full gropup trasnfer
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 16;");
                cmd.Connection = con;
                getGroupTrasnfer = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }
            //exclude float
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 17;");
                cmd.Connection = con;
                getGTExcludeFloat = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }
            //exclude org and float
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 18;");
                cmd.Connection = con;
                getGTExcludeOrg = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }
            /////////Now logic behind preselected options
            if (getDeleteFloatTran == "True")
            {
                deleteFloatTran.Checked = true;
            }
            else if (getDeleteFloatTran == "False")
            {
                deleteFloatTran.Checked = false;
            }
            ////////////////////////////////////////
            if (getGroupTrasnfer == "True")
            {
                groupTrasnfer.Checked = true;
            }
            else if (getGroupTrasnfer == "False")
            {
                groupTrasnfer.Checked = false;
            }
            ///////////////////////////////////////////
            if (getGTExcludeFloat == "True")
            {
                gtExcludeFloat.Checked = true;
            }
            else if (getGTExcludeFloat == "False")
            {
                gtExcludeFloat.Checked = false;
            }
            //////////////////////////////////////
            if (getGTExcludeOrg == "True")
            {
                gtExcludeOrg.Checked = true;
            }
            else if (getGTExcludeOrg == "False")
            {
                gtExcludeOrg.Checked = false;
            }
        }

        if (groupTrasnfer.Checked)
        {
            gtExcludeFloat.Enabled = true;
            gtExcludeOrg.Enabled = true;
        }
        ////////////////////////////make extra div invisible...might need later///////////////////
        spare.Visible = true;

        //Get the Current parade
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 10;");
            cmd.Connection = con;
            currentParade.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

     

        //getting the parade ID for the organization in the current parade
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT paradeID FROM parade WHERE paradeName = '" + currentParade.Text + "';");
            cmd.Connection = con;
            constantParadeID = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("There are no Parades in the ParadeMS");
        }

        //gets organization from specifi parades
        try
        {
            SqlDataSource2.SelectCommand = "SELECT porgid, oorganization FROM orginfo WHERE paradeID = '" + constantParadeID.ToString() + "'";
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //gets participant users from specific parades
        try
        {
            SqlDataSource5.SelectCommand = "SELECT uid, uusername FROM user WHERE paradeID = '" + constantParadeID.ToString() + "' AND uStatus = 'Participant'  ";
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //gets  volunteer users from specific parades
        try
        {
            SqlDataSource4.SelectCommand = "SELECT uid, uusername FROM user WHERE paradeID = '" + constantParadeID.ToString() + "' AND uStatus = 'Volunteer'  ";
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        // get preset state of current parade


      
        //dropdowns Select latest parade

        //delete float from ogranization
        
        

        

    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/ try{/*get date and time*/String years = DateTime.Now.Year.ToString();String months = DateTime.Now.Month.ToString();String days = DateTime.Now.Day.ToString();String hours = DateTime.Now.Hour.ToString();String mins = DateTime.Now.Minute.ToString();String secs = DateTime.Now.Second.ToString();String fullDate = years + "-" + months + "-" + days;String fullTime = hours + ":" + mins + ":" + secs;MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);con.Open();MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has signed out.' );");cmd.Connection = con;MySqlDataReader reader3 = cmd.ExecuteReader();con.Close(); con.Dispose();}catch (Exception ex){}Session.Remove("userSession");
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx", true);
        }
    }

    protected void makeCurrentParadeBtn_Click(object sender, EventArgs e)
    {



        //get the parade name to set in the current parade
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT paradeName FROM parade WHERE paradeID = '" + pickCurrentParade.SelectedValue.ToString() + "';");
            cmd.Connection = con;
            getParadeName = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        try
        {
             
            MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con1.Open();
            MySqlCommand cmd1 = new MySqlCommand("UPDATE pageconfig SET value = '" + getParadeName.ToString() + "' WHERE configID = 10;");
            cmd1.Connection = con1;
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            reader1.Close();
            con1.Close(); con1.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has made [" + getParadeName.ToString() + "] the current parade via the Transfer Org. or User page. ' );");
            cmd1.Connection = con1;
            MySqlDataReader reader3 = cmd1.ExecuteReader();
            con1.Close(); con1.Dispose();
        }
        catch (Exception ex)
        {


        }

        //update the IDS value to the currennt parade in page config
        try
        {
             
            MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con1.Open();
            MySqlCommand cmd1 = new MySqlCommand("UPDATE pageconfig SET IDs = '" + pickCurrentParade.SelectedValue.ToString() + "'  WHERE  configID = 10");
            cmd1.Connection = con1;
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            reader1.Close();
            con1.Close(); con1.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        Response.Redirect("trasnferOrg.aspx");
    }
    protected void trasnfer_Click(object sender, EventArgs e)
    {
        //changing the floats to another another parade related to the selected organization
        if (deleteFloatTran.Checked)
        {

            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(" SELECT DISTINCT floatID FROM floatdetails f, orginfo o WHERE f.porgID = o.porgid AND o.porgid ='" + tOrganization.SelectedValue.ToString() + "'  ;");
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

        }
        else
        {

            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(" SELECT DISTINCT floatID FROM floatdetails f, orginfo o WHERE f.porgID = o.porgid AND o.porgid ='" + tOrganization.SelectedValue.ToString() + "'  ;");
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
                        MySqlCommand cmd1 = new MySqlCommand(" UPDATE floatdetails SET paradeID = '" + tParade.SelectedValue.ToString() + "' WHERE floatID = '" + test.Text + "' ;");
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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has trasferred an organization. ' );");
            cmd1.Connection = con1;
            MySqlDataReader reader3 = cmd1.ExecuteReader();
            con1.Close(); con1.Dispose();
        }
        catch (Exception ex)
        {


        }

        //actually changing the organization
        try
        {
             
            MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con1.Open();
            MySqlCommand cmd1 = new MySqlCommand("UPDATE orginfo SET paradeID = '" + tParade.SelectedValue.ToString() + "' WHERE porgid = '" + tOrganization.SelectedValue.ToString() + "';");
            cmd1.Connection = con1;
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            reader1.Close();
            con1.Close(); con1.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        Response.Redirect("trasnferOrg.aspx");
    }
    protected void UserTrasnfer_Click(object sender, EventArgs e)
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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has trasferred a participant user. ' );");
            cmd1.Connection = con1;
            MySqlDataReader reader3 = cmd1.ExecuteReader();
            con1.Close(); con1.Dispose();
        }
        catch (Exception ex)
        {


        }

        //actually changing the user to the other parade
        try
        {
             
            MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con1.Open();
            MySqlCommand cmd1 = new MySqlCommand("UPDATE user SET paradeID = '" + tUserParade.SelectedValue.ToString() + "' WHERE uid = '" + tUser.SelectedValue.ToString() + "';");
            cmd1.Connection = con1;
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            reader1.Close();
            con1.Close(); con1.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        Response.Redirect("trasnferOrg.aspx");
    }
    protected void resetDeleteFloat_Click(object sender, EventArgs e)
    {
        deleteFloatTran.Checked = false;
        groupTrasnfer.Checked = false;
        gtExcludeFloat.Checked = false;
        gtExcludeOrg.Checked = false;
    }

    protected void gtOptionSave_Click(object sender, EventArgs e)
    {
        if (deleteFloatTran.Checked)
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has set the deletion of a float when transfering Org. option. ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {


            }

            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("UPDATE pageconfig SET value = 'True' WHERE configID = '19';");
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

        if (!deleteFloatTran.Checked)
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has reset the delete float when transfering Org. option. ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {


            }

            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("UPDATE pageconfig SET value = 'False' WHERE configID = '19';");
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
        ////////////////////////////////////////

        if (groupTrasnfer.Checked == true)
        {

            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("UPDATE pageconfig SET value = 'True' WHERE configID = '16';");
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
        else if (groupTrasnfer.Checked == false)
        {
            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("UPDATE pageconfig SET value = 'False' WHERE configID = '16';");
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
        ///////////////////////////////////////////
        if (gtExcludeFloat.Checked == true)
        {
            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("UPDATE pageconfig SET value = 'True' WHERE configID = '17';");
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
        else if (gtExcludeFloat.Checked == false)
        {
            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("UPDATE pageconfig SET value = 'False' WHERE configID = '17';");
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
        //////////////////////////////////////
        if (gtExcludeOrg.Checked == true)
        {
            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("UPDATE pageconfig SET value = 'True' WHERE configID = '18';");
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
        else if (gtExcludeOrg.Checked == false)
        {
            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("UPDATE pageconfig SET value = 'False' WHERE configID = '18';");
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

        Response.Redirect("trasnferOrg.aspx");
    }
    protected void tVolBtn_Click(object sender, EventArgs e)
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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has trasferred a volunteer user. ' );");
            cmd1.Connection = con1;
            MySqlDataReader reader3 = cmd1.ExecuteReader();
            con1.Close(); con1.Dispose();
        }
        catch (Exception ex)
        {


        }

        try
        {
             
            MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con1.Open();
            MySqlCommand cmd1 = new MySqlCommand("UPDATE user SET paradeID = '" + tVolParade.SelectedValue.ToString() + "' WHERE uid = '" + tVolUser.SelectedValue.ToString() + "';");
            cmd1.Connection = con1;
            MySqlDataReader reader1 = cmd1.ExecuteReader();
            reader1.Close();
            con1.Close(); con1.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        Response.Redirect("trasnferOrg.aspx");
    }
}