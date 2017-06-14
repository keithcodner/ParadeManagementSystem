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


public partial class SantaInvolved : System.Web.UI.Page
{
    static string getScrollTextCode;
    static string getScrollText;

    protected void Page_Load(object sender, EventArgs e)
    {
        ///////////////////////get from db//////////////////////////////////////////
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT other FROM pageconfig WHERE configID = 11;");
            cmd.Connection = con;
            getScrollTextCode = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT value FROM pageconfig WHERE configID = 11;");
            cmd.Connection = con;
            getScrollText = ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }
        scrollText.Text = getScrollText;
        /////////////////////if there is scroll text, change size and color///////////////////////
        if (getScrollTextCode == "BigRed")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Red;
        }
        if (getScrollTextCode == "BigBlue")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Blue;
        }
        if (getScrollTextCode == "BigBlack")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Black;
        }
        if (getScrollTextCode == "BigWhite")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.White;
        }
        if (getScrollTextCode == "BigPurple")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Purple;
        }
        if (getScrollTextCode == "BigYellow")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Yellow;
        }
        if (getScrollTextCode == "BigGreen")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Green;
        }
        if (getScrollTextCode == "BigOrange")
        {
            scrollText.Font.Size = 100;
            scrollText.ForeColor = System.Drawing.Color.Orange;
        }
        if (getScrollTextCode == "MediumRed")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Red;
        }
        if (getScrollTextCode == "MediumBlue")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Blue;
        }
        if (getScrollTextCode == "MediumBlack")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Black;
        }
        if (getScrollTextCode == "MediumWhite")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.White;
        }
        if (getScrollTextCode == "MediumPurple")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Purple;
        }
        if (getScrollTextCode == "MediumYellow")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Yellow;
        }
        if (getScrollTextCode == "MediumGreen")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Green;
        }
        if (getScrollTextCode == "MediumOrange")
        {
            scrollText.Font.Size = 50;
            scrollText.ForeColor = System.Drawing.Color.Orange;
        }
        if (getScrollTextCode == "SmallRed")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Red;
        }
        if (getScrollTextCode == "SmallBlue")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Blue;
        }
        if (getScrollTextCode == "SmallBlack")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Black;
        }
        if (getScrollTextCode == "SmallWhite")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.White;
        }
        if (getScrollTextCode == "SmallPurple")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Purple;
        }
        if (getScrollTextCode == "SmallYellow")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Yellow;
        }
        if (getScrollTextCode == "SmallGreen")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Green;
        }
        if (getScrollTextCode == "SmallOrange")
        {
            scrollText.Font.Size = 25;
            scrollText.ForeColor = System.Drawing.Color.Orange;
        }
       
    }
}