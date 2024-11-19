<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ModificarEvento.aspx.cs" Inherits="TPC.ModificarEvento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        h1 {
            margin-top: 50px;
            display: flex;
            justify-content: center;
        }

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

        .Disciplina {
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

    <h1>Esta por modificar el siguiente evento</h1>

    <div>
        <div>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" Enabled="true" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblFecha" runat="server" Text="Fecha"></asp:Label>
            <asp:TextBox ID="txtFecha" runat="server" Enabled="true" CssClass="text" type="date"></asp:TextBox>
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
            <asp:TextBox ID="txtCalle" runat="server" Enabled="true" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblAltura" runat="server" Text="Altura"></asp:Label>
            <asp:TextBox ID="txtAltura" runat="server" Enabled="true" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblCosto" runat="server" Text="Costo"></asp:Label>
            <asp:TextBox ID="txtCosto" runat="server" Enabled="true" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblCupos" runat="server" Text="Cupos"></asp:Label>
            <asp:TextBox ID="txtCupos" runat="server" Enabled="true" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblEdadMinima" runat="server" Text="Edad Minima"></asp:Label>
            <asp:TextBox ID="txtEdadMinima" runat="server" Enabled="true" CssClass="text"></asp:TextBox>
        </div>

        <div>
            <asp:Label ID="lblEdadMaxima" runat="server" Text="Edad Maxima"></asp:Label>
            <asp:TextBox ID="txtEdadMaxima" runat="server" Enabled="true" CssClass="text"></asp:TextBox>
        </div>

        <asp:Repeater ID="repRepetidor" runat="server">
            <ItemTemplate>
                <div>
                    <asp:Label ID="lblDisciplina" runat="server" Text="Disciplina"></asp:Label>
                    <asp:DropDownList ID="DropDownDisciplina" CssClass="btn bg-color-white btn-md dropdown-toggle btn-outline-secondary text-start w-100" runat="server" AutoPostBack="true">
                    </asp:DropDownList>
                    <input id="txtDisciplina" type="text" value="<%#Eval("Descripcion")%>" enabled="false"></input>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <div class="button-container">
            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass=" btn btn-primary" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-secondary" />
            <asp:Button ID="btnBorrarEvento" runat="server" Text="Eliminar Evento" OnClick="btnBorrarEvento_Click" CssClass="btn btn-danger" />
        </div>
    </div>
</asp:Content>
