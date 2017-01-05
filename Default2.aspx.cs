using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
             HttpRequest q = Request;

            datenow.Text = q.QueryString["daterequest"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");

            datepickup1.Text = q.QueryString["p2"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            txtDropDown1.Text = q.QueryString["p3"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            datepickup2.Text = q.QueryString["p4"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            pickuprequestedby.Text = q.QueryString["p5"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            requester.Text = q.QueryString["p6"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            reference.Text = q.QueryString["p7"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            piece.Text = q.QueryString["p8"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            weight.Text = q.QueryString["p9"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            setcode.Text = q.QueryString["p10"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            cutofftime.Text = q.QueryString["p11"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            delivertime.Text = q.QueryString["p12"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            namepickup.Text = q.QueryString["p13"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            orgpickup.Text = q.QueryString["p22"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            contactpickup.Text = q.QueryString["p14"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            TextBox12.Text = q.QueryString["p15"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            timefreight.Text = q.QueryString["p16"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            deliverylocation.Text = q.QueryString["p17"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            deliveryto.Text = q.QueryString["p18"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            contactdelivery.Text = q.QueryString["p19"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            TextBox17.Text = q.QueryString["p20"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            Textarea1.Text = q.QueryString["p21"].Replace("specialcharacter1", "\"").Replace("specialcharacter2", "&").Replace("specialcharacter3", "#");
            
            

        }
    }
}