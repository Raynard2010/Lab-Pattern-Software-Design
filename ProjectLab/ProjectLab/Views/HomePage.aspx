<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/navbar.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ProjectLab.Views.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Home</h1>
    <p>Welcome  <asp:Label ID="UsernameLbl" runat="server" Text="aaa"></asp:Label></p>
    <asp:GridView ID="ShowGridView" runat="server" AutoGenerateColumns="true" />
</asp:Content>