<%@ Page EnableEventValidation="true" Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleTicket.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.DetalleTicket" MaintainScrollPositionOnPostback="true" %>

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
                <dd class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Usuario:</label>
                    <div class="uk-form-controls">
                        <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="btn btn-secondary dropdown-toggle" Style="text-align: left;" form-check-input required></asp:DropDownList>
                    </div>
                </dd>
                <dd class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Tipo:</label>
                    <div class="uk-form-controls">
                        <asp:DropDownList ID="ddlTipoTicket" runat="server" CssClass="btn btn-secondary dropdown-toggle" Style="text-align: left;" form-check-input required></asp:DropDownList>
                    </div>
                </dd>
                <dd class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Prioridad:</label>
                    <div class="dropdown">
                        <asp:DropDownList ID="ddlPrioridad" runat="server" CssClass="btn btn-secondary dropdown-toggle" Style="text-align: left;" form-check-input required>
                        </asp:DropDownList>
                    </div>
                </dd>
                <dt>Cliente Afectado</dt>
                <dd>
                    <asp:Label runat="server" ID="lblClienteAfectado" /></dd>
                <dt>Fecha De Creacion</dt>
                <dd>
                    <asp:Label runat="server" ID="lblFechaCreacion" /></dd>
                <dt>Fecha De Cierre</dt>
                <dd>
                    <asp:Label runat="server" ID="lblFechaCierre" /></dd>
                <dt>Comentarios</dt>
                <dd>
                    <asp:Label runat="server" ID="labelComentarios" /></dd>
                <dt>Añadir comentario</dt>
                <dd class="uk-margin col-11">
                    <div class="uk-form-controls">
                        <asp:TextBox ID="textComentario" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                        <asp:Label ID="labelVerificacionCierre" runat="server" Text="Debes completar con una descripción del cierre para continuar" Visible="false" ViewStateMode="Enabled" />
                    </div>
                </dd>
                <dd>
                    <asp:Label runat="server" ID="lblEstadoTicket" /></dd>
                <dd class="uk-container">
                    <asp:Button ID="btnCambioEstado1" Text="" runat="server" CssClass="uk-button uk-button-default uk-button-large" type="button" OnClick="btnCambioEstado1_Click" Enabled="false" />
                </dd>
                <dd class="uk-container">
                    <asp:Button ID="btnCambioEstado2" Text="" runat="server" CssClass="uk-button uk-button-default uk-button-large" type="button" OnClick="btnCambioEstado2_Click" Enabled="false" />
                </dd>

            </dl>
        </div>
    </div>

    <div class="uk-container">
        <asp:Button ID="btnGuardarCambios" Text="Guardar cambios" runat="server" CssClass="uk-button uk-button-default uk-button-large" type="button" OnClick="btnGuardarCambios_Click" />
    </div>
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
 <script type="text/javascript">
     $("#<%= textComentario.ClientID %>").keyup(function () {
         $("#<%= btnCambioEstado1.ClientID %>").attr("disabled", $(this).val() == "");
         $("#<%= btnCambioEstado2.ClientID %>").attr("disabled", $(this).val() == "");
        });
 </script>

</asp:Content>
