<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPages/navbar.Master" AutoEventWireup="true" CodeBehind="EditCardPage.aspx.cs" Inherits="ProjectLab.Views.EditCardPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <h1>Edit Card</h1>
        Name: <asp:TextBox ID="TbName" runat="server" /><br />
        Price: <asp:TextBox ID="TbPrice" runat="server" /><br />
        Description: <asp:TextBox ID="TbDescription" runat="server" /><br />
        Type:   <asp:RadioButtonList ID="RblType" runat="server">
                        <asp:ListItem Value="Spell">Spell</asp:ListItem>
                        <asp:ListItem Value="Monster">Monster</asp:ListItem>
                  </asp:RadioButtonList>
        Foil:   <asp:RadioButtonList ID="RblFoil" runat="server">
                        <asp:ListItem Value="1">Yes</asp:ListItem>
                        <asp:ListItem Value="0">No</asp:ListItem>
                  </asp:RadioButtonList>
        <asp:Button ID="BtnUpdate" Text="Update" OnClick="BtnUpdate_Click" runat="server" /><br />
        <asp:Label ID="LblError" runat="server" ForeColor="Red" Text=" "/>
</asp:Content>
