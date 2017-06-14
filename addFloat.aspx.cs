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

public partial class addFloat : System.Web.UI.Page
{
    static string getOrganizationName;
    static string getContact;
    static string getCurrentParade;
    static string getParadeID;
    static string getParadeIDs;
    static string constantParadeID;
    static string getParadeName;
    static string getSelectedOrgs;

    

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

       

        //Get the waiver 
        //get the waiver title
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 7;");
            cmd.Connection = con;
             test.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        //--------Set the waiver in read only textbox--------

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT wWaiver FROM waiver WHERE wName = '" + test.Text + "';");
            cmd.Connection = con;
            Waiver.Text = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("A Waiver should be added/created before you create a Float.");
        }
        //Get the Current parade
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

        //getting the parade ID for the organization in the current parade
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT paradeID FROM parade WHERE paradeName = '" + getParadeName.ToString() + "';");
            cmd.Connection = con;
            getSelectedOrgs = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("There are no Parades in the ParadeMS");
        }
        //gets organization from specifi parades
        try
        {
            OrgName.SelectCommand = "SELECT porgid, oorganization FROM orginfo WHERE paradeID = '" + getSelectedOrgs.ToString() + "'";
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //get the parade ID from pageconfig
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT IDs FROM pageconfig where configID= '10'");
            cmd.Connection = con;
            getParadeIDs = (cmd.ExecuteScalar().ToString());

            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        //get the current max entry number so far
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT MAX(entryNo) FROM floatdetails where paradeID= '" + getParadeIDs.ToString() + "'");
            cmd.Connection = con;
            maxEntry.Text = (cmd.ExecuteScalar().ToString());

            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (cTerms.Checked) // if waiver is checked
        {
           

            //getting organization name
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT oOrganization FROM orginfo WHERE porgid = '" +  Organization.SelectedValue.ToString() + "';");
                cmd.Connection = con;
                getOrganizationName = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }
            //get contact
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT oContact FROM orginfo WHERE porgid = '" + Organization.SelectedValue.ToString() + "';");
                cmd.Connection = con;
                getContact = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }
            // get current parade from config page
            try
             {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 10 ;");
                cmd.Connection = con;
                getCurrentParade = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

        //get the parade id to insert into the float
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT paradeID FROM parade WHERE paradeName = '" + getCurrentParade.ToString() + "' ;");
                cmd.Connection = con;
                getParadeID = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has added a float with the organization name [" + getOrganizationName + "].' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {


            }

            //insert float into database
            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertFloat";
                MySqlParameter p1 = new MySqlParameter("porgid", Organization.SelectedValue.ToString());
                MySqlParameter p2 = new MySqlParameter("Parade", Parade.SelectedValue.ToString());
                MySqlParameter p3 = new MySqlParameter("Organization", getOrganizationName.ToString());
                MySqlParameter p4 = new MySqlParameter("Contact", getContact.ToString());
                MySqlParameter p5 = new MySqlParameter("EntryType", Entry.Text);
                MySqlParameter p6 = new MySqlParameter("FloatType", floatType.Text);
                MySqlParameter p7 = new MySqlParameter("FloatLength", floatLength.Text);
                MySqlParameter p8 = new MySqlParameter("FloatHeight", floatHeight.Text);
                MySqlParameter p9 = new MySqlParameter("FloatWidth", floatWidth.Text);
                MySqlParameter p10 = new MySqlParameter("Marchers", Marchers.Text);
                MySqlParameter p11 = new MySqlParameter("NoOfMarchers", noOfMarchers.Text);
                MySqlParameter p12 = new MySqlParameter("SoundSystem", SoundSystem.SelectedValue.ToString());
                MySqlParameter p13 = new MySqlParameter("WaiverAccepter", Acceptor.SelectedValue.ToString());
                MySqlParameter p14 = new MySqlParameter("Amount", Amount.Text);
                MySqlParameter p15 = new MySqlParameter("Status", Status.Text);
                MySqlParameter p16 = new MySqlParameter("entryno", EntryNo.Text);
                MySqlParameter p17 = new MySqlParameter("FloatDesc", Description.Text);
                MySqlParameter p18 = new MySqlParameter("Comments", scriptLbl.Text);
                MySqlParameter p19 = new MySqlParameter("Fees", Fees.SelectedValue.ToString());
                MySqlParameter p20 = new MySqlParameter("paradeID", getParadeID.ToString());
                MySqlParameter p21 = new MySqlParameter("entryCode", entryCode.Text);
                MySqlParameter p22 = new MySqlParameter("eBanner", banner.Text);
               
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
                cmd.Parameters.Add(p17);
                cmd.Parameters.Add(p18);
                cmd.Parameters.Add(p19);
                cmd.Parameters.Add(p20);
                cmd.Parameters.Add(p21);
                cmd.Parameters.Add(p22);

                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close(); con.Dispose();

                Response.Redirect("floatDetails.aspx", true);
                Response.Write("Float was created!");
            }
            catch (Exception ex)
            {
                Response.Write("");
            }

        }
        else
        {
            notChecked.Visible = true;
        }
    }
}