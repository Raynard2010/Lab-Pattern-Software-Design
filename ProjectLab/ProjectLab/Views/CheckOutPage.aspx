<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/Views/MasterPages/navbar.Master" AutoEventWireup="true" CodeBehind="CheckOutPage.aspx.cs" Inherits="ProjectLab.Views.CheckOutPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Checkout</h2>

    <asp:GridView ID="GridViewCheckout" runat="server" AutoGenerateColumns="False" CssClass="checkout-grid">
        <Columns>
            <asp:TemplateField HeaderText="Card Name">
                <ItemTemplate>
                    <%# Eval("Card.CardName") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price">
                <ItemTemplate>
                    <%# Eval("Card.CardPrice", "{0:C}") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description">
                <ItemTemplate>
                    <%# Eval("Card.CardDesc") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <%# Eval("Quantity") %>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <br />
    <asp:Label ID="lblTotalPrice" runat="server" Font-Bold="true" ForeColor="Green" />

    <br /><br />
    <asp:Button ID="btnConfirmCheckout" runat="server" Text="Confirm Checkout" OnClick="btnConfirmCheckout_Click" />
</asp:Content>
