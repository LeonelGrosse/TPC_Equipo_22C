<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TPC.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Log In</h1>
    </div>
    <section>
        <div>
            <asp:Label ID="lblUsuario" runat="server" Text="Email:"></asp:Label> <%--El usuario es el mail--%>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblContrasenia" runat="server" Text="Contraseña:"></asp:Label>
            <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnAceptar" runat="server" Text="Iniciar sesión" OnClick="btnAceptar_Click"/>
            <asp:Label ID="lblAvisoLogin" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div>
            <a href="#">Olvidaste tu contraseña?</a>            
        </div>
    </section>

</asp:Content>
