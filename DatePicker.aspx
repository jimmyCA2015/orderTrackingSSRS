<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DatePicker.aspx.cs" Inherits="DatePicker" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script  type="text/javascript">
        function SetDate(dateValue) {
            // retrieve from the querystring the value of the Ctl param,
            // that is the name of the input control on the parent form
            // that the user want to set with the clicked date
            ctl = window.location.search.substr(1).substring(4);
            // set the value of that control with the passed date
            thisForm = window.opener.document.forms[0].elements[ctl].value =
               dateValue;
            // close this popup
            self.close();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:calendar id="calendar1"  OnDayRender="Calendar1_DayRender" runat ="server"></asp:calendar>
    </div>
    </form>
</body>
</html>