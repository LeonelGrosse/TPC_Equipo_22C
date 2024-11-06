<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CargarEvento.aspx.cs" Inherits="TPC.CargarEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <style>
        .row {
            padding-left: 0;
            padding-right: 0;
            margin-left: 0;
            margin-top: 0;
        }

        .container-form {
            padding: 2rem;
            border: 5px solid;
            border-radius: 8px;
        }

        .container-page {
            display: flex;
            justify-content: center;
            align-items: center;
            min-height: 80vh;
        }

            .container-page .container-form div {
                margin-bottom: 5px;
            }
    </style>

    <div class="container container-page m-4">
        <div class="container-form col-6">
            <div class="row">
                <h1>Registrar nuevo evento</h1>
                <div class="col-6">
                    <label for="NombreEvento" class="form-label">Nombre</label>
                    <asp:TextBox type="text" ID="NombreEvento" CssClass="form-control" placeholder="Ingrese el nombre" runat="server" />
                </div>
                <div class="col-6">
                    <label for="FechaEvento" class="form-label">Fecha</label>
                    <asp:TextBox type="Date" ID="FechaEvento" CssClass="form-control" placeholder="Ingres la fecha" runat="server" />
                </div>

                <div class="row">
                    <div class="col-6">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <label for="ProvinciaEvento" class="form-label">Provincia</label>
                                <asp:DropDownList ID="DropDownProvincias" CssClass="btn bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" OnSelectedIndexChanged="DropDownProvincias_SelectedIndexChanged" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-6">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <label for="CiudadEvento" class="form-label">Ciudad</label>
                                <asp:DropDownList ID="DropDownCiudades" CssClass="btn bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" runat="server">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <div class="col-6">
                        <label for="CalleEvento" class="form-label">Calle</label>
                        <asp:TextBox type="Text" ID="CalleEvento" CssClass="form-control" placeholder="Ingrese la calle" runat="server" />
                    </div>
                    <div class="col-6">
                        <label for="AlturaEvento" class="form-label">Altura</label>
                        <asp:TextBox type="Text" ID="AlturaEvento" CssClass="form-control" placeholder="Ingrese la altura" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <label for="CostoEvento" class="form-label">Costo inscripción</label>
                        <asp:TextBox type="Text" ID="CostoEvento" CssClass="form-control" placeholder="Ingrese el costo" runat="server" />
                    </div>
                    <div class="col-6">
                        <label for="CuposDisponibles" class="form-label">Cupos disponibles</label>
                        <asp:TextBox type="Text" ID="CuposDisponibles" CssClass="form-control" placeholder="Ingrese los cupos disponibles" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-6">
                        <label for="EdadMinEvento" class="form-label">Edad minima</label>
                        <asp:TextBox type="Text" ID="EdadMinEvento" CssClass="form-control" placeholder="Ingrese el costo" runat="server" />
                    </div>
                    <div class="col-6">
                        <label for="EdadMaxEvento" class="form-label">Edad maxima</label>
                        <asp:TextBox type="Text" ID="EdadMaxEvento" CssClass="form-control" placeholder="Ingrese el costo" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div id="containerDisciplina" class="row" runat="server">
                                <div class="col-6">
                                    <label for="Disciplina1" class="form-label">Disciplinas</label>
                                    <asp:DropDownList ID="DropDownDisciplina" CssClass="btn bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-5">
                                    <label for="DistanciaDisciplina1" class="form-label">Distancia</label>
                                    <asp:TextBox type="Text" ID="DistanciaDisciplina1" CssClass="form-control" placeholder="Distancia" runat="server" />
                                    <asp:RequiredFieldValidator CssClass="RequiredMessage" ErrorMessage="*El campo requiere un valor." ControlToValidate="DistanciaDisciplina1" Display="Dynamic" runat="server" />
                                    <asp:RegularExpressionValidator CssClass="RequiredMessage" ValidationExpression="^\d+$" ErrorMessage="*Solo valores númericos." ControlToValidate="DistanciaDisciplina1" Display="Dynamic" runat="server" />
                                </div>
                                <div class="col-1 d-flex justify-content-center align-items-center">
                                    <asp:LinkButton Text="text" ID="BtnAgregarDisciplina" CssClass="text-dark" OnClick="BtnAgregarDisciplina_Click" runat="server">
                                        <i class="bi bi-plus-circle fs-3"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>

                            <div id="containerDisciplina2" class="row" visible="false" runat="server">
                                <div class="col-6">
                                    <asp:DropDownList ID="DropDownDisciplina2" CssClass="btn bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-5">
                                    <asp:TextBox type="Text" ID="DistanciaDisciplina2" CssClass="form-control" placeholder="Distancia" runat="server" />
                                    <asp:RequiredFieldValidator CssClass="RequiredMessage" ErrorMessage="*El campo requiere un valor." ControlToValidate="DistanciaDisciplina2" Display="Dynamic" runat="server" />
                                     <asp:RegularExpressionValidator CssClass="RequiredMessage" ValidationExpression="^\d+$" ErrorMessage="*Solo valores númericos." ControlToValidate="DistanciaDisciplina2" Display="Dynamic" runat="server" />
                                </div>
                                <div class="col-1 d-flex justify-content-center align-items-start">
                                    <asp:LinkButton Text="text" ID="btnQuitarDisciplina2" CssClass="text-danger" OnClick="btnQuitarDisciplina2_Click" runat="server">
                                          <i class="bi bi-dash-circle fs-3"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>

                            <div id="containerDisciplina3" class="row" visible="false" runat="server">
                                <div class="col-6">
                                    <asp:DropDownList ID="DropDownDisciplina3" CssClass="btn bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" runat="server" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-5">
                                    <asp:TextBox type="Text" ID="DistanciaDisciplina3" CssClass="form-control" placeholder="Distancia" runat="server" />
                                    <asp:RequiredFieldValidator CssClass="RequiredMessage" ErrorMessage="*El campo requiere un valor." ControlToValidate="DistanciaDisciplina3" Display="Dynamic" runat="server" />
                                    <asp:RegularExpressionValidator CssClass="RequiredMessage" ValidationExpression="^\d+$" ErrorMessage="*Solo valores númericos." ControlToValidate="DistanciaDisciplina3" Display="Dynamic" runat="server" />
                                </div>
                                <div class="col-1 d-flex justify-content-center align-items-start">
                                    <asp:LinkButton Text="text" ID="btnQuitarDisciplina3" CssClass="text-danger" OnClick="btnQuitarDisciplina3_Click" runat="server">
                                        <i class="bi bi-dash-circle fs-3"></i>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                    </div>
                    <div class="col-4">
                        <label for="Disciplina2" class="form-label">Disciplina 2</label>
                        <asp:TextBox type="Text" ID="Disciplina2" CssClass="form-control" placeholder="Ingrese el disciplina" runat="server" />
                    </div>
                    <div class="col-4">
                        <label for="Disciplina3" class="form-label">Disciplina 3</label>
                        <asp:TextBox type="Text" ID="Disciplina3" CssClass="form-control" placeholder="Ingrese el disciplina" runat="server" />
                    </div>
                </div>
                <div>
                    <asp:Button Text="Registrar" type="submit" ID="BtnCargarEvento" CssClass="btn btn-primary" OnClick="BtnCargarEvento_Click" runat="server" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
