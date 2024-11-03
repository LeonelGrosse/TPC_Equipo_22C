<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="TPC.Eventos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Eventos</h1>

    <div class="Filtro d-flex justify-content-end">
        <button class="btn btn-secondary">Fecha</button>
        <button class="btn btn-secondary">Ubicacion</button>
        <button class="btn btn-secondary">Costo</button>
        <button class="btn btn-secondary">Disciplina</button>
    </div>

        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div class="row row-cols-1 row-cols-md-3 g-4">
                    <div class="card mb-3" style="width: 100%;">
                        <div class="row g-0">
                            <div class="col-md-4">
                                <img src="<%#Eval("Imagen.URL") %>" class="img-fluid rounded-start" alt="...">
                            </div>
                            <div class="col-md-4">
                                <div class="card-body">
                                    <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                    <p class="card-text">Fecha: <%#Eval("FechaEvento") %></p>
                                    <p class="card-text">Costo: <%#Eval("CostoInscripcion") %></p>
                                    <p class="card-text">Disciplina: <%#Eval("Disciplina.Descripcion") %></p>
                                    <p class="card-text">Edad Minima: <%#Eval("EdadMinima") %></p>
                                </div>
                            </div>
                            <div class="col-md-4 d-flex justify-content-end">
                                <p class="card-text">Cupos: <%#Eval("CuposDisponibles") %></p>
                                <asp:Button ID="btnInscribirse" runat="server" Text="Inscribirse" CssClass="btn btn-primary align-self-end" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

</asp:Content>
