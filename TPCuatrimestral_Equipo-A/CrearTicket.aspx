<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearTicket.aspx.cs" Inherits="TPCuatrimestral_Equipo_A.CrearTicket" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-2"></div>
    <div class="container">
            <h3 class="uk-heading-divider">Agregar Ticket</h3>
            <div class="uk-margin">
                <label class="uk-form-label" for="form-stacked-text">Cliente:</label>
                <div class="uk-form-controls row">
                    <div class="col-5">
                        <asp:TextBox runat="server" ID="tbBuscarPorDNI" placeholder="Buscar cliente por DNI..." CssClass="uk-input" />
                        <asp:LinkButton ID="buttonBuscarPorDNI" runat="server" OnClick="buttonBuscarPorDNI_Click">
                                <i class="lupita">
                                    <svg xmlns="http://www.w3.org/2000/svg" class="input-icon" viewBox="0 0 20 20" fill="currentColor" width="20" height="20">
                                    <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd" />
                                    </svg>
                                </i>
                        </asp:LinkButton>
                    </div>
                    <div class="col-5">
                        <asp:TextBox runat="server" ID="txBuscarPorID" placeholder="Buscar cliente por ID..." CssClass="uk-input" />
                        <asp:LinkButton ID="buttonBuscarPorID" runat="server" OnClick="buttonBuscarPorID_Click">
                                <i class="lupita">
                                    <svg xmlns="http://www.w3.org/2000/svg" class="input-icon" viewBox="0 0 20 20" fill="currentColor" width="20" height="20">
                                    <path fill-rule="evenodd" d="M8 4a4 4 0 100 8 4 4 0 000-8zM2 8a6 6 0 1110.89 3.476l4.817 4.817a1 1 0 01-1.414 1.414l-4.816-4.816A6 6 0 012 8z" clip-rule="evenodd" />
                                    </svg>
                                </i>
                        </asp:LinkButton>
                    </div>
                    <div class="col-1"></div>
                    <div class="col-md-11">
                        <asp:TextBox Text="" ID="textResultadoCliente" runat="server" CssClass="form-control" ReadOnly form-check-input required />
                        <asp:Label ID="labelValidarCliente" runat="server" Text="Debes seleccionar un cliente para continuar" Visible="false" />
                        <asp:Label ID="labelClienteValido" runat="server" Text="Cliente encontrado!" Visible="false" />
                    </div>
                </div>
            </div>
            <div class="uk-form-stacked">
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
                <div class="uk-margin">
                    <label class="uk-form-label" for="form-stacked-text">Usuario:</label>
                    <div class="uk-form-controls">
                        <asp:DropDownList ID="ddlUsuario" runat="server" CssClass="btn btn-secondary dropdown-toggle" Style="text-align: left;" form-check-input required></asp:DropDownList>
                    </div>
                </div>
                <div class="uk-margin col-11">
                    <label class="uk-form-label" for="form-stacked-text">Descripción:</label>
                    <div class="uk-form-controls">
                        <asp:TextBox ID="textDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
                        <asp:Label ID="labelValidarDescripcion" runat="server" Text="Debes completar con una descripción para continuar" Visible="false" ViewStateMode="Enabled" />
                    </div>
                </div>
                <div class="col-11">
                    <asp:Label Text="" runat="server" ID="txtAgregaCliente" Visible="false" />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cliente" CssClass="uk-button uk-button-secondary uk-width-1-1" OnClick="btnGuardar_Click" />
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="uk-button uk-button-secondary uk-width-1-1" OnClick="btnVolver_Click" Visible="false" />
                </div>
            </div>
    </div>
    <div class="col-2"></div>
</asp:Content>