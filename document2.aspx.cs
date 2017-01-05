using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;
using PdfSharp;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Drawing;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using System.Configuration;
public partial class Document2 : System.Web.UI.Page
{
    public static string accountNumber;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        HttpRequest q = Request;
        invoicenumber.Text = q.QueryString["invoice"];
        OleDbConnection conn = new OleDbConnection(GetConnectionString());
        OleDbCommand populate1 = new OleDbCommand(" SELECT  AccountNumber FROM [CourierComplete].[dbo].[viewSearchOrders] where invoiceNumber=? ", conn);
        populate1.Parameters.Add("@p1", OleDbType.VarChar).Value = invoicenumber.Text;
        OleDbDataReader ddlValues3;
        populate1.Connection.Open();
        ddlValues3 = populate1.ExecuteReader();
        while (ddlValues3.Read())
        {
            accountNumber =ddlValues3["AccountNumber"].ToString();
        }
        /* string test = "select * from EDIUsers";
        DataSet testds = new DataSet();
        OleDbConnection conn = new OleDbConnection(GetConnectionString());
        OleDbCommand testcmd = new OleDbCommand(test, conn);
        testcmd.CommandType = CommandType.Text;
        OleDbDataAdapter testda = new OleDbDataAdapter(testcmd);
        testda.Fill(testds, "testtable");
        conn.Open();*/
        ReportDocument myReportDocument;
        myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath("~/cystalreport/invoice.rpt"));
        //myReportDocument.SetDataSource(testds);
        myReportDocument.SetDatabaseLogon("sa", "ccdbsa5133");
        // String invoiceNumber = invoiceNumber.ToString();
        // String accountNumber = accountNumber.ToString();
        myReportDocument.SetParameterValue("InvoiceComments", "");
        myReportDocument.SetParameterValue("InvoiceNumber", invoicenumber.Text);
        myReportDocument.SetParameterValue("AccountNumber", accountNumber);
        //CrystalReportViewer1.ReportSource = myReportDocument;
       // CrystalReportViewer1.Refresh();
       // CrystalReportViewer1.DisplayToolbar = true;
        accountnumber.Text = accountNumber;
        ExportOptions CrExportOptions;
        DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
        PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
        CrDiskFileDestinationOptions.DiskFileName = Server.MapPath("~/tempinvoice/invoice.pdf");
       CrExportOptions = myReportDocument.ExportOptions;
        {
            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
            CrExportOptions.FormatOptions = CrFormatTypeOptions;
        }
        
        myReportDocument.Export();
        Response.Redirect("http://localhost:55047/WebSite19/tempinvoice/invoice.pdf");
         /*ReportDocument Rel = new ReportDocument();
        Rel.Load(Server.MapPath("../Reports/Test.rpt"));
        BinaryReader stream = new BinaryReader(Rel.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
        Response.ClearContent();
        Response.ClearHeaders();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment; filename=" + downloadAsFilename);
        Response.AddHeader("content-length", stream.BaseStream.Length.ToString());
        Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
        Response.Flush();
        Response.Close();
         
        ParameterFields paramFields = new ParameterFields();
        ParameterDiscreteValue paramDiscreteValue = new ParameterDiscreteValue();
        ExportFormatType formatType = ExportFormatType.NoFormat;
        formatType = ExportFormatType.PortableDocFormat;
        myReportDocument.ExportToHttpResponse(formatType, Response, true, "Crystal");
        Response.End();
          */
    }
   // protected void Button1_Click(object sender, EventArgs e)
   // {
        
    //}
    public string GetConnectionString()
    {
        //sets the connection string from your web config file "ConnString" is the name of your Connection String
        return System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}