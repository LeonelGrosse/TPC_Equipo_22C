<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="TPC.LogIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Log In</h1>
    </div>
    <section>
        <div>
            <asp:Label ID="lblUsuario" runat="server" Text="Email:"></asp:Label>
            <%--El usuario es el mail--%>
            <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblContrasenia" runat="server" Text="Contraseña:"></asp:Label>
            <asp:TextBox ID="txtContrasenia" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnAceptar" runat="server" Text="Iniciar sesión" OnClick="btnAceptar_Click" />
            <asp:Label ID="lblAvisoLogin" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div>
            <br />
            <asp:Button ID="btnOlvido" runat="server" Text="Olvidé mi contraseña" OnClick="btnOlvido_Click" />
        </div>
    </section>
    <section>
        <div>
            <br />
            <asp:Label ID="lblRecuEmail" runat="server" Text="Ingresá tu email:" Visible="false"></asp:Label>
            <asp:TextBox ID="txtRecuEmail" runat="server" Visible="false"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblRecuDNI" runat="server" Text="Ingresá tu DNI:" Visible="false"></asp:Label>
            <asp:TextBox ID="txtRecuDNI" runat="server" Visible="false"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnSiguiente" runat="server" Text="Siguiente" OnClick="btnSiguiente_Click" Visible="false" />
            <asp:Label ID="lblAvisoSiguiente" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
    </section>
    <section>
        <div>
            <br />
            <asp:Label ID="lblNuevaContrasenia" runat="server" Text="Ingresá tu nueva contraseña:" Visible="false"></asp:Label>
            <asp:TextBox ID="txtNuevaContrasenia" runat="server" Visible="false" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblRepeNuevaContrasenia" runat="server" Text="Repetí tu contraseña:" Visible="false"></asp:Label>
            <asp:TextBox ID="txtRepeNuevaContrasenia" runat="server" Visible="false" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="btnRecuperar" runat="server" Text="Recuperar" OnClick="btnRecuperar_Click" Visible="false" />
            <asp:Label ID="lblAvisoRecuperar" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
    </section>

</asp:Content>
