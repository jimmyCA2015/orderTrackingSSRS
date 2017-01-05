<%@ Page Language="C#" AutoEventWireup="true" CodeFile="JohnsonHome.aspx.cs" Inherits="JonsonHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body >
    <form id="form1" runat="server">
    <div>
      <img style="position:absolute;left:0px;top:0px" src="companylogo.gif" width="60%" height="150" />
            <img style="position:absolute;left:60%;top:0px" src="johnson.png" width="40%" height="150" />
         <!--<img style="position:absolute;left:0px;top:150px" src="johnsonbak.jpg" width="100%" height="100%" /><br /><br />-->
    </div>        
    <div style="height:200px">&nbsp;</div>
        <div>
            <asp:label style="float:left;text-align:center;padding:30px 50px 30px" Font-Bold="true" ID="label1" runat="server" ><asp:ImageButton  ID ="ImageButton2"  src="images/order_icon.jpg" runat="server" OnClick="orderentryimage_Click"  /><br />Order Entry</asp:label>
            <asp:label style="float:left;text-align:center;padding:30px 50px 30px" Font-Bold="true" ID="label2" runat="server" ><asp:ImageButton ID="ImageButton1"  src="images/report_icon.jpg" runat="server"  OnClick="ImageButton1_Click" /><br />Order Status Report</asp:label>
        </div>        
    </form>
</body>
</html>
