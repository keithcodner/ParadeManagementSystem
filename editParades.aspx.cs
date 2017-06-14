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

public partial class editParades : System.Web.UI.Page
{
    //global variables
    static bool update = false;
    static string authNum;
    static string confirmType;
    //for delete command
    static string getConfrimCmd;
    static string maxID;
    static string maxContactID;
    static string test; 
    //for make current parade
    static string getParadeName;
    static string nbsp = "&nbsp;";

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

        //get the current parade
        try
        {
             
            MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con1.Open();
            MySqlCommand cmd1 = new MySqlCommand("SELECT value FROM pageconfig WHERE configID =10;");
            cmd1.Connection = con1;
            currentParade.Text = (cmd1.ExecuteScalar().ToString());
            con1.Close(); con1.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        Button2.Enabled = false;

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
        //Delete Command
        string key = e.CommandName;
        if (key == "DeleteParade")
        {

            AlertLbl.Text = "By clicking confirm, you are deleting this parade from the Parade Management System and it cannot be recovered and is NOT recommended.All Organizations and Floats related to this parade will be deleted. Are you absolutely sure you confirm these changes?";
            confirmPanel.Visible = true;
            //  GridView1.Visible = false;
            GridView1.Enabled = false;
            Button2.Enabled = false;
            searchBtn.Enabled = false;
            advSearch.Enabled = false;

            int index = int.Parse(e.CommandArgument.ToString());
            GridView grid = (GridView)e.CommandSource;
            GridViewRow row = grid.Rows[index];

            TableCell tblCell = row.Cells[0];
            authNum = tblCell.Text;


            confirmType = "Delete";


        }
        // make current Command
        if (key == "makeCurrent")
        {

            AlertLbl.Text = "By clicking confirm, you are making this parade current.All view/editing pages that contain float and organization details will only display information on this current parade you are selecting. Do you confirm these changes?";
            confirmPanel.Visible = true;
            //  GridView1.Visible = false;
            GridView1.Enabled = false;
            Button2.Enabled = false;
            searchBtn.Enabled = false;
            advSearch.Enabled = false;

            int index = int.Parse(e.CommandArgument.ToString());
            GridView grid = (GridView)e.CommandSource;
            GridViewRow row = grid.Rows[index];

            TableCell tblCell = row.Cells[0];
            authNum = tblCell.Text;


            confirmType = "Current";


        }

        //Update Command

        if (key == "UpdateParade")
        {
            Button2.Enabled = true;
            update = true;
            int index = int.Parse(e.CommandArgument.ToString());
            GridView grid = (GridView)e.CommandSource;
            GridViewRow row = grid.Rows[index];

            TableCell tblCell = row.Cells[0];
            authNum = tblCell.Text;

            TableCell place1 = row.Cells[1];
            paradeName.Text = place1.Text.Replace(nbsp, "");

            TableCell place2 = row.Cells[2];
            paradeYear.Text = place2.Text.Replace(nbsp, "");

            TableCell place3 = row.Cells[3];
            paradeType.Text = place3.Text.Replace(nbsp, "");

            TableCell place4 = row.Cells[4];
            paradeDate.Text = place4.Text.Replace(nbsp, "");

            TableCell place5 = row.Cells[5];
            paradeStartTime.Text = place5.Text.Replace(nbsp, "");

            TableCell place6 = row.Cells[6];
            paradeEndTime.Text = place6.Text.Replace(nbsp, "");
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //parade confirmation
        AlertLbl.Text = "By clicking Apply, you are updatting this parade in the Parade Management System. Data cannot be reverted once changes have been made. Do you confirm these changes?";
        confirmPanel.Visible = true;
        //  GridView1.Visible = false;
        GridView1.Enabled = false;
        Button2.Enabled = false;
        searchBtn.Enabled = false;
        advSearch.Enabled = false;

        confirmType = "Update";
    }
    protected void searchBtn_Click(object sender, EventArgs e)
    {
        try
        {

            GridView1.AllowPaging = false;
            GridView1.AllowSorting = false;

            //advance search options
            if (cParadeName.Checked)
            {
                searchedTable.SelectCommand = "SELECT paradeID, paradeName, paradeYear, paradeType, paradeDate, paradeStartTime, paradeEndTime FROM parade  WHERE (paradeName LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Parade Name";
            }
            else if (cParadeYear.Checked)
            {
                searchedTable.SelectCommand = "SELECT paradeID, paradeName, paradeYear, paradeType, paradeDate, paradeStartTime, paradeEndTime FROM parade  WHERE (paradeYear LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Parade Year";
            }
            else if (cParadeType.Checked)
            {
                searchedTable.SelectCommand = "SELECT paradeID, paradeName, paradeYear, paradeType, paradeDate, paradeStartTime, paradeEndTime FROM parade  WHERE (paradeType LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Parade Type";
            }

            else if (cParadeDate.Checked)
            {
                searchedTable.SelectCommand = "SELECT paradeID, paradeName, paradeYear, paradeType, paradeDate, paradeStartTime, paradeEndTime FROM parade  WHERE (paradeDate LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Parade Date";
            }

            else if (cParadeStartTime.Checked)
            {
                searchedTable.SelectCommand = "SELECT paradeID, paradeName, paradeYear, paradeType, paradeDate, paradeStartTime, paradeEndTime FROM parade WHERE (paradeStartTime LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Start Time";
            }

            else if (cParadeEndTime.Checked)
            {
                searchedTable.SelectCommand = "SELECT paradeID, paradeName, paradeYear, paradeType, paradeDate, paradeStartTime, paradeEndTime FROM parade  WHERE (paradeEndTime LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "End Time";
            }
            else 
            {
                searchedTable.SelectCommand = "SELECT paradeID, paradeName, paradeYear, paradeType, paradeDate, paradeStartTime, paradeEndTime FROM parade  WHERE (paradeName LIKE '%" + searchTxt.Text.ToString() + "%' )";
                searchLbl.Text = "Parade Name";
            }

            GridView1.DataSourceID = "searchedTable";
        }
        catch (Exception ex)
        {
            Response.Write("");
        }
    }
    protected void advSearch_Click(object sender, EventArgs e)
    {
        advSearchPanel.Visible = true;
    }
    protected void ConfirmBtn_Click(object sender, EventArgs e)
    {
        //Delete float table data with the same paradeID
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has deleted a parade with ID [" + int.Parse(authNum) + "].' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

            ////////DELETE FLOATS RELATED TO THE ORGS/////////////////////////

            try
            {
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(" SELECT DISTINCT floatID FROM floatdetails f, orginfo o, parade p WHERE f.paradeID = p.paradeID AND o.paradeID = p.paradeID AND p.paradeID = '" + int.Parse(authNum) + "' ;");
                cmd.Connection = con;
                MySqlDataReader reader = cmd.ExecuteReader();

                //Deletes row from the float
                if (reader.HasRows)
                {
                    while (reader.Read() && reader.HasRows)
                    {
                        //was for testing purposes
                       // test.Text = reader.GetString(0);
                        test = reader.GetString(0);

                         
                        MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                        con1.Open();
                        MySqlCommand cmd1 = new MySqlCommand(" DELETE FROM floatDetails WHERE floatID = '" + test + "' ;");
                        cmd1.Connection = con1;
                        MySqlDataReader reader1 = cmd1.ExecuteReader();
                        con1.Close(); con1.Dispose(); reader1.Close();
                    }
                }
                else
                {
                    test = "No rows found";
                }

                con.Close(); con.Dispose(); reader.Close();

            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            /////////DELETE ORG THAT HAS THE SAME PARADE ID ///////////////
             
            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("DELETE FROM orginfo WHERE paradeID = '" + int.Parse(authNum) + "'");
                cmd1.Connection = con1;
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                reader1.Close();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //////////////////////DELETEING THE PARADE///////////////////////////////////////
            try
            {
                //need this to connect to mysql database from here to
                 
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                //get name of stored procedure
                cmd.CommandText = "DeleteParade";
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
                Button2.Enabled = true;
                searchBtn.Enabled = true;
                advSearch.Enabled = true;

                confirmType = "";
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            ///////////////////////////////////////////////////////////////
            //////pageconfig current parade setter after deletion
            ///////////////////////////////////////////////////////////////

            /////////Set the max id to be inserted into the parade table//////// 


            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT MAX(paradeID) FROM parade;");
                cmd1.Connection = con1;
                maxID = (cmd1.ExecuteScalar().ToString());
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            ///////////////////get contact and store in string/////////////////
            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT paradeName FROM parade WHERE paradeID = '" + maxID + "'; ");
                cmd1.Connection = con1;
                maxContactID = (cmd1.ExecuteScalar().ToString());
                searchLbl.Text = maxContactID;
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {
                if (maxContactID == null)
                {
                    Response.Write("There are no parades.");
                    currentParade.Text = "";
                }
                else 
                {
                    Response.Write("");
                    currentParade.Text = "";
                }
                
            }

            /////////////////////update the current parade/////////////////
            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("UPDATE pageconfig SET value = '" + maxContactID + "' WHERE  configID = 10");
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

        //Make current parade

        if (confirmType == "Current")
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has set the current parade to [" + getParadeName + "].' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

            //set the parade
            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("SELECT paradeName FROM parade WHERE paradeID ='" + int.Parse(authNum) + "';");
                cmd1.Connection = con1;
                getParadeName = (cmd1.ExecuteScalar().ToString());
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }



            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("UPDATE pageconfig SET value = '" + getParadeName + "' WHERE  configID = 10");
                cmd1.Connection = con1;
                MySqlDataReader reader1 = cmd1.ExecuteReader();
                reader1.Close();
                con1.Close(); con1.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            try
            {
                 
                MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con1.Open();
                MySqlCommand cmd1 = new MySqlCommand("UPDATE pageconfig SET IDS = '" + int.Parse(authNum) + "' WHERE  configID = 10");
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
        //Update the parade Table

        if (confirmType == "Update")
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
                MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has updated the parade information with the name [" + paradeName.Text + "].' );");
                cmd.Connection = con;
                MySqlDataReader reader3 = cmd.ExecuteReader();
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {


            }

            //update the parade info
            try
            {
           //TODO:
            //need this to connect to mysql database from here to
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //get name of stored procedure
            cmd.CommandText = "UpdateParade";
            //here

           
                //TODO: 
                
                MySqlParameter p1 = new MySqlParameter("eParadeName", paradeName.Text);
                MySqlParameter p2 = new MySqlParameter("eParadeYear", paradeYear.Text);
                MySqlParameter p3 = new MySqlParameter("eParadeType", paradeType.Text);
                MySqlParameter p4 = new MySqlParameter("eParadeDate", paradeDate.Text);
                MySqlParameter p5 = new MySqlParameter("eParadeStartTime", paradeStartTime.Text);
                MySqlParameter p6 = new MySqlParameter("eParadeEndTime", paradeEndTime.Text);              
                MySqlParameter p7 = new MySqlParameter("eID", int.Parse(authNum));

                cmd.Parameters.Add(p7);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);

                MySqlDataReader reader = cmd.ExecuteReader();
                
                GridView1.DataBind();
                con.Close(); con.Dispose();
                reader.Close();
                con.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            
        }
        Button2.Enabled = false;
        AlertLbl.Text = "";
        confirmPanel.Visible = false;
        GridView1.Enabled = true;
        Button2.Enabled = true;
        searchBtn.Enabled = true;
        advSearch.Enabled = true;
        //BannerBtn.Enabled = true;
        confirmType = "";
        Response.Redirect("editParades.aspx");

    }
    protected void CanelBtn_Click(object sender, EventArgs e)
    {
        AlertLbl.Text = "";
        confirmPanel.Visible = false;
        GridView1.Enabled = true;
        Button2.Enabled = true;
        searchBtn.Enabled = true;
        advSearch.Enabled = true;
        //BannerBtn.Enabled = true;
        confirmType = "";
        Button2.Enabled = false;
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

            string fileName = "ParadeMSParadeTable" + "_" + fullDate1 + "_" + fullTime1 + ".csv";

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);

            MySqlCommand cmd = new MySqlCommand("SELECT * INTO OUTFILE '" + uploadPath + fileName + "' FIELDS TERMINATED BY ',' OPTIONALLY ENCLOSED BY '\"'LINES TERMINATED BY '\n' FROM parade;", con);
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
}