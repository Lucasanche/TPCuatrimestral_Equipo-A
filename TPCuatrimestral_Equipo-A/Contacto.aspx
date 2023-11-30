<%@ Page EnableEventValidation="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.Contacto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="uk-section uk-section-default">
        <div class="uk-container">
            <h3>Contacto</h3>
            <dl class="uk-description-list uk-description-list-divider">
                <dt>DNI</dt>
                <dd><asp:Label runat="server" ID="lblDNI" /></dd>
                <dt>Nombre</dt>
                <dd><asp:Label runat="server" ID="lblNombre" /></dd>
                <dt>Apellido</dt>
                <dd><asp:Label runat="server" ID="lblApellido" /></dd>
                <dt>Email</dt>
                <dd><asp:Label runat="server" ID="lblEmail" /></dd>
                <dt>Telefono</dt>
                <dd><asp:Label runat="server" ID="lblTelefono" /></dd>
            </dl>
        </div>
    </div>

    <div class="uk-container">
        <button class="uk-button uk-button-default uk-button-large" type="button" uk-toggle="target: #modal-editar">Editar Cliente</button>
        <asp:LinkButton runat="server" CommandName="CrearTicket" OnCommand="CrearTicket_Command" class="uk-button uk-button-primary uk-button-large">Agregar Incidente</asp:LinkButton>
        <button class="uk-button uk-button-secondary uk-button-large" type="button" uk-toggle="target: #modal-eliminar">Eliminar Cliente</button>
    </div>

    <!--Inicio advert para eliminar-->
    <div id="modal-eliminar" uk-modal>
        <div class="uk-modal-dialog uk-modal-body">
            <h2 class="uk-modal-title">Headline</h2>
            <p>Esta seguro que desea darle la BAJA al cliente?</p>
            <p class="uk-text-right">
                <button class="uk-button uk-button-default uk-modal-close" type="button">Cancelar</button>
                <asp:Button Text="Confirmar" runat="server" ID="EliminarCliente" OnClick="EliminarCliente_Click" CssClass="uk-button uk-button-danger" AutoPostBack="false" UseSubmitBehavior="False" />
            </p>
            <asp:Label Text="text" runat="server" ID="txtEliminado"/>
        </div>
    </div>
  <!--FIN advert para eliminar-->

    

    <!-- Modal Edicion Cliente-->
    <div id="modal-editar" uk-modal>
        <div class="uk-modal-dialog uk-modal-body uk-margin-auto-vertical">
            <h3 class="uk-heading-divider">Modificar Cliente</h3>

            <button class="uk-modal-close-default" type="button" uk-close></button>

        <div class="uk-form-stacked">
            <div class="uk-margin">
                <label class="uk-form-label" for="form-stacked-text">Nombre:</label>
                <div class="uk-form-controls">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="uk-input" />
                </div>
            </div>

            <div class="uk-margin">
                <label class="uk-form-label" for="form-stacked-text">Apellido:</label>
                <div class="uk-form-controls">
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="uk-input" />
                </div>
            </div>

            <div class="uk-margin">
                <label class="uk-form-label" for="form-stacked-text">DNI:</label>
                <div class="uk-form-controls">
                    <asp:TextBox ID="txtDNI" runat="server" CssClass="uk-input" />
                </div>
            </div>

             <div class="uk-margin">
                 <label class="uk-form-label" for="form-stacked-text">Email:</label>
                 <div class="uk-form-controls">
                     <asp:TextBox ID="txtEmail" runat="server" CssClass="uk-input" />
                 </div>
             </div>

            <div class="uk-margin">
                <label class="uk-form-label" for="form-stacked-text">Telefono:</label>
                <div class="uk-form-controls">
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="uk-input" />
                </div>
            </div>
                <p class="uk-text-right">
                    <asp:Button Text="Guardar Cambios" runat="server" ID="ConfirmaEdicion" OnClick="ConfirmaEdicion_Click" CssClass="uk-button uk-button-primary" AutoPostBack="false" UseSubmitBehavior="False" />
                    <button class="uk-button uk-button-default uk-modal-close" type="button">Cancelar</button>
                </p>
                <asp:Label Text="" runat="server" ID="txtEditado"/>
            </div>
        </div>
    </div> 
    <!-- Fin Modal Edicion -->



</asp:Content>
