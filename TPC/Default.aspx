<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        /* body {
            background: #262626;
        }*/

        .seccion-container {
            padding-top: 8rem;
        }

        .seccion-container-descripcion p {
            padding: 0 2rem;
            text-align: center;
            font: 600 3rem Roboto;
            color: #242424;
        }

        .section-buttons {
            display: flex;
            justify-content: space-between;
            flex-wrap: wrap;
            width: 100%;
        }

            .section-buttons .container-button {
                padding: 1.2rem;
            }

            .section-buttons .btn {
                padding: 1.5rem 1rem;
                border-radius: 100vw;
                font: 600 1rem Roboto;
                color: white;
            }

        .btn-organizador {
            background-color: #023373;
        }

            .btn-organizador:hover {
                background-color: #023373;
                color: white !important;
            }

        .btn-participante {
            background-color: #F23D3D;
        }

            .btn-participante:hover {
                background-color: #F23D3D;
                color: white !important;
            }
    </style>
    <section class="seccion-container container d-flex flex-column">
        <div class="seccion-container-descripcion">
            <p>Encontra todos los eventos deportivos de resistencia en un solo lugar.</p>
        </div>
        <div class="section-buttons d-flex flex-row justify-content-center g-4">
            <div class="container-button">
                <asp:Button Text="Quiero ser organizador" type="submit" ID="BtnSerOrganizador" CssClass="btn btn-organizador" OnClick="BtnSerOrganizador_Click" runat="server" />
            </div>
            <div class="container-button">
                <asp:Button Text="Quiero ser participante" type="submit" ID="BtnSerParticipante" CssClass="btn btn-participante" OnClick="BtnSerParticipante_Click" runat="server" />
            </div>
        </div>
    </section>

</asp:Content>
