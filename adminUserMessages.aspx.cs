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

public partial class adminUserMessages : System.Web.UI.Page
{
    static string determineNewMessages;
    static string getParadeID;
    static string authNum;
    static string getUserID;

    //puting messages into sessions
    static string getMessageUser;
    static string getMessageDate;
    static string getMessageName;
    static string getDessageDesc;

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

        //Get the Current parade
        try
        {

            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT IDs FROM pageconfig WHERE configID = 10;");
            cmd.Connection = con;
            getParadeID = (cmd.ExecuteScalar().ToString());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

      //select only from the current parade year

        SqlDataSource1.SelectCommand = "SELECT messageID, userName, messageDate, messageName, messageDesc, messageStatus FROM messageFromUser WHERE paradeID = '" + getParadeID + "' AND blacklist = 'no'; ";

    }

    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/ try{/*get date and time*/String years = DateTime.Now.Year.ToString();String months = DateTime.Now.Month.ToString();String days = DateTime.Now.Day.ToString();String hours = DateTime.Now.Hour.ToString();String mins = DateTime.Now.Minute.ToString();String secs = DateTime.Now.Second.ToString();String fullDate = years + "-" + months + "-" + days;String fullTime = hours + ":" + mins + ":" + secs;MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);con.Open();MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has signed out.' );");cmd.Connection = con;MySqlDataReader reader3 = cmd.ExecuteReader();con.Close(); con.Dispose();}catch (Exception ex){}Session.Remove("userSession");
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx", true);
        }
    }

    protected string GetImageUrl(string input)
    {
        try
        {
            if (input.Equals("new"))
            {
                return "images/new.png";
            }
            else
            {
                return "images/clear.png";
            }
        }
        catch (Exception exp)
        {

            return "No Status available.";
        }
        
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string key = e.CommandName;

        //reply
        if (key == "ReplyToMessage")
        {
            ////////////////////////////////change the message status///////////////////////////////////////////////////////
            int index = int.Parse(e.CommandArgument.ToString());
            GridView grid = (GridView)e.CommandSource;
            GridViewRow row = grid.Rows[index];

            TableCell tblCell = row.Cells[0];
            authNum = tblCell.Text;

            //change status of message
            try
            {
             

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE messageFromUser SET messageStatus='old' WHERE messageID = '" + Int32.Parse(authNum) + "'; ");
                cmd.Connection = con;
                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();
                GridView1.DataBind();
            }
            catch (Exception)
            {
                
               
            }    
            /////////////////////////////////////Replying to the message most likely be redirected///////////////////////////////////////
            
            //username
            TableCell messageUNameCell = row.Cells[1];
            getMessageUser = messageUNameCell.Text;
            
           //date
            TableCell messageUDateCell = row.Cells[2];
            getMessageDate = messageUDateCell.Text;
            
            //message Name
            TableCell messageMsgNameCell = row.Cells[3];
            getMessageName = messageMsgNameCell.Text;
            
            //message description
            TableCell messageMsgDescCell = row.Cells[4];
            getDessageDesc = messageMsgDescCell.Text;

            //////////////////store these variables into a sesssion

           

            Session["getMessageUser"] = getMessageUser;
            Session["getMessageDate"] = getMessageDate;
            Session["getMessageName"] = getMessageName;
            Session["getDessageDesc"] = getDessageDesc;

            //redirect the page
            Response.Redirect("adminUserReply.aspx"); 

            ////////////////////////////////////////////
        }

        //blacklist user from messages
        if (key == "BlackList")
        {
            ////////////////////////////////change the message status///////////////////////////////////////////////////////
            int index = int.Parse(e.CommandArgument.ToString());
            GridView grid = (GridView)e.CommandSource;
            GridViewRow row = grid.Rows[index];

            TableCell tblCell = row.Cells[0];
            authNum = tblCell.Text;

           

            //gets the user ID
            
            try
            {

                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT uID FROM messageFromUser WHERE messageID = '" + Int32.Parse(authNum) + "'; ");
                cmd.Connection = con;
                getUserID = (cmd.ExecuteScalar().ToString());
                con.Close(); con.Dispose();
            }
            catch (Exception ex)
            {

                Response.Write("");
            }

            //change message status
            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
                con.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE messageFromUser SET messageStatus='old' WHERE uID = '" + Int32.Parse(getUserID) + "'; UPDATE messageFromUser SET blacklist='yes' WHERE uID = '" + Int32.Parse(getUserID) + "';");
                cmd.Connection = con;
                MySqlDataReader reader2 = cmd.ExecuteReader();
                //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
                reader2.Close();
                con.Close(); con.Dispose();
                GridView1.DataBind();
            }
            catch (Exception)
            {


            }
        }

         //delete message
        if (key == "DeleteMessage")
        {
            try
            {
                MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            //get name of stored procedure
            cmd.CommandText = "DeleteMessage";
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
            }
            catch (Exception ex)
            {
                
                
            }
        }

        
    }

    protected void removeBlackList_Click(object sender, EventArgs e)
    {


        //change message status
        try
        {
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("UPDATE messageFromUser SET blacklist='no' WHERE blacklist = 'yes';");
            cmd.Connection = con;
            MySqlDataReader reader2 = cmd.ExecuteReader();

            while (reader2.HasRows)
            {
                
            }
            //userGlobalActive.Text = ((string)cmd.ExecuteScalar());
            reader2.Close();
            con.Close(); con.Dispose();
            GridView1.DataBind();
        }
        catch (Exception)
        {


        }


       
    }
    protected void messageUser_Click(object sender, EventArgs e)
    {
       

        Response.Redirect("adminMessageToUser.aspx"); 
    }
}