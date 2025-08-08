<%@ Page Title="Order Card" Language="C#" MasterPageFile="~/Views/MasterPages/navbar.Master" AutoEventWireup="true" CodeBehind="OrderCard.aspx.cs" Inherits="ProjectLab.Views.OrderCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridViewCards" runat="server" AutoGenerateColumns="False"
        DataKeyNames="CardId" OnRowCommand="GridViewCards_RowCommand">
        <Columns>
            <asp:BoundField DataField="CardName" HeaderText="Name" />
            <asp:BoundField DataField="CardPrice" HeaderText="Price" DataFormatString="{0:C}" />

            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txtQuantity" runat="server" Text="1" Width="50px" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart"
                                CommandName="AddToCart" CommandArgument='<%# Container.DataItemIndex %>' />
                    <asp:Button ID="btnDetail" runat="server" Text="Detail"
                                CommandName="ViewDetail" CommandArgument='<%# Eval("CardId") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
