<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="TPC.PerfilUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <style>
        .container-profile {
            width: 1200px;
            max-width: 100%;
            height: auto;
        }

        .container-profile-body {
            display: flex;
            flex-direction: row;
            justify-content: center;
            align-items: flex-start;
            flex-wrap: wrap;
            width: 100%;
            font: 400 1rem Roboto;
            color: white;
        }

        .container-info {
            padding: 0 4rem;
        }

            .container-info .form-control {
                border: none;
                border-radius: 100vw;
            }

        .profile-container-image picture .img {
            width: 100%;
            max-width: 300px;
            height: 100%;
            object-fit: cover;
            object-position: top;
            clip-path: circle();
        }

        .info-controls {
            padding-bottom: 1rem;
        }

            .info-controls .btn {
                border-radius: 100vw;
                padding: .5rem 1rem;
            }
    </style>

    <div class="container-profile card mt-3 bg-dark">
        <div class="container-profile-body card-body m-3">
            <div class="profile-container-image row">
                <picture>
                    <asp:Image ID="UrlImagen" ImageUrl="https://imgs.search.brave.com/kdxUh1UbYBaqf0QViEa5oF5RwtIcTQKI8XXgRBeIYJc/rs:fit:500:0:0:0/g:ce/aHR0cHM6Ly9zbWFs/bGltZy5wbmdrZXku/Y29tL3BuZy9zbWFs/bC8yMzMtMjMzMjY3/N19pbWFnZS01MDA1/ODAtcGxhY2Vob2xk/ZXItdHJhbnNwYXJl/bnQucG5n" CssClass="img img-fluid" runat="server" />
                </picture>
            </div>
            <div class="container-info">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="container-info-nombre row">
                            <div id="containerControlNombre" class="info-controls col-6" runat="server">
                                <label for="txtNombre" class="form-label">Nombre</label>
                                <asp:TextBox ID="txtNombre" CssClass="form-control" ReadOnly="true" runat="server" />
                            </div>
                            <div id="containerControlApellido" class="info-controls col-6" runat="server">
                                <label for="txtApellido" class="form-label">Apellido</label>
                                <asp:TextBox ID="txtApellido" CssClass="form-control" ReadOnly="true" runat="server" />
                            </div>
                        </div>
                        <div class="container-infor-dni-fecha row">
                            <div class="info-controls col-6">
                                <label for="txtDni" class="form-label">DNI</label>
                                <asp:TextBox ID="txtDni" CssClass="form-control" ReadOnly="true" runat="server" />
                            </div>
                            <div class="info-controls col-6">
                                <label for="txtFechaNacimiento" class="form-label">Fecha Nacimiento</label>
                                <asp:TextBox ID="txtFechaNacimiento" CssClass="form-control" ReadOnly="true" runat="server" />
                            </div>
                        </div>
                        <div class="container-info-email row">
                            <div id="containerControlEmail" class="info-controls" runat="server">
                                <label for="txtEmail" class="form-label">Email</label>
                                <asp:TextBox ID="txtEmail" CssClass="form-control" ReadOnly="true" runat="server"/>
                            </div>
                        </div>
                        <div class="container-info-password row">
                            <div id="containerControlPassword" class="info-controls" runat="server">
                                <label for="txtPassword" class="form-label">Contraseña</label>
                                <asp:TextBox ID="txtPassword" CssClass="form-control" ReadOnly="true" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="container-btn d-flex justify-content-center">
                    <div class="container-btn-modificar ps-2">
                        <div class="info-controls w-100 d-flex justify-content-center">
                            <asp:Button ID="btn_modificar" type="submit" Text="Modificar" CssClass="btn bg-success text-white" OnClick="btn_modificar_Click" runat="server" />
                        </div>
                    </div>
                    <div class="container-btn-aceptar ps-2">
                        <div class="info-controls w-100 d-flex justify-content-center">
                            <asp:Button ID="btn_confirmar" Text="Aceptar" CssClass="btn bg-success text-white" OnClick="btn_confirmar_Click" Visible="false" runat="server" />
                        </div>
                    </div>
                    <div class="container-btn-cancelar ps-2">
                        <div class="info-controls w-100 d-flex justify-content-center">
                            <asp:Button ID="btn_cancelar" Text="Cancelar" CssClass="btn bg-danger text-white" OnClick="btn_cancelar_Click" Visible="false" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
