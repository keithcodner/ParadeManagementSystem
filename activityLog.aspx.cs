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

public partial class activityLog : System.Web.UI.Page
{
    static string authNum;
    static string getSUUsername;
    static string isExcludeErrorSelected;
    static bool isSuperAdmin = false;

    static string uploadPath = "C://ProgramData//1UPSolutionsParadeMS//";
    static string uploadVirtualPath = "1UPSolutionsParadeMS\\";


    protected void Page_Load(object sender, EventArgs e)
    {
        //session
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSession"].ToString();
        }

        //check to see if the user is super admin
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uUsername FROM user WHERE uStatus = 'Super-Administrator';");
            cmd.Connection = con;
            getSUUsername = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("You are not Super Admin. ");
        }

        //check to see if exclude errors is selected
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = '24';");
            cmd.Connection = con;
            isExcludeErrorSelected = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write(" ");
        }
        ////////////////////////////////////////////////////////////
        if (isExcludeErrorSelected == "False")
        {
            rbExcludeErrors.Checked = false;
        }


        if (isExcludeErrorSelected == "True")
        {
            rbExcludeErrors.Checked = true;
        }
        //////////////////////////////////////////////////////////
        if (rbExcludeErrors.Checked == true)
        {
            SqlDataSource2.SelectCommand = "SELECT ALID, aLDate, aLTime, aLUser, aLDesc FROM activityLog WHERE aLDesc NOT LIKE '%Error%' ORDER BY ALID DESC";
            GridView2.DataBind();
        }
        else 
        {
            SqlDataSource2.SelectCommand = "SELECT ALID, aLDate, aLTime, aLUser, aLDesc FROM activityLog ORDER BY ALID DESC";
            GridView2.DataBind();
        }

        //////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////
        if (getSUUsername == usernameSession.Text)
        {
            isSuperAdmin = true;
            
        }
        else 
        {
            isSuperAdmin = false;
            
        }

        //search


    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/
        try {/*get date and time*/String years = DateTime.Now.Year.ToString(); String months = DateTime.Now.Month.ToString(); String days = DateTime.Now.Day.ToString(); String hours = DateTime.Now.Hour.ToString(); String mins = DateTime.Now.Minute.ToString(); String secs = DateTime.Now.Second.ToString(); String fullDate = years + "-" + months + "-" + days; String fullTime = hours + ":" + mins + ":" + secs; MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString); con.Open(); MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has signed out.' );"); cmd.Connection = con; MySqlDataReader reader3 = cmd.ExecuteReader(); con.Close(); con.Dispose(); }
        catch (Exception ex) { } Session.Remove("userSession");
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx", true);
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    { 
            string key = e.CommandName;
            if (key == "DeleteLog")
            {

                if (isSuperAdmin == true)
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
                        MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has delete a log entry from the Activity Log with the ID[" + int.Parse(authNum) + "].' );");
                        cmd.Connection = con;
                        MySqlDataReader reader3 = cmd.ExecuteReader();
                        con.Close(); con.Dispose();
                    }
                    catch (Exception ex)
                    {


                    }

                    try
                    {
                        int index = int.Parse(e.CommandArgument.ToString());
                        GridView grid = (GridView)e.CommandSource;
                        GridViewRow row = grid.Rows[index];
                        TableCell tblCell = row.Cells[0];
                        authNum = tblCell.Text;




                        MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con.Open();
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM activityLog WHERE ALID = '" + int.Parse(authNum) + "';");
                        cmd.Connection = con;
                        MySqlDataReader reader3 = cmd.ExecuteReader();
                        con.Close(); reader3.Close();
                        GridView2.DataBind();

                    }
                    catch (Exception ex)
                    {


                    }
                }
                else 
                {
                    error.Text = "You are not the super administrator and cannot edit the activity Log.";
                }
            }


            if (key == "UpdateLog")
            {

                if (isSuperAdmin == true)
                {
                    logApplyBtn.Enabled = true;
                    cancel.Enabled = true;


                    try
                    {


                        int index = int.Parse(e.CommandArgument.ToString());
                        GridView grid = (GridView)e.CommandSource;
                        GridViewRow row = grid.Rows[index];
                        TableCell tblCell = row.Cells[0];
                        authNum = tblCell.Text;

                        TableCell place0 = row.Cells[3];
                        txtUsername.Text = place0.Text.Replace("&#39;", "'").Replace("&nbsp;", ""); ;

                        TableCell place1 = row.Cells[4];
                        txtLogDesc.Text = place1.Text.Replace("&#39;", "'").Replace("&nbsp;", ""); ;
                    }
                    catch (Exception ex)
                    {


                    }


                }
                else
                {
                    error.Text = "You are not the super administrator and cannot edit the activity Log.";
                }
                

            }
    }
    protected void cityApplyBtn_Click(object sender, EventArgs e)
    {

    }
    protected void cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("activityLog.aspx");
    }
    protected void logApplyBtn_Click(object sender, EventArgs e)
    {


        try
        {
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE activityLog SET aLUser= '" + txtUsername.Text + "', aLDesc= '" + txtLogDesc.Text + "' WHERE ALID = '" + int.Parse(authNum) + "' ;");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();
            GridView2.DataBind();
            //clear text field
            logApplyBtn.Enabled = false;
            cancel.Enabled = false;
        }
        catch (Exception ex)
        {
           // error.Text = "it didnt work";

        }
    }
    protected void search_Click(object sender, EventArgs e)
    {
        GridView2.AllowPaging = false;
        GridView2.AllowSorting = false;
        search.Focus();
        SqlDataSource2.SelectCommand = "SELECT ALID, aLDate, aLTime, aLUser, aLDesc FROM activityLog WHERE (aLUser LIKE '%" + searchTxt.Text.ToString() + "%' ) ORDER BY ALID DESC";
        if (rbDate.Checked)
        {
            SqlDataSource2.SelectCommand = "SELECT ALID, aLDate, aLTime, aLUser, aLDesc FROM activityLog WHERE (aLDate LIKE '%" + searchTxt.Text.ToString() + "%' ) ORDER BY ALID DESC";
        }
        else if (rbTime.Checked)
        {
            SqlDataSource2.SelectCommand = "SELECT ALID, aLDate, aLTime, aLUser, aLDesc FROM activityLog WHERE (aLTime LIKE '%" + searchTxt.Text.ToString() + "%' ) ORDER BY ALID DESC";
        }
        else if (rbDesc.Checked)
        {
            SqlDataSource2.SelectCommand = "SELECT ALID, aLDate, aLTime, aLUser, aLDesc FROM activityLog WHERE (aLDesc LIKE '%" + searchTxt.Text.ToString() + "%' ) ORDER BY ALID DESC";
        }

        else if (rbUser.Checked)
        {
            SqlDataSource2.SelectCommand = "SELECT ALID, aLDate, aLTime, aLUser, aLDesc FROM activityLog WHERE (aLUser LIKE '%" + searchTxt.Text.ToString() + "%' ) ORDER BY ALID DESC";
        }
        else 
        {
            SqlDataSource2.SelectCommand = "SELECT ALID, aLDate, aLTime, aLUser, aLDesc FROM activityLog WHERE (aLUser LIKE '%" + searchTxt.Text.ToString() + "%' ) ORDER BY ALID DESC";
        }
        GridView2.DataBind();
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

            string fileName = "ParadeMSActivityLogTable" + "_" + fullDate1 + "_" + fullTime1 + ".csv";

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * INTO OUTFILE '" + uploadPath + fileName + "' FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '\"'LINES TERMINATED BY '\n' FROM activityLog;", con);
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
    protected void excludeReset_Click(object sender, EventArgs e)
    {
        rbExcludeErrors.Checked = false;

        try
        {
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value= 'False' WHERE configID = '24' ;");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();
            GridView2.DataBind();
          
        }
        catch (Exception ex)
        {
            // error.Text = "it didnt work";

        }
        Response.Write("Page Refreshing...");
        Response.AddHeader("REFRESH", "1;URL= activityLog.aspx");
    }
    protected void rbExcludeErrors_CheckedChanged(object sender, EventArgs e)
    {

        try
        {
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE pageconfig SET value= 'True' WHERE configID = '24' ;");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();
            GridView2.DataBind();

        }
        catch (Exception ex)
        {
            // error.Text = "it didnt work";

        }
        Response.Write("Page Refreshing...");
        Response.AddHeader("REFRESH", "1;URL= activityLog.aspx");
    }
}