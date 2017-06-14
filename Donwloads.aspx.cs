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

public partial class Donwloads : System.Web.UI.Page
{
    static string authNum;
    static string uploadServerFilePath = "uploads\\";
    
    //file name
    static string filename;
    static string getFileName;
    static String modifiedFileName;

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
    if (key == "DeleteDownload")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];
                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;

                try
                {

                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM download WHERE downloadID = '" + authNum + "';");
                    cmd.Connection = con;
                    MySqlDataReader reader3 = cmd.ExecuteReader();
                    con.Close(); con.Dispose();
                    GridView2.DataBind();
                }
                catch (Exception ex)
                {

                    Response.Write("");
                }

            }

            if (key == "Download")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];
                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;


                try
                {

                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT dFileName FROM download WHERE downloadID = '" + authNum + "';");
                    cmd.Connection = con;
                    getFileName = (cmd.ExecuteScalar().ToString());
                    con.Close(); con.Dispose();
                }
                catch (Exception ex)
                {

                    Response.Write("");
                }

                try
                {
                    Response.ContentType = "APPLICATION/OCTET-STREAM";
                    String Header = "Attachment; Filename=" + getFileName;
                    Response.AppendHeader("Content-Disposition", Header);

                    //needs to be modified when added to server
                    System.IO.FileInfo Dfile = new System.IO.FileInfo(Server.MapPath(@uploadServerFilePath + getFileName));
                    Response.WriteFile(Dfile.FullName);
                    //Don't forget to add the following line
                    Response.End();
                }
                catch (Exception)
                {

                    Response.Write("No file was found for this user.");
                }


            }

            if (key == "UpdateDownload")
            {
               addFile.Enabled = false;
               apply.Enabled = true;
               txtFileName.Enabled = false;
               uploadControl.Enabled = false;

               int index = int.Parse(e.CommandArgument.ToString());
               GridView grid = (GridView)e.CommandSource;
               GridViewRow row = grid.Rows[index];
               TableCell tblCell = row.Cells[0];
               authNum = tblCell.Text;

               

               TableCell place1 = row.Cells[3];
               txtFielDesc.Text = place1.Text.Replace("&#39;", "'").Replace("&nbsp;", "");

               TableCell place2 = row.Cells[4];
               DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf
                     (DropDownList1.Items.FindByText(place2.Text));


            }


    }

    protected void addFile_Click(object sender, EventArgs e)
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

        //try
        //{

        if ((uploadControl.PostedFile != null) && (uploadControl.HasFile != false) && (txtFileName.Text != "") && (txtFielDesc.Text != ""))
        {



            //for activity log
            try
            {
                //get date and time
              
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDates + "','" + fullTimes + "','" + Session["userSession"].ToString() + "','Administrator: " + Session["userSession"].ToString() + " has uploaded a new file.' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception)
            {

                Response.Write("Could not write to activity log. Issues connecting to database, please contact Admin or Start/Re-Start the database server.");
            }
            //////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////////////////////////////////

            try
            {
                //get date and time
                String hoursd = DateTime.Now.Hour.ToString();
                String minsd = DateTime.Now.Minute.ToString();
                String secsd = DateTime.Now.Second.ToString();

                String fullTimesd = hoursd + "" + minsd + "" + secsd;

                filename = uploadControl.PostedFile.FileName;

                filename = "_" + fullTimesd + "_" + filename.Replace(" ", "_");
                uploadControl.PostedFile.SaveAs(Server.MapPath(@uploadServerFilePath + txtFileName.Text + "_" + filename));

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertDownload";
                MySqlParameter p1 = new MySqlParameter("dFileName", txtFileName.Text + "_" + filename);
                MySqlParameter p2 = new MySqlParameter("dDescription", txtFielDesc.Text);
                MySqlParameter p3 = new MySqlParameter("dFileDate", fullDates);
                MySqlParameter p4 = new MySqlParameter("dFileUserType", DropDownList1.Text);

                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);

                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close(); con.Dispose();
                GridView2.DataBind();

                // Response.Redirect("addchangewaiveraspx.aspx");
                txtFileName.Text = "";
                txtFielDesc.Text = "";
                DropDownList1.SelectedIndex = 0;
                error.Text = "";
            }
            catch(Exception)
            {
            
            }
        }
        else 
        {
            error.Text = "File was NOT uploaded. You missed a text field or a file was not selected to be uploaded.";
        
        }
        

        //}
        //catch (Exception)
        //{

        //}


    }
    protected void apply_Click(object sender, EventArgs e)
    {
        try
        {
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE download SET dDescription= '" + txtFielDesc.Text + "', dFileUserType= '" + DropDownList1.Text + "' WHERE downloadID = '" + int.Parse(authNum) + "' ;");
            cmd.Connection = con;
            MySqlDataReader reader3 = cmd.ExecuteReader();
            con.Close(); reader3.Close();
            GridView2.DataBind();
            //clear text field
            addFile.Enabled =  true;
            apply.Enabled =  false;
            txtFileName.Enabled =  true;
            uploadControl.Enabled =  true;
            txtFielDesc.Text = "";
        }
        catch (Exception ex)
        {
            // error.Text = "it didnt work";

        }
    }
}