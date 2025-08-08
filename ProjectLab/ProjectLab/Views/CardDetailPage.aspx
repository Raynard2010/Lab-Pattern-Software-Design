<%@ Page Title="Card Detail" Language="C#" MasterPageFile="~/Views/MasterPages/navbar.Master" AutoEventWireup="true" CodeBehind="CardDetailPage.aspx.cs" Inherits="ProjectLab.Views.CardDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Card Detail</h2>
    <asp:Panel ID="PanelCardDetail" runat="server" Visible="false">
        <p><strong>Name:</strong> <asp:Label ID="LblName" runat="server" Text=""></asp:Label></p>
        <p><strong>Price:</strong> <asp:Label ID="LblPrice" runat="server" Text=""></asp:Label></p>
        <p><strong>Type:</strong> <asp:Label ID="LblType" runat="server" Text=""></asp:Label></p>
        <p><strong>Description:</strong> <asp:Label ID="LblDescription" runat="server" Text=""></asp:Label></p>
        <asp:Button ID="BtnBack" runat="server" Text="Back" OnClick="BtnBack_Click" />
    </asp:Panel>

    <asp:Label ID="LblError" runat="server" ForeColor="Red" Visible="false" />
</asp:Content>
