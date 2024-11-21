<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisInscripciones.aspx.cs" Inherits="TPC.MisInscripciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .card {
            width: 20rem;
            min-width: 350px;
            max-width: 100%;
        }

        img {
            height: 150px;
            width: 100%;
            object-fit: cover;
            object-position: center;
        }

        .container-eventos .card-text {
            display: inline-block;
            padding: .4rem;
            border-radius: 100vw;
            font-size: .8rem;
            background-color: #E0E4EF;
            font: 600 .8rem Roboto;
            color: #242424;
        }

        .evento-disponible {
            background-color: #84BF0475;
        }

        .evento-cancelado {
            background-color: #D91A6075;
        }

        .btn {
            padding: .6rem .6rem;
            border-radius: 100vw;
            font: 600 .85rem Roboto;
            color: white;
        }

        .btn-filtros {
            background-color: #F23D3D;
        }

            .btn-filtros:hover {
                color: white;
                background-color: #F23D3D;
                transform: scale(1.05);
            }

        .btn-card {
            background-color: #023373;
        }

            .btn-card:hover {
                color: white;
                background-color: #023373;
                transform: scale(1.05)
            }
    </style>

    <div class="container-cards d-flex flex-wrap gap-5 mt-5">
        <div class="w-100">
            <h1>Historial de inscripciones</h1>
        </div>
        <div class="d-flex justify-content-end w-100 p-2">
            <div class="d-flex align-items-end container-dropdowns">
                <div class="mx-2">
                    <p class="p-0 m-0">Buscar por:</p>
                    <asp:DropDownList ID="DropDownOpcionesFiltro" CssClass="btn btn-filtros bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" OnSelectedIndexChanged="DropDownOpcionesFiltro_SelectedIndexChanged" AutoPostBack="true" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="mx-2">
                    <p class="p-0 m-0">Criterio:</p>
                    <asp:DropDownList ID="DropDownListCriterio" CssClass="btn btn-filtros bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" OnSelectedIndexChanged="DropDownListCriterio_SelectedIndexChanged" AutoPostBack="true" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="mx-2">
                    <asp:Button ID="BtnFiltrar" Text="Filtrar" CssClass="btn btn-filtros" OnClick="BtnFiltrar_Click" runat="server" />
                </div>
                <div class="mx-2">
                    <asp:Button ID="BtnLimpiarFiltro" Text="Limpiar" CssClass="btn btn-filtros" OnClick="BtnLimpiarFiltro_Click" runat="server" />
                </div>
            </div>
        </div>
        <asp:Repeater ID="RepeaterEventosUsuario" runat="server">
            <ItemTemplate>
                <div class="container-eventos card d-flex g-3">
                    <div class="row d-flex flex-column">
                        <picture class="">
                            <img src="<%#Eval("Imagen.URL") != null ? Eval("Imagen.URL") : "https://shorturl.at/aGjXG"  %>" class="card-img-top" alt="...">
                        </picture>
                        <div class="d-flex flex-column">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text">Fecha: <%#Eval("FechaEvento") %></p>
                                <p class="card-text">Provincia: <%#Eval("Ubicacion.Ciudad.Provincia.Nombre") %></p>
                                <p class="card-text">Ciudad: <%#Eval("Ubicacion.Ciudad.Nombre") %></p>
                                <p class="card-text">Direccion: <%#Eval("Ubicacion.Direccion.Calle") %></p>
                                <p class="card-text">Costo: $<%#Eval("CostoInscripcion") %></p>
                                <p class="card-text">Edad Minima: <%#Eval("EdadMinima") %></p>
                                <p class="card-text">Edad Maxima: <%#Eval("EdadMaxima") %></p>
                                <asp:Label ID="estadoEvento" CssClass="card-text" runat="server" />
                            </div>
                            <div class="d-flex justify-content-center pb-2">
                                <asp:Button ID="btnCancelarInscripcion" Text="Cancelar inscripcion" CssClass="btn btn-card" OnClick="btnCancelarInscripcion_Click" CommandArgument='<%#Eval("IdEvento") %>' CommandName="IDEvento" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
        <div class="d-flex flex-column align-items-center w-100" runat="server">
            <label id="MsjInscripciones" cssclass="g-0 mt-5 fst-italic" visible="false" runat="server"></label>
            <div>
                <asp:Button ID="btnVerEvento" Text="Quiero inscribirme" CssClass="btn btn-card" OnClick="btnVerEvento_Click" Visible="false" runat="server" />
            </div>
        </div>
    </div>

    <div id="ContainerCard" class="d-flex flex-column justify-content-center align-items-center container-card-msj position-fixed top-0 start-0 w-100 h-100" style="min-height: 80vh;" visible="false" runat="server">
        <div class="card col-12 " style="width: 26rem; height: 10rem">
            <div class="card-body d-flex flex-column justify-content-between align-items-center bg-danger bg-opacity-25">
                <asp:Label ID="CardMsj" Text="" class="card-text fs-6" runat="server" />
                <div class="d-flex justify-content-center align-items-center text-center">
                    <asp:Button Text="Volver" ID="BtnVolverInicio" type="button" CssClass="btn btn-card" OnClick="BtnVolverInicio_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
