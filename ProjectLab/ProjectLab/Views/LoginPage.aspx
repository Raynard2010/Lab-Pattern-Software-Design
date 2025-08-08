<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/navbar.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ProjectLab.Views.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Login Page</h1>
        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label><br />
        <asp:TextBox ID="UsernameTb" runat="server"></asp:TextBox><br />
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label><br />
        <asp:TextBox ID="PasswordTb" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:CheckBox ID="RememberMeCb" runat="server" />
        <asp:Label ID="Label3" runat="server" Text="Remember Me"></asp:Label><br />
        <asp:Button ID="LoginBtn" runat="server" Text="Login" OnClick="LoginBtn_Click"/><br />
        <asp:Button ID="RegisterBtn" runat="server" Text="Register Page" OnClick="RegisterBtn_Click"/><br />
        <asp:Label ID="ErrorLbl" runat="server" Text=" " ForeColor="Red"></asp:Label>
    </div>
</asp:Content>
