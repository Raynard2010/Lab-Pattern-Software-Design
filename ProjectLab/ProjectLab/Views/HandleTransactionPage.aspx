<%@ Page Title="Handle Transactions" Language="C#" MasterPageFile="~/Views/MasterPages/navbar.Master" AutoEventWireup="true" CodeBehind="HandleTransactionPage.aspx.cs" Inherits="ProjectLab.Views.HandleTransactionPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Unhandled Transactions</h2>

    <asp:GridView ID="TransactionGridView" runat="server" AutoGenerateColumns="false"
        DataKeyNames="TransactionID" OnRowCommand="TransactionGridView_RowCommand"
        EmptyDataText="No unhandled transactions found.">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="User.Username" HeaderText="Username" />
            <asp:BoundField DataField="TransactionDate" HeaderText="Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Status" HeaderText="Status" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="BtnHandle" runat="server" Text="Handle Transaction"
                        CommandName="HandleTransaction" CommandArgument='<%# Eval("TransactionID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:Label ID="LblMessage" runat="server" ForeColor="Green" Visible="false"></asp:Label>
</asp:Content>
