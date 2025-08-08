<%@ Page Title="Transaction Detail" Language="C#" MasterPageFile="~/Views/MasterPages/navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="ProjectLab.Views.TransactionDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Transaction Detail</h2>

    <h4><asp:Label ID="TransactionIdLbl" runat="server" /></h4>

    <asp:Label ID="CustomerLbl" runat="server" /><br />
    <asp:Label ID="DateLbl" runat="server" /><br />
    <asp:Label ID="StatusLbl" runat="server" /><br /><br />

    <h5>Items</h5>

    <asp:GridView ID="TransactionDetailGv" runat="server" AutoGenerateColumns="false" ShowFooter="true">
        <Columns>
            <asp:BoundField DataField="CardName" HeaderText="Card Name" />
            <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
        </Columns>
        <EmptyDataTemplate>
            <span>No items found in this transaction.</span>
        </EmptyDataTemplate>
    </asp:GridView>

    <br />
    <a href="TransactionHistoryPage.aspx">Back to Transaction History</a>

</asp:Content>
