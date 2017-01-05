<%@ Page Language="C#" AutoEventWireup="true" CodeFile="orderentry.aspx.cs" Inherits="orderentry" %>


<!DOCTYPE html>

 <html xmlns="http://www.w3.org/1999/xhtml">
 <head id="Head1" runat="server">
     <title></title>
     <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>
     <link href="//netdna.bootstrapcdn.com/bootstrap/3.3.2/css/bootstrap.min.css" rel="stylesheet"/>
     <script src="//netdna.bootstrapcdn.com/bootstrap/3.3.2/js/bootstrap.min.js"></script>
     <script src="//cdnjs.cloudflare.com/ajax/libs/moment.js/2.8.4/moment.min.js"></script>
     <link href="build/css/bootstrap-datetimepicker.css" rel="stylesheet"/>
     <script src="build/js/bootstrap-datetimepicker.min.js"></script>
     <script src="Scripts/Float.js" type="text/javascript"></script>
     <script type="text/javascript">
         function placeholder1() {
             if (document.getElementById('<%= deliverylocation.ClientID %>').value == "Address not found")
             {
                document.getElementById('<%= deliverylocation.ClientID %>').value = "";
             }
         }
         function placeholder2() {
             if (document.getElementById('<%= deliveryto.ClientID %>').value == "Address not found") {
                 document.getElementById('<%= deliveryto.ClientID %>').value = "";
             }
         }
         function placeholder3() {
             if (document.getElementById('<%= contactdelivery.ClientID %>').value == "Please Enter Contact Info.") {
                 document.getElementById('<%= contactdelivery.ClientID %>').value = "";
                 document.getElementById('<%= contactdelivery.ClientID %>').style.color = "black";
             }
         }
         function placeholder4() {
             if (document.getElementById('<%= TextBox17.ClientID %>').value == "Please Enter Location Info.") {
                 document.getElementById('<%= TextBox17.ClientID %>').value = "";
                 document.getElementById('<%= TextBox17.ClientID %>').style.color = "black";
             }
         }
         function placeholder5() {
             if (document.getElementById('<%= contactpickup.ClientID %>').value == "Please Enter Contact Info.") {
                  document.getElementById('<%= contactpickup.ClientID %>').value = "";
                 document.getElementById('<%= contactpickup.ClientID %>').style.color = "black";
             }
         }
         function placeholder6() {
             if (document.getElementById('<%= TextBox12.ClientID %>').value == "Please Enter Location Info.") {
                 document.getElementById('<%= TextBox12.ClientID %>').value = "";
                 document.getElementById('<%= TextBox12.ClientID %>').style.color = "black";
             }
         }
         function default1() {
             if (document.getElementById('<%= contactdelivery.ClientID %>').value == "") {
                 document.getElementById('<%= contactdelivery.ClientID %>').value = "Please Enter Contact Info.";
                 document.getElementById('<%= contactdelivery.ClientID %>').style.color = "red";
             } 
         }
         function default2() {
             if (document.getElementById('<%= TextBox17.ClientID %>').value == "") {
                 document.getElementById('<%= TextBox17.ClientID %>').value = "Please Enter Location Info.";
                 
             }
         }
         function default3() {
             if (document.getElementById('<%= contactpickup.ClientID %>').value == "") {
                     document.getElementById('<%= contactpickup.ClientID %>').value = "Please Enter Contact Info.";
                 document.getElementById('<%= contactpickup.ClientID %>').style.color = "red";
             }
         }
        
         function default4() {
             if (document.getElementById('<%= TextBox12.ClientID %>').value == "") {
                   document.getElementById('<%= TextBox12.ClientID %>').value = "Please Enter Location Info.";
                 
             }
         }
         function visible() {
             document.getElementById('feature').style.display='inherit';
         }
         function invisible() {
             document.getElementById('feature').style.display = 'none';
         }
         function visible2() {
             document.getElementById('feature2').style.display = 'inherit';
         }
         function invisible2() {
             document.getElementById('feature2').style.display = 'none';
         }
     </script>
     <script type = "text/javascript">
         $(function () {
             $(".Validators").Float();
         });
    </script>
      <script type = "text/javascript">
          function openWindow() {
           window.open('popup.aspx', '', 'status=1,toolbar=0,menubar=0,location=1,scrollbars=1,resizable=1,top=500,left=700,width=1200,height=300');
          }
          function openWindow2() {
              window.open('popup2.aspx', '', 'status=1,toolbar=0,menubar=0,location=1,scrollbars=1,resizable=1,top=500,left=700,width=1200,height=300');
          }
      </script>
     <script type = "text/javascript">
         function clearText() {
             var isValid = Page_ClientValidate("integercheck"); //parameter is the validation group - thanks @Jeff
             if (!isValid) {
                 document.getElementById('<%= piece.ClientID %>').value = "";
             }
             if (typeof (Page_ClientValidate) == 'function') {
                 Page_ClientValidate();
             }
             if (!Page_IsValid) {
                 alert('Please fill all required fields before bubmitting the form. Thank You');
             }
         }
     </script>
     <script>
         $("wow2").click(function () {
             $("#test").table2excel({
                 exclude: ".noExl",
                 name: "Excel Document Name"
             });

         });
     </script>
     <script type="text/javascript">
         $(function () {
             $('.datetimepicker1').datetimepicker();

         });
     </script>
   <style>
        .firstcolumn {
            color:black;
            font-weight:bold;
             width:400px;
             height:25px;
             text-align:center;
         }
         .secondcolumn {
             width:600px;
             height:25px;
             text-align:center;
         }
         .firstcolumn2 {
            color:black;
            font-weight:bold;
             width:400px;
             height:35px;
             text-align:center;
         }
         .secondcolumn2 {
             width:600px;
             height:35px;
             text-align:center;
         }
          .secondcolumn3 {
            float:left;
             width:400px;
             height:25px;
             text-align:center;
         }
         .thirdcolumn3 {
              width:200px;
             height:25px;
             text-align:center;
         }
     </style>
 </head>
 <body>
     <form id="form1" runat="server" method="get">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div>
    <table  border="1" style="border-collapse:collapse;border-color:black;width:1000px" >
        <tr>
            <td colspan="2" style="width:1000px;height:25px;background-color:yellow;text-align:center">
            Johnson & Johnson - DePuy / Synthes Loaner Pick Up Programme 
            </td>
        </tr>
           <td colspan="2" style="width:1000px;height:25px;background-color:yellow;text-align:center">
                 Pick Up Request / Detail for Carrier 
           </td>
        <tr>
           <td colspan="2"  style="width:1000px;height:25px;text-align:center;color:rgb(0, 148, 255);font-size:xx-large">
                 Carrier Information
           </td>
        </tr>
        <tr >
            <td class="firstcolumn">
                Carrier
            </td>
            <td class="secondcolumn">
               Rogue
            </td>
         </tr>
        <tr>
            <td class="firstcolumn">
                Call Centre

            </td>
            <td style="text-decoration: underline;" class="secondcolumn" >
              <a href = "mailto:customerservice@roguedelivers.com">customerservice@roguedelivers.com</a>
            </td>
        </tr>
        <tr>
             <td class="firstcolumn">
                Customer Service Number
            </td>
            <td  class="secondcolumn" >
              905-362-9401
            </td>
        </tr>
          <tr>
             <td class="firstcolumn">
               Date /Time Of Request
            </td>
            <td   class="secondcolumn">
              <asp:TextBox ID="datenow" class="secondcolumn" runat="server"></asp:TextBox>
            </td>
        </tr>
          <tr>
             <td class="firstcolumn">
               Date Of Pick Up Request
            </td>
            <td>
               <div style="width:600px;height:25px" class="container">
              <div class="row">
                 <div class="col-md-6" >
                    <asp:textbox ID="datepickup1"  class="datetimepicker1" style="width:500px;height:25px;position:absolute;left:0px;text-align:center"    runat="server"></asp:textbox>
                 </div>
                  <span class="input-group-addon" style="width:100px;height:25px;float:right">
                     <span class="glyphicon glyphicon-calendar"></span>
                     </span>
                 </div>
              </div>
           </td>
          </tr>
           <tr>
             <td class="firstcolumn">
               Service Description (Select from Drop Down)
            </td>
            <td  class="secondcolumn">
              <asp:DropDownList ID="txtDropDown1" runat="server"  style="color:black" class="secondcolumn" AutoPostBack="True"  >
                  <asp:ListItem >Pre-Scheduled</asp:ListItem>
                  <asp:ListItem >Direct Drive </asp:ListItem>
                  <asp:ListItem >Rush</asp:ListItem>
                  <asp:ListItem >Regular</asp:ListItem>
                  <asp:ListItem>Same Day Delivery</asp:ListItem>
          </asp:DropDownList>
            </td>
          </tr>
         <tr>
             <td  class="firstcolumn">
               Date Freight Needs to Pick Up On
            </td>
            <td   class="secondcolumn">
                <div style="width:600px;height:25px" class="container">
              <div class="row">
                 <div class="col-md-6">
                    <asp:textbox ID="datepickup2" class="datetimepicker1" style="width:500px;height:25px;position:absolute;left:0px;text-align:center"  runat="server"></asp:textbox>
                 </div>
                  <span class="input-group-addon" style="width:100px;height:25px;float:right">
                     <span class="glyphicon glyphicon-calendar"></span>
                     </span>
                 </div>
              </div>
            </td>
          </tr>
         <tr>
             <td  class="firstcolumn">
               Pick Up Requested By
            </td>
            <td   class="secondcolumn">
              <asp:TextBox ID="pickuprequestedby" class="secondcolumn" runat="server"  ></asp:TextBox>
            </td>
          </tr>
          <tr>
             <td  class="firstcolumn">
               Contact Information of Requester
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="requester"  class="secondcolumn" runat="server"></asp:TextBox>
            </td>
          </tr>
        <tr>
           <td colspan="2"  style="width:1000px;height:25px;text-align:center;color:rgb(0, 148, 255);font-size:xx-large">
                 Order Detail
           </td>
        </tr>
            <tr>
             <td class="firstcolumn">
               JnJ Reference Number
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="reference"  class="secondcolumn" runat="server"></asp:TextBox>
            </td>
          </tr>
            <tr>
             <td  class="firstcolumn">
                Piece Count to be Picked Up
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="piece"  class="secondcolumn" runat="server"></asp:TextBox>
            </td>
          </tr>
        <tr>
             <td  class="firstcolumn">
                Total Weight Of Pieces
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="weight"  class="secondcolumn" runat="server"></asp:TextBox>
            </td>
          </tr>
           <tr>
             <td  class="firstcolumn">
               SET CODES
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="setcode"  class="secondcolumn" runat="server"></asp:TextBox>
            </td>
          </tr>
           <tr>
             <td  class="firstcolumn">
               Order Cutoff Time
            </td>
            <td   class="secondcolumn">
              <div style="width:600px;height:25px" class="container">
              <div class="row">
                 <div class="col-md-6">
                    <asp:textbox ID="cutofftime" class="datetimepicker1" style="width:500px;height:25px;position:absolute;left:0px;text-align:center"  runat="server"></asp:textbox>
                 </div>
                  <span class="input-group-addon" style="width:100px;height:25px;float:right">
                     <span class="glyphicon glyphicon-calendar"></span>
                     </span>
                 </div>
              </div>
            </td>
          </tr>
        <tr>
             <td  class="firstcolumn">
              Delivery By Time
            </td>
            <td   class="secondcolumn">
              <div style="width:600px;height:25px" class="container">
              <div class="row">
                 <div class="col-md-6">
                    <asp:textbox ID="delivertime" class="datetimepicker1" style="width:500px;height:25px;position:absolute;left:0px;text-align:center"  runat="server"></asp:textbox>
                 </div>
                  <span class="input-group-addon" style="width:100px;height:25px;float:right">
                     <span class="glyphicon glyphicon-calendar"></span>
                     </span>
                 </div>
              </div>
            </td>
          </tr>
     
        <tr>
           
           <td colspan="2"  style="width:1000px;height:25px;text-align:center;color:rgb(0, 148, 255);font-size:xx-large">
                 Pick Up Location
           </td>
            
        </tr>
           <tr>
            <td  class="firstcolumn">
               ShipToNo
            </td>
            <td   class="secondcolumn">
             <asp:TextBox  ID="shippick" class="secondcolumn3"   runat="server"></asp:TextBox>
            
             <asp:Button ID="Button3" class="thirdcolumn3"  Text="Read Search/Add Customer" runat="server" OnClientClick="openWindow2();" CausesValidation="False"></asp:Button>
            </td>
          </tr>

       
          <tr>
             <td class="firstcolumn" >
               Pickup Location(Full Address) 
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="namepickup"  class="secondcolumn" runat="server"></asp:TextBox>
            </td>
          </tr>
           <tr>
             <td class="firstcolumn">
              Organization Freight To Be Picked Up From
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="orgpickup"  class="secondcolumn" runat="server"></asp:TextBox>
            </td>
          </tr>
          <tr>
            <td  class="firstcolumn">
               Name Of Contact at Pick Up Location
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="contactpickup"  class="secondcolumn" onClick="placeholder5()"  onfocusout="default3()"  runat="server"></asp:TextBox>
            </td>

          </tr>
        <tr>
            <td  class="firstcolumn">
               Specifics regarding location/area of pick up
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="TextBox12"  class="secondcolumn" onClick="placeholder6()"  onfocusout="default4()"  runat="server"></asp:TextBox>
            </td>

          </tr>
        <tr>
            <td  class="firstcolumn">
               Time freight will be available for pick up
            </td>
            <td   class="secondcolumn">
              <div style="width:600px;height:25px" class="container">
              <div class="row">
                 <div class="col-md-6">
                    <asp:textbox ID="timefreight" class="datetimepicker1" style="width:500px;height:25px;position:absolute;left:0px;text-align:center"  runat="server"></asp:textbox>
                 </div>
                  <span class="input-group-addon" style="width:100px;height:25px;float:right">
                     <span class="glyphicon glyphicon-calendar"></span>
                     </span>
                 </div>
              </div>
            </td>

          </tr>
        <tr>
           <td colspan="2"  style="width:1000px;height:25px;text-align:center;color:rgb(0, 148, 255);font-size:xx-large">
               <asp:Label style="width:200px" runat="server"></asp:Label>
               <asp:Label  style="text-align:right;width:800px;" runat="server">Delivery Information</asp:Label> 
            <!--<asp:Button Text="populate address " style="width:200px;float:right;height:100%;font-size:medium;color:black;" OnClientClick="openWindow();return false;" CausesValidation="false"  runat="server"></asp:Button>-->
           </td>
        </tr>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
          <tr>
            <td  class="firstcolumn">
               ShipToNo
            </td>
            <td   class="secondcolumn">
             <asp:TextBox  ID="shipNo" class="secondcolumn3"   runat="server"></asp:TextBox>
            
             <asp:Button ID="populate" class="thirdcolumn3"  Text="Read Search/Add Customer" runat="server" OnClientClick="openWindow();" CausesValidation="False"></asp:Button>
            </td>
          </tr>
        <tr>
            <td  class="firstcolumn">
               Delivery Location(Full Address)
            </td>
            <td   class="secondcolumn">
             
             <asp:TextBox  ID="deliverylocation" class="secondcolumn"  OnClick="placeholder1()" runat="server"></asp:TextBox>
              
            </td>

          </tr>
        <tr>
            <td  class="firstcolumn">
               Organization freight to be delivered to
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="deliveryto"  class="secondcolumn" OnClick="placeholder2()" runat="server"></asp:TextBox>
            </td>

          </tr>
               </ContentTemplate>
         
          </asp:UpdatePanel>
        <tr>
            <td  class="firstcolumn">
               Name Of Contact at Delivery Location
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="contactdelivery"  class="secondcolumn" onClick="placeholder3()"  onfocusout="default1()" runat="server" ></asp:TextBox>
            </td>

          </tr>
          <tr>
            <td  class="firstcolumn">
              Specifics regarding location/area of delivery
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="TextBox17"  class="secondcolumn"  onClick="placeholder4()" onfocusout="default2()" runat="server"></asp:TextBox>
            </td>

          </tr>
           <tr>
            <td class="firstcolumn2">
             additional Comments/Notes/Instructions
            </td>
            <td   class="secondcolumn2">
             <ASP:TextBox id="Textarea1"  TextMode="MultiLine" rows="4"  cols="10" class="secondcolumn2" runat="server">Enter Your Comments</ASP:TextBox>
            </td>
          </tr>
    </table>
     </div>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="deliverylocation" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="deliveryto" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="timefreight" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="contactpickup" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="namepickup" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="delivertime" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="weight" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator8" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="cutofftime" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator9" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="piece" runat="server"
     ErrorMessage="Required Field and only whole number is allowed"></asp:RequiredFieldValidator>

          <asp:RequiredFieldValidator ID="RequiredFieldValidator10" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="reference" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>
         
          <asp:RequiredFieldValidator ID="RequiredFieldValidator11" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="requester" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>

         
          <asp:RequiredFieldValidator ID="RequiredFieldValidator12" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="pickuprequestedby" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>
         
          <asp:RequiredFieldValidator ID="RequiredFieldValidator13" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="datepickup1" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>

         <asp:RequiredFieldValidator ID="RequiredFieldValidator14" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="datepickup2" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>

         <asp:RequiredFieldValidator ID="RequiredFieldValidator15" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="setcode" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>
         <asp:RequiredFieldValidator ID="RequiredFieldValidator16" CssClass="Validators" ForeColor="Red" 
     Display="Dynamic" ControlToValidate="contactdelivery" runat="server"
     ErrorMessage="Required Field"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Type="Integer"  CssClass="Validators" ForeColor="Red" 
  Display="Dynamic"  ControlToValidate="piece" ErrorMessage="" ValidationGroup="integercheck" />  
         
         <br />
       <!--<asp:Button ID="open" style="position:absolute;left:1010px;top:725px" runat="server" Text="SECOND OPTION:POPULATE DELIVERY ADDRESS FROM A POPUP WINDOW" OnClientClick="openWindow();"  CausesValidation="false"  ></asp:Button>-->
       <asp:Button ID="Button2" style="position:absolute;left:1200px;top:725px" runat="server" Text="Refresh" OnClick="Unnamed3_Click" CausesValidation="false" Visible="false"  ></asp:Button>
       <asp:label ID="feature" style="position:absolute;left:1010px;top:740px;display:none" runat="server" Text="New Feature:Click on 'Read Search/Add Customer' to search for a delivery location"  CausesValidation="false"  ></asp:label>
       <asp:label ID="feature2" style="position:absolute;left:1010px;top:540px;display:none" runat="server" Text="New Feature:Click on 'Read Search/Add Customer' to search for a pickup location"  CausesValidation="false"  ></asp:label>
       <asp:Image  style="position:absolute;left:1010px;top:780px;width:30px;height:30px" ID ="ImageButtonNewFeature"  onmouseover="visible()" onmouseout="invisible()" src="images/asterisk.jpg" runat="server" />
       <asp:Image  style="position:absolute;left:1010px;top:580px;width:30px;height:30px" ID ="Image1"  onmouseover="visible2()" onmouseout="invisible2()" src="images/asterisk.jpg" runat="server" />
       <asp:Button ID="Button1"   OnClick="Unnamed2_Click" OnClientClick="clearText();" Text="SEND FORM" runat="server" > </asp:Button>
       <asp:Label ID="status" runat="server" style="color:red"></asp:Label>
       <div  id="insertform" style="position:absolute;left:1050px;top:200px;width:500px;height:500px;border-color:black;border-style:solid;display:none"    runat="server" >
           <legend>ADD CUSTOMER</legend>
           <asp:Label runat="server">SHIP TO NUMBER</asp:Label>
           <asp:TextBox style="position:absolute;left:150px" id="insertShipNo" runat="server"></asp:TextBox><br /><br />
           <asp:Label ID="Label1" runat="server">HOSPITAL NAME</asp:Label>
           <asp:TextBox style="position:absolute;left:150px" id="insertHospitalName" runat="server"></asp:TextBox><br /><br />
           <asp:Label ID="Label2" runat="server">SOLD TO NUMBER</asp:Label>
           <asp:TextBox style="position:absolute;left:150px" id="insertSoldTo" runat="server"></asp:TextBox><br /><br />
           <asp:Label ID="Label3" runat="server">ADDRESS 1</asp:Label>
           <asp:TextBox style="position:absolute;left:150px" id="insertAddress1" runat="server"></asp:TextBox><br /><br />
           <asp:Label ID="Label4" runat="server">ADDRESS 2</asp:Label>
           <asp:TextBox style="position:absolute;left:150px" id="insertAddress2" runat="server"></asp:TextBox><br /><br />
           <asp:Label ID="Label5" runat="server">CITY NAME</asp:Label>
           <asp:TextBox style="position:absolute;left:150px" id="insertCityName" runat="server"></asp:TextBox><br /><br />
           <asp:Label ID="Label6" runat="server">PROVINCE</asp:Label>
           <asp:TextBox style="position:absolute;left:150px" id="insertProvince" runat="server"></asp:TextBox><br /><br />
           <asp:Label ID="Label7" runat="server">POSTAL CODE</asp:Label>
           <asp:TextBox style="position:absolute;left:150px" id="insertPostalCode" runat="server"></asp:TextBox><br /><br />
           <asp:Button style="position:absolute;left:10px" id="INSERT" TEXT="ADD CUSTOMER" runat="server" OnClick="INSERT_Click" CausesValidation="false"></asp:Button>
       </div>      
  </form>
 </body>
</html>

