<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SSRS.aspx.cs" Inherits="SSRS" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"

    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">

    .modal

    {

        position: fixed;

        top: 0;

        left: 0;

        background-color: black;

        z-index: 99;

        opacity: 0.8;

        filter: alpha(opacity=80);

        -moz-opacity: 0.8;

        min-height: 100%;

        width: 100%;

    }

    .loading

    {

        font-family: Arial;

        font-size: 10pt;

        border: 5px solid #67CFF5;

        width: 300px;

        height: 100px;

        display: none;

        position: fixed;

        background-color: White;

        z-index: 999;

    }

</style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>

<script type="text/javascript">

    function ShowProgress() {

        setTimeout(function () {

            var modal = $('<div />');

            modal.addClass("modal");

            $('body').append(modal);

            var loading = $(".loading");

            loading.show();

            var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);

            var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);

            loading.css({ top: top, left: left });

        }, 0);

    }

    $('form').live("submit", function () {

        ShowProgress();

    });

</script>
     <script type="text/javascript">
         function PopupPicker(ctl, w, h) {
             var PopupWindow = null;
             settings = 'width=' + w + ',height=' + h + ',left=800px,top=300px,location=no,directories=no, menubar=no,toolbar=no,status=no,scrollbars=no,resizable=no, dependent=no';
             PopupWindow = window.open('DatePicker.aspx?Ctl=' +
                ctl, 'DatePicker', settings);
             PopupWindow.focus();
         }
   </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <div> 
           <img  style="position:absolute;left:0px;top:0px" src="companylogo.gif" width="100%" height="150px" />    
           <asp:Panel ID="Panel1"  style="position:absolute;border: 1px solid black; width: 100%; top:160px;left:0px" runat="server" >
           <asp:label ID="generallabel" style="position:absolute;width:100%;height:100px;background-color:#33CCFF;top:0px;left:0px;text-align:center;font-size:xx-large;padding-top:50px;font-weight:bold"  runat="server"></asp:label>
           <div id="Div1"  style="position:absolute;width:100%;height:50px;background-color:#33CCFF;top:100px;left:0px;text-align:left;"  runat="server">Option 1:Search By PO#/Reference # <br />Option 2: Search by pickup start date and pickup end date</div>
           <table style="background-color:lightblue;position:absolute;left:0px;top:150px;height:100px;"> 
           <tr >
              <td>P0 #/Reference #</td>
              <td><asp:TextBox id="referenceGeneral" runat="server"></asp:TextBox></td>
           </tr>
           <tr>
              <td>Pickup Start Date</td>
              <td><asp:TextBox id="pickupStart4" runat="server"></asp:TextBox></td>
              <td><asp:linkbutton ID="Linkbutton1" runat="server"   OnClientClick="PopupPicker('pickupStart4', 250, 250)" ><img src="calendar.gif" alt="delete group" /></asp:linkbutton></td>
              <td style="padding-right:10px"> </td>
              <td>Pickup End Date</td>
              <td><asp:TextBox id="pickupEnd4" runat="server"></asp:TextBox></td>
              <td><asp:linkbutton ID="Linkbutton2" runat="server"   OnClientClick="PopupPicker('pickupEnd4', 250, 250)" ><img src="calendar.gif" alt="delete group" /></asp:linkbutton></td>
              <td style="padding-right:100px"> </td>
              <td ><asp:button id="viewSearch" runat="server" Text="ViewReport" OnClick="viewSearch_Click4"></asp:button></td>
              <td ><asp:button id="viewPDF" runat="server" Text="Download P.O.D. Files"  onclick="downloadpdf"  visible="false"></asp:button></td>
           </tr>
          </table>
        <rsweb:ReportViewer style="position:absolute;left:0px;top:250px" ID="ReportViewer4" runat="server" Width="100%"   Height="100%"  AsyncRendering="False"  SizeToReportContent="True"  ShowParameterPrompts="true" ProcessingMode="Remote">
        </rsweb:ReportViewer>
      </asp:Panel>
</div>
         <div class="loading" align="center">

    Loading(it make take up to 30 seconds to reload). Please wait.<br />

    <br />

    <img src="report.jpg" width="300px" height="80px" alt="" />

</div>
    </form>
</body>
</html>
