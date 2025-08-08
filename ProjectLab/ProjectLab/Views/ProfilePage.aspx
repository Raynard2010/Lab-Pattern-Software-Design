<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/navbar.Master" AutoEventWireup="true" CodeBehind="ProfilePage.aspx.cs" Inherits="ProjectLab.Views.ProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Profile</h1>
    <asp:Label ID="OldUsernameLbl" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="OldEmailLbl" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="OldPasswordLbl" runat="server" Text=""></asp:Label><br />
    <asp:Label ID="OldGenderLbl" runat="server" Text=""></asp:Label><br />

        New username: <asp:TextBox ID="TbNewUsername" runat="server" /><br />
        New email: <asp:TextBox ID="TbNewEmail" runat="server" /><br />
        Old password: <asp:TextBox ID="TbOldPassword" TextMode="Password" runat="server" /><br />
        New password: <asp:TextBox ID="TbNewPassword" TextMode="Password" runat="server" /><br />
        Confirmation password: <asp:TextBox ID="TbConfirmationPassword" TextMode="Password" runat="server" /><br />
        Gender:   <asp:RadioButtonList ID="RblNewGender" runat="server">
                        <asp:ListItem Value="Male">Male</asp:ListItem>
                        <asp:ListItem Value="Female">Female</asp:ListItem>
                  </asp:RadioButtonList>

        <asp:Button ID="BtnUpdate" Text="Update" OnClick="BtnUpdate_Click" runat="server" /><br />
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=" "/>
</asp:Content>
