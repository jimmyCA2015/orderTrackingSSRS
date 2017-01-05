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

public partial class document : System.Web.UI.Page
{
    public static String[] path = new String[100];
    public static String[] filename = new String[100];
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DirectoryInfo dir = new DirectoryInfo(Server.MapPath("~/clientfile/"));
            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }
            if (currentUser.getValidation == 0)
            {
                Response.Redirect("~/Login.aspx");
            }
            HttpRequest q = Request;
            String orderNo = q.QueryString["order"];
            OleDbConnection conn = new OleDbConnection(GetConnectionString());
            OleDbCommand populate1 = new OleDbCommand("SELECT case when left(In_DocLocation, 1 ) = 1 then '\\\\RTDATA\\ScanDocs\\' + right(In_DocLocation, len(In_DocLocation)-2) + '\\' + main.In_DocFamilyID + '.' + In_DocFileExt when left(In_DocLocation, 1 ) = 2 then '\\\\RTDATA\\ScanDocs\\SHIPDOCS2015\\' + right(In_DocLocation, len(In_DocLocation)-2) + '\\' + main.In_DocFamilyID + '.' + In_DocFileExt else'POD un-avaialble' end DocPath ,main.In_DocFamilyID+'.'+In_DocFileExt AS 'filename' FROM  RTDATA.SHIPDOCS.dbo.Main main INNER JOIN RTDATA.SHIPDOCS.dbo.OrderNumber OrdNum ON Main.In_DocFamilyID = OrdNum.In_DocFamilyID where OrderNumber= ? and In_DocTypeID = 15", conn);
            populate1.Parameters.Add("@p1", OleDbType.VarChar).Value = orderNo;
            OleDbDataReader ddlValues;
            populate1.Connection.Open();
            ddlValues = populate1.ExecuteReader();
            String destinationFileFolder = "";
            PdfDocument one = new PdfDocument();
            int counter = 0;
            while (ddlValues.Read())
            {
             path[counter] = ddlValues["DocPath"].ToString();
             filename[counter] = ddlValues["filename"].ToString();
             counter = counter + 1;
            }
            if (counter == 1)
            {
                destinationFileFolder = Server.MapPath("~/clientfile/" + filename[0] + "");
                //File.Copy(defaultFileFolder, destinationFileFolder,true);
                File.Copy(path[0], destinationFileFolder, true);
                if (filename[0].Contains(".tif"))
                {
                    //convert from tif to pdf file 
                    PdfDocument tiff = new PdfDocument();
                    PdfPage page = tiff.AddPage();
                    XGraphics gfx = XGraphics.FromPdfPage(page);
                    XImage image = XImage.FromFile(destinationFileFolder);
                    page.Width = image.PointWidth;
                    page.Height = image.PointHeight;
                    gfx.DrawImage(image, 0, 0);
                    tiff.Save(Server.MapPath("~/clientfile/" + filename[0] + ".pdf"));
                    String url = "http://roguebi.roguedelivers.com/orderstatus/clientfile/" + filename[0]+".pdf";
                    Response.Redirect(url);
                }
                else if (filename[0].Contains(".pdf"))
                {
                    String url = "http://roguebi.roguedelivers.com/orderstatus/clientfile/" + filename[0];
                    Response.Redirect(url);
                }
            }
            else if (counter == 0)  
            {
               //SHOW AN ERROR MESSAGE IF POD IS NOT FOUND
                String message = "POD IS NOT AVAILABLE";
                System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
                sb2.Append("<script type = 'text/javascript'>");
                sb2.Append("window.onload=function(){");
                sb2.Append("alert('");
                sb2.Append(message);
                sb2.Append("')};");
                sb2.Append("</script>");
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb2.ToString());
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", " window.close();", true);
            }
            else if (counter >= 2)
            {
                //concat multiple files together
                PdfDocument concat = new PdfDocument();
                PdfDocument tiff = new PdfDocument();
                PdfDocument tiffopen = new PdfDocument();
                PdfPage page = tiff.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);
                for (int i = 0; i < counter; i++)
                {
                    destinationFileFolder = Server.MapPath("~/clientfile/" + filename[i] + "");
                    File.Copy(path[i], destinationFileFolder, true);
                    if (filename[i].Contains(".pdf"))
                    {
                        one = PdfReader.Open(destinationFileFolder, PdfDocumentOpenMode.Import);
                        CopyPages(one, concat);
                       
                    }
                    if (filename[i].Contains(".tif"))
                    {   
                       
                        XImage image = XImage.FromFile(destinationFileFolder);
                        page.Width = image.PointWidth;
                        page.Height = image.PointHeight;
                        gfx.DrawImage(image, 0, 0);
                        tiff.Save(Server.MapPath("~/clientfile/" + filename[i] + ".pdf"));
                        tiffopen = PdfReader.Open(Server.MapPath("~/clientfile/" + filename[i] + ".pdf"), PdfDocumentOpenMode.Import);
                        CopyPages(tiffopen, concat);
                        
                    }
                }
                concat.Save(Server.MapPath("~/clientfile/" + filename[0] + "concat.pdf"));
                String urlconcat = "http://roguebi.roguedelivers.com/orderstatus/clientfile/" + filename[0] + "concat.pdf";
                Response.Redirect(urlconcat);
            }
        }
    }
    public string GetConnectionString()
    {
        //sets the connection string from your web config file "ConnString" is the name of your Connection String
        return System.Configuration.ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
    }
    void CopyPages(PdfDocument from, PdfDocument to)
    {
        for (int i = 0; i < from.PageCount; i++)
        {
            to.AddPage(from.Pages[i]);
        }
    }
}