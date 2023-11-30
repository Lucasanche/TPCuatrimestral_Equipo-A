<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearCliente.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.CrearCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-2"></div>
    <div class="container">
        <form novalidate>
            <h3 class="uk-heading-divider">Agregar Clientes</h3>

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
                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Telefono:</label>
                    <div class="uk-form-controls">
                        <asp:Calendar ID="CalendarioFechaNacimiento" runat="server"></asp:Calendar>
                    </div>
                </div>
                
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cliente" OnClick="btnGuardar_Click" CssClass="uk-button uk-button-secondary uk-width-1-1" UseSubmitBehavior="false" />
                <asp:Label Text="" runat="server" ID="txtAgregaCliente" />
            </div>
        </form>
    </div>
</asp:Content>
