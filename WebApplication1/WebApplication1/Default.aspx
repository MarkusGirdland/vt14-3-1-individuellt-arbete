<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h1>Hello World!</h1>
        <asp:ListView ID="SpelareListView" runat="server"
            ItemType="WebApplication1.Model.Spelare"
            SelectMethod="SpelareListView_GetData"
            InsertMethod="SpelareListView_InsertItem"
            UpdateMethod="SpelareListView_UpdateItem"
            DeleteMethod="SpelareListView_DeleteItem"
            DataKeyNames="SpelareID"
            InsertItemPosition="FirstItem">
            <LayoutTemplate>
                <table>
                    <tr>
                        <th>Förnamn</th>
                        <th>Efternamn</th>
                        <th>Lön</th>
                    </tr>
                    <%-- Platshållare --%>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <%-- Mall för nya rader --%>
                <tr>
                    <td>
                        <asp:Label ID="FörnamnLabel" runat="server" Text='<%#: Item.Förnamn %>' />
                    </td>
                    <td>
                        <asp:Label ID="EfternamnLabel" runat="server" Text='<%#: Item.Efternamn %>' />
                    </td>
                    <td>
                        <asp:Label ID="Lön" runat="server" Text='<%#: Item.Lön %>' />
                    </td>
                    <td>
                        <asp:Label ID="Hjältenamn" runat="server" Text='<%#: Item.Hjältenamn %>' />
                    </td>
                    <td>
                        <asp:Label ID="Skicklighet" runat="server" Text='<%#: Item.Skicklighet %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <EmptyDataTemplate>
                <%-- Då det är tomt. --%>
                <table class="empty">
                    <tr>
                        <td>
                            Spelaruppgifter saknas.
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr>
                    <td>
                        <asp:TextBox ID="Förnamn" runat="server" Text='<%# BindItem.Förnamn %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Efternamn" runat="server" Text='<%# BindItem.Efternamn %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Lön" runat="server" Text='<%# BindItem.Lön %>' />
                    </td>
                    <td>
                        <%-- Knappar --%>
                        <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
                        <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                    </td>
                </tr>
            </InsertItemTemplate>
            <EditItemTemplate>
                 <tr>
                    <td>
                        <asp:TextBox ID="Förnamn" runat="server" Text='<%# BindItem.Förnamn %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Efternamn" runat="server" Text='<%# BindItem.Efternamn %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="Lön" runat="server" Text='<%# BindItem.Lön %>' />
                    </td>
                    <td>
                        <%-- Knappar --%>
                        <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                        <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                    </td>
                </tr>
            </EditItemTemplate>
        </asp:ListView>
    </div>
    </form>
</body>
</html>
