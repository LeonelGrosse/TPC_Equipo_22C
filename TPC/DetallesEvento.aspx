<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetallesEvento.aspx.cs" Inherits="TPC.DetallesEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        div {
            margin-bottom: 15px;
        }

        label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
        }

        input[type="text"], textarea {
            padding: 10px;
            border: 1px solid #ccc;
            border-radius: 4px;
            width: 100%;
            box-sizing: border-box;
            background-color: #f9f9f9;
        }

        .button-container {
            display: flex;
            justify-content: center;
            margin-top: 20px;
        }

        input[type="button"], .btn {
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            margin: 0 10px;
            transition: background-color 0.3s, transform 0.3s;
            font-size: 16px;
        }

            input[type="button"][id$="btnAceptar"], .btn-primary {
                background-color: #007bff;
                color: white;
            }

            input[type="button"][id$="btnCancelar"], .btn-secondary {
                background-color: #6c757d;
                color: white;
            }

            input[type="button"]:hover, .btn:hover {
                opacity: 0.9;
                transform: translateY(-2px);
            }

        @media (max-width: 600px) {
            div {
                flex-direction: column;
            }

            input[type="text"], input[type="button"], .btn {
                width: 100%;
                margin-bottom: 10px;
            }

            .button-container {
                flex-direction: column;
            }
        }
    </style>

    <div class="row" style="margin-top: 50px">
        <h3 class="col-12 text-center">Esta por inscribirse al siguiente evento</h3>
    </div>

    <div>
        <div>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" Enabled="false" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>
            <asp:TextBox ID="txtFecha" runat="server" Enabled="false" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblProvincia" runat="server" Text="Provincia"></asp:Label>
            <asp:TextBox ID="txtProvincia" runat="server" Enabled="false" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblCiudad" runat="server" Text="Ciudad"></asp:Label>
            <asp:TextBox ID="txtCiudad" runat="server" Enabled="false" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblCalle" runat="server" Text="Calle"></asp:Label>
            <asp:TextBox ID="txtCalle" runat="server" Enabled="false" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblAltura" runat="server" Text="Altura"></asp:Label>
            <asp:TextBox ID="txtAltura" runat="server" Enabled="false" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblCosto" runat="server" Text="Costo"></asp:Label>
            <asp:TextBox ID="txtCosto" runat="server" Enabled="false" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblCupos" runat="server" Text="Cupos"></asp:Label>
            <asp:TextBox ID="txtCupos" runat="server" Enabled="false" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblEdadMinima" runat="server" Text="Edad Minima"></asp:Label>
            <asp:TextBox ID="txtEdadMinima" runat="server" Enabled="false" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblDisciplina" runat="server" Text="Disciplina"></asp:Label>
            <%foreach (dominio.Disciplina disciplina in evento.Disciplina)
                { %>
            <label><%: disciplina.Nombre %> : <%:disciplina.Distancia %></label>
            <%} %>
        </div>

        <div class="button-container">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass=" btn btn-primary" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
        </div>
    </div>
</asp:Content>
