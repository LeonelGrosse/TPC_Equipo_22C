<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="TPC.PerfilUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .lblInfo {
            margin-bottom: 1rem;
        }
        .container-label
        {
            display: flex;
            flex-direction: row;
        }
    </style>

    <div class="card mt-3" style="width: 18rem;">
        <div class="card-body m-3">
            <div class="container-label">
                <p>Nombre:</p>
                <asp:Label CssClass="lblInfo" Text="NombreCompleto" ID="txtNombreUsuario" runat="server" />
            </div>
            <div class="container-label">
                <p>DNI:</p>
                <asp:Label CssClass="lblInfo" Text="DNI" ID="txtDniUsuario" runat="server" />
            </div>
            <div class="container-label">
                <p>Email:</p>
                <asp:Label CssClass="lblInfo" Text="Email" ID="txtEmailUsuario" runat="server" />
            </div>
            <div class="container-label">
                <p>FechaNacimiento:</p>
                <asp:Label CssClass="lblInfo" Text="FechaNacimiento" ID="txtFechaNacimiento" runat="server" />
            </div>
            <div class="container-label">
                <p>Rol:</p>
                <asp:Label CssClass="lblInfo" Text="Rol" ID="txtRolUsuario" runat="server" />
            </div>
            <div class="container-label">
                <p>Contraseña:</p>
                <asp:Label CssClass="lblInfo" Text="********" ID="txtPasswordUsuario" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
