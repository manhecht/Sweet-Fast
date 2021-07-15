<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Sweet_Fast_PL.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sweet & Fast</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <div id="divLogin">
            <asp:Label ID="lblLogin" runat="server" Text="Ich bin schon registriert und will was süßes😋 "></asp:Label>
            <br />
            <asp:TextBox ID="txtEmailLogin" runat="server" placeholder="E-Mail"></asp:TextBox>
            <asp:TextBox ID="txtPasswortLogin" runat="server" placeholder="Passwort"></asp:TextBox>
            <br />
            <asp:Button ID="btnLogin" runat="server" Text="Login und gleich bestellen" />
        </div>
        <div id="divRegister">
            <asp:Label ID="lblRegister" runat="server" Text="Gib mir einen Account Daddy🍆 "></asp:Label>
            <br />
            <asp:TextBox ID="txtVornameRegister" runat="server" placeholder="Vorname"></asp:TextBox>
            <asp:TextBox ID="txtZunameRegister" runat="server" placeholder="Zuname"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtStreetRegister" runat="server" placeholder="Straße"></asp:TextBox>
            <asp:TextBox ID="txtHausnummerRegister" runat="server" placeholder="Hausnummer"></asp:TextBox>
            <asp:TextBox ID="txtTürnummerRegister" runat="server" placeholder="Türnummer"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtPLZRegister" runat="server" placeholder="PLZ"></asp:TextBox>
            <asp:TextBox ID="txtOrtRegister" runat="server" placeholder="Ort"></asp:TextBox>
            <asp:TextBox ID="txtTelefonRegister" runat="server" placeholder="Telefon"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtEmailRegister" runat="server" placeholder="E-Mail"></asp:TextBox>
            <asp:TextBox ID="txtPasswortRegister" runat="server" placeholder="Passwort"></asp:TextBox>
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="Registrieren" />
        </div>
    </form>
</body>
</html>
