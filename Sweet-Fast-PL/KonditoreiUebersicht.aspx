<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KonditoreiUebersicht.aspx.cs" Inherits="Sweet_Fast_PL.KonditoreiUebersicht" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sweet & Fast</title>
    <link href="style2.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Label ID="lblHalloUser" runat="server"></asp:Label>
            
            <asp:GridView ID="GVKonditorei" runat="server" AutoGenerateColumns="False"  EmptyDataText="Keine Lokale in der Datenbank" AutoGenerateSelectButton="True" OnSelectedIndexChanged="GVKonditorei_SelectedIndexChanged" >
                <Columns>
                    <asp:BoundField DataField="kondID" Visible="False" />
                    <asp:BoundField DataField="kondName" HeaderText="Name" />
                    <asp:BoundField DataField="businessType" HeaderText="Typ" />
                    <asp:TemplateField HeaderText="derzeit geöffnet?">
                        <EditItemTemplate>
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <asp:Label ID="lblTemplate" runat="server" Text='<%# öffnung(Convert.ToInt32(Eval("kondID"))) %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
