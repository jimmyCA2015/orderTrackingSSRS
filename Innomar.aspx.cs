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


public partial class Innomar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
            if (!IsPostBack)
            {
                if (currentUser.getValidation == 0 || currentUser.getUser != "Innomar")
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
    protected void viewSearch_Click2(object sender, EventArgs e)
       
    {

        if ((pickupStart2.Text.ToString() != String.Empty && pickupEnd2.Text.ToString() != String.Empty) || (referenceInn.Text.ToString() != String.Empty))
        {

            OleDbConnection conn = new OleDbConnection(GetConnectionString());
            string sql = "exec [Rogue].[dbo].[getdataforinnomarssrs] @StartDate=?,@EndDate=?,@Reference=?";

            DataSetInnomar dsInnomar= new DataSetInnomar();
            OleDbDataAdapter myCommand2 = new OleDbDataAdapter(sql, conn);
            if (pickupStart2.Text.ToString() != String.Empty)
            {
                myCommand2.SelectCommand.Parameters.Add("@p1", OleDbType.DBDate).Value = pickupStart2.Text;
            }
            if (pickupStart2.Text.ToString() == String.Empty)
            {
                myCommand2.SelectCommand.Parameters.Add("@p1", OleDbType.DBDate).Value = DBNull.Value;
            }
            if (pickupEnd2.Text.ToString() != String.Empty)
            {
                myCommand2.SelectCommand.Parameters.Add("@p2", OleDbType.DBDate).Value = pickupEnd2.Text;
            }
            if (pickupEnd2.Text.ToString()  == String.Empty)
            {
                myCommand2.SelectCommand.Parameters.Add("@p2", OleDbType.DBDate).Value = DBNull.Value;
            }
            if (referenceInn.Text.ToString() != String.Empty)
            {
                myCommand2.SelectCommand.Parameters.Add("@p3", OleDbType.VarChar).Value = referenceInn.Text;
            }
            if (referenceInn.Text.ToString() == String.Empty)
            {
                myCommand2.SelectCommand.Parameters.Add("@p3", OleDbType.VarChar).Value = DBNull.Value;
            }
            myCommand2.Fill(dsInnomar, "getdataforinnomarssrs");
            conn.Open();
            myCommand2.SelectCommand.CommandType = CommandType.Text;
            myCommand2.SelectCommand.ExecuteNonQuery();


            /*ReportParameter start = new ReportParameter();
            ReportParameter end = new ReportParameter();
            start.Name = "pickupStartDate";
            end.Name = "pickupEndDate";
            start.Values.Add(pickupStart.Text.ToString());
            end.Values.Add(pickupEnd.Text.ToString());
            ReportViewer2.LocalReport.SetParameters(
            new ReportParameter[] { start, end });
             */
            if (dsInnomar.Tables[0].Rows.Count != 0)
            {
            ReportViewer1.ProcessingMode = ProcessingMode.Local;

            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Innomar.rdlc");
            
            

                ReportDataSource datasource = new ReportDataSource("DataSet1", dsInnomar.Tables[0]);
                ReportViewer1.LocalReport.DataSources.Clear();

                ReportViewer1.LocalReport.DataSources.Add(datasource);

                string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                conn.Close();
            }
            else
            {
                conn.Close();
                String message = "";
                if (referenceInn.Text.ToString() != String.Empty)
                {
                    message = " PO#/reference# is invalid,please enter a pickup start date and pickup end date to search";
                }
                if (referenceInn.Text.ToString() == String.Empty)
                {
                    message = "No data Found within the Date Range,please pick a different Date Range";
                }

                referenceInn.Text = "";

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
        else if (pickupStart2.Text.ToString() == String.Empty && referenceInn.Text.ToString()==String.Empty)
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
        else if (pickupEnd2.Text.ToString() == String.Empty && referenceInn.Text.ToString() == String.Empty)
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

    

