<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TPC.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Log In</h1>
    </div>
    <section>
        <div>
            <asp:Label ID="lblUsuario" runat="server" Text="Ingrese su usuario:"></asp:Label>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblContrasena" runat="server" Text="Ingrese su contraseña:"></asp:Label>
            <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar"/>
        </div>
    </section>

</asp:Content>
