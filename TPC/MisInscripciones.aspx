<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MisInscripciones.aspx.cs" Inherits="TPC.MisInscripciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .card {
            width: 19rem;
            max-width: 100%;
        }

        img {
            height: 150px;
            width: 100%;
            object-fit: cover;
            object-position: center;
        }

        .card-text {
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
            background-color: #F23D3D;
        }

            .btn:hover {
                background-color: #F23D3D50;
            }
    </style>

    <div class="container-cards d-flex flex-wrap gap-5 mt-5">
        <div class="w-100">
            <h1>Historial de inscripciones</h1>
        </div>
        <div class="d-flex justify-content-end w-100 p-2">
            <div class="d-flex">
                <div>
                    <asp:DropDownList ID="DropDownFiltroFecha" CssClass="btn bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" runat="server">
                    </asp:DropDownList>
                </div>
                <div>
                    <asp:DropDownList ID="DropDownFiltroProvincias" CssClass="btn bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" runat="server">
                    </asp:DropDownList>
                </div>

                <div class="">
                    <asp:DropDownList ID="DropDownFiltroCosto" CssClass="btn bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
                <div class="">
                    <asp:DropDownList ID="DropDownFiltroDisciplina" CssClass="btn bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
        </div>
        <%if (ExistenInscripciones())
            { %>
        <asp:Repeater ID="RepeaterEventosUsuario" runat="server">
            <ItemTemplate>
                <div class="card d-flex g-3">
                    <div class="row d-flex flex-column">
                        <picture class="">
                            <img src="<%#Eval("Imagen.URL") %>" class="card-img-top" alt="...">
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
                                <asp:Button ID="btnCancelarInscripcion" Text="Cancelar inscripcion" CssClass="btn" OnClick="btnCancelarInscripcion_Click" CommandArgument='<%#Eval("IdEvento") %>' CommandName="IDEvento" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
        <%}
            else
            { %>
        <div class="d-flex flex-column align-items-center w-100">
            <p class="g-0 mt-5 fst-italic">Aun no se ha inscrito a ningun evento.</p>
            <div>
                <asp:Button ID="btnVerEvento" Text="Quiero inscribirme" CssClass="btn" OnClick="btnVerEvento_Click" runat="server" />
            </div>
        </div>
        <% } %>
    </div>

</asp:Content>
