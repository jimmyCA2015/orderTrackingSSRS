<%@ Page Language="C#" AutoEventWireup="true" CodeFile="popup2.aspx.cs" Inherits="popup2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title></title>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/Float.js" type="text/javascript"></script>
    <script type = "text/javascript">
        $(function () {
            $(".Validators").Float();
        });
    </script>
      <script type = "text/javascript">
          function clearText() {
              var isValid = Page_ClientValidate("integercheck"); //parameter is the validation group - thanks @Jeff
              if (!isValid) {
                  document.getElementById('<%= ShipNo.ClientID %>').value = "";
              }

          }</script>

    <script type="text/javascript">
        function reloadParent() {

            window.close();
            window.opener.location.reload(true);
        }

     </script>
   <script type="text/javascript">
       function closepopup() {
           window.close();
           //alert('PLEASE  FILL OUT THE FORM ON THE RIGHT TO INSERT NEW ADDRESS INTO EXCEL SHEET');
           window.opener.location.reload(true);
       }
     </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
       <asp:Label ID="Label1" Text="Search By Ship To Number"  runat ="server" style="position:absolute; top: 21px; left: 23px;"></asp:Label>
        <asp:TextBox ID="ShipNo"     runat ="server" style="position:absolute; top: 21px; left: 210px;"></asp:TextBox>
         <asp:Label ID="Label4" Text="Pickup Location Search" runat ="server" style="position:absolute; top: 21px; left: 400px;font-weight:bold;font-size:large"></asp:Label>
        <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Integer"  CssClass="Validators" ForeColor="Red" 
         Display="Dynamic"  ControlToValidate="ShipNo" ErrorMessage="Whole Number Required" ValidationGroup="integercheck" />  
        <asp:Label ID="Label2" Text="OR" runat="server"  style="position:absolute; top: 51px; left: 23px;"></asp:Label>
         <asp:Label ID="Label3" Text="Search By Hospital Name"  runat ="server" style="position:absolute; top: 81px; left: 23px;"></asp:Label>
        <asp:TextBox ID="SoldNum"     runat ="server" style="position:absolute; top: 81px; left: 210px;"></asp:TextBox>
    </div>
    <asp:Button ID="Button1" Text="Search"  style="position:absolute; top: 81px; left: 400px;" runat="server" OnClientClick="clearText()"  OnClick="Unnamed2_Click" CausesValidation="true"></asp:Button>
    <asp:Button ID="insert" Text="ADD CUSTOMER"  style="position:absolute; top: 81px; left: 500px;" runat="server"   CausesValidation="false" OnClick="insert_Click" ></asp:Button>
    <asp:Button ID="confirm" Text="Confirm And Close window"  style="position:absolute; top: 81px; left: 700px;font-size:large;font-weight:bold" OnClientClick="reloadParent()" runat="server" Visible="false" ></asp:Button>
    <asp:GridView  style="position:absolute;top:130px;left:130px" ID="GridView1" runat="server" AutoGenerateEditButton="True"  BorderColor="black" AutoGenerateColumns="true" CellPadding="8" CellSpacing="0"  Font-Name="Verdana" Font-Size="8pt"  HeaderStyle-BackColor="#aaaadd"   AutoGenerateSelectButton="true" OnRowEditing="GridView1_RowEditing"   OnRowUpdating="GridView1_RowUpdating"   onselectedindexchanged="GridView1_SelectedIndexChanged"
       onselectedindexchanging="GridView1_SelectedIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" EnableViewState="true">  
        <HeaderStyle BackColor="lightblue" Font-Bold="true" ForeColor="green" Font-Size="Larger"></HeaderStyle>
     </asp:GridView>
     </form>
</body>
</html>