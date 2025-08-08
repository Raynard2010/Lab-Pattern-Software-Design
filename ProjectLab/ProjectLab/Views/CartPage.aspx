<%@ Page Title="Cart" Language="C#" MasterPageFile="~/Views/MasterPages/navbar.Master" AutoEventWireup="true" CodeBehind="CartPage.aspx.cs" Inherits="ProjectLab.Views.CartPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2>Your Cart</h2>

    <asp:Label ID="LblMessage" runat="server" ForeColor="Red" Visible="false" />

    <asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="false" 
        DataKeyNames="CardID" OnRowCommand="CartGridView_RowCommand"
        EmptyDataText="Your cart is empty">
        <Columns>
            <asp:BoundField DataField="Card.CardName" HeaderText="Card Name" />
            <asp:BoundField DataField="Card.CardType" HeaderText="Type" />
            <asp:BoundField DataField="Card.CardPrice" HeaderText="Price" DataFormatString="{0:C}" />

            <asp:TemplateField HeaderText="Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="TxtQuantity" runat="server" Text='<%# Eval("Quantity") %>' Width="50px" />
                    <asp:Button ID="BtnUpdateQty" runat="server" Text="Update" 
                                CommandName="UpdateQuantity" CommandArgument='<%# Eval("CardID") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Subtotal">
                <ItemTemplate>
                    <%# string.Format("{0:C}", Convert.ToDecimal(Eval("Card.CardPrice")) * Convert.ToInt32(Eval("Quantity"))) %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton ID="BtnRemove" runat="server" Text="Remove" 
                                    CommandName="RemoveItem" CommandArgument='<%# Eval("CardID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <br />

    <asp:Label ID="LblTotalPrice" runat="server" Font-Bold="true" />

    <br /><br />

    <asp:Button ID="CheckoutBtn" runat="server" Text="Checkout" OnClick="CheckOutBtn_Click" />
    <asp:Button ID="BtnContinueShopping" runat="server" Text="Continue Shopping" PostBackUrl="~/Views/OrderCard.aspx" />
    <asp:Button ID="BtnClearCart" runat="server" Text="Clear Cart" OnClick="BtnClearCart_Click" />

</asp:Content>
