<%@ Page Title="Transaction History" Language="C#" MasterPageFile="~/Views/MasterPages/navbar.Master" AutoEventWireup="true" CodeBehind="TransactionHistoryPage.aspx.cs" Inherits="ProjectLab.Views.TransactionHistoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transaction History</h2>

    <asp:GridView ID="TransactionGv" runat="server" AutoGenerateColumns="false"
        DataKeyNames="TransactionID" OnRowCommand="TransactionGv_RowCommand"
        EmptyDataText="No transactions found.">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
            <asp:BoundField DataField="Date" HeaderText="Transaction Date" />
            <asp:BoundField DataField="CustomerName" HeaderText="Customer" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="BtnDetail" runat="server" Text="View Detail"
                        CommandName="ViewDetail" CommandArgument='<%# Eval("TransactionID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
