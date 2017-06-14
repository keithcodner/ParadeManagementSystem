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


public partial class viewParadeInfo : System.Web.UI.Page
{
    public static DataTable fullTable;
    static bool update = false;
    static string authNum;
    static string getSelect;
    static string getParadeName;
    static string getParadeID;
    static string getFileName;
    //needs to be modified when added to server
    static string uploadPath = "C:\\Users\\ikjblue\\Desktop\\Y3S5\\Capstone 2\\ParadeManagementSys2\\uploads\\";
    static string uploadVirtualPath =  "uploads\\";

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


        //--------------------selective or global selections----------------
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
        //--------get the parade ID fromget ParadeName from the config page -----------------
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
            if (getParadeID != null)
            {
                Response.Write("");
            }

        }

        if (getSelect == "Selective")
        {
            Label1.Text = "for the current parade";
            SqlDataSource1.SelectCommand = "SELECT porgid, uid, oOrganization, oContact, oPhone, oEmail, oWebsite, oActivation, oFileName FROM orginfo  WHERE paradeID='" + getParadeID + "';";

        }

        if (getSelect == "Global")
        {
            Label1.Text = "";
            SqlDataSource1.SelectCommand = "SELECT porgid, uid, oOrganization, oContact, oPhone, oEmail, oWebsite, oActivation, oFileName FROM  orginfo ;  ";
        }

        //GridView1.DataSource = fullTable;
        //GridView1.DataBind();
        ////////////////////////file download///////////////////////////


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

     //Search for organization
     if (key == "searchOrg")
     {
         Session.Remove("getOrgID");
         Session.Remove("SessionSearchOrg");


         int index = int.Parse(e.CommandArgument.ToString());
         GridView grid = (GridView)e.CommandSource;
         GridViewRow row = grid.Rows[index];

         TableCell tblCell = row.Cells[0];
         authNum = tblCell.Text;

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
             MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has searched for an organization with the ID [" + authNum + "].' );");
             cmd1.Connection = con1;
             MySqlDataReader reader3 = cmd1.ExecuteReader();
             con1.Close(); con1.Dispose();
         }
         catch (Exception ex)
         {


         }

         Session["getOrgID"] = authNum;
         Session["SessionSearchOrg"] = "SessionSearchOrg";
         //test.Text = Session["getUserID"].ToString();
         Response.Redirect("editParadeInfo.aspx");
     }

    //download from org table
     if (key == "Download")
     {
         int index = int.Parse(e.CommandArgument.ToString());
         GridView grid = (GridView)e.CommandSource;
         GridViewRow row = grid.Rows[index];

         TableCell tblCell = row.Cells[0];
         authNum = tblCell.Text;

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
             MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has downloaded a float details file name with the ID [" + authNum + "].' );");
             cmd1.Connection = con1;
             MySqlDataReader reader3 = cmd1.ExecuteReader();
             con1.Close(); con1.Dispose();
         }
         catch (Exception )
         {


         }

         //------ get the file name----------------------

         try
         {

             MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
             con.Open();
             MySqlCommand cmd = new MySqlCommand("SELECT oFileName FROM orginfo WHERE pOrgID = '" + authNum + "';");
             cmd.Connection = con;
             getFileName = (cmd.ExecuteScalar().ToString());
             con.Close(); con.Dispose();
         }
         catch (Exception ex)
         {

             Response.Write("");
         }

         if ((getFileName.Trim() == null) || (getFileName.Trim() == "") || (getFileName.Trim().Length == 0) || getFileName == "N/A" || getFileName == "N_A")
         {
             Response.Write("No file was found for this user.");
          
         }
         else
         {
             try
             {
                 Response.ContentType = "APPLICATION/OCTET-STREAM";
                 String Header = "Attachment; Filename=" + getFileName;
                 Response.AppendHeader("Content-Disposition", Header);

                 //needs to be modified when added to server
                 System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath(@uploadVirtualPath + getFileName));
                 Response.WriteFile(Dfile.FullName);
                 //Don't forget to add the following line
                 Response.End();
             }
             catch (Exception)
             {

                 Response.Write("No file was found for this user.");
             }
         }

         
     }
    }
}