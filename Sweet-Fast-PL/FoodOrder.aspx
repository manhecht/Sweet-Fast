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
        <asp:GridView ID="GVEssen" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVEssen_SelectedIndexChanged"
            
 >
            <Columns>
                <asp:CommandField SelectText="Zum Warenkorb hinzufügen" ShowSelectButton="True" />
                <asp:BoundField HeaderText="Essen" DataField="foodName" SortExpression="foodName" />
                <asp:BoundField HeaderText="Preis(€)" DataField="preis" SortExpression="preis" DataFormatString="{0:N2}"/>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZitateConnectionString %>" SelectCommand="SELECT [foodName], [preis] FROM [Essen] WHERE ([unternehmenID] = @unternehmenID)">
            <SelectParameters>
                <asp:SessionParameter Name="unternehmenID" SessionField="currentBusiness" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        
        <div id="divWarenkorb">
            <asp:Label ID="lblWarenkorb" runat="server" Text="Warenkorb"></asp:Label>
            <asp:GridView ID="GVWarenkorb" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GVWarenkorb_SelectedIndexChanged" EmptyDataText="Keine Kunden in der Datenbank">
                <Columns>
                    <asp:CommandField SelectText="Löschen" ShowSelectButton="True" />
                    <asp:BoundField DataField="foodName" />
                    <asp:BoundField DataField="preis" DataFormatString="{0:N2}"/>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
        </div>
        <asp:Label ID="lblGesamtpreisWarenkorb" runat="server" Text="Gesamtpreis"></asp:Label>
        <asp:Label ID="lblGesamtpreisZahlWarenkorb" runat="server" DataFormatString="{0:N2}" ></asp:Label>
        <p>
            <asp:Button ID="btnBestellen" runat="server" OnClick="btnBestellen_Click" Text="Bestellen!" />
            <asp:Label ID="lblWarnungWarenkorb" runat="server" ForeColor="Red"></asp:Label>
        </p>
    </form>
</body>
</html>
