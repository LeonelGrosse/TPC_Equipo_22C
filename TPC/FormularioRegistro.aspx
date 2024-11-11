<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioRegistro.aspx.cs" Inherits="TPC.FormularioRegistro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>Registrate!</h1>
        <p>Desafiá tu mente, inscribite para comenzar la aventura.</p>
    </div>
    <section>
        <div class="w-25">
            <asp:Label ID="lblNombre" runat="server" Text="Ingrese su nombre: "></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" class="form-control"></asp:TextBox>
            <asp:Label ID="lblAvisoNombre" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div class="w-25">
            <asp:Label ID="lblApellido" runat="server" Text="Ingrese su apellido: "></asp:Label>
            <asp:TextBox ID="txtApellido" runat="server" class="form-control"></asp:TextBox>
            <asp:Label ID="lblAvisoApellido" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div class="w-25">
            <asp:Label ID="lblEmail" runat="server" Text="Ingrese su E-mail: "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" class="form-control"></asp:TextBox>
            <asp:Label ID="lblAvisoEmail" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div class="w-25">
            <asp:Label ID="lblDNI" runat="server" Text="Ingrese su DNI: "></asp:Label>
            <asp:TextBox ID="txtDNI" runat="server" TextMode="Number" class="form-control"></asp:TextBox>
            <asp:Label ID="lblAvisoDNI" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div class="w-25">
            <asp:Label ID="lblFechaNacimiento" runat="server" Text="Ingrese su fecha de nacimiento: "></asp:Label>
            <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="DateTime" class="form-control"></asp:TextBox>
            <asp:Label ID="lblAvisoFechaNacimiento" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
        <div class="w-25">
            <asp:Label ID="lblContraseniaRegistro" runat="server" Text="Ingrese su contraseña: "></asp:Label>
            <asp:TextBox ID="txtContraseniaRegistro" runat="server" TextMode="Password" class="form-control"></asp:TextBox>
            <asp:Label ID="lblAvisoContrasenias" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>

        <div class="form-group row">
            <div class="col-auto">
                <asp:Label ID="lblImagenRegistro" runat="server" Text="Cargar una imagen (opcional):" CssClass="col-form-label"></asp:Label>
            </div>
        </div>

        <div class="form-group row">
            <div class="col-auto">
                <asp:FileUpload ID="inputGroupFile" runat="server" CssClass="form-control" />
            </div>
            <div class="col-auto">
                <asp:Button ID="btnCargarImagen" runat="server" Text="Cargar Imagen" OnClick="btnCargarImagen_Click" CssClass="btn btn-primary" />
            </div>
        </div>
        <br />
        <div class="form-group row">
            <div class="col-auto">
                <asp:Image ID="imgRegistro" runat="server" Width="200px" Height="200px" />
            </div>
        </div>
        <div>
            <br />
            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" CssClass="btn btn-success" />
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-danger" />
        </div>
    </section>
</asp:Content>
