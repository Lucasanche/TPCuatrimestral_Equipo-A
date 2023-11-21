<%@ Page EnableEventValidation="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleTicket.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.DetalleTicket" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="uk-section uk-section-default">
        <div class="uk-container">
            <h3>Contacto</h3>
            <dl class="uk-description-list uk-description-list-divider">
                <dt>ID</dt>
                <asp:Label runat="server" ID="lblID"></asp:Label>
                <dt>Tipo</dt>
                <dd><asp:Label runat="server" ID="lblTipo" /></dd>
                <dt>Prioridad</dt>
                <dd><asp:Label runat="server" ID="lblPrioridad" /></dd>
                <dt>Descripcion De Inicial</dt>
                <dd><asp:Label runat="server" ID="lblDescripcionInicial" /></dd>
                <dt>Descripcion De Cierre</dt>
                <dd><asp:Label runat="server" ID="lblDescripcionCierre" /></dd>
                <dt>Legajo De Usuario</dt>
                <dd><asp:Label runat="server" ID="lblLegajoUsuario" /></dd>
                <dt>Cliente Afectado</dt>
                <dd><asp:Label runat="server" ID="lblClienteAfectado" /></dd>
                <dt>Fecha De Creacion</dt>
                <dd><asp:Label runat="server" ID="lblFechaCreacion" /></dd>
                <dt>Fecha De Cierre</dt>
                <dd><asp:Label runat="server" ID="lblFechaCierre" /></dd>
                <dt>Estado</dt>
                <dd><asp:Label runat="server" ID="lblEstado" /></dd>
            </dl>
        </div>
    </div>

    <div class="uk-container">
        <button class="uk-button uk-button-default uk-button-large" type="button" uk-toggle="target: #modal-example">Editar Ticket</button>
        <button class="uk-button uk-button-primary uk-button-large" href="#modal-center-Add" >Agregar Incidente</button>
        <button class="uk-button uk-button-secondary uk-button-large">Eliminar Ticket</button>
    </div>

</asp:Content>
