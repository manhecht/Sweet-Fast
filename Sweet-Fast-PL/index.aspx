<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Sweet_Fast_PL.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sweet & Fast</title>
    <link href="style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">


        <div id="divLogin">
            <h3>
                <asp:Label ID="lblResponse" runat="server"></asp:Label>
            </h3>
            <h3>&nbsp;</h3>
            <h3><asp:Label ID="lblLogin" runat="server" Text="Ich bin schon registriert und will was süßes😋 "></asp:Label> </h3>
            <br />
            <asp:TextBox ID="txtEmailLogin" runat="server" placeholder="E-Mail"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmailLogin" runat="server" ControlToValidate="txtEmailLogin" Display="Dynamic" ErrorMessage="!" ForeColor="Red" ValidationGroup="vldLogin"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmailLogin" runat="server" ControlToValidate="txtEmailLogin" Display="Dynamic" ErrorMessage="Email inkorrekt" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtPasswortLogin" runat="server" placeholder="Passwort"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPasswortLogin" runat="server" ControlToValidate="txtPasswortLogin" Display="Dynamic" ErrorMessage="!" ForeColor="Red" ValidationGroup="vldLogin"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPasswortLogin" runat="server" ControlToValidate="txtPasswortLogin" Display="Dynamic" ErrorMessage="Passwort inkorrekt" ForeColor="Red" ValidationExpression="[\w\s]{1,50}"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login und gleich bestellen" OnClick="btnLogin_Click" ValidationGroup="vldLogin" />
        </div>


        <div id="divRegister">
            <h3><asp:Label ID="lblRegister" runat="server" Text="Gib mir einen Account Daddy🍆 "></asp:Label></h3> 
            <br />
            <asp:TextBox ID="txtVornameRegister" runat="server" placeholder="Vorname"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvVornameRegister" runat="server" ControlToValidate="txtVornameRegister" Display="Dynamic" ErrorMessage="!" ForeColor="Red" ValidationGroup="vldRegister"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revVornameRegister" runat="server" ControlToValidate="txtVornameRegister" Display="Dynamic" ErrorMessage="Vorname inkorrekt" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9'@&amp;#.\s]{0,50}$"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtZunameRegister" runat="server" placeholder="Zuname"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvZunameRegister" runat="server" ControlToValidate="txtZunameRegister" Display="Dynamic" ErrorMessage="!" ForeColor="Red" ValidationGroup="vldRegister"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revZunameRegister" runat="server" ControlToValidate="txtZunameRegister" Display="Dynamic" ErrorMessage="Zuname inkorrekt" ForeColor="Red" ValidationExpression="[\w\s]{0,50}"></asp:RegularExpressionValidator>
            <br />
            <asp:TextBox ID="txtStreetRegister" runat="server" placeholder="Straße"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvStrasseRegister" runat="server" ControlToValidate="txtStreetRegister" Display="Dynamic" ErrorMessage="!" ForeColor="Red" ValidationGroup="vldRegister"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revStrasseRegister" runat="server" ControlToValidate="txtStreetRegister" Display="Dynamic" ErrorMessage="Straße inkorrekt" ForeColor="Red" ValidationExpression="[\w\s]{0,50}"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtHausnummerRegister" runat="server" placeholder="Hausnummer"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvHausnummerRegister" runat="server" ControlToValidate="txtHausnummerRegister" Display="Dynamic" ErrorMessage="!" ForeColor="Red" ValidationGroup="vldRegister"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rvHausnummerRegister" runat="server" ControlToValidate="txtHausnummerRegister" Display="Dynamic" ErrorMessage="Türnummer inkorrekt" ForeColor="Red" MaximumValue="2000" MinimumValue="1" Type="Integer"></asp:RangeValidator>
            <asp:TextBox ID="txtTürnummerRegister" runat="server" placeholder="Türnummer"></asp:TextBox>
            <asp:RangeValidator ID="rvTürnummerRegister" runat="server" ControlToValidate="txtTürnummerRegister" Display="Dynamic" ErrorMessage="Türnummer inkorrekt" ForeColor="Red" MaximumValue="2000" MinimumValue="0" Type="Integer"></asp:RangeValidator>
            <br />
            <asp:TextBox ID="txtPLZRegister" runat="server" placeholder="PLZ"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rvfPlzRegister" runat="server" ControlToValidate="txtPLZRegister" Display="Dynamic" ErrorMessage="!" ForeColor="Red" ValidationGroup="vldRegister"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="rvPlzRegister" runat="server" ControlToValidate="txtPLZRegister" Display="Dynamic" ErrorMessage="PLZ inkorrekt" ForeColor="Red" MaximumValue="5" MinimumValue="1"></asp:RangeValidator>
            <asp:TextBox ID="txtOrtRegister" runat="server" placeholder="Ort"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvOrtRegister" runat="server" ControlToValidate="txtOrtRegister" Display="Dynamic" ErrorMessage="!" ForeColor="Red" ValidationGroup="vldRegister"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revOrtRegister" runat="server" ControlToValidate="txtOrtRegister" Display="Dynamic" ErrorMessage="Ort inkorrekt" ForeColor="Red" ValidationExpression="[\w\s]{0,50}"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtTelefonRegister" runat="server" placeholder="Telefon"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvTelefonnummerRegister" runat="server" ControlToValidate="txtTelefonRegister" Display="Dynamic" ErrorMessage="!" ForeColor="Red" ValidationGroup="vldRegister"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revTelefonnummerRegister" runat="server" ControlToValidate="txtTelefonRegister" Display="Dynamic" ErrorMessage="Telefonnummer inkorrekt" ForeColor="Red" ValidationExpression="[\w\s]{0,50}"></asp:RegularExpressionValidator>
            <br />
            <asp:TextBox ID="txtEmailRegister" runat="server" placeholder="E-Mail"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmailRegister" runat="server" ControlToValidate="txtEmailRegister" Display="Dynamic" ErrorMessage="!" ForeColor="Red" ValidationGroup="vldRegister"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revEmailRegister" runat="server" ControlToValidate="txtEmailRegister" Display="Dynamic" ErrorMessage="Email inkorrekt" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <asp:TextBox ID="txtPasswortRegister" runat="server" placeholder="Passwort" Font-Italic="False" Font-Names="Arial"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPasswortRegister" runat="server" ControlToValidate="txtPasswortRegister" Display="Dynamic" ErrorMessage="!" ForeColor="Red" ValidationGroup="vldRegister"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revPasswortRegister" runat="server" ControlToValidate="txtPasswortRegister" Display="Dynamic" ErrorMessage="Passwort inkorrekt" ForeColor="Red" ValidationExpression="[\w\s]{0,50}"></asp:RegularExpressionValidator>
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="Registrieren" OnClick="btnRegister_Click" />
        </div>
    </form>
</body>
</html>
