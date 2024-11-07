<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="OrganizadorFormulario.aspx.cs" Inherits="TPC.OrganizadorFormulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row mb-3">
        <asp:Label ID="lblNombre" runat="server" Text="Ingrese su nombre: " CssClass="col-sm-2 col-form-label"></asp:Label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Label ID="lblAvisoNombre" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
    </div>
    <div class="row mb-3">
        <asp:Label ID="lblApellido" runat="server" Text="Ingrese su apellido: " CssClass="col-sm-2 col-form-label"></asp:Label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtApellido" CssClass="form-control" runat="server"></asp:TextBox>
            <asp:Label ID="lblAvisoApellido" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
    </div>
    <div class="row mb-3">
        <asp:Label ID="lblEmail" runat="server" Text="Ingrese su E-mail: " CssClass="col-sm-2 col-form-label"></asp:Label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtEmail" CssClass="form-control" TextMode="Email" runat="server"></asp:TextBox>
            <asp:Label ID="lblAvisoEmail" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
        </div>
    </div>
    <div class="row mb-3">
        <asp:Label ID="lblArchivo" runat="server" Text="Ingrese su Curriculum: " CssClass="col-sm-2 col-form-label"></asp:Label>
        <div class="col-sm-10">
            <input type="file" class="form-control" id="inputGroupFile02">
        </div>
    </div>
    <div class="row mb-3">
        <asp:Label ID="lblSobreVos" runat="server" Text="Explicanos porque serias un buen organizador: " CssClass="col-sm-2 col-form-label"></asp:Label>
        <div class="col-sm-10">
            <asp:TextBox ID="txtSobreVos" CssClass="form-control" runat="server"></asp:TextBox>
        </div>
    </div>
    <div>
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-light" OnClick="btnEnviar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-light" OnClick="btnCancelar_Click" />
    </div>
</asp:Content>
