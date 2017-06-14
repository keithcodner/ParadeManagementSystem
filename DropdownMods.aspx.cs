using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.IO;
using System.Drawing;
using System.Web.Security;


public partial class DropdownMods : System.Web.UI.Page
{
    static string authNum;

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
    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/ try{/*get date and time*/String years = DateTime.Now.Year.ToString();String months = DateTime.Now.Month.ToString();String days = DateTime.Now.Day.ToString();String hours = DateTime.Now.Hour.ToString();String mins = DateTime.Now.Minute.ToString();String secs = DateTime.Now.Second.ToString();String fullDate = years + "-" + months + "-" + days;String fullTime = hours + ":" + mins + ":" + secs;MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);con.Open();MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has signed out.' );");cmd.Connection = con;MySqlDataReader reader3 = cmd.ExecuteReader();con.Close(); con.Dispose();}catch (Exception ex){}Session.Remove("userSession");
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx", true);
        }
    }
    /*
  * //ENTRY TYPE DROPDOWN MODIFICATION
  * /////////////////////////////////////////////////////////////////////////////////////////////////
  * /////////////////////////////////////////////////////////////////////////////////////////////////
  */
    protected void cityBtn_Click(object sender, EventArgs e)
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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has added [" + txtCity.Text + "] to the Entry Type drop down list.' );");
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
            MySqlCommand cmd = new MySqlCommand("INSERT INTO ddEntryType (EntryType) VALUES ('" + txtCity.Text + "'); ");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();
            GridView2.DataBind();
            //clear text field
            txtCity.Text = "";
        }
        catch (Exception ex)
        {


        }
    }
    protected void cityApplyBtn_Click(object sender, EventArgs e)
    {
        //change buttons when apply is selected
        cityApplyBtn.Enabled = false;
        cityBtn.Enabled = true;

        //change label
        cityLbl.Text = "Add";

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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has modified the entry type drop down list item with the ID[" + int.Parse(authNum) + "]' );");
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
            MySqlCommand cmd = new MySqlCommand("UPDATE ddEntryType SET EntryType= '" + txtCity.Text + "' WHERE ddEntryTypeID = '" + int.Parse(authNum) + "' ;");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();
            GridView2.DataBind();
            //clear text field
            txtCity.Text = "";
        }
        catch (Exception ex)
        {


        }


    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    { 
     string key = e.CommandName;
     if (key == "DeleteEntryType")
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
             MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has deleted the entry type drop down list item with the ID[" + int.Parse(authNum) + "]' );");
             cmd1.Connection = con1;
             MySqlDataReader reader3 = cmd1.ExecuteReader();
             con1.Close(); con1.Dispose();
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
             MySqlCommand cmd = new MySqlCommand("DELETE FROM ddEntryType WHERE ddEntryTypeID = '" + int.Parse(authNum) + "';");
             cmd.Connection = con;
             MySqlDataReader reader3 = cmd.ExecuteReader();
             con.Close(); reader3.Close();
             GridView2.DataBind();
             //clear text field
             txtCity.Text = "";
         }
         catch (Exception ex)
         {


         }
     }

     if (key == "UpdateEntryType")
     {
         cityLbl.Text = "Modify";

         try
         {
             //change buttons when modify is selected
             cityApplyBtn.Enabled = true;
             cityBtn.Enabled = false;

             int index = int.Parse(e.CommandArgument.ToString());
             GridView grid = (GridView)e.CommandSource;
             GridViewRow row = grid.Rows[index];
             TableCell tblCell = row.Cells[0];
             authNum = tblCell.Text;

             TableCell place0 = row.Cells[1];
             txtCity.Text = place0.Text.Replace("&#39;", "'").Replace("&nbsp;",""); ;
         }
         catch (Exception ex)
         {
             
          
         }


         
     }

    }
    /*
     * //FLOAT TYPE DROPDOWN MODIFICATION
     * /////////////////////////////////////////////////////////////////////////////////////////////////
     * /////////////////////////////////////////////////////////////////////////////////////////////////
     */
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string key = e.CommandName;
        if (key == "DeleteFloatType")
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has deleted the float type drop down list item with the ID[" + int.Parse(authNum) + "]' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
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
                MySqlCommand cmd = new MySqlCommand("DELETE FROM ddFloatType WHERE ddFloatTypeID = '" + int.Parse(authNum) + "';");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); reader3.Close();
                GridView4.DataBind();
                //clear text field
                txtFloatType.Text = "";
            }
            catch (Exception ex)
            {


            }
        }

        if (key == "UpdateFloatType")
        {
            floatTypeLbl.Text = "Modify";

            try
            {
                //change buttons when modify is selected
                applyFloatType.Enabled = true;
                addFloatType.Enabled = false;

                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];
                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;

                TableCell place0 = row.Cells[1];
                txtFloatType.Text = place0.Text.Replace("&#39;", "'").Replace("&nbsp;", ""); ;
            }
            catch (Exception ex)
            {


            }



        }
    }
    protected void addFloatType_Click(object sender, EventArgs e)
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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has added [" + txtFloatType.Text + "] to the Float Type drop down list.' );");
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
            MySqlCommand cmd = new MySqlCommand("INSERT INTO ddFloatType (FloatType) VALUES ('" + txtFloatType.Text + "'); ");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();
            GridView4.DataBind();
            //clear text field
            txtFloatType.Text = "";
        }
        catch (Exception ex)
        {


        }
    }
    protected void applyFloatType_Click(object sender, EventArgs e)
    {
        //change buttons when apply is selected
        applyFloatType.Enabled = false;
        addFloatType.Enabled = true;

        //change label
        floatTypeLbl.Text = "Add";

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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has modified the float type drop down list item with the ID[" + int.Parse(authNum) + "]' );");
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
            MySqlCommand cmd = new MySqlCommand("UPDATE ddFloatType SET FloatType= '" + txtFloatType.Text + "' WHERE ddFloatTypeID = '" + int.Parse(authNum) + "' ;");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();
            GridView4.DataBind();
            //clear text field
            txtFloatType.Text = "";
        }
        catch (Exception ex)
        {


        }
    }

    /*
    * //STATUS DROPDOWN MODIFICATION
    * /////////////////////////////////////////////////////////////////////////////////////////////////
    * /////////////////////////////////////////////////////////////////////////////////////////////////
    */
    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string key = e.CommandName;
        if (key == "DeleteStatus")
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has deleted the status drop down list item with the ID[" + int.Parse(authNum) + "]' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
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
                MySqlCommand cmd = new MySqlCommand("DELETE FROM ddStatus WHERE ddStatusID = '" + int.Parse(authNum) + "';");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); reader3.Close();
                GridView3.DataBind();
                //clear text field
                txtStatus.Text = "";
            }
            catch (Exception ex)
            {


            }
        }

        if (key == "UpdateStatus")
        {
            StatusLbl.Text = "Modify";

            try
            {
                //change buttons when modify is selected
                applyStatus.Enabled = true;
                addStatus.Enabled = false;

                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];
                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;

                TableCell place0 = row.Cells[1];
                txtStatus.Text = place0.Text.Replace("&#39;", "'").Replace("&nbsp;", ""); ;
            }
            catch (Exception ex)
            {


            }



        }
    }
    protected void addStatus_Click(object sender, EventArgs e)
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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has added  [" + txtStatus.Text + "] to the Status drop down list.' );");
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
            MySqlCommand cmd = new MySqlCommand("INSERT INTO ddStatus (Status) VALUES ('" + txtStatus.Text + "'); ");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();
            GridView3.DataBind();
            //clear text field
            txtStatus.Text = "";
        }
        catch (Exception ex)
        {


        }
    }
    protected void applyStatus_Click(object sender, EventArgs e)
    {
        //change buttons when apply is selected
        applyStatus.Enabled = false;
        addStatus.Enabled = true;

        //change label
        StatusLbl.Text = "Add";

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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has modified the status drop down list item with the ID[" + int.Parse(authNum) + "]' );");
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
            MySqlCommand cmd = new MySqlCommand("UPDATE ddStatus SET Status = '" + txtStatus.Text + "' WHERE ddStatusID = '" + int.Parse(authNum) + "' ;");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();
            GridView3.DataBind();
            //clear text field
            txtStatus.Text = "";
        }
        catch (Exception ex)
        {


        }
    }
}