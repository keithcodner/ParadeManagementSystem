using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using MySql.Data.MySqlClient;

public partial class reportGen : System.Web.UI.Page
{
     static string getParadeID;

    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Get the current Parade
        try
        {
             
            MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);
            con.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT IDs FROM pageconfig WHERE configID = 10;");
            cmd.Connection = con;
            getParadeID= ((string)cmd.ExecuteScalar());
            con.Close(); con.Dispose();
        }
        catch (Exception ex)
        {

            Response.Write("");
        }

        // make sure the report only gets current parade info
        SqlDataSource1.SelectCommand = "SELECT oOrganization, oContact, oSeminarAtt, oPhone FROM orginfo  WHERE paradeID = '" + getParadeID.ToString() + "' ";

        // make sure the report only gets current parade info
        SqlDataSource2.SelectCommand = "SELECT paradeName FROM parade  WHERE paradeID = '" + getParadeID.ToString() + "' ";


        //Session
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx");
        }
        else
        {
            usernameSession.Text = Session["userSession"].ToString();
        }
        //c reports test

        //try
        //{
        //    ReportDocument crystalReport = new ReportDocument();
        //    crystalReport.Load(@"C:\Users\KJBLeu\Desktop\Y3S5\Capstone 2\ParadeManagementSys2\CrystalReport.rpt");
        //    crystalReport.SetDatabaseLogon("root", "root", "localhost", "pms");
        //    crystalReport.SetDataSource(CrystalReportSource1);
        //    CrystalReportViewer1.ReportSource = crystalReport;
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex);
    

    //if (!IsPostBack)
    //{
    //    ReportDocument cryRpt = new ReportDocument();
    //    TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
    //    TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
    //    ConnectionInfo crConnectionInfo = new ConnectionInfo();
    //    Tables CrTables;

    //    cryRpt.Load(Server.MapPath("CrystalReport.rpt"));

    //    crConnectionInfo.ServerName = "localhost";
    //    crConnectionInfo.DatabaseName = "PMS";
    //    crConnectionInfo.UserID = "root";
    //    crConnectionInfo.Password = "root";
    //    crConnectionInfo.IntegratedSecurity = true;
    //    cryRpt.SetDatabaseLogon("root", "root");

    //    CrTables = cryRpt.Database.Tables;
    //    foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
    //    {
    //        crtableLogoninfo = CrTable.LogOnInfo;
    //        crtableLogoninfo.ConnectionInfo = crConnectionInfo;
    //        CrTable.ApplyLogOnInfo(crtableLogoninfo);
    //    }

    //    CrystalReportViewer1.ReportSource = cryRpt;
    //    CrystalReportViewer1.RefreshReport();
    ////}
    //    try
    //    {
    //        ReportDocument rpt = new ReportDocument();
    //        rpt.Load(Request.PhysicalApplicationPath + "CrystalReport.rpt");
    //        rpt.SetDataSource(CrystalReportSource1);
    //        CrystalReportViewer1.DisplayGroupTree = false;
    //        CrystalReportViewer1.ReportSource = rpt;
    //        CrystalReportViewer1.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Console.WriteLine(ex);
    //    }


        
}
    protected void logoutButton_Click(object sender, EventArgs e)
    {
        /*for activity log*/ try{/*get date and time*/String years = DateTime.Now.Year.ToString();String months = DateTime.Now.Month.ToString();String days = DateTime.Now.Day.ToString();String hours = DateTime.Now.Hour.ToString();String mins = DateTime.Now.Minute.ToString();String secs = DateTime.Now.Second.ToString();String fullDate = years + "-" + months + "-" + days;String fullTime = hours + ":" + mins + ":" + secs;MySqlConnection con = new MySqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["pmsConnectionString"].ConnectionString);con.Open();MySqlCommand cmd = new MySqlCommand("INSERT INTO activityLog(aLDate, aLTime, aLUser, aLDesc) VALUES('" + fullDate + "','" + fullTime + "','" + Session["userSession"].ToString() + "','Administrator : " + Session["userSession"].ToString() + " has signed out.' );");cmd.Connection = con;MySqlDataReader reader3 = cmd.ExecuteReader();con.Close(); con.Dispose();}catch (Exception ex){}Session.Remove("userSession");
        if (Session["userSession"] == null)
        {
            Response.Redirect("adminlogin.aspx", true);
        }
    }
}


