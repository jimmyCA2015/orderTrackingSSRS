using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.IO;  


public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        // make a connection to EDIUsers table in rtappsvr  and validate
        //user input based on UserID,UserPwd in EDIUsers table
        OleDbConnection conn = new OleDbConnection(GetConnectionString());
        conn.Open();
        string sql = "SELECT  UserID,UserPwd,UserNo,MasterAccountName FROM  [Rogue].[dbo].[EDIUsers] ;";
        OleDbCommand cmd = new OleDbCommand(sql, conn);
        bool validated = false;
        using (OleDbDataReader oReader = cmd.ExecuteReader())
        {
            while (oReader.Read())
            {
                if (username.Text == oReader["UserID"].ToString() && password.Text == oReader["UserPwd"].ToString())
                {
                    currentUser.getValidation = 1;
                    validated = true;
                    currentUser.getUserAccountMaping = oReader["UserNo"].ToString();
                    if(username.Text !="Johnson&Johnson")
                    {
                    currentUser.getUser = username.Text;
                    }
                    else
                    {
                     currentUser.getUser = "Johnson";
                    }
                    currentUser.getUserAccountMasterName = oReader["MasterAccountName"].ToString();
                }
                
            }
        }
        conn.Close();
        if (validated)
        {
            /*if (currentUser.getUser == "fisherweb" )
            {
                Response.Redirect("~/fisherweb.aspx");
            }
            else if (currentUser.getUser == "Innomar")
            {
               Response.Redirect("~/Innomar.aspx");
            }
             */
             if (currentUser.getUser == "Johnson")
            {
               Response.Redirect("~/JohnsonHome.aspx");
            }
            else
            {
                Response.Redirect("~/SSRS.aspx");
            }
        }
        if (!validated)
        {
            lblLoginError.Text = "Invalid Login";
            lblLoginError.Attributes["style"] = "color:red; font-weight:bold;";
        }
    }
    public string GetConnectionString()
    {
        //sets the connection string from your web config file "ConnString" is the name of your Connection String
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
    protected void btQuickSearch_Click(object sender, EventArgs e)
    {

    }
}