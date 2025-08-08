<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/navbar.Master" AutoEventWireup="true" CodeFile="RegisterPage.aspx.cs" Inherits="ProjectLab.Views.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Register</h1>
        Username: <asp:TextBox ID="TbUsername" runat="server" /><br />
        Email: <asp:TextBox ID="TbEmail" runat="server" /><br />
        Password: <asp:TextBox ID="TbPassword" TextMode="Password" runat="server" /><br />
        Gender:   <asp:RadioButtonList ID="RblGender" runat="server">
                        <asp:ListItem Value="Male">Male</asp:ListItem>
                        <asp:ListItem Value="Female">Female</asp:ListItem>
                  </asp:RadioButtonList>
        Confirmation Password: <asp:TextBox ID="TbPasswordConfirm" TextMode="Password" runat="server" /><br />
        Role:   <asp:RadioButtonList ID="RblRole" runat="server">
                        <asp:ListItem Selected="True" Value="Customer">Customer</asp:ListItem>
                        <asp:ListItem Value="Admin">Admin</asp:ListItem>
                  </asp:RadioButtonList>
        <asp:Button ID="BtnRegister" Text="Register" OnClick="BtnRegister_Click" runat="server" /><br />
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=" "/>
</asp:Content>
