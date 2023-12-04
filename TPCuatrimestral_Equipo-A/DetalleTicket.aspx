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
                    <asp:Label runat="server" ID="lblDescripcionInicial" /></dd>
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
                <dd>
                    <asp:Label runat="server" ID="lblEstadoTicket" /></dd>
                <div class="uk-container">
                    <asp:Button ID="btnCambioEstado1" Text="" runat="server" CssClass="uk-button uk-button-default uk-button-large" type="button" OnClick="btnCambioEstado1_Click" />
                </div>
                <div class="uk-container">
                    <asp:Button ID="btnCambioEstado2" Text="" runat="server" CssClass="uk-button uk-button-default uk-button-large" type="button" OnClick="btnCambioEstado2_Click" />
                </div>
                <div class="uk-margin col-11">
                    <asp:Label ID="labelDescripcionCierre" Text="Descripción cierre:" runat="server" Visible="false" />
                    <div class="uk-form-controls">
                        <asp:TextBox ID="textCierre" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" Visible="false" />
                        <asp:Label ID="labelVerificacionCierre" runat="server" Text="Debes completar con una descripción del cierre para continuar" Visible="false" ViewStateMode="Enabled" />
                    </div>
                </div>
            </dl>
        </div>
    </div>

    <div class="uk-container">
        <asp:Button ID="btnGuardarCambios" Text="Guardar cambios" runat="server" CssClass="uk-button uk-button-default uk-button-large" type="button" OnClick="btnGuardarCambios_Click" />
    </div>

</asp:Content>
