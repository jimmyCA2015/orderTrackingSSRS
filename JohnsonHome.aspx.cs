using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JonsonHome : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (currentUser.getValidation == 0 || currentUser.getUser != "Johnson")
            {
                Response.Redirect("~/Login.aspx");
            }

        }
    }
    protected void orderentryimage_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("orderentry.aspx");

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("SSRS.aspx");

    }
}