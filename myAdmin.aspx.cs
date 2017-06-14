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

public partial class myAdmin : System.Web.UI.Page
{
    static string dDay;
    static string dMonth;
    static string dYear;
    static string getDateTime;
    static int getIntAdminUID;
    static string getAdminUID;
    static String assembleGetDateOnly;
    static string correctStringDate;
    public static DataTable fullTable;
    static bool update = false;
    static string authNum;

    static ListItem li;

    protected void Page_Load(object sender, EventArgs e)
    {
        noteApply.Enabled = false;
      ///////////////////advanced search checks////////////////////////////
        if ((!TitleRB.Checked) || (!BodyRB.Checked) || (!DateRB.Checked) || (!IDRB.Checked))
        {
            SqlDataSource1.SelectCommand = "SELECT noteID, noteDate, noteName, noteBody FROM datenote WHERE noteUID = '" + getAdminUID + "' AND noteName LIKE   '%" + searchTxt.Text.ToString() + "%' ";
        }
        else if ((TitleRB.Checked))
        {
            SqlDataSource1.SelectCommand = "SELECT noteID, noteDate, noteName, noteBody FROM datenote WHERE noteUID = '" + getAdminUID + "' AND noteName LIKE   '%" + searchTxt.Text.ToString() + "%' ";
        }
        else if ((BodyRB.Checked))
        {
            SqlDataSource1.SelectCommand = "SELECT noteID, noteDate, noteName, noteBody FROM datenote WHERE noteUID = '" + getAdminUID + "' AND noteBody LIKE   '%" + searchTxt.Text.ToString() + "%' ";
        }
        else if ((DateRB.Checked))
        {
            SqlDataSource1.SelectCommand = "SELECT noteID, noteDate, noteName, noteBody FROM datenote WHERE noteUID = '" + getAdminUID + "' AND noteDate LIKE   '%" + searchTxt.Text.ToString() + "%' ";
        }
        else if ((IDRB.Checked))
        {
            SqlDataSource1.SelectCommand = "SELECT noteID, noteDate, noteName, noteBody FROM datenote WHERE noteUID = '" + getAdminUID + "' AND noteID LIKE   '%" + searchTxt.Text.ToString() + "%' ";
        }

     //////////////////get the admin userid//////////////////////////////
        try
        {
            //encrypting password to be matched to databaase password
            string hash;
            hash = FormsAuthentication.HashPasswordForStoringInConfigFile(Session["userSessionPW"].ToString() + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");

             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uID FROM user WHERE uUsername= '" + Session["userSession"].ToString() + "' AND uPassword = '" + hash.ToString() + "' ");
            cmd.Connection = con;
            getIntAdminUID = ((int)cmd.ExecuteScalar());
            getAdminUID = getIntAdminUID.ToString();
            con.Close(); con.Dispose();
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
            Response.Write("User is missing First Name and/or Last Name.");

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
        //////////////////////get Select Command///////////////////////////
        SqlDataSource1.SelectCommand = "SELECT noteID, noteDate, noteName, noteBody FROM datenote WHERE noteUID = '" + getAdminUID + "' ";


     //////////////////////clears Calanerder pre-selections//////////////////
        if (Page.IsPostBack && Calendar1.SelectedDates.Count == 1)
        {
            Calendar1.SelectedDates.Clear();
        }  
        ////////////////////////Date Getter//////////////////
        String dyear = DateTime.Now.Year.ToString();
        String dmonth = DateTime.Now.Month.ToString();
        String dday = DateTime.Now.Day.ToString();
        String hour = DateTime.Now.Hour.ToString();
        String min = DateTime.Now.Minute.ToString();
        String sec = DateTime.Now.Second.ToString();
        String fullDate = dyear + "-" + dmonth + "-" + dday;
        //String fullTime = hour + ":" + min + ":" + sec;
        getDateTime = fullDate ;
        ///////////////////get user real name /////////////
        BindCalendar();
        try
        {
            //encrypting password to be matched to databaase password
            string hash;
            hash = FormsAuthentication.HashPasswordForStoringInConfigFile(Session["userSessionPW"].ToString() + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");

             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uFName FROM user WHERE uUsername= '" + Session["userSession"].ToString() + "' AND uPassword = '" + hash.ToString() + "' ");
            cmd.Connection = con;
            getUFName.Text= ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
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

        try
        {
            //encrypting password to be matched to databaase password
            string hash;
            hash = FormsAuthentication.HashPasswordForStoringInConfigFile(Session["userSessionPW"].ToString() + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");

             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT uLName FROM user WHERE uUsername= '" + Session["userSession"].ToString() + "' AND uPassword = '" + hash.ToString() + "' ");
            cmd.Connection = con;
            getULName.Text = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
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

        ////////////////Getting date//////////////////////////
        dDay = DateTime.Now.DayOfWeek.ToString();
        day.Text = dDay;
        dMonth = String.Format("{0:MMMM}", DateTime.Now).ToString();
        month.Text = dMonth;
        dYear = DateTime.Now.Year.ToString();
        year.Text = dYear;
        monthInt.Text = DateTime.Now.Day.ToString();

        //////////////////////////////////////
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSession"].ToString();
        }
        
    }

    private void BindCalendar()
    {
        Calendar1.SelectedDate = DateTime.Now;
    }
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/ try{/*get date and time*/String years = DateTime.Now.Year.ToString();String months = DateTime.Now.Month.ToString();String days = DateTime.Now.Day.ToString();String hours = DateTime.Now.Hour.ToString();String mins = DateTime.Now.Minute.ToString();String secs = DateTime.Now.Second.ToString();String fullDate = years + "-" + months + "-" + days;String fullTime = hours + ":" + mins + ":" + secs;MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);con.Open();MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has signed out.' );");cmd.Connection = con;MySqlDataReader reader3 = cmd.ExecuteReader();con.Close(); con.Dispose();}catch (Exception ex){}Session.Remove("userSession");
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx", true);
        }
    }
    protected void Calendar1_SelectionChanged(object sender, System.EventArgs e)
    {
         li = new ListItem();
        li.Text = Calendar1.SelectedDate.ToShortDateString();

        int counter = 0;
        foreach (ListItem litem in BulletedList1.Items)
        {
            if (litem.Text == li.Text)
            {
                counter++;
            }
        }

        if (counter > 0)
        {
            BulletedList1.Items.Remove(li);
        }
        else
        {
            BulletedList1.Items.Add(li);
        }

       Calendar1.SelectedDates.Clear();
       SelectedDatesCollection dates = Calendar1.SelectedDates;

       foreach (ListItem litem in BulletedList1.Items)
       {
           DateTime date = Convert.ToDateTime(litem.Text);
           dates.Add(date);
       }
    }  
    protected void Button1_Click(object sender, EventArgs e)
    {
        ///////////////////calendar control to label///////////////////

        //DateTime dt = Convert.ToDateTime(Calendar1.SelectedDate.ToShortDateString());
        //string getDateTime = dt.ToString();
        //String[] getDateOnly = getDateTime.Split(' ');
        //assembleGetDateOnly = getDateOnly[0];
        //correctStringDate = assembleGetDateOnly.Replace("/", "-");
        //dateTest.Text = correctStringDate;

        //try
        //{
             
        //    MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
        //    con.Open();
        //    MySqlCommand cmd = new MySqlCommand("INSERT INTO pageconfig(value) VALUES('" + sCon + "') WHERE configID=12  ");
        //    cmd.Connection = con;
        //    getIntAdminUID = ((int)cmd.ExecuteScalar());
        //    getAdminUID = getIntAdminUID.ToString();
        //    con.Close(); con.Dispose();
        //}
        //catch (Exception ex)
        //{

        //    Response.Write("");
        //}
    }
    protected void noteSubmit_Click(object sender, EventArgs e)
    {
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insertNote";
            MySqlParameter p1 = new MySqlParameter("eNoteDate", getDateTime);
            MySqlParameter p2 = new MySqlParameter("eNoteName", noteTitle.Text);
            MySqlParameter p3 = new MySqlParameter("eNoteBody", noteBody.Text);
            MySqlParameter p4 = new MySqlParameter("eNoteID", getAdminUID);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p4);
            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            con.Close(); con.Dispose();
            Response.Redirect("myAdmin.aspx");

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
    }
    protected void search_Click(object sender, EventArgs e)
    {
        if ((!TitleRB.Checked) && (!BodyRB.Checked) && (!DateRB.Checked) && (!IDRB.Checked))
        {
            SqlDataSource1.SelectCommand = "SELECT noteID, noteDate, noteName, noteBody FROM datenote WHERE noteUID = '" + getAdminUID + "' AND noteName LIKE   '%" + searchTxt.Text.ToString() + "%' ";
        }
        else if (TitleRB.Checked)
        {
            SqlDataSource1.SelectCommand = "SELECT noteID, noteDate, noteName, noteBody FROM datenote WHERE noteUID = '" + getAdminUID + "' AND noteName LIKE   '%" + searchTxt.Text.ToString() + "%' ";
            searchSubject.Text = "Title";
        }
        else if (BodyRB.Checked)
        {

            SqlDataSource1.SelectCommand = "SELECT noteID, noteDate, noteName, noteBody FROM datenote WHERE noteUID = '" + getAdminUID + "' AND noteBody LIKE   '%" + searchTxt.Text.ToString() + "%' ";
            searchSubject.Text = "Body in Word";
        }
        else if (DateRB.Checked)
        {
            //searchTxt.Text = dateTest.Text;
            SqlDataSource1.SelectCommand = "SELECT noteID, noteDate, noteName, noteBody FROM datenote WHERE noteUID = '" + getAdminUID + "' AND noteDate LIKE   '%" + searchTxt.Text.ToString() + "%' ";
            searchSubject.Text = "Date";


        }
        else if (IDRB.Checked)
        {
            SqlDataSource1.SelectCommand = "SELECT noteID, noteDate, noteName, noteBody FROM datenote WHERE noteUID = '" + getAdminUID + "' AND noteID LIKE   '%" + searchTxt.Text.ToString() + "%' ";
            searchSubject.Text = "ID";
        }
        ///////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////
        GridView1.DataSourceID = "SqlDataSource1";
        AdvSearchPanel.Visible = false;
    }
    protected void advSearch_Click(object sender, EventArgs e)
    {
        AdvSearchPanel.Visible = true;
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        string key = e.CommandName;
        if (key == "DeleteNote")
        {
            //need this to connect to mysql database from here to
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //get name of stored procedure
            cmd.CommandText = "DeleteNote";
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
            noteSubmit.Enabled = true;
        }
        if (key == "UpdateNote")
        {


            update = true;
            int index = int.Parse(e.CommandArgument.ToString());
            GridView grid = (GridView)e.CommandSource;
            GridViewRow row = grid.Rows[index];
            TableCell tblCell = row.Cells[0];
            authNum = tblCell.Text;


            TableCell place1 = row.Cells[2];
            noteTitle.Text = place1.Text.Replace("&#39;", "'");

            TableCell place2 = row.Cells[3];
            noteBody.Text = place2.Text.Replace("&#39;", "'");


            if (noteTitle.Text.Equals("&nbsp;"))
            {
                noteTitle.Text = "";
            }
            if (noteBody.Equals("&nbsp;"))
            {
                noteBody.Text = "";
            }


            //place2.Text = place2.Text.


            noteSubmit.Enabled = false;
            noteApply.Enabled = true;
        }

    }
    protected void noteApply_Click(object sender, EventArgs e)
    {
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateNote";
            MySqlParameter p1 = new MySqlParameter("eNoteName", noteTitle.Text);
            MySqlParameter p2 = new MySqlParameter("eNoteBody", noteBody.Text);
            MySqlParameter p3 = new MySqlParameter("eID", int.Parse(authNum));

            cmd.Parameters.Add(p3);
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);

            MySqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            con.Close(); con.Dispose();
            GridView1.DataBind();
            // Response.Redirect("addchangewaiveraspx.aspx");
            noteTitle.Text = "";
            noteBody.Text = "";

            noteApply.Enabled = false;
            noteSubmit.Enabled = true;
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
        
    }
}