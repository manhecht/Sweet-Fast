<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Endscreen.aspx.cs" Inherits="Sweet_Fast_PL.Endscreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
        <link href="style2.css" rel="stylesheet" />
    <title></title>
</head>
<body>
                        <br />
                    <br />
                    <br />
                    <br />
    <div class="content">

    <form id="form1" runat="server">
        <div class="header">
            <asp:Label ID="lblThanks" runat="server"></asp:Label>
            <br/>
            <br/>
            <asp:Label ID="lblDeliveryTime" runat="server"></asp:Label>
            <br />
        </div>

        <div class="order">

            <asp:Label ID="lblBestellung" runat="server" Text="Deine Bestellung" CssClass="bestellungUeberschrift"></asp:Label>
            <br />
        <div class ="orderStuff">
        <asp:GridView ID="GVEndscreen" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" CellPadding="6" CellSpacing="2" GridLines="Horizontal" BackColor="White">
            <Columns>
                <asp:BoundField DataField="foodName" HeaderText="Essen"   ItemStyle-HorizontalAlign ="Left" HeaderStyle-HorizontalAlign ="Left"/>
                <asp:BoundField DataField="preis" HeaderText="Preis (€)" DataFormatString="{0:N2}" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign ="Right"/>
            </Columns>
        </asp:GridView>
            <br />

            <asp:Label ID="lblGesamtpreisZahlWarenkorb" runat="server" Text="Label"></asp:Label>
        </div>

        </div>
                    <br />
                    <br />
                    <br />
                    <br />

        <div class="buttonFinalScreen">
            <br />
        <asp:Button ID="btnReorder" runat="server" OnClick="btnReorder_Click" Text="Noch hungrig?" CssClass="buttonClick" />
            <br />
            <br />
        <asp:Button ID="btnLogOut" runat="server" OnClick="btnLogOut_Click" Text="Log Out" CssClass="buttonClick" />
            <br />
        </div>
        <br />
    </form>
        </div>
</body>
</html>
