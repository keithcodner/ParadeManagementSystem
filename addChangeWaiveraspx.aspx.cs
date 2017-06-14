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

public partial class addChangeWaiveraspx : System.Web.UI.Page
{
    public static DataTable fullTable;
    static bool update = false;
    static string authNum;
    static string doesWaiverNameExist;
    static string nbsp = "&nbsp;";

    protected void Page_Load(object sender, EventArgs e)
    {
        applyUpdate.Enabled = false;

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
    protected void BannerBtn_Click(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string key = e.CommandName;
        if (key == "DeleteWaiver")
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has deleted a waiver with the ID[" + int.Parse(authNum) + "]. ' );");
                cmd1.Connection = con1;
                MySqlDataReader reader3 = cmd1.ExecuteReader();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {


            }

            //need this to connect to mysql database from here to
            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                //get name of stored procedure
                cmd.CommandText = "DeleteWaiver";
                //here

                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];

                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;
                MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
                cmd.Parameters.Add(p1);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close(); con.Dispose();
                GridView1.DataBind();
                BannerBtn.Enabled = true;
            }
            catch (Exception ex)
            {
                
                
            }
           
        }
        if (key == "UpdateWaiver")
        {
            try
            {
                DropDownList1.Enabled = true;
                DropDownList1.SelectedIndex = 1;

                update = true;
                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];
                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;

                TableCell place0 = row.Cells[1];
                DropDownList1.Text = place0.Text.Replace("&#39;", "'");

                TableCell place1 = row.Cells[2];
                waiverEditTitle.Text = place1.Text;
                waiverEditTitle.Text = place1.Text.Replace("&#39;", "'");
                waiverEditTitle.Text = waiverEditTitle.Text.Replace(nbsp, "");

                TableCell place2 = row.Cells[3];
                waiverEditBody.Text = place2.Text.Replace("&#39;", "'");

                waiverEditBody.Text = waiverEditBody.Text.Replace(nbsp, "");

                if (waiverEditTitle.Text.Equals("&nbsp;"))
                {
                    waiverEditTitle.Text = "";
                }
                if (waiverEditBody.Equals("&nbsp;"))
                {
                    waiverEditBody.Text = "";
                }


                //place2.Text = place2.Text.


                BannerBtn.Enabled = false;
                applyUpdate.Enabled = true;
            }
            catch (Exception ex)
            {
                
                
            }
            
        }
        
    }

    protected void BannerBtn_Click1(object sender, EventArgs e)
    {

        //if YES - org name
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "checkWaiverName";
            MySqlParameter p1 = new MySqlParameter("chckWaiverName", waiverEditTitle.Text);

            //MySqlParameter p3 = new MySqlParameter("ofTypeAdmin", p);
            cmd.Parameters.Add(p1);


            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows && waiverEditTitle.Text != null)
            {

                doesWaiverNameExist = "Yes";

               

            }
            else
            {
                doesWaiverNameExist = "No";
            }


            reader.Close();
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {


        }

        if (doesWaiverNameExist  == "Yes")
        {

            checkIfNameExists.Text = "*The waiver name already exits, please choose another.";

            
        }
        else 
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has added a waiver with the title [" + waiverEditTitle.Text + "]. ' );");
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
                cmd.CommandText = "insertWaiver";
                MySqlParameter p1 = new MySqlParameter("eName", waiverEditTitle.Text);
                MySqlParameter p2 = new MySqlParameter("eWaiver", waiverEditBody.Text);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                MySqlDataReader reader = cmd.ExecuteReader();
                reader.Close();
                con.Close(); con.Dispose();
                Response.Redirect("addchangewaiveraspx.aspx");

            }
            catch (Exception ex)
            {

                Response.Write("");
            }
        }

        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void applyUpdate_Click(object sender, EventArgs e)
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
            MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has made changes to a waiver/about with ID[" + int.Parse(authNum) + "]. ' );");
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
            cmd.CommandText = "UpdateWaiver";
            MySqlParameter p1 = new MySqlParameter("eWName", waiverEditTitle.Text);
            MySqlParameter p2 = new MySqlParameter("eWWaiver", waiverEditBody.Text);
            MySqlParameter p3 = new MySqlParameter("eID", int.Parse(authNum));
            MySqlParameter p4 = new MySqlParameter("eWType", DropDownList1.Text);

            cmd.Parameters.Add(p4);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            con.Close(); con.Dispose();
            GridView1.DataBind();
            // Response.Redirect("addchangewaiveraspx.aspx");
            waiverEditTitle.Text = "";
            waiverEditBody.Text = "";

            applyUpdate.Enabled = false;
            BannerBtn.Enabled = true;

        }
        catch(Exception)
        {
        
        }
        DropDownList1.Enabled = false;
    }
}