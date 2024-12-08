﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="TPC.Eventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

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
                transform: scale(1.05)
            }

        .btn-card {
            background-color: #023373;
        }

            .btn-card:hover {
                color: white;
                background-color: #023373;
                transform: scale(1.05)
            }

        .form-control {
            border-radius: 100vw;
            background-color: #E0E4EF;
        }
    </style>

    <h1>Eventos</h1>
    <div class="d-flex justify-content-end w-100 p-2">
        <div class="d-flex align-items-end container-dropdowns">
            <div class="mx-2">
                <p class="p-0 m-0">Buscar por:</p>
                <asp:DropDownList ID="DropDownOpcionesFiltroEventos" CssClass="btn btn-filtros bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" OnSelectedIndexChanged="DropDownOpcionesFiltroEventos_SelectedIndexChanged" AutoPostBack="true" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mx-2">
                <p class="p-0 m-0">Criterio:</p>
                <asp:DropDownList ID="DropDownListCriterioEventos" CssClass="btn btn-filtros bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" OnSelectedIndexChanged="DropDownListCriterioEventos_SelectedIndexChanged" AutoPostBack="true" runat="server">
                </asp:DropDownList>
            </div>
            <div class="mx-2">
                <asp:Button ID="BtnFiltrarEvento" Text="Filtrar" CssClass="btn btn-filtros" OnClick="BtnFiltrarEvento_Click" runat="server" />
            </div>
            <div class="mx-2">
                <asp:Button ID="BtnLimpiarFiltroEvento" Text="Limpiar" CssClass="btn btn-filtros" OnClick="BtnLimpiarFiltroEvento_Click" runat="server" />
            </div>
        </div>
    </div>

    <asp:Repeater ID="repRepetidor" OnItemDataBound="repRepetidor_ItemDataBound" runat="server">
        <ItemTemplate>
            <div class="container-eventos row row-cols-1 row-cols-md-3 g-4 mt-3">
                <div class="card mb-3 shadow-sm border-light" style="width: 100%;">
                    <div class="row g-0">
                        <div class="col-md-4">
                            <img src="<%#Eval("Imagen.URL") %>" class="card-img-top rounded-start" alt="...">
                        </div>
                        <div class="col-md-4">
                            <div class="card-body">
                                <h5 class="card-title text-primary"><%#Eval("Nombre") %></h5>
                                <p class="card-text"><strong>Fecha: </strong><%# Eval("FechaEvento", "{0:dd/MM/yyyy}") %></p>
                                <p class="card-text"><strong>Provincia: </strong><%#Eval("Ubicacion.Ciudad.Provincia.Nombre") %></p>
                                <p class="card-text"><strong>Ciudad:</strong> <%#Eval("Ubicacion.Ciudad.Nombre") %></p>
                                <p class="card-text"><strong>Direccion:</strong> <%#Eval("Ubicacion.Direccion.Calle") %></p>
                                <p class="card-text"><strong>Costo: </strong><%# Eval("CostoInscripcion", "{0:$#,0}") %></p>
                                <asp:Repeater ID="RepeaterDisciplinas" runat="server">
                                    <ItemTemplate>
                                        <p class="card-text">
                                            <strong>Disciplina:</strong> <%# Eval("Nombre") %> - <strong>Distancia:</strong> <%# Eval("Distancia") %> km
                                        </p>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <p class="card-text"><strong>Edad Minima: </strong><%#Eval("EdadMinima") %></p>
                            </div>
                        </div>
                        <div class="col-md-4 d-flex flex-column justify-content-between p-3">
                            <p class="card-text"><strong>Cupos: </strong><%#Eval("CuposDisponibles") %></p>
                            <%if (accesorio.Seguridad.SesionActiva(Session["UsuarioActivo"]))
                                {
                                    if (accesorio.Seguridad.UsuarioLogueado.EsParticipante())
                                    {%>
                            <asp:Button ID="btnInscribirse" runat="server" Text="Inscribirse" OnClick="btnInscribirse_Click" CommandArgument='<%#Eval("IdEvento")%>' CommandName="IdEvento" CssClass="btn btn-card" />
                            <%}
                                else if (accesorio.Seguridad.UsuarioLogueado.EsOrganizador() || accesorio.Seguridad.UsuarioLogueado.EsAdministrador())
                                {%>

                            <div class="d-flex justify-content-end gap-3">
                                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CommandArgument='<%#Eval("IdEvento")%>' CommandName="IdEvento" CssClass="btn btn-card" />
                                <asp:Button ID="btnCargarResultados" Text="Cargar Resultados" CommandArgument='<%#Eval("IdEvento")%>' CommandName="IdEvento" CssClass="btn btn-card" OnClick="btnCargarResultados_Click" runat="server" />
                                <asp:Button ID="btnParticipantes" runat="server" Text="Ver Participantes" OnClick="btnParticipantes_Click" CommandArgument='<%#Eval("IdEvento")%>' CommandName="IdEvento" CssClass="btn btn-card" />
                            </div>
                            <%}
                                }
                            %>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <div class="d-flex flex-column align-items-center w-100" runat="server">
        <label id="MsjReporteBusquedaEventos" cssclass="g-0 mt-5 fst-italic" visible="false" runat="server"></label>
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

    <div id="Div1" class="d-flex flex-column justify-content-center align-items-center container-card-msj position-fixed top-0 start-0 w-100 h-100" style="min-height: 80vh;" visible="false" runat="server">
        <div class="card col-12 " style="width: 40rem; height: 30rem">
            <div class="card-body d-flex flex-column align-items-start flex-wrap bg-danger bg-opacity-25">
                <div class="container-dpd-dni d-flex align-self-start">
                    <label placeholder="Seleccionar DNI">DNI de usuario:</label>
                    <asp:DropDownList ID="DropDownDNI" CssClass="btn bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" runat="server">
                    </asp:DropDownList>
                </div>
                <div class="container-disciplinas d-flex flex-column align-items-center gap-2">

                    <div id="ContainerNatacion" class="d-flex align-items-center gap-2 pt-2" visible="false" runat="server">
                        <asp:Label For="" Text="Natación" runat="server" />
                        <asp:TextBox ID="TextBoxMinutosNatacion" Text="" CssClass="form-control w-25" placeHolder="Minutos" runat="server" />
                        <asp:TextBox ID="TextBoxSegundosNatación" Text="" CssClass="form-control w-25" placeHolder="Segundos" runat="server" />
                        <p class="d-flex m-0">totales.</p>
                    </div>

                    <div id="ContainerCiclismo" class="d-flex align-items-center gap-2 pt-2" visible="false" runat="server">
                        <asp:Label For="" Text="Ciclismo" runat="server" />
                        <asp:TextBox ID="TextBoxMinutosCiclismo" Text="" CssClass="form-control w-25" placeHolder="Minutos" runat="server" />
                        <asp:TextBox ID="TextBoxSegundosCiclismo" Text="" CssClass="form-control w-25" placeHolder="Segundos" runat="server" />
                        <p class="d-flex m-0">totales.</p>
                    </div>

                    <div id="ContainerRunning" class="d-flex align-items-center gap-2 pt-2" visible="false" runat="server">
                        <asp:Label For="" Text="Running" runat="server" />
                        <asp:TextBox ID="TextBoxMinutosRunning" Text="" CssClass="form-control w-25" placeHolder="Minutos" runat="server" />
                        <asp:TextBox ID="TextBoxSegundosRunning" Text="" CssClass="form-control w-25" placeHolder="Segundos" runat="server" />
                        <p class="d-flex m-0">totales.</p>
                    </div>

                </div>

                <div class="d-flex gap-2 pt-2">
                    <div class="d-flex justify-content-center align-items-center text-center">
                        <asp:Button Text="Cargar" ID="BtnCargar" type="button" CssClass="btn btn-card" OnClick="BtnCargar_Click" runat="server" />
                    </div>
                    <div class="d-flex justify-content-center align-items-center text-center">
                        <asp:Button Text="Cancelar" ID="BtnCancelar" type="button" CssClass="btn btn-card" OnClick="BtnCancelar_Click" runat="server" />
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
