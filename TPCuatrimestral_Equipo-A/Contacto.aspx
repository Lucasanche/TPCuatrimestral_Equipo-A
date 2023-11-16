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
        <button class="uk-button uk-button-default uk-button-large" type="button" uk-toggle="target: #modal-example">Editar Cliente</button>
        <button class="uk-button uk-button-primary uk-button-large">Agregar Incidente</button>
        <button class="uk-button uk-button-secondary uk-button-large">Eliminar Cliente</button>
    </div>

    <!-- Modal Edicion Cliente-->
    <div id="modal-example" uk-modal>
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
                    <button class="uk-button uk-button-primary" type="button">Guardar Cambios</button>
                    <button class="uk-button uk-button-default uk-modal-close" type="button">Cancelar</button>
                </p>
            </div>
        </div>
    </div> 
    <!-- Fin Modal Edicion -->



</asp:Content>
