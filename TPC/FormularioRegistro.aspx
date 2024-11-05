<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioRegistro.aspx.cs" Inherits="TPC.FormularioRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Registrate!</h1>
        <p>Desafiá tu mente, inscribite para comenzar la aventura.</p>
    </div>
    <section>
        <div>
            <asp:Label ID="lblNombre" runat="server" Text="Ingrese su nombre: "></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:Label ID="lblAvisoNombre" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblApellido" runat="server" Text="Ingrese su apellido: "></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            <asp:Label ID="lblAvisoApellido" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblEmail" runat="server" Text="Ingrese su E-mail: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
            <asp:Label ID="lblAvisoEmail" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblDNI" runat="server" Text="Ingrese su DNI: "></asp:Label>
            <asp:TextBox ID="txtDNI" runat="server" TextMode="Number"></asp:TextBox>
            <asp:Label ID="lblAvisoDNI" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Ingrese su fecha de nacimiento: "></asp:Label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="DateTime"></asp:TextBox>
            <asp:Label ID="lblAvisoFechaNacimiento" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Label ID="lblContraseniaRegistro" runat="server" Text="Ingrese su contraseña: "></asp:Label>
            <asp:TextBox ID="txtContraseniaRegistro" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Label ID="lblAvisoContrasenias" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
    </section>
</asp:Content>
