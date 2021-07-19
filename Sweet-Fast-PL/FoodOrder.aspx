<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FoodOrder.aspx.cs" Inherits="Sweet_Fast_PL.FoodOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblFoodOrderPlaceName" runat="server"></asp:Label>
            <br />
            <asp:Label ID="lblFoodOrderPlaceOpening" runat="server"></asp:Label>
        </div>
        <asp:GridView ID="GVEssen" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
                <asp:BoundField HeaderText="Essen" DataField="foodName" />
                <asp:BoundField HeaderText="Preis" DataField="preis" />
                <asp:ButtonField Text="In den Warenkorb!" />
            </Columns>
        </asp:GridView>
        <br />
        
        <div id="divWarenkorb">
            <asp:Label ID="lblWarenkorb" runat="server" Text="Warenkorb"></asp:Label>
            <asp:GridView ID="GVWarenkorb" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField HeaderText="Essen" DataField="foodName" />
                    <asp:BoundField HeaderText="Preis" DataField="preis" />
                    <asp:ButtonField Text="Löschen!" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
