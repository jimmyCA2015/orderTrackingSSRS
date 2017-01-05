<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <center>
			<table id="Table_02" width="780" style="height:139px;" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td rowspan="3">
						<img src="HeaderImages/WebPageHeader_01.gif" width="326" height="139" alt="" /></td>
					<td rowspan="2">
						<img src="HeaderImages/WebPageHeader_02.gif" width="177" height="86" alt="" /></td>
					<td colspan="2">
						<img src="HeaderImages/WebPageHeader_03.gif" width="277" height="66" alt="" /></td>
				</tr>
				<tr>
					<td align="right">
					    <img src="HeaderImages/spacer.gif" width="1" height="20" alt="" /></td>
					<td align="right">
                        <a id="ctl00_linkLogin"><span id="ctl00_lblLogin" class="Bold"></span></a></td>
				</tr>
				<tr>
					<td colspan="3">
						<img src="HeaderImages/WebPageHeader_05.gif" width="454" height="53" alt="" /></td>
				</tr>
			</table>
    <table width="300" border="0" cellspacing="0" cellpadding="0" style="background-color:#dcdcdc">
		<tr style="background-color:gray">
			<td style="width:100px; color:white" valign="middle" align="left">&nbsp;&nbsp;<b>Login</b></td>
			<td colspan="2"><img src="Images/Spacer.gif" alt="" height="25" width="1" style="border:0" /></td>
		</tr>
		<tr>
			<td colspan="3" style="background-color:red"><img src="Images/spacer.gif" height="2" style="border:0" alt="" /></td>
		</tr>
		<tr>
			<td align="right" style="width:100px"><img src="Images/spacer.gif" alt="" height="10" width="1" style="border:0" /></td>
			<td style="width:20px"></td>
			<td style="width:180px"></td>
		</tr>
		<tr>
			<td align="right" style="width:100px"><b>Username:</b></td>
			<td style="width:20px"></td>
			<td style="width:180px" align="left"><asp:textbox id="username" cssclass="text" runat="Server" Width="150" /></td>
		</tr>
		<tr>
			<td align="right" style="width:100px"><b>Password:</b></td>
			<td style="width:20px"></td>
			<td style="width:180px" align="left"><asp:textbox id="password" textmode="Password" cssclass="text" runat="Server" Width="150" /></td>
		</tr>
		<tr>
			<td align="right" style="width:100px"></td>
			<td style="width:20px"><img src="Images/Spacer.gif" alt="" height="10" width="1" style="border:0" /></td>
			<td style="width:180px"></td>
		</tr>
		<tr>
		    <td style="width:100px">&nbsp;</td>
			<td style="width:20px"></td>
			<td style="width:180px"><asp:button id="login_button" onclick="Login_Click" text="  Login  " cssclass="button" runat="Server"/></td>
		</tr>
        <tr>
			<td colspan="3" align="center"><asp:Label ID="lblLoginError" runat="server" Text="" CssClass="FormError"></asp:Label></td>	
		</tr>
		<tr>
		    <td style="width:100px"></td>
			<td style="width:20px"></td>
			<td style="width:180px"><img src="Images/spacer.gif" alt="" height="10" width="1" style="border:0" /></td>
		</tr>
	</table>
	<table width="300" border="0" cellspacing="0" cellpadding="0">
		<tr>
			<td align="center"><br /></td>
		</tr>
		<tr>
			<td align="left">If you have an access code and would like to go directly to the QuickSearch enter it below.</td>	
		</tr>
		<tr>
			<td align="center"><br /></td>	
		</tr>
		<tr>
			<td align="center">
                <asp:TextBox ID="tbQuickSearch" runat="server" Width="120"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btQuickSearch" runat="server" Text="QuickSearch" OnClick="btQuickSearch_Click" /></td>	
		</tr>
		<tr>
			<td align="left">
                </td>	
		</tr>
	</table>
    </center>
    </form>
</body>
</html>


