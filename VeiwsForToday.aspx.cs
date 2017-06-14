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


public partial class VeiwsForToday : System.Web.UI.Page
{
    static string getCurrentParaeID;

    //global variables
    static bool update = false;
    static string authNum;
    static string confirmType;

    static String years = DateTime.Now.Year.ToString();
    static String months = DateTime.Now.Month.ToString();
    static String days = DateTime.Now.Day.ToString();
    static String hours = DateTime.Now.Hour.ToString();
    static String mins = DateTime.Now.Minute.ToString();
    static String secs = DateTime.Now.Second.ToString();
    static String fullDate = years + "-" + months + "-" + days;
    static String fullTime = hours + ":" + mins + ":" + secs;
    //   test.Text = fullDate + " " + fullTime;

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

        spare.Visible = false;


        //get the current parade
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT IDs FROM pageconfig WHERE configID = 10 ;");
            cmd.Connection = con;
            getCurrentParaeID = Convert.ToString(cmd.ExecuteScalar());

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
        ////////////////////////session determines whats displayed/////////////////////////////////
        
        //if user is selected
        if (Session["User"] == "User" && Session["Org"] == null)
        {
            orgOrUSer.Text = "Users Added Today";
            orgOrUser2.Text = "users";
            orgTable.Visible = false;
            SqlDataSource1.SelectCommand = "SELECT uID, uUsername, uFName, uLName, uEmail, uStatus FROM user WHERE uDateJoined = '" + fullDate + "'  AND paradeID = '" + getCurrentParaeID.ToString() + "' ; ";
        }

        //if user is selected
        if (Session["User"] == null && Session["Org"] == "Org")
        {
            orgOrUSer.Text = "Organizations Added Today";
            orgOrUser2.Text = "organizations";
            userTable.Visible = false;
            SqlDataSource1.SelectCommand = "SELECT pOrgID, oOrganization, oContact, oPhone, oEmail, oActivation FROM orginfo WHERE oDateJoined = '" + fullDate + "' AND paradeID = '" + getCurrentParaeID.ToString() + "'; ";
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

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string key = e.CommandName;

       

        //Search
        if (key == "searchUser")
        {
            Session.Remove("getUserID");
            Session.Remove("SessionSearch");

            int index = int.Parse(e.CommandArgument.ToString());
            GridView grid = (GridView)e.CommandSource;
            GridViewRow row = grid.Rows[index];

            TableCell tblCell = row.Cells[0];
            authNum = tblCell.Text;

            Session["getUserID"] = authNum;
            Session["SessionSearch"] = "SessionSearch";
            //test.Text = Session["getUserID"].ToString();
            Response.Redirect("editOrDeleteUser.aspx");
        }

        
    }


    protected void GridView1_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        string keys = e.CommandName;

        //Search for organization
        if (keys == "searchOrg")
        {
            Session.Remove("getOrgID");
            Session.Remove("SessionSearchOrg");

            int index = int.Parse(e.CommandArgument.ToString());
            GridView grid = (GridView)e.CommandSource;
            GridViewRow row = grid.Rows[index];

            TableCell tblCell = row.Cells[0];
            authNum = tblCell.Text;

            Session["getOrgID"] = authNum;
            Session["SessionSearchOrg"] = "SessionSearchOrg";
            //test.Text = Session["getUserID"].ToString();
            Response.Redirect("editParadeInfo.aspx");
        }
    }
   
}