<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Participantes.aspx.cs" Inherits="TPC.Participantes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        h2 {
            display: flex;
            justify-content: center;
            margin-top: 50px;
        }
    </style>
    <div>
        <h2>Participantes</h2>
    </div>
    <div>
        <asp:ScriptManager runat="server" ID="ScripManager1"/>
        <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="gvParticipantes" runat="server" AutoGenerateColumns="false" HorizontalAlign="Center" CssClass="table table-bordered table-hover table-responsive">
                    <Columns>
                        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
                        <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                        <asp:BoundField HeaderText="Dni" DataField="Dni" />
                        <asp:BoundField HeaderText="Fecha Nacimiento" DataField="FechaNacimiento" />
                        <asp:BoundField HeaderText="Correo Electronico" DataField="CorreoElectronico" />
                        <asp:TemplateField>
                            <HeaderTemplate>Eliminar de evento</HeaderTemplate>
                            <ItemTemplate>
                                <asp:Button ID="btnEliminarDeEvento" runat="server" Text="Eliminar" OnClick="btnEliminarDeEvento_Click" CssClass="btn btn-primary" CommandArgument='<%#Eval("Dni")%>'/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <HeaderStyle HorizontalAlign="Center" CssClass="table table-primary" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
