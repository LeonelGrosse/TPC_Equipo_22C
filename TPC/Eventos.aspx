<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="TPC.Eventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        h1 {
            margin-top: 30px;
        }

        .card {
            border-radius: 10px;
            transition: transform 0.3s ease;
        }

            .card:hover {
                transform: translateY(-5px);
            }

        .card-img-top {
            object-fit: cover;
            height: 100%;
            width: 100%;
        }

        .card-body h5 {
            font-size: 1.25rem;
            font-weight: bold;
        }

        .card .card-text {
            color: #6c757d;
        }

            .card .card-text strong {
                color: #343a40;
            }

        .btn-success {
            background-color: #28a745;
            border-color: #28a745;
        }

            .btn-success:hover {
                background-color: #218838;
                border-color: #1e7e34;
            }
    </style>

    <h1>Eventos</h1>

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

    <asp:Repeater ID="repRepetidor" runat="server">
        <ItemTemplate>
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <div class="card mb-3 shadow-sm border-light" style="width: 100%;">
                    <div class="row g-0">
                        <div class="col-md-4">
                            <img src="<%#Eval("Imagen.URL") %>" class="card-img-top rounded-start" alt="...">
                        </div>
                        <div class="col-md-4">
                            <div class="card-body">
                                <h5 class="card-title text-primary"><%#Eval("Nombre") %></h5>
                                <p class="card-text"><strong>Fecha: </strong><%#Eval("FechaEvento") %></p>
                                <p class="card-text"><strong>Provincia: </strong><%#Eval("Ubicacion.Ciudad.Provincia.Nombre") %></p>
                                <p class="card-text"><strong>Ciudad:</strong> <%#Eval("Ubicacion.Ciudad.Nombre") %></p>
                                <p class="card-text"><strong>Direccion:</strong> <%#Eval("Ubicacion.Direccion.Calle") %></p>
                                <p class="card-text"><strong>Costo: </strong><%#Eval("CostoInscripcion") %></p>
                                <p class="card-text"><strong>Disciplina: </strong><%# ObtenerDescripciones((List<dominio.Disciplina>)Eval("Disciplina")) %></p>
                                <p class="card-text"><strong>Edad Minima: </strong><%#Eval("EdadMinima") %></p>
                            </div>
                        </div>
                        <div class="col-md-4 d-flex flex-column justify-content-between p-3">
                            <p class="card-text"><strong>Cupos: </strong><%#Eval("CuposDisponibles") %></p>
                            <%if (accesorio.Seguridad.SesionActiva(Session["UsuarioActivo"])){
                                    if (accesorio.Seguridad.UsuarioLogueado.EsParticipante())
                                    {%>
                                    <asp:Button ID="btnInscribirse" runat="server" Text="Inscribirse" OnClick="btnInscribirse_Click" CommandArgument='<%#Eval("IdEvento")%>' CommandName="IdEvento" CssClass="btn btn-success" />
                                    <%}
                                        else if (accesorio.Seguridad.UsuarioLogueado.EsOrganizador())
                                        {%>
                                    <asp:Button ID = "btnModificar" runat = "server" Text = "Modificar" OnClick="btnModificar_Click" CommandArgument = '<%#Eval("IdEvento")%>' CommandName="IdEvento" CssClass="btn btn-success" />
                                    <%}
                            }
                            %>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
