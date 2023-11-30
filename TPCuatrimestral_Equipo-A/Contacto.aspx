<%@ Page EnableEventValidation="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <form novalidate>
        <div class="uk-section uk-section-default">
            <div class="uk-container">
                <h3>Contacto</h3>
                <dl class="uk-description-list uk-description-list-divider">
                    <dt>DNI</dt>
                    <dd><asp:Label ID="lblDNI" runat="server" /></dd>
                    <dt>Nombre</dt>
                    <dd><asp:TextBox ID="txtNombre" runat="server" CssClass="uk-input" /></dd>
                    <dt>Apellido</dt>
                    <dd><asp:TextBox ID="txtApellido" runat="server" CssClass="uk-input" /></dd>
                    <dt>Email</dt>
                    <dd><asp:TextBox ID="txtEmail" runat="server" CssClass="uk-input" /></dd>
                    <dt>Telefono</dt>
                    <dd><asp:TextBox ID="txtTelefono" runat="server" CssClass="uk-input" /></dd>
                </dl>
            </div>
        </div>

        <div class="uk-container">
            <asp:Button Text="Editar Cliente" ID="btnEditarCliente" AutoPostBack="false" OnClick="btnEditarCliente_Click" CssClass="uk-button uk-button-secondary uk-button-large" runat="server" />
            <asp:LinkButton runat="server" CommandName="CrearTicket" OnCommand="CrearTicket_Command" class="uk-button uk-button-primary uk-button-large">Agregar Incidente</asp:LinkButton>
            <button class="uk-button uk-button-danger uk-button-large" type="button" uk-toggle="target: #modal-eliminar">Eliminar Cliente</button>
        </div>
    </form>

    <!--Inicio advert para eliminar-->
    <div id="modal-eliminar" uk-modal>
        <div class="uk-modal-dialog uk-modal-body">
            <h2 class="uk-modal-title">Headline</h2>
            <p>Esta seguro que desea darle la BAJA al cliente?</p>
            <p class="uk-text-right">
                <button class="uk-button uk-button-default uk-modal-close" type="button">Cancelar</button>
                <asp:Button Text="Confirmar" runat="server" ID="EliminarCliente" OnClick="EliminarCliente_Click" CssClass="uk-button uk-button-danger" AutoPostBack="false" UseSubmitBehavior="false"/>
            </p>
            
        </div>
    </div>
  <!--FIN advert para eliminar-->

    <asp:Label Text="" runat="server" ID="txtEditado"/>
    <asp:Label Text="" runat="server" ID="txtEliminado"/>

    



</asp:Content>
