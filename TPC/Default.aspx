<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .seccion-principal {
            max-width: 1200px;
            min-height: 100%;
            font: 600 1.6rem Roboto;
        }

            .seccion-principal a {
                text-decoration: none;
                cursor: pointer;
            }

        .section-buttons .btn {
            padding: 1rem;
            border-radius: 100vw;
            color: white;
        }

        .btn-organizador {
            background-color: #023373;
        }

        .btn-participante {
            background-color: #F23D3D;
        }
        picture{
            border-radius: 100vw;
        }

        picture img{
            min-width: 1200px;
            max-width: 100%;
        }
    </style>

    <section class="seccion-principal row mt-5">
        <picture>
            <img src="https://as1.ftcdn.net/v2/jpg/02/46/08/54/1000_F_246085469_hIVhuF98NapUOGaAniSAmpS5TQFqFybn.jpg" alt="" class="img-fluid" />
        </picture>
        <div>
            <p>BAEventos es un sitio que busca conectar a las personas con todas las competencias deportivas en la Argentina.</p>
        </div>
        <div>
            <p>No solo podras participar de los eventos sino tambien, registrarte como organizador y ser el creador de tu propia aventura.</p>
        </div>
        <div>
            <p>Es tu oportunidad de <a href="FormularioRegistro.aspx" class="">registrarte</a> y comenzar a vivir tu experiencia deportiva al maximo nivel! </p>
        </div>
        <div class="section-buttons d-flex flex-row justify-content-center g-4">
            <asp:Button Text="Quiero ser organizador" type="submit" ID="BtnSerOrganizador" CssClass="btn btn-organizador" OnClick="BtnSerOrganizador_Click" runat="server" />
            <asp:Button Text="Quiero ser participante" type="submit" ID="BtnSerParticipante" CssClass="btn btn-participante" OnClick="BtnSerParticipante_Click" runat="server" />
        </div>
    </section>

</asp:Content>
