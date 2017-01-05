using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Microsoft.Reporting.WebForms;
using System.Data.OleDb;
using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;
using PdfSharp;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using System.Net;
using System.IO.Compression;


public partial class SSRS : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (currentUser.getValidation == 0)
            {
                Response.Redirect("~/Login.aspx");
            }
            string script = "$(document).ready(function () { $('[id*=btnSubmit]').click(); });";

            ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
        }
        generallabel.Text = currentUser.getUserAccountMasterName + " Order Report";
    }
    public string GetConnectionString()
    {
        //sets the connection string from your web config file "ConnString" is the name of your Connection String
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
    protected void viewSearch_Click4(object sender, EventArgs e)
    {
       // System.Threading.Thread.Sleep(1000);
        //generate an order report based on the stored procedure behind
        if (pickupStart4.Text.ToString() != String.Empty && pickupEnd4.Text.ToString() != String.Empty || (referenceGeneral.Text.ToString() != String.Empty))
        {
            OleDbConnection conn = new OleDbConnection(GetConnectionString());
            string sql = "exec [Rogue].[dbo].[getdataforgeneralssrs] @StartDate=?,@EndDate=?,@UserNo=?,@Reference=?";

            DataSetGeneral dsGeneral = new DataSetGeneral();
            OleDbDataAdapter myCommand4 = new OleDbDataAdapter(sql, conn);
            if (pickupStart4.Text.ToString() != String.Empty)
            {
                myCommand4.SelectCommand.Parameters.Add("@p1", OleDbType.DBDate).Value = pickupStart4.Text;
            }
            if (pickupStart4.Text.ToString() == String.Empty)
            {
                myCommand4.SelectCommand.Parameters.Add("@p1", OleDbType.DBDate).Value = DBNull.Value;
            }
            if (pickupEnd4.Text.ToString() != String.Empty)
            {
                myCommand4.SelectCommand.Parameters.Add("@p2", OleDbType.DBDate).Value = pickupEnd4.Text;
            }
            if (pickupEnd4.Text.ToString() == String.Empty)
            {
                myCommand4.SelectCommand.Parameters.Add("@p2", OleDbType.DBDate).Value = DBNull.Value;
            }
            myCommand4.SelectCommand.Parameters.Add("@p3", OleDbType.VarChar).Value = currentUser.getUserAccountMaping;
           
            if (referenceGeneral.Text.ToString() != String.Empty)
            {
                myCommand4.SelectCommand.Parameters.Add("@p4", OleDbType.VarChar).Value = referenceGeneral.Text;
            }
            if (referenceGeneral.Text.ToString() == String.Empty)
            {
                myCommand4.SelectCommand.Parameters.Add("@p4", OleDbType.VarChar).Value = DBNull.Value;
            }
           
                myCommand4.Fill(dsGeneral, "getdataforgeneralssrs");
                conn.Open();
                myCommand4.SelectCommand.CommandType = CommandType.Text;
                myCommand4.SelectCommand.ExecuteNonQuery();
            /*ReportParameter start = new ReportParameter();
            ReportParameter end = new ReportParameter();
            start.Name = "pickupStartDate";
            end.Name = "pickupEndDate";
            start.Values.Add(pickupStart.Text.ToString());
            end.Values.Add(pickupEnd.Text.ToString());
            ReportViewer2.LocalReport.SetParameters(
            new ReportParameter[] { start, end });
             */
                if (dsGeneral.Tables[0].Rows.Count != 0)
                {
                    ReportViewer4.ProcessingMode = ProcessingMode.Local;
                    ReportViewer4.LocalReport.ReportPath = Server.MapPath("~/SSRS.rdlc");
                    ReportDataSource datasource = new ReportDataSource("DataSet4", dsGeneral.Tables[0]);
                    ReportViewer4.LocalReport.DataSources.Clear();
                    ReportViewer4.LocalReport.DataSources.Add(datasource);
                    ReportViewer4.LocalReport.EnableHyperlinks = true;
                    string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    conn.Close();
                }
                else
                {
                    conn.Close();
                    String message = "";
                    if(referenceGeneral.Text.ToString() != String.Empty)
                    {
                        message = "PO#/reference# is invalid,please enter a pickup start date and pickup end date to search";
                    }
                    else if (referenceGeneral.Text.ToString() == String.Empty)
                    {
                       message = "No data Found within the Date Range,please pick a different Date Range";
                    }
                    referenceGeneral.Text = "";
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
        else if (pickupStart4.Text.ToString() == String.Empty && referenceGeneral.Text.ToString() == String.Empty)
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
        else if (pickupEnd4.Text.ToString() == String.Empty && referenceGeneral.Text.ToString() == String.Empty)
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
        viewPDF.Visible = true;
    }
    protected void downloadpdf(object sender, EventArgs e)
    {
       String[] orderNumber = new String[1000000];
       String[] path = new String[1000000];
       String[] filename = new String[1000000];
       String[] destinationFileFolder =new String[1000000];
       String[] pickupDate = new String[1000000];
       DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/temp/"));
        foreach (FileInfo fi in dir.GetFiles())
        {
            fi.Delete();
        }
        File.Delete(Server.MapPath("~/zip/result.zip"));
        string zipPath = Server.MapPath("~/zip/result.zip");
        OleDbCommand myCommand4;
        OleDbConnection conn = new OleDbConnection(GetConnectionString());
        //generate an order report based on the stored procedure behind
        if (pickupStart4.Text.ToString() != String.Empty && pickupEnd4.Text.ToString() != String.Empty || (referenceGeneral.Text.ToString() != String.Empty))
        {
            
            string sql = "exec [Rogue].[dbo].[getdataforgeneralssrs] @StartDate=?,@EndDate=?,@UserNo=?,@Reference=?";


            myCommand4 = new OleDbCommand(sql, conn);
            if (pickupStart4.Text.ToString() != String.Empty)
            {
                myCommand4.Parameters.Add("@p1", OleDbType.DBDate).Value = pickupStart4.Text;
            }
            if (pickupStart4.Text.ToString() == String.Empty)
            {
                myCommand4.Parameters.Add("@p1", OleDbType.DBDate).Value = DBNull.Value;
            }
            if (pickupEnd4.Text.ToString() != String.Empty)
            {
                myCommand4.Parameters.Add("@p2", OleDbType.DBDate).Value = pickupEnd4.Text;
            }
            if (pickupEnd4.Text.ToString() == String.Empty)
            {
                myCommand4.Parameters.Add("@p2", OleDbType.DBDate).Value = DBNull.Value;
            }
            myCommand4.Parameters.Add("@p3", OleDbType.VarChar).Value = currentUser.getUserAccountMaping;

            if (referenceGeneral.Text.ToString() != String.Empty)
            {
                myCommand4.Parameters.Add("@p4", OleDbType.VarChar).Value = referenceGeneral.Text;
            }
            if (referenceGeneral.Text.ToString() == String.Empty)
            {
                myCommand4.Parameters.Add("@p4", OleDbType.VarChar).Value = DBNull.Value;
            }


            OleDbDataReader ddlValues;
            myCommand4.Connection.Open();
            ddlValues = myCommand4.ExecuteReader();
            int counter = 0;
            
            while (ddlValues.Read())
            {
                orderNumber[counter] = ddlValues["OrderNo"].ToString();
                pickupDate[counter] = ddlValues["PickUpTime"].ToString();
                counter++;
            }
            int i = 0;
            ddlValues.Close();
            while (orderNumber[i] != null && pickupDate[i] !=null)
            {
                OleDbCommand populate1 = new OleDbCommand("SELECT case when left(In_DocLocation, 1 ) = 1 then '\\\\RTDATA\\ScanDocs\\' + right(In_DocLocation, len(In_DocLocation)-2) + '\\' + main.In_DocFamilyID + '.' + In_DocFileExt when left(In_DocLocation, 1 ) = 2 then '\\\\RTDATA\\ScanDocs\\SHIPDOCS2015\\' + right(In_DocLocation, len(In_DocLocation)-2) + '\\' + main.In_DocFamilyID + '.' + In_DocFileExt else'POD un-avaialble' end DocPath ,main.In_DocFamilyID+'.'+In_DocFileExt AS 'filename' FROM  RTDATA.SHIPDOCS.dbo.Main main INNER JOIN RTDATA.SHIPDOCS.dbo.OrderNumber OrdNum ON Main.In_DocFamilyID = OrdNum.In_DocFamilyID where OrderNumber= ? and In_DocTypeID = 15", conn);
                populate1.Parameters.Add("@p1", OleDbType.VarChar).Value = orderNumber[i];
                OleDbDataReader ddlValues2;
                ddlValues2 = populate1.ExecuteReader();
                int counter2 = 0;
                while (ddlValues2.Read())
                {
                    path[counter2] = ddlValues2["DocPath"].ToString();
                    filename[counter2] = ddlValues2["filename"].ToString();
                    destinationFileFolder[counter2] = Server.MapPath("~/temp/" + pickupDate[i].Replace(':', '-').Replace('/','-') + "." + filename[counter2] + "");
                    File.Copy(path[counter2], destinationFileFolder[counter2], true);
                    counter2 = counter2 + 1;
                }
                i++;
                ddlValues2.Close();
            }
           ZipFile.CreateFromDirectory(Server.MapPath("~/temp/"), zipPath);
           WebClient req = new WebClient();
           HttpResponse response = HttpContext.Current.Response;
           response.Clear();
           response.ClearContent();
           response.ClearHeaders();
           response.Buffer = true;
           response.AddHeader("Content-Disposition", "attachment;filename=\"" +"podfile.zip"+"\"");
           byte[] data = req.DownloadData(zipPath);
           response.BinaryWrite(data);
           response.End();
          }
       


}

}



        




          
           
    
