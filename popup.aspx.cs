using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

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


public partial class popup : System.Web.UI.Page
{
    public DataView currentlist;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["hospitalname"] = "";
        Session["address"] = "";
        Session["shipno"] = "";
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //Set the edit index.
        GridView1.EditIndex = e.NewEditIndex;
        bindData();
        GridView1.Rows[e.NewEditIndex].Cells[1].Enabled = false;
        GridView1.Rows[e.NewEditIndex].Cells[3].Enabled = false;
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Set the edit index.
        GridView1.EditIndex = -1;
        //Update the values.
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/excel/address.xls") + ";Extended Properties='Excel 8.0;HDR=Yes;'";
        OleDbConnection connection = new OleDbConnection(connectionString);
        //connection.Open();
        //this next line assumes that the file is in default Excel format with Sheet1 as the first sheet name, adjust accordingly
        //OleDbCommand populate1 = new OleDbCommand("SELECT * FROM [depuycustomers$] WHERE [SHIP TO]=? OR [SOLD TO]=?", connection);
        OleDbDataAdapter populate2 = new OleDbDataAdapter("SELECT * FROM [depuycustomers$] WHERE [SHIP TO]=? OR UCase([HOSPITAL NAME]) like ? ", connection);

        if (ShipNo.Text.ToString() != String.Empty)
        {
            populate2.SelectCommand.Parameters.Add("@p1", OleDbType.VarChar).Value = ShipNo.Text;
        }
        if (ShipNo.Text.ToString() == String.Empty)
        {
            populate2.SelectCommand.Parameters.Add("@p1", OleDbType.VarChar).Value = DBNull.Value;
        }
        if (SoldNum.Text.ToString() != String.Empty)
        {
            populate2.SelectCommand.Parameters.Add("@p2", OleDbType.VarChar).Value = "%" + SoldNum.Text.ToUpper() + "%";
        }
        if (SoldNum.Text.ToString() == String.Empty)
        {
            populate2.SelectCommand.Parameters.Add("@p2", OleDbType.VarChar).Value = DBNull.Value;
        }
        DataSet ds = new DataSet();
        populate2.Fill(ds);
        //OleDbDataReader ddlValues;
        connection.Open();
        populate2.SelectCommand.CommandType = CommandType.Text;
        populate2.SelectCommand.ExecuteNonQuery();
        GridViewRow row = GridView1.Rows[e.RowIndex];
        ds.Tables[0].Rows[0]["HOSPITAL NAME"] = ((TextBox)(row.Cells[2].Controls[0])).Text;
        ds.Tables[0].Rows[0]["ADDRESS 1 "] = ((TextBox)(row.Cells[4].Controls[0])).Text;
        ds.Tables[0].Rows[0]["ADDRESS 2"] = ((TextBox)(row.Cells[5].Controls[0])).Text;
        ds.Tables[0].Rows[0]["CITY NAME"] = ((TextBox)(row.Cells[6].Controls[0])).Text;
        ds.Tables[0].Rows[0]["PROVINCE"] = ((TextBox)(row.Cells[7].Controls[0])).Text;
        ds.Tables[0].Rows[0]["POSTAL CODE"] = ((TextBox)(row.Cells[8].Controls[0])).Text;
        DataView source = new DataView(ds.Tables[0]);
        GridView1.DataSource = source;
        GridView1.DataBind();
        connection.Close();
        if (ds.Tables[0].Rows.Count != 0)
        {
            Session["hospitalname"] = ds.Tables[0].Rows[0]["HOSPITAL NAME"];
            currentAddress.getDeliveryTo = (String)Session["hospitalname"];
        }
        if (ds.Tables[0].Rows.Count != 0)
        {
            Session["address"] = ds.Tables[0].Rows[0]["ADDRESS 1 "] + " - " + ds.Tables[0].Rows[0]["ADDRESS 2"] + "  " + ds.Tables[0].Rows[0]["CITY NAME"] + "  " + ds.Tables[0].Rows[0]["PROVINCE"] + "  " + ds.Tables[0].Rows[0]["POSTAL CODE"];
            currentAddress.getDeliveryLocation = (String)Session["address"];
        }
        if (ds.Tables[0].Rows.Count != 0)
        {
            Session["shipno"] = ds.Tables[0].Rows[0]["SHIP TO"];
            currentAddress.getShipToNumber = Session["shipno"].ToString();
        }
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    
    {
        //Set the edit index.
        GridView1.EditIndex = -1;
        bindData();

    }
    protected void GridView1_SelectedIndexChanged(Object sender, EventArgs e)
    {
        // Get the currently selected row using the SelectedRow property.
        GridViewRow row = GridView1.SelectedRow;

        // Display the first name from the selected row.
        // In this example, the third column (index 2) contains
        // the first name.
        string message = "SUCCESSFULLY SELECT HOSPITAL: " + row.Cells[2].Text.Replace("&amp;", "&").Replace("&nbsp;", " ").Replace("&#39;", "'") + " WITH SHIP TO NO: " + row.Cells[1].Text;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append("<script type = 'text/javascript'>");
        sb.Append("window.onload=function(){");
        sb.Append("alert('");
        sb.Append(message);
        sb.Append("')};");
        sb.Append("</script>");
        //ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
         ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "window.close();  window.opener.location.reload(true);", true);
    }
    protected void GridView1_SelectedIndexChanging(Object sender, GridViewSelectEventArgs e)
    {
        // Get the currently selected row. Because the SelectedIndexChanging event
        // occurs before the select operation in the GridView control, the
        // SelectedRow property cannot be used. Instead, use the Rows collection
        // and the NewSelectedIndex property of the e argument passed to this 
        // event handler.
        GridViewRow row = GridView1.Rows[e.NewSelectedIndex];
        // You can cancel the select operation by using the Cancel
        // property. For this example, if the user selects a customer with 
        // the ID "ANATR", the select operation is canceled and an error message
        // is displayed.
        Session["hospitalname"] = row.Cells[2].Text.Replace("&amp;", "&").Replace("&nbsp;", " ").Replace("&#39;", "'");
        Session["address"] = row.Cells[4].Text.Replace("&amp;", "&").Replace("&nbsp;", " ").Replace("&#39;", "'") + " - " + row.Cells[5].Text.Replace("&amp;", "&").Replace("&nbsp;", " ").Replace("&#39;", "'") + "  " + row.Cells[6].Text.Replace("&amp;", "&").Replace("&nbsp;", " ").Replace("&#39;", "'") + "  " + row.Cells[7].Text.Replace("&amp;", "&").Replace("&nbsp;", " ").Replace("&#39;", "'") + "  " + row.Cells[8].Text.Replace("&amp;", "&").Replace("&nbsp;", " ").Replace("&#39;", "'");
        Session["shipno"] = row.Cells[1].Text;
        currentAddress.getDeliveryLocation = (String)Session["address"];
        currentAddress.getDeliveryTo = (String)Session["hospitalname"];
        currentAddress.getShipToNumber = Session["shipno"].ToString();
    }
    protected void Unnamed2_Click(object sender, EventArgs e)
    {
        bindData();
    }
    protected void bindData()
    {
        string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("~/excel/address.xls") + ";Extended Properties='Excel 8.0;HDR=Yes;'";
        OleDbConnection connection = new OleDbConnection(connectionString);
        //connection.Open();
        //this next line assumes that the file is in default Excel format with Sheet1 as the first sheet name, adjust accordingly
        //OleDbCommand populate1 = new OleDbCommand("SELECT * FROM [depuycustomers$] WHERE [SHIP TO]=? OR [SOLD TO]=?", connection);
            OleDbDataAdapter populate2 = new OleDbDataAdapter("SELECT * FROM [depuycustomers$] WHERE [SHIP TO]=? OR UCase([HOSPITAL NAME]) LIKE  ? ", connection);
            if (ShipNo.Text.ToString() != String.Empty)
            {
                populate2.SelectCommand.Parameters.Add("@p1", OleDbType.VarChar).Value = ShipNo.Text;
            }
            if (ShipNo.Text.ToString() == String.Empty)
            {
                populate2.SelectCommand.Parameters.Add("@p1", OleDbType.VarChar).Value = DBNull.Value;
            }
            if (SoldNum.Text.ToString() != String.Empty)
            {
                populate2.SelectCommand.Parameters.Add("@p2", OleDbType.VarChar).Value = "%" + SoldNum.Text.ToUpper() + "%";
            }
            if (SoldNum.Text.ToString() == String.Empty)
            {
                populate2.SelectCommand.Parameters.Add("@p2", OleDbType.VarChar).Value = DBNull.Value;
                /* string message = "please enter SOLD TO Number as well ";
                 System.Text.StringBuilder sb = new System.Text.StringBuilder();
                 sb.Append("<script type = 'text/javascript'>");
                 sb.Append("window.onload=function(){");
                 sb.Append("alert('");
                 sb.Append(message);
                 sb.Append("')};");
                 sb.Append("</script>");
                 ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                 */
            }
                DataSet ds = new DataSet();
                try
                {
                    populate2.Fill(ds);
                }
                catch
                {
                    string message = "DATA NOT FOUND,PLEASE ENTER A VALID SHIP TO NUMBER OR  SEARCH BY HOSPITAL NAME ";
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    return;
                }
                if (ds.Tables[0].Rows.Count == 0)
                {
                    string message = "DATA NOT FOUND,PLEASE ENTER A VALID SHIP TO NUMBER OR  SEARCH BY HOSPITAL NAME  ";

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();

                    sb.Append("<script type = 'text/javascript'>");

                    sb.Append("window.onload=function(){");

                    sb.Append("alert('");

                    sb.Append(message);
                    sb.Append("')};");
                    sb.Append("</script>");
            
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    
                    return;

                }
            
            
        //OleDbDataReader ddlValues;
        connection.Open();
        populate2.SelectCommand.CommandType = CommandType.Text;
        
        populate2.SelectCommand.ExecuteNonQuery();
        
        
        DataView source = new DataView(ds.Tables[0]);

        GridView1.DataSource = source;

        GridView1.DataBind();
        connection.Close();
        confirm.Visible = true;
        if (ds.Tables[0].Rows.Count != 0)
        {
            if (ds.Tables[0].Rows[0]["HOSPITAL NAME"] != String.Empty && ds.Tables[0].Rows[0]["HOSPITAL NAME"] != DBNull.Value)
            {
                Session["hospitalname"] = ds.Tables[0].Rows[0]["HOSPITAL NAME"];

                currentAddress.getDeliveryTo = (String)Session["hospitalname"];
            }
        }
        if (ds.Tables[0].Rows.Count != 0)
        {
            Session["address"] = ds.Tables[0].Rows[0]["ADDRESS 1 "] + " - " + ds.Tables[0].Rows[0]["ADDRESS 2"] + "  " + ds.Tables[0].Rows[0]["CITY NAME"] + "  " + ds.Tables[0].Rows[0]["PROVINCE"] + "  " + ds.Tables[0].Rows[0]["POSTAL CODE"];
            currentAddress.getDeliveryLocation = (String)Session["address"];
        }
        if (ds.Tables[0].Rows.Count != 0)
        {
            Session["shipno"] = ds.Tables[0].Rows[0]["SHIP TO"];
            currentAddress.getShipToNumber = Session["shipno"].ToString();
        }
        
        
    }


    protected void insert_Click(object sender, System.EventArgs e)
    {
        Session["DISPLAYFORM"] = "YES";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "window.close();  window.opener.location.reload(true);", true);
    }
}