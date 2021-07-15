<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KonditoreiUebersicht.aspx.cs" Inherits="Sweet_Fast_PL.KonditoreiUebersicht" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Sweet & Fast</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Hallo User, diese Unternehmen liefern zu Dir!</h2>
            <asp:GridView ID="GVKonditorei" runat="server" AutoGenerateColumns="False" EmptyDataText="Keine Lokale in der Datenbank" >
                <Columns>
                    <asp:BoundField DataField="kondName" HeaderText="Name" />
                    <asp:BoundField DataField="businessType" HeaderText="Typ" />
                    <asp:BoundField DataField="startH" HeaderText="derzeit geöffnet?" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
