<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TPC.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div>
        <h1>Contactate con el staff</h1>
    </div>
    <section>
        <div class="w-50">
            <asp:Label ID="lblAsunto" runat="server" Text="¿Sobre que tema es su consulta?"></asp:Label>
            <asp:TextBox ID="txtAsunto" runat="server" class="form-control" TextMode="SingleLine"></asp:TextBox>
        </div>
        <div class="w-50">
            <asp:Label ID="lblCorreoContacto" runat="server" Text="Ingrese su consulta, la cual será respondida por un organizador: "></asp:Label>
            <asp:TextBox ID="txtCorreoContacto" runat="server" class="form-control" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div>
            <br />
            <asp:Button ID="btnEnviarCorreo" runat="server" Text="Enviar" OnClick="btnEnviarCorreo_Click" CssClass="btn btn-success" />
        </div>
    </section>




</asp:Content>

