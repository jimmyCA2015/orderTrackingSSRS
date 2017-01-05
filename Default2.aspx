<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        .firstcolumn {
            color:black;
            font-weight:bold;
             width:400px;
             height:22px;
             text-align:center;
         }
         .secondcolumn {
             
             width:600px;
             height:22px;
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
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table  border="1" style="border-collapse:collapse;border-color:black;width:1000px" >
        <tr>
            <td colspan="2" style="width:1000px;height:22px;background-color:yellow;text-align:center">
              
            Johnson & Johnson - DePuy / Synthes Loaner Pick Up Programme 
            </td>
           

        </tr>
           <td colspan="2" style="width:1000px;height:22px;background-color:yellow;text-align:center">
                 Pick Up Request / Detail for Carrier 
           </td>

        <tr>
           <td colspan="2"  style="width:1000px;height:22px;text-align:center;color:rgb(0, 148, 255);font-size:xx-large">
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
              customerservice@roguedelivers.com
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
            <td class="secondcolumn">
               
               
              
                    <asp:textbox ID="datepickup1"  class="secondcolumn"    runat="server"></asp:textbox>
                
               
              </td>
              
          
       
          </tr>
           <tr>
             <td class="firstcolumn">
               Service Description (Select from Drop Down)

            </td>
            <td  class="secondcolumn">
                <asp:textbox ID="txtDropDown1"  class="secondcolumn"    runat="server"></asp:textbox>

            </td>
       
          </tr>
         <tr>
             <td  class="firstcolumn">
               Date Freight Needs to Pick Up On

            </td>
            <td   class="secondcolumn">
                
                    <asp:textbox ID="datepickup2" class="secondcolumn"  runat="server"></asp:textbox>
                 
              
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
           <td colspan="2"  style="width:1000px;height:22px;text-align:center;color:rgb(0, 148, 255);font-size:xx-large">
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
              
              
               
                    <asp:textbox ID="cutofftime" class="secondcolumn"  runat="server"></asp:textbox>
                 
              
            </td>
          </tr>
        <tr>
             <td  class="firstcolumn">
              Delivery By Time
            </td>
            <td   class="secondcolumn">
              
              
               
                    <asp:textbox ID="delivertime" class="secondcolumn"   runat="server"></asp:textbox>
                 
                  
              
            </td>
          </tr>
        <tr>
           <td colspan="2"  style="width:1000px;height:22px;text-align:center;color:rgb(0, 148, 255);font-size:xx-large">
                 Pick Up Location
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
               Name Of Contact & Phone Number at Pick Up Location
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="contactpickup"  class="secondcolumn" runat="server"></asp:TextBox>
            </td>

          </tr>
        <tr>
            <td  class="firstcolumn">
               Specifics regarding location/area of pick up
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="TextBox12"  class="secondcolumn" runat="server"></asp:TextBox>
            </td>

          </tr>
        <tr>
            <td  class="firstcolumn">
               Time freight will be available for pick up
            </td>
            <td   class="secondcolumn">
              
                    <asp:textbox ID="timefreight" class="secondcolumn"   runat="server"></asp:textbox>
                 
            </td>

          </tr>
        <tr>
           <td colspan="2"  style="width:1000px;height:22px;text-align:center;color:rgb(0, 148, 255);font-size:xx-large">
                Delivery Information
           </td>
        </tr>
        <tr>
            <td  class="firstcolumn">
               Delivery Location(Full Address)
            </td>
            <td   class="secondcolumn">
             <asp:TextBox  id="deliverylocation" class="secondcolumn"   runat="server"></asp:TextBox>
            </td>

          </tr>
        <tr>
            <td  class="firstcolumn">
               Organization freight to be delivered to
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="deliveryto"  class="secondcolumn" runat="server"></asp:TextBox>
            </td>

          </tr>
        <tr>
            <td  class="firstcolumn">
               Name Of Contact at Delivery Location
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="contactdelivery"  class="secondcolumn" runat="server"></asp:TextBox>
            </td>

          </tr>
          <tr>
            <td  class="firstcolumn">
              Specifics regarding location/area of delivery
            </td>
            <td   class="secondcolumn">
             <asp:TextBox ID="TextBox17"  class="secondcolumn" runat="server"></asp:TextBox>
            </td>

          </tr>
           <tr>
            <td class="firstcolumn2">
              additional Comments/Notes/Instructions
            </td>
            <td   class="secondcolumn2">
             <asp:TextBox id="Textarea1" TextMode="MultiLine" rows="4"  cols="10" class="secondcolumn2" runat="server">Enter Your Comments</asp:TextBox>


            </td>

          </tr>
       
       


    </table>
    </div>
    </form>
</body>
</html>
