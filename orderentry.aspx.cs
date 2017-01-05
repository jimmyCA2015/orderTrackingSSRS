using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Data.OleDb;
using System.IO;
using System.Drawing;

public partial class orderentry : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (currentUser.getValidation == 0 || currentUser.getUser != "Johnson")
        {
            Response.Redirect("~/Login.aspx");
        }
        if (!IsPostBack)
        {

            datenow.Text = DateTime.Now.ToString();
            currentAddress.getDeliveryTo = "";
            currentAddress.getDeliveryLocation = "";
            currentAddress.getShipToNumber = "";
            currentPickup.getDeliveryTo2 = "";
            currentPickup.getDeliveryLocation2 = "";
            currentPickup.getShipToNumber2 = "";
            contactdelivery.Text = "Please Enter Contact Info.";
            contactdelivery.ForeColor = Color.Red;
            contactpickup.Text = "Please Enter Contact Info.";
            contactpickup.ForeColor = Color.Red;


            TextBox17.Text = "Please Enter Location Info.";

            //TextBox17.ForeColor = Color.Red;
            TextBox12.Text = "Please Enter Location Info.";

            //TextBox12.ForeColor = Color.Red;
        }
        if (IsPostBack)
        {
            if (Session["DISPLAYFORM"] == "YES")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "document.getElementById('insertform').style.display='inherit';alert('PLEASE  FILL OUT THE FORM ON THE RIGHT TO ADD NEW CUSTOMER');", true);
                Session["DISPLAYFORM"] = "NO";
            }
            if (Session["hospitalname"] != null)
            {
                deliveryto.Text = Session["hospitalname"].ToString();
            }
            if (Session["hospitalname"] == "")
            {
                deliveryto.Text = currentAddress.getDeliveryTo;
            }
            
            if (Session["address"] != null)
            {
                deliverylocation.Text = Session["address"].ToString();
            }
            if (Session["address"] == "")
            {
                deliverylocation.Text = currentAddress.getDeliveryLocation;
            }
            if (Session["shipno"] == "")
            {
                shipNo.Text = currentAddress.getShipToNumber;
            }
            if (Session["shipno"] !=null)
            {
                shipNo.Text = Session["shipno"].ToString();
            }
            if (Session["hospitalname2"] != null)
            {
                orgpickup.Text = Session["hospitalname2"].ToString();
            }
            if (Session["hospitalname2"] == "")
            {
                orgpickup.Text = currentPickup.getDeliveryTo2;
            }

            if (Session["address2"] != null)
            {
                namepickup.Text = Session["address2"].ToString();
            }
            if (Session["address2"] == "")
            {
                namepickup.Text = currentPickup.getDeliveryLocation2;
            }
            if (Session["shipno2"] == "")
            {
                shippick.Text = currentPickup.getShipToNumber2;
            }
            if (Session["shipno2"] != null)
            {
                shippick.Text = Session["shipno2"].ToString();
            }
            
        }
        //deliverylocation.Text = "J";
        //deliveryto.Text = "JOHNSON";
        //contactdelivery.Text = "DOCK CONTROLLER";
        //TextBox17.Text = "DOCK DOOR `;
    }

    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        //replace "\" with specialcharacter , "&" with specialcharacter2 ,"#" with specialcharacter 3, and recapture those special characters on a new page
       string daterequest = datenow.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#","specialcharacter3");
        string p2 = datepickup1.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p3 = txtDropDown1.SelectedValue.Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p4 = datepickup2.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p5 = pickuprequestedby.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p6 = requester.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p7 = reference.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p8 = piece.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p9 = weight.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p10 = setcode.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p11 = cutofftime.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p12 = delivertime.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p13 = namepickup.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p14 = contactpickup.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p15 = TextBox12.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p16 = timefreight.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p17 = deliverylocation.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p18 = deliveryto.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p19 = contactdelivery.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p20 = TextBox17.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p21 = Textarea1.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        string p22 = orgpickup.Text.ToString().Replace("\"", "specialcharacter1").Replace("&", "specialcharacter2").Replace("#", "specialcharacter3");
        //Response.Redirect("Default2.aspx?daterequest=" + daterequest + "&p2=" + p2 + "&p3=" + p3 + "&p4=" + p4 + "&p5=" + p5 + "&p6=" + p6 +
        // "&p7=" + p7 + "&p8=" + p8 + "&p9=" + p9 + "&p10=" + p10 + "&p11=" + p11 + "&p12=" + p12 +
        // "&p13= " + p13 + "&p14= " + p14 + " &p15= " + p15 + " &p16= " + p16 + "&p17= " + p17 + "&p18= " + p18 + "&p19=" + p19 +
        //"&p20= " + p20 + "&p21= " + p21 + " ");
        string querystring = "?daterequest=" + daterequest + "&p2=" + p2 + "&p3=" + p3 + "&p4=" + p4 + "&p5=" + p5 + "&p6=" + p6 +
                   "&p7=" + p7 + "&p8=" + p8 + "&p9=" + p9 + "&p10=" + p10 + "&p11=" + p11 + "&p12=" + p12 +
                  "&p13= " + p13 + "&p14= " + p14 + " &p15= " + p15 + " &p16= " + p16 + "&p17= " + p17 + "&p18= " + p18 + "&p19=" + p19 +
                  "&p20= " + p20 + "&p21= " + p21 + "&p22= " + p22 + "";

        String message;
       try
       {

        MailMessage mail = new MailMessage();
        NetworkCredential credentials = new NetworkCredential("ccmail", "Rogue905");
        SmtpClient SmtpServer = new SmtpClient();
        SmtpServer.Host = "rtserver.roguedelivers.com";
        //SmtpServer.EnableSsl = true;
        SmtpServer.UseDefaultCredentials = true;
        mail.To.Add("jlin@roguedelivers.com");
        //Configure the address we are sending the mail from
        MailAddress address = new MailAddress("ccmail@roguedelivers.com");
        mail.From = address;
        mail.IsBodyHtml = true;
        //Append their name in the beginning of the subject
        mail.Subject = "New Order From Johnson&Johnson";
        string url = "http://localhost:55047/WebSite19/Default2.aspx" + querystring;
        mail.Body = "<html><body><a href=\"" + url + "\">New Order From Johnson&Jonson, please click to see it</a></body></html>";
        SmtpServer.Send(mail);
       }
      catch(Exception ex)
        {
            message = "Fail to send form, please contact rogue specialty transportation customer service representative";
            System.Text.StringBuilder sb1 = new System.Text.StringBuilder();
            sb1.Append("<script type = 'text/javascript'>");
            sb1.Append("window.onload=function(){");
            sb1.Append("alert('");
            sb1.Append(message);
            sb1.Append("')};");
            sb1.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb1.ToString());
            return;
        }
       message = "Send Form Successfully. Thank you ";
       System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
       sb2.Append("<script type = 'text/javascript'>");
       sb2.Append("window.onload=function(){");
       sb2.Append("alert('");
       sb2.Append(message);
       sb2.Append("')};");
       sb2.Append("</script>");

       ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb2.ToString());
       status.Text = "Send Form Successfully. Thank you ";
    }
    protected void populate_Click(object sender, EventArgs e)
    {
        if (shipNo.Text == String.Empty)
        {
            String message = "PLEASE ENTER A  SHIP TO NUMBER TO SEARCH. THANK YOU ";
            System.Text.StringBuilder sb2 = new System.Text.StringBuilder();
            sb2.Append("<script type = 'text/javascript'>");
            sb2.Append("window.onload=function(){");
            sb2.Append("alert('");
            sb2.Append(message);
            sb2.Append("')};");
            sb2.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb2.ToString());
            return;
        }
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+Server.MapPath("~/excel/address.xls")+";Extended Properties='Excel 8.0;HDR=Yes;'";
        OleDbConnection connection = new OleDbConnection(connectionString);
        //connection.Open();
        //this next line assumes that the file is in default Excel format with Sheet1 as the first sheet name, adjust accordingly
        OleDbCommand populate1 = new OleDbCommand("SELECT * FROM [depuycustomers$]", connection);
        OleDbDataReader ddlValues;
        populate1.Connection.Open();
        ddlValues = populate1.ExecuteReader();
        Boolean found = false;
        if (shipNo.Text ==String.Empty)
        {
            deliveryto.Text = "";
            deliverylocation.Text = "";
            return;
        }
        while (ddlValues.Read())
        {
            if (ddlValues["SHIP TO"].ToString() == shipNo.Text)
            {
                deliveryto.Text = ddlValues["HOSPITAL NAME"].ToString();
                deliverylocation.Text = ddlValues["ADDRESS 1 "].ToString() + " - " + ddlValues["ADDRESS 2"].ToString() + " " + ddlValues["CITY NAME"].ToString() + " " + ddlValues["PROVINCE"].ToString() + " " + ddlValues["POSTAL CODE"].ToString();
                found = true;
            }
        }
        if (!found)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "var confirm = prompt('ADDRESS NOT FOUND,DO YOU WANT TO ADD NEW ADDRESS  yes/no?');{if(confirm.toLowerCase()=='yes' || confirm.toLowerCase()=='y' ) {document.getElementById('insertform').style.display='inherit'; alert('PLEASE FILL OUT THE FORM ON THE RIGHT TO ADD NEW ADDRESS ');}}", true);
            //insertform.Visible = true;
             deliveryto.Text = "Address not found,please enter manually, thanks";
             deliverylocation.Text = "Address not found,please enter manually, thanks";
            
        }
        populate1.Connection.Close();
        populate1.Connection.Dispose();
      
    }
    //protected void UploadButton_Click(object sender, EventArgs e)
    //{
       // if (FileUploadControl.HasFile)
       // {
           // try
           // {
              //  string filename = Path.GetFileName(FileUploadControl.FileName);
               // FileUploadControl.SaveAs(Server.MapPath("~/excel/") + "address.xls");
           //     //StatusLabel.Text = "Upload status: File uploaded!";
          //  }
           // catch (Exception ex)
           // {
                //StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
           // }
       // }
    //}
   // protected void Unnamed1_Click(object sender, EventArgs e)
   // {
      

            //ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "window.open('popup.aspx','','status=1,toolbar=0,menubar=0,location=1,scrollbars=1,resizable=1,top=500,left=700,width=1000,height=300');", true);

          //  Button2.Visible = true;
   // }
    protected void Unnamed3_Click(object sender, EventArgs e)
    {
        Button2.Visible = false;
    }


    protected void INSERT_Click(object sender, EventArgs e)
    {
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source="+Server.MapPath("~/excel/address.xls")+";Extended Properties='Excel 8.0;HDR=Yes;'";
        OleDbConnection connection = new OleDbConnection(connectionString);
        //connection.Open();
        //this next line assumes that the file is in default Excel format with Sheet1 as the first sheet name, adjust accordingly
        OleDbCommand populate1 = new OleDbCommand("INSERT INTO [depuycustomers$]([SHIP TO],[HOSPITAL NAME],[SOLD TO],[ADDRESS 1 ],[ADDRESS 2],[CITY NAME],[PROVINCE],[POSTAL CODE])  VALUES (?,?,?,?,?,?,?,?);", connection);
        if (insertShipNo.Text.ToString() != String.Empty)
        {
            populate1.Parameters.Add("@p1", OleDbType.VarChar).Value = insertShipNo.Text;
        }
        if (insertShipNo.Text.ToString() == String.Empty)
        {
            populate1.Parameters.Add("@p1", OleDbType.Integer).Value = 0;
        }
        if (insertHospitalName.Text.ToString() != String.Empty)
        {
            populate1.Parameters.Add("@p2", OleDbType.VarChar).Value = insertHospitalName.Text;
        }
        if (insertHospitalName.Text.ToString() == String.Empty)
        {
            populate1.Parameters.Add("@p2", OleDbType.VarChar).Value = "";
        }
        if (insertSoldTo.Text.ToString() != String.Empty)
        {
            populate1.Parameters.Add("@p3", OleDbType.VarChar).Value = insertSoldTo.Text;
        }
        if (insertSoldTo.Text.ToString() == String.Empty)
        {
            populate1.Parameters.Add("@p3", OleDbType.Integer).Value = 0;
        }
        if (insertAddress1.Text.ToString() != String.Empty)
        {
            populate1.Parameters.Add("@p4", OleDbType.VarChar).Value = insertAddress1.Text;
        }
        if (insertAddress1.Text.ToString() == String.Empty)
        {
            populate1.Parameters.Add("@p4", OleDbType.VarChar).Value = "";
        }
        if (insertAddress2.Text.ToString() != String.Empty)
        {
            populate1.Parameters.Add("@p5", OleDbType.VarChar).Value = insertAddress2.Text;
        }
        if (insertAddress2.Text.ToString() == String.Empty)
        {
            populate1.Parameters.Add("@p5", OleDbType.VarChar).Value = "";
        }
        if (insertCityName.Text.ToString() != String.Empty)
        {
            populate1.Parameters.Add("@p6", OleDbType.VarChar).Value = insertCityName.Text;
        }
        if (insertCityName.Text.ToString() == String.Empty)
        {
            populate1.Parameters.Add("@p6", OleDbType.VarChar).Value ="";
        }
        if (insertProvince.Text.ToString() != String.Empty)
        {
            populate1.Parameters.Add("@p7", OleDbType.VarChar).Value = insertProvince.Text;
        }
        if (insertProvince.Text.ToString() == String.Empty)
        {
            populate1.Parameters.Add("@p7", OleDbType.VarChar).Value = "";
        }
        if (insertPostalCode.Text.ToString() != String.Empty)
        {
            populate1.Parameters.Add("@p8", OleDbType.VarChar).Value = insertPostalCode.Text;
        }
        if (insertPostalCode.Text.ToString() == String.Empty)
        {
            populate1.Parameters.Add("@p8", OleDbType.VarChar).Value = "";
        }
        
        populate1.Connection.Open();
        populate1.CommandType = CommandType.Text;
        try
        {
            populate1.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            string message2 = "ONLY INTEGER VALUES ALLOWED FOR SHIP TO #  AND SOLD TO #";

            System.Text.StringBuilder sb2 = new System.Text.StringBuilder();

            sb2.Append("<script type = 'text/javascript'>");

            sb2.Append("window.onload=function(){");

            sb2.Append("alert('");

            sb2.Append(message2);
            sb2.Append("')};");
            sb2.Append("</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "document.getElementById('insertform').style.display='inherit';", true);
           
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb2.ToString());
            
            return;
        }
        populate1.Connection.Close();
        populate1.Connection.Dispose();
        string message = "SUCCESFULLY INSERT DATA INTO EXCEL SHEET";
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