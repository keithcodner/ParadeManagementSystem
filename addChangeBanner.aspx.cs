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

public partial class addChangeBanner : System.Web.UI.Page
{
    public static DataTable fullTable;
    static bool update = false;
    static bool displayOrDelete = false;
    static string authNum;
    public static object temps;
    static string uploadServerFilePath = "images\\";

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

       
       // leftBanner.Checked = true;
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
        //bannerNametxt
        //bannerDesctxt
        //bannerFileUpload

        if (bannerFileUpload.HasFile && (bannerFileUpload.PostedFile != null))
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has added an image to the banner database.[" + bannerNametxt.Text + "] ' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

            try
            {
                String bannerName = bannerNametxt.Text;
                String bannerDesc = bannerDesctxt.Text;
                byte[] bannerFile = bannerFileUpload.FileBytes;

                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insertBanner";
                MySqlParameter p1 = new MySqlParameter("eName", bannerName);
                MySqlParameter p2 = new MySqlParameter("eDesc", bannerDesc);
                MySqlParameter p3 = new MySqlParameter("eBanner", bannerFile);

                //MySqlParameter p3 = new MySqlParameter("ofTypeAdmin", p);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                MySqlDataReader reader = cmd.ExecuteReader();
                // int result = cmd.ExecuteNonQuery();
                reader.Close();
                con.Close();  con.Dispose();
                //Response.Redirect("adminArea.aspx", true);
                Response.Redirect("addChangeBanner.aspx");
            }
            catch (Exception ex)
            {

                Response.Write("");
            }
            
        }


    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        

        string key = e.CommandName;

        //delete Banner
        if (key == "DeleteBanner")
        {
            ConfirmBtn.Enabled = true;
            AlertLbl.Text = "By clicking confirm, you are deleting this Banner from the Parade Management System and it cannot be recovered. Do you confirm these changes?";
            confirmPanel.Visible = true;
            //  GridView1.Visible = false;
            GridView1.Enabled = false;
            BannerBtn.Enabled = false;

            int index = int.Parse(e.CommandArgument.ToString());
            GridView grid = (GridView)e.CommandSource;
            GridViewRow row = grid.Rows[index];

            TableCell tblCell = row.Cells[0];
            authNum = tblCell.Text;

            displayOrDelete = false;
           
        }

        if (key == "Preview")
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has previewed an image with the ID[" + authNum + "]. ' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

            try
            {
                    update = true;
                    int index = int.Parse(e.CommandArgument.ToString());
                    GridView grid = (GridView)e.CommandSource;
                    GridViewRow row = grid.Rows[index];
                    TableCell tblCell = row.Cells[0];
                    authNum = tblCell.Text;

                    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT banner FROM bannerTable WHERE bannerID = '" + authNum + "';");
                    cmd.Connection = con;

                    temps = (cmd.ExecuteScalar());
                    
                    //Change directory to where the banner was stored


                    System.IO.File.WriteAllBytes(Server.MapPath(@uploadServerFilePath + "preview.png"), (byte[])temps);
                    con.Close(); con.Dispose();
                   
                }
                catch (Exception ex)
                {

                    Response.Write("");
                }

            Image5.ImageUrl = "images\\preview.png" + "?" + "ts=" + Server.UrlEncode(DateTime.Now.Ticks.ToString());
            //Image5.ImageUrl = "images\\preview.png";
            //Response.Redirect("addChangeBanner.aspx");
        }

        
        //get image
        if (key == "Image")
        {
            ConfirmBtn.Enabled = true;
                AlertLbl.Text = "By clicking confirm, you will change all publicly seen Banners to this image. Do you confirm these changes?";
                confirmPanel.Visible = true;
                //  GridView1.Visible = false;
                GridView1.Enabled = false;
                BannerBtn.Enabled = false;

                update = true;
                int index = int.Parse(e.CommandArgument.ToString());
                GridView grid = (GridView)e.CommandSource;
                GridViewRow row = grid.Rows[index];
                TableCell tblCell = row.Cells[0];
                authNum = tblCell.Text;

                displayOrDelete = true;

                if ((!leftBanner.Checked ) && (!rightBanner.Checked ))
                {
                    AlertLbl.Text = "Oops! You forgot step one.Please choose 'Cancel' and select a banner you wish to change in 'Step 1.'";
                    ConfirmBtn.Enabled = false;
                }
          
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
       
    }
    protected void ConfirmBtn_Click(object sender, EventArgs e)
    {
        //this path will be temporarily used for testing, subject to change when on the server
        if (AlertLbl.Text == "")
        {
            
            
        }
       

        if (leftBanner.Checked && displayOrDelete == true)
        {
            //if (displayOrDelete == true)
            //{

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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has changed the left banner with the ID[" + authNum + "]. ' );");
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
                    MySqlCommand cmd = new MySqlCommand("SELECT banner FROM bannerTable WHERE bannerID = '" + authNum + "';");
                    cmd.Connection = con;

                    temps = (cmd.ExecuteScalar());
                    
                    //Change directory to where the banner was stored


                    System.IO.File.WriteAllBytes(Server.MapPath(@uploadServerFilePath + "mypic.png"), (byte[])temps);
                    con.Close(); con.Dispose();
                    AlertLbl.Text = "";
                    confirmPanel.Visible = false;
                    //  GridView1.Visible = false;
                    GridView1.Enabled = true;
                    BannerBtn.Enabled = true;

                 


                }
                catch (Exception ex)
                {

                    Response.Write("");
                }
            //}

                Image1.ImageUrl = "images\\mypic.png" + "?" + "tss=" + Server.UrlEncode(DateTime.Now.Ticks.ToString());
                Response.Redirect("addChangeBanner.aspx");
        }


        if (rightBanner.Checked && displayOrDelete == true)
        {
            //if (displayOrDelete == true)
            //{

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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has changed the right banner with the ID[" + authNum + "]. ' );");
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
                    MySqlCommand cmd = new MySqlCommand("SELECT banner FROM bannerTable WHERE bannerID = '" + authNum + "';");
                    cmd.Connection = con;

                    temps = (cmd.ExecuteScalar());
                    
                    //Change directory to where the banner was stored


                    System.IO.File.WriteAllBytes(Server.MapPath(@uploadServerFilePath + "santaface.JPG"), (byte[])temps);
                    con.Close(); con.Dispose();

                    AlertLbl.Text = "";
                    confirmPanel.Visible = false;
                    //  GridView1.Visible = false;
                    GridView1.Enabled = true;
                    BannerBtn.Enabled = true;

                    


                }
                catch (Exception ex)
                {

                    Response.Write("");
                }
           // }
                Image3.ImageUrl = "images\\santaface.JPG" + "?" + "tsss=" + Server.UrlEncode(DateTime.Now.Ticks.ToString());
                Response.Redirect("addChangeBanner.aspx");
        }
        

        if (displayOrDelete == false)
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
                MySqlCommand cmd1 = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " Has deleted an image with the ID[" + authNum + "]. ' );");
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
            cmd.CommandText = "DeleteBanner";
            //here


            MySqlParameter p1 = new MySqlParameter("eID", int.Parse(authNum));
            cmd.Parameters.Add(p1);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            con.Close(); con.Dispose();
            GridView1.DataBind();

            AlertLbl.Text = "";
            confirmPanel.Visible = false;
            //  GridView1.Visible = false;
            GridView1.Enabled = true;
            BannerBtn.Enabled = true;
        }

        Response.Redirect("addChangeBanner.aspx");
    }
    protected void CanelBtn_Click(object sender, EventArgs e)
    {
        AlertLbl.Text = "";
        confirmPanel.Visible = false;
        //  GridView1.Visible = false;
        GridView1.Enabled = true;
        BannerBtn.Enabled = true;
    }
}