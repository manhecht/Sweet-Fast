<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FoodOrder.aspx.cs" Inherits="Sweet_Fast_PL.FoodOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
            <link href="style2.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        .auto-style1 {
            font-size: 50px;
            color: #EF476F;
            text-align: center;
            display: inline-block;
            margin-top: 0px;
        }
    </style>
</head>
<body>
    <div class="content">
        <form id="form1" runat="server">
        <div class="header">
            <asp:Label ID="lblFoodOrderPlaceName" runat="server" CssClass="bestellungUeberschrift"></asp:Label>
            <br />
            <asp:Label ID="lblFoodOrderPlaceOpening" runat="server" CssClass="bestellungUeberschrift"></asp:Label>
        </div>
        <div class="order">
        <asp:GridView ID="GVEssen" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center" OnSelectedIndexChanged="GVEssen_SelectedIndexChanged" GridLines="Vertical" BackColor="White" CellPadding="6" CellSpacing="2"
            
 >
            <Columns>
                <asp:CommandField SelectText="+" ShowSelectButton="True" HeaderText="Add" >
                <ItemStyle ForeColor="#FF0066" />
                </asp:CommandField>
                <asp:BoundField HeaderText="Essen" DataField="foodName" SortExpression="foodName" />
                <asp:BoundField HeaderText="Preis(€)" DataField="preis" SortExpression="preis" DataFormatString="{0:N2}"/>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ZitateConnectionString %>" SelectCommand="SELECT [foodName], [preis] FROM [Essen] WHERE ([unternehmenID] = @unternehmenID)">
            <SelectParameters>
                <asp:SessionParameter Name="unternehmenID" SessionField="currentBusiness" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        </div>
        <br />
        
        <div id="divWarenkorb" class="order">
            <asp:Label ID="lblWarenkorb" runat="server" Text="Warenkorb"></asp:Label>
            <asp:GridView ID="GVWarenkorb" runat="server" HorizontalAlign="Center" AutoGenerateColumns="False" OnSelectedIndexChanged="GVWarenkorb_SelectedIndexChanged" EmptyDataText="noch ist nichts im Warenkorb" BackColor="White" CellPadding="6" CellSpacing="2" GridLines="Vertical">
                <Columns>
                    <asp:CommandField SelectText="-" ShowSelectButton="True" HeaderText="Delete" >
                    <ItemStyle ForeColor="#FF3399" />
                    </asp:CommandField>
                    <asp:BoundField DataField="foodName" HeaderText="Essen" />
                    <asp:BoundField DataField="preis" DataFormatString="{0:N2}" HeaderText="Preis(€)"/>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource2" runat="server"></asp:SqlDataSource>
        </div>
            <div class="order">

                <br />
        <asp:Label ID="lblGesamtpreisZahlWarenkorb" runat="server" DataFormatString="{0:N2}" CssClass="header" ></asp:Label>
            </div>

        <p>
            <asp:Button ID="btnBestellen" runat="server" OnClick="btnBestellen_Click" Text="Bestellen!" CssClass="buttonClick" />
            <asp:Label ID="lblWarnungWarenkorb" runat="server" ForeColor="Red" CssClass="header"></asp:Label>
        </p>
    </form>

    </div>
    
</body>
</html>
