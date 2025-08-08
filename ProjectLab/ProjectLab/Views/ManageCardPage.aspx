<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/navbar.Master" AutoEventWireup="true" CodeBehind="ManageCardPage.aspx.cs" Inherits="ProjectLab.Views.ManageCardPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Manage Card</h1>

        <asp:GridView ID="CardGv" runat="server" AutoGenerateColumns="False" OnRowEditing="CardGv_RowEditing" OnRowDeleting="CardGv_RowDeleting" DataKeyNames="CardName">
            <Columns>
                <asp:BoundField DataField="CardName" HeaderText="Name" SortExpression="CardName" />
                <asp:BoundField DataField="CardPrice" HeaderText="Price" SortExpression="CardPrice" />
                <asp:BoundField DataField="CardDesc" HeaderText="Description" SortExpression="CardDescription" />

                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="DeleteBtn" runat="server" Text="Delete" CommandName="Delete"/>
                        <asp:Button ID="UpdateBtn" runat="server" Text="Update" CommandName="Edit"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
        
        <asp:Button ID="AddBtn" runat="server" Text="Add" OnClick="AddBtn_Click"/>
</asp:Content>
