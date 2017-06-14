using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using MySql.Data.MySqlClient;
using System.Drawing;

public partial class validateAccount : System.Web.UI.Page
{
    static string getValidCode;
    static string getUsername;
    static string getPassword;
    static string hash;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Session: session should always be loaded first, to eliminated possible errors in the future
        if (Session["userSessionU"] == null)
        {
            Response.Redirect("userLogin.aspx");
        }
        else
        {
           Session["userSessionU"].ToString();
        }

        //get credential session strings
        getUsername = Session["userSessionU"].ToString();
        getPassword = Session["userSessionPWU"].ToString();

        //make password hashed
        try
        {
            hash = FormsAuthentication.HashPasswordForStoringInConfigFile(getPassword + "-2>/z>.L0~TstH(39%@l2)E xAAo _=IOa8u<D?0cE", "SHA1");

            MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con1.Open();
            MySqlCommand cmd1 = new MySqlCommand("SELECT uValidCode FROM user WHERE uUsername = '" + getUsername + "' AND uPassword = '" + hash.ToString() + "';");
            cmd1.Connection = con1;
            getValidCode = ((string)cmd1.ExecuteScalar());
            con1.Close(); con1.Dispose();


        }
        catch (Exception)
        {

            Response.Write("You cannot log in.");
        }
       
        //make label valid code
        //Label1.Text = getValidCode;
    }
    protected void Submit_Click(object sender, EventArgs e)
    {
        if (codeTxt.Text == getValidCode)
        {
            MySqlConnection con1 = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con1.Open();
            MySqlCommand cmd1 = new MySqlCommand("UPDATE user SET uEmailValidator = 'Valid' WHERE uUsername = '" + getUsername + "' AND uPassword = '" + hash.ToString() + "';");
            cmd1.Connection = con1;
            getValidCode = ((string)cmd1.ExecuteScalar());
            con1.Close(); con1.Dispose();

            error.ForeColor = Color.Green;
            error.Text = "Code was correct!";

            //redirect after 5 sec
            Response.Write("  Code was verified!. You will be redirected shortly.");
            redirectingLabel.Visible = true;

            Response.AddHeader("REFRESH", "5;URL=userHomeLogin.aspx");
            Submit.Enabled = false;
        }
        else 
        {
            error.ForeColor = Color.Red;
            error.Text = "Code was not entered correctly. Please try again.";
            //Response.Redirect("validateAccount.aspx");
        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("userLogin.aspx");
    }
}