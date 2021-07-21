<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Sweet_Fast_PL.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sweet & Fast</title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" class="loginSeite" runat="server">


        <div id="divLogin">
            <h3>
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
            </h3>
            <h3>&nbsp;</h3>
            <h3><asp:Label ID="lblLogin" runat="server" Text="Ich bin schon registriert und will was süßes😋 "></asp:Label> </h3>
            <br />
            <div class="loginInput">
            <asp:TextBox ID="txtEmailLogin" runat="server" placeholder="E-Mail" Height="50px" Width="800px" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" ForeColor="#EF476F"  style="margin-bottom: 5px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmailLogin" runat="server" ControlToValidate="txtEmailLogin" Display="Dynamic" ErrorMessage="!" ForeColor="#EF476F" ValidationGroup="vldLogin" Font-Size="X-Large"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmailLogin" runat="server" ControlToValidate="txtEmailLogin" Display="Dynamic" ErrorMessage="Email inkorrekt" ForeColor="#EF476F" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Size="X-Large"></asp:RegularExpressionValidator>
                <br />
            <asp:TextBox ID="txtPasswortLogin" runat="server" placeholder="Passwort" Height="50px" Width="800px" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" ForeColor="#EF476F" style="margin-top: 0px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPasswortLogin" runat="server" ControlToValidate="txtPasswortLogin" Display="Dynamic" ErrorMessage="!" ForeColor="#EF476F" ValidationGroup="vldLogin" Font-Size="X-Large"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPasswortLogin" runat="server" ControlToValidate="txtPasswortLogin" Display="Dynamic" ErrorMessage="Passwort inkorrekt" ForeColor="#EF476F" ValidationExpression="[\w\s]{1,50}" Font-Size="X-Large"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login " OnClick="btnLogin_Click" ValidationGroup="vldLogin" Height="70px" BorderStyle="Solid" CssClass="buttonClick" Font-Bold="True" Font-Overline="False" Font-Size="X-Large" style="margin-left: 275px" Width="250px" />
             </div>
        </div>


        <div id="divRegister">
            <h3><asp:Label ID="lblRegister" runat="server" Text="Gib mir einen Account Daddy🍆 "></asp:Label></h3> 
            <br />
            <div class="registerInput">
                <div class="register1">
            <asp:TextBox ID="txtVornameRegister" runat="server" placeholder="Vorname" Height="50px" style="margin-right: 60px; margin-bottom: 15px;" Width="375px" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" ForeColor="#EF476F"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvVornameRegister" runat="server" ControlToValidate="txtVornameRegister" Display="Dynamic" ErrorMessage="!" ForeColor="#EF476F" ValidationGroup="vldRegister" Font-Size="X-Large"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revVornameRegister" runat="server" ControlToValidate="txtVornameRegister" Display="Dynamic" ErrorMessage="Vorname inkorrekt" ForeColor="#EF476F" ValidationExpression="^[a-zA-Z0-9'@&amp;#.\s]{0,50}$" Font-Size="X-Large"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtZunameRegister" runat="server" placeholder="Zuname" Height="50px" Width="375px" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" ForeColor="#EF476F" style="margin-bottom: 15px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvZunameRegister" runat="server" ControlToValidate="txtZunameRegister" Display="Dynamic" ErrorMessage="!" ForeColor="#EF476F" ValidationGroup="vldRegister" Font-Size="X-Large"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revZunameRegister" runat="server" ControlToValidate="txtZunameRegister" Display="Dynamic" ErrorMessage="Zuname inkorrekt" ForeColor="#EF476F" ValidationExpression="[\w\s]{0,50}" Font-Size="X-Large"></asp:RegularExpressionValidator>
            <br />
                    </div>
                <div class="register2">
            <asp:TextBox ID="txtStreetRegister" runat="server" placeholder="Straße" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" ForeColor="#EF476F" Height="50px" style="margin-right: 25px; margin-bottom: 15px" Width="550px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvStrasseRegister" runat="server" ControlToValidate="txtStreetRegister" Display="Dynamic" ErrorMessage="!" ForeColor="Red" ValidationGroup="vldRegister"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revStrasseRegister" runat="server" ControlToValidate="txtStreetRegister" Display="Dynamic" ErrorMessage="Straße inkorrekt" ForeColor="#EF476F" ValidationExpression="[\w\s]{0,50}" Font-Size="X-Large"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtHausnummerRegister" runat="server" placeholder="Hausnummer" Width="100px" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" ForeColor="#EF476F" Height="50px" style="margin-right: 25px; margin-bottom: 15px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvHausnummerRegister" runat="server" ControlToValidate="txtHausnummerRegister" Display="Dynamic" ErrorMessage="!" ForeColor="Red" ValidationGroup="vldRegister"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rvHausnummerRegister" runat="server" ControlToValidate="txtHausnummerRegister" Display="Dynamic" ErrorMessage="Hausnummer inkorrekt" ForeColor="#EF476F" MaximumValue="2000" MinimumValue="1" Type="Integer" Font-Size="X-Large"></asp:RangeValidator>
            <asp:TextBox ID="txtTürnummerRegister" runat="server" placeholder="Türnummer" Width="100px" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" ForeColor="#EF476F" Height="50px" style="margin-bottom: 15px"></asp:TextBox>
            <asp:RangeValidator ID="rvTürnummerRegister" runat="server" ControlToValidate="txtTürnummerRegister" Display="Dynamic" ErrorMessage="Türnummer inkorrekt" ForeColor="Red" MaximumValue="2000" MinimumValue="0" Type="Integer"></asp:RangeValidator>
            <br />
                    </div>
                    <div class="register3">
            <asp:TextBox ID="txtPLZRegister" runat="server" placeholder="PLZ" Width="150px" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" ForeColor="#EF476F" Height="50px" style="margin-right: 25px; margin-bottom: 15px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvfPlzRegister" runat="server" ControlToValidate="txtPLZRegister" Display="Dynamic" ErrorMessage="!" ForeColor="#EF476F" ValidationGroup="vldRegister" Font-Size="X-Large"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rvPlzRegister" runat="server" ControlToValidate="txtPLZRegister" Display="Dynamic" ErrorMessage="PLZ inkorrekt" ForeColor="#EF476F" MaximumValue="5" MinimumValue="1" Font-Size="X-Large"></asp:RangeValidator>
            <asp:TextBox ID="txtOrtRegister" runat="server" placeholder="Ort" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" ForeColor="#EF476F" Height="50px" style="margin-right: 25px; margin-bottom: 15px" Width="326px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvOrtRegister" runat="server" ControlToValidate="txtOrtRegister" Display="Dynamic" ErrorMessage="!" ForeColor="#EF476F" ValidationGroup="vldRegister" Font-Size="X-Large"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revOrtRegister" runat="server" ControlToValidate="txtOrtRegister" Display="Dynamic" ErrorMessage="Ort inkorrekt" ForeColor="#EF476F" ValidationExpression="[\w\s]{0,50}" Font-Size="X-Large"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtTelefonRegister" runat="server" placeholder="Telefon" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" ForeColor="#EF476F" Height="50px" style="margin-bottom: 15px" Width="275px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTelefonnummerRegister" runat="server" ControlToValidate="txtTelefonRegister" Display="Dynamic" ErrorMessage="!" ForeColor="#EF476F" ValidationGroup="vldRegister" Font-Size="X-Large"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revTelefonnummerRegister" runat="server" ControlToValidate="txtTelefonRegister" Display="Dynamic" ErrorMessage="Telefonnummer inkorrekt" ForeColor="#EF476F" ValidationExpression="[\w\s]{0,50}" Font-Size="X-Large"></asp:RegularExpressionValidator>
            <br />
                        </div>
                <div class="register4">
            <asp:TextBox ID="txtEmailRegister" runat="server" placeholder="E-Mail" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" ForeColor="#EF476F" Height="50px" style="margin-right: 60px; margin-bottom: 15px" Width="375px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmailRegister" runat="server" ControlToValidate="txtEmailRegister" Display="Dynamic" ErrorMessage="!" ForeColor="#EF476F" ValidationGroup="vldRegister" Font-Size="X-Large"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmailRegister" runat="server" ControlToValidate="txtEmailRegister" Display="Dynamic" ErrorMessage="Email inkorrekt" ForeColor="#EF476F" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Font-Size="X-Large"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtPasswortRegister" runat="server" placeholder="Passwort" Font-Italic="False" Font-Names="Arial" BorderColor="Black" BorderStyle="Solid" BorderWidth="3px" Font-Size="X-Large" ForeColor="#EF476F" Height="50px" style="margin-bottom: 15px" Width="375px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPasswortRegister" runat="server" ControlToValidate="txtPasswortRegister" Display="Dynamic" ErrorMessage="!" ForeColor="#EF476F" ValidationGroup="vldRegister" Font-Size="X-Large"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPasswortRegister" runat="server" ControlToValidate="txtPasswortRegister" Display="Dynamic" ErrorMessage="Passwort inkorrekt" ForeColor="#EF476F" ValidationExpression="[\w\s]{0,50}" Font-Size="X-Large"></asp:RegularExpressionValidator>
            <br />
                    </div>
            <asp:Button ID="btnRegister" runat="server" Text="Registrieren" OnClick="btnRegister_Click" CssClass="buttonClick" Font-Bold="True" Height="70px" Width="300px" />
                </div>
        </div>
    </form>
</body>
</html>
