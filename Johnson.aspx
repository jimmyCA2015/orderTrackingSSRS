﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Johnson.aspx.cs" Inherits="Johnson" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"

    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title></title>
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
           <!--<img style="position:absolute;left:0px;top:0px" src="companylogo.gif" width="60%" height="150px" />
           <img style="position:absolute;left:60%;top:0px" src="johnson.png" width="40%" height="150px" /><br /><br />-->
  <asp:Panel ID="Panel1"  style="position:absolute;border: 1px solid black; width: 100%; top:0px;left:0px" runat="server" >
  <!--<asp:label ID="Label1" style="position:absolute;width:100%;height:100px;background-color:#33CCFF;top:0px;left:0px;text-align:center;"  runat="server"><h1>Johnson&Johnson SSRS REPORT</h1></asp:label>
  <div id="Div1"  style="position:absolute;width:100%;height:50px;background-color:#33CCFF;top:100px;left:0px;text-align:left;"  runat="server">Option 1:Search By PO#/Reference # <br />Option 2: Search by pickup start date and pickup end date</div>-->
  <table style="background-color:lightblue;position:absolute;left:0px;top:0px;height:100px"> 
     <tr >
         <td>Pickup Start Date</td>
         <td><asp:TextBox id="pickupStart3" runat="server"></asp:TextBox></td>
         <td><asp:linkbutton ID="Linkbutton1" runat="server"   OnClientClick="PopupPicker('pickupStart3', 250, 250)" ><img src="calendar.gif" alt="delete group" /></asp:linkbutton></td>
         <td style="padding-right:10px"> </td>
         <td>Pickup End Date</td>
          <td><asp:TextBox id="pickupEnd3" runat="server"></asp:TextBox></td>
         <td><asp:linkbutton ID="Linkbutton2" runat="server"   OnClientClick="PopupPicker('pickupEnd3', 250, 250)" ><img src="calendar.gif" alt="delete group" /></asp:linkbutton></td>
         <td style="padding-right:100px"> </td>
         <td ><asp:button id="viewSearch" runat="server" Text="ViewReport" OnClick="viewSearch_Click3"></asp:button></td>
     </tr>
     <tr>
         <td>P0 #/Reference #</td>
         <td><asp:TextBox id="referenceJohn" runat="server"></asp:TextBox></td>
         <td colspan="6"></td>
         <td ><asp:button id="downloadfile" runat="server" Text="Download P.O.D. Files" OnClick="download" Visible="false"></asp:button></td>
     </tr>
   </table>
    <rsweb:ReportViewer style="position:absolute;left:0px;top:100px" ID="ReportViewer3" runat="server" Width="100%"   Height="100%"  AsyncRendering="False"  SizeToReportContent="True"  ShowParameterPrompts="true" ProcessingMode="Remote">
    </rsweb:ReportViewer>
  </asp:Panel>
</div>
     </form>
</body>
</html>
