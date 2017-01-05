using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using System.Configuration;

using System.Data.SqlClient;

using Microsoft.Reporting.WebForms;
using System.Data.OleDb;


public partial class fisherweb : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (currentUser.getValidation == 0 || currentUser.getUser != "fisherweb")
            {
                Response.Redirect("~/Login.aspx");
            }

        }

    }
    public string GetConnectionString()
    {
        //sets the connection string from your web config file "ConnString" is the name of your Connection String
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
    protected void viewSearch_Click(object sender, EventArgs e)
    {
        if ((pickupStart.Text.ToString() != String.Empty && pickupEnd.Text.ToString() != String.Empty)|| (referenceFisher.Text.ToString() != String.Empty))
        {
            
            OleDbConnection conn = new OleDbConnection(GetConnectionString());
            string sql = "exec [Rogue].[dbo].[getdataforfisherssrs] @StartDate=?,@EndDate=?,@Reference=?";

            DataSetFisherWeb dsFisherweb=new DataSetFisherWeb();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(sql, conn);
            if (pickupStart.Text.ToString() != String.Empty)
            {
                myCommand.SelectCommand.Parameters.Add("@p1", OleDbType.DBDate).Value = pickupStart.Text;
            }
            if (pickupStart.Text.ToString() == String.Empty)
            {
                myCommand.SelectCommand.Parameters.Add("@p1", OleDbType.DBDate).Value = DBNull.Value;
            }
            if (pickupEnd.Text.ToString() != String.Empty)
            {
                myCommand.SelectCommand.Parameters.Add("@p2", OleDbType.DBDate).Value = pickupEnd.Text;
            }
            if (pickupEnd.Text.ToString() == String.Empty)
            {
                myCommand.SelectCommand.Parameters.Add("@p2", OleDbType.DBDate).Value = DBNull.Value;
            }
            if (referenceFisher.Text.ToString() != String.Empty)
            {
                myCommand.SelectCommand.Parameters.Add("@p3", OleDbType.VarChar).Value = referenceFisher.Text;
            }
            if (referenceFisher.Text.ToString() == String.Empty)
            {
                myCommand.SelectCommand.Parameters.Add("@p3", OleDbType.VarChar).Value = DBNull.Value;
            }
            
            myCommand.Fill(dsFisherweb, "getdataforfisherssrs");
            conn.Open();
            myCommand.SelectCommand.CommandType = CommandType.Text;
            myCommand.SelectCommand.ExecuteNonQuery();

            
            /*ReportParameter start = new ReportParameter();
            ReportParameter end = new ReportParameter();
            start.Name = "pickupStartDate";
            end.Name = "pickupEndDate";
            start.Values.Add(pickupStart.Text.ToString());
            end.Values.Add(pickupEnd.Text.ToString());
            ReportViewer2.LocalReport.SetParameters(
            new ReportParameter[] { start, end });
             */
            if (dsFisherweb.Tables[0].Rows.Count != 0)
            {
                ReportViewer2.ProcessingMode = ProcessingMode.Local;

                ReportViewer2.LocalReport.ReportPath = Server.MapPath("~/fisherweb.rdlc");
                ReportDataSource datasource = new ReportDataSource("DataSet2", dsFisherweb.Tables[0]);
                ReportViewer2.LocalReport.DataSources.Clear();
                ReportViewer2.LocalReport.DataSources.Add(datasource);
                string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                conn.Close();
            }
            else
            {

                conn.Close();
                String message = "";
                if (referenceFisher.Text.ToString() != String.Empty)
                {
                    message = " PO#/reference# is invalid,please enter a pickup start date and pickup end date to search";
                }
                if (referenceFisher.Text.ToString() == String.Empty)
                {
                    message = "No data Found within the Date Range,please pick a different Date Range";
                }

                referenceFisher.Text = "";
                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                sb.Append("<script type = 'text/javascript'>");

                sb.Append("window.onload=function(){");

                sb.Append("alert('");

                sb.Append(message);

                sb.Append("')};");

                sb.Append("</script>");

                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

            }
        }
        else if (pickupStart.Text.ToString() == String.Empty && referenceFisher.Text.ToString() == String.Empty)
        {
            string message = "please enter valid pickup Start Date or just enter a PO#/reference#";

           System.Text.StringBuilder sb = new System.Text.StringBuilder();

              sb.Append("<script type = 'text/javascript'>"); 

              sb.Append("window.onload=function(){"); 

              sb.Append("alert('"); 

              sb.Append(message);

             sb.Append("')};");

             sb.Append("</script>"); 

             ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());


        }
        else if (pickupEnd.Text.ToString() == String.Empty && referenceFisher.Text.ToString() == String.Empty)
        
        {

            string message = "please enter valid pickup End Date or just enter a PO#/reference#";

           System.Text.StringBuilder sb = new System.Text.StringBuilder();

              sb.Append("<script type = 'text/javascript'>"); 

              sb.Append("window.onload=function(){"); 

              sb.Append("alert('"); 

              sb.Append(message);

             sb.Append("')};");

             sb.Append("</script>"); 

             ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());


        }




      
    }
}