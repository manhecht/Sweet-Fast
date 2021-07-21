﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Endscreen.aspx.cs" Inherits="Sweet_Fast_PL.Endscreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblThanks" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblDeliveryTime" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblBestellung" runat="server" Font-Bold="True" Text="Deine Bestellung"></asp:Label>
        </div>
        <asp:GridView ID="GVEndscreen" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="foodName" HeaderText="Essen" />
                <asp:BoundField DataField="preis" HeaderText="Preis" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnReorder" runat="server" OnClick="btnReorder_Click" Text="Noch hungrig?" />
        <br />
        <asp:Button ID="btnLogOut" runat="server" OnClick="btnLogOut_Click" Text="Log Out" />
    </form>
</body>
</html>
