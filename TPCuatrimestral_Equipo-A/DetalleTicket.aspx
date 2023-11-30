<%@ Page EnableEventValidation="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleTicket.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.DetalleTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <div class="uk-section uk-section-default">
        <div class="uk-container">
            <h3>Detalle Ticket</h3>
            <hr />
            <dl class="uk-description-list uk-description-list-divider">
                <dt>ID</dt>
                <asp:Label runat="server" ID="lblID"></asp:Label>
                <dt>Descripcion De Inicial</dt>
                <dd>
                    <asp:Label runat="server" ID="lblDescripcionInicial"/></dd>
                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Usuario:</label>
                    <div class="uk-form-controls">
                        <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="btn btn-secondary dropdown-toggle" Style="text-align: left;" form-check-input required></asp:DropDownList>
                    </div>
                </div>
                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Tipo:</label>
                    <div class="uk-form-controls">
                        <asp:DropDownList ID="ddlTipoTicket" runat="server" CssClass="btn btn-secondary dropdown-toggle" Style="text-align: left;" form-check-input required></asp:DropDownList>
                    </div>
                </div>
                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Prioridad:</label>
                    <div class="dropdown">
                        <asp:DropDownList ID="ddlPrioridad" runat="server" CssClass="btn btn-secondary dropdown-toggle" Style="text-align: left;" form-check-input required>
                        </asp:DropDownList>
                    </div>
                </div>
                <dt>Cliente Afectado</dt>
                <dd>
                    <asp:Label runat="server" ID="lblClienteAfectado" /></dd>
                <dt>Fecha De Creacion</dt>
                <dd>
                    <asp:Label runat="server" ID="lblFechaCreacion" /></dd>
                <dt>Fecha De Cierre</dt>
                <dd>
                    <asp:Label runat="server" ID="lblFechaCierre" /></dd>
                <dt>Estado</dt>
                <div class="uk-margin">
                    <div class="dropdown">
                        <asp:DropDownList ID="ddlEstado" runat="server" CssClass="btn btn-secondary dropdown-toggle" Style="text-align: left;" form-check-input required AutoPostBack="true" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
            </dl>
        </div>
    </div>

    <div class="uk-container">
        <button class="uk-button uk-button-default uk-button-large" type="button" uk-toggle="target: #modal-editar-ticket">Editar Ticket</button>
        <button class="uk-button uk-button-secondary uk-button-large">Eliminar Ticket</button>
    </div>

    <!--Inicio Modal EDITAR Ticket-->
    <div id="modal-editar-ticket" class="uk-flex-top" uk-modal>
        <div class="uk-modal-dialog uk-modal-body uk-margin-auto-vertical">
            <h3 class="uk-heading-divider">Editar ticket</h3>

            <button class="uk-modal-close-default" type="button" uk-close></button>

            <div class="uk-form-stacked">
                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Tipo:</label>
                    <div class="uk-form-controls">
                        <asp:DropDownList ID="TipoDDL" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="uk-form-stacked">
                    <div class="uk-margin">
                        <label class="uk-form-label" for="form-stacked-text">Prioridad:</label>
                        <asp:DropDownList ID="PrioridadDDL" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="uk-form-stacked">
                    <div class="uk-margin">
                        <label class="uk-form-label" for="form-stacked-text">Descripción inicial:</label>
                        <asp:TextBox ID="TextDescripcionInicial" runat="server" CssClass="uk-input" />
                    </div>
                </div>
                <div class="uk-form-stacked">
                    <div class="uk-margin">
                        <label class="uk-form-label" for="form-stacked-text">Cliente afectado:</label>
                        <asp:TextBox ID="TextClienteAfectado" runat="server" CssClass="uk-input" />
                    </div>
                </div>

                <%--  <asp:Button ID="btnGuardar" runat="server" Text="Guardar Usuario" OnClick="btnGuardar_Click" CssClass="uk-button uk-button-secondary uk-width-1-1" />--%>
            </div>
        </div>
    </div>
    <!--FIN Modal EDITAR Ticket-->

</asp:Content>
